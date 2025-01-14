using AccsoDtos.Mappings;
using AutoMapper;
using Azure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los periodos de facturaciones
    /// </summary>
    public class ValidacionPeriodoFacturacion
    {
        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.PeriodoFacturacion ObjPeriodoFacturacion;

        public ValidacionPeriodoFacturacion()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjPeriodoFacturacion = new AccsoDtos.Parametrizacion.PeriodoFacturacion(_mapper);
        }

        #region Validacion de PeriodoFacturacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.PeriodoFacturacionDTO objPeriodoFacturacion)
        {
            if (string.IsNullOrEmpty(objPeriodoFacturacion.Codigo) || (string.IsNullOrEmpty(objPeriodoFacturacion.Nombre)))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }
            var PeriodoFacturacionExiste = await ObjPeriodoFacturacion.VerificarPeriodoFacturacion(objPeriodoFacturacion.Codigo);
            return  PeriodoFacturacionExiste 
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste 
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        }
        #endregion

        #region Validacion de PeriodoFacturacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.PeriodoFacturacionDTO objPeriodoFacturacion_)
        {
            if (string.IsNullOrEmpty(objPeriodoFacturacion_.Codigo))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            var PeriodoFacturacionExiste = await ObjPeriodoFacturacion.VerificarPeriodoFacturacion(objPeriodoFacturacion_.Codigo);
            return  PeriodoFacturacionExiste! 
                    ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste 
                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa; 
        }
        #endregion

        #region Validacion de PeriodoFacturacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.PeriodoFacturacionDTO objPeriodoFacturacion)
        {
            if (string.IsNullOrEmpty(objPeriodoFacturacion.Codigo) || string.IsNullOrEmpty(objPeriodoFacturacion.Nombre))
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
            }

            bool periodoFacturacionExiste = await ObjPeriodoFacturacion.VerificarPeriodoFacturacion(objPeriodoFacturacion.Codigo);

            return periodoFacturacionExiste
                ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste
                : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        }
        #endregion

        #region Validacion de PeriodoFacturacion Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            return !string.IsNullOrEmpty(Busqueda)
                   ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                   : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
        }
        #endregion
    }
}
