using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IMotonave
    {
        public Task<List<MdloDtos.DTO.MotonaveDTO>> ListarMotonave();

        public Task<List<MdloDtos.DTO.MotonaveDTO>> FiltrarMotonaveEspecifico(String Codigo);

        public Task<List<MdloDtos.DTO.MotonaveDTO>> FiltrarMotonaveGeneral(String Codigo);

        public Task<dynamic> IngresarMotonave(MdloDtos.DTO.MotonaveDTO ObjMotonave);

        public Task<MdloDtos.DTO.MotonaveDTO> EditarMotonave(MdloDtos.DTO.MotonaveDTO ObjMotonave);

        public Task<dynamic> EliminarMotonave(String Codigo);
    }
}
