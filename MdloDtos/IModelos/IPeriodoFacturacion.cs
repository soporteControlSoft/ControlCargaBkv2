using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPeriodoFacturacion
    {
        public Task<List<MdloDtos.DTO.PeriodoFacturacionDTO>> ListarPeriodoFacturacion();

        public Task<List<MdloDtos.DTO.PeriodoFacturacionDTO>> FiltrarPeriodoFacturacionGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.PeriodoFacturacionDTO>> FiltrarPeriodoFacturacionEspecifico(String Codigo);

        public Task<dynamic> IngresarPeriodoFacturacion(MdloDtos.DTO.PeriodoFacturacionDTO ObjMotonave);

        public Task<dynamic> EditarPeriodoFacturacion(MdloDtos.DTO.PeriodoFacturacionDTO ObjMotonave);

        public Task<dynamic> EliminarPeriodoFacturacion(String Codigo);
    }
}
