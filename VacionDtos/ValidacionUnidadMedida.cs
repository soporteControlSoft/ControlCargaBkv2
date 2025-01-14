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
    /// Clase para Validar las Unidades Medidas
    /// </summary>
    public class ValidacionUnidadMedida
    {
        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.UnidadMedida ObjUnidadMedida;

        public ValidacionUnidadMedida()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjUnidadMedida = new AccsoDtos.Parametrizacion.UnidadMedida(_mapper);
        }


        #region Validacion de UnidadMedida , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.UnidadMedidumDTO objUnidadMedida)
        {
            try
            {
                if (string.IsNullOrEmpty(objUnidadMedida.Codigo) || string.IsNullOrEmpty(objUnidadMedida.Nombre))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                bool unidadMedidaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objUnidadMedida.Codigo);
                return unidadMedidaExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de UnidadMedida , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.UnidadMedidumDTO objUnidadMedida_)
        {
            try
            {
                if (string.IsNullOrEmpty(objUnidadMedida_.Codigo))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                bool unidadMedidaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objUnidadMedida_.Codigo);
                return unidadMedidaExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de UnidadMedida , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.UnidadMedidumDTO objUnidadMedida)
        {
            try
            {
                if (string.IsNullOrEmpty(objUnidadMedida.Codigo) ||
                    string.IsNullOrEmpty(objUnidadMedida.Nombre) ||
                    objUnidadMedida.EsGranel == null ||
                    objUnidadMedida.Activo == null)
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                bool unidadMedidaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objUnidadMedida.Codigo);
                return unidadMedidaExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de UnidadMedida Validar Busquedas ( Filtros)
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
