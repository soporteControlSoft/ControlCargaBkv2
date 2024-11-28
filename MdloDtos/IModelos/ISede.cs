using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ISede
    {
        public Task<List<MdloDtos.Sede>> ListarSede();

        public Task<List<MdloDtos.Sede>> FiltrarSedePorCompania(string Codigo);

        public Task<MdloDtos.Sede> IngresarSede(MdloDtos.Sede ObjSede);

        public Task<MdloDtos.Sede> EditarSede(MdloDtos.Sede ObjSede);

        public Task<List<MdloDtos.Sede>> FiltrarSedeGeneral(String Codigo);
        public Task<List<MdloDtos.Sede>> FiltrarSedeEspecifico(String Codigo);


        public Task<MdloDtos.Sede> EliminarSede(int Codigo);

    }
}
