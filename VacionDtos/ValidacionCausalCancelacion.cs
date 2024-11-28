using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Causales de Cancelación
    /// </summary>
    public class ValidacionCausalCancelacion
    {
        AccsoDtos.Parametrizacion.CausalCancelacion ObjCausalCancelacion = new AccsoDtos.Parametrizacion.CausalCancelacion();

        #region Validacion de CausalCancelacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.CausalCancelacion objCausalCancelacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCausalCancelacion.CcCdgo)) && (!string.IsNullOrEmpty(objCausalCancelacion.CcDscrpcion)) && (!string.IsNullOrEmpty(objCausalCancelacion.CcOrgen)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var CausalCancelacionExiste = await ObjCausalCancelacion.VerificarCausalCancelacion(objCausalCancelacion.CcCdgo);
                    if (CausalCancelacionExiste == true)
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

        #region Validacion de CausalCancelacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.CausalCancelacion objCausalCancelacion_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objCausalCancelacion_.CcCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var CausalCancelacionExiste = await ObjCausalCancelacion.VerificarCausalCancelacion(objCausalCancelacion_.CcCdgo);
                    if (CausalCancelacionExiste == false)
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

        #region Validacion de CausalCancelacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.CausalCancelacion objCausalCancelacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCausalCancelacion.CcCdgo)) && (!string.IsNullOrEmpty(objCausalCancelacion.CcDscrpcion)) && (!string.IsNullOrEmpty(objCausalCancelacion.CcOrgen)))
                {
                    //Validar que el codigo/Llave exista.
                    var CausalCancelacionExiste = await ObjCausalCancelacion.VerificarCausalCancelacion(objCausalCancelacion.CcCdgo);
                    if (CausalCancelacionExiste == false)
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

        #region Validacion de CausalCancelacion Validar Busquedas ( Filtros)
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
