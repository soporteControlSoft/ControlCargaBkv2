using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICompania
    {
        public Task<List<MdloDtos.Companium>> ListarCompania();

        public Task<MdloDtos.Companium> IngresarCompania(MdloDtos.Companium ObjCiudad);

        public Task<MdloDtos.Companium> EditarCompania(MdloDtos.Companium ObjCiudad);

        public Task<List<MdloDtos.Companium>> FiltrarCompaniaGeneral(String Codigo);
        public Task<List<MdloDtos.Companium>> FiltrarCompaniaEspecifico(String Codigo);
        public Task<MdloDtos.Companium> EliminarCompania(string Codigo);

    }
}
