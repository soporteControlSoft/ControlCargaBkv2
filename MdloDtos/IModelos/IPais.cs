using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IPais
    {
        public Task<List<MdloDtos.Pai>> ListarPais();

        public Task<List<MdloDtos.Pai>> FiltrarPaisGeneral(String Codigo);

        public Task<List<MdloDtos.Pai>> FiltrarPaisEspecifico(String Codigo);

        public Task<MdloDtos.Pai> IngresarPais(MdloDtos.Pai ObjPais);

        public Task<MdloDtos.Pai> EditarPais(MdloDtos.Pai ObjPais);

        public Task<MdloDtos.Pai> EliminarPais(string Codigo);
    }
}
