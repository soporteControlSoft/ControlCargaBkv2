using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    [ApiController]
    /// <summary>
    ///   API para el manejo de listado de clientes
    ///   Daniel Alejandro Lopez
    /// </summary>
    public class ListadoClientesEncabezadoController : Controller
    {
        
        private readonly MdloDtos.IModelos.IListadoClientesEncabezado _dbContex;
        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public ListadoClientesEncabezadoController(MdloDtos.IModelos.IListadoClientesEncabezado dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionListadoClientes validacionListadoClientes = new VldcionDtos.ValidacionListadoClientes();

        #region Consultar Listado de Clientes Encabezador por Id de la Visita
        [HttpGet("consulta-listado-clientes-encabezado")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwListadoClientesEncabezado>>> ListarClientesEncabezado(int IdVisita)
        {

            var ObListadoClientesEncabezado = new List<MdloDtos.VwListadoClientesEncabezado>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObListadoClientesEncabezado = await this._dbContex.ListarClientesEncabezado(IdVisita);
                if (ObListadoClientesEncabezado != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObListadoClientesEncabezado;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObListadoClientesEncabezado;
                return BadRequest(respuesta);
            }
            return ObListadoClientesEncabezado;
        }
        #endregion



        #region Actualizar Listado Clientes Encabezado
        [HttpPut("actualizar-listado-clientes-encabezado")]
        public async Task<ActionResult<dynamic>> EditarEncabezadoClientes([FromBody] MdloDtos.VwListadoClientesEncabezado ObjVwListadoClientesEncabezado)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionListadoClientes.ValidarActualizacion(ObjVwListadoClientesEncabezado);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObListadoClientesEncabezado = await this._dbContex.EditarEncabezadoClientes(ObjVwListadoClientesEncabezado);
                    if (ObListadoClientesEncabezado != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListadoClientesEncabezado;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObListadoClientesEncabezado;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVwListadoClientesEncabezado;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVwListadoClientesEncabezado;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        

       

    }
}
