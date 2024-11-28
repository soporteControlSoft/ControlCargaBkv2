using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IUnidadMedida
    {
        public Task<List<MdloDtos.UnidadMedidum>> ListarUnidadMedida();

        public Task<List<MdloDtos.UnidadMedidum>> FiltrarUnidadMedidaEspecifico(String Codigo);

        public Task<List<MdloDtos.UnidadMedidum>> FiltrarUnidadMedidaGeneral(String Codigo);

        public Task<MdloDtos.UnidadMedidum> IngresarUnidadMedida(MdloDtos.UnidadMedidum ObjUnidadMedida);

        public Task<MdloDtos.UnidadMedidum> EditarUnidadMedida(MdloDtos.UnidadMedidum ObjUnidadMedida);

        public Task<MdloDtos.UnidadMedidum> EliminarUnidadMedida(String Codigo);
    }
}
