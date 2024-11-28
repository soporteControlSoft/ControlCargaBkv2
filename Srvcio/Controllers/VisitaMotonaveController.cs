using AccsoDtos.Parametrizacion;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using VldcionDtos;

namespace Srvcio.Controllers
{
    public class VisitaMotonaveController : Controller
    {
        private readonly MdloDtos.IModelos.IVisitaMotonave _dbContex;

        MdloDtos.Utilidades.RespuestaServicios respuesta = new MdloDtos.Utilidades.RespuestaServicios();

        public VisitaMotonaveController(MdloDtos.IModelos.IVisitaMotonave dbContex)
        {
            _dbContex = dbContex;
        }
        /// <summary>
        /// Clase para validar los datos.
        /// </summary>
        VldcionDtos.ValidacionVisitaMotonave ObjValidacionVisitaMotonave = new VldcionDtos.ValidacionVisitaMotonave();

        #region Consultar secuencia Motonave
        [HttpGet("listar-secuenciaMotonave")]
        public async Task<ActionResult<string>> ConsultarSecuenciaVisitaMotonave(string CodigoCompania, String CodigoMotonave)
        {

            string Secuencia = "";

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                Secuencia = await this._dbContex.ConsultarSecuenciaVisitaMotonave(CodigoCompania, CodigoMotonave);
                if (Secuencia != null || (!string.IsNullOrEmpty(Secuencia)) || (Secuencia.Length > 0))
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = Secuencia;
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = CodigoMotonave;
                return BadRequest(respuesta);
            }

            return Secuencia;
        }
        #endregion

        #region Ingresar visita Motonave
        [HttpPost("ingresar-visitaMotonave")]
        public async Task<ActionResult<dynamic>> IngresarVisitaMotonave([FromBody] MdloDtos.VisitaMotonave objVisitaMotonave)
        {
            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
            int validacion = 0; // para sacar el mensaje de la operacion del crud.
            try
            {
                validacion = await ObjValidacionVisitaMotonave.ValidarIngreso(objVisitaMotonave);
                if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                {
                    var Obvisita = await this._dbContex.IngresarVisitaMotonave(objVisitaMotonave);
                    if (Obvisita != null)
                    {
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = Obvisita;
                    }
                    else
                    {
                        // Error en la transaccion.
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        respuesta.datos = objVisitaMotonave;
                    }
                }
                else
                {
                    //regresa el error
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    respuesta.datos = objVisitaMotonave;
                }

            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                respuesta.datos = objVisitaMotonave;
                return BadRequest(respuesta);
            }

            return respuesta;

        }
        #endregion
        
        #region Actualizar Situacion Portuaria
         [HttpPut("actualizar-visitaMotonave")]
         public async Task<ActionResult<dynamic>> EditarVisitaMotonave([FromBody] MdloDtos.VisitaMotonave objVisitaMotonave)
         {

             int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Actualizacion);
             int validacion = 0; // para sacar el mensaje de la operacion del crud.
             try
             {
                 validacion = await ObjValidacionVisitaMotonave.ValidarActualizacion(objVisitaMotonave);

                 if (validacion == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) //si fue exito)
                 {
                     var ObjVisitaMotonave = await this._dbContex.EditarVisitaMotonave(objVisitaMotonave);
                     if (ObjVisitaMotonave != null)
                     {
                         respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                         respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                         respuesta.datos = ObjVisitaMotonave;
                     }
                     else
                     {
                         //Error en la transaccion.
                         validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

                         respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                         respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                         respuesta.datos = objVisitaMotonave;
                     }
                 }
                 else
                 {
                     //regresa el error
                     respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                     respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                     respuesta.datos = objVisitaMotonave;
                 }

             }
             catch (Exception ex)
             {
                 respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                 respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                 respuesta.datos = objVisitaMotonave;
                 return BadRequest(respuesta);
             }

             return respuesta;
         }
         #endregion
        
        #region Consultar visita motonave , Listar todos.
        [HttpGet("listar-visitaMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> ConsultarVisitaMotonave()
        {

            List<MdloDtos.VisitaMotonave> listaDatos = new List<MdloDtos.VisitaMotonave>();

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                var ObjViista = new List<MdloDtos.VisitaMotonave>();
                listaDatos = await this._dbContex.ConsultarVisitaMotonave();
                if (ObjViista != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    //foreach (var item in ObjViista)
                    //{

                    //   // var ObjSituacion = ObjValidacionVisitaMotonave.ValoresVisitaMotonave(item);
                    //    listaDatos.Add(item);

                    //}
                    respuesta.datos = listaDatos;
                }
                else
                {


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

        #region Consultar visita motonave , Por fechas.
        [HttpGet("listar-filtrarVisitasfechas")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> FiltrarVisitaMotonaveEspecifico(DateTime FechaInicio, DateTime FechaFin, string Motonave)
        {

            List<MdloDtos.VisitaMotonave> listaDatos = new List<MdloDtos.VisitaMotonave>();

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                string fechaInicio = Convert.ToString(FechaInicio);
                string fechafin = Convert.ToString(FechaFin);
                if ((!string.IsNullOrEmpty(fechaInicio)) && (!string.IsNullOrEmpty(fechafin)))
                {
                   
                    var listaDatos_ = await this._dbContex.FiltrarVisitaMotonaveEspecifico(FechaInicio, FechaFin, Motonave);
                    if (listaDatos_ != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                            foreach (var item in listaDatos_)
                            {

                                
                                listaDatos.Add(item);

                            }
                            respuesta.datos = listaDatos;
                    }
                    else
                    {


                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    }
                }
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta(operacion) + ", " + MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                //respuesta.datos = listaDatos;
                return BadRequest(respuesta);
            }

            return listaDatos;
        }
        #endregion

        //cambio
        #region Consultar visita motonave , Por id.
        [HttpGet("listar-filtrarVisitasId")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> FiltrarVisitaMotonaveId(int Id)
        {

            List<MdloDtos.VisitaMotonave> listaDatos = new List<MdloDtos.VisitaMotonave>();

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {

                if ((!string.IsNullOrEmpty(Id.ToString())) && (Id>0))
                {
                    var ObjViista = new List<MdloDtos.VisitaMotonave>();
                    listaDatos = await this._dbContex.FiltrarVisitaMotonaveId(Id);
                    if (ObjViista != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        //foreach (var item in ObjViista)
                        //{

                        //   // var ObjSituacion = ObjValidacionVisitaMotonave.ValoresVisitaMotonave(item);
                        //    listaDatos.Add(item);

                        //}
                        respuesta.datos = listaDatos;
                    }
                    else
                    {


                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    }
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

        //cambio
        #region Consultar visita motonave , Por codigo o nombre de motonave.
        [HttpGet("listar-filtrarVisitasMotonave")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> FiltrarVisitaMotonaveMotonave(string Motonave)
        {

            List<MdloDtos.VisitaMotonave> listaDatos = new List<MdloDtos.VisitaMotonave>();

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {

                if ((!string.IsNullOrEmpty(Motonave.ToString())))
                {
                    var ObjViista = new List<MdloDtos.VisitaMotonave>();
                    listaDatos = await this._dbContex.FiltrarVisitaMotonaveMotonave(Motonave);
                    if (ObjViista != null)
                    {
                        validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                        //foreach (var item in ObjViista)
                        //{

                        //   // var ObjSituacion = ObjValidacionVisitaMotonave.ValoresVisitaMotonave(item);
                        //    listaDatos.Add(item);

                        //}
                        respuesta.datos = listaDatos;
                    }
                    else
                    {


                        respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                        respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);
                    }
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


        //nueva versionn 26.05.2024.
        #region Consultar visita motonave aprobacion, Por codigo compania o por fechas.
        [HttpGet("listar-VisitasMotonave-aprobacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonaveDocumento>>> ConsultaVisitaMotonaveCompania(string Compania, DateTime fechaInicio, DateTime FechaFin)
        {

            List<MdloDtos.VisitaMotonaveDocumento> listaDatos = new List<MdloDtos.VisitaMotonaveDocumento>();

            int operacion = Convert.ToInt32(MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta);
            int validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            try
            {
                var ObjViista = new List<MdloDtos.VisitaMotonaveDocumento>();
                listaDatos = await this._dbContex.ConsultaVisitaMotonaveCompania( Compania,  fechaInicio,  FechaFin);
                if (ObjViista != null)
                {
                    validacion = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion(validacion);

                    respuesta.datos = listaDatos;
                }
                else
                {
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

        #region Consultar visita motonave aduanas, Por usuario y empresa.
        [HttpGet("consulta-vista-motonave-aduana")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> ConsultaVisitaMotonaveAduana(string Compania, string CodigoUsuario)
        {
            if (string.IsNullOrEmpty(Compania) || string.IsNullOrEmpty(CodigoUsuario))
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje =MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaVisitaMotonave = await this._dbContex.ConsultaVisitaMotonaveAduana(Compania, CodigoUsuario);
                if (listaVisitaMotonave != null && listaVisitaMotonave.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaVisitaMotonave;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.VisitaMotonave>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

        //cambio
        #region Consultar visita motonave , Por id.
        [HttpGet("calcular-documentos-pendientes-aprobacion-visitamotonave")]
        public async Task<ActionResult<IEnumerable<Object>>> ConsultaCantidadDocumentosPendientesAprobacionPorVisitaMotonave(int IdVisitaMotonave)
        {
            if (IdVisitaMotonave <= 0)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                int cantidadDocumentosPendientesPorAprobar = await this._dbContex.ConsultaCantidadDocumentosPendientesAprobacionPorVisitaMotonave(IdVisitaMotonave);
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                respuesta.datos = cantidadDocumentosPendientesPorAprobar;
               
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

        #region Consultar visita motonave aduanas, Por usuario y empresa.
        [HttpGet("consulta-vista-motonave-deposito")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> ConsultaVisitaMotonaveDeposito(string Compania, string CodigoUsuario)
        {
            if (string.IsNullOrEmpty(Compania) || string.IsNullOrEmpty(CodigoUsuario))
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaVisitaMotonave = await this._dbContex.ConsultaVisitaMotonaveDeposito(Compania, CodigoUsuario);
                if (listaVisitaMotonave != null && listaVisitaMotonave.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaVisitaMotonave;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.VisitaMotonave>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

        #region Consultar visita motonave para la aprobacion de depositos.
        [HttpGet("consulta-vista-motonave-aprobacion-deposito")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> ConsultaVisitaMotonaveDepositoAprobacion(string Compania)
        {
            if (string.IsNullOrEmpty(Compania))
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaVisitaMotonave = await this._dbContex.ConsultaVisitaMotonaveDepositoAprobacion(Compania);
                if (listaVisitaMotonave != null && listaVisitaMotonave.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaVisitaMotonave;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.VisitaMotonave>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

        #region Consultar visita motonave aduanas, Por usuario y empresa.
        [HttpGet("consulta-vista-motonave-deposito-creacion")]
        public async Task<ActionResult<IEnumerable<MdloDtos.VisitaMotonave>>> ConsultaVisitaMotonaveDepositoCreacion(string Compania)
        {
            if (string.IsNullOrEmpty(Compania))
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull);
                return BadRequest(respuesta);
            }

            try
            {
                var listaVisitaMotonave = await this._dbContex.ConsultaVisitaMotonaveDepositoCreacion(Compania);
                if (listaVisitaMotonave != null && listaVisitaMotonave.Any())
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = listaVisitaMotonave;
                }
                else
                {
                    respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoExito;
                    respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeOperacion((int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa);
                    respuesta.datos = new List<MdloDtos.VisitaMotonave>();
                }
                return Ok(respuesta);
            }
            catch (Exception ex)
            {
                respuesta.exito = MdloDtos.Utilidades.Constantes.RetornoError;
                respuesta.mensaje = MdloDtos.Utilidades.Mensajes.MensajeRespuesta((int)MdloDtos.Utilidades.Constantes.TipoOperacion.Consulta) + ", " + ex.Message;
                return BadRequest(respuesta);
            }
        }
        #endregion

       

    }
}
