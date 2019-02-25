﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Security.Cryptography;

namespace RepublicSystemClasses
{
    public class ClasePlanetaOuter
    {
        AccesoBD bd = new AccesoBD();
        UdpClient udpServer;
        UdpClient udpCli = new UdpClient();
        Thread T;
        GenerarMensajes gm = new GenerarMensajes();
        RSA rs = new RSA();
        
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        ComprobarNave cn = new ComprobarNave();
        public Form form { get; set; }

        public void Start()
        {
            Int32 puerto = Convert.ToInt32(bd.PortarPerConsulta("select PortPlanetText from Planets where idPlanet = 3").Tables[0].Rows[0][0]);
            udpServer = new UdpClient(puerto);
            T = new Thread(StartServer);
            T.Start();
        }

        public void StartServer()
        {
            int i = 0;
            while (true)
            {
                IPEndPoint IeP = new IPEndPoint(IPAddress.Any, 0);
                byte[] BytesIn = udpServer.Receive(ref IeP);
                string returnData = Encoding.ASCII.GetString(BytesIn), mensaje_comprobacion ;
                byte[] decryptData = null;
                

                if (returnData.Length > 0)
                {
                    //if (cn.Comprobacion(Encoding.ASCII.GetString(decryptData)))
                    if (cn.Comprobacion(returnData) || i>1)
                    {
                        if (i > 1)
                        {
                            CspParameters csp = new CspParameters();
                            csp.KeyContainerName = "NABO";
                            RSACryptoServiceProvider rsc = new RSACryptoServiceProvider(csp);
                            decryptData = rs.RSADecrypt(Encoding.ASCII.GetBytes(returnData), rsc.ExportParameters(true));
                            mensaje_comprobacion = gm.generarMensageAprovacion(true);
                        }
                        else
                        {
                            mensaje_comprobacion = "Se solicita a la nave el mensaje encriptado.";
                        }
                        foreach (Control ctrl in form.Controls)
                        {
                            if (ctrl.GetType() == typeof(TextBox))
                            {
                                ((TextBox)ctrl).Invoke((MethodInvoker)delegate
                                {
                                    ((TextBox)ctrl).AppendText(mensaje_comprobacion);

                                });
                            }
                        }
                        string IP = ((bd.PortarPerConsulta("select IPSpaceShip from SpaceShips where idSpaceShip = 1")).Tables[0].Rows[0][0]).ToString();
                        IPAddress ipbien = IPAddress.Parse(IP);
                        Int32 puerto = Convert.ToInt32((bd.PortarPerConsulta("select PortSpaceShipText from SpaceShips where idSpaceShip = 1")).Tables[0].Rows[0][0]);
                        udpCli.Connect(ipbien, puerto);
                        udpCli.Send(Encoding.ASCII.GetBytes(mensaje_comprobacion), mensaje_comprobacion.Length);                       
                    }
                    i++;
                }
            }
        }
    }
}
