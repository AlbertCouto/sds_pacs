using System;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace RepublicSystemClasses
{
    public class Desencriptar
    {
        private static AccesoBD db = new AccesoBD();
        private static char[] abecedario = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        private static Dictionary<char, string> dict_letras_numeros = new Dictionary<char, string>();
        public bool DesencriptarFichero(string fichero_numeros, string fichero_letras)
        {
            try
            {
                string numero = "";
                if (!ObtenerDiccionario()) return false;
                if (File.Exists(fichero_letras)) File.Delete(fichero_letras);

                using (StreamWriter sw = File.CreateText(fichero_letras))
                {
                    using (StreamReader sr = File.OpenText(fichero_numeros))
                    {
                        while (!sr.EndOfStream)
                        {
                            numero += (char)sr.Read();
                            if (numero.Length == 4)
                            {
                                sw.Write(ObtenerLetra(numero));
                                numero = "";
                            }
                        }
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        private char ObtenerLetra(string numero)
        {
            char letra = ' ';
            foreach (KeyValuePair<char, string> item in dict_letras_numeros)
                if (item.Value == numero) letra = item.Key;
            return letra;
        }
        private bool ObtenerDiccionario()
        {
            string query = "select Numbers from InnerEncryptionData where IdInnerEncryption = 13";
            try
            {
                DataSet ds = new DataSet();
                ds = db.PortarPerConsulta(query);
                for (int i = 0; i < abecedario.Length; i++)
                    dict_letras_numeros.Add(abecedario[i], ds.Tables[0].Rows[i]["Numbers"].ToString());
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
