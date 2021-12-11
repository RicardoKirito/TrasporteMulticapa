using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using C_Entidad;


namespace C_Negocios
{
    public class N_Ruta
    {
        D_Ruta obj = new D_Ruta();
         
        public List<Ruta> Listar()
        {
            return obj.ListarRuta();
        }
        public List<Ruta> Buscar(string buscar)
        {
            return obj.BuscarRuta(buscar);
        }
        public void Insertar(Ruta ruta)
        {
            obj.InsertarRuta(ruta);
        }
        public void Editar(Ruta ruta)
        {
            obj.EditarRuta(ruta);

        }
        public void Eliminar(Ruta ruta)
        {
            obj.EliminarRuta(ruta);
        }
    }
}
