﻿using System;
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
        public static ComprobarNave cn;
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
            string IP = ((bd.PortarPerConsulta("select IPSpaceShip from SpaceShips where idSpaceShip = 1")).Tables[0].Rows[0][0]).ToString();
            ReceiveTCP(puerto_archivo, puerto_mensaje, IP);

        }
        public static void ReceiveTCP(int portN, int portN2, string IP)
        {
            string Status = string.Empty;         
            string rutaZip = @"C:\Users\admin\Desktop\pacs1.zip";
            byte[] SendingBuffer = null;         
            try
            {
                cn = new ComprobarNave();
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
                TcpClient client3 = null;
                NetworkStream netstream3 = null;
                string texto = null;
                Status = string.Empty;
                try
                {
                    if (Listener.Pending())
                    {
                        client = Listener.AcceptTcpClient();
                        netstream = client.GetStream();
                        string ruta = "C:\\Users\\admin\\Desktop\\Pruebas.rar";
                        FileStream Fs = new FileStream(ruta, FileMode.OpenOrCreate, FileAccess.Write);
                        RecBytes = netstream.Read(RecData, 0, RecData.Length);
                        Fs.Write(RecData, 0, RecBytes);
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
