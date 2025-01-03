using MdloDtos;
using Microsoft.AspNetCore.Mvc;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Wilbert Rivas Granados
    /// Fecha: 03/01/2025
    /// Crud Parametros con DTO
    /// </summary>
    [ApiController]
    public class ParametrosController : Controller
    {
        private readonly MdloDtos.IModelos.IParametros _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();


        public ParametrosController(MdloDtos.IModelos.IParametros dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionParametro validacionParametro = new VldcionDtos.ValidacionParametro();


        #region Consultar parametros NAS
        [HttpGet("consulta-parametro-nas")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ParametroDTO>>> ListarParametro()
        {
            var ObParametro = new List<MdloDtos.DTO.ParametroDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObParametro = await this._dbContex.ListarParametro();
                if (ObParametro != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObParametro;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObParametro;
                return BadRequest(respuesta);
            }

            return ObParametro;
        }
        #endregion

        #region Consultar parametros
        [HttpGet("consultar-parametros-todos")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ParametroDTO>>> ListarParametroTodos()
        {
            var ObParametro = new List<MdloDtos.DTO.ParametroDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObParametro = await this._dbContex.ListarParametro();
                if (ObParametro != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObParametro;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObParametro;
                return BadRequest(respuesta);
            }

            return ObParametro;
        }
        #endregion

        #region Actualizar parametros
        [HttpPut("actualizar-parametros")]
        public async Task<ActionResult<dynamic>> EditarParametro([FromBody] MdloDtos.DTO.ParametroDTO parametroDTO)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0;
            try
            {
                validacion = await validacionParametro.VerificarParametroExiste(parametroDTO.Id);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var Obparametro = await this._dbContex.EditarParametro(parametroDTO);
                    if (Obparametro != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = Obparametro;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = Obparametro;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = parametroDTO;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = parametroDTO;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion
    }
}
