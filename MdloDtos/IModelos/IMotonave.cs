using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IMotonave
    {
        public Task<List<MdloDtos.Motonave>> ListarMotonave();

        public Task<List<MdloDtos.Motonave>> FiltrarMotonaveEspecifico(String Codigo);

        public Task<List<MdloDtos.Motonave>> FiltrarMotonaveGeneral(String Codigo);

        public Task<MdloDtos.Motonave> IngresarMotonave(MdloDtos.Motonave ObjMotonave);

        public Task<MdloDtos.Motonave> EditarMotonave(MdloDtos.Motonave ObjMotonave);

        public Task<MdloDtos.Motonave> EliminarMotonave(String Codigo);
    }
}
