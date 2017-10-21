using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace udp_serial_conv
{
    class serial
    {
        static public void serialcom(string portnum,Byte[] data)
        {
            Parity parity = Parity.None;
            StopBits stopBits = StopBits.One;
            SerialPort serial = new SerialPort(portnum, 115200, parity, 8, stopBits);
            serial.Open();
            serial.Write(data, 0, data.Length);
            serial.Close();
        }
    }
}
