using MdloDtos;
using MdloDtos.RNDC;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionReserva
    {
        AccsoDtos.Reserva.Reserva _ObjReserva = new AccsoDtos.Reserva.Reserva();
        AccsoDtos.RNDC.RNDC RNDC = new AccsoDtos.RNDC.RNDC();
        ValidacionTercero validacionTercero = new ValidacionTercero();
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion  de la existencia de una solicitud de retiro mediante su RowId
        public async Task<int> ValidarExistenciaSolicitudRetiro(int IdSolicitudRetiro)
        {
            try
            {
                if (IdSolicitudRetiro > 0)
                {
                    bool SolicitudRetiroExiste = await _ObjReserva.VerificarSolicitudRetiro(IdSolicitudRetiro);
                    return (!SolicitudRetiroExiste) ?  (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste :
                                                            (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;  
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion  de la existencia de una solicitud de retiro mediante su RowId
        public async Task<int> ValidarExistenciaOrden(int CodigoOrden)
        {
            try
            {
                if (CodigoOrden > 0)
                {
                    bool OrdenExiste = await _ObjReserva.VerificarOrden(CodigoOrden);
                    return (!OrdenExiste) ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste :
                                            (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion el estado de un manifiesto
        public async Task<string> ValidarManifiesto(MdloDtos.Orden _Orden)
        {
            try
            {
                if (string.IsNullOrEmpty(_Orden.OrMnfsto))
                    return "El manifiesto es obligatorio";

                var transportadora = await validacionTercero.ConsultarTerceroPorId(_Orden.OrRowidTrnsprtdra);
                if (transportadora == null)
                    return "La transportadora no está creada en el sistema";

                if (string.IsNullOrEmpty(transportadora.TeCdgo))
                    return "La transportadora no tiene código NIT asociado, es necesario para validar el manifiesto";

                var result = await RNDC.validarManifiesto(_Orden.OrMnfsto, transportadora.TeCdgo);
                if (!result.transaccionExitosa)
                    return $"Error al tratar de validar el manifiesto con el sistema de RNDC: {result.errorCode} {result.errorText}";

                return result.estado switch
                {
                    "AC" => ValidarManifiestoActivo(result, _Orden),
                    "CE" => "El manifiesto se encuentra Cerrado. No se puede crear la orden.",
                    "AN" => "El manifiesto se encuentra Anulado. No se puede crear la orden.",
                    _ => "Error al tratar de validar el manifiesto con el sistema de RNDC"
                };
            }
            catch (Exception)
            {
                return "Error al tratar de validar el manifiesto con el sistema de RNDC";
            }
        }

        private string ValidarManifiestoActivo(ConsultaManifiestoRespuesta result, MdloDtos.Orden _Orden)
        {
            if (result.placa.Equals(_Orden.OrPlca) &&
                (result.id_Conductor.Equals(_Orden.OrIdntfccionCndctor) || result.id_Conductor2.Equals(_Orden.OrIdntfccionCndctor)))
            {
                return "OK";
            }
            return "El manifiesto se encuentra activo, pero los datos de placa y conductor no coinciden con el número de manifiesto";
        }
        #endregion

        #region Validacion de metodo de ingreso de observaciones a la orden
        public async Task<int> ValidarIngresoObservacion(int? CodigoOrden, string CodigoUsuario, string Observacion)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                if (
                    CodigoOrden > 0 &&
                    !string.IsNullOrEmpty(CodigoUsuario) &&
                    !string.IsNullOrEmpty(Observacion)
                    )
                {
                    //#1, validamos que exista la orden
                    bool DepositoExisteExiste = ((await ValidarExistenciaOrden((int)CodigoOrden))
                                                == (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa) ?
                                                true : false;
                    if (!DepositoExisteExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }

                    //#2. validamos que el usuario exista
                    if (!validarResultado)
                    {
                        bool UsarioExiste = await _ObjUsuario.VerificarUsuario(CodigoUsuario);
                        if (!UsarioExiste)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            validarResultado = true;
                        }
                    }
                    if (!validarResultado)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
    }
}
