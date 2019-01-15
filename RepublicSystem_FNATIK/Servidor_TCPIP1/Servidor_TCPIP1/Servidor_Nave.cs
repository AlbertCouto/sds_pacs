using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Servidor_TCPIP1
{
    class Servidor_Nave
    {
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        
        static void Main(string[] args)
        {            
            ThreadStart Ts = new ThreadStart(StartReceiving);
            Thread T = new Thread(Ts);
            T.SetApartmentState(ApartmentState.STA);
            T.Start();
        }
        public static void StartReceiving()
        {
            ReceiveTCP(29251);
        }
        public static void ReceiveTCP(int portN)
        {
            string Status = string.Empty;
            TcpListener Listener = null;
            try
            {
                Listener = new TcpListener(IPAddress.Any, portN);
                Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] RecData = new byte[BufferSize];
            int RecBytes;

            for (; ; )
            {
                string ruta = "C:\\Users\\admin\\Desktop\\hola.txt";
                TcpClient client = null;
                NetworkStream netstream = null;
                string texto = null;
                Status = string.Empty;
                try
                {
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();                   
                        
                        if (portN == 29250)
                        {
                            int totalrecbytes = 0;
                            FileStream Fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                            while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                            {
                                Fs.Write(RecData, 0, RecBytes);
                                totalrecbytes += RecBytes;
                            }
                            Fs.Close();
                        }
                        else
                        {
                            int bytesRead = netstream.Read(RecData, 0, RecData.Length);
                            texto = Encoding.UTF8.GetString(RecData, 0, bytesRead);                           
                            Console.WriteLine(texto);
                        }
                        netstream.Close();
                        client.Close();
                      
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                  
                }
            }

            
        }
       
    }
}
