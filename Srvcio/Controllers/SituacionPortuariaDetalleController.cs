using MdloDtos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la creación de SituacionPortuaria Detalle
    ///   Wilbert Rivas Granados
    /// </summary>
    [ApiController]
    public class SituacionPortuariaDetalle : Controller
    {
        private readonly MdloDtos.IModelos.ISituacionPortuariaDetalle _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public SituacionPortuariaDetalle(MdloDtos.IModelos.ISituacionPortuariaDetalle dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionSituacionPortuariaDetalle validacionSituacionPortuariaDetalle = new VldcionDtos.ValidacionSituacionPortuariaDetalle();

     

        #region Consultar todas las situacionPortuariaDetalle para una situacionPortuaria pasando como parámetro un IdSituacionPortuaria
        [HttpGet("filtrar-situacionPortuariaDetalle-situacionPortuaria")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuariaDetalle>>> FiltrarSituacionPortuariaDetallePorIdSituacionPortuaria(int IdSituacionPortuaria)
        {

            List<MdloDtos.SituacionPortuariaDetalle> ObjSituacionPortuariaDetalle = new List<MdloDtos.SituacionPortuariaDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuariaDetalle.ValidarFiltroBusquedasPorIdSituacionPortuaria(IdSituacionPortuaria);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjSituacionPortuariaDetalle = await this._dbContext.FiltrarSituacionPortuariaDetallePorIdSituacionPortuaria(IdSituacionPortuaria);
                    if (ObjSituacionPortuariaDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSituacionPortuariaDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSituacionPortuariaDetalle;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjSituacionPortuariaDetalle;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjSituacionPortuariaDetalle;
                return BadRequest(respuesta);
            }
            return ObjSituacionPortuariaDetalle;

        }
        #endregion

        #region Consultar todas las situacionPortuariaDetalle creadas
        [HttpGet("listar-situacionPortuariaDetalle")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuariaDetalle>>> ConsultarSituacionPortuariaDetalleTodas()
        {

            List<MdloDtos.SituacionPortuariaDetalle> ObjSituacionPortuariaDetalle = new List<MdloDtos.SituacionPortuariaDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjSituacionPortuariaDetalle = await this._dbContext.consultarSituacionPortuariaDetalle();
                if (ObjSituacionPortuariaDetalle != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjSituacionPortuariaDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjSituacionPortuariaDetalle;
                return BadRequest(respuesta);
            }

            return ObjSituacionPortuariaDetalle;

        }
        #endregion

        #region Consultar una situacionPortuariaDetalle pasando como parámetro un IdSituacionPortuariaDetalle
        [HttpGet("filtrar-situacionPortuariaDetalle-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuariaDetalle>>> FiltrarSituacionPortuariaDetalleEspecifico(int IdSituacionPortuariaDetalle)
        {

            List<MdloDtos.SituacionPortuariaDetalle> listaDatos = new List<MdloDtos.SituacionPortuariaDetalle>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuariaDetalle.ValidarFiltroBusquedasPorIdSituacionPortuariaDetalle(IdSituacionPortuariaDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    MdloDtos.SituacionPortuariaDetalle ObjSituacionPortuariaDetalle = await this._dbContext.FiltrarSituacionPortuariaDetalleEspecifico(IdSituacionPortuariaDetalle);
                    if (ObjSituacionPortuariaDetalle != null)
                    {
                        listaDatos.Add(ObjSituacionPortuariaDetalle);
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

        #region Ingresa situacionPortuariaDetalle

        [HttpPost("ingresar-situacionPortuariaDetalle")]
        public async Task<ActionResult<dynamic>> IngresarSituacionPortuariaDetalle([FromBody] MdloDtos.SituacionPortuariaDetalle objSituacionPortuariaDetalle)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuariaDetalle.ValidarIngreso(objSituacionPortuariaDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var obSituacionPortuariaDetalle = await this._dbContext.IngresarSituacionPortuariaDetalle(objSituacionPortuariaDetalle);
                    if (obSituacionPortuariaDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = obSituacionPortuariaDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objSituacionPortuariaDetalle;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuariaDetalle;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objSituacionPortuariaDetalle;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Actualizar una situacionPortuariaDetalle pasando como parámetro un objSituacionPortuariaDetalle
        [HttpPut("actualizar-situacionPortuariaDetalle")]
         public async Task<ActionResult<dynamic>> EditarSituacionPortuariaDetalle([FromBody] MdloDtos.SituacionPortuariaDetalle objSituacionPortuariaDetalle)
         {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuariaDetalle.ValidarActualizacion(objSituacionPortuariaDetalle);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObSituacionPortuariaDetalle = await this._dbContext.EditarSituacionPortuariaDetalle(objSituacionPortuariaDetalle);
                    if (ObSituacionPortuariaDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObSituacionPortuariaDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objSituacionPortuariaDetalle;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuariaDetalle;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objSituacionPortuariaDetalle;
                return BadRequest(respuesta);
            }

            return respuesta;
         }
        #endregion

        #region Eliminar SituacionPortuariaDetalle por un código de SituacionPortuariaDetalle en particular
        [HttpDelete("eliminar-situacionPortuariaDetalle-especifico")]
        public async Task<ActionResult<dynamic>> EliminarSituacionPortuariaEspecifico([FromBody] MdloDtos.SituacionPortuariaDetalle objSituacionPortuariaDetalle)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuariaDetalle.ValidarEliminar(objSituacionPortuariaDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObSituacionPortuariaDetalle = await _dbContext.EliminarSituacionPortuariaDetalleEspecifico(objSituacionPortuariaDetalle);
                    if (ObSituacionPortuariaDetalle != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObSituacionPortuariaDetalle;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objSituacionPortuariaDetalle;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuariaDetalle;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objSituacionPortuariaDetalle;
                return BadRequest(respuesta);

            }
            return respuesta;
        }
        #endregion

        #region Eliminar todas las situacionPortuariaDetalle pasando como parámetro el id de la situacionPortuaria
        [HttpDelete("eliminar-situacionPortuariaDetalle-situacionPortuaria")]
        public async Task<ActionResult<dynamic>> EliminarSituacionPortuariaPorIdSituacionPortuaria([FromBody] MdloDtos.SituacionPortuarium objSituacionPortuaria)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.       
            try
            {
                validacion = await validacionSituacionPortuariaDetalle.ValidarEliminarPorSituacionPortuaria(objSituacionPortuaria);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObAuditoriaModulo = await _dbContext.EliminarSituacionPortuariaDetallePorIdSituacionPortuaria(objSituacionPortuaria);
                    if (ObAuditoriaModulo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoriaModulo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objSituacionPortuaria;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuaria;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objSituacionPortuaria;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objSituacionPortuaria;
                    return BadRequest(respuesta);
                }

            }
            return respuesta;

        }
        #endregion

    
    }
}
