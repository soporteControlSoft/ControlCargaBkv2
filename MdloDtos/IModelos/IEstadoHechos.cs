using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEstadoHechos
    {
        public Task<MdloDtos.EstadoHecho> IngresarEstadoHecho(MdloDtos.EstadoHecho ObjEstadoHecho);
        public Task<List<MdloDtos.EstadoHecho>> ListarEstadoHecho();

        public Task<MdloDtos.EstadoHecho> EditarEstadoHecho(MdloDtos.EstadoHecho ObjEstadoHecho);

        public Task<List<MdloDtos.EstadoHecho>> FiltrarEstadoHechoGeneral(String Codigo);

        public Task<List<MdloDtos.EstadoHecho>> FiltrarEstadoHechoEspecifico(String Codigo);

        public Task<MdloDtos.EstadoHecho> ModificarEstadoEstadoHecho(MdloDtos.EstadoHecho ObjEstadoHecho);

        public Task<MdloDtos.EstadoHecho> CerrarOcancelarEstadoEstadoHecho(MdloDtos.EstadoHecho ObjEstadoHecho);

        public Task<bool> VerificarEstadoHecho(int Codigo);

    }
}
