using System;
using System.IO;
using System.Data;
using System.Collections.Generic;

namespace RepublicSystemClasses
{
    class Desencriptar
    {
        private static AccesoBD db = new AccesoBD();
        private static char[] abecedario = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        private static Dictionary<char, string> dict_letras_numeros = new Dictionary<char, string>(ObtenerDictionary());
        public void DesencriptarFichero(string fichero_numeros, string fichero_letras)
        {
            string numero = "";
            if (File.Exists(fichero_letras)) File.Delete(fichero_letras);

            using (StreamWriter sw = File.CreateText(fichero_letras))
            {
                using (StreamReader sr = File.OpenText(fichero_numeros))
                {
                    while(!sr.EndOfStream)
                    {
                        numero += (char)sr.Read();
                        if (numero.Length==4)
                        {
                            sw.Write(ObtenerLetra(numero));
                            numero = "";
                        }
                    }
                }
            }
        }
        private char ObtenerLetra(string numero)
        {
            char letra = ' ';
            foreach (KeyValuePair<char, string> item in dict_letras_numeros)
                if (item.Value == numero) letra = item.Key;
            return letra;
        }
        private static Dictionary<char, string> ObtenerDictionary()
        {
            Dictionary<char, string> diccio = new Dictionary<char, string>(); ;
            foreach (char letra in abecedario)
                diccio.Add(letra, GetNumeroBD(letra));

            return diccio;
        }
        private static string GetNumeroBD(char letra)
        {
            string query = "SELECT Numbers from InnerEncryptionData where IdInnerEncryption = 13 AND Word = '" + letra + "'";
            DataSet ds = new DataSet();
            ds = db.PortarPerConsulta(query);

            return ds.Tables[0].Rows[0][0].ToString();
        }
    }
}
