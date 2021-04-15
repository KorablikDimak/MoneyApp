using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NLog;
using OxyPlot;
using OxyPlot.Series;

namespace NewFamilyMoney
{
    public partial class Form2 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public DateTime newDateTime { get; private set; }
        public List<string[,]> listOfValues { get; private set; }

        public Form2(DateTime newDateTime)
        {
            this.newDateTime = newDateTime;
            listOfValues = new List<string[,]>();
            
            listOfValues.Add(Program.LoadData(newDateTime));

            InitializeComponent();
            dateTimeForDiagrams.Value = this.newDateTime;
            GetDataForDiagrams();
        }

        private void dateTimeForDiagrams_CloseUp(object sender, EventArgs e)
        {
            listOfValues.Clear();
            newDateTime = dateTimeForDiagrams.Value;

            listOfValues.Add(Program.LoadData(newDateTime));
            GetDataForDiagrams();
            comboBox1.Text = "За сутки";
        }

        private void GetDataForDiagrams()
        {
            var modelP1 = new PlotModel { Title = "Статистика доходов" };
            dynamic seriesP1 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };
            var modelP2 = new PlotModel { Title = "Статистика расходов" };
            dynamic seriesP2 = new PieSeries { StrokeThickness = 2.0, InsideLabelPosition = 0.5, AngleSpan = 360, StartAngle = 0, InnerDiameter = 0.4 };

            double totalSpend = 0;
            double totalProfit = 0;
            HashSet<string> names = new HashSet<string>();

            foreach (string[,] values in listOfValues)
            {
                for (int i = 0; i < values.GetLength(0); i++)
                {
                    names.Add(values[i, 0]);
                }
            }

            foreach (string name in names) 
            {
                foreach (string[,] values in listOfValues)
                {
                    for (int i = 0; i < values.GetLength(0); i++)
                    {
                        if (values[i, 4] == "spend" && values[i, 0] == name)
                        {
                            double value;
                            double.TryParse((values[i, 3] ?? "0").ToString(), out value);
                            totalSpend += value;
                        }
                        else if (values[i, 4] == "profit" && values[i, 0] == name)
                        {
                            double value;
                            double.TryParse((values[i, 3] ?? "0").ToString(), out value);
                            totalProfit += value;
                        }
                    }
                }
                if (totalProfit != 0)
                {
                    seriesP1.Slices.Add(new PieSlice(name, totalProfit) { IsExploded = true });
                }
                if (totalSpend != 0)
                {
                    seriesP2.Slices.Add(new PieSlice(name, totalSpend) { IsExploded = true });
                }
                totalSpend = 0;
                totalProfit = 0;
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
                listOfValues.Add(Program.LoadData(newDateTime));
                newDateTime = newDateTime.AddDays(-1);
            }

            GetDataForDiagrams();

            logger.Info("успешная отработка функции для многодневной статистики");
        }
    }
}
