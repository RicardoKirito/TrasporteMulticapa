using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using CapaDatos;
using C_Entidad;

namespace C_Negocios
{
    public class N_Bus
    {
        D_Bus obj = new D_Bus();

        public List<Bus> Listar()
        {
            return obj.ListarBus();
        }
        public List<Bus> Buscar(string buscar)
        {
            return obj.BuscarBus(buscar);
        }
        public void Editar(Bus bus)
        {
            obj.Editarbus(bus);
        }
        public void Insertar(Bus bus)
        {
            obj.InsertarBus(bus);
        }
        public void Eliminar(Bus bus)
        {
            obj.Eliminarbus(bus);
        }
        public string Marca()
        {
            return obj.Marcas();
        }
        public string Modelo(string marca)
        {
            return obj.Modelos(marca);
        }
        public string Bus()
        {
            return obj.bus();
        }
    }
}
