using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Condiciones de Facturacion
    /// </summary>
    public class ValidacionCondicionFacturacion
    {
        AccsoDtos.Parametrizacion.CondicionFacturacion ObjCondicionFacturacion = new AccsoDtos.Parametrizacion.CondicionFacturacion();

        #region Validacion de CondicionFacturacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.CondicionFacturacion objCondicionFacturacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objCondicionFacturacion.CfCdgo) && (!string.IsNullOrEmpty(objCondicionFacturacion.CfNmbre)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var CondicionFacturacionExiste = await ObjCondicionFacturacion.VerificarCondicionFacturacion(objCondicionFacturacion.CfCdgo);
                    if (CondicionFacturacionExiste == true)
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

        #region Validacion de CondicionFacturacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.CondicionFacturacion objCondicionFacturacion_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objCondicionFacturacion_.CfCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var CondicionFacturacionExiste = await ObjCondicionFacturacion.VerificarCondicionFacturacion(objCondicionFacturacion_.CfCdgo);
                    if (CondicionFacturacionExiste == false)
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

        #region Validacion de CondicionFacturacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.CondicionFacturacion objCondicionFacturacion)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCondicionFacturacion.CfCdgo)) && (!string.IsNullOrEmpty(objCondicionFacturacion.CfNmbre)))
                {
                    //Validar que el codigo/Llave No exista.
                    var CondicionFacturacionExiste = await ObjCondicionFacturacion.VerificarCondicionFacturacion(objCondicionFacturacion.CfCdgo);
                    if (CondicionFacturacionExiste == false)
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

        #region Validacion de CondicionFacturacion Validar Busquedas ( Filtros)
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
