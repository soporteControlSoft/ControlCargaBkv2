using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// </summary>
    public class SubDepositoController : Controller
    {
        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        private readonly MdloDtos.IModelos.ISubdepositos _dbContex;
        public SubDepositoController(MdloDtos.IModelos.ISubdepositos dbContex)
        {
            _dbContex = dbContex;
        }

        #region Consultar  depositos por visita y por producto
        [HttpGet("listar-deposito-subdeposito")]
        public async Task<ActionResult<IEnumerable<MdloDtos.WvConsultaDepositosSubdeposito>>> ConsultarDepositosSegunSubDeposito(int Visita, string CodigoProducto, string codigoUsuario)
        {
            var ObDeposito = new List<MdloDtos.WvConsultaDepositosSubdeposito>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarDepositosSegunSubDeposito(Visita, CodigoProducto, codigoUsuario);
                if (ObDeposito != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObDeposito;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObDeposito;
                return BadRequest(respuesta);
            }

            return ObDeposito;
        }
        #endregion


        #region Consultar  depositos por visita y por producto
        [HttpGet("listar-producto-subdeposito")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwConsultarProductosSubdeposito>>> ConsultarProductoSubDeposito(int idvisita)
        {
            var ObDeposito = new List<MdloDtos.VwConsultarProductosSubdeposito>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarProductoSubDeposito(idvisita);
                if (ObDeposito != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObDeposito;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObDeposito;
                return BadRequest(respuesta);
            }

            return ObDeposito;
        }
        #endregion


        #region Consultar  sub depositos por deposito
        [HttpGet("listar-subdeposito-deposito")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwConsultarSubdeposito>>> ConsultarSubDeposito(string codigoDepositoPadre)
        {
            var ObDeposito = new List<MdloDtos.VwConsultarSubdeposito>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSubDeposito(codigoDepositoPadre);
                if (ObDeposito != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObDeposito;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObDeposito;
                return BadRequest(respuesta);
            }

            return ObDeposito;
        }
        #endregion

        #region Ingresar Sub deposito
        [HttpPost("ingresar-subdeposito")]
        public async Task<ActionResult<dynamic>> IngresarSubDeposito([FromBody] MdloDtos.Deposito Objsubdeposito)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((Objsubdeposito.DeCia is not null) && (Objsubdeposito.DeCntdad is not null) &&
                     (Objsubdeposito.DeKlos is not null) && (Objsubdeposito.DeRowidTrcro is not null) &&
                     (Objsubdeposito.DeCdgoDpstoPdre is not null) && (Objsubdeposito.DeCdgoPrdcto is not null)) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSubDeposito(Objsubdeposito);
                    if (ObSubdeposito != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObSubdeposito;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObSubdeposito;
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
