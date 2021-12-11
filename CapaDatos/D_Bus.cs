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
    public class D_Bus
    {
        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public List<Bus> ListarBus()
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("Select * from bus", conexion);
            conexion.Close();
            conexion.Open();
            read = cmd.ExecuteReader();

            List<Bus> Listar = new List<Bus>();

            while (read.Read())
            {
                Listar.Add(
                    new Bus
                    {
                        ID1 = read.GetInt32(0),
                        Marca1 = read.GetString(1),
                        Modelo1 = read.GetString(2),
                        Ano1 = read.GetString(3),
                        Color1 = read.GetString(4),
                        Placa1 = read.GetString(5),
                        IDruta1 = read["IDRuta"].ToString()
                    });
            }
            conexion.Close();
            read.Close();
            return Listar;
        }
        public List<Bus> BuscarBus(string buscar)
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("SP_Buscarauto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Close();
            conexion.Open();
            cmd.Parameters.AddWithValue("@buscar", buscar);
            read = cmd.ExecuteReader();

            List<Bus> Listar = new List<Bus>();

            while (read.Read())
            {
                Listar.Add(
                    new Bus
                    {
                        ID1 = read.GetInt32(0),
                        Marca1 = read.GetString(1),
                        Modelo1 = read.GetString(2),
                        Ano1 = read.GetString(3),
                        Color1 = read.GetString(4),
                        Placa1 = read.GetString(5),
                        IDruta1 = read["IDRuta"].ToString()
                    });
            }
            conexion.Close();
            read.Close();
            return Listar;
        }
        public void InsertarBus(Bus bus)
        {
            SqlCommand cmd = new SqlCommand("SP_inAutobus", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Close();
            conexion.Open();
            cmd.Parameters.AddWithValue("@Marca", bus.Marca1);
            cmd.Parameters.AddWithValue("@Modelo", bus.Modelo1);
            cmd.Parameters.AddWithValue("@Ano", bus.Ano1);
            cmd.Parameters.AddWithValue("@Color", bus.Color1);
            cmd.Parameters.AddWithValue("@Placa", bus.Placa1);

            cmd.ExecuteNonQuery();
            conexion.Close();

        }
        public void Editarbus(Bus bus)
        {
            SqlCommand cmd = new SqlCommand("SP_EdBus", conexion);
            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Marca", bus.Marca1);
            cmd.Parameters.AddWithValue("@Modelo", bus.Marca1);
            cmd.Parameters.AddWithValue("@Ano", bus.Marca1);
            cmd.Parameters.AddWithValue("@Placa", bus.Marca1);
            cmd.Parameters.AddWithValue("@IDRuta", bus.Marca1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public void Eliminarbus(Bus bus)
        {
            SqlCommand cmd = new SqlCommand("SP_DelBus", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            conexion.Close();
            conexion.Open();
            cmd.Parameters.AddWithValue("@ID", bus.ID1);
            cmd.Parameters.AddWithValue("@Marca", bus.Marca1);
            cmd.Parameters.AddWithValue("@Modelo", bus.Marca1);
            cmd.Parameters.AddWithValue("@Ano", bus.Marca1);
            cmd.Parameters.AddWithValue("@Placa", bus.Marca1);
            cmd.Parameters.AddWithValue("@IDRuta", bus.Marca1);

            cmd.ExecuteNonQuery();
            conexion.Close();
        }
        public string Marcas()
        {
            SqlCommand cmd = new SqlCommand("select distinct Marca from Brands", conexion);
            conexion.Close();
            conexion.Open();
            SqlDataReader read = cmd.ExecuteReader();
            string marca = "";

            while (read.Read())
            {
               marca += read["Marca"].ToString()+"\n";
                

            }
            return marca;
            conexion.Close();
        }
        public string Modelos(string marca)
        {
            SqlCommand cmd = new SqlCommand($"select distinct Modelo from Brands where Marca = '{marca}'", conexion);
            conexion.Close();
            conexion.Open();
            SqlDataReader read = cmd.ExecuteReader();
            string modelo = "";
            int count = 0;
            while (read.Read())
            {
                modelo += read["Modelo"].ToString() + "\n";
            }
            return modelo;
            conexion.Close();
        }
        public string bus()
        {
            SqlDataReader read;
            SqlCommand cmd = new SqlCommand("select * from Bus where IDRuta is null", conexion);
            conexion.Open();
            read = cmd.ExecuteReader();
            string bus = "";
            while (read.Read())
            {
                bus += $"{read["Placa"]} | {read["Marca"]} | {read["Modelo"]}" + "\n";
            }
            return bus;
        }
    }
}
