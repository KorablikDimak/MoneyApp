using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NLog;
using OxyPlot;
using OxyPlot.Series;

namespace NewFamilyMoney
{
    public partial class DiagramForm : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        private DateTime newDateTime;
        private List<string[,]> listOfValues;
        public DiagramForm(DateTime newDateTime)
        {
            this.newDateTime = newDateTime;
            listOfValues = new List<string[,]>();
            
            listOfValues.Add(LoadFromFiles.LoadData(newDateTime));

            InitializeComponent();
            dateTimeForDiagrams.Value = this.newDateTime;
            GetDataForDiagrams();
        }

        private void dateTimeForDiagrams_CloseUp(object sender, EventArgs e)
        {
            listOfValues.Clear();
            newDateTime = dateTimeForDiagrams.Value;

            listOfValues.Add(LoadFromFiles.LoadData(newDateTime));
            GetDataForDiagrams();
            comboBox1.Text = "За сутки";
        }

        private void GetDataForDiagrams()
        {
            var modelP1 = new PlotModel { Title = "Статистика доходов" };
            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };
            var modelP2 = new PlotModel { Title = "Статистика расходов" };
            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };

            Dictionary<string, double[]> namesForChart = new Dictionary<string, double[]>();

            foreach (string[,] values in listOfValues)
            {
                for (int i = 0; i < values.GetLength(0); i++)
                {
                    string name = values[i, 0];

                    if (namesForChart.ContainsKey(name))
                    {
                        double value;
                        double.TryParse(values[i, 3] ?? "0", out value);

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
                        double value;
                        double.TryParse(values[i, 3] ?? "0", out value);

                        if (values[i, 4] == "spend")
                        {
                            namesForChart.Add(values[i, 0], new[] {0, value});
                        }
                        else
                        {
                            namesForChart.Add(values[i, 0], new[] {value, 0});
                        }
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

            logger.Info("построение диаграммы успешно");
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            logger.Info("изменено значение comboBox1");

            if (comboBox1.SelectedIndex == 0)
            {
                GetDiagramsForManyDays(1);
            }

            else if (comboBox1.SelectedIndex == 1)
            {
                GetDiagramsForManyDays(7);
            }

            else if (comboBox1.SelectedIndex == 2)
            {
                GetDiagramsForManyDays(30);
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                GetDiagramsForManyDays(365);
            }

            else if (comboBox1.SelectedIndex == 3)
            {
                GetDiagramsForManyDays(10000);
            }

            newDateTime = dateTimeForDiagrams.Value;
        }

        private void GetDiagramsForManyDays(int days)
        {
            listOfValues.Clear();

            for (int i = 0; i < days; i++)
            {
                string[,] values;
                values = LoadFromFiles.LoadData(newDateTime);
                if (values != null)
                {
                    listOfValues.Add(values);
                    newDateTime = newDateTime.AddDays(-1);
                }
            }

            GetDataForDiagrams();

            logger.Info("успешная отработка функции для многодневной статистики");
        }
    }
}
