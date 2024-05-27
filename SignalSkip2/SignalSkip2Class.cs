using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EnergyDetectorModeling.SignalSkip2
{
    public class SignalSkip2Class
    {
        public SignalSkip2Class(TabPage SignalSkip2, double[] p, double[] H, double N)
        {
            Chart chart = CreateChart(SignalSkip2);

            ChartArea chartArea = CreateChartArea();
            chart.ChartAreas.Add(chartArea);

            Legend legend = CreateLegend();
            chart.Legends.Add(legend);

            CreateGraph(chart, p, H, N);

            SetChartAreaStyle(chartArea, p);

            SignalSkip2.Controls.Add(chart);
        }

        private Chart CreateChart(TabPage SignalSkip2) => new Chart
        {
            Width = 800,
            Height = 600,
            Parent = SignalSkip2,
            Location = new Point(10, 10),
            Name = "chart4",
        };

        private ChartArea CreateChartArea() => new ChartArea();

        private Legend CreateLegend() => new Legend
        {
            Name = "MyLegend"
        };

        private void CreateGraph(Chart chart, double[] p0, double[] H, double N)
        {

            for (double h = H[0]; h <= H[1]; h += H[2])
            {
                Series series = CreateSeries(h, N);

                for (double p = p0[0]; p <= p0[1]; p += p0[2])
                {
                    double P = Q((h - N - p) / (Math.Sqrt(2 * N + p)));
                    P = 1 - P;
                    series.Points.AddXY(p, P);
                }

                chart.Series.Add(series);
            }
        }

        private Series CreateSeries(double h, double N) => new Series
        {
            Name = "h = " + h + " N = " + N,
            ChartType = SeriesChartType.Line,
            Legend = "MyLegend",
        };

        private void SetChartAreaStyle(ChartArea chartArea, double[] P)
        {
            chartArea.AxisX.Title = "P";
            chartArea.AxisY.Title = "P1";
            chartArea.AxisX.Minimum = P[0];
            chartArea.AxisX.Maximum = P[1];
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
