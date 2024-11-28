using AccsoDtos.AccesoSistema;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para el pais, Tiene el metodo para implementar la seguridad.
    ///   Daniel Alejandro Lopez
    /// </summary>
    public class PaisController : Controller
    {
        private readonly MdloDtos.IModelos.IPais _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public PaisController(MdloDtos.IModelos.IPais dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionPais _ObjValidacionPais = new VldcionDtos.ValidacionPais();


        #region Consultar pais
        [HttpGet("listar-pais")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Pai>>> ListarPais()
        {
            //Para validar el token
            var identity=HttpContext.User.Identity as ClaimsIdentity;
            AccsoDtos.AccesoSistema.ValidarToken ObjvalidacionPermisos = new AccsoDtos.AccesoSistema.ValidarToken();
            var respuestaToken = ObjvalidacionPermisos.validarAcceso(identity);
           
            string VarPermiso = LoginSistema.MD5Hash(MdloDtos.Utilidades.Constantes.id_Catalogo_Pais + Enum.GetName(typeof(MdloDtos.Utilidades.Constantes.TipoOperacion), 3));
            // validacion de permisos
            //validacion de perfil y permisos y token.
            // if (respuestaToken.success)
            //{

            //Obtener Perfil del claim para enviarselo a la consulta de permisos y sacar los permisos.
            //MdloDtos.Perfil perfil_ = respuestaToken.result;
            //var lstPermisos = ObjvalidacionPermisos.ConsultarPermisos(perfil_.PeCdgo);
            //   foreach (var item in lstPermisos)
            //    {
            //        if (item.PpPrmso == VarPermiso) {
            var ObPais = new List<MdloDtos.Pai>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObPais = await this._dbContex.ListarPais();
                if (ObPais != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                        respuesta.datos = ObPais;
                    }
                }
                catch (Exception ex)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObPais;
                    return BadRequest(respuesta);
                }
                //    }
         //       }

           // }
           // else
           // {
             //   return respuestaToken;
           // }
            
            return ObPais;
        }
        #endregion

        #region Filtrar pais por codigo general
        [HttpGet("filtrar-pais-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Pai>>> FiltrarPaisGeneral(string FiltroBusqueda)
        {
            
            var ObPais = new List<MdloDtos.Pai>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await _ObjValidacionPais.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObPais = await this._dbContex.FiltrarPaisGeneral(FiltroBusqueda);
                    if (ObPais != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObPais;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObPais;
                return BadRequest(respuesta);
            }
            return ObPais;

        }
        #endregion

        #region Filtrar pais por codigo por codigo especifico
        [HttpGet("filtrar-pais-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Pai>>> FiltrarPaisEspecifico(string CodigoBusqueda)
        {
            var ObPais = new List<MdloDtos.Pai>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoBusqueda;
                validacion = await _ObjValidacionPais.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObPais = await this._dbContex.FiltrarPaisEspecifico(CodigoBusqueda);
                    if (ObPais != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObPais;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObPais;
                return BadRequest(respuesta);
            }
            return ObPais;

        }
        #endregion

        #region Ingresar pais
        [HttpPost("ingresar-pais")]
        public async Task<ActionResult<dynamic>> IngresarPais( [FromBody] MdloDtos.Pai objPai)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjValidacionPais.ValidarIngreso(objPai);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObPais = await this._dbContex.IngresarPais(objPai);
                    if (ObPais != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objPai;
                    }
                }
                else 
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objPai;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objPai;
                return BadRequest(respuesta);  
            }
            return respuesta;
        }
        #endregion

        #region Actualizar pais
        [HttpPut("actualizar-pais")]
        public async Task<ActionResult<dynamic>> EditarPais([FromBody] MdloDtos.Pai objPai)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjValidacionPais.ValidarActualizacion(objPai);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    var ObPais = await this._dbContex.EditarPais(objPai);
                    if (ObPais != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objPai;
                    }
                }
                else 
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objPai;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objPai;
                return BadRequest(respuesta);
            }
            return respuesta;

        }
        #endregion

        #region Eliminar pais
        [HttpDelete("eliminar-pais")]
        public async Task<ActionResult<dynamic>> EliminarPais([FromBody] MdloDtos.Pai objPai)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await _ObjValidacionPais.ValidarEliminar(objPai);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    var ObPais = await _dbContex.EliminarPais(objPai.PaCdgo);

                    if (ObPais != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObPais;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objPai;
                    }
                        
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objPai;
                }

            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objPai;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objPai;
                    return BadRequest(respuesta);
                }
            }

            return respuesta;
        }

        #endregion
    }
}
