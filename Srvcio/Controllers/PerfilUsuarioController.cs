using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class PerfilUsuarioController : Controller
    {
        private readonly MdloDtos.IModelos.IPerfilUsuario _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public PerfilUsuarioController(MdloDtos.IModelos.IPerfilUsuario dbContex)
        {
            _dbContex = dbContex;
        }

        #region Consultar perfil usuario
        [HttpGet("listar-perfilUsuario")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PerfilUsuario>>> ListarPerfilUsuario()
        {
           
            var ObPerfilUsuario = new List<MdloDtos.PerfilUsuario>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            try
            {
                ObPerfilUsuario = await this._dbContex.ListarPerfilUsuario();
                if (ObPerfilUsuario != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilUsuario;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = ObPerfilUsuario;
                return BadRequest(respuesta);
            }

            return ObPerfilUsuario;
        }
        #endregion

        #region Filtrar perfil usuario por codigo de perfil
        [HttpGet("filtrar-perfilUsuarioPerfil")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PerfilUsuario>>> FiltrarPerfilUsuarioPorPerfil(string CodigoPerfil)
        {
            
            var ObPerfilUsuario = new List<MdloDtos.PerfilUsuario>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            try
            {
                if ((!string.IsNullOrEmpty(CodigoPerfil)) || CodigoPerfil.Length > 0)
                {
                    ObPerfilUsuario = await this._dbContex.FiltrarPerfilUsuarioPorPerfil(CodigoPerfil);
                    if (ObPerfilUsuario != null)
                    {
                        respuesta.exito = 1;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                        respuesta.datos = ObPerfilUsuario;
                    }
                }
                else
                {
                    respuesta.exito = 0;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                    respuesta.datos = ObPerfilUsuario;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = ObPerfilUsuario;
                return BadRequest(respuesta);
            }

            return ObPerfilUsuario;

        }
        #endregion

        #region Filtrar perfil usuario por codigo de usuario
        [HttpGet("filtrar-perfilUsuarioUsuario")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PerfilUsuario>>> FiltrarPerfilUsuarioPorUsuario(string CodigoUsuario)
        {
            
            var ObPerfilUsuario = new List<MdloDtos.PerfilUsuario>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            try
            {
                if ((!string.IsNullOrEmpty(CodigoUsuario)) || CodigoUsuario.Length > 0)
                {
                    ObPerfilUsuario = await this._dbContex.FiltrarPerfilUsuarioPorUsuario(CodigoUsuario);
                    if (ObPerfilUsuario != null)
                    {
                        respuesta.exito = 1;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                        respuesta.datos = ObPerfilUsuario;
                    }
                }
                else
                {
                    respuesta.exito = 0;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                    respuesta.datos = ObPerfilUsuario;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = ObPerfilUsuario;
                return BadRequest(respuesta);
            }

            return ObPerfilUsuario;

        }
        #endregion

        #region Filtrar perfil usuario por codigo Compañia
        [HttpGet("filtrar-perfilUsuarioCompania")]
        public async Task<ActionResult<IEnumerable<string>>> FiltrarPerfilUsuarioPorCompania(string CodigoCompania)
        {

            var ObPerfilUsuario = new List<string>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            try
            {
                if ((!string.IsNullOrEmpty(CodigoCompania)) || CodigoCompania.Length > 0)
                {
                    ObPerfilUsuario = await this._dbContex.FiltrarPerfilUsuarioPorCompania(CodigoCompania);
                    if (ObPerfilUsuario != null)
                    {
                        respuesta.exito = 1;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                        respuesta.datos = ObPerfilUsuario;
                    }
                }
                else
                {
                    respuesta.exito = 0;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                    respuesta.datos = ObPerfilUsuario;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = ObPerfilUsuario;
                return BadRequest(respuesta);
            }

            return ObPerfilUsuario;

        }
        #endregion

        #region Ingresar perfil usuario 
        [HttpPost("ingresar-perfilUsuario")]
        public async Task<ActionResult<dynamic>> IngresarPerfilUsuario([FromBody] List<MdloDtos.PerfilUsuario> objPerfilUsuario)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            try
            {
               // if (!string.IsNullOrEmpty(objPerfilUsuario.PuCdgoPrfil) && (!string.IsNullOrEmpty(objPerfilUsuario.PuCdgoCia)))
                //{
                    var ObPerfilUsuario = await this._dbContex.IngresarPerfilUsuario(objPerfilUsuario);
                    if (ObPerfilUsuario != null)
                    {
                        respuesta.exito = 1;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                        respuesta.datos = ObPerfilUsuario;
                    }
                    else
                    {
                        respuesta.exito = 0;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                        respuesta.datos = objPerfilUsuario;
                    }
               // }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = objPerfilUsuario;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        /* Cambio solicitado 3-02-2024; Crear Endpoint para perfil Usuario
        #region Actualizar perfil usuario
        [HttpPut("actualizar-perfilUsuario")]
        public async Task<ActionResult<dynamic>> EditarPerfilUsuario([FromBody] List<MdloDtos.PerfilUsuario> objPerfilUsuario)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            try
            {
               // if (!string.IsNullOrEmpty(objPerfilUsuario.PuCdgoCia) && (!string.IsNullOrEmpty(objPerfilUsuario.PuCdgoPrfil)))
               // {
                    var ObPerfilUsuario = await this._dbContex.EditarPerfilUsuario(objPerfilUsuario);
                    if (ObPerfilUsuario != null)
                    {
                        respuesta.exito = 1;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                        respuesta.datos = ObPerfilUsuario;
                    }
                    else
                    {
                        respuesta.exito = 0;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                        respuesta.datos = objPerfilUsuario;
                    }
              //  }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = objPerfilUsuario;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        */

        /*
        #region Eliminar Puerto Origen
        [HttpDelete("eliminar-perfilUsuario")]
        public async Task<ActionResult<dynamic>> EliminarPerfilUsuario([FromBody] MdloDtos.PerfilUsuario objPerfilUsuario)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            try
            {
                if (objPerfilUsuario.PuRowid>0)
                {

                    var ObPerfilUsuario = await _dbContex.EliminarPerfilUsuario((int)objPerfilUsuario.PuRowid);
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilUsuario;
                }
                else
                {
                    respuesta.exito = 0;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                    respuesta.datos = objPerfilUsuario;
                }


            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = objPerfilUsuario;
                BadRequest(respuesta);
            }

            return respuesta;
        }

        #endregion
        */
    }
}
