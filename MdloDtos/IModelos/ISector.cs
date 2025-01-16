using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISector
    {
        public Task<MdloDtos.DTO.SectorDTO> IngresarSector(MdloDtos.DTO.SectorDTO ObjSector);
        public Task<List<MdloDtos.DTO.SectorDTO>> ListarSector();
        public Task<bool> VerificarSector(int Codigo);

    }
}
