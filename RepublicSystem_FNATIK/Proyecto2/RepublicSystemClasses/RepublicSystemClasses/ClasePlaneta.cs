using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RepublicSystemClasses
{
    public class ClasePlaneta
    {
        Thread T;
        static AccesoBD bd = new AccesoBD();
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        public  TcpListener Listener2;
        public  ComprobarNave cn;
        public Form form { get; set; }
        public void StartServer()
        {
            T = new Thread(StartReceiving);
            T.SetApartmentState(ApartmentState.STA);
            T.Start();         
           
        }
        public void OffServer()
        {

            try
            {
                if (Listener2 != null)
                {
                    Listener2.Stop();
                    //T.Abort();
                                        
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        public  void StartReceiving()
        {
            int puerto_archivo = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetFile from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            int puerto_mensaje = Convert.ToInt32((bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 1")).Tables[0].Rows[0][0]);
            string IP = ((bd.PortarPerConsulta("select IPSpaceShip from SpaceShips where idSpaceShip = 1")).Tables[0].Rows[0][0]).ToString();
            ReceiveTCP(puerto_archivo, puerto_mensaje, IP);

        }
        public  void ReceiveTCP(int portN, int portN2, string IP)
        {
            string Status = string.Empty;
            string rutaZip = @"C:\Users\admin\Desktop\pacs1.zip";
            byte[] SendingBuffer = null;
            try
            {
                cn = new ComprobarNave();
                Listener2 = new TcpListener(IPAddress.Any, portN2);
                Listener2.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            byte[] RecData = new byte[BufferSize];
            byte[] RecData2 = new byte[BufferSize];

            for (; ; )
            {

                TcpClient client2 = null;
                NetworkStream netstream2 = null;
                TcpClient client3 = null;
                NetworkStream netstream3 = null;
                string texto = null;
                Status = string.Empty;
                try
                {

                    if (Listener2.Pending())
                    {
                        client2 = Listener2.AcceptTcpClient();
                        netstream2 = client2.GetStream();
                        int bytesRead2 = netstream2.Read(RecData2, 0, RecData2.Length);
                        texto = Encoding.UTF8.GetString(RecData2, 0, bytesRead2);

                        if (texto.Length == 28)
                        {
                            if (cn.Comprobacion(texto))
                            {
                                MessageBox.Show("MENSAJE CORRECTO");
                                client3 = new TcpClient(IP, portN2);
                                netstream3 = client3.GetStream();

                                FileStream Fs = new FileStream(rutaZip, FileMode.Open, FileAccess.Read);
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
                                    {
                                        CurrentPacketLength = TotalLength;
                                    }

                                    SendingBuffer = new byte[CurrentPacketLength];
                                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                                    netstream3.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                                    //if (i = 1779)
                                    //{
                                    //    MessageBox.Show("NO = " + NoOfPackets.ToString());
                                    //    MessageBox.Show("I = " + i.ToString());
                                    //}

                                }
                                MessageBox.Show("ARCHIVO ENVIADO");
                                foreach (Control ctrl in form.Controls)
                                {
                                    if (ctrl.GetType() == typeof(Timer))
                                    {
                                        ((Timer)ctrl).Invoke((MethodInvoker)delegate {
                                            ((Timer)ctrl).Show();
                                            ((Timer)ctrl).StartTimer();
                                        });
                                    }
                                }
                                Fs.Close();
                                netstream3.Close();
                            }
                        }
                        //MessageBox.Show(texto);
                        netstream2.Close();
                        client2.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

