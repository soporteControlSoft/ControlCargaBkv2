using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IAuditoriaMotivo
    {
        public Task<List<MdloDtos.AuditoriaMotivo>> ListarAuditoriaMotivo();

        public Task<List<MdloDtos.AuditoriaMotivo>> FiltrarAuditoriaMotivoEspecifico(String Codigo);
        public Task<List<MdloDtos.AuditoriaMotivo>> FiltrarAuditoriaMotivoGeneral(String Codigo);

        public Task<MdloDtos.AuditoriaMotivo> IngresarAuditoriaMotivo(MdloDtos.AuditoriaMotivo ObjAuditoriaMotivo);

        public Task<MdloDtos.AuditoriaMotivo> EditarAuditoriaMotivo(MdloDtos.AuditoriaMotivo ObjAuditoriaMotivo);

        public Task<MdloDtos.AuditoriaMotivo> EliminarAuditoriaMotivo(String Codigo);
    }
}
