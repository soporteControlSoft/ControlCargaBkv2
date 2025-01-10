using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IClasificacion
    {
        public Task<MdloDtos.DTO.ClasificacionDTO> IngresarClasificacion(MdloDtos.DTO.ClasificacionDTO ObjClasificacion);
        public Task<List<MdloDtos.DTO.ClasificacionDTO>> ListarClasificacion(bool estado);
        public Task<MdloDtos.DTO.ClasificacionDTO> EditarClasificacion(MdloDtos.DTO.ClasificacionDTO ObjClasificacion);
        public Task<List<MdloDtos.DTO.ClasificacionDTO>> FiltrarClasificacionGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.DTO.ClasificacionDTO>> FiltrarClasificacionEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.DTO.ClasificacionDTO> InactivarClasificacion(MdloDtos.DTO.ClasificacionDTO ObjClasificacion);
        public Task<bool> VerificarClasificacion(int Codigo);

    }
}
