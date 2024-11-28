using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class AuditoriaController : Controller
    {
        private readonly MdloDtos.IModelos.IAuditoria _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public AuditoriaController(MdloDtos.IModelos.IAuditoria dbContex)
        {
            _dbContex = dbContex;
        }

        #region Ingresar Auditoria
        [HttpPost("ingresar-auditoria")]
        public async Task<ActionResult<dynamic>> IngresarAuditoria([FromBody] MdloDtos.Auditorium ObjAuditoriaAuditorium)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                    var ObAuditoria= await this._dbContex.IngresarAuditoria(ObjAuditoriaAuditorium);
                    if (ObAuditoria != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoria;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoria;
                    }
                
                

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjAuditoriaAuditorium;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion





    }
}
