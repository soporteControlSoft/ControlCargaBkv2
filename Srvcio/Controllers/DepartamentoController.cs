using Azure;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Srvcio.Controllers
{
    /// <summary>
    ///   API para el depatrtamento
    ///   Daniel Alejandro Lopez
    /// </summary>
    [ApiController]
    public class DepartamentoController : Controller
    {
        private readonly MdloDtos.IModelos.IDepartamento _dbContex;
        
        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public DepartamentoController(MdloDtos.IModelos.IDepartamento dbContex)
        {
            _dbContex = dbContex;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionDepartamento validacionDepartamento = new VldcionDtos.ValidacionDepartamento();

        #region Consultar departamento
        [HttpGet("listar-departamento")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Departamento>>> ListarDepartamento()
        {
            var ObjDepartamento = new List<MdloDtos.Departamento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                ObjDepartamento = await this._dbContex.ListarDepartamento();
                if (ObjDepartamento != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjDepartamento;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjDepartamento;
                return BadRequest(respuesta);
            }

            return ObjDepartamento;
        }
        #endregion

        #region Filtrar departamento por codigo Nombre , Codigo (like)
        [HttpGet("filtrar-departamento-general")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Departamento>>> FiltrarDepartamentoGeneral( string FiltroBusqueda)
        {

            var ObjDepartamento= new List<MdloDtos.Departamento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            
            try
            {
                string? Codigo = FiltroBusqueda;
                validacion = await validacionDepartamento.ValidarFiltroBusquedas(Codigo);

                if (validacion == (int)(MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)) //si fue exito)
                {
                    ObjDepartamento = await this._dbContex.FiltrarDepartamentoGeneral(FiltroBusqueda);
                    if (ObjDepartamento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                }
                else 
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjDepartamento;
                }  
            }
            catch (Exception ex)
            {
                //regresa el error
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjDepartamento;
                return BadRequest(respuesta);
            }
            return ObjDepartamento;

        }
        #endregion

        #region Filtrar departamento por codigo especifico de departamento
        [HttpGet("filtrar-departamento-especifico")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Departamento>>> FiltrarDepartamentoEspecifico(string CodigoBusqueda)
        {

            var ObjDepartamento = new List<MdloDtos.Departamento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoBusqueda;
                validacion = await validacionDepartamento.ValidarFiltroBusquedas(Codigo);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjDepartamento = await this._dbContex.FiltrarDepartamentoEspecifico(CodigoBusqueda);
                    if (ObjDepartamento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjDepartamento;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjDepartamento;
                return BadRequest(respuesta);
            }
            return ObjDepartamento;
        }
        #endregion

        #region Filtrar departamento por Pais
        [HttpGet("filtrar-departamento-pais")]
        public async Task<ActionResult<IEnumerable<MdloDtos.Departamento>>> FiltrarDepartamentoPorPais(string CodigoPais)
        {

            var ObjDepartamento = new List<MdloDtos.Departamento>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                string? Codigo = CodigoPais;
                validacion = await validacionDepartamento.ValidarFiltroBusquedas(Codigo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    ObjDepartamento = await this._dbContex.FiltrarDepartamentoPorPais(CodigoPais);
                    if (ObjDepartamento != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                    else 
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                }
                else
                {     
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjDepartamento;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = ObjDepartamento;
                return BadRequest(respuesta);
            }
            return ObjDepartamento;

        }
        #endregion

        #region Ingresar departamento
        [HttpPost("ingresar-departamento")]
        public async Task<ActionResult<dynamic>> IngresarDepartamento([FromBody] MdloDtos.Departamento objDepartamento)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionDepartamento.ValidarIngreso(objDepartamento);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObDepartamento = await this._dbContex.IngresarDepartamento(objDepartamento);
                    if (ObDepartamento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.Exito + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObDepartamento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objDepartamento;
                    }
                }
                else {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objDepartamento;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objDepartamento;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Actualizar Departamento
        [HttpPut("actualizar-departamento")]
        public async Task<ActionResult<dynamic>> EditarDepartamento([FromBody]  MdloDtos.Departamento objDepartamento)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionDepartamento.ValidarActualizacion(objDepartamento);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObDepartamento = await this._dbContex.EditarDepartamento(objDepartamento);
                    if (ObDepartamento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObDepartamento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objDepartamento;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objDepartamento;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objDepartamento;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Eliminar Departamento
        [HttpDelete("eliminar-departamento")]
        public async Task<ActionResult<dynamic>> EliminarDepartamento([FromBody] MdloDtos.Departamento ObjDepartamento)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionDepartamento.ValidarEliminar(ObjDepartamento);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito
                {
                    var ObDepartamento = await _dbContex.EliminarDepartamento((int)ObjDepartamento.DeRowid);
                    if (ObDepartamento != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObDepartamento;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObjDepartamento;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = ObjDepartamento;
                }


            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = ObjDepartamento;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = ObjDepartamento;
                    return BadRequest(respuesta);
                }
            }

            return respuesta;
        }

        #endregion
    }
}
