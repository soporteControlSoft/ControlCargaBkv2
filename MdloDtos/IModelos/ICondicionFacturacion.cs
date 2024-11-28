using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICondicionFacturacion
    {
        public Task<List<MdloDtos.CondicionFacturacion>> ListarCondicionFacturacion();

        public Task<List<MdloDtos.CondicionFacturacion>> FiltrarCondicionFacturacionGeneral(String Codigo);

        public Task<List<MdloDtos.CondicionFacturacion>> FiltrarCondicionFacturacionEspecifico(String Codigo);

        public Task<MdloDtos.CondicionFacturacion> IngresarCondicionFacturacion(MdloDtos.CondicionFacturacion ObjCondicionFacturacion);

        public Task<MdloDtos.CondicionFacturacion> EditarCondicionFacturacion(MdloDtos.CondicionFacturacion ObjCondicionFacturacion);

        public Task<MdloDtos.CondicionFacturacion> EliminarCondicionFacturacion(String Codigo);
    }
}
