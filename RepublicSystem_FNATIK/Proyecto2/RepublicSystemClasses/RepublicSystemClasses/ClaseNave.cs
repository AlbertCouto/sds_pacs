using System;
using System.Text;
using System.IO;
using System.Net.Sockets;
using System.Data;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;


namespace RepublicSystemClasses
{
    public class ClaseNave
    {
        //Thread th;        
        private const int BufferSize = 1024;
        public static AccesoBD bd = new AccesoBD();
        //private static TcpListener Listener;
        public Int32 puerto;
        public Form form { get; set; }
        public void Start_Client()
        {          
            string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);

            SendTCP(IP, puerto);
        }
        public void Start_Client_File()
        {
            string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetFile from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);

            SendTCP(IP, puerto);
        }

        public void SendTCP(string IPA, Int32 PortN)
        {
            TcpClient client = null;
            DataSet ds = new DataSet();
            NetworkStream netstream = null;
            byte[] RecData = new byte[BufferSize];      
            byte[] SendingBuffer = null;
            string ruta_inicial = "C:\\User\\admin\\Desktop\\PACS\\PACSSOL.ZIP";
            client = new TcpClient(IPA, PortN);
            netstream = client.GetStream();
            ThreadListener();
            if (PortN == 5678)
            {
                FileStream Fs = new FileStream(ruta_inicial, FileMode.Open, FileAccess.Read);
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
            if (PortN == 9250)
            {
                GenerarMensajes gm = new GenerarMensajes();
                string mensaje = gm.GenerarMensajeInicio();
                byte[] nouBuffer = Encoding.ASCII.GetBytes(mensaje);
                netstream.Write(nouBuffer, 0, nouBuffer.Length);

            }         
        }
       
        public void CrearListener()
        {            
            string IPA = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            Int32 PortN = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            TcpClient client2 = null;
            DataSet ds = new DataSet();
            NetworkStream netstream = null;
            byte[] RecData = new byte[BufferSize];
            int RecBytes;            

            TcpListener Listener2 = new TcpListener(IPAddress.Any, PortN);
            Listener2.Start();
            client2 = new TcpClient(IPA, PortN);
            netstream = client2.GetStream();
            for (; ; )
            {
                if (Listener2.Pending())
                {
                    int totalrecbytes = 0;
                    client2 = Listener2.AcceptTcpClient();
                    netstream = client2.GetStream();
                    string ruta = "C:\\Users\\admin\\Desktop\\PACS.ZIP";
                    FileStream Fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                    while ((RecBytes = netstream.Read(RecData, 0, RecData.Length))>0)
                    {
                        Fs.Write(RecData, 0, RecBytes);
                        totalrecbytes += RecBytes;
                    }
                    string msgOK = "Archivo Recibido";
                    string msg = "Archivo No Recibido";
                    
                    foreach (Control ctrl in form.Controls)
                    {
                        if (ctrl.GetType() == typeof(RichTextBox))
                        {
                            ((RichTextBox)ctrl).Invoke((MethodInvoker)delegate {
                                if (File.Exists(ruta))
                                {
                                    ((RichTextBox)ctrl).AppendText(msgOK);
                                    ((RichTextBox)ctrl).Select(((RichTextBox)ctrl).Text.Length - msgOK.Length, msgOK.Length);
                                    ((RichTextBox)ctrl).SelectionColor = Color.Green;
                                }
                                else
                                {
                                    ((RichTextBox)ctrl).AppendText(msg);
                                    ((RichTextBox)ctrl).Select(((RichTextBox)ctrl).Text.Length - msg.Length, msg.Length);
                                    ((RichTextBox)ctrl).SelectionColor = Color.Red;
                                }
                            });
                        }
                    }
               
                    foreach (Control ctrl in form.Controls)
                    {
                        if (ctrl.GetType() == typeof(Timer))
                        {
                            ((Timer)ctrl).Invoke((MethodInvoker)delegate{
                                ((Timer)ctrl).StartTimer();
                            });
                        }
                    }
                    Fs.Close();
                    netstream.Close();
                    client2.Close();
                }
            }
        }

        public void ThreadListener()
        {
            Thread th = new Thread(CrearListener);
            th.Start();
            
        }
    }
}
