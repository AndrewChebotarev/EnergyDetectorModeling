using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EnergyDetectorModeling.FalseAlarm2
{
    public class FalseAlarm2Class
    {
        public FalseAlarm2Class(TabPage FalseAlarm2, double[] N, double[] H)
        {
            Chart chart = CreateChart(FalseAlarm2);

            ChartArea chartArea = CreateChartArea();
            chart.ChartAreas.Add(chartArea);

            Legend legend = CreateLegend();
            chart.Legends.Add(legend);

            CreateGraph(chart, N, H);

            SetChartAreaStyle(chartArea, N);

            FalseAlarm2.Controls.Add(chart);
        }

        private Chart CreateChart(TabPage FalseAlarm2) => new Chart
        {
            Width = 800,
            Height = 600,
            Parent = FalseAlarm2,
            Location = new Point(10, 10),
            Name = "chart2",
        };

        private ChartArea CreateChartArea() => new ChartArea();

        private Legend CreateLegend() => new Legend
        {
            Name = "MyLegend"
        };

        private void CreateGraph(Chart chart, double[] N, double[] H)
        {
            
            for (double h = H[0]; h <= H[1]; h += H[2])
            {
                Series series = CreateSeries(h);

                for (double n = N[0]; n <= N[1]; n += N[2])
                {
                    double P = Q((h - n) / (Math.Sqrt(2 * n)));
                    series.Points.AddXY(n, P);
                }

                chart.Series.Add(series);
            }
        }

        private Series CreateSeries(double h) => new Series
        {
            Name = "h = " + h,
            ChartType = SeriesChartType.Line,
            Legend = "MyLegend",
        };

        private void SetChartAreaStyle(ChartArea chartArea, double[] N)
        {
            chartArea.AxisX.Title = "N";
            chartArea.AxisY.Title = "P0";
            chartArea.AxisX.Minimum = N[0];
            chartArea.AxisX.Maximum = N[1];
            chartArea.AxisY.Minimum = 0;
            chartArea.AxisY.Maximum = 1;
        }

        private double SimpsonRule(Func<double, double> f, double a, double b, int n)
        {
            double h = (b - a) / n;
            double k = 0.0;
            double x = a + h;

            for (int i = 1; i < n; i += 2)
            {
                k += 4.0 * f(x);
                x += 2.0 * h;
            }

            x = a + 2.0 * h;

            for (int i = 2; i < n - 1; i += 2)
            {
                k += 2.0 * f(x);
                x += 2.0 * h;
            }

            return (h / 3.0) * (f(a) + f(b) + k);
        }

        private double Integrand(double t) => Math.Exp(-t * t / 2.0) / Math.Sqrt(2.0 * Math.PI);

        public double Q(double x) => SimpsonRule(Integrand, x, 10.0, 1000);
    }
}