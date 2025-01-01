using AccsoDtos.AccesoSistema;
using AccsoDtos.ImplementacionRNDC;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para validar los manifiesto en el sistema RNDC
    ///   WILBERT RIVAS GRANADOS
    /// </summary>
    [ApiController]
    public class RNDCController : Controller
    {
        private readonly MdloDtos.IModelos.IRNDC _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public RNDCController(MdloDtos.IModelos.IRNDC dbContex)
        {
            _dbContex = dbContex;
        }

        #region validar un manifiesto en particular por idManifiesto y nitEmpresaTransporte
        [HttpGet("validar-manifiesto")]
        public async Task<ActionResult<IEnumerable<object>>> validarManifiesto(string idManifiesto, string nitEmpresaTransporte)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            string result = await this._dbContex.validarManifiesto(idManifiesto, nitEmpresaTransporte);
            try
            {
                if (!string.IsNullOrEmpty(result))
                {
                    switch (result)
                    {
                        case "AC": // AC: Activo, Manifiesto de carga corresponde a un viaje en proceso.
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = "ACTIVO";
                            break;

                        case "CE": // CE: Cerrado, Manifiesto de carga corresponde a un viaje terminado.
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = "CERRADO";
                            break;

                        case "AN": // AN: Anulado, Manifiesto de carga no es válido porque se anuló.
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = "ANULADO";
                            break;

                        default:
                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            respuesta.datos = result;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = $"{MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion)}, {MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion)}";
                respuesta.datos = result;
                return BadRequest(respuesta);
            }

            return Ok(respuesta);
        }
        #endregion

    }
}
