using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Api para la creacion de Tipo de Identificacion
    /// Daniel Alejandro Lopez
    /// </summary>
    public class TipoIdentificacionController : Controller
    {
        private readonly MdloDtos.IModelos.ITipoIdentificacion _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public TipoIdentificacionController(MdloDtos.IModelos.ITipoIdentificacion dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionTipoIdentificacion _ValidacionTipoIdentificacion = new VldcionDtos.ValidacionTipoIdentificacion();


        #region Consultar Tipo Identificacion
        [HttpGet("listar-tipoIdentificacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.TipoIdentificacion>>> ListarTipoIdentificacion()
        {
           
            var ObTipoIdentificacion = new List<MdloDtos.TipoIdentificacion>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObTipoIdentificacion = await this._dbContex.ListarTipoIdentificacion();
                if (ObTipoIdentificacion != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObTipoIdentificacion;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObTipoIdentificacion;
                return BadRequest(respuesta);
            }

            return ObTipoIdentificacion;
        }
        #endregion

        #region Filtrar tipo Identificacion por codigo
        [HttpGet("filtrar-tipoIdentificacion-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.TipoIdentificacion>>> FiltrarTipoIdentificacionGeneral(string FiltroBusqueda)
        {
            
            var ObTipoIdentificacion = new List<MdloDtos.TipoIdentificacion>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await _ValidacionTipoIdentificacion.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObTipoIdentificacion = await this._dbContex.FiltrarTipoIdentificacionGeneral(FiltroBusqueda);
                    if (ObTipoIdentificacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTipoIdentificacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTipoIdentificacion;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObTipoIdentificacion;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObTipoIdentificacion;
                return BadRequest(respuesta);
            }

            return ObTipoIdentificacion;

        }
        #endregion

        #region Filtrar tipo Identificacion por codigo
        [HttpGet("filtrar-tipoIdentificacion-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.TipoIdentificacion>>> FiltrarTipoIdentificacionEspecifico(string CodigoBusqueda)
        {

            var ObTipoIdentificacion = new List<MdloDtos.TipoIdentificacion>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                string? Codigo = CodigoBusqueda;
                validacion = await _ValidacionTipoIdentificacion.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    
                    ObTipoIdentificacion = await this._dbContex.FiltrarTipoIdentificacionEspecifico(CodigoBusqueda);
                    if (ObTipoIdentificacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTipoIdentificacion;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTipoIdentificacion;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObTipoIdentificacion;
                }
            }
            catch (Exception ex)
            {

                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObTipoIdentificacion;
                return BadRequest(respuesta);
            }

            return ObTipoIdentificacion;

        }
        #endregion

        #region Ingresar Tipo Identificacion
        [HttpPost("ingresar-tipoIdentificacion")]
        public async Task<ActionResult<dynamic>> IngresarTipoIdentificacion([FromBody] MdloDtos.TipoIdentificacion _objTipoIdentificacion)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ValidacionTipoIdentificacion.ValidarIngreso(_objTipoIdentificacion);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObjTipoIdentificacion = await this._dbContex.IngresarTipoIdentificacion(_objTipoIdentificacion);
                    if (ObjTipoIdentificacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjTipoIdentificacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _objTipoIdentificacion;
                    }

                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objTipoIdentificacion;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _objTipoIdentificacion;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Actualizar Tipo Identificacion
        [HttpPut("actualizar-tipoIdentificacion")]
        public async Task<ActionResult<dynamic>> EditarTipoIdentificacion( [FromBody] MdloDtos.TipoIdentificacion _objTipoIdentificacion)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ValidacionTipoIdentificacion.ValidarActualizacion(_objTipoIdentificacion);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObjTipoIdentificacion = await this._dbContex.EditarTipoIdentificacion(_objTipoIdentificacion);
                    if (ObjTipoIdentificacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjTipoIdentificacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _objTipoIdentificacion;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objTipoIdentificacion;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _objTipoIdentificacion;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Eliminar Tipo de identificacion
        [HttpDelete("eliminar-tipoIdentificacion")]
        public async Task<ActionResult<dynamic>> EliminarTipoIdentificacion([FromBody] MdloDtos.TipoIdentificacion _objTipoIdentificacion)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ValidacionTipoIdentificacion.ValidarEliminar(_objTipoIdentificacion);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObTipoIdentificacion = await _dbContex.EliminarTipoIdentificacion(_objTipoIdentificacion.TiCdgo);
                    if (ObTipoIdentificacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObTipoIdentificacion;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _objTipoIdentificacion;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objTipoIdentificacion;
                }


            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = _objTipoIdentificacion;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = _objTipoIdentificacion;
                    return BadRequest(respuesta);
                }
            }

            return respuesta;
        }

        #endregion
    }
}
