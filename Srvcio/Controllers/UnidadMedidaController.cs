using AutoMapper;
using MdloDtos.Utilidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la creación de UnidadMedida
    ///   Wilbert Rivas Granados
    /// </summary>
    [ApiController]
    public class UnidadMedidaController : Controller
    {
        private readonly MdloDtos.IModelos.IUnidadMedida _dbContext;
        private readonly IMapper _mapper;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public UnidadMedidaController(MdloDtos.IModelos.IUnidadMedida dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionUnidadMedida _ObjvalidacionUnidadMedida = new VldcionDtos.ValidacionUnidadMedida();

        #region Consultar todas las UnidadMedida
        [HttpGet("listar-unidadMedida")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.UnidadMedidumDTO>>> ListarUnidadMedida()
        {

            var ObjUnidadMedida = new List<MdloDtos.DTO.UnidadMedidumDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjUnidadMedida = await this._dbContext.ListarUnidadMedida();
                if (ObjUnidadMedida != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjUnidadMedida;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjUnidadMedida;
                return BadRequest(respuesta);
            }

            return ObjUnidadMedida;
        }
        #endregion

        #region Filtrar UnidadMedida por codigo general
        [HttpGet("filtrar-unidadMedida-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.UnidadMedidumDTO>>> FiltrarUnidadMedidaGeneral(string FiltroBusqueda)
        {
            var ObjUnidadMedida = new List<MdloDtos.DTO.UnidadMedidumDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await _ObjvalidacionUnidadMedida.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObjUnidadMedida = await this._dbContext.FiltrarUnidadMedidaGeneral(FiltroBusqueda);
                    if (ObjUnidadMedida != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjUnidadMedida;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjUnidadMedida;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjUnidadMedida;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjUnidadMedida;
                return BadRequest(respuesta);
            }
            return ObjUnidadMedida;
        }
        #endregion

        #region Filtrar UnidadMedida por codigo especifico
        [HttpGet("filtrar-unidadMedida-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.UnidadMedidumDTO>>> FiltrarUnidadMedidumEspecifico(string CodigoBusqueda)
        {

            var ObjUnidadMedidum = new List<MdloDtos.DTO.UnidadMedidumDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoBusqueda;
                validacion = await _ObjvalidacionUnidadMedida.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObjUnidadMedidum = await this._dbContext.FiltrarUnidadMedidaEspecifico(CodigoBusqueda);
                    if (ObjUnidadMedidum != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjUnidadMedidum;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjUnidadMedidum;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjUnidadMedidum;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjUnidadMedidum;
                return BadRequest(respuesta);
            }
            return ObjUnidadMedidum;
        }
        #endregion

        #region Ingresa UnidadMedida
        [HttpPost("ingresar-unidadMedida")]
        public async Task<ActionResult<dynamic>> IngresarUnidadMedida([FromBody] MdloDtos.DTO.UnidadMedidumDTO objUnidadMedida)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjvalidacionUnidadMedida.ValidarIngreso(objUnidadMedida);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObUnidadMedida = await this._dbContext.IngresarUnidadMedida(objUnidadMedida);
                    if (ObUnidadMedida != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObUnidadMedida;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObUnidadMedida;
                    }
                }
                else 
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objUnidadMedida;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objUnidadMedida;
                return BadRequest(respuesta);
            }
            return respuesta;

        }
        #endregion

        #region Actualizar UnidadMedida
        [HttpPut("actualizar-unidadMedida")]
        public async Task<ActionResult<dynamic>> EditarUnidadMedida([FromBody] MdloDtos.DTO.UnidadMedidumDTO objUnidadMedida)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjvalidacionUnidadMedida.ValidarActualizacion(objUnidadMedida);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObUnidadMedida = await this._dbContext.EditarUnidadMedida(objUnidadMedida);
                    if (ObUnidadMedida != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObUnidadMedida;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objUnidadMedida;
                    }
                }
                else 
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objUnidadMedida;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objUnidadMedida;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Eliminar UnidadMedida por codigo 
        [HttpDelete("eliminar-unidadMedida")]
        public async Task<ActionResult<dynamic>> EliminarUnidadMedida([FromBody] MdloDtos.DTO.UnidadMedidumDTO objUnidadMedida)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {

                validacion = await _ObjvalidacionUnidadMedida.ValidarEliminar(objUnidadMedida);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {  
                    var ObjUnidadMedida = await _dbContext.EliminarUnidadMedida(objUnidadMedida.Codigo.ToString());
                    if (ObjUnidadMedida != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjUnidadMedida;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objUnidadMedida;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objUnidadMedida;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objUnidadMedida;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objUnidadMedida;
                    return BadRequest(respuesta);
                }
            }
            return respuesta;
        }
        #endregion
    }
}
