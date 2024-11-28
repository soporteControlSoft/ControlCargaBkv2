using Azure;
using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Api para guardar los permisos de los usuarios.
    /// Daniel Alejandro Lopez
    /// </summary>
    [ApiController]
    public class PerfilPermisoController : Controller
    {
        private readonly MdloDtos.IModelos.IPerfilPermisos _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public PerfilPermisoController(MdloDtos.IModelos.IPerfilPermisos dbContex)
        {
            _dbContex = dbContex;
        }

        #region Consultar Perfil Permisos
        [HttpGet("listar-perfilPermisos")]
        public async Task<ActionResult<IEnumerable<MdloDtos.PerfilPermiso>>> ListarPerfilPermiso()
        {

            var ObPerfilPermiso = new List<MdloDtos.PerfilPermiso>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            try
            {
                ObPerfilPermiso = await this._dbContex.ListarPerfilPermiso();
                if (ObPerfilPermiso != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilPermiso;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = ObPerfilPermiso;
                return BadRequest(respuesta);
            }

            return ObPerfilPermiso;
        }
        #endregion

        #region Ingresar Perfil Permiso - Catalogo
        [HttpPost("ingresar-ingresarPerfilPermisoCatalogo")]
        public async Task<ActionResult<dynamic>> IngresarPerfilPermisoCatalogo([FromBody] MdloDtos.PerfilPermiso objPerfilPermiso)
        {
            var ObPerfilPermiso = await this._dbContex.IngresarPerfilPermisoCatalogo(objPerfilPermiso);
            try
            {
                if (ObPerfilPermiso != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilPermiso.ToString();
                }
                else
                {
                    respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString();
                    respuesta.datos = null;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString();
                respuesta.datos = null;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Actualizar Perfil permiso - Catalogo
        [HttpPut("actualizar-editarPerfilPermisoCatalogo")]
        public async Task<ActionResult<dynamic>> EditarPerfilPermisoCatalogo([FromBody] MdloDtos.PerfilPermiso Obj)
        {
            try
            {
                var ObPerfilPermiso = await this._dbContex.EditarPerfilPermisoCatalogo(Obj);
                if (ObPerfilPermiso != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilPermiso.ToString();
                }
                else
                {
                    respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion.ToString();
                    respuesta.datos = null;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion.ToString();
                respuesta.datos = null;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Ingresar Perfil Permiso - menu
        [HttpPost("ingresar-ingresarPerfilPermisoMenu")]
        public async Task<ActionResult<dynamic>> IngresarPerfilPermisoMenu( [FromBody] MdloDtos.PerfilPermiso obj)
        {
            try
            {
                var ObPerfilPermiso = await this._dbContex.IngresarPerfilPermisoMenu(obj);
                if (ObPerfilPermiso != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilPermiso.ToString();
                }
                else
                {
                    respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString();
                    respuesta.datos = null;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso.ToString();
                respuesta.datos = null;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Actualizar Perfil permiso - menu
        [HttpPut("actualizar-editarPerfilPermisoMenu")]
        public async Task<ActionResult<dynamic>> EditarPerfilPermisoMenu([FromBody] MdloDtos.PerfilPermiso obj)
        {
            
            try
            {
                var ObPerfilPermiso = await this._dbContex.EditarPerfilPermisoMenu(obj);
                if (ObPerfilPermiso != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilPermiso.ToString();
                }
                else
                {
                    respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion.ToString();
                    respuesta.datos = null;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion.ToString();
                respuesta.datos = null;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Eliminar Perfil Permiso
        [HttpDelete("eliminar-eliminarPerfilPermiso")]
        public async Task<ActionResult<dynamic>> EliminarPerfilPermiso(MdloDtos.PerfilPermiso Obj)
        {


            try
            {
                if (Obj.PpCdgoPrfil != null)
                {
                    var ObPerfilPermiso = await _dbContex.EliminarPerfilPermiso(Obj.PpCdgoPrfil);
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObPerfilPermiso.ToString();
                }

                   


            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = "Error sobre la entidad perfil permiso en la operacion" + " - " + MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion.ToString();

            }

            return respuesta;
        }

        #endregion



    }
}
