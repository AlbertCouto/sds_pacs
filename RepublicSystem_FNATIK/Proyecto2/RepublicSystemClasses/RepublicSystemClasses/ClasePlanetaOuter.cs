using System;
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
        ComprobarNave cn = new ComprobarNave();
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
                byte[] BytesIn = udpServer.Receive(ref IeP);
                string returnData = Encoding.ASCII.GetString(BytesIn), mensaje_comprobacion ;
                byte[] decryptData = null;
                int i = 0;

                if (returnData.Length > 0)
                {
                    if (cn.Comprobacion(Encoding.ASCII.GetString(decryptData)))
                    {
                        if (i > 0)
                        {
                            CspParameters csp = new CspParameters();
                            csp.KeyContainerName = "NABO";
                            RSACryptoServiceProvider rsc = new RSACryptoServiceProvider(csp);
                            decryptData = rs.RSADecrypt(Encoding.ASCII.GetBytes(returnData), rsc.ExportParameters(true));
                            mensaje_comprobacion = gm.generarMensageAprovacion(true);
                        }
                        else
                        {
                            mensaje_comprobacion = "Vale, ahora me lo puedes encriptar?";
                        }
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
                        IPAddress ipbien = IPAddress.Parse("172.17.20.96");
                        udpCli.Connect(ipbien, 9250);
                        udpCli.Send(Encoding.ASCII.GetBytes(mensaje_comprobacion), mensaje_comprobacion.Length);                       
                    }
                    i++;
                }
            }
        }
    }
}
