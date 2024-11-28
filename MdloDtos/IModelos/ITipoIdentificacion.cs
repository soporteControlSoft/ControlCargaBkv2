using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITipoIdentificacion
    {
        public Task<List<MdloDtos.TipoIdentificacion>> ListarTipoIdentificacion();

        public Task<List<MdloDtos.TipoIdentificacion>> FiltrarTipoIdentificacionGeneral(String Codigo);

        public Task<List<MdloDtos.TipoIdentificacion>> FiltrarTipoIdentificacionEspecifico(String Codigo);

        public Task<MdloDtos.TipoIdentificacion> IngresarTipoIdentificacion(MdloDtos.TipoIdentificacion ObjTipoIdentificacion);

        public Task<MdloDtos.TipoIdentificacion> EditarTipoIdentificacion(MdloDtos.TipoIdentificacion ObjTipoIdentificacion);

        public Task<MdloDtos.TipoIdentificacion> EliminarTipoIdentificacion(String Codigo);
    }
}
