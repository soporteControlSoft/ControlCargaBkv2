using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Crud tipo de Novedad 
    /// </summary>
    [ApiController]
    public class VisitaNovedadController : Controller
    {
        /*private readonly MdloDtos.IModelos.INovedad _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public VisitaNovedadController(MdloDtos.IModelos.INovedad dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionNovedad _objvalidacionNovedad = new VldcionDtos.ValidacionNovedad();


        #region Ingresa Novedad

        [HttpPost("ingresar-novedad")]
        public async Task<ActionResult<dynamic>> IngresarNovedad([FromBody] MdloDtos.VisitaMotonaveNovedad _Novedad)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _objvalidacionNovedad.ValidarIngreso(_Novedad);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObjNovedad = await this._dbContext.IngresarNovedad(_Novedad);
                    if (ObjNovedad != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjNovedad;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _Novedad;
                    }

                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _Novedad;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _Novedad;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Consultar todos los novedades en este momento se envia al mismo usuario hasta que se parametricen los permisos
        [HttpGet("consulta-novedad")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveNovedad>>> ListarNovedad(int IdVisita)
        {

            var ObjNovedad = new List<MdloDtos.VisitaMotonaveNovedad>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjNovedad = await this._dbContext.ListarNovedad(IdVisita);
                if (ObjNovedad != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjNovedad;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjNovedad;
                return BadRequest(respuesta);
            }

            return ObjNovedad;
        }
        #endregion*/
    }
}
