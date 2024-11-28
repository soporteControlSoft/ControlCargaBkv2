using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IZonaCd
    {
        public Task<List<MdloDtos.ZonaCd>> ListarZonaCd();

        public Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdPorSede(int Codigo);

        public Task<MdloDtos.ZonaCd> IngresarZonaCd(MdloDtos.ZonaCd ObjZonaCd);

        public Task<MdloDtos.ZonaCd> EditarZonaCd(MdloDtos.ZonaCd ObjZonaCd);

        public Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdEspecifico(String Codigo);

        public Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdGeneral(String Codigo);

        public Task<MdloDtos.ZonaCd> EliminarZonaCd(int Codigo);

        public Task<List<MdloDtos.ZonaCd>> cargarZonaSegunLugar(String zn);

        public Task<List<MdloDtos.ZonaCd>> cargarZonaSegunLugarBuscar(String zn, string busqueda);

    }
}
