using MdloDtos.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IConceptosPesajes
    {
        //Consultar toda la tabla
        public Task<List<ConceptoPesajeDTO>> ConsultarConceptosPesajes();

        //ingresar conceptos de pesajes
        public Task<dynamic> IngresarConceptosPesajes(ConceptoPesajeDTO ObjConceptosPesajes);

        //Actualizar conceptos de pesajes
        public Task<dynamic> EditarConceptosPesajes(ConceptoPesajeDTO ObjConceptosPesajes);

        //Eliminar un conceptos de pesajes.
        public Task<dynamic> EliminarConceptosPesajes(string CodigoEmpresa,string CodigoConceptos);

        //Filtrar un conceptos de pesajes por el codigo de la compañia
        public Task<List<ConceptoPesajeDTO>> FiltrarConceptosPesajesPorCompania(string CodigoCompania);

        //Filtrar conceptos de pesajes por el Codigo
        public Task<List<ConceptoPesajeDTO>> FiltrarConceptosPesajesCodigo(string CodigoConceptos);
    }
}
