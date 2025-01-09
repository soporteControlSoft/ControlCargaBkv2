using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using VldcionDtos;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para la configuracion vehicular
    ///   Daniel Alejandro Lopez
    /// </summary>
    [ApiController]
    public class ConfiguracionVehicularController : Controller
    {
        private readonly MdloDtos.IModelos.IConfiguracionVehicular _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public ConfiguracionVehicularController(MdloDtos.IModelos.IConfiguracionVehicular dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionConfiguracionVehicular validacionConfiguracionVehicular = new VldcionDtos.ValidacionConfiguracionVehicular();


        #region Consultar Configuracion Vehicular
        [HttpGet("listar-configuracionVehicular")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ConfiguracionVehicularDTO>>> ListarConfiguracionVehicular()
        {
            var ObConfiguracionVehicular = new List<MdloDtos.DTO.ConfiguracionVehicularDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObConfiguracionVehicular = await this._dbContex.ListarConfiguracionVehicular();
                if (ObConfiguracionVehicular != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObConfiguracionVehicular;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObConfiguracionVehicular;
                return BadRequest(respuesta);
            }

            return ObConfiguracionVehicular;
        }
        #endregion

        #region Filtrar Configuracion Vehicular por codigo
        [HttpGet("filtrar-configuracionVehicular-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ConfiguracionVehicularDTO>>> FiltrarConfiguracionVehicularGeneral( string FiltroBusqueda)
        {
            var ObConfiguracionVehicular = new List<MdloDtos.DTO.ConfiguracionVehicularDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await validacionConfiguracionVehicular.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObConfiguracionVehicular = await this._dbContex.FiltrarConfiguracionVehicularGeneral(FiltroBusqueda);
                    if (ObConfiguracionVehicular != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObConfiguracionVehicular;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObConfiguracionVehicular;
                return BadRequest(respuesta);
            }
            return ObConfiguracionVehicular;
        }
        #endregion

        #region Filtrar Configuracion Vehicular por codigo
        [HttpGet("filtrar-configuracionVehicular-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.DTO.ConfiguracionVehicularDTO>>> FiltrarConfiguracionVehicularEspecifico( string CodigoBusqueda)
        {
            var ObConfiguracionVehicular = new List<MdloDtos.DTO.ConfiguracionVehicularDTO>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoBusqueda;
                validacion = await validacionConfiguracionVehicular.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObConfiguracionVehicular = await this._dbContex.FiltrarConfiguracionVehicularEspecifico(CodigoBusqueda);
                    if (ObConfiguracionVehicular != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObConfiguracionVehicular;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObConfiguracionVehicular;
                return BadRequest(respuesta);
            }
            return ObConfiguracionVehicular;
        }
        #endregion

        #region Ingresar Configuracion Vehicular
        [HttpPost("ingresar-configuracionVehicular")]
        public async Task<ActionResult<dynamic>> IngresarConfiguracionVehicular( [FromBody] MdloDtos.DTO.ConfiguracionVehicularDTO objConfiguracionVehicular)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionConfiguracionVehicular.ValidarIngreso(objConfiguracionVehicular);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObConfiguracionVehicular = await this._dbContex.IngresarConfiguracionVehicular(objConfiguracionVehicular);
                    if (ObConfiguracionVehicular != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;   
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objConfiguracionVehicular;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objConfiguracionVehicular;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Actualizar Configuracion Vehicular
        [HttpPut("actualizar-configuracionVehicular")]
        public async Task<ActionResult<dynamic>> EditarConfiguracionVehicular([FromBody] MdloDtos.DTO.ConfiguracionVehicularDTO objConfiguracionVehicular)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionConfiguracionVehicular.ValidarActualizacion(objConfiguracionVehicular);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObConfiguracionVehicular = await this._dbContex.EditarConfiguracionVehicular(objConfiguracionVehicular);
                    if (ObConfiguracionVehicular != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObConfiguracionVehicular;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objConfiguracionVehicular;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objConfiguracionVehicular;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objConfiguracionVehicular;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Eliminar Configuracion Vehicular
        [HttpDelete("eliminar-configuracionVehicular")]
        public async Task<ActionResult<dynamic>> EliminarConfiguracionVehicular([FromBody] MdloDtos.DTO.ConfiguracionVehicularDTO objConfiguracionVehicular)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionConfiguracionVehicular.ValidarEliminar(objConfiguracionVehicular);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    int Id = (int)objConfiguracionVehicular.IdConfiguracionVehicular;
                    var ObAuditoriaModulo = await _dbContex.EliminarConfiguracionVehicular(Id);
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
                        respuesta.datos = objConfiguracionVehicular;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objConfiguracionVehicular;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objConfiguracionVehicular;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objConfiguracionVehicular;
                    return BadRequest(respuesta);
                }

            }
            return respuesta;
        }

        #endregion
    }
}
