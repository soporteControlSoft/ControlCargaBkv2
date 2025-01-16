using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IUnidadMedida
    {
        public Task<List<MdloDtos.DTO.UnidadMedidumDTO>> ListarUnidadMedida();

        public Task<List<MdloDtos.DTO.UnidadMedidumDTO>> FiltrarUnidadMedidaEspecifico(String Codigo);

        public Task<List<MdloDtos.DTO.UnidadMedidumDTO>> FiltrarUnidadMedidaGeneral(String Codigo);

        public Task<dynamic> IngresarUnidadMedida(MdloDtos.DTO.UnidadMedidumDTO ObjUnidadMedida);

        public Task<MdloDtos.DTO.UnidadMedidumDTO> EditarUnidadMedida(MdloDtos.DTO.UnidadMedidumDTO ObjUnidadMedida);

        public Task<dynamic> EliminarUnidadMedida(String Codigo);
    }
}
