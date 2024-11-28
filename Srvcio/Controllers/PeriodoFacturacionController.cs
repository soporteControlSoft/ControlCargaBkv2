using MdloDtos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using VldcionDtos;


namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la creación de periodo de facturacion
    ///   Wilbert Rivas Granados
    ///   Ajuste Daniel Lopez
    /// </summary>
    [ApiController]
    public class PeriodoFacturacionController : Controller
    {
        private readonly MdloDtos.IModelos.IPeriodoFacturacion _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public PeriodoFacturacionController(MdloDtos.IModelos.IPeriodoFacturacion dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionPeriodoFacturacion validacionPeriodoFacturacion = new VldcionDtos.ValidacionPeriodoFacturacion();


        #region Consultar todos los Periodo Facturacion
        [HttpGet("listar-periodoFacturacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PeriodoFacturacion>>> ListarPeriodoFacturacion()
        { 
            var ObjPeriodoFacturacion = new List<MdloDtos.PeriodoFacturacion>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjPeriodoFacturacion = await this._dbContext.ListarPeriodoFacturacion();
                if (ObjPeriodoFacturacion != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjPeriodoFacturacion;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjPeriodoFacturacion;
                return BadRequest(respuesta);
            }

            return ObjPeriodoFacturacion;
        }
        #endregion

        #region Filtrar Periodo Facturacion por codigo general
        [HttpGet("filtrar-periodoFacturacion-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PeriodoFacturacion>>> FiltrarPeriodoFacturacionGeneral(string FiltroBusqueda)
        {  
            var ObjPeriodoFacturacion = new List<MdloDtos.PeriodoFacturacion>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await validacionPeriodoFacturacion.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjPeriodoFacturacion = await this._dbContext.FiltrarPeriodoFacturacionGeneral(FiltroBusqueda);
                    if (ObjPeriodoFacturacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjPeriodoFacturacion;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjPeriodoFacturacion;
                return BadRequest(respuesta);
            }
            return ObjPeriodoFacturacion;  
        }
        #endregion

        #region Filtrar Periodo Facturacion por codigo especifico
        [HttpGet("filtrar-periodoFacturacion-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PeriodoFacturacion>>> FiltrarPeriodoFacturacionEspecifico( string CodigoPeriodoFacturacion)
        {
            
            var ObjPeriodoFacturacion = new List<MdloDtos.PeriodoFacturacion>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoPeriodoFacturacion;
                validacion = await validacionPeriodoFacturacion.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjPeriodoFacturacion = await this._dbContext.FiltrarPeriodoFacturacionEspecifico(CodigoPeriodoFacturacion);
                    if (ObjPeriodoFacturacion != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjPeriodoFacturacion;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjPeriodoFacturacion;
                return BadRequest(respuesta);
            }

            return ObjPeriodoFacturacion;
        }
        #endregion

        #region Ingresa Periodo Facturacion

        [HttpPost("ingresar-periodoFacturacion")]
        public async Task<ActionResult<dynamic>> IngresarPeriodoFacturacion([FromBody] MdloDtos.PeriodoFacturacion ObjPeriodoFacturacion)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionPeriodoFacturacion.ValidarIngreso(ObjPeriodoFacturacion);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObAuditoriaModulo = await this._dbContext.IngresarPeriodoFacturacion(ObjPeriodoFacturacion);
                    if (ObAuditoriaModulo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoriaModulo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjPeriodoFacturacion;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjPeriodoFacturacion;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Actualizar Periodo Facturacion
        [HttpPut("actualizar-periodoFacturacion")]
        public async Task<ActionResult<dynamic>> EditarPeriodoFacturacion([FromBody] MdloDtos.PeriodoFacturacion ObjPeriodoFacturacion)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionPeriodoFacturacion.ValidarActualizacion(ObjPeriodoFacturacion);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObPeriodoFacturacion = await this._dbContext.EditarPeriodoFacturacion(ObjPeriodoFacturacion);
                    if (ObPeriodoFacturacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPeriodoFacturacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjPeriodoFacturacion;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjPeriodoFacturacion;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Eliminar Periodo Facturacion por codigo 
        [HttpDelete("eliminar-periodoFacturacion")]
        public async Task<ActionResult<dynamic>> EliminarPeriodoFacturacion([FromBody] MdloDtos.PeriodoFacturacion ObjPeriodoFacturacion)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionPeriodoFacturacion.ValidarEliminar(ObjPeriodoFacturacion);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObPeriodoFacturacion = await _dbContext.EliminarPeriodoFacturacion(ObjPeriodoFacturacion.PfCdgo);
                    if (ObPeriodoFacturacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPeriodoFacturacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjPeriodoFacturacion;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjPeriodoFacturacion;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = ObjPeriodoFacturacion;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = ObjPeriodoFacturacion;
                    return BadRequest(respuesta);
                }

            }
            return respuesta;
        }
        #endregion
    }
}
