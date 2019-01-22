using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Servidor_Nave
{
    public class Class1
    {
        private const int BufferSize = 1024;
        public string Status = string.Empty;

        public void StartServer()
        {

            ThreadStart Ts = new ThreadStart(StartReceiving);
            Thread T = new Thread(Ts);
            T.SetApartmentState(ApartmentState.STA);
            T.Start();

        }
        public static void StartReceiving()
        {
            ReceiveTCP(5678, 9250);

        }
        public static void ReceiveTCP(int portN, int portN2)
        {
            string Status = string.Empty;
            TcpListener Listener = null;
            TcpListener Listener2 = null;
            try
            {
                Listener = new TcpListener(IPAddress.Any, portN);
                Listener.Start();
                Listener2 = new TcpListener(IPAddress.Any, portN2);
                Listener2.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] RecData = new byte[BufferSize];
            int RecBytes;
            byte[] RecData2 = new byte[BufferSize];


            for (; ; )
            {
                TcpClient client = null;
                NetworkStream netstream = null;
                TcpClient client2 = null;
                NetworkStream netstream2 = null;
                string texto = null;
                Status = string.Empty;
                try
                {
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        string ruta = "C:\\Users\\admin\\Desktop\\Pruebas.rar";
                        //int totalrecbytes = 0;
                        FileStream Fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                        RecBytes = netstream.Read(RecData, 0, RecData.Length);
                        Fs.Write(RecData, 0, RecBytes);
                        //while (RecBytes > 0)
                        //{
                        //    MessageBox.Show(RecBytes.ToString());
                        //totalrecbytes += RecBytes;
                        //RecBytes = netstream.Read(RecData, 0, RecData.Length);
                        //}
                        MessageBox.Show("Archivo recibido");
                        Fs.Close();
                        netstream.Close();
                        client.Close();

                    }
                    if (Listener2.Pending())
                    {
                        client2 = Listener2.AcceptTcpClient();
                        netstream2 = client2.GetStream();
                        int bytesRead2 = netstream2.Read(RecData2, 0, RecData2.Length);
                        texto = Encoding.UTF8.GetString(RecData2, 0, bytesRead2);
                        MessageBox.Show(texto);
                        netstream2.Close();
                        client2.Close();

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
