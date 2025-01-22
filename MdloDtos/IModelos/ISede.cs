using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISede
    {
        public Task<List<MdloDtos.DTO.SedeDTO>> ListarSede();

        public Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedePorCompania(string Codigo);

        public Task<dynamic> IngresarSede(MdloDtos.DTO.SedeDTO ObjSede);

        public Task<MdloDtos.DTO.SedeDTO> EditarSede(MdloDtos.DTO.SedeDTO ObjSede);

        public Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedeGeneral(String Codigo);
        public Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedeEspecifico(String Codigo);

        public Task<dynamic> EliminarSede(int Codigo);

    }
}
