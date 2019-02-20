using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Threading;

namespace RepublicSystemClasses
{
    public class ClasePlanetaOuter
    {
        UdpClient udpServer = new UdpClient(9423);
        UdpClient udpCli = new UdpClient();
        Thread T;

        public void Start()
        {
            T = new Thread(StartServer);
            T.Start();
        }

        public bool StartServer()
        {
            while (true)
            {
                IPEndPoint IeP = new IPEndPoint(IPAddress.Any, 0);
                Byte[] BytesIn = udpServer.Receive(ref IeP);
                string returnData = Encoding.ASCII.GetString(BytesIn);
                if (returnData.Length > 0)
                {
                    return true;
                }
                MessageBox.Show(returnData);
            }
        }

        public void StartClient()
        {
            IPAddress ipbien = IPAddress.Parse("127.0.0.1");            
            udpCli.Connect(ipbien,9423);
            Byte[] sendData = Encoding.ASCII.GetBytes("Hola S2AM!!!");
            udpCli.Send(sendData, sendData.Length);
        }
    }
}
