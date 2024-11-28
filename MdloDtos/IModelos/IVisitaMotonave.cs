using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IVisitaMotonave
    {
        public Task<string> ConsultarSecuenciaVisitaMotonave(string CodigoCompania, String CodigoMotonave);

        public Task<MdloDtos.VisitaMotonave> IngresarVisitaMotonave(MdloDtos.VisitaMotonave ObjVisitaMotonave);
        
        public Task<List<MdloDtos.VisitaMotonave>> FiltrarVisitaMotonaveEspecifico(DateTime FechaInicio, DateTime FechaFin,string Motonave);
        public Task<List<MdloDtos.VisitaMotonave>> FiltrarVisitaMotonaveId(int Id);

        public Task<List<MdloDtos.VisitaMotonave>> FiltrarVisitaMotonaveMotonave(string Motonave);

        public Task<List<MdloDtos.VisitaMotonave>> ConsultarVisitaMotonave();

        public Task<MdloDtos.VisitaMotonave> EditarVisitaMotonave(MdloDtos.VisitaMotonave ObjVisitaMotonave);

        public Task<List<VisitaMotonaveDocumento>> ConsultaVisitaMotonaveCompania(string Compania, DateTime fechaInicio, DateTime FechaFin);

        public Task<List<VisitaMotonave>> ConsultaVisitaMotonaveAduana(string Compania, string CodigoUsuario);

        public Task<int>  ConsultaCantidadDocumentosPendientesAprobacionPorVisitaMotonave(int IdVisitaMotonave);

        public Task<List<VwMdloDpstoLstarVstaMtnve>> ConsultaVisitaMotonaveDeposito(string Compania, string CodigoUsuario);

        public Task<List<VwMdloDpstoAprbcionLstarVstaMtnve>> ConsultaVisitaMotonaveDepositoAprobacion(string Compania);

        public Task<List<MdloDtos.VwMdloDpstoCrcionLstarVstaMtnve>> ConsultaVisitaMotonaveDepositoCreacion(string Compania);
    }
}
    