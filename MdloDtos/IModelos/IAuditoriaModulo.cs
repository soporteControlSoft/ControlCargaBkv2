using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IAuditoriaModulo
    {
        public Task<List<MdloDtos.AuditoriaModulo>> ListarAuditoriaModulo();

        public Task<List<MdloDtos.AuditoriaModulo>> FiltrarAuditoriaModuloGeneral(String Codigo);

        public Task<List<MdloDtos.AuditoriaModulo>> FiltrarAuditoriaModuloEspecifico(String Codigo);

        public Task<MdloDtos.AuditoriaModulo> IngresarAuditoriaModulo(MdloDtos.AuditoriaModulo ObjAuditoriaModulo);

        public Task<MdloDtos.AuditoriaModulo> EditarAuditoriaModulo(MdloDtos.AuditoriaModulo ObjAuditoriaModulo);

        public Task<MdloDtos.AuditoriaModulo> EliminarAuditoriaModulo(String Codigo);
    }
}
