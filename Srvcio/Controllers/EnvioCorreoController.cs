using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Apiu para enviar correos electronicos.
    /// Daniel Alejandro Lopez.
    /// </summary>
    public class EnvioCorreoController : Controller
    {
        private readonly MdloDtos.IModelos.IEnvioCorreo _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public EnvioCorreoController(MdloDtos.IModelos.IEnvioCorreo dbContex)
        {
            _dbContex = dbContex;
        }

        #region Envio Correo Electronico
        [HttpPost("envio-correoAutenticacion")]
        public ActionResult<dynamic> Enviar_Correo_Directo(MdloDtos.CorreoElectronico request)
        {
            var ObCorreo = this._dbContex.Enviar_Correo_Directo(request);
            try
            {
                if (ObCorreo != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObCorreo.ToString();
                }
                else
                {
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Error + " " + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString();
                    respuesta.datos = null;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = ex.Message;
                respuesta.datos = ex.ToString() + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta;
                return BadRequest(respuesta);
            }

            return respuesta;

        }


        #endregion
    }
}
