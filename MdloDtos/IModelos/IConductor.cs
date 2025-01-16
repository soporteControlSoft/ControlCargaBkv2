using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IConductor
    { 
        public Task<dynamic> IngresarConductor(MdloDtos.DTO.ConductorDTO conductor);

        public  Task<List<MdloDtos.VwCndctorLstar>> ListarConductor();

        public  Task<MdloDtos.DTO.ConductorDTO> EditarConductor(MdloDtos.DTO.ConductorDTO _Conductor);

        public  Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorGeneral(string Codigo);

        public  Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorEspecifico(string Identificacion);

        public  Task<dynamic> EliminarConductor(string Identificacion);

        public  Task<bool> VerificarExistenciaConductor(string Identificacion);
    }
}
