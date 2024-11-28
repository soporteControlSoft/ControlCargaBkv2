using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IVisitaMotonaveDetalle
    {
        //public Task<MdloDtos.VisitaMotonaveDetalle> IngresarVisitaMotonaveDetalle(MdloDtos.VisitaMotonaveDetalle ObjVisitaMotonaveDetalle);

        public Task<List<MdloDtos.VisitaMotonaveDetalle>> FiltrarVisitaMotonaveDetallePorIdVisitaMotonave(int IdVisitaMotonave);

        public Task<List<MdloDtos.VisitaMotonaveDetalle>> FiltrarVisitaMotonaveDetalleEspecifico(int IdVisitaMotonaveDetalle);

        public Task<List<MdloDtos.VisitaMotonaveDetalle>> consultarVisitaMotonaveDetalle();

        public Task<MdloDtos.VisitaMotonaveDetalle> EditarVisitaMotonaveDetalle(MdloDtos.VisitaMotonaveDetalle ObjVisitaMotonaveDetalle);

        public Task<MdloDtos.VisitaMotonaveDetalle> EliminarVisitaMotonaveDetalleEspecifico(MdloDtos.VisitaMotonaveDetalle ObjVisitaMotonaveDetalle);

        public Task<bool> EliminarVisitaMotonaveDetallePorIdVisitaMotonave(MdloDtos.VisitaMotonave IdVisitaMotonave);
    }
}
