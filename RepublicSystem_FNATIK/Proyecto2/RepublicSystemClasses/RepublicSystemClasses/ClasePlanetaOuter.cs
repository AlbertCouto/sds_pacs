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
        UdpClient udpServer = new UdpClient(9423);
        UdpClient udpCli = new UdpClient();
        Thread T;
        GenerarMensajes gm = new GenerarMensajes();
        RSA rs = new RSA();
        AccesoBD bd = new AccesoBD();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

        public Form form { get; set; }

        public void Start()
        {
            T = new Thread(StartServer);
            T.Start();
        }

        public void StartServer()
        {           

            while (true)
            {
                IPEndPoint IeP = new IPEndPoint(IPAddress.Any, 0);
                Byte[] BytesIn = udpServer.Receive(ref IeP);
                string returnData = Encoding.ASCII.GetString(BytesIn);
                if (returnData.Length > 0)
                {
                    foreach (Control ctrl in form.Controls)
                    {
                        if (ctrl.GetType() == typeof(TextBox))
                        {
                            ((TextBox)ctrl).Invoke((MethodInvoker)delegate
                            {
                                ((TextBox)ctrl).AppendText(returnData.ToString());
                         
                            });
                        }
                    }
                }
            }
        }

        public void StartClient()
        {
            DataSet ds = new DataSet();
            string mensaje, clave_publica;
            byte[] mensaje_bytes = null;

            ds = bd.PortarPerConsulta("select XMLKey from PlanetKeys where idKey = (select MAX(idKey) from PlanetKeys)");
            clave_publica = ds.Tables[0].Rows[0][0].ToString();

            RSA.FromXmlString(clave_publica);

            mensaje = gm.GenerarMensajeInicio();
            mensaje_bytes = rs.RSAEncrypt(Encoding.ASCII.GetBytes(mensaje), RSA.ExportParameters(false));
            
            IPAddress ipbien = IPAddress.Parse("127.0.0.1");            
            udpCli.Connect(ipbien,9423);
            udpCli.Send(mensaje_bytes, mensaje_bytes.Length);          

        }
    }
}
