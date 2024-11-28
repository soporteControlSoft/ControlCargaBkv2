using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Api para generar clave unica
    /// Daniel Alejandro Lopez
    /// </summary>
    public class ClaveAleatoriaController : Controller
    {
        private readonly MdloDtos.IModelos.IGeneradoClave _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public ClaveAleatoriaController(MdloDtos.IModelos.IGeneradoClave dbContex)
        {
            _dbContex = dbContex;
        }

        #region generador de clave aleatoria
        [HttpPost("generacion-claveAleatoria")]
        public ActionResult<dynamic> generarContraseñaAleatoria([FromBody] int CantidaddigitosClave)
        {
            
            try
            {
                var ObjCadena = this._dbContex.generarContraseñaAleatoria(CantidaddigitosClave);
                if (ObjCadena != null || ObjCadena.Length>0)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObjCadena.ToString();
                }
                else
                {
                    respuesta.mensaje = MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString();
                    respuesta.datos = null;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = ex.Message;
                respuesta.datos = ex.ToString() + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta;
                return BadRequest(respuesta);
            }

            return respuesta;

        }


        #endregion
    }
}
