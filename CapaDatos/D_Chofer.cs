using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using C_Entidad;




namespace CapaDatos
{
    public class D_Chofer
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<Chofer> BuscarChofer(string buscar)
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("SP_Buscarchofer", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@buscar", buscar);
            read = cmd.ExecuteReader();

            List<Chofer> Listar = new List<Chofer>();

            while (read.Read())
            {

                Listar.Add(
                    new Chofer
                    {
                        ID1 = read.GetInt32(0),
                        Nombre1 = read.GetString(1),
                        Apellido1 = read.GetString(2),
                        Fecha1 = read.GetString(3),
                        Cedula1 = read.GetString(4),
                        Ruta1 = read["Ruta"].ToString()

                    }

                );
            }
            conexion.Close();
            read.Close();
            return Listar;
        }
        public List<Chofer> ListarChofer()
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("select * from Chofer", conexion);
            conexion.Close();
            conexion.Open();
            read = cmd.ExecuteReader();

            List<Chofer> Listar = new List<Chofer>();

            while (read.Read())
            {

                Listar.Add(
                    new Chofer
                    {
                        ID1 = read.GetInt32(0),
                        Nombre1 = read.GetString(1),
                        Apellido1 = read.GetString(2),
                        Fecha1 = read.GetString(3),
                        Cedula1 = read.GetString(4),
                        Ruta1 = read["Ruta"].ToString()

                    }

                );
            }
            conexion.Close();
            read.Close();
            return Listar;
        }
        public void InsertarChofer(Chofer chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_inChofer", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre1);
            cmd.Parameters.AddWithValue("@Apellido", chofer.Apellido1);
            cmd.Parameters.AddWithValue("@Fecha", chofer.Fecha1);
            cmd.Parameters.AddWithValue("@Cedula", chofer.Cedula1);


            cmd.ExecuteNonQuery();
            conexion.Close();

        } 
        public void EditarChofer(Chofer chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_EdChofer", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre1);
            cmd.Parameters.AddWithValue("@Apellido", chofer.Apellido1);
            cmd.Parameters.AddWithValue("@Fecha", chofer.Fecha1);
            cmd.Parameters.AddWithValue("@Cedula", chofer.Cedula1);
            cmd.Parameters.AddWithValue("@ruta", chofer.Ruta1);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void EliminarChofer(Chofer chofer)
        {
            SqlCommand cmd = new SqlCommand("SP_DelChofer", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", chofer.ID1);
            cmd.Parameters.AddWithValue("@Nombre", chofer.Nombre1);
            cmd.Parameters.AddWithValue("@Apellido", chofer.Apellido1);
            cmd.Parameters.AddWithValue("@Fecha", chofer.Fecha1);
            cmd.Parameters.AddWithValue("@Cedula", chofer.Cedula1);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public string choferes()
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("select * from Chofer where Ruta is null", conexion);
            conexion.Close();
            conexion.Open();
            read = cmd.ExecuteReader();
            string chofer = "";
            while (read.Read())
            {
                chofer += $"{read["Cedula"]} | {read["Nombre"]} {read["Apellido"]}" + "\n";
            }
            return chofer;
            conexion.Close();
        }
    }
}
