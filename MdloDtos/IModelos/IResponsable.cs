using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IResponsable
    {
        public Task<MdloDtos.DTO.ResponsableDTO> IngresarResponsable(MdloDtos.DTO.ResponsableDTO ObjResponsable);
        public Task<List<MdloDtos.DTO.ResponsableDTO>> ListarResponsable(bool estado);

        public Task<MdloDtos.DTO.ResponsableDTO> EditarResponsable(MdloDtos.DTO.ResponsableDTO ObjResponsable);

        public Task<List<MdloDtos.DTO.ResponsableDTO>> FiltrarResponsableGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.DTO.ResponsableDTO>> FiltrarResponsableEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.DTO.ResponsableDTO> InactivarResponsable(MdloDtos.DTO.ResponsableDTO ObjResponsable);
        public Task<bool> VerificarResponsable(int? Codigo);

    }
}
