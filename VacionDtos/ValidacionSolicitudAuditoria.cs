using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionSolicitudAuditoria
    {
        AccsoDtos.Auditoria.SolicitudAutorizacion ObjSolicitudAutorizacion = new AccsoDtos.Auditoria.SolicitudAutorizacion();

        #region Validacion de Solicitud Confirmacion , metodo Ingreso
        public async Task<int> ValidarSolicitudConfirmacion(MdloDtos.AutorizacionRemotum objSolicitudAutorizacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objSolicitudAutorizacion.ArCdgoCia)) && (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArIdntfcdor))
                    &&  (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArCdgoUsrioSlcta)) &&  (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArEqpoSlcta))
                    && (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArFchaSlctud.ToString())))
                {
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Solicitud Confirmacion , metodo Ingreso
        public async Task<int> ValidarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum objSolicitudAutorizacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objSolicitudAutorizacion.ArCdgoCia)) && (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArIdntfcdor))
                    && (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArCdgoUsrioAutrza)) && (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArEqpoAutrza))
                    && (!string.IsNullOrEmpty(objSolicitudAutorizacion.ArFchaAutrza.ToString())))
                {
                    //Retorna valor del TipoMensaje: TransaccionExitosa
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;

                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion


        #region Validacion de AuditoriaModulo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.AutorizacionRemotum objSolicitudAutorizacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objSolicitudAutorizacion.ArRowid.ToString())))
                {
                  
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
    }
}
