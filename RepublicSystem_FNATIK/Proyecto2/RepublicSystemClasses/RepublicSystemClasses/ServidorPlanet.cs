using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RepublicSystemClasses
{
    public class ServidorPlanet
    {
        static AccesoBD bd = new AccesoBD();
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        private static TcpListener Listener;
        private static TcpListener Listener2;
        private bool verificar { get; set; }
        public void StartServer()
        {

            ThreadStart Ts = new ThreadStart(StartReceiving);
            Thread T = new Thread(Ts);
            T.SetApartmentState(ApartmentState.STA);
            T.Start();

        }
        public void OffServer()
        {
            Listener.Stop();
            Listener2.Stop();
        }
        public static void StartReceiving()
        {
            int puerto_archivo = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetFile from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            int puerto_mensaje = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            ReceiveTCP(puerto_archivo, puerto_mensaje);

        }
        public static void ReceiveTCP(int portN, int portN2)
        {
            string Status = string.Empty;
            
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
                        verificar = true;
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
                        verificar = true;
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
