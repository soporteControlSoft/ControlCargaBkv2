using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEventos
    {
        public Task<MdloDtos.Evento> IngresarEvento(MdloDtos.Evento ObjEvento);
        public Task<List<MdloDtos.Evento>> ListarEvento( bool estado );

        public Task<MdloDtos.Evento> EditarEvento(MdloDtos.Evento ObjEvento);

        public Task<List<MdloDtos.Evento>> FiltrarEventoGeneral(String Codigo, bool estado);
        public Task<List<MdloDtos.Evento>> FiltrarEventoEspecifico(String Codigo, bool estado);
        public Task<MdloDtos.Evento> InactivarEvento(MdloDtos.Evento ObjEvento);
        public Task<bool> VerificarEvento(int Codigo);

    }
}
