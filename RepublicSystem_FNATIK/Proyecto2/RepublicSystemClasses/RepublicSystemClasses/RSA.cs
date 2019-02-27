using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RepublicSystemClasses
{
    public class RSA
    {
        private string connectionString = "Server=den1.mssql8.gear.host;Database=republicsystem;User Id=republicsystem;Password=fnatik_1";
        GenerarMensajes gr = new GenerarMensajes();
        CspParameters cspp = new CspParameters();
        public RSAParameters RSAPrivate;
        public RSAParameters RSAPublic;
        AccesoBD bd = new AccesoBD();
        public string PlanetName { get; set; }

        public void GenerarKeys()
        {           
            string keyName = "NABO";
            cspp.KeyContainerName = keyName;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            UnicodeEncoding ByteConverter = new UnicodeEncoding();

            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            {
                RSAPrivate = RSA.ExportParameters(true);
                RSAPublic = RSA.ExportParameters(false);
                string publicKey = rsa.ToXmlString(false);
                guardarXMLBBDD(publicKey);
            }
        }
       
        public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKey)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(cspp))
            {
                RSA.ImportParameters(RSAKey);
                MessageBox.Show(RSA.ToXmlString(false));
                encryptedData = RSA.Encrypt(DataToEncrypt, false);
            }
            return encryptedData;
        }
        public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKey)
        {
            byte[] decryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(cspp))
            {
                RSA.ImportParameters(RSAKey);
                decryptedData = RSA.Decrypt(DataToDecrypt, true);
            }
            return decryptedData;
        }
        public void guardarXMLBBDD(string clauPublica)
        {
            string query, query_update;
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet v_id = new DataSet();

            using (SqlConnection connexio = new SqlConnection(connectionString))
            {
                //query = "INSERT INTO PlanetKeys ([XMLKey]) VALUES (@XMLKey)";
                query = "update PlanetKeys set XMLKey =(@XMLKey) where idKey = 11";

                connexio.Open();

                using (SqlCommand command = new SqlCommand(query, connexio))
                {
                    try
                    {
                        command.Parameters.AddWithValue("@XMLKey", clauPublica);
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
                connexio.Close();
            }
        }
    }
}
