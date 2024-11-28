using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IGrupoModelo
    {
        public Task<List<MdloDtos.GrupoTercero>> ListarGrupoTercero();

        public Task<List<MdloDtos.GrupoTercero>> FiltrarGrupoTerceroGeneral(String Codigo);

        public Task<List<MdloDtos.GrupoTercero>> FiltrarGrupoTerceroEspecifico(String Codigo);

        public Task<MdloDtos.GrupoTercero> IngresarGrupoTercero(MdloDtos.GrupoTercero ObjGrupoTercero);

        public Task<MdloDtos.GrupoTercero> EditarGrupoTercero(MdloDtos.GrupoTercero ObjGrupoTercero);

        public Task<MdloDtos.GrupoTercero> EliminarGrupoTercero(String Codigo);


    }
}
