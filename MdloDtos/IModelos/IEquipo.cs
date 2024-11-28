using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEquipo
    {
        public Task<MdloDtos.Equipo> IngresarEquipo(MdloDtos.Equipo ObjCEquipo);
        public Task<List<MdloDtos.Equipo>> ListarEquipo(bool estado);

        public Task<MdloDtos.Equipo> EditarEquipo(MdloDtos.Equipo ObjEquipo);

        public Task<List<MdloDtos.Equipo>> FiltrarEquipoGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.Equipo>> FiltrarEquipoEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.Equipo> InactivarEquipo(MdloDtos.Equipo ObjEquipo);
        public Task<bool> VerificarEquipo(int Codigo);

    }
}
