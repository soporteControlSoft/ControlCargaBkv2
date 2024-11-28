using MdloDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using VldcionDtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Srvcio.Controllers
{
    /// <summary>
    /// Crud para la api Situacionn Portuaria, llamados a acceso a datos.
    /// Daniel Alejandro Lopez
    /// 17/02/2024
    /// </summary>
    [ApiController]
    public class SituacionPortuariaController : Controller
    {
        private readonly MdloDtos.IModelos.ISituacionPortuaria _dbContext;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();
        public SituacionPortuariaController(MdloDtos.IModelos.ISituacionPortuaria dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionSituacionPortuaria validacionSituacionPortuaria = new VldcionDtos.ValidacionSituacionPortuaria();
       

        #region Filtrar Situacion Portuaria por Zona
        [HttpGet("filtrar-situacionPortuaria-zona")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> FiltrarSituacionPortuariaPorZona(int IdZona)
        {

            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarFiltroBusquedasPorZona(IdZona);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObjSituacionPortuarium = await this._dbContext.FiltrarSituacionPortuariaPorZona(IdZona);
                    if (ObjSituacionPortuarium != null)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        foreach (var item in ObjSituacionPortuarium)
                        {
                            var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                            listaDatos.Add(ObjSituacion);

                        }
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;
        }
        #endregion

        #region Filtrar Situacion Portuaria por terminal
        [HttpGet("filtrar-situacionPortuaria-terminal")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> FiltrarSituacionPortuariaPorTerminal(string CodigoTerminalMaritimo)
        {
            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarFiltroBusquedasPorCodigoTerminal(CodigoTerminalMaritimo);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObjSituacionPortuarium = await this._dbContext.FiltrarSituacionPortuariaPorTerminal(CodigoTerminalMaritimo);
                    if (ObjSituacionPortuarium != null)
                    {

                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        foreach (var item in ObjSituacionPortuarium)
                        {
                            var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                            listaDatos.Add(ObjSituacion);

                        }
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;
        }
        #endregion

        #region Filtrar Situacion Portuaria por motonave
        [HttpGet("filtrar-situacionPortuaria-motonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> FiltrarSituacionPortuariaPorMotonave(string CodigoMotonave)
        {

            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarFiltroBusquedasPorCodigoMotonave(CodigoMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObjSituacionPortuarium = await this._dbContext.FiltrarSituacionPortuariaPorMotonave(CodigoMotonave);
                    if (ObjSituacionPortuarium != null)
                    {

                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        foreach (var item in ObjSituacionPortuarium)
                        {
                            var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                            listaDatos.Add(ObjSituacion);

                        }
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;

        }
        #endregion

        #region Filtrar Situacion Portuaria por estado motonave
        [HttpGet("filtrar-situacionPortuaria-estado")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> FiltrarSituacionPortuariaPorEstadoMotonave(string CodigoEstadoMotonave)
        {

            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarFiltroBusquedasPorCodigoEstadosMotonave(CodigoEstadoMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObjSituacionPortuarium = await this._dbContext.FiltrarSituacionPortuariaPorEstadoMotonave(CodigoEstadoMotonave);
                    if (ObjSituacionPortuarium != null)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        foreach (var item in ObjSituacionPortuarium)
                        {
                            var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                            listaDatos.Add(ObjSituacion);

                        }
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;
        }
        #endregion

        #region Filtrar Situacion Portuaria por pais 
        [HttpGet("filtrar-situacionPortuaria-pais")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> FiltrarSituacionPortuariaPorPais(string CodigoPais)
        {

            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarFiltroBusquedasPorCodigoPais(CodigoPais);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObjSituacionPortuarium = await this._dbContext.FiltrarSituacionPortuariaPorPais(CodigoPais);
                    if (ObjSituacionPortuarium != null)
                    {

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        foreach (var item in ObjSituacionPortuarium)
                        {
                            var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                            listaDatos.Add(ObjSituacion);

                        }
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;
        }
        #endregion

        #region Filtrar Situacion Portuaria por Id 
        [HttpGet("filtrar-situacionPortuaria-Situacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> FiltrarSituacionPortuariaPorIdSituacion(int IdSituacion)
        {

            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.

            try
            {
                validacion = await validacionSituacionPortuaria.ValidarFiltroBusquedasPorIdSituacionPortuaria(IdSituacion);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObjSituacionPortuarium = await this._dbContext.FiltrarSituacionPortuariaPorIdSituacion(IdSituacion);
                    if (ObjSituacionPortuarium != null)
                    {
                        //exito.
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        foreach (var item in ObjSituacionPortuarium)
                        {
                            var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                            listaDatos.Add(ObjSituacion);

                        }
                        respuesta.datos = listaDatos;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = listaDatos;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = listaDatos;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;

        }
        #endregion

        #region Consultar Situacion Portuaria , Listar todos.
        [HttpGet("listar-situacionPortuaria")]
        public async Task<ActionResult<IEnumerable<MdloDtos.SituacionPortuarium>>> ConsultarSituacionPortuaria()
        {

            List<MdloDtos.SituacionPortuarium> listaDatos = new List<MdloDtos.SituacionPortuarium>();
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            { 
                var ObjSituacionPortuarium = await this._dbContext.ConsultarSituacionPortuaria();
                if (ObjSituacionPortuarium != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    foreach (var item in ObjSituacionPortuarium)
                    {

                        var ObjSituacion = validacionSituacionPortuaria.ValoresSituacionPortuaria(item);
                        listaDatos.Add(ObjSituacion);

                    }
                    respuesta.datos = listaDatos;
                }
                else {


                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;
        }
        #endregion

        #region Ingresar Situacion Portuaria
        [HttpPost("ingresar-situacionPortuaria")]
        public async Task<ActionResult<dynamic>> IngresarSituacionPortuaria([FromBody] MdloDtos.SituacionPortuarium objSituacionPortuarium)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarIngreso(objSituacionPortuarium);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObSituacion = await this._dbContext.IngresarSituacionPortuaria(objSituacionPortuarium);
                    if (ObSituacion != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObSituacion;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objSituacionPortuarium;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuarium;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objSituacionPortuarium;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion

        #region Actualizar Situacion Portuaria
        [HttpPut("actualizar-situacionPortuaria")]
        public async Task<ActionResult<dynamic>> EditarSituacionPortuaria([FromBody] MdloDtos.SituacionPortuarium objSituacionPortuarium)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarActualizacion(objSituacionPortuarium);

                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObAuditoriaModulo = await this._dbContext.EditarSituacionPortuaria(objSituacionPortuarium);
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
                        respuesta.datos = objSituacionPortuarium;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuarium;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objSituacionPortuarium;
                return BadRequest(respuesta);
            }

            return respuesta;
        }
        #endregion

        #region Eliminar Situacion Portuaria
        [HttpDelete("eliminar-situacionPortuaria")]
        public async Task<ActionResult<dynamic>> EliminarSituacionPortuaria([FromBody] MdloDtos.SituacionPortuarium objSituacionPortuarium)
        {

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Eliminacion);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await validacionSituacionPortuaria.ValidarEliminar(objSituacionPortuarium);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var ObSituacionPortuarium = await _dbContext.EliminarSituacionPortuaria((int)objSituacionPortuarium.SpRowid);
                    if (ObSituacionPortuarium != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = ObSituacionPortuarium;
                    }
                    else
                    {
                        //Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objSituacionPortuarium;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objSituacionPortuarium;
                }
            }
            catch (Exception ex)
            {
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa)
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.HayRelacionesForaneas);
                    respuesta.datos = objSituacionPortuarium;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta);
                    respuesta.datos = objSituacionPortuarium;
                    return BadRequest(respuesta);
                }

            }
            return respuesta;
        }

        #endregion

    }
}
