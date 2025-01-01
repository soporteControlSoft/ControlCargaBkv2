using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IEstadoHechosListas
    {

        public Task<List<MdloDtos.VwEstdoHchoLstarVstaMtnve>> ListarEstadoHechosVisitaMotonave();

        public Task<List<MdloDtos.SpListarEstadosHecho>> ListarEstadoHechosEventos(SpListarEstadosHecho spListarEstadosHecho);

        public Task<List<MdloDtos.SpListarEstadosHecho>> ListarEstadoHechosEventosZonaEspecifico(SpListarEstadosHecho spListarEstadosHecho);

        public Task<List<MdloDtos.SpListarEstadosHecho>> ListarEstadoHechosEventosZonaGeneral(SpListarEstadosHecho spListarEstadosHecho);

        public Task<List<MdloDtos.VwEstdoHchoLstarVstaMtnve>> FiltrarListarEstadoHechosVisitaMotonaveGeneral(string busqueda);
                                                         

        //Task<DateTime> ObtenerHoraSistemaAsync();

    }
}
