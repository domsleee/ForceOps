"use strict";
      (function () {
        // Colors from https://github.com/github/linguist/blob/master/lib/linguist/languages.yml
        const toolColors = {
          cargo: "#dea584",
          go: "#00add8",
          benchmarkjs: "#f1e05a",
          benchmarkluau: "#000080",
          pytest: "#3572a5",
          googlecpp: "#f34b7d",
          catch2: "#f34b7d",
          julia: "#a270ba",
          jmh: "#b07219",
          benchmarkdotnet: "#178600",
          customBiggerIsBetter: "#38ff38",
          customSmallerIsBetter: "#ff3838",
          _: "#333333",
        };

        function init() {
          function collectBenchesPerTestCase(entries) {
            const map = new Map();
            for (const entry of entries) {
              const { commit, date, tool, benches } = entry;
              for (const bench of benches) {
                const result = { commit, date, tool, bench };
                const arr = map.get(bench.name);
                if (arr === undefined) {
                  map.set(bench.name, [result]);
                } else {
                  arr.push(result);
                }
              }
            }
            return map;
          }

          processData(window.BENCHMARK_DATA);
          const data = window.BENCHMARK_DATA;

          // Render header
          document.getElementById("last-update").textContent = new Date(
            data.lastUpdate
          ).toString();
          const repoLink = document.getElementById("repository-link");
          repoLink.href = data.repoUrl;
          repoLink.textContent = data.repoUrl;

          // Render footer
          document.getElementById("dl-button").onclick = () => {
            const dataUrl = "data:," + JSON.stringify(data, null, 2);
            const a = document.createElement("a");
            a.href = dataUrl;
            a.download = "benchmark_data.json";
            a.click();
          };

          // Prepare data points for charts
          const allBenchesPerTestCase = Object.keys(data.entries).map(
            (name) => ({
              name,
              benchesPerTestCase: collectBenchesPerTestCase(data.entries[name]),
            })
          );

          let nameToBenchGroup = [];
          for (const benchesPerTestCase of allBenchesPerTestCase) {
            const groupingByKey = {};
            for (const [
              key,
              dataSet,
            ] of benchesPerTestCase.benchesPerTestCase.entries()) {
              const splitKey = key.split("(")[1];
              if (!(splitKey in groupingByKey)) {
                groupingByKey[splitKey] = { dataSets: [] };
              }
              groupingByKey[splitKey].dataSets.push({ dataSet, key });
            }
            nameToBenchGroup.push(groupingByKey);
          }

          return nameToBenchGroup;
        }

        function renderAllCharts(benchSetGroups) {
          const main = document.getElementById("main");
          for (const benchSetGroup of benchSetGroups) {
            renderBenchSet(benchSetGroup, main);
          }
        }

        function renderBenchSet(benchSetGroups, main) {
          const setElem = document.createElement("div");
          setElem.className = "benchmark-set";
          main.appendChild(setElem);

          const nameElem = document.createElement("h1");
          nameElem.className = "benchmark-title";
          nameElem.textContent = name;
          setElem.appendChild(nameElem);

          const graphsElem = document.createElement("div");
          graphsElem.className = "benchmark-graphs";
          setElem.appendChild(graphsElem);

          for (const [groupName, benchSetGroup] of Object.entries(
            benchSetGroups
          )) {
            renderGraph(graphsElem, groupName, benchSetGroup.dataSets);
          }
        }

        function renderGraph(parent, groupName, dataSets) {
          const canvas = document.createElement("canvas");
          canvas.className = "benchmark-chart";
          parent.appendChild(canvas);

          const firstDataset = dataSets[0].dataSet;

          const fixLabel = (s) => s.split("(")[0].split(".").at(-1);

          const color =
            toolColors[firstDataset.length > 0 ? firstDataset[0].tool : "_"];
          const data = {
            labels: firstDataset.map((d) => d.commit.id.slice(0, 7)),
            datasets: [
              {
                label: fixLabel(dataSets[0].key),
                data: dataSets[0].dataSet.map((d) => d.bench.value),
                borderColor: color,
                backgroundColor: color + "10", // Add alpha for #rrggbbaa
              },
              {
                label: fixLabel(dataSets[1].key),
                data: dataSets[1].dataSet.map((d) => d.bench.value),
                borderColor: toolColors.julia,
                backgroundColor: toolColors.julia + "20", // Add alpha for #rrggbbaa
              },
            ],
          };
          const options = {
            scales: {
              xAxes: [
                {
                  scaleLabel: {
                    display: true,
                    labelString: "commit",
                  },
                },
              ],
              yAxes: [
                {
                  scaleLabel: {
                    display: true,
                    labelString:
                      firstDataset.length > 0 ? firstDataset[0].bench.unit : "",
                  },
                  ticks: {
                    beginAtZero: true,
                  },
                },
              ],
            },
            tooltips: {
              callbacks: {
                afterTitle: (items) => {
                  const { index } = items[0];
                  const data = firstDataset[index];
                  return (
                    "\n" +
                    data.commit.message +
                    "\n\n" +
                    data.commit.timestamp +
                    " committed by @" +
                    data.commit.committer.username +
                    "\n"
                  );
                },
                label: (item) => {
                  let label = item.value;
                  const { range, unit } = firstDataset[item.index].bench;
                  label += " " + unit;
                  if (range) {
                    label += " (" + range + ")";
                  }
                  return label;
                },
                afterLabel: (item) => {
                  const { extra } = firstDataset[item.index].bench;
                  return extra ? "\n" + extra : "";
                },
              },
            },
            onClick: (_mouseEvent, activeElems) => {
              if (activeElems.length === 0) {
                return;
              }
              // XXX: Undocumented. How can we know the index?
              const index = activeElems[0]._index;
              const url = firstDataset[index].commit.url;
              window.open(url, "_blank");
            },
            title: {
              display: true,
              text: groupName.split(')')[0],
            },
          };

          new Chart(canvas, {
            type: "line",
            data,
            options,
          });
        }

        function processData(data) {
          for (const entryGroup of Object.values(data.entries)) {
            for (const entry of entryGroup) {
              for (const bench of entry.benches) {
                convertBench(bench, 'ms');
              }
            }
          }
        }

        function convertBench(bench, newUnit) {
          if (bench.unit === 'ns' && newUnit === 'ms') {
            bench.value = round(bench.value / 1e6);
            const benchRange = bench.range.split(' ').at(-1);
            bench.range = `± ${round(benchRange/1e6)}`;
            bench.unit = newUnit;
          }
        }

        function round(val) {
          return Math.round(val * 100) / 100;
        }

        renderAllCharts(init()); // Start
      })();