using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICiudad
    {
        public Task<List<MdloDtos.DTO.CiudadDTO>> ListarCiudad();

        public Task<List<MdloDtos.DTO.CiudadDTO>> FiltrarCiudadPorDepartamento(int Codigo);

        public Task<dynamic> IngresarCiudad(MdloDtos.DTO.CiudadDTO ObjCiudad);

        public Task<MdloDtos.DTO.CiudadDTO> EditarCiudad(MdloDtos.DTO.CiudadDTO ObjCiudad);

        public Task<List<MdloDtos.DTO.CiudadDTO>> FiltrarCiudadEspecifico(String Codigo);
        public Task<List<MdloDtos.DTO.CiudadDTO>> FiltrarCiudadGeneral(String Codigo);
        public Task<dynamic> EliminarCiudad(string Codigo);

    }
}
