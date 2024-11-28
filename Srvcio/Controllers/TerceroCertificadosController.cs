using MdloDtos;
using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class TerceroCertificadosController : Controller
    {
        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        private readonly MdloDtos.IModelos.ICertificado _dbContex;
        public TerceroCertificadosController(MdloDtos.IModelos.ICertificado dbContex)
        {
            _dbContex = dbContex;
        }

      /*  #region Consultar  tercero certificados
        [HttpGet("listar-tercero-certificado")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwConsultaCertificado>>> ConsultarTerceroCertificado()
        {
            var ObTerceroCertificado = new List<MdloDtos.VwConsultaCertificado>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObTerceroCertificado = await this._dbContex.ConsultarTerceroCertificado();
                if (ObTerceroCertificado != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObTerceroCertificado;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObTerceroCertificado;
                return BadRequest(respuesta);
            }

            return ObTerceroCertificado;
        }
        #endregion
      */

        #region Ingresar Tercero Certificados
        [HttpPost("ingresar-tercero-certificados")]
        public async Task<ActionResult<dynamic>> IngresarCertificado([FromBody] MdloDtos.TerceroCertificado _certificado)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                // validacion = await _ObjvalidacionAuditoriamModulo.ValidarIngreso(ObjAuditoriaModulo);
                validacion = 5;
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObTerceroCertificado = await this._dbContex.IngresarCertificado(_certificado);
                    if (ObTerceroCertificado != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTerceroCertificado;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTerceroCertificado;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = "null";
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = "null";
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

    }
}
