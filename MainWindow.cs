using EnergyDetectorModeling.FalseAlarm1;
using EnergyDetectorModeling.FalseAlarm2;
using EnergyDetectorModeling.SignalSkip1;
using EnergyDetectorModeling.SignalSkip2;
using EnergyDetectorModeling.SignalSkip3;
using EnergyDetectorModeling.UWBCRS;
using System;
using System.Windows.Forms;

namespace EnergyDetectorModeling
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            InitializeUWBCRS();

            InitializeFalseAlarm1();
            InitializeFalseAlarm2();

            InitializeSignalSkip1();
            InitializeSignalSkip2();
            InitializeSignalSkip3();
        }

        private void InitializeUWBCRS()
        {
            try
            {
                double[] dataInfo = { Convert.ToDouble(MaxRangeX.Text), Convert.ToDouble(tDefaultSignal.Text), Convert.ToDouble(ADefaultSignal.Text),
                                        Convert.ToDouble(WDefaultSignal.Text), Convert.ToDouble(phiDefaultSignal.Text), Convert.ToDouble(xStep.Text)};

                UWBCRSClass uwbcrs = new UWBCRSClass(DefaultSignal, NoDefaultSignal, dataInfo, TDefaultSignal2);
            }
            catch 
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButtonUWBCRS_Click(object sender, EventArgs e)
        {
            DefaultSignal.Series[0].Points.Clear();
            NoDefaultSignal.Series[0].Points.Clear();

            InitializeUWBCRS();
        }

        private void InitializeFalseAlarm1()
        {
            try
            {
                double[] N = { Convert.ToDouble(NStartFalseAlarm1.Text), Convert.ToDouble(NNumberFalseAlarm1.Text), Convert.ToDouble(NRangeFalseAlarm1.Text) };
                double[] H = { Convert.ToDouble(hStartFalseAlarm1.Text), Convert.ToDouble(hNumberFalseAlarm1.Text), Convert.ToDouble(hRangeFalseAlarm1.Text) };

                FalseAlarm1Class falseAlarm1 = new FalseAlarm1Class(FalseAlarm, N, H);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButtonFalseAlarm1_Click(object sender, EventArgs e)
        {
            FalseAlarm.Controls.RemoveByKey("chart1");
            InitializeFalseAlarm1();
        }

        private void InitializeFalseAlarm2()
        {
            try
            {
                double[] N = { Convert.ToDouble(NStartFalseAlarm2.Text), Convert.ToDouble(NNumberFalseAlarm2.Text), Convert.ToDouble(NRangeFalseAlarm2.Text) };
                double[] H = { Convert.ToDouble(hStartFalseAlarm2.Text), Convert.ToDouble(hNumberFalseAlarm2.Text), Convert.ToDouble(hRangeFalseAlarm2.Text) };

                FalseAlarm2Class falseAlarm2 = new FalseAlarm2Class(FalseAlarm2, N, H);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButtonFalseAlarm2_Click(object sender, EventArgs e)
        {
            FalseAlarm2.Controls.RemoveByKey("chart2");
            InitializeFalseAlarm2();
        }

        private void InitializeSignalSkip1()
        {
            try
            {
                double[] N = { Convert.ToDouble(NStartSignalSkip1.Text), Convert.ToDouble(NNumberSignalSkip1.Text), Convert.ToDouble(NRangeSignalSkip1.Text) };
                double[] H = { Convert.ToDouble(hStartSignalSkip1.Text), Convert.ToDouble(hNumberSignalSkip1.Text), Convert.ToDouble(hRangeSignalSkip1.Text) };
                double p = Convert.ToDouble(pNumberSignalSkip1.Text);

                SignalSkip1Class signalSkip1 = new SignalSkip1Class(SignalSkip1, N, H, p);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButtonSignalSkip1_Click(object sender, EventArgs e)
        {
            SignalSkip1.Controls.RemoveByKey("chart3");
            InitializeSignalSkip1();
        }

        private void InitializeSignalSkip2()
        {
            try
            {
                double[] p = { Convert.ToDouble(pStartSignalSkip2.Text), Convert.ToDouble(pNumberSignalSkip2.Text), Convert.ToDouble(pRangeSignalSkip2.Text) };
                double[] H = { Convert.ToDouble(hStartSignalSkip2.Text), Convert.ToDouble(hNumberSignalSkip2.Text), Convert.ToDouble(hRangeSignalSkip2.Text) };
                double N = Convert.ToDouble(NNumberSignalSkip2.Text);

                SignalSkip2Class signalSkip2 = new SignalSkip2Class(SignalSkip2, p, H, N);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButtonSignalSkip2_Click(object sender, EventArgs e)
        {
            SignalSkip2.Controls.RemoveByKey("chart4");
            InitializeSignalSkip2();
        }

        private void InitializeSignalSkip3()
        {
            try
            {
                double[] N = { Convert.ToDouble(NStartSignalSkip3.Text), Convert.ToDouble(NNumberSignalSkip3.Text), Convert.ToDouble(NRangeSignalSkip3.Text) };
                double[] H = { Convert.ToDouble(hStartSignalSkip3.Text), Convert.ToDouble(hNumberSignalSkip3.Text), Convert.ToDouble(hRangeSignalSkip3.Text) };
                double p = Convert.ToDouble(pNumberSignalSkip3.Text);

                SignalSkip3Class signalSkip3 = new SignalSkip3Class(SignalSkip3, N, H, p);
            }
            catch
            {
                MessageBox.Show("Ошибка ввода данных!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void EditButtonSignalSkip3_Click(object sender, EventArgs e)
        {
            SignalSkip3.Controls.RemoveByKey("chart5");
            InitializeSignalSkip3();
        }
    }
}
