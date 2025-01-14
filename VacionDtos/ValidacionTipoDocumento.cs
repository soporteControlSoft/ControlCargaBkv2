using AccsoDtos.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Wilbert Rivas Granados
    /// Validar el crud del tipo de documento 
    /// </summary>
    public class ValidacionTipoDocumento
    {
        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.TipoDocumento _TipoDocumento;

        public ValidacionTipoDocumento()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            _TipoDocumento = new AccsoDtos.Parametrizacion.TipoDocumento(_mapper);
        }


        #region Validacion de vehiculos , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento)
        {
            if (string.IsNullOrEmpty(ObjTipoDocumento.IdTipoDocumento) ||
                string.IsNullOrEmpty(ObjTipoDocumento.Nombre) ||
                string.IsNullOrEmpty(ObjTipoDocumento.Origen) ||
                string.IsNullOrEmpty(ObjTipoDocumento.Asignar))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            bool vehiculoExiste = await _TipoDocumento.VerificarTipoDocumento(ObjTipoDocumento.IdTipoDocumento);
            return vehiculoExiste
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        }
        #endregion

        #region Validacion de Tipo Documento , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento)
        {
            if (string.IsNullOrEmpty(ObjTipoDocumento.IdTipoDocumento))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            bool vehiculoExiste = await _TipoDocumento.VerificarTipoDocumento(ObjTipoDocumento.IdTipoDocumento);
            return vehiculoExiste
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
        }
        #endregion

        #region Validacion de Tipo Vehiculo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento)
        {
            if (!SonCamposValidos(ObjTipoDocumento))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            try
            {
                bool vehiculoExiste = await _TipoDocumento.VerificarTipoDocumento(ObjTipoDocumento.IdTipoDocumento);
                return vehiculoExiste
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
            }
            catch (Exception)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        private bool SonCamposValidos(MdloDtos.DTO.TipoDocumentoDTO objTipoDocumento)
        {
            return !string.IsNullOrEmpty(objTipoDocumento.IdTipoDocumento) &&
                   !string.IsNullOrEmpty(objTipoDocumento.Nombre) &&
                   !string.IsNullOrEmpty(objTipoDocumento.Origen) &&
                   !string.IsNullOrEmpty(objTipoDocumento.Asignar);
        }
        #endregion

        #region Validacion de TipoDocumento,  Validar Filtros
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            return  string.IsNullOrEmpty(Busqueda)
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        }
        #endregion
    }
}
