using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICausalCancelacion
    {
        public Task<List<MdloDtos.CausalCancelacion>> ListarCausalCancelacion();

        public Task<List<MdloDtos.CausalCancelacion>> FiltrarCausalCancelacionEspecifico(String Codigo);
        public Task<List<MdloDtos.CausalCancelacion>> FiltrarCausalCancelacionGeneral(String Codigo);
        public Task<MdloDtos.CausalCancelacion> IngresarCausalCancelacion(MdloDtos.CausalCancelacion ObjCausalCancelacion);

        public Task<MdloDtos.CausalCancelacion> EditarCausalCancelacion(MdloDtos.CausalCancelacion ObjCausalCancelacion);

        public Task<MdloDtos.CausalCancelacion> EliminarCausalCancelacion(String Codigo);
    }
}
