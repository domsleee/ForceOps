namespace ForceOps
{
    public class Program
    {
        static void Main()
        {
            ForceOpsMethods.MoveFileOrFolder(@"C:\Users\user\Documents\hi.txt", @"C:\Users\user\Documents\hi_moved.txt");
        }
    }
}