using System;
using System.Collections;
using System.Collections.Generic;

namespace CifrarLetras
{
    public class Cifrado
    {
        private char[] abecedario = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        ArrayList numeros_usados = new ArrayList();

        public Dictionary<char, string> GenerarCifrado ()
        {
            Dictionary<char, string> cifrado_final = new Dictionary<char, string>();

            foreach (char letra in abecedario)
                cifrado_final.Add(letra, GetNumero());

            numeros_usados.Clear();
            return cifrado_final;
        }

        private string GetNumero ()
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
