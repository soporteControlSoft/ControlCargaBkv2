using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IZonaCd
    {
        public Task<List<MdloDtos.DTO.ZonaCdDTO>> ListarZonaCd();

        public Task<List<MdloDtos.DTO.ZonaCdDTO>> FiltrarZonaCdPorSede(int Codigo);

        public Task<dynamic> IngresarZonaCd(MdloDtos.DTO.ZonaCdDTO ObjZonaCd);

        public Task<MdloDtos.DTO.ZonaCdDTO> EditarZonaCd(MdloDtos.DTO.ZonaCdDTO ObjZonaCd);

        public Task<List<MdloDtos.DTO.ZonaCdDTO>> FiltrarZonaCdEspecifico(String Codigo);

        public Task<List<MdloDtos.DTO.ZonaCdDTO>> FiltrarZonaCdGeneral(String Codigo);

        public Task<dynamic> EliminarZonaCd(int Codigo);

        public Task<List<MdloDtos.DTO.ZonaCdDTO>> cargarZonaSegunLugar(String zn);

        public Task<List<MdloDtos.DTO.ZonaCdDTO>> cargarZonaSegunLugarBuscar(String zn, string busqueda);

    }
}
