using MdloDtos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITiposConceptos
    {
        //Consultar toda la tabla
        public Task<List<TipoConceptoDTO>> ConsultarTipoConcepto();


        //Filtrar un tipo de concepto por el codigo
        public Task<List<TipoConceptoDTO>> FiltrarTipoConceptoPorCodigo(string Codigo);
    }
}
