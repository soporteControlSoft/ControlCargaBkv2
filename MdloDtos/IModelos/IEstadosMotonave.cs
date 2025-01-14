using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEstadosMotonave
    {
        public Task<List<MdloDtos.DTO.EstadoMotonaveDTO>> ListarEstadoMotonave();
        public Task<List<MdloDtos.DTO.EstadoMotonaveDTO>> FiltrarEstadoMotonaveEspecifico(string Codigo);
        
    }
}
