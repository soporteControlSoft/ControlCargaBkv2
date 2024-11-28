using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISituacionPortuariaDetalle
    {
        public Task<MdloDtos.SituacionPortuariaDetalle> IngresarSituacionPortuariaDetalle(MdloDtos.SituacionPortuariaDetalle ObjSituacionPortuariaDetalle);

        public Task<List<MdloDtos.SituacionPortuariaDetalle>> FiltrarSituacionPortuariaDetallePorIdSituacionPortuaria(int IdSituacionPortuaria);

        public Task<MdloDtos.SituacionPortuariaDetalle> FiltrarSituacionPortuariaDetalleEspecifico(int IdSituacionPortuariaDetalle);

        public Task<List<MdloDtos.SituacionPortuariaDetalle>> consultarSituacionPortuariaDetalle();

        public Task<MdloDtos.SituacionPortuariaDetalle> EditarSituacionPortuariaDetalle(MdloDtos.SituacionPortuariaDetalle ObjSituacionPortuariaDetalle);

        public Task<MdloDtos.SituacionPortuariaDetalle> EliminarSituacionPortuariaDetalleEspecifico(MdloDtos.SituacionPortuariaDetalle ObjSituacionPortuariaDetalle);

        public Task<bool> EliminarSituacionPortuariaDetallePorIdSituacionPortuaria(MdloDtos.SituacionPortuarium ObjSituacionPortuarium);
    }
}
