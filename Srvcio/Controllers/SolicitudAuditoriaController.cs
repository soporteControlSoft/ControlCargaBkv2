using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class SolicitudAuditoriaController : Controller
    {
        private readonly MdloDtos.IModelos.ISolicitudAutorizacion _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public SolicitudAuditoriaController(MdloDtos.IModelos.ISolicitudAutorizacion dbContex)
        {
            _dbContex = dbContex;
        }
        VldcionDtos.ValidacionSolicitudAuditoria _ObjValidacionSolicitudAuditoria = new VldcionDtos.ValidacionSolicitudAuditoria();
        
        #region Ingresar Solicitud Autorizacion
        [HttpPost("ingresar-solicitudAutorizacion")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudAutorizacion([FromBody] MdloDtos.AutorizacionRemotum ObjAutorizacionRemotum)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjValidacionSolicitudAuditoria.ValidarSolicitudConfirmacion(ObjAutorizacionRemotum);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObAuditoriaModulo = await this._dbContex.IngresarSolicitudAutorizacion(ObjAutorizacionRemotum);
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
                        respuesta.datos = ObjAutorizacionRemotum;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjAutorizacionRemotum;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjAutorizacionRemotum;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion


        #region Ingresar Solicitud Confirmacion
        [HttpPost("ingresar-solicitudConfirmacion")]
        public async Task<ActionResult<dynamic>> ConfirmarSolicitudAutorizacion([FromBody] MdloDtos.AutorizacionRemotum ObjAutorizacionRemotum)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjValidacionSolicitudAuditoria.ValidarSolicitudAutorizacion(ObjAutorizacionRemotum);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObAuditoriaModulo = await this._dbContex.ConfirmarSolicitudAutorizacion(ObjAutorizacionRemotum);
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
                        respuesta.datos = ObjAutorizacionRemotum;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjAutorizacionRemotum;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjAutorizacionRemotum;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Actualizar Solicitud Autorizacion
        [HttpPut("actualizar-solicitudAutorizacion")]
        public async Task<ActionResult<dynamic>> EditarAuditoriaModulo([FromBody] MdloDtos.AutorizacionRemotum ObjAutorizacionRemotum)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjValidacionSolicitudAuditoria.ValidarActualizacion(ObjAutorizacionRemotum);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObjAuditoriaModulo = await this._dbContex.EditarSolicitudAutorizacion(ObjAutorizacionRemotum);
                    if (ObjAuditoriaModulo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjAuditoriaModulo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjAutorizacionRemotum;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjAutorizacionRemotum;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjAutorizacionRemotum;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

    }
}
