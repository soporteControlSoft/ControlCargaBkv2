using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IResponsable
    {
        public Task<MdloDtos.Responsable> IngresarResponsable(MdloDtos.Responsable ObjResponsable);
        public Task<List<MdloDtos.Responsable>> ListarResponsable(bool estado);

        public Task<MdloDtos.Responsable> EditarResponsable(MdloDtos.Responsable ObjResponsable);

        public Task<List<MdloDtos.Responsable>> FiltrarResponsableGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.Responsable>> FiltrarResponsableEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.Responsable> InactivarResponsable(MdloDtos.Responsable ObjResponsable);
        public Task<bool> VerificarResponsable(int? Codigo);

    }
}
