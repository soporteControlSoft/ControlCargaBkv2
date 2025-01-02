using AccsoDtos.AccesoSistema;
using AccsoDtos.RNDC;
using MdloDtos.RNDC;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para validar los manifiesto en el sistema RNDC
    ///   WILBERT RIVAS GRANADOS
    /// </summary>
    [ApiController]
    public class RNDCController : Controller
    {
        private readonly MdloDtos.IModelos.IRNDC _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public RNDCController(MdloDtos.IModelos.IRNDC dbContex)
        {
            _dbContex = dbContex;
        }

        #region validar un manifiesto en particular por idManifiesto y nitEmpresaTransporte
        [HttpGet("validar-manifiesto")]
        public async Task<ConsultaManifiestoRespuesta> validarManifiesto(string idManifiesto, string nitEmpresaTransporte)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            ConsultaManifiestoRespuesta result = await this._dbContex.validarManifiesto(idManifiesto, nitEmpresaTransporte);
            try
            {
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }
        #endregion

    }
}
