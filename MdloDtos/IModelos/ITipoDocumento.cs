using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITipoDocumento
    {
        public Task<List<MdloDtos.TipoDocumento>> ListarTipoDocumento();

        public Task<List<MdloDtos.TipoDocumento>> FiltrarTipoDocumentoGeneral(String Codigo);

        public Task<List<MdloDtos.TipoDocumento>> FiltrarTipoDocumentoEspecifico(String Codigo);

        public Task<List<MdloDtos.TipoDocumento>> FiltrarTipoDocumentoDetalle();

        public Task<MdloDtos.TipoDocumento> IngresarTipoDocumento(MdloDtos.TipoDocumento ObjTipoDocumento);

        public Task<MdloDtos.TipoDocumento> EditarTipoDocumento(MdloDtos.TipoDocumento ObjTipoDocumento);

    }
}
