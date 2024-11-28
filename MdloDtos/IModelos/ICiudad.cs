using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface ICiudad
    {
        public Task<List<MdloDtos.Ciudad>> ListarCiudad();

        public Task<List<MdloDtos.Ciudad>> FiltrarCiudadPorDepartamento(int Codigo);

        public Task<MdloDtos.Ciudad> IngresarCiudad(MdloDtos.Ciudad ObjCiudad);

        public Task<MdloDtos.Ciudad> EditarCiudad(MdloDtos.Ciudad ObjCiudad);

        public Task<List<MdloDtos.Ciudad>> FiltrarCiudadEspecifico(String Codigo);
        public Task<List<MdloDtos.Ciudad>> FiltrarCiudadGeneral(String Codigo);
        public Task<MdloDtos.Ciudad> EliminarCiudad(string Codigo);

    }
}
