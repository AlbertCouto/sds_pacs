using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RepublicSystemClasses
{
    public class GenerarMensajes
    {
        AccesoBD db = new AccesoBD();
        DataSet ds = new DataSet();
        private string GenerarMensajeInicio()
        {
            string fecha, fecha_bien;
            string[] cosas;
            string[] cosas2;
            string SSID;
            string DeliveryID;


            ds = db.PortarPerConsulta("select Day from InnerEncryption where idInnerEncryption = (select max(idInnerEncryption) from InnerEncryption);");
            fecha = (ds.Tables[0].Rows[0][0]).ToString();
            cosas = fecha.Split(' ');
            cosas2 = cosas[0].Split('/');

            ds = db.PortarPerConsulta("select SpaceShip, CodeDelivery from DeliveryData");
            SSID = (ds.Tables[0].Rows[0][0]).ToString();
            DeliveryID = (ds.Tables[0].Rows[0][1]).ToString();

            fecha_bien = cosas2[1] + cosas2[0] + cosas2[2] + SSID + DeliveryID;

            return fecha_bien; 
        }
    }
}
