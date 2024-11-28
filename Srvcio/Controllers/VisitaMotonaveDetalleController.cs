using MdloDtos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la creación de VisitaMotonaveDetalle
    ///   Wilbert Rivas Granados
    /// </summary>
    [ApiController]
    public class VisitaMotonaveDetalle : Controller
    {
        private readonly MdloDtos.IModelos.IVisitaMotonaveDetalle _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public VisitaMotonaveDetalle(MdloDtos.IModelos.IVisitaMotonaveDetalle dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionVisitaMotonaveDetalle validacionVisitaMotonaveDetalle = new VldcionDtos.ValidacionVisitaMotonaveDetalle();

        #region Consultar todas las VisitaMotonaveDetalle para una VisitaMotonave pasando como parámetro un IdVisitaMotonave
        [HttpGet("filtrar-visitaMotonaveDetalle-visitaMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDetalle>>> FiltrarVisitaMotonaveDetallePorIdVisitaMotonave(int IdVisitaMotonave)
        {
            List<MdloDtos.VisitaMotonaveDetalle> ObjVisitaMotonaveDetalle = new List<MdloDtos.VisitaMotonaveDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveDetalle.ValidarFiltroBusquedasPorIdVisitaMotonave(IdVisitaMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjVisitaMotonaveDetalle = await this._dbContext.FiltrarVisitaMotonaveDetallePorIdVisitaMotonave(IdVisitaMotonave);
                    if (ObjVisitaMotonaveDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonaveDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonaveDetalle;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVisitaMotonaveDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVisitaMotonaveDetalle;
                return BadRequest(respuesta);
            }
            return ObjVisitaMotonaveDetalle;

        }
        #endregion

        #region Consultar todas las VisitaMotonaveDetalle creadas
        [HttpGet("listar-VisitaMotonaveDetalle")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDetalle>>> ConsultarVisitaMotonaveDetalleTodas()
        {
            List<MdloDtos.VisitaMotonaveDetalle> ObjVisitaMotonaveDetalle = new List<MdloDtos.VisitaMotonaveDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjVisitaMotonaveDetalle = await this._dbContext.consultarVisitaMotonaveDetalle();
                if (ObjVisitaMotonaveDetalle != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVisitaMotonaveDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVisitaMotonaveDetalle;
                return BadRequest(respuesta);
            }

            return ObjVisitaMotonaveDetalle;

        }
        #endregion

        #region Consultar una VisitaMotonaveDetalle pasando como parámetro un IdVisitaMotonaveDetalle
        [HttpGet("filtrar-visitaMotonaveDetalle-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDetalle>>> FiltrarVisitaMotonaveDetalleEspecifico(int IdVisitaMotonaveDetalle)
        {
            List<MdloDtos.VisitaMotonaveDetalle> listaDatos = new List<MdloDtos.VisitaMotonaveDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveDetalle.ValidarFiltroBusquedasPorIdVisitaMotonaveDetalle(IdVisitaMotonaveDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveDetalle> ObjVisitaMotonaveDetalle = await this._dbContext.FiltrarVisitaMotonaveDetalleEspecifico(IdVisitaMotonaveDetalle);
                    if (ObjVisitaMotonaveDetalle != null)
                    {
                        listaDatos=ObjVisitaMotonaveDetalle;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }
            return listaDatos;
        }
        #endregion

        #region Actualizar una VisitaMotonaveDetalle pasando como parámetro un objVisitaMotonaveDetalle
        [HttpPut("actualizar-VisitaMotonaveDetalle")]
         public async Task<ActionResult<dynamic>> EditarVisitaMotonaveDetalle([FromBody] MdloDtos.VisitaMotonaveDetalle objVisitaMotonaveDetalle)
         {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveDetalle.ValidarActualizacion(objVisitaMotonaveDetalle);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObVisitaMotonaveDetalle = await this._dbContext.EditarVisitaMotonaveDetalle(objVisitaMotonaveDetalle);
                    if (ObVisitaMotonaveDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObVisitaMotonaveDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonaveDetalle;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonaveDetalle;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonaveDetalle;
                return BadRequest(respuesta);
            }
            return respuesta;
         }
        #endregion

        #region Eliminar VisitaMotonaveDetalle por un código de VisitaMotonaveDetalle en particular
        [HttpDelete("eliminar-VisitaMotonaveDetalle-especifico")]
        public async Task<ActionResult<dynamic>> EliminarVisitaMotonaveEspecifico([FromBody] MdloDtos.VisitaMotonaveDetalle objVisitaMotonaveDetalle)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveDetalle.ValidarEliminar(objVisitaMotonaveDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObVisitaMotonaveDetalle = await _dbContext.EliminarVisitaMotonaveDetalleEspecifico(objVisitaMotonaveDetalle);
                    if (ObVisitaMotonaveDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObVisitaMotonaveDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonaveDetalle;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonaveDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonaveDetalle;
                return BadRequest(respuesta);

            }
            return respuesta;
        }
        #endregion

        #region Eliminar todas las VisitaMotonaveDetalle pasando como parámetro el id de la VisitaMotonave
        [HttpDelete("eliminar-visitaMotonaveDetalle-visitaMotonave")]
        public async Task<ActionResult<dynamic>> EliminarVisitaMotonaveDetallePorIdVisitaMotonave([FromBody] MdloDtos.VisitaMotonave objVisitaMotonave)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.       
            try
            {
                validacion = await validacionVisitaMotonaveDetalle.ValidarEliminarPorVisitaMotonave(objVisitaMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObVisitaMotonave = await _dbContext.EliminarVisitaMotonaveDetallePorIdVisitaMotonave(objVisitaMotonave);
                    if (ObVisitaMotonave != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObVisitaMotonave;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonave;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objVisitaMotonave;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objVisitaMotonave;
                    return BadRequest(respuesta);
                }

            }
            return respuesta;
        }
        #endregion
    }
}
