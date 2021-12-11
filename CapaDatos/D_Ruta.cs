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
    public class D_Ruta
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);

        public List<Ruta> BuscarRuta(string buscar)
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("SP_Buscarruta", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Open();

            cmd.Parameters.AddWithValue("@buscar", buscar);
            read = cmd.ExecuteReader();

            List<Ruta> Listar = new List<Ruta>();

            while (read.Read())
            {
                Listar.Add(
                    new Ruta
                    {
                        ID1 = read.GetInt32(0),
                        NombreR1 = read.GetString(1)
                    });
            }
            conexion.Close();
            read.Close();
            return Listar;
        }
        public List<Ruta> ListarRuta()
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("select r.ID, Nombre_ruta, Nombre, Placa, Marca, Modelo, Cedula, Apellido from Rutas" +
                " r left join Chofer c on r.ID = c.Ruta   left join Bus b on b.IDRuta = r.ID;", conexion);
            
            conexion.Open();
            read = cmd.ExecuteReader();

            List<Ruta> Listar = new List<Ruta>();

            while (read.Read())
            {
                
                Listar.Add(
                    new Ruta
                    {
                        ID1 = read.GetInt32(0),
                        NombreR1 = read.GetString(1),
                        Chofer1 = $"{read["Cedula"]} | {read["Nombre"]}",
                        Bus1 = $"{read["Placa"]} | {read["Marca"]} | {read["Modelo"]}"

                    });
            }
            conexion.Close();
            read.Close();
            return Listar;
        }
        public void InsertarRuta(Ruta ruta)
        {
            SqlCommand cmd = new SqlCommand("SP_inRuta", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", ruta.ID1);
            cmd.Parameters.AddWithValue("@Nombre", ruta.NombreR1);
            cmd.ExecuteNonQuery();

            conexion.Close();

        }
        public void EditarRuta(Ruta ruta)
        {
            SqlCommand cmd = new SqlCommand("SP_EdRuta", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", ruta.ID1);
            cmd.Parameters.AddWithValue("@Nombre", ruta.NombreR1);
            cmd.ExecuteNonQuery();

            conexion.Close();

        }
        public void EliminarRuta(Ruta ruta)
        {
            SqlCommand cmd = new SqlCommand("SP_DelRuta", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@ID", ruta.ID1);
            cmd.Parameters.AddWithValue("@Nombre", ruta.NombreR1);
            cmd.ExecuteNonQuery();

            conexion.Close();

        }
    }
}
