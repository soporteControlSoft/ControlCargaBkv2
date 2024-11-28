using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEmpaque
    {
        public Task<List<MdloDtos.Empaque>> ListarEmpaque();

        public Task<List<MdloDtos.Empaque>> FiltrarEmpaqueEspecifico(String Codigo);

        public Task<List<MdloDtos.Empaque>> FiltrarEmpaqueGeneral(String Codigo);

        public Task<MdloDtos.Empaque> IngresarEmpaque(MdloDtos.Empaque ObjEmpaque);

        public Task<MdloDtos.Empaque> EditarEmpaque(MdloDtos.Empaque ObjEmpaque);

        public Task<MdloDtos.Empaque> EliminarEmpaque(int RowId);
    }
}
