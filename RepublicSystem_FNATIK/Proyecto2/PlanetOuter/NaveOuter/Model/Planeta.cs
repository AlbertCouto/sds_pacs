using System;
using System.Net;
using System.Net.Sockets;

namespace PlanetaOuter.Model
{
    public class Planeta
    {
        public static string IP
        {
            get
            {
                return ObtenerIP();
            }
        }

        private static string ObtenerIP()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                    return ip.ToString();
            }
            throw new Exception("Dirección IP del Planeta no encontrada");
        }
    }
}
