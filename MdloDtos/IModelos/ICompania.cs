using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICompania
    {
        public Task<List<MdloDtos.DTO.companiaDTO>> ListarCompania();

        public Task<MdloDtos.DTO.companiaDTO> IngresarCompania(MdloDtos.DTO.companiaDTO ObjCiudad);

        public Task<MdloDtos.DTO.companiaDTO> EditarCompania(MdloDtos.DTO.companiaDTO ObjCiudad);

        public Task<List<MdloDtos.DTO.companiaDTO>> FiltrarCompaniaGeneral(String Codigo);
        public Task<List<MdloDtos.DTO.companiaDTO>> FiltrarCompaniaEspecifico(String Codigo);
        public Task<dynamic> EliminarCompania(string Codigo);

    }
}
