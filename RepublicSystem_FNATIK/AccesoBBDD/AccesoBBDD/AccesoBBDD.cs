using System;
using System.Data.SqlClient;
using System.Data;

namespace AccesoBBDD
{
    public class AccesoBBDD
    {
        private string connectionString = "Server=den1.mssql8.gear.host;Database=republicsystem;User Id=republicsystem;Password=fnatik_1";
        private SqlConnection conexion = new SqlConnection();
        DataSet taula;
        SqlDataAdapter da;
        private void Abrir()
        {
            try
            {
                conexion.ConnectionString = connectionString;
                conexion.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la BD");
            }
        }
        private void Cerrar()
        {
            conexion.Close();
        }
        public DataSet PortarTaula(string nom_taula)
        {
            taula = new DataSet();
            Abrir();
            string query = "select * from " + nom_taula;
            da = new SqlDataAdapter(query, conexion);
            da.Fill(taula);
            Cerrar();
            return taula;
        }

        public DataSet PortarPerConsulta(string consulta)
        {
            taula = new DataSet();
            Abrir();
            da = new SqlDataAdapter(consulta, conexion);
            da.Fill(taula);
            Cerrar();

            return taula;
        }

        public DataSet PortarPerConsulta(string consulta, string nom_taula)
        {
            taula = new DataSet();

            Abrir();
            taula.Tables[0].TableName = nom_taula;
            da = new SqlDataAdapter(consulta, conexion);
            da.Fill(taula);
            Cerrar();

            return taula;
        }

        public DataTable PortarPerConsultaTable(string consulta)
        {
            DataTable taula = new DataTable();
            Abrir();
            da = new SqlDataAdapter(consulta, conexion);
            da.Fill(taula);
            Cerrar();

            return taula;
        }

        public void Executa(string query)
        {
            
            SqlCommand sqlCommand = new SqlCommand(query, conexion);
            
            sqlCommand.ExecuteNonQuery();
            
        }

        public void Insert(string consulta)
        {
            Abrir();
            SqlCommand sqlCommand = new SqlCommand(consulta, conexion);
            //sqlCommand.Connection.Open();
            sqlCommand.ExecuteNonQuery();
            Cerrar();
        }
        public DataSet Actualitzar(DataSet t_entrada, string consulta)
        {
            try
            {
                Abrir();
                da = new SqlDataAdapter(consulta, conexion);
                SqlCommandBuilder builder = new SqlCommandBuilder(da);

                var x = da.Update(t_entrada.Tables[0]);
                Cerrar();

            }
            catch (SqlException)
            {
                System.Windows.Forms.MessageBox.Show("Este registro tiene más registros de otras tablas asociado");
            }
            catch (DBConcurrencyException)
            {

            }

            return t_entrada;
        }

        public DataSet PortarPerId(string id, int valor, string nom_taula)
        {
            taula = new DataSet();

            Abrir();

            string query = "select * from " + nom_taula + " where " + id + " = " + valor;
            da = new SqlDataAdapter(query, conexion);
            da.Fill(taula);

            Cerrar();

            return taula;
        }
        public DataSet PortarPerId(int valor, string nom_taula)
        {
            DataTable taula2 = new DataTable();
            DataColumn[] id;
            taula = new DataSet();
            Abrir();

            string query = "select * from " + nom_taula;

            da = new SqlDataAdapter(query, conexion);
            da.Fill(taula2);

            id = taula2.PrimaryKey;

            query = "select * from " + nom_taula + " where " + id[0].ToString() + " = " + valor;
            da = new SqlDataAdapter(query, conexion);
            da.Fill(taula);

            Cerrar();

            return taula;
        }
    }
}
