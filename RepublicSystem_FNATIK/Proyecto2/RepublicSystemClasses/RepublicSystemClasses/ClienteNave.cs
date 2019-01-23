using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Data;

namespace RepublicSystemClasses
{
    public class ClienteNave
    {
        public string SendingFilePath = string.Empty;
        private const int BufferSize = 1024;
        public AccesoBD bd = new AccesoBD();
        public Int32 puerto;
        public void Start_Client()
        {
            string SendingFilePath = "C:\\Users\\admin\\Desktop\\as.rar";
            string IP = "172.17.20.90";
            SendTCP(SendingFilePath, IP, puerto);
        }
        public static void SendTCP(string M, string IPA, Int32 PortN)
        {
            byte[] SendingBuffer = null;
            TcpClient client = null;
            /*string fecha, fecha_bien, año;
            string[] cosas;
            string nave, entrega;*/

            DataSet ds = new DataSet();

            NetworkStream netstream = null;
            //try
            //{
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
                /*ds = bd.PortarPerConsulta("select Day from InnerEncryption where idInnerEncryption = (select max(idInnerEncryption) from InnerEncryption);");
                fecha = (ds.Tables[0].Rows[1]).ToString();
                cosas = fecha.Split('/');
                año = cosas[2];
                ds = bd.PortarPerConsulta("select SpaceShip, CodeDelivery from DeliveryData");
                fecha_bien = cosas[1] + cosas[0] + año[0];*/
                byte[] nouBuffer = Encoding.ASCII.GetBytes("ESTO ES UN TEXTO DE PRUEBA");
                netstream.Write(nouBuffer, 0, nouBuffer.Length);

            }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            //finally
            //{
            //    if (netstream != null)
            //        netstream.Close();
            //    if (client != null)
            //        client.Close();
            //}
        }
    }
}
