using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IVisitaMotonaveBI
    {
        public Task<MdloDtos.VisitaMotonaveBl> IngresarVisitaMotonaveBl(MdloDtos.VisitaMotonaveBl ObjVisitaMotonaveBl);

        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorIdVisitaMotonaveDetalle(int IdVisitaMotonaveDetalle);

        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlEspecifico(int IdVisitaMotonaveBl);

        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorIdVisitaMotonave(int IdVisitaMotonave);
        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlAduanas(int IdVisitaMotonave, string codigoUsuario);

        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlPorFiltros(int? IdVisitaMotonaveBl,
                                                                                   int? IdVisitaMotonaveDetalle,
                                                                                   DateTime? fechaInicio,
                                                                                   DateTime? fechaFinal);
        public Task<List<MdloDtos.VisitaMotonaveBl>> ConsultarVisitaMotonaveBl();

        public Task<MdloDtos.VisitaMotonaveBl> EditarVisitaMotonaveBl(MdloDtos.VisitaMotonaveBl ObjVisitaMotonaveBl);

        public Task<MdloDtos.VisitaMotonaveBl> EliminarVisitaMotonaveBlEspecifico(MdloDtos.VisitaMotonaveBl ObjVisitaMotonaveBl);

        public Task<bool> EliminarVisitaMotonaveBlPorIdVisitaMotonaveDetalle(MdloDtos.VisitaMotonaveDetalle IdVisitaMotonaveDetalle);

        public Task<MdloDtos.VisitaMotonaveBl> actualizarEstadoVisitaMotonaveBl(MdloDtos.VisitaMotonaveBl ObjVisitaMotonaveBl);

        public Task<List<MdloDtos.VisitaMotonaveBl>> FiltrarVisitaMotonaveBlDepositoCreacion(int IdVisitaMotonave, int IdTercero, string codigoProducto);

    }
}
