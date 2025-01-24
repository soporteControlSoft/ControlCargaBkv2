using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITercero
    {
        public Task<List<MdloDtos.DTO.TerceroDTO>> ListarTercero();

        public Task<List<MdloDtos.DTO.TerceroDTO>> FiltrarTerceroGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.TerceroDTO>> FiltrarTerceroEspecifico(String Codigo);

        public Task<dynamic> IngresarTercero(MdloDtos.DTO.TerceroDTO ObjTercero);

        public Task<MdloDtos.DTO.TerceroDTO> EditarTercero(MdloDtos.DTO.TerceroDTO ObjTercero);

        public Task<dynamic> EliminarTercero(int Codigo);

        public Task<List<MdloDtos.DTO.TerceroDTO>> FiltrarTerceroPorTipo(int Codigo);

        public Task<List<MdloDtos.DTO.TerceroDTO>> FiltrarTerceroEspecificoPorId(int IdTercero);
    }
}
