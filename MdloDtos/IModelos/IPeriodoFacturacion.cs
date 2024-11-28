using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPeriodoFacturacion
    {
        public Task<List<MdloDtos.PeriodoFacturacion>> ListarPeriodoFacturacion();

        public Task<List<MdloDtos.PeriodoFacturacion>> FiltrarPeriodoFacturacionGeneral(String Codigo);

        public Task<List<MdloDtos.PeriodoFacturacion>> FiltrarPeriodoFacturacionEspecifico(String Codigo);

        public Task<MdloDtos.PeriodoFacturacion> IngresarPeriodoFacturacion(MdloDtos.PeriodoFacturacion ObjMotonave);

        public Task<MdloDtos.PeriodoFacturacion> EditarPeriodoFacturacion(MdloDtos.PeriodoFacturacion ObjMotonave);

        public Task<MdloDtos.PeriodoFacturacion> EliminarPeriodoFacturacion(String Codigo);
    }
}
