using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IDocumentacionVisita
    {
        //Consulta motonave asociadas a la visita motonave encabezado
        public Task<List<MdloDtos.VisitaMotonaveDocumento>> ListaVisitaMotonave(string CodigoUsuario,string CodigoConpania);

        //Consulta motonave asociadas a la visita motonave encabezado
        public Task<List<MdloDtos.VisitaMotonaveDocumento>> ListaVisitaMotonavePorCompania(string CodigoConpania);

        //Consulta todos los tipo de documentos.
        public Task<List<MdloDtos.TipoDocumento>> ConsultarTipoDocumentos(int VisitaMotonave);

        //Ingresar visita motonave documento
        public Task<MdloDtos.VisitaMotonaveDocumento> IngresarVisitaMotonaveDocumento(MdloDtos.VisitaMotonaveDocumento _VisitaMotonaveDocumento);

        //consulta documentos asociados a la visita motonave , que cargo la agencia naviera.
        public  Task<List<VisitaMotonaveDocumento>> ConsultarTipoDocumentosIdVisita(int idVisitaMotonave);

        public  Task<MdloDtos.VisitaMotonaveDocumento> EditarEstadoDocumentos(MdloDtos.VisitaMotonaveDocumento _VisitaMotonaveDocumento);

        public Task<List<MdloDtos.Comentario>> IngresarComentario(int CodigoVisitaMotonaveDocumento, string codigoUsuario, string comentario);

        public Task<List<MdloDtos.Comentario>> ConsultarComentario(int CodigoVisitaMotonaveDocumento);

        public Task<List<MdloDtos.VisitaMotonaveDocumento>> ActualizarTarifas(List<MdloDtos.VisitaMotonaveDocumento> listVisitaMotonaveDocumento);
    }
}
