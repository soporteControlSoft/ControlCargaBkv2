using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Auditoria Modulos.
    /// </summary>
    public class ValidacionAuditoriaModulo
    {
        AccsoDtos.Parametrizacion.AuditoriaModulo ObjAuditoriaModulo = new AccsoDtos.Parametrizacion.AuditoriaModulo();

        #region Validacion de AuditoriaModulo , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.AuditoriaModulo objAuditoriaModulo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objAuditoriaModulo.AmCdgo)) && (!string.IsNullOrEmpty(objAuditoriaModulo.AmNmbre)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var AuditoriaModuloExiste = await ObjAuditoriaModulo.VerificarAuditoriaModulo(objAuditoriaModulo.AmCdgo);
                    if (AuditoriaModuloExiste == true)
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

        #region Validacion de AuditoriaModulo , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.AuditoriaModulo objAuditoriaModulo_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objAuditoriaModulo_.AmCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var AuditoriaModuloExiste = await ObjAuditoriaModulo.VerificarAuditoriaModulo(objAuditoriaModulo_.AmCdgo);
                    if (AuditoriaModuloExiste == false)
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

        #region Validacion de AuditoriaModulo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.AuditoriaModulo objAuditoriaModulo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objAuditoriaModulo.AmCdgo)) && (!string.IsNullOrEmpty(objAuditoriaModulo.AmNmbre)))
                {
                    //Validar que el codigo/Llave No exista.
                    var AuditoriaModuloExiste = await ObjAuditoriaModulo.VerificarAuditoriaModulo(objAuditoriaModulo.AmCdgo);
                    if (AuditoriaModuloExiste == false)
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

        #region Validacion de AuditoriaModulo Validar Busquedas ( Filtros)
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
