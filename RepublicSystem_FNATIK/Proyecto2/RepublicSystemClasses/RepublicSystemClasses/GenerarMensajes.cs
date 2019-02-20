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
        public string GenerarMensajeInicio()
        {
            string fecha, fecha_bien;
            string[] fecha_split1;
            string[] fecha_split2;
            string SSID;
            string DeliveryID;


            ds = db.PortarPerConsulta("select Day from InnerEncryption where idInnerEncryption = (select max(idInnerEncryption) from InnerEncryption);");
            fecha = (ds.Tables[0].Rows[0][0]).ToString();
            fecha_split1 = fecha.Split(' ');
            fecha_split2 = fecha_split1[0].Split('/');

            ds = db.PortarPerConsulta("select SpaceShip, CodeDelivery from DeliveryData");
            SSID = (ds.Tables[0].Rows[0][0]).ToString();
            DeliveryID = (ds.Tables[0].Rows[0][1]).ToString();

            fecha_bien = fecha_split2[1] + fecha_split2[0] + fecha_split2[2] + SSID + DeliveryID;

            return fecha_bien; 
        }
        
        public string generarMensageAprovacion(bool ver)
        {
            string verificacion = null;
            string menFinal = null;
            ds = db.PortarPerConsulta("select SpaceShip from DeliveryData Where idDeliveryData = 1");

            if (ver) verificacion = "AG";            
            else verificacion = "AD";

            menFinal = (ds.Tables[0].Rows[0][0]).ToString() + verificacion;

            return menFinal;
        }


    }
}
