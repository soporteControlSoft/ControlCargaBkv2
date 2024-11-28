using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class ListadoClientesDetalleController : Controller
    {
        
        private readonly MdloDtos.IModelos.IListadoClientesDetalle _dbContex;
        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public ListadoClientesDetalleController(MdloDtos.IModelos.IListadoClientesDetalle dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionListadoClientes validacionListadoClientes = new VldcionDtos.ValidacionListadoClientes();

        #region Consultar Listado de Clientes Detalle por Id de la Visita
        [HttpGet("consulta-listado-clientes-detalle")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwListadoClientesDetalle>>> ListarClientesDetalle(int IdVisita)
        {

            var ObListadoClientesDetalle = new List<MdloDtos.VwListadoClientesDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObListadoClientesDetalle = await this._dbContex.ListarClientesDetalle(IdVisita);
                if (ObListadoClientesDetalle != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObListadoClientesDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObListadoClientesDetalle;
                return BadRequest(respuesta);
            }
            return ObListadoClientesDetalle;
        }
        #endregion

        #region Actualizar Listado Clientes detalle
        [HttpPut("actualizar-listado-clientes-detalle")]
        public async Task<ActionResult<dynamic>> EditarDetalleClientes([FromBody] MdloDtos.VwListadoClientesDetalle ObjVwListadoClientesDetalle)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionListadoClientes.ValidarActualizacionDetalle(ObjVwListadoClientesDetalle);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListadoClientesDetalle = await this._dbContex.EditarDetalleClientes(ObjVwListadoClientesDetalle);
                    if (ObListadoClientesDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListadoClientesDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVwListadoClientesDetalle;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVwListadoClientesDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVwListadoClientesDetalle;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Consultar Listado de Clientes Detalle ( Escotilla)
        [HttpGet("consulta-listado-clientes-escotilla")]
        public async Task<ActionResult<IEnumerable<string>>> ListarMotonaveEscotillas(int IdVisita)
        {

            List<string> ObListadoMotonaveEscotilla = new List<string>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObListadoMotonaveEscotilla = await this._dbContex.ListarMotonaveEscotillas(IdVisita);
                if (ObListadoMotonaveEscotilla != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObListadoMotonaveEscotilla;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObListadoMotonaveEscotilla;
                return BadRequest(respuesta);
            }
            return ObListadoMotonaveEscotilla;
        }
        #endregion

        #region Consultar Listado de Clientes Detalle(Resumen) por Id de la Visita
        [HttpGet("consulta-listado-clientes-resumen")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwResumenListadoCliente>>> ListarClientesResumen(int IdVisita)
        {

            var ObListadoClientesResumen = new List<MdloDtos.VwResumenListadoCliente>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObListadoClientesResumen = await this._dbContex.ListarClientesResumen(IdVisita);
                if (ObListadoClientesResumen != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObListadoClientesResumen;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObListadoClientesResumen;
                return BadRequest(respuesta);
            }
            return ObListadoClientesResumen;
        }
        #endregion

        #region Consultar Listado de Clientes Detalle(Grafico Torta) por Id de la Visita
        [HttpGet("consulta-listado-clientes-grafico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.WmGraficoListadoCliente>>> ListarClientesGrafico(int IdVisita)
        {

            var ObListadoClientesGrafico = new List<MdloDtos.WmGraficoListadoCliente>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObListadoClientesGrafico = await this._dbContex.ListarClientesGrafico(IdVisita);
                if (ObListadoClientesGrafico != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObListadoClientesGrafico;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObListadoClientesGrafico;
                return BadRequest(respuesta);
            }
            return ObListadoClientesGrafico;
        }
        #endregion

        #region Consultar Listado de Clientes Detalle(Barco) por Id de la Visita
        [HttpGet("consulta-listado-clientes-barco")]
        public async Task<ActionResult<IEnumerable<MdloDtos.BarcoListadoCliente>>> ListarClientesBarco(int IdVisita)
        {

            var ObListadoClientesBarco = new List<MdloDtos.BarcoListadoCliente>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObListadoClientesBarco = await this._dbContex.ListarClientesBarco(IdVisita);
                if (ObListadoClientesBarco != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObListadoClientesBarco;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObListadoClientesBarco;
                return BadRequest(respuesta);
            }
            return ObListadoClientesBarco;
        }
        #endregion
    }
}
