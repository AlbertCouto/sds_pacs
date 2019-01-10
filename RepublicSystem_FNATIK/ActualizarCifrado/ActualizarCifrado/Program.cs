using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ActualizarCifrado
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            CifrarLetras.Cifrado cifrado = new CifrarLetras.Cifrado();
            AccesoBBDD.AccesoBBDD acceso_bd = new AccesoBBDD.AccesoBBDD();
            string query = "insert into InnerEncryption (Day, Active) values ('" + DateTime.Today.ToString("yyyy-MM-dd") + "', 1)";
            acceso_bd.Insert(query);

            foreach (KeyValuePair<char, string> item in cifrado.GenerarCifrado())
            {
                query = "insert into InnerEncryptionData (IdInnerEncryption ,Word, Numbers, OrderData) values ((select max(idInnerEncryption) from InnerEncryption),'" + item.Key + "','" + item.Value + "', 1)";
                acceso_bd.Insert(query);
            }

            MessageBox.Show("Todo OK");
        }
    }
}
