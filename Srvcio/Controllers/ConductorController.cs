using AccsoDtos.AccesoSistema;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using VldcionDtos;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para los conductores
    ///   Wilbert Rivas Granados
    /// </summary>
    [ApiController]
    public class ConductorController : Controller
    {
        private readonly MdloDtos.IModelos.IConductor _dbContex;
        private readonly IMapper _mapper;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public ConductorController(MdloDtos.IModelos.IConductor dbContex, IMapper mapper)
        {
            _dbContex = dbContex;
            _mapper = mapper;
        }


        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionConductor validacionConductor = new VldcionDtos.ValidacionConductor();

        /*#region Ingresar conductor
        [HttpPost("ingresar-conductor")]
        public async Task<ActionResult<dynamic>> IngresarConductor([FromBody] MdloDtos.DTO.ConductorDTO2 conductorDTO2)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                //var conductor = _mapper.Map<MdloDtos.Conductor>(conductorDTO2);//aquí se hace el mapeo
                var ObConductor = await this._dbContex.IngresarConductor(conductorDTO2);

                /*validacion = await validacionConductor.ValidarIngreso(objConductor);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObConductor = await this._dbContex.IngresarConductor(objConductor);
                    if (ObConductor != null)
                    {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObConductor;
                 }
                 else
                 {
                     //Error en la transaccion.
                     validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                     respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                     respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                     respuesta.datos = objConductor;
                 }
             }
             else
             {
                 //regresa el error
                 respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                 respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                 respuesta.datos = objConductor;
             }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = conductorDTO2;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion
        */

        #region Ingresar conductor
        [HttpPost("ingresar-conductor")]
        public async Task<ActionResult<dynamic>> IngresarConductor([FromBody] MdloDtos.Conductor conductor)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; 
            try
            {
                //var conductor = _mapper.Map<MdloDtos.Conductor>(conductorDTO2);//aquí se hace el mapeo
                //var ObConductor = await this._dbContex.IngresarConductor(conductor);

                validacion = await validacionConductor.ValidarIngreso(conductor);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObjConductor = await this._dbContex.IngresarConductor(conductor);
                    if (ObjConductor != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = conductor;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = conductor;
                    }
                }
                 else
                 {
                     respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                     respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                     respuesta.datos = conductor;
                 }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = conductor;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Consultar Conductor
        [HttpGet("listar-conductor")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwCndctorLstar>>> ListarConductor()
        {
           
            var ObConductor = new List<MdloDtos.VwCndctorLstar>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObConductor = await this._dbContex.ListarConductor();
                if (ObConductor != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObConductor;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObConductor;
                return BadRequest(respuesta);
            }

            return ObConductor;
        }
        #endregion

        #region Filtrar conductor por codigo
        [HttpGet("filtrar-conductor-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwCndctorLstar>>> FiltrarConductorGeneral(string FiltroBusqueda)
        {
            var ObConductor = new List<MdloDtos.VwCndctorLstar>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; 
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await validacionConductor.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObConductor = await this._dbContex.FiltrarConductorGeneral(FiltroBusqueda);
                    if (ObConductor != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConductor;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConductor;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObConductor;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObConductor;
                return BadRequest(respuesta);
            }
            return ObConductor;
        }
        #endregion

        #region Filtrar conductor
        [HttpGet("filtrar-conductor-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VwCndctorLstar>>> FiltrarConductorEspecifico(string CodigoBusqueda)
        {
            var LstaCndctor = new List<MdloDtos.VwCndctorLstar>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0;
            try
            {
                string? Codigo = CodigoBusqueda;
                validacion = await validacionConductor.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    LstaCndctor = await this._dbContex.FiltrarConductorEspecifico(CodigoBusqueda);
                    if (LstaCndctor != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = LstaCndctor;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = LstaCndctor;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = LstaCndctor;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = LstaCndctor;
                return BadRequest(respuesta);
            }
            return LstaCndctor;

        }
        #endregion

       


        #region Actualizar conductor
        [HttpPut("actualizar-conductor")]
        public async Task<ActionResult<dynamic>> EditarConductor([FromBody] MdloDtos.Conductor objConductor)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0;
            try
            {
                validacion = await validacionConductor.ValidarActualizacion(objConductor);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObConductor = await this._dbContex.EditarConductor(objConductor);
                    if (ObConductor != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje =MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConductor;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objConductor;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objConductor;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objConductor;
                return BadRequest(respuesta);
            }
            return respuesta;
        }
        #endregion

        #region Eliminar conductor
        [HttpDelete("eliminar-conductor")]
        public async Task<ActionResult<dynamic>> EliminarConductor([FromBody] MdloDtos.Conductor objConductor)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; 
            try
            {
                validacion = await validacionConductor.ValidarEliminar(objConductor);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObConductor = await _dbContex.EliminarConductor(objConductor.CnIdntfccion.ToString());
                    if (ObConductor != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConductor;
                    }
                    else
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objConductor;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objConductor;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objConductor;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objConductor;
                    return BadRequest(respuesta);
                } 
            }
            return respuesta;
        }

        #endregion
    }
    
}
