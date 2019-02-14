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
        private const int BufferSize = 2048;
        public static AccesoBD bd = new AccesoBD();
        Thread th;
        //private static TcpListener Listener;
        public Int32 puerto;
        public Form form { get; set; }
        public void Start_Client()
        {          
            string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            ThreadListener();
            SendTCPMessage(IP, puerto);
        }
        public bool Start_Client_File()
        {
            try
            {
                string IP = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
                puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetFile from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);

                SendTCPFile(IP, puerto);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SendTCPMessage(string IPA, Int32 PortN)
        {
            TcpClient client = null;
            DataSet ds = new DataSet();
            NetworkStream netstream = null;
            byte[] RecData = new byte[BufferSize];  
            

            client = new TcpClient(IPA, PortN);
            netstream = client.GetStream();
            
         
            if (PortN == 9250)
            {
                GenerarMensajes gm = new GenerarMensajes();
                string mensaje = gm.GenerarMensajeInicio();
                byte[] nouBuffer = Encoding.ASCII.GetBytes(mensaje);
                netstream.Write(nouBuffer, 0, nouBuffer.Length);
                netstream.Close();
                client.Close();
            }         
        }

        public void SendTCPFile(string IPA, Int32 PortN)
        {
            TcpClient client = null;
            DataSet ds = new DataSet();
            NetworkStream netstream = null;
            byte[] RecData = new byte[BufferSize];
            byte[] SendingBuffer = null;
            string ruta_inicial = "C:\\Users\\admin\\Desktop\\PACS\\PACSSOL.txt";


            client = new TcpClient(IPA, PortN);
            netstream = client.GetStream();

            if (PortN == 5678)
            {
                FileStream Fs = new FileStream(ruta_inicial, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                int TotalLength = (int)Fs.Length, CurrentPacketLength;
                int total = 0;
                try
                {
                    while (!netstream.DataAvailable)
                    {
                        total = total + 1;
                        
                        CurrentPacketLength = BufferSize;
                        SendingBuffer = new byte[CurrentPacketLength];
                        Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                        netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                        netstream.Flush();
                        Fs.Flush();
                        Thread.Sleep(2);
                        if (total == NoOfPackets)
                        {
                            Thread.Sleep(4);
                            MessageBox.Show(total.ToString());
                            break;
                        }
                    }
                    //for (int i = 0; i < NoOfPackets; i++)
                    //{

                    //    if (i % 100 == 0)
                    //    {
                    //        Thread.Sleep(4);
                    //        MessageBox.Show(i.ToString());
                    //    }

                    //    if (i == 320)
                    //    {
                    //        Fs.Close();
                    //        Fs.Dispose();
                    //        Fs = new FileStream(ruta_inicial, FileMode.Open, FileAccess.Read);
                    //    }


                    //    if (TotalLength > BufferSize)
                    //    {
                    //        CurrentPacketLength = BufferSize;
                    //        TotalLength = TotalLength - CurrentPacketLength;
                    //        total = total + CurrentPacketLength;
                    //    }
                    //    else
                    //        CurrentPacketLength = TotalLength;

                    //    SendingBuffer = new byte[CurrentPacketLength];
                    //    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    //    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                    //    netstream.Flush();
                    //    Fs.Flush();
                    //    Thread.Sleep(2);
                    //}
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                
                Fs.Close();
                netstream.Close();
                client.Close();
            }
        }
       
        public void CrearListener()
        {
            if (File.Exists("C:\\Users\\admin\\Desktop\\PACS.ZIP")) File.Delete("C:\\Users\\admin\\Desktop\\PACS.ZIP");
            string IPA = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            Int32 PortN = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            TcpClient client2 = null;
            DataSet ds = new DataSet();
            NetworkStream netstream = null;
            byte[] RecData = new byte[BufferSize];
            int RecBytes;
            try
            {
                TcpListener Listener2 = new TcpListener(IPAddress.Any, PortN);
                client2 = new TcpClient(IPA, PortN);
                netstream = client2.GetStream();
                for (; ; )
                {
                    Listener2.Start();
                    if (Listener2.Pending())
                    {
                        int totalrecbytes = 0;
                        client2 = Listener2.AcceptTcpClient();
                        netstream = client2.GetStream();
                        string ruta = "C:\\Users\\admin\\Desktop\\PACS.ZIP";
                        FileStream Fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                        while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                        {
                            Fs.Write(RecData, 0, RecBytes);
                            totalrecbytes += RecBytes;
                        }
                        Fs.Flush();
                        Fs.Close();
                        netstream.Close();
                        client2.Close();
                        Listener2.Stop();
                        string msgOK = "Archivo Recibido \n";
                        string msg = "Archivo No Recibido";

                        foreach (Control ctrl in form.Controls)
                        {
                            if (ctrl.GetType() == typeof(RichTextBox))
                            {
                                ((RichTextBox)ctrl).Invoke((MethodInvoker)delegate
                                {
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
                                ((Timer)ctrl).Invoke((MethodInvoker)delegate
                                {
                                    ((Timer)ctrl).StartTimer();
                                });
                            }
                        }

                    }
                }
            }
            catch
            {

            }
        }

        public void ThreadListener()
        {
            th = new Thread(CrearListener);
            th.Start();            
        }
    }
}
