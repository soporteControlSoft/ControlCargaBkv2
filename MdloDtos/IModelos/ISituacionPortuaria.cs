using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISituacionPortuaria
    {
        public Task<MdloDtos.SituacionPortuarium> IngresarSituacionPortuaria(MdloDtos.SituacionPortuarium ObjSituacionPortuarium);
    
        public Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorZona(int IdZona);

        public Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorTerminal(string CodigoTerminalMaritimo);

        public Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorMotonave(string CodigoMotonave);

        public Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorEstadoMotonave(string CodigoEstadoMotonave);

        public Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorPais(string CodigoPais);
        public Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorIdSituacion(int IdSituacion);

        public Task<List<MdloDtos.SituacionPortuarium>> ConsultarSituacionPortuaria();

        public Task<MdloDtos.SituacionPortuarium> EditarSituacionPortuaria(MdloDtos.SituacionPortuarium ObjSituacionPortuarium);

        public Task<MdloDtos.SituacionPortuarium> EliminarSituacionPortuaria(int RowId);

      
    }
}
