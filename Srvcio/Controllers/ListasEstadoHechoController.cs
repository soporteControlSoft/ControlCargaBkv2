using AccsoDtos.AccesoSistema;
using MdloDtos;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using VldcionDtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para las Clasificaciones
    ///   Jesus Al berto Calzada
    /// </summary>
    [ApiController]
    public class LidtaasEstadoHecosController : Controller
    {
        private readonly MdloDtos.IModelos.IEstadoHechosListas _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public LidtaasEstadoHecosController(MdloDtos.IModelos.IEstadoHechosListas dbContex)
        {
            _dbContex = dbContex;
        }


        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionClasificacion validacionCLasificacion = new VldcionDtos.ValidacionClasificacion();

        #region Consultar lista estado de hechos motonave
        [HttpGet("listar-MotonaveVisitaEstadoHcho")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ListadoEstadoHechosDTO>>> ListarMotonaveVisitaEstadoHecho()
        {
           
            var ObjVisitaMotonave  = new List<MdloDtos.DTO.ListadoEstadoHechosDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjVisitaMotonave = await this._dbContex.ListarEstadoHechosVisitaMotonave();
                if (ObjVisitaMotonave != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjVisitaMotonave;
                return BadRequest(respuesta);
            }

            return ObjVisitaMotonave;
        }
        #endregion

        #region Consultar Hora del Sistema
        [HttpGet("obtener-hora-sistema")]
        public async Task<ActionResult<string>> ObtenerHoraSistemaAsync()
        {
            // Iniciamos las variables necesarias para manejar la respuesta y la validación
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

            try
            {
                // Obtener la hora del sistema de manera asincrónica
                DateTime horaSistema = await Task.Run(() => DateTime.Now);

                // Si la operación es exitosa
                validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = horaSistema.ToString("yyyy-MM-dd HH:mm:ss");  // Devolvemos la fecha en formato string

                // Retornar la respuesta exitosa con la hora del sistema
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                // Si ocurre un error
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = null;

                // Retornar la respuesta de error
                return BadRequest(respuesta);
            }
        }
        #endregion

        VldcionDtos.ValidacionEstadoHecho validacionEstadoHecho = new VldcionDtos.ValidacionEstadoHecho();

        #region Consultar eventos de un estado de hechos segun su estado
        [HttpPost("estadoHecho-estado-eventos")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpListarEstadosHecho>>> FiltrarEstadoHechoEspecifico(SpListarEstadosHecho objSpListarEstadosHecho)
        {
            var ObjSpListarEstadosHecho = new List<MdloDtos.SpListarEstadosHecho>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionEstadoHecho.ValidarCamposEventosEstadoHecho(objSpListarEstadosHecho.eh_estdo, objSpListarEstadosHecho.eh_rowid_vsta_mtnve);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {

                    ObjSpListarEstadosHecho = await this._dbContex.ListarEstadoHechosEventos(objSpListarEstadosHecho) ;
                    if (ObjSpListarEstadosHecho != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSpListarEstadosHecho;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSpListarEstadosHecho;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjSpListarEstadosHecho;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjSpListarEstadosHecho;
                return BadRequest(respuesta);
            }
            return ObjSpListarEstadosHecho;

        }
        #endregion

        #region Consultar eventos de un estado de hechos especifico
        [HttpPost("estadoHecho-estado-eventos-especfico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpListarEstadosHecho>>> FiltrarEstadoHechoZonaEspecifico(SpListarEstadosHecho objSpListarEstadosHecho)
        {
            var ObjSpListarEstadosHecho = new List<MdloDtos.SpListarEstadosHecho>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionEstadoHecho.ValidarCamposEventosEstadoHecho(objSpListarEstadosHecho.eh_estdo, objSpListarEstadosHecho.eh_rowid_vsta_mtnve);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {

                    ObjSpListarEstadosHecho = await this._dbContex.ListarEstadoHechosEventosZonaEspecifico(objSpListarEstadosHecho);
                    if (ObjSpListarEstadosHecho != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSpListarEstadosHecho;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSpListarEstadosHecho;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjSpListarEstadosHecho;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjSpListarEstadosHecho;
                return BadRequest(respuesta);
            }
            return ObjSpListarEstadosHecho;

        }
        #endregion

        #region Consultar eventos de un estado de hechos segun su estado
        [HttpPost("estadoHecho-estado-eventos-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SpListarEstadosHecho>>> FiltrarEstadoHechoZonaGeneral(SpListarEstadosHecho objSpListarEstadosHecho)
        {
            var ObjSpListarEstadosHecho = new List<MdloDtos.SpListarEstadosHecho>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionEstadoHecho.ValidarCamposEventosEstadoHecho(objSpListarEstadosHecho.eh_estdo, objSpListarEstadosHecho.eh_rowid_vsta_mtnve);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {

                    ObjSpListarEstadosHecho = await this._dbContex.ListarEstadoHechosEventosZonaGeneral(objSpListarEstadosHecho);
                    if (ObjSpListarEstadosHecho != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSpListarEstadosHecho;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjSpListarEstadosHecho;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjSpListarEstadosHecho;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjSpListarEstadosHecho;
                return BadRequest(respuesta);
            }
            return ObjSpListarEstadosHecho;

        }
        #endregion

        #region Consultar lista estado de hechos motonave por codigo o nombre
        [HttpGet("listar-MotonaveVisitaEstadoHcho-busqueda")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ListadoEstadoHechosDTO>>> ListarMotonaveVisitaEstadoHechoBusqueda(string FiltroBusqueda)
        {

            var ObjListarEstadosHechoBusqueda = new List<MdloDtos.DTO.ListadoEstadoHechosDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionEstadoHecho.ValidarFiltroBusquedas(FiltroBusqueda);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {

                    ObjListarEstadosHechoBusqueda = await this._dbContex.FiltrarListarEstadoHechosVisitaMotonaveGeneral(FiltroBusqueda);
                    if (ObjListarEstadosHechoBusqueda != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjListarEstadosHechoBusqueda;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjListarEstadosHechoBusqueda;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjListarEstadosHechoBusqueda;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjListarEstadosHechoBusqueda;
                return BadRequest(respuesta);
            }
            return ObjListarEstadosHechoBusqueda;
        }
        #endregion

    }
}
