using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEquipo
    {
        public Task<MdloDtos.DTO.EquipoDTO> IngresarEquipo(MdloDtos.DTO.EquipoDTO ObjCEquipo);
        public Task<List<MdloDtos.DTO.EquipoDTO>> ListarEquipo(bool estado);

        public Task<MdloDtos.DTO.EquipoDTO> EditarEquipo(MdloDtos.DTO.EquipoDTO ObjEquipo);

        public Task<List<MdloDtos.DTO.EquipoDTO>> FiltrarEquipoGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.DTO.EquipoDTO>> FiltrarEquipoEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.DTO.EquipoDTO> InactivarEquipo(MdloDtos.DTO.EquipoDTO ObjEquipo);
        public Task<bool> VerificarEquipo(int Codigo);

    }
}
