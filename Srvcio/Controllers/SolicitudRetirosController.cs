using MdloDtos;
using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Logica de acceso a datos solicitud de retiro
    /// Daniel Alejandro lopez.
    /// </summary>
    public class SolicitudRetirosController : Controller
    {
        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        private readonly MdloDtos.IModelos.ISolicitudRetiros _dbContex;
        public SolicitudRetirosController(MdloDtos.IModelos.ISolicitudRetiros dbContex)
        {
            _dbContex = dbContex;
        }

        #region Consultar  depositos por visita y por producto
        [HttpGet("listar-deposito-combo")]
        public async Task<ActionResult<IEnumerable<MdloDtos.WvConsultaDepositosSubdeposito>>> ConsultarDepositoProducto(int Visita, string CodigoProducto)
        {
            var ObDeposito = new List<MdloDtos.WvConsultaDepositosSubdeposito>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarDepositoProducto(Visita, CodigoProducto);
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
        #region Consultar  solicitud de retiro 
        [HttpGet("listar-solicitudRetiro-combo")]
        public async Task<ActionResult<IEnumerable<MdloDtos.WmDepositosSolicitudRetiro>>> ConsultarSolicitudRetiro()
        {
            var ObDeposito = new List<MdloDtos.WmDepositosSolicitudRetiro>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiro();
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
        #region Consultar  solicitud de retiro  Final para el combo y para la lista
        [HttpGet("listar-solicitudRetiro")]
        public async Task<ActionResult<IEnumerable<MdloDtos.WmDepositosSolicitudRetiro>>> ConsultarSolicitudRetiroDeposito(int? Deposito, int idvisita, string CodigoProducto,int? SoliocitudRetiro)
        {
            var ObDeposito = new List<MdloDtos.WmDepositosSolicitudRetiro>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroDeposito( Deposito,  idvisita,  CodigoProducto, SoliocitudRetiro);
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
        #region Ingresar Solicitud de retiro
        [HttpPost("ingresar-solicitudRetiro")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetiros([FromBody] MdloDtos.SolicitudRetiro _SolicitudRetiro)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudRetiro.SrCia is not null)  &&
                     (!string.IsNullOrEmpty(_SolicitudRetiro.SrRowidDpsto.ToString())) ) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSolicitudRetiros(_SolicitudRetiro);
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
                        respuesta.datos = _SolicitudRetiro;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _SolicitudRetiro;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _SolicitudRetiro;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion
        #region cerrar Solicitud de retiro
        [HttpGet("cerrar-solicitudRetiro")]
        public async Task<ActionResult<dynamic>> CerrarSolicitudRetiros(int IdSolicitud)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((!string.IsNullOrEmpty(IdSolicitud.ToString()))) // exito

                {
                    var ObSubdeposito = await this._dbContex.CerrarSolicitudRetiro(IdSolicitud);
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
        #region Ingresar Solicitud de retiro transportadora cerrada
        [HttpPost("ingresar-trasnportadora-cerrada")]
        public async Task<ActionResult<dynamic>> IngresarTrasnportadoraCerrada([FromBody] MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiro)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
               
                var ObSubdeposito = await this._dbContex.IngresarTrasnportadoraCerrada(_SolicitudRetiro);
                if (ObSubdeposito != null)
                {
                    if (ObSubdeposito == 1)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "la cantidad supera a la la solicitud del retiro";
                        respuesta.datos = _SolicitudRetiro;

                    }
                    else {


                        if (ObSubdeposito == 2)
                        {

                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "el deposito no existe";
                            respuesta.datos = _SolicitudRetiro;

                        }
                        else
                        {

                            if (ObSubdeposito == 2)
                            {

                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "el deposito no existe";
                                respuesta.datos = _SolicitudRetiro;

                            }
                            else
                            {
                                if (ObSubdeposito == 3)
                                {

                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = "la solicitud de retiro no es cerrada";
                                    respuesta.datos = _SolicitudRetiro;

                                }
                                else
                                {
                                    if (ObSubdeposito == 4)
                                    {

                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = "ya existe una trasnportadora para esa solicitud.";
                                        respuesta.datos = _SolicitudRetiro;

                                    }
                                    else
                                    {
                                        if (ObSubdeposito == 5)
                                        {

                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                            respuesta.mensaje = "solicitud de retiro no existe.";
                                            respuesta.datos = _SolicitudRetiro;

                                        }
                                        else
                                        {
                                            if (ObSubdeposito == 6)
                                            {

                                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                                respuesta.mensaje = "error en la transaccion";
                                                respuesta.datos = _SolicitudRetiro;

                                            }
                                            else
                                            {
                                                if (ObSubdeposito == 7)
                                                {

                                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                                                    respuesta.mensaje = "exito en el ingreso de la solicitud";
                                                    respuesta.datos = _SolicitudRetiro;

                                                }

                                            }

                                        }

                                    }

                                }

                            }

                        }
                    }
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
        #region Ingresar Solicitud de retiro transportadora abierta
        [HttpPost("ingresar-trasnportadora-abierta")]
        public async Task<ActionResult<dynamic>> IngresarTrasnportadoraAbierta([FromBody] MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                var ObSubdeposito = await this._dbContex.IngresarTrasnportadoraAbierta(_SolicitudRetiroTransportadora);
                if (ObSubdeposito != null)
                {
                    if (ObSubdeposito == 4)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = "exito en el ingreso";
                        respuesta.datos = _SolicitudRetiroTransportadora;
                    }
                    else
                    {

                        //kilos y unidades son superiores al del deposito.
                        if (ObSubdeposito == 2)
                        {
                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "Kilos y Unidades Superior al permitido en el deposito";
                            respuesta.datos = _SolicitudRetiroTransportadora;
                        }
                        else
                        {

                            //id de la solicitud no existe 
                            if (ObSubdeposito == 1)
                            {
                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "Solicitud de retiro no existe";
                                respuesta.datos = _SolicitudRetiroTransportadora;
                            }
                            else
                            {
                                if (ObSubdeposito == 5)
                                {
                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = "Solitud de retiro no es abierta";
                                    respuesta.datos = _SolicitudRetiroTransportadora;
                                }
                                else
                                {
                                    if (ObSubdeposito == 6)
                                    {
                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = "ya existe una solicitud de retiro relacionado con esa trasnportadora";
                                        respuesta.datos = _SolicitudRetiroTransportadora;
                                    }
                                    else
                                    {
                                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                        respuesta.datos = _SolicitudRetiroTransportadora;
                                    }
                                }

                            }
                        }
                    }
                }
                    
            }
            catch (Exception ex)
            {
                //Error en la transaccion.
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = "null";
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion
        #region Ingresar Solicitud de retiro autorizacion cerrada 
        [HttpPost("ingresar-solicitudRetiro-autorizacion-cerrada")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetirosAutorizacionCerrada([FromBody] MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                var ObSubdeposito = await this._dbContex.IngresarSolicitudRetirosAutorizacionCerrada(_SolicitudAutorizacion);
                if (ObSubdeposito != null)
                {
                    //cantidad es mayo a la solicitud de la trasnportadora
                    if (ObSubdeposito == 6)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "cantidad a autorizar es mayor a la registrado en la solicitud de la trasnportadora";
                        respuesta.datos = _SolicitudAutorizacion;
                    }
                    else
                    {

                        if (ObSubdeposito == 1)
                        {

                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "kilos y unidades mayores que la solicitud de retiro.";
                            respuesta.datos = _SolicitudAutorizacion;
                        }
                        else
                        {

                            if (ObSubdeposito == 2)
                            {

                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "la solicitud no es cerrada";
                                respuesta.datos = _SolicitudAutorizacion;
                            }
                            else
                            {
                                if (ObSubdeposito == 3)
                                {

                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = "solicitud de retiro no existe";
                                    respuesta.datos = _SolicitudAutorizacion;
                                }
                                else
                                {
                                    if (ObSubdeposito == 4)
                                    {
                                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                        respuesta.datos = _SolicitudAutorizacion;
                                    }
                                    else
                                    {
                                        if (ObSubdeposito == 5)
                                        {

                                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                                            respuesta.mensaje = "ingreso exitoso";
                                            respuesta.datos = _SolicitudAutorizacion;
                                        }
                                        else
                                        {

                                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                            respuesta.datos = _SolicitudAutorizacion;

                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _SolicitudAutorizacion;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion
        #region actualizar Solicitud de retiro
        [HttpPut("actualizar-solicitudRetiro")]
        public async Task<ActionResult<dynamic>> EditarSolicitudRetiro([FromBody] MdloDtos.SolicitudRetiro _SolicitudRetiro)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                var ObSubdeposito = await this._dbContex.EditarSolicitudRetiro(_SolicitudRetiro);
                if (ObSubdeposito != null)
                {
                    if (ObSubdeposito == 1)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = "las cantidades y killos son mayores a las registradas en el deposito";
                        respuesta.datos = _SolicitudRetiro;
                    }
                    else {

                        if (ObSubdeposito == 2)
                        {

                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "deposito no existe";
                            respuesta.datos = _SolicitudRetiro;
                        }
                        else
                        {
                            if (ObSubdeposito == 3)
                            {

                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "solicitud de retiro no existe";
                                respuesta.datos = _SolicitudRetiro;
                            }
                            else
                            {

                                if (ObSubdeposito == 4)
                                {
                                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                    respuesta.datos = _SolicitudRetiro;
                                }
                                else
                                {
                                    if (ObSubdeposito == 5)
                                    {
                                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                                        respuesta.mensaje = "se actualizo la solcitud de retiro";
                                        respuesta.datos = _SolicitudRetiro;
                                    }
                                    else {

                                        if (ObSubdeposito == 6)
                                        {
                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                            respuesta.mensaje = "ya existen cantidades y kilos autorizados superiores a esta cantidad";
                                            respuesta.datos = _SolicitudRetiro;
                                        }
                                    }

                                }
                            }

                        }
                    }
                   
                }
                else
                {
                    //Error en la transaccion.
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _SolicitudRetiro;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _SolicitudRetiro;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion
        #region Ingresar Solicitud de retiro autorizacion abierta
        [HttpPost("ingresar-solicitudRetiro-autorizacion-abierta")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetirosAutorizacionAbierta([FromBody] MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudAutorizacion.SraRowidSlctudRtro > 0) ) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSolicitudRetirosAutorizacionAbierta(_SolicitudAutorizacion);
                    if (ObSubdeposito != null)
                    {
                        if (ObSubdeposito == 1)
                        {

                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                            respuesta.mensaje = "unidades y kilos superan a las del deposito";
                            respuesta.datos = _SolicitudAutorizacion;
                        }
                        else {

                            if (ObSubdeposito == 2)
                            {

                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                respuesta.mensaje = "deposito no existe";
                                respuesta.datos = _SolicitudAutorizacion;
                            }
                            else
                            {
                                if (ObSubdeposito == 3)
                                {

                                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                    respuesta.mensaje = "la solicitud no es abierta";
                                    respuesta.datos = _SolicitudAutorizacion;
                                }
                                else
                                {
                                    if (ObSubdeposito == 4)
                                    {

                                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                        respuesta.mensaje = "la solicitdu no existe";
                                        respuesta.datos = _SolicitudAutorizacion;
                                    }
                                    else
                                    {
                                        if (ObSubdeposito == 5)
                                        {

                                            validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                                            respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                                            respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                                            respuesta.datos = _SolicitudAutorizacion;
                                        }
                                        else
                                        {
                                            if (ObSubdeposito == 6)
                                            {

                                                validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                                                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                                                respuesta.mensaje = "ingreso exitoso de la solicitud de autorización";
                                                respuesta.datos = _SolicitudAutorizacion;
                                            }

                                        }

                                    }

                                }

                            }
                        }
                    }
                    else
                    {
                        //Error en la transaccion.
                       
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = "solicitud obligatoria";
                    respuesta.datos = _SolicitudAutorizacion;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _SolicitudAutorizacion;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion
        #region Ingresar Solicitud de retiro transportadora
        [HttpPost("ingresar-solicitudRetiro-trasnportadora")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetiroTrasnportadora([FromBody] MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudRetiroTransportadora.SrtRowidSlctudRtro > 0) && (_SolicitudRetiroTransportadora.SrtRowidTrnsprtdra > 0) &&
                     (!string.IsNullOrEmpty(_SolicitudRetiroTransportadora.SrtAutrzdoKlos.ToString())) && (!string.IsNullOrEmpty(_SolicitudRetiroTransportadora.SrtDspchdoKlos.ToString()))
                     && (!string.IsNullOrEmpty(_SolicitudRetiroTransportadora.SrtAutrzdoUnddes.ToString())) && (_SolicitudRetiroTransportadora.SrtDspchdoUnddes is not null) && (_SolicitudRetiroTransportadora.SrtActva is not null)) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSolicitudRetiroTrasnportadora(_SolicitudRetiroTransportadora);
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
        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Trasnportadora.
        [HttpGet("listar-solicitudRetiro-trasnportadora-IdRetiroTrasnportadora")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SolicitudRetiroTransportadora>>> ConsultarSolicitudRetiroTrasnportadoraIdRetiro(int IdSolicitudRetiroTrasnportadora)
        {
            var ObDeposito = new List<MdloDtos.SolicitudRetiroTransportadora>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroTrasnportadoraIdRetiro(IdSolicitudRetiroTrasnportadora);
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
        #region Consultar solicitud de retiros Trasnportadora  por ID retiros
        [HttpGet("listar-solicitudRetiro-trasnportadora-IdRetiro")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SolicitudRetiroTransportadora>>> ConsultarSolicitudRetiroIdRetiroTrasnportadora(int IdSolicitudRetiro)
        {
            var ObDeposito = new List<MdloDtos.SolicitudRetiroTransportadora>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroIdRetiroTrasnportadora(IdSolicitudRetiro);
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
        #region  Consultar solicitud de retiros autorizacion por ID retiros.
        [HttpGet("listar-solicitudRetiroAutorizacion-IdRetiro")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SolicitudRetiroAutorizacion>>> ConsultarSolicitudRetiroAutorizacionIdRetiro(int IdRetiro)
        {
            var ObDeposito = new List<MdloDtos.SolicitudRetiroAutorizacion>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroAutorizacionIdRetiro(IdRetiro);
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
        #region Consultar  solicitud de retiro Autorizacion por Id Retiros Autorizacion
        [HttpGet("listar-solicitudRetiroAutorizacion-IdRetirosAutorizacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SolicitudRetiroAutorizacion>>> ConsultarSolicitudRetiroAutorizacionIdRetiroAutorizacion(int IdSolicitudRetiroAutorizacion)
        {
            var ObDeposito = new List<MdloDtos.SolicitudRetiroAutorizacion>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroAutorizacionIdRetiroAutorizacion(IdSolicitudRetiroAutorizacion);
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









        //no utilizar , se cambiaron en la nueva version.
        #region Actualizar Solicitud de retiro transportadora
        [HttpPut("actualizar-solicitudRetiro-trasnportadora")]
        public async Task<ActionResult<dynamic>> ActualizarSolicitudRetiroTrasnportadora([FromBody] MdloDtos.SolicitudRetiroTransportadora _SolicitudRetiroTransportadora)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudRetiroTransportadora.SrtRowidSlctudRtro > 0) && (_SolicitudRetiroTransportadora.SrtRowidTrnsprtdra > 0) &&
                     (!string.IsNullOrEmpty(_SolicitudRetiroTransportadora.SrtAutrzdoKlos.ToString())) && (!string.IsNullOrEmpty(_SolicitudRetiroTransportadora.SrtDspchdoKlos.ToString()))
                     && (!string.IsNullOrEmpty(_SolicitudRetiroTransportadora.SrtAutrzdoUnddes.ToString())) && (_SolicitudRetiroTransportadora.SrtDspchdoUnddes is not null) && (_SolicitudRetiroTransportadora.SrtActva is not null)) // exito

                {
                    var ObSubdeposito = await this._dbContex.ActualizarSolicitudRetiroTrasnportadora(_SolicitudRetiroTransportadora);
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
        #region Ingresar Solicitud de retiro transportadora Historial
        [HttpPost("ingresar-solicitudRetiro-trasnportadora.historial")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetirosTrasnsportadoraHistorico([FromBody] MdloDtos.SolicitudRetiroTransportadoraHistorial _SolicitudRetiroTransportadoraHistorial)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudRetiroTransportadoraHistorial.SrthAutrzdoKlos > 0) && (_SolicitudRetiroTransportadoraHistorial.SrthRowidSlctudRtroTrnsprtdra > 0) &&
                     (!string.IsNullOrEmpty(_SolicitudRetiroTransportadoraHistorial.SrthFcha.ToString())) && (!string.IsNullOrEmpty(_SolicitudRetiroTransportadoraHistorial.SrthAutrzdoUnddes.ToString()))
                    ) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSolicitudRetirosTrasnsportadoraHistorico(_SolicitudRetiroTransportadoraHistorial);
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
        #region Ingresar Solicitud de retiro autorizacion Historial 
        [HttpPost("ingresar-solicitudRetiro-autorizacion-historial")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetirosAutorizacionHistorial([FromBody] MdloDtos.SolicitudRetiroAutorizacionHistorial _SolicitudAutorizacionHistorial)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudAutorizacionHistorial.SrahRowidSlctudRtroAutrzcion > 0) && (_SolicitudAutorizacionHistorial.SrahAutrzdoKlos > 0) &&
                     (!string.IsNullOrEmpty(_SolicitudAutorizacionHistorial.SrahAutrzdoKlos.ToString())) && (!string.IsNullOrEmpty(_SolicitudAutorizacionHistorial.SrahAutrzdoUnddes.ToString()))
                     && (!string.IsNullOrEmpty(_SolicitudAutorizacionHistorial.SrahFcha.ToString())) && (_SolicitudAutorizacionHistorial.SraCdgoUsrio is not null)) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSolicitudAutorizacionHistorial(_SolicitudAutorizacionHistorial);
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
        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Autorizacion.
        [HttpGet("listar-solicitudRetiro-Trasmportadora-historia-IdRetiro")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SolicitudRetiroTransportadoraHistorial>>> ConsultarSolicitudRetiroTrasnportadoraHistorialIdRetiro(int IdSolicitudRetiroTrasnportadora)
        {
            var ObDeposito = new List<MdloDtos.SolicitudRetiroTransportadoraHistorial>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroTrasnportadoraHistorialIdRetiro(IdSolicitudRetiroTrasnportadora);
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

    }
}
