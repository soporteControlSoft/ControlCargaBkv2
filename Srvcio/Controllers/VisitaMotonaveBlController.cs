using MdloDtos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la creación de VisitaMotonaveBl
    ///   Wilbert Rivas Granados
    /// </summary>
    [ApiController]
    public class VisitaMotonaveBl : Controller
    {
        private readonly MdloDtos.IModelos.IVisitaMotonaveBI _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public VisitaMotonaveBl(MdloDtos.IModelos.IVisitaMotonaveBI dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionVisitaMotonaveBl validacionVisitaMotonaveBl = new VldcionDtos.ValidacionVisitaMotonaveBl();

        #region Consultar todas las VisitaMotonaveBl según filtros que recibe por parámetros
        [HttpGet("filtrar-visita-motonave-bl")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlFiltros(int? IdVisitaMotonaveBl, int? IdVisitaMotonaveDetalle, DateTime? fechaInicio, DateTime? fechaFinal)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContext.FiltrarVisitaMotonaveBlPorFiltros(IdVisitaMotonaveBl, IdVisitaMotonaveDetalle, fechaInicio, fechaFinal);
                if (ObjVisitaMotonaveBl != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    listaDatos = ObjVisitaMotonaveBl;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }
                else
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
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

        #region Consultar todas las VisitaMotonaveBl creadas
        [HttpGet("consultar-visita-motonave-bl")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> ConsultarVisitaMotonaveBlTodas()
        {
            List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjVisitaMotonaveBl = await this._dbContext.ConsultarVisitaMotonaveBl();
                if (ObjVisitaMotonaveBl != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVisitaMotonaveBl;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVisitaMotonaveBl;
                return BadRequest(respuesta);
            }

            return ObjVisitaMotonaveBl;

        }
        #endregion

        #region Consultar una VisitaMotonaveBl pasando como parámetro un IdVisitaMotonaveBl
        [HttpGet("filtrar-visita-motonave-bl-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlEspecifico(int IdVisitaMotonaveBl)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarFiltroBusquedasPorIdVisitaMotonaveBl(IdVisitaMotonaveBl);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContext.FiltrarVisitaMotonaveBlEspecifico(IdVisitaMotonaveBl);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        listaDatos = ObjVisitaMotonaveBl;
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

        #region Consultar una VisitaMotonaveBl pasando como parámetro un IdVisitaMotonaveDetalle
        [HttpGet("filtrar-visitaMotonaveBl-visitaMotonaveDetalle")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlPorVisitaMotonaveDetalle(int IdVisitaMotonaveDetalle)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarFiltroBusquedasPorIdVisitaMotonaveDetalle(IdVisitaMotonaveDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContext.FiltrarVisitaMotonaveBlPorIdVisitaMotonaveDetalle(IdVisitaMotonaveDetalle);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        listaDatos = ObjVisitaMotonaveBl;
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

        #region Consultar una VisitaMotonaveBl pasando como parámetro un IdVisitaMotonaveDetalle
        [HttpGet("filtrar-visitaMotonaveBl-visitaMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlPorVisitaMotonave(int IdVisitaMotonave)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarFiltroBusquedasPorIdVisitaMotonave(IdVisitaMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContext.FiltrarVisitaMotonaveBlPorIdVisitaMotonave(IdVisitaMotonave);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        listaDatos = ObjVisitaMotonaveBl;
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

        #region Consultar una VisitaMotonaveBl pasando como parámetro un IdVisitaMotonaveDetalle
        [HttpGet("filtrar-visitaMotonaveBl-aduanas-visitaMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlAduanasPorVisitaMotonave(int IdVisitaMotonave, string codigoUsuario)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarFiltroBusquedas(IdVisitaMotonave, codigoUsuario);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContext.FiltrarVisitaMotonaveBlAduanas(IdVisitaMotonave, codigoUsuario);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        listaDatos = ObjVisitaMotonaveBl;
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


        #region Ingresa VisitaMotonaveBl

        [HttpPost("Ingresar-visita-motonave-bl")]
        public async Task<ActionResult<dynamic>> IngresarVisitaMotonaveBl([FromBody] MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarIngreso(objVisitaMotonaveBl);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var obVisitaMotonaveBl = await this._dbContext.IngresarVisitaMotonaveBl(objVisitaMotonaveBl);
                    if (obVisitaMotonaveBl != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = obVisitaMotonaveBl;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonaveBl;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonaveBl;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonaveBl;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Actualizar una VisitaMotonaveBl pasando como parámetro un objVisitaMotonaveBl
        [HttpPut("editar-visita-motonave-bl")]
        public async Task<ActionResult<dynamic>> EditarVisitaMotonaveBl([FromBody] MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarActualizacion(objVisitaMotonaveBl);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObVisitaMotonaveBl = await this._dbContext.EditarVisitaMotonaveBl(objVisitaMotonaveBl);
                    if (ObVisitaMotonaveBl != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObVisitaMotonaveBl;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonaveBl;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonaveBl;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonaveBl;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Eliminar VisitaMotonaveBl por un código de VisitaMotonaveBl en particular
        [HttpDelete("eliminar-visita-motonave-bl-especifico")]
        public async Task<ActionResult<dynamic>> EliminarVisitaMotonaveBlEspecifico([FromBody] MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarEliminar(objVisitaMotonaveBl);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObVisitaMotonaveBl = await _dbContext.EliminarVisitaMotonaveBlEspecifico(objVisitaMotonaveBl);
                    if (ObVisitaMotonaveBl != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObVisitaMotonaveBl;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonaveBl;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonaveBl;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonaveBl;
                return BadRequest(respuesta);

            }
            return respuesta;
        }
        #endregion

        #region Eliminar todas las VisitaMotonaveBl pasando como parámetro el id de la VisitaMotonaveDetalle
        [HttpDelete("eliminar-visita-motonave-bl-visitaMotonaveDetalle")]
        public async Task<ActionResult<dynamic>> EliminarVisitaMotonaveBlPorIdVisitaMotonaveDetalle([FromBody] MdloDtos.VisitaMotonaveDetalle objVisitaMotonaveDetalle)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.       
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarEliminarPorVisitaMotonaveDetalle(objVisitaMotonaveDetalle);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObVisitaMotonaveDetalle = await _dbContext.EliminarVisitaMotonaveBlPorIdVisitaMotonaveDetalle(objVisitaMotonaveDetalle);
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
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objVisitaMotonaveDetalle;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objVisitaMotonaveDetalle;
                    return BadRequest(respuesta);
                }

            }
            return respuesta;
        }
        #endregion

        #region Actualizar Estado
        [HttpPut("actualizar-estado-bl")]
        public async Task<ActionResult<dynamic>> EditarEstadoVisitaMotonaBl([FromBody] MdloDtos.VisitaMotonaveBl _objVisitaMotonaveBl)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarActualizacionEstado(_objVisitaMotonaveBl);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObjVisitaMotonaveBl = await this._dbContext.actualizarEstadoVisitaMotonaveBl(_objVisitaMotonaveBl);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjVisitaMotonaveBl;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _objVisitaMotonaveBl;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _objVisitaMotonaveBl;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _objVisitaMotonaveBl;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Consultar una VisitaMotonaveBl pasando como parámetro un int IdVisitaMotonave, int IdTercero, string codigoProducto
        [HttpGet("filtrar-visitaMotonaveBl-deposito-creacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveBl>>> FiltrarVisitaMotonaveBlCreacionDeposito(int IdVisitaMotonave, int IdTercero, string codigoProducto)
        {
            List<MdloDtos.VisitaMotonaveBl> listaDatos = new List<MdloDtos.VisitaMotonaveBl>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionVisitaMotonaveBl.ValidarFiltroBusquedasVisitaMotonaveBl(IdVisitaMotonave,IdTercero,codigoProducto);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    List<MdloDtos.VisitaMotonaveBl> ObjVisitaMotonaveBl = await this._dbContext.FiltrarVisitaMotonaveBlDepositoCreacion(IdVisitaMotonave, IdTercero, codigoProducto);
                    if (ObjVisitaMotonaveBl != null)
                    {
                        listaDatos = ObjVisitaMotonaveBl;
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

    }
}
