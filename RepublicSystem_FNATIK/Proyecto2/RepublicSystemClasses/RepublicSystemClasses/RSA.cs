using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepublicSystemClasses
{
    class RSA
    {
        //TIPOS DE KEYS//
        private static RSAParameters publicKey;
        private static RSAParameters privateKey;
        static string CONTAINER_NAME = "MyContainerName";

        //POSIBLES TAMAÑOS DE LAS LLAVES (uso de contenedores)//
        public enum KeySizes
        {
            SIZE_512 = 512,
            SIZE_1024 = 1024,
            SIZE_2048 = 2048,
            SIZE_952 = 952,
            SIZE_1369 = 1369
        };

        static void Main(string[] args)
        {
            string message = "FNATIK";
            generateKeys();
            byte[] encrypted = Encrypt(Encoding.UTF8.GetBytes(message));
            byte[] decrypted = Decrypt(encrypted);
           
            Console.WriteLine("Original\n\t " + message + "\n");
            Console.WriteLine("Encriptado\n\t" + BitConverter.ToString(encrypted).Replace("-", "") + "\n");
            Console.WriteLine("Desencriptado\n\t" + Encoding.UTF8.GetString(decrypted));

            Console.ReadLine();

        }

        //GENERAMOS LAS LLAVES// 
        static void generateKeys()
        {
            using(var rsa = new RSACryptoServiceProvider(2048)) //CREANDO EL OBJETO RSA, LE INDICAMOS EL TAMAÑO DE LAS LLAVES
            {
                rsa.PersistKeyInCsp = false; //NO GUARDA LA KEY EN UN CONTENEDOR
                publicKey = rsa.ExportParameters(false); //LLAVE PUBLICA
                privateKey = rsa.ExportParameters(true); //LLAVE PRIVADA
                //AMBAS DEVUELVEN UN RSA PARAMETER (Tipo del objeto)

            }
        }

        //ENCRIPTAR EN HEX//
        private static byte[] Encrypt(byte[] input)
        {
            byte[] encrypted;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false; //LE DECIMOS QUE NO GUARDAMOS EN CONTENEDOR
                rsa.ImportParameters(publicKey); //IMPORTAMOS LA LLAVE PUBLICA
                encrypted = rsa.Encrypt(input, true);
                //LE PASAMOS EL SRTING Y USAMOS EL SISTEMA DE PADDING(hace el algoritmo mas seguro)
            }
            return encrypted;
        }

        //DESENCRIPTAR//
        private static byte[] Decrypt(byte[] input)
        {
            byte[] decrypted;

            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.PersistKeyInCsp = false;
                rsa.ImportParameters(privateKey);//IMPORTAMOS LA LLAVE PRIVADA
                decrypted = rsa.Decrypt(input, true);
                //LE PASAMOS EL TEXTO ENCRIPTADO Y USAMOS EL SISTEMA DE PADDING
            }
            return decrypted;
        }

    }
}
