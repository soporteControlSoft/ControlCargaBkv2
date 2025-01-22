using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEmpaque
    {
        public Task<List<MdloDtos.DTO.EmpaqueDTO>> ListarEmpaque();

        public Task<List<MdloDtos.DTO.EmpaqueDTO>> FiltrarEmpaqueEspecifico(String Codigo);

        public Task<List<MdloDtos.DTO.EmpaqueDTO>> FiltrarEmpaqueGeneral(String Codigo);

        public Task<dynamic> IngresarEmpaque(MdloDtos.DTO.EmpaqueDTO ObjEmpaque);

        public Task<MdloDtos.DTO.EmpaqueDTO> EditarEmpaque(MdloDtos.DTO.EmpaqueDTO ObjEmpaque);

        public Task<dynamic> EliminarEmpaque(int RowId);
    }
}
