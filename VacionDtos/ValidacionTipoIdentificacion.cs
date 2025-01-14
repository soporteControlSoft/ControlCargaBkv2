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
    /// clase para validar el tipo de identificacion.
    /// </summary>
    public  class ValidacionTipoIdentificacion
    {
        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.TipoIdentificacion _ObjTipoIdentificacion;

        public ValidacionTipoIdentificacion()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            _ObjTipoIdentificacion = new AccsoDtos.Parametrizacion.TipoIdentificacion(_mapper);
        }

        #region Validacion de tipo de identificacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.TipoIdentificacionDTO ObjTipoIdentificacion)
        {
            try
            {
                if (string.IsNullOrEmpty(ObjTipoIdentificacion.Codigo))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                var tipoIdentificacionExiste = await _ObjTipoIdentificacion.VerificarTipoIdentificacion(ObjTipoIdentificacion.Codigo);
                return tipoIdentificacionExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de tipo de identificacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.TipoIdentificacionDTO ObjTipoIdentificacion)
        {
            try
            {
                if (string.IsNullOrEmpty(ObjTipoIdentificacion.Codigo))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                var tipoIdentificacionExiste = await _ObjTipoIdentificacion.VerificarTipoIdentificacion(ObjTipoIdentificacion.Codigo);
                return tipoIdentificacionExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de tipo de identificacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.TipoIdentificacionDTO ObjTipoIdentificacion)
        {
            try
            {
                if (string.IsNullOrEmpty(ObjTipoIdentificacion.Codigo))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                var tipoIdentificacionExiste = await _ObjTipoIdentificacion.VerificarTipoIdentificacion(ObjTipoIdentificacion.Codigo);
                return tipoIdentificacionExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de TipoIdentificacion, Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            try
            {
                if (!string.IsNullOrEmpty(Busqueda))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }

                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion
    }
}
