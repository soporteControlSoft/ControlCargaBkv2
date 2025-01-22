using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IDepartamento
    {
        public Task<List<MdloDtos.DTO.DepartamentoDTO>> ListarDepartamento();

        public Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoPorPais(String Codigo);

        public Task<dynamic> IngresarDepartamento(MdloDtos.DTO.DepartamentoDTO ObjDepartamento);

        public Task<MdloDtos.DTO.DepartamentoDTO> EditarDepartamento(MdloDtos.DTO.DepartamentoDTO ObjDepartamento);

        public Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoGeneral(String Codigo);
        public Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoEspecifico(String Codigo);

        public Task<dynamic> EliminarDepartamento(int Codigo);
    }
}
