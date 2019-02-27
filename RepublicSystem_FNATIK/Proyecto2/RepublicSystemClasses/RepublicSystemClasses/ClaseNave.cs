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
        TcpClient client;
        NetworkStream netstream;
        private const int BufferSize = 2048;
        public static AccesoBD bd = new AccesoBD();
        Thread th;
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

        public void SendTCPMessage(string IPA, Int32 puerto_mensaje)
        {
            client = new TcpClient(IPA, puerto_mensaje);
            netstream = client.GetStream();
            try
            {
                if (puerto_mensaje == 9250)
                {
                    GenerarMensajes gm = new GenerarMensajes();
                    string mensaje = gm.GenerarMensajeInicio();
                    byte[] nouBuffer = Encoding.ASCII.GetBytes(mensaje);
                    netstream.Write(nouBuffer, 0, nouBuffer.Length);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                netstream.Close();
                netstream = null;
                client.Close();
                client = null;
            }

        }

        public void SendTCPFile(string IPA, Int32 puerto_fichero)
        {
            byte[] SendingBuffer = null;
            string ruta_inicial = "C:\\Users\\admin\\Desktop\\PACS\\PACSSOL.txt";

            client = new TcpClient(IPA, puerto_fichero);
            netstream = client.GetStream();

            if (puerto_fichero == 5678)
            {
                FileStream Fs2 = new FileStream(ruta_inicial, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs2.Length) / Convert.ToDouble(BufferSize)));
                int TotalLength = (int)Fs2.Length, CurrentPacketLength;
                int total = 0;
                try
                {
                    while (!netstream.DataAvailable)
                    {
                        total = total + 1;
                        
                        CurrentPacketLength = BufferSize;
                        SendingBuffer = new byte[CurrentPacketLength];
                        Fs2.Read(SendingBuffer, 0, CurrentPacketLength);
                        netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                        netstream.Flush();
                        Fs2.Flush();
                        Thread.Sleep(2);
                        
                        if (total == NoOfPackets)
                        {
                            Thread.Sleep(4);
                            MessageBox.Show(total.ToString());
                            break;
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    Fs2.Close();
                    netstream.Close();
                    netstream = null;
                    client.Close();
                    client = null;
                }
            }
        }
        private void MostrarMsgLog(string msg, Color color)
        {
            foreach (Control ctrl in form.Controls)
            {
                if (ctrl.GetType() == typeof(RichTextBox))
                {
                    ((RichTextBox)ctrl).Invoke((MethodInvoker)delegate
                    {
                        ((RichTextBox)ctrl).AppendText(msg + "\r\n");
                        ((RichTextBox)ctrl).Select(((RichTextBox)ctrl).Text.Length - msg.Length - 1, msg.Length);
                        ((RichTextBox)ctrl).SelectionColor = color;
                    });
                }
            }
        }
        public void CrearListeners()
        {
            if (File.Exists("C:\\Users\\admin\\Desktop\\PACS.ZIP")) File.Delete("C:\\Users\\admin\\Desktop\\PACS.ZIP");
            string IPA = ((bd.PortarPerConsulta("select IPPlanet from Planets where idPlanet = 3")).Tables[0].Rows[0][0]).ToString();
            Int32 puerto_mensaje = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            Int32 puerto_fichero = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetFile from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            DataSet ds = new DataSet();
            byte[] RecData = new byte[BufferSize];
            int RecBytes;
            byte[] RecData2 = new byte[BufferSize];
            string msgOK = "Archivo Recibido \n";
            string msg = "Archivo No Recibido";
            TcpListener Listener = new TcpListener(IPAddress.Any, puerto_mensaje);
            TcpListener Listener2 = new TcpListener(IPAddress.Any, puerto_fichero);

            try
            {
                for (; ; )
                {
                    Listener.Start();
                    Listener2.Start();

                    if (Listener2.Pending())
                    {
                        int totalrecbytes = 0;
                        client = Listener2.AcceptTcpClient();
                        netstream = client.GetStream();
                        string ruta = "C:\\Users\\admin\\Desktop\\PACS.ZIP";
                        FileStream Fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                        while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                        {
                            Fs.Write(RecData, 0, RecBytes);
                            totalrecbytes += RecBytes;
                        }
                        Fs.Flush();
                        Fs.Close();
                        Listener2.Stop();                       

                        if (File.Exists(ruta)) MostrarMsgLog(msgOK, Color.Green);                        
                        else MostrarMsgLog(msg, Color.Red);
                      
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
                        Listener2.Stop();
                    }
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        int bytesRead2 = netstream.Read(RecData2, 0, RecData2.Length);
                        string texto = Encoding.UTF8.GetString(RecData2, 0, bytesRead2);
                        if (texto.Substring(8,2) == "AG") MostrarMsgLog(texto, Color.Green);
                        else MostrarMsgLog(texto, Color.Red);
                        Listener.Stop();
                        foreach (Control ctrl in form.Controls)
                        {
                            if (ctrl.GetType() == typeof(Timer))
                            {
                                ((Timer)ctrl).Invoke((MethodInvoker)delegate
                                {
                                    ((Timer)ctrl).StopTimer();
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                netstream.Close();
                netstream = null;
                client.Close();
                client = null;
                Listener2.Stop();
            }
        }

        public void ThreadListener()
        {
            th = new Thread(CrearListeners);
            th.Start();            
        }
    }
}
