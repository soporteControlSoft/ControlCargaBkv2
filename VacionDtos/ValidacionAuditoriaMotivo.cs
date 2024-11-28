using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las AuditoriaMotivo
    /// </summary>
    public class ValidacionAuditoriaMotivo
    {
        AccsoDtos.Parametrizacion.AuditoriaMotivo ObjAuditoriaMotivo = new AccsoDtos.Parametrizacion.AuditoriaMotivo();

        #region Validacion de AuditoriaMotivo , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.AuditoriaMotivo objAuditoriaMotivo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objAuditoriaMotivo.AmCdgo)) && (!string.IsNullOrEmpty(objAuditoriaMotivo.AmDscrpcion)) 
                    &&  (objAuditoriaMotivo.AmRqrePdirRzon != null))
                {
                    //Validar que el codigo/Llave  No exista.
                    var AuditoriaMotivoExiste = await ObjAuditoriaMotivo.VerificarAuditoriaMotivo(objAuditoriaMotivo.AmCdgo);
                    if (AuditoriaMotivoExiste == true)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
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

        #region Validacion de AuditoriaMotivo , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.AuditoriaMotivo objAuditoriaMotivo_)
        {
            int resultado = 0;
            try
            {
                if (!string.IsNullOrEmpty(objAuditoriaMotivo_.AmCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var AuditoriaMotivoExiste = await ObjAuditoriaMotivo.VerificarAuditoriaMotivo(objAuditoriaMotivo_.AmCdgo);
                    if (AuditoriaMotivoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
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

        #region Validacion de AuditoriaMotivo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.AuditoriaMotivo objAuditoriaMotivo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objAuditoriaMotivo.AmCdgo)) && (!string.IsNullOrEmpty(objAuditoriaMotivo.AmDscrpcion))
                    && (objAuditoriaMotivo.AmRqrePdirRzon != null))
                {
                    //Validar que el codigo/Llave exista.
                    var AuditoriaMotivoExiste = await ObjAuditoriaMotivo.VerificarAuditoriaMotivo(objAuditoriaMotivo.AmCdgo);
                    if (AuditoriaMotivoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
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

        #region Validacion de AuditoriaMotivo Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(Busqueda)) || Busqueda.Length > 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
    }
}
