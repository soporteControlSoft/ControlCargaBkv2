using MdloDtos;
using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
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


        #region Consultar  solicitud de retiro 
        [HttpGet("listar-solicitudRetiro")]
        public async Task<ActionResult<IEnumerable<MdloDtos.WmDepositosSolicitudRetiro>>> ConsultarSolicitudRetiroDeposito(int Deposito, int idvisita, string CodigoProducto,int? SoliocitudRetiro)
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

                if ((_SolicitudRetiro.SrCia is not null) && (_SolicitudRetiro.SrCdgo is not null) &&
                     (!string.IsNullOrEmpty(_SolicitudRetiro.SrRowidDpsto.ToString())) && (_SolicitudRetiro.SrAutrzdoCntdad is not null) ) // exito

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


        #region Ingresar Solicitud de retiro autorizacion
        [HttpPost("ingresar-solicitudRetiro-autorizacion")]
        public async Task<ActionResult<dynamic>> IngresarSolicitudRetirosAutorizacion([FromBody] MdloDtos.SolicitudRetiroAutorizacion _SolicitudAutorizacion)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                if ((_SolicitudAutorizacion.SraRowidSlctudRtro >0) && (_SolicitudAutorizacion.SraRowidTrnsprtdra >0) &&
                     (!string.IsNullOrEmpty(_SolicitudAutorizacion.SraAutrzdoKlos.ToString())) && (!string.IsNullOrEmpty(_SolicitudAutorizacion.SraAutrzdoUnddes.ToString()))
                     && (!string.IsNullOrEmpty(_SolicitudAutorizacion.SraFcha.ToString())) && (_SolicitudAutorizacion.SraCdgoUsrio is not null)) // exito

                {
                    var ObSubdeposito = await this._dbContex.IngresarSolicitudRetirosAutorizacion(_SolicitudAutorizacion);
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


        #region Ingresar Solicitud de retiro autorizacion
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


        #region Ingresar Solicitud de retiro transportadora
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

        #region Consultar  solicitud de retiro Autorizacion Historial por Id Retiros Autorizacion
        [HttpGet("listar-solicitudRetiroAutorizacion-historial-IdRetirosAutorizacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SolicitudRetiroAutorizacionHistorial>>> ConsultarSolicitudRetiroAutorizacionHistorialIdRetiro(int IdSolicitudRetiroAutorizacion)
        {
            var ObDeposito = new List<MdloDtos.SolicitudRetiroAutorizacionHistorial>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObDeposito = await this._dbContex.ConsultarSolicitudRetiroAutorizacionHistorialIdRetiro(IdSolicitudRetiroAutorizacion);
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

        #region Consultar solicitud de retiros Trasnportadora  por ID retiros Autorizacion.
        [HttpGet("listar-solicitudRetiro-trasmportadora-IdRetiro")]
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
