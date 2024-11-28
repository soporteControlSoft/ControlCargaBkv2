using AccsoDtos.AccesoSistema;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la entidad Auditoria modulo
    ///   Daniel Alejandro Lopez
    /// </summary>
    [ApiController]
    public class AuditoriaModuloController : Controller
    {
        private readonly MdloDtos.IModelos.IAuditoriaModulo _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public AuditoriaModuloController(MdloDtos.IModelos.IAuditoriaModulo dbContex)
        {
            _dbContex = dbContex;
        }
        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionAuditoriaModulo _ObjvalidacionAuditoriamModulo = new VldcionDtos.ValidacionAuditoriaModulo();

        #region Consultar Auditoria Modulo
        [HttpGet("listar-auditoriaModulo")]
        public async Task<ActionResult<IEnumerable<MdloDtos.AuditoriaModulo>>> ListarAuditoriaModulo()
        {
            var ObAuditoriaModulo = new List<MdloDtos.AuditoriaModulo>();
            //Tipo de Operacion
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObAuditoriaModulo = await this._dbContex.ListarAuditoriaModulo();
                if (ObAuditoriaModulo != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObAuditoriaModulo;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObAuditoriaModulo;
                return BadRequest(respuesta);
            }

            return ObAuditoriaModulo;
        }
        #endregion

        #region Filtrar Auditoria Modulo por codigo general , ( Codigo o Nombre - Like Contains)
        [HttpGet("filtrar-auditoriaModulo-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.AuditoriaModulo>>> FiltrarAuditoriaModuloGeneral(string FiltroBusqueda)
        {
            var ObAuditoriaModulo = new List<MdloDtos.AuditoriaModulo>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await _ObjvalidacionAuditoriamModulo.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObAuditoriaModulo = await this._dbContex.FiltrarAuditoriaModuloGeneral(FiltroBusqueda);
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
                        respuesta.datos = ObAuditoriaModulo;
                    }
                }
                else 
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObAuditoriaModulo;
                }
                
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObAuditoriaModulo;
                return BadRequest(respuesta);
            }
            return ObAuditoriaModulo;
        }
        #endregion

        #region Filtrar Auditoria Modulo por especifico de Auditoria Modulo
        [HttpGet("filtrar-auditoriaModulo-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.AuditoriaModulo>>> FiltrarAuditoriaModuloEspecifico(string CodigoBusqueda)
        {
            var ObAuditoriaModulo = new List<MdloDtos.AuditoriaModulo>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoBusqueda;
                validacion = await _ObjvalidacionAuditoriamModulo.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObAuditoriaModulo = await this._dbContex.FiltrarAuditoriaModuloEspecifico(CodigoBusqueda);
                    if (ObAuditoriaModulo != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje =  MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoriaModulo;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoriaModulo;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObAuditoriaModulo;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObAuditoriaModulo;
                return BadRequest(respuesta);
            }
            return ObAuditoriaModulo;

        }
        #endregion

        #region Ingresar Auditoria Modulo
        [HttpPost("ingresar-auditoriaModulo")]
        public async Task<ActionResult<dynamic>> IngresarAuditoriaModulo([FromBody] MdloDtos.AuditoriaModulo ObjAuditoriaModulo)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjvalidacionAuditoriamModulo.ValidarIngreso(ObjAuditoriaModulo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) 
                {
                    var ObAuditoriaModulo = await this._dbContex.IngresarAuditoriaModulo(ObjAuditoriaModulo);
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
                        respuesta.datos = ObjAuditoriaModulo;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjAuditoriaModulo;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjAuditoriaModulo;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Actualizar Auditoria Modulo
        [HttpPut("actualizar-auditoriaModulo")]
        public async Task<ActionResult<dynamic>> EditarAuditoriaModulo([FromBody] MdloDtos.AuditoriaModulo _ObjAuditoria)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjvalidacionAuditoriamModulo.ValidarActualizacion(_ObjAuditoria);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObjAuditoriaModulo = await this._dbContex.EditarAuditoriaModulo(_ObjAuditoria);
                    if (ObjAuditoriaModulo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje =  MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjAuditoriaModulo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _ObjAuditoria;
                    }
                }
                else {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _ObjAuditoria;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = _ObjAuditoria;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Eliminar Auditoria Modulo
        [HttpDelete("eliminar-auditoriaModulo")]
        public async Task<ActionResult<dynamic>> EliminarAuditoriaModulo([FromBody] MdloDtos.AuditoriaModulo _ObjAuditoria)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                
                validacion = await _ObjvalidacionAuditoriamModulo.ValidarEliminar(_ObjAuditoria);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObAuditoriaModulo = await _dbContex.EliminarAuditoriaModulo(_ObjAuditoria.AmCdgo);
                    if (ObAuditoriaModulo != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje =MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObAuditoriaModulo;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = _ObjAuditoria;
                    }
                }
                else {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = _ObjAuditoria;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = _ObjAuditoria;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = _ObjAuditoria;
                    return BadRequest(respuesta);
                }
            }

            return respuesta;
        }

        #endregion

       
    }
}

