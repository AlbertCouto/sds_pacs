using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Threads
{
    public class Threads
    {
        //private string ruta = "C:\\Users\\admin\\Desktop\\RepublicSystem_FNATIK\\Threads\\Threads\\resources\\pacs";
        private char[] abecedario = new char[] {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
        public void GenerarFicheros()
        {
            MessageBox.Show("Generando Ficheros Base...");
            Parallel.Invoke(() => { Generar("1"); },
                            () => { Generar("2"); },
                            () => { Generar("3"); },
                            () => { Generar("4"); }
                            );
            MessageBox.Show("Ficheros Base Generados");
        }
        private void Generar(string valor)
        {
            string ruta = "C:\\Users\\admin\\Desktop\\RepublicSystem_FNATIK\\Threads\\Threads\\resources\\pacs" + valor + ".txt";
            if (!File.Exists(ruta))
            {
                Random rnd = new Random();
                using (StreamWriter sw = File.CreateText(ruta))
                {
                    for (int j = 0; j < 1000000; j++)
                    {
                        int numero = rnd.Next(abecedario.Length);
                        char letra = abecedario[numero];
                        sw.Write(letra);
                    }
                }
            }
        }
        public void Encriptar()
        {

        }
        public void Desencriptar()
        {

        }
    }
}
