using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace RepublicSystemClasses
{
    public class ClasePlaneta
    {
        Thread T;
        static AccesoBD bd = new AccesoBD();
        private const int BufferSize = 1024;
        public string Status = string.Empty;
        public TcpListener Listener2;
        public TcpListener Listener;
        private ComprobarNave cn;
        private ZipUnzipCompare zipCompare;
        private Concatenar concat;
        
        public Form form { get; set; }
        private string msg;
        private Color color;
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
                if (Listener2 != null||Listener!=null)
                {
                    Listener2.Stop();
                    Listener.Stop();
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
        public  void ReceiveTCP(int puerto_archivo, int puerto_mensaje, string IP)
        {
            string Status = string.Empty;
            string rutaZip = @"C:\Users\admin\Desktop\PACS.zip";
            //string rutaZipSol = @"C:\Users\admin\Desktop\PACSSOL.zip";
            string rutaZipSol = @"C:\Users\admin\Desktop\PACSSOL.txt";
            byte[] SendingBuffer = null;
            try
            {
                cn = new ComprobarNave();
                Listener2 = new TcpListener(IPAddress.Any, puerto_mensaje);
                Listener2.Start();
                Listener = new TcpListener(IPAddress.Any, puerto_archivo);
                Listener.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            byte[] RecData = new byte[BufferSize];
            byte[] RecData2 = new byte[BufferSize];
            byte[] RecData3 = new byte[BufferSize];
            for (; ; )
            {
                TcpClient client = null;
                NetworkStream netstream = null;
                TcpClient client2 = null;
                NetworkStream netstream2 = null;
                TcpClient client3 = null;
                NetworkStream netstream3 = null;
                TcpClient client4 = null;
                NetworkStream netstream4 = null;                

                string texto = null;
                int RecBytes;

                Status = string.Empty;
                try
                {
                    Listener2.Start();
                    Listener.Start();
                    if (Listener2.Pending())
                    {
                        client2 = Listener2.AcceptTcpClient();
                        netstream2 = client2.GetStream();
                        if (netstream2 == null) return;
                        int bytesRead2 = netstream2.Read(RecData2, 0, RecData2.Length);
                        texto = Encoding.UTF8.GetString(RecData2, 0, bytesRead2);

                        if (texto.Length == 28)
                        {
                            if (cn.Comprobacion(texto))
                            {
                                msg = "Solicitud de planeta recibida";
                                color = Color.Green;
                                MostrarMsgLog(msg, color);
                                client3 = new TcpClient(IP, puerto_archivo);
                                netstream3 = client3.GetStream();

                                FileStream Fs = new FileStream(rutaZip, FileMode.Open, FileAccess.Read);
                                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                                int TotalLength = (int)Fs.Length, CurrentPacketLength;
                                int total = 0;
                                while (!netstream3.DataAvailable)
                                {
                                    total = total + 1;
                                    CurrentPacketLength = BufferSize;
                                    SendingBuffer = new byte[CurrentPacketLength];
                                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                                    netstream3.Write(SendingBuffer, 0, (int)SendingBuffer.Length);
                                    netstream3.Flush();
                                    Fs.Flush();
                                    Thread.Sleep(2);
                                    
                                        if (total == NoOfPackets)
                                        {
                                            Thread.Sleep(4);
                                            MessageBox.Show(total.ToString());
                                            break;
                                        }
                                    
                                }
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

                                client3.Close();
                                Fs.Close();
                                netstream3.Close();
                                msg = "Archivo enviado";
                                color = Color.Green;
                                MostrarMsgLog(msg, color);

                            }                           
                        }
                        netstream2.Close();
                        client2.Close();
                        Listener2.Stop();
                    }
                    
                    if (Listener.Pending())
                    {
                        if (File.Exists(rutaZipSol))
                        {
                            File.Delete(rutaZipSol);
                        }
                        int totalrecbytes = 0;
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        if (netstream == null) return;
                        FileStream Fs2 = new FileStream(rutaZipSol, FileMode.OpenOrCreate, FileAccess.Write);
                        while((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                        {
                            Fs2.Write(RecData, 0, RecBytes);
                            totalrecbytes += RecBytes;
                        }
                        Fs2.Close();
                        netstream.Close();
                        client.Close();
                        Listener.Stop();
                        msg = "Archivo recibido";
                        color = Color.Green;
                        MostrarMsgLog(msg, color);

                        concat = new Concatenar();
                        zipCompare = new ZipUnzipCompare();
                        string ruta_concatenar = @"C:\Users\admin\Desktop\FicherosLetras";
                        string ruta_txt_concatenado = @"C:\Users\admin\Desktop\concatenado.txt";
                        string ruta_toUnzip = @"C:\Users\admin\Desktop\PACSSOL.zip";
                        string original_file_path = @"C: \Users\admin\Desktop\concatenado.txt";
                        //string returned_file_path = @"C:\Users\admin\Desktop\PACS\NaveTXT\PACSSOL.txt";
                        string returned_file_path = @"C:\Users\admin\Desktop\PACSSOL.txt";

                        bool verificacion;

                        concat.ConcatenaFicheros(ruta_concatenar, ruta_txt_concatenado);
                        //zipCompare.Descomprimir(ruta_toUnzip);
                        verificacion = zipCompare.Comparar(original_file_path, returned_file_path);                                            

                        client4 = new TcpClient(IP, puerto_mensaje);
                        netstream4 = client4.GetStream();

                        if (puerto_mensaje == 9250)
                        {
                            GenerarMensajes gm = new GenerarMensajes();
                            string mensaje = gm.generarMensageAprovacion(verificacion);
                            byte[] nouBuffer = Encoding.ASCII.GetBytes(mensaje);
                            netstream4.Write(nouBuffer, 0, nouBuffer.Length);
                            netstream4.Close();
                            client4.Close();
                        }
                      
                        foreach (Control ctrl in form.Controls)
                        {
                            if (ctrl.GetType() == typeof(Timer))
                            {
                                ((Timer)ctrl).Invoke((MethodInvoker)delegate {
                                    ((Timer)ctrl).Show();
                                    ((Timer)ctrl).StopTimer();
                                });
                            }
                        }
                        MessageBox.Show(verificacion.ToString());                        
                    }
                }
                catch (Exception ex)
                {
                   
                    //MessageBox.Show(ex.ToString());
                    //Console.WriteLine(ex.Message);
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
    }
    

}

