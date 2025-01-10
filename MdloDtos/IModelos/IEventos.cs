using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEventos
    {
        public Task<MdloDtos.DTO.EventoDTO> IngresarEvento(MdloDtos.DTO.EventoDTO ObjEvento);
        public Task<List<MdloDtos.DTO.EventoDTO>> ListarEvento( bool estado );

        public Task<MdloDtos.DTO.EventoDTO> EditarEvento(MdloDtos.DTO.EventoDTO ObjEvento);

        public Task<List<MdloDtos.DTO.EventoDTO>> FiltrarEventoGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.DTO.EventoDTO>> FiltrarEventoEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.DTO.EventoDTO> InactivarEvento(MdloDtos.DTO.EventoDTO ObjEvento);
        public Task<bool> VerificarEvento(int Codigo);

    }
}
