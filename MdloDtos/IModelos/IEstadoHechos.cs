using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEstadoHechos
    {
        public Task<dynamic> IngresarEstadoHecho(MdloDtos.DTO.EstadoHechoDTO ObjEstadoHecho);
        public Task<List<MdloDtos.DTO.EstadoHechoDTO>> ListarEstadoHecho();

        public Task<MdloDtos.DTO.EstadoHechoDTO> EditarEstadoHecho(MdloDtos.DTO.EstadoHechoDTO ObjEstadoHecho);

        public Task<List<MdloDtos.DTO.EstadoHechoDTO>> FiltrarEstadoHechoGeneral(String Codigo);

        public Task<List<MdloDtos.DTO.EstadoHechoDTO>> FiltrarEstadoHechoEspecifico(String Codigo);

        public Task<MdloDtos.DTO.EstadoHechoDTO> ModificarEstadoEstadoHecho(MdloDtos.DTO.EstadoHechoDTO ObjEstadoHecho);

        public Task<dynamic> CerrarOcancelarEstadoEstadoHecho(MdloDtos.DTO.EstadoHechoDTO ObjEstadoHecho);

        public Task<bool> VerificarEstadoHecho(int Codigo);
    }
}
