using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITipoDocumento
    {
        public Task<List<MdloDtos.DTO.TipoDocumentoDTO>> ListarTipoDocumento();

        public Task<List<MdloDtos.DTO.TipoDocumentoDTO>> FiltrarTipoDocumentoGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.TipoDocumentoDTO>> FiltrarTipoDocumentoEspecifico(String Codigo);

        public Task<List<MdloDtos.DTO.TipoDocumentoDTO>> FiltrarTipoDocumentoDetalle();

        public Task<dynamic> IngresarTipoDocumento(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento);

        public Task<MdloDtos.DTO.TipoDocumentoDTO> EditarTipoDocumento(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento);

    }
}
