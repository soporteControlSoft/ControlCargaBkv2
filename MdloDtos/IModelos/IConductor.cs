using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IConductor
    { 
        public Task<MdloDtos.Conductor> IngresarConductor(MdloDtos.Conductor conductor);

        public  Task<List<MdloDtos.VwCndctorLstar>> ListarConductor();

        public  Task<MdloDtos.Conductor> EditarConductor(MdloDtos.Conductor _Conductor);

        public  Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorGeneral(string Codigo);

        public  Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorEspecifico(string Identificacion);

        public  Task<MdloDtos.Conductor> EliminarConductor(string Identificacion);

        public  Task<bool> VerificarExistenciaConductor(string Identificacion);
    }
}
