using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //rsa clear afegit perque necessita que esborri la clau anterior dins del mateix keycontainer
            rsa.Clear();
            rsa = new RSACryptoServiceProvider(cspp);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
           
            RSAPrivate = rsa.ExportParameters(true);
            RSAPublic = rsa.ExportParameters(false);
            string publicKey = rsa.ToXmlString(false);
            string publicKey2 = rsa.ToXmlString(true);
            //MessageBox.Show(publicKey2);
            //MessageBox.Show(publicKey);
            guardarXMLBBDD(publicKey);
            
        }
       
        public byte[] RSAEncrypt(byte[] DataToEncrypt, RSAParameters RSAKey)
        {
            byte[] encryptedData;
            using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(cspp))
            {
                RSA.ImportParameters(RSAKey);
                encryptedData = RSA.Encrypt(DataToEncrypt, false);
            }
            return encryptedData;
        }
        public byte[] RSADecrypt(byte[] DataToDecrypt, RSAParameters RSAKey)
        {
            byte[] decryptedData;
            RSACryptoServiceProvider rsc = new RSACryptoServiceProvider();
            //using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
            //{
                rsc.ImportParameters(RSAKey);
                decryptedData = rsc.Decrypt(DataToDecrypt, false);
            //}
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
                query = "update PlanetKeys set XMLKey =(@XMLKey) where idKey = 12";

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
