using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Crud Parametros
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

        #region Consultar parametros NAS
        [HttpGet("consulta-parametro-nas")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Parametro>>> ListarParametro()
        {

            var ObParametro = new List<MdloDtos.Parametro>();
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
    }
}
