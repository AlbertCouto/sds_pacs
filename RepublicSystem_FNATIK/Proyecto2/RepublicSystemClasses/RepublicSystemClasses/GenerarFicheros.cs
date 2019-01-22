using System;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace RepublicSystemClasses
{
    public class GenerarFicheros
    {
        AccesoBD db = new AccesoBD();
        private char[] abecedario = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private Dictionary<char, string> cifrado = new Dictionary<char, string>();
        private Thread th1;
        private Thread th2;

        public void GenerarLosFicheros()
        {
            // Obtenemos el diccionario para acceder a la BD una sola vez
            if (ObtenerDiccionario())
            {
                //THREADS
                th1 = new Thread(GenerarFicherosNumeros);
                th2 = new Thread(GenerarFicherosLetras);

                //Iniciamos Threads
                th1.Start();
                th2.Start();
            }
        }

        // Diccionario letra-numeros
        private bool ObtenerDiccionario()
        {
            string query = "select Numbers from InnerEncryptionData where IdInnerEncryption = 13";
            try
            {
                DataSet ds = new DataSet();
                ds = db.PortarPerConsulta(query);
                for (int i = 0; i < abecedario.Length; i++)
                    cifrado.Add(abecedario[i], ds.Tables[0].Rows[i]["Numbers"].ToString());
                return true;
            }
            catch
            {
                MessageBox.Show("Error al Obtener los numeros de la BD.");
                return false;
            }
        }

        // Generamos los ficheros con 1M de ltras Random a la vez
        private void GenerarFicherosLetras()
        {
            Parallel.Invoke(() => { InvokeFicherosLetras("1"); },
                            () => { InvokeFicherosLetras("2"); },
                            () => { InvokeFicherosLetras("3"); },
                            () => { InvokeFicherosLetras("4"); }
            );
        }
        private void InvokeFicherosLetras(string valor)
        {
            string ruta = "C:\\Users\\admin\\Desktop\\RepublicSystem_FNATIK\\Threads\\Threads\\resources\\FicherosLetras\\pacs" + valor + ".txt";

            if (File.Exists(ruta)) File.Delete(ruta);
            try
            {
                Random rnd = new Random();
                using (StreamWriter sw = File.CreateText(ruta))
                {
                    for (int j = 0; j < 1000000; j++)
                    {
                        sw.Write(abecedario[rnd.Next(abecedario.Length)]);
                        sw.Flush();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ruta de ficheros no válida");
            }
        }

        // Generamos los ficheros de 4M de numeros a la vez
        private void GenerarFicherosNumeros()
        {
            th2.Join(); // Espera a que acabe de generar los ficheros de letras para iniciar el de numeros 
            Parallel.Invoke(() => { InvokeFicherosNumeros("1"); },
                            () => { InvokeFicherosNumeros("2"); },
                            () => { InvokeFicherosNumeros("3"); },
                            () => { InvokeFicherosNumeros("4"); }
            );
            MessageBox.Show("Ficheros Generados");
            cifrado.Clear();
        }
        private void InvokeFicherosNumeros(string valor)
        {
            string ruta_numeros = "C:\\Users\\admin\\Desktop\\RepublicSystem_FNATIK\\Threads\\Threads\\resources\\FicherosNumeros\\pacs" + valor + ".txt";
            string ruta_letras = "C:\\Users\\admin\\Desktop\\RepublicSystem_FNATIK\\Threads\\Threads\\resources\\FicherosLetras\\pacs" + valor + ".txt";

            if (File.Exists(ruta_numeros)) File.Delete(ruta_numeros);
            try
            {
                using (StreamWriter sw = File.CreateText(ruta_numeros))
                {
                    using (StreamReader sr = File.OpenText(ruta_letras))
                    {
                        do sw.Write(cifrado[(char)sr.Read()]);
                        while (!sr.EndOfStream);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ruta de ficheros no válida");
            }
        }
    }
}
