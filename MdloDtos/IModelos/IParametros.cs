using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IParametros
    {
        public Task<List<MdloDtos.DTO.ParametroDTO>> ListarParametro();

        public Task<List<MdloDtos.DTO.ParametroDTO>> ListarParametroTodos();

        public Task<MdloDtos.DTO.ParametroDTO> EditarParametro(MdloDtos.DTO.ParametroDTO ParametroDTO);

        public Task<bool> VerificarParametroExiste(int IdParametro);
    }
}
