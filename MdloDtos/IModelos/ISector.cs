using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISector
    {
        public Task<MdloDtos.Sector> IngresarSector(MdloDtos.Sector ObjSector);
        public Task<List<MdloDtos.Sector>> ListarSector();
        public Task<bool> VerificarSector(int Codigo);

    }
}
