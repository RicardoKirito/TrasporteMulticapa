using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using C_Entidad;

namespace C_Negocios
{
    public class N_Chofer
    {
        D_Chofer obj = new D_Chofer();

        public List<Chofer> Listar()
        {
            return obj.ListarChofer();
        }
        public List<Chofer> Buscar(string buscar)
        {
            return obj.BuscarChofer(buscar);
        }
        public void Insertar(Chofer chofer)
        {
            obj.InsertarChofer(chofer);
        }
        public void Editar(Chofer chofer)
        {
            obj.EditarChofer(chofer);
        }
        public string Chofer()
        {
            return obj.choferes();
        }

    }
}
