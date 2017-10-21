using System;
using System.Net;
using System.Windows;
using System.Windows.Threading;
using System.IO.Ports;

namespace udp_serial_conv
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        static public bool udpstatus = false;
        static public Byte[] data;
        int net_port_int;
        string serial_port_str;
        public MainWindow()
        {
            InitializeComponent();
            string myhostname = Dns.GetHostName();
            IPAddress[] address = Dns.GetHostAddresses(myhostname);
            string[] portname = SerialPort.GetPortNames();
            serial_port.ItemsSource = portname;

            foreach (IPAddress addrs in address)
            {
                if (addrs.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    ip_addr.Text = addrs.ToString();
                    break;
                }
            }
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //int count = 0;
            //serial_port.ItemsSource = portname;
            //count = 0;
            if (udpstatus == true)
            {
                data = udp.GetV(net_port_int);
                serial.serialcom(serial_port_str, data);
            }
        }

        private void start(object sender, RoutedEventArgs e)
        {
            data = BitConverter.GetBytes(false);
            net_ooi.Width = 230;
            serial_ooi.Width = 230;
            net_port_int = int.Parse(net_port.Text);
            serial_port_str = serial_port.SelectedItem.ToString();
            udpstatus = true;
        }

        private void stop(object sender, RoutedEventArgs e)
        {
            udpstatus = false;
            net_ooi.Width = 0;
            serial_ooi.Width = 0;
        }

        private void opendw(object sender, RoutedEventArgs e)
        {
            datawindow a = new datawindow();
            a.Show();
        }

        private void serialport_reload(object sender, RoutedEventArgs e)
        {
            string[] portname = SerialPort.GetPortNames();
            serial_port.ItemsSource = portname;
        }
    }
}
