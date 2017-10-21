using System;
using System.Windows;
using System.Windows.Threading;

namespace udp_serial_conv
{
    /// <summary>
    /// datawindow.xaml の相互作用ロジック
    /// </summary>
    public partial class datawindow : Window
    {
        public datawindow()
        {
            InitializeComponent();
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0);
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Byte[] data;
            if (MainWindow.udpstatus == true)
            {
                data = MainWindow.data;
                databox.Text = BitConverter.ToString(data);
            }
            else
            {
                databox.Text = "The UDP connect has not been started yet.";
            }
        }
    }
}
