using System;
using System.Collections;
using System.Collections.Generic;

namespace RepublicSystemClasses
{
    public class ActualizarCifradoBD
    {
        private char[] abecedario = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        ArrayList numeros_usados = new ArrayList();
        Dictionary<char, string> cifrado_final = new Dictionary<char, string>();
        AccesoBD db = new AccesoBD();

        public void ActualizarBD()
        {
            cifrado_final = GenerarCifrado();
            foreach (KeyValuePair<char, string> item in cifrado_final)
                db.Insert("insert into InnerEncryptionData (IdInnerEncryption ,Word, Numbers, OrderData) values ((select max(idInnerEncryption) from InnerEncryption),'" + item.Key + "','" + item.Value + "', 1)");
        }
        public Dictionary<char, string> GenerarCifrado()
        {
            foreach (char letra in abecedario)
                cifrado_final.Add(letra, GetNumero());

            numeros_usados.Clear();
            return cifrado_final;
        }
        private string GetNumero()
        {
            Random rnd = new Random();
            string numero = "";

            do numero = rnd.Next(9999).ToString("D4");
            while (numeros_usados.Contains(numero));

            numeros_usados.Add(numero);

            return numero;
        }
    }
}
