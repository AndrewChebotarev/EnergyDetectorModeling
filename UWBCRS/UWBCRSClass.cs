using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace EnergyDetectorModeling.UWBCRS
{
    public class UWBCRSClass
    {
        public UWBCRSClass(Chart defaultSignal, Chart noDefaultSugnal, double[] dataInfo, TextBox PeriodTextBox) 
        {
            defaultSignal.ChartAreas[0].AxisX.Title = "t";
            defaultSignal.ChartAreas[0].AxisY.Title = "S(t)";

            double y;
            double x = 0;
            double a = 0;
            double b = dataInfo[0];
            double tSignal = dataInfo[1];
            double A = dataInfo[2];
            double w = dataInfo[3];
            double phi = dataInfo[4];
            double h = dataInfo[5];
            double period = 2 * Math.PI / w;

            PeriodTextBox.Text = period.ToString();

            while (x <= b)
            {
                if (x <= tSignal)
                {
                    y = A * Math.Cos((w * x) + phi);
                    defaultSignal.Series[0].Points.AddXY(x, y);
                    x += h;
                }
                else
                {
                    y = 0;
                    defaultSignal.Series[0].Points.AddXY(x, y);
                    x += h;
                }
            }

            x = a;

            while (x <= 1)
            {
                y = A * Math.Cos((2 * Math.PI * ((tSignal / period) * x)) + phi);
                noDefaultSugnal.Series[0].Points.AddXY(x, y);
                x += h;
            }
        }
    }
}
