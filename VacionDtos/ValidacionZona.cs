using AccsoDtos.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para validacion de la zona
    /// </summary>
    public  class ValidacionZona
    {
        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.ZonaCd ObjZonaCd;
        AccsoDtos.Parametrizacion.Sede ObjSede = new AccsoDtos.Parametrizacion.Sede();

        public ValidacionZona()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjZonaCd = new AccsoDtos.Parametrizacion.ZonaCd(_mapper);
        }

        #region Validacion de zonas , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.ZonaCdDTO objZonaCd)
        {
            if (string.IsNullOrEmpty(objZonaCd.Codigo) || objZonaCd.IdSede <= 0)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            var listaSede = await ObjSede.FiltrarSedeId(Convert.ToInt32(objZonaCd.IdSede));
            if (listaSede == null || listaSede.Count == 0)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
            }

            if (await ObjZonaCd.VerificarZonaCodigo(objZonaCd.Codigo))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
            }

            return ObjZonaCd.ValidacionZonaNombreIngresar(objZonaCd)
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        }
        #endregion

        #region Validacion de zonas , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.ZonaCdDTO objZonaCd)
        {
            if (objZonaCd.IdZona <= 0)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }
            var ZonaExiste = await ObjZonaCd.VerificarZonaId(objZonaCd.IdZona);
            return ZonaExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;                                
        }
        #endregion

        #region Validacion de zonas , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.ZonaCdDTO objZonaCd)
        {
            if ((string.IsNullOrEmpty(objZonaCd.Codigo)) || (objZonaCd.IdSede <= 0))
            { 
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            var ZonaExiste = await ObjZonaCd.VerificarZonaId(objZonaCd.IdZona);
            if (ZonaExiste == false)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
            }
            var SedeExiste = await ObjSede.FiltrarSedeId(Convert.ToInt32(objZonaCd.IdSede));
            if (SedeExiste == null || SedeExiste.Count == 0)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
            }
            else
            {
                var NombreExiste = ObjZonaCd.ValidacionZonaNombreActualizar(objZonaCd);
                return NombreExiste
                     ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste
                     : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
            }
        }
        #endregion

        #region Validacion de zonas,  Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            return (!string.IsNullOrEmpty(Busqueda)) 
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
        }
        #endregion

        #region Validacion de Zona, Validar Busquedas por IdSede ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdSede(int IdSede)
        {
            return (IdSede > 0) 
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
        }
        #endregion

    }
}
