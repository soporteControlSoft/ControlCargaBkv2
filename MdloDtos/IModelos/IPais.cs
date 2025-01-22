using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPais
    {
        public Task<List<MdloDtos.DTO.PaisDTO>> ListarPais();
          
        public Task<List<MdloDtos.DTO.PaisDTO>> FiltrarPaisGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.PaisDTO>> FiltrarPaisEspecifico(String Codigo);

        public Task<dynamic> IngresarPais(MdloDtos.DTO.PaisDTO ObjPais);

        public Task<MdloDtos.DTO.PaisDTO> EditarPais(MdloDtos.DTO.PaisDTO ObjPais);

        public Task<dynamic> EliminarPais(string Codigo);
    }
}
