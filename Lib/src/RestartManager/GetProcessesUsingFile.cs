using System.ComponentModel;
using System.Diagnostics;
using RestartManager;

namespace ForceOps
{
    static class RestartManagerWrapper
    {
        public static IEnumerable<Process> GetProcessesUsingFiles(params string[] filePaths)
        {
            if ((filePaths == null) || !(filePaths.Length > 0))
            {
                yield break;
            }

            int sessionHandle = 0;

            try
            {
                var startResult = NativeMethods.RmStartSession(
                    out sessionHandle,
                    0,
                    Guid.NewGuid().ToString("N"));

                if (startResult != RmResult.ERROR_SUCCESS)
                {
                    throw new Win32Exception("Failed to start a Restart Manager session.");
                }

                var registerResourcesResult = NativeMethods.RmRegisterResources(
                    sessionHandle,
                    (uint)filePaths.Length,
                    filePaths,
                    0U,
                    Array.Empty<RM_UNIQUE_PROCESS>(),
                    0U,
                    Array.Empty<string>());

                if (registerResourcesResult != RmResult.ERROR_SUCCESS)
                {
                    throw new Win32Exception("Failed to register target files to a Restart Manager session.");
                }

                // Get processes using target files with the session.
                uint pnProcInfoNeeded = 0;
                uint pnProcInfo = 0;
                RM_PROCESS_INFO[]? rgAffectedApps = null;

                RmResult getListResult;

                do
                {
                    getListResult = NativeMethods.RmGetList(
                        sessionHandle,
                        out pnProcInfoNeeded,
                        ref pnProcInfo,
                        rgAffectedApps!,
                        out var lpdwRebootReasons);

                    switch (getListResult)
                    {
                        case (uint)RmResult.ERROR_SUCCESS:
                            if (pnProcInfo == 0)
                            {
                                break;
                            }

                            foreach (var app in rgAffectedApps!)
                            {
                                Process? proc = null;
                                try
                                {
                                    proc = Process.GetProcessById((int)app.Process.dwProcessId);
                                }
                                catch (ArgumentException)
                                {
                                    // None (In case the process is no longer running).
                                }

                                if (proc != null)
                                {
                                    yield return proc;
                                }
                            }
                            break;

                        case RmResult.ERROR_MORE_DATA: // The size of RM_PROCESS_INFO array is not enough.
                                                       // Set RM_PROCESS_INFO array to store the processes.
                            rgAffectedApps = new RM_PROCESS_INFO[(int)pnProcInfoNeeded];
                            pnProcInfo = (uint)rgAffectedApps.Length;
                            break;

                        default:
                            throw new Win32Exception("Failed to get processes using target files with a Restart Manager session.");
                    }
                }
                while (getListResult != RmResult.ERROR_SUCCESS);
            }
            finally
            {
                NativeMethods.RmEndSession(sessionHandle);
            }
        }
    }
}
