using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITipoIdentificacion
    {
        public Task<List<MdloDtos.DTO.TipoIdentificacionDTO>> ListarTipoIdentificacion();

        public Task<List<MdloDtos.DTO.TipoIdentificacionDTO>> FiltrarTipoIdentificacionGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.TipoIdentificacionDTO>> FiltrarTipoIdentificacionEspecifico(String Codigo);

        public Task<dynamic> IngresarTipoIdentificacion(MdloDtos.DTO.TipoIdentificacionDTO ObjTipoIdentificacion);

        public Task<MdloDtos.DTO.TipoIdentificacionDTO> EditarTipoIdentificacion(MdloDtos.DTO.TipoIdentificacionDTO ObjTipoIdentificacion);

        public Task<dynamic> EliminarTipoIdentificacion(String Codigo);
    }
}
