using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    public class EstadoMotonaveController : Controller
    {
        private readonly MdloDtos.IModelos.IEstadosMotonave _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public EstadoMotonaveController(MdloDtos.IModelos.IEstadosMotonave dbContext)
        {
            _dbContext = dbContext;
        }

        #region Consultar Estados Motonave
        [HttpGet("listar-estadosMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.EstadoMotonave>>> ListarEstadoMotonave()
        {

            var ObEstadoMotonave = new List<MdloDtos.EstadoMotonave>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            try
            {
                ObEstadoMotonave = await this._dbContext.ListarEstadoMotonave();
                if (ObEstadoMotonave != null)
                {
                    respuesta.exito = 1;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito;
                    respuesta.datos = ObEstadoMotonave;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = 0;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion);
                respuesta.datos = ObEstadoMotonave;
                return BadRequest(respuesta);
            }

            return ObEstadoMotonave;
        }
        #endregion
    }
}
