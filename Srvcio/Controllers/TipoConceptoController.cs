using AutoMapper;
using MdloDtos;
using Microsoft.AspNetCore.Mvc;

namespace Srvcio.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class TipoConceptoController : Controller
    {
        /// <summary>
        /// Acceso a Datos tipo consecutivo
        /// Daniel Alejandro Lopez.
        /// </summary>
        private readonly MdloDtos.IModelos.ITiposConceptos _dbContex;
        private readonly IMapper _Mapper;


        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public TipoConceptoController(MdloDtos.IModelos.ITiposConceptos dbContex)
        {
            _dbContex = dbContex;

        }

        #region Lista de tipo de concepto ( todos)
        [HttpGet("listar-tipoConceptos")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> ConsultarTipoConcepto()
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.TipoConceptoDTO>();

                result = await this._dbContex.ConsultarTipoConcepto();

                if (result.Count > 0)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(respuesta);
            }
        }
        #endregion

        #region Lista de tipo de conceptos ( por codigo)
        [HttpGet("buscar-tipoConcepto-codigo")]
        [ProducesResponseType<string>(StatusCodes.Status404NotFound)]
        public async Task<dynamic> FiltrarTipoConceptoPorCodigo(string Codigo)
        {

            try
            {
                int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
                int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                var result = new List<MdloDtos.DTO.TipoConceptoDTO>();

                result = await this._dbContex.FiltrarTipoConceptoPorCodigo(Codigo);

                if (result.Count > 0)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = result;
                }
                return result;
            }
            catch (Exception ex)
            {
                return BadRequest(respuesta);
            }
        }
        #endregion

    }
}
