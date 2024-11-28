using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los periodos de facturaciones
    /// </summary>
    public class ValidacionPeriodoFacturacion
    {
        AccsoDtos.Parametrizacion.PeriodoFacturacion ObjPeriodoFacturacion = new AccsoDtos.Parametrizacion.PeriodoFacturacion();

        #region Validacion de PeriodoFacturacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.PeriodoFacturacion objPeriodoFacturacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objPeriodoFacturacion.PfCdgo) && (!string.IsNullOrEmpty(objPeriodoFacturacion.PfNmbre)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var PeriodoFacturacionExiste = await ObjPeriodoFacturacion.VerificarPeriodoFacturacion(objPeriodoFacturacion.PfCdgo);
                    if (PeriodoFacturacionExiste == true)
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

        #region Validacion de PeriodoFacturacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.PeriodoFacturacion objPeriodoFacturacion_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objPeriodoFacturacion_.PfCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var PeriodoFacturacionExiste = await ObjPeriodoFacturacion.VerificarPeriodoFacturacion(objPeriodoFacturacion_.PfCdgo);
                    if (PeriodoFacturacionExiste == false)
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

        #region Validacion de PeriodoFacturacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.PeriodoFacturacion objPeriodoFacturacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objPeriodoFacturacion.PfCdgo) && (!string.IsNullOrEmpty(objPeriodoFacturacion.PfNmbre)))
                {
                    //Validar que el codigo/Llave No exista.
                    var PeriodoFacturacionExiste = await ObjPeriodoFacturacion.VerificarPeriodoFacturacion(objPeriodoFacturacion.PfCdgo);
                    if (PeriodoFacturacionExiste == false)
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

        #region Validacion de PeriodoFacturacion Validar Busquedas ( Filtros)
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
