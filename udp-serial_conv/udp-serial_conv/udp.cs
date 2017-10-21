using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace udp_serial_conv
{
    class udp
    {
        static public Byte[] GetV(int portnum)
        {
            IPAddress localAddress = IPAddress.Any;
            IPEndPoint localEP = new IPEndPoint(localAddress, portnum);
            UdpClient udp = new UdpClient(localEP);
            IPEndPoint remoteEP = null;
            Byte[] rcvbytes = udp.Receive(ref remoteEP);
            udp.Close();
            return rcvbytes;
        }
    }
}
