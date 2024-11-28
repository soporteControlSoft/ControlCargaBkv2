using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ITercero
    {
        public Task<List<MdloDtos.Tercero>> ListarTercero();

        public Task<List<MdloDtos.Tercero>> FiltrarTerceroGeneral(String Codigo);

        public Task<List<MdloDtos.Tercero>> FiltrarTerceroEspecifico(String Codigo);

        public Task<MdloDtos.Tercero> IngresarTercero(MdloDtos.Tercero ObjTercero);

        public Task<MdloDtos.Tercero> EditarTercero(MdloDtos.Tercero ObjTercero);

        public Task<MdloDtos.Tercero> EliminarTercero(int Codigo);

        public Task<List<MdloDtos.Tercero>> FiltrarTerceroPorTipo(int Codigo);
    }
}
