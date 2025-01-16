using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPuertoOrigen
    {
        public Task<List<MdloDtos.DTO.PuertoOrigenDTO>> ListarPuertoOrigen();

        public Task<List<MdloDtos.DTO.PuertoOrigenDTO>> FiltrarPuertoOrigenGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.PuertoOrigenDTO>> FiltrarPuertoOrigenEspecifico(String Codigo);

        public Task<MdloDtos.DTO.PuertoOrigenDTO> IngresarPuertoOrigen(MdloDtos.DTO.PuertoOrigenDTO ObjPuertoOrigen);

        public Task<MdloDtos.DTO.PuertoOrigenDTO> EditarPuertoOrigen(MdloDtos.DTO.PuertoOrigenDTO ObjPuertoOrigen);

        public Task<dynamic> EliminarPuertoOrigen(String Codigo);
    }
}
