using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Data;
using System.Net;

namespace RepublicSystemClasses
{
    public class ClienteNave
    {
        public string SendingFilePath = string.Empty;
        private const int BufferSize = 1024;
        public static AccesoBD bd = new AccesoBD();
        private static TcpListener Listener;
        public Int32 puerto;
        public void Start_Client()
        {
            string SendingFilePath = "C:\\Users\\admin\\Desktop\\as.rar";


            string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);

            SendTCP(SendingFilePath, IP, puerto);
        }
        public static void SendTCP(string M, string IPA, Int32 PortN)
        {
            byte[] SendingBuffer = null;
            TcpClient client = null;

            Listener = new TcpListener(IPAddress.Any, PortN);
            Listener.Start();

            DataSet ds = new DataSet();

            NetworkStream netstream = null;
            
            client = new TcpClient(IPA, PortN);
            netstream = client.GetStream();
            if (PortN == 5678)
            {
                FileStream Fs = new FileStream(M, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                int TotalLength = (int)Fs.Length, CurrentPacketLength;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                        CurrentPacketLength = TotalLength;
                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);

                }
                Fs.Close();
            }
            else
            {
                GenerarMensajes gm = new GenerarMensajes();
                string mensaje = gm.GenerarMensajeInicio();
                byte[] nouBuffer = Encoding.ASCII.GetBytes(mensaje);
                netstream.Write(nouBuffer, 0, nouBuffer.Length);

            }          

        }
    }
}
