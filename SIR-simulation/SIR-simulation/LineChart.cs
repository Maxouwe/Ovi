using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace SIR_simulation
{
    internal class LineChart : Chart
    {
        Font axisFont;
        public LineChart(double xMin, double xMax, double yMin, double yMax, int interval)
        {
            this.Series.Add("Susceptibles");
            this.Series.Add("Infected");
            this.Series.Add("Recovered");
            this.ChartAreas.Add("ChartArea");

            this.Series["Susceptibles"].ChartType = SeriesChartType.Line;
            this.Series["Susceptibles"].BorderWidth = 3;
            this.Series["Susceptibles"].BorderColor = Color.Blue;

            this.Series["Infected"].ChartType = SeriesChartType.Line;
            this.Series["Infected"].BorderWidth = 3;
            this.Series["Infected"].BorderColor = Color.Red;

            this.Series["Recovered"].ChartType = SeriesChartType.Line;
            this.Series["Recovered"].BorderWidth = 3;
            this.Series["Recovered"].BorderColor = Color.Green;

            axisFont = new Font("Times New Roman", 5.0f);

            this.ChartAreas["ChartArea"].AxisX.Minimum = xMin;
            this.ChartAreas["ChartArea"].AxisX.Maximum = xMax;
            this.ChartAreas["ChartArea"].AxisX.LabelStyle.Font = axisFont;
            this.ChartAreas["ChartArea"].AxisX.Interval = interval;
            this.ChartAreas["ChartArea"].AxisX.Title = "amount of days";

            this.ChartAreas["ChartArea"].AxisY.Minimum = yMin;
            this.ChartAreas["ChartArea"].AxisY.Maximum = yMax;
            this.ChartAreas["ChartArea"].AxisY.LabelStyle.Font = axisFont;
            this.ChartAreas["ChartArea"].AxisY.Interval = 0.05;
            this.ChartAreas["ChartArea"].AxisY.Title = "population fraction";
        }
    }

    class MyForm : Form
    {
        double totalDays;
        List<double> ySus;
        List<double> yInf;
        List<double> yRec;
        LineChart chart;

        public MyForm(double totalDays, double yMin, double yMax, int interval)
        {
            this.totalDays = totalDays;
            this.Size = new Size(600, 600);
            chart = new LineChart(0, totalDays, yMin, yMax, interval);
            chart.Size = new Size(500, 500);

            this.Controls.Add(chart);

            ySus = new List<double>();

            yInf = new List<double>();
            yRec = new List<double>();
        }

        public void addValues(List<double> ySus, List<double> yInf, List<double> yRec)
        {
            this.ySus = ySus;
            this.yInf = yInf;
            this.yRec = yRec;

            for (int i = 0;i < totalDays;i++)
            {
                chart.Series["Susceptibles"].Points.AddXY((double)i, ySus[i]);
                chart.Series["Infected"].Points.AddXY((double)i, yInf[i]);
                chart.Series["Recovered"].Points.AddXY((double)i, yRec[i]);
            }
        }
    }
}
