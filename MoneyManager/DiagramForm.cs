using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OxyPlot;
using OxyPlot.Series;

namespace MoneyManager
{
    public partial class DiagramForm : Form
    {
        private DateTime _newDateTime;
        private readonly List<string[,]> _listOfValues;
        public DiagramForm(DateTime newDateTime)
        {
            _newDateTime = newDateTime;
            _listOfValues = new List<string[,]> {LoadFromFiles.LoadData(newDateTime)};

            InitializeComponent();
            dateTimeForDiagrams.Value = _newDateTime;
            GetDataForDiagrams();
        }

        private void CloseUpDateTimeForDiagrams(object sender, EventArgs e)
        {
            _listOfValues.Clear();
            _newDateTime = dateTimeForDiagrams.Value;

            _listOfValues.Add(LoadFromFiles.LoadData(_newDateTime));
            GetDataForDiagrams();
            comboBox1.Text = "За сутки";
        }

        private void GetDataForDiagrams()
        {
            var modelP1 = new PlotModel { Title = "Статистика доходов" };
            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };
            var modelP2 = new PlotModel { Title = "Статистика расходов" };
            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };

            var namesForChart = new Dictionary<string, double[]>();

            foreach (string[,] values in _listOfValues)
            {
                for (int i = 0; i < values.GetLength(0); i++)
                {
                    string name = values[i, 0];

                    if (namesForChart.ContainsKey(name))
                    {
                        double.TryParse(values[i, 3] ?? "0", out var value);

                        if (values[i, 4] == "spend")
                        {
                            namesForChart[name][1] += value;
                        }
                        else
                        {
                            namesForChart[name][0] += value;
                        }
                    }
                    else
                    {
                        double.TryParse(values[i, 3] ?? "0", out var value);

                        namesForChart.Add(values[i, 0], values[i, 4] == "spend" ? new[] {0, value} : new[] {value, 0});
                    }
                }
            }

            foreach (var name in namesForChart.Keys)
            {
                double totalProfit = namesForChart[name][0];
                
                if (totalProfit != 0)
                {
                    seriesP1.Slices.Add(new PieSlice(name, totalProfit) { IsExploded = true });
                }
                double totalSpend = namesForChart[name][1];
                
                if (totalSpend != 0)
                {
                    seriesP2.Slices.Add(new PieSlice(name, namesForChart[name][1]) { IsExploded = true });
                }
            }

            modelP1.Series.Add(seriesP1);
            plotView1.Model = modelP1;
            modelP2.Series.Add(seriesP2);
            plotView2.Model = modelP2;
        }

        private void ComboBoxSelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    GetDiagramsForManyDays(1);
                    break;
                case 1:
                    GetDiagramsForManyDays(7);
                    break;
                case 2:
                    GetDiagramsForManyDays(30);
                    break;
                case 3:
                    GetDiagramsForManyDays(365);
                    break;
                default:
                {
                    if (comboBox1.SelectedIndex == 3)
                    {
                        GetDiagramsForManyDays(10000);
                    }

                    break;
                }
            }

            _newDateTime = dateTimeForDiagrams.Value;
        }

        private void GetDiagramsForManyDays(int days)
        {
            _listOfValues.Clear();

            for (int i = 0; i < days; i++)
            {
                var values = LoadFromFiles.LoadData(_newDateTime);
                if (values == null) continue;
                _listOfValues.Add(values);
                _newDateTime = _newDateTime.AddDays(-1);
            }

            GetDataForDiagrams();
        }
    }
}
