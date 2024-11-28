using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar el puerto origen.
    /// </summary>
    public class ValidacionPuertoOrigen
    {
        AccsoDtos.Parametrizacion.PuertoOrigen ObjPuertoOrigen = new AccsoDtos.Parametrizacion.PuertoOrigen();

        #region Validacion de PuertoOrigen , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.PuertoOrigen objPuertoOrigen)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objPuertoOrigen.PoCdgo)) && (!string.IsNullOrEmpty(objPuertoOrigen.PoDscrpcion)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var PuertoOrigenExiste = await ObjPuertoOrigen.VerificarPuertoOrigen(objPuertoOrigen.PoCdgo);
                    if (PuertoOrigenExiste == true)
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

        #region Validacion de PuertoOrigen , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.PuertoOrigen objPuertoOrigen_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objPuertoOrigen_.PoCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var PuertoOrigenExiste = await ObjPuertoOrigen.VerificarPuertoOrigen(objPuertoOrigen_.PoCdgo);
                    if (PuertoOrigenExiste == false)
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

        #region Validacion de PuertoOrigen , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.PuertoOrigen objPuertoOrigen)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objPuertoOrigen.PoCdgo)) && (!string.IsNullOrEmpty(objPuertoOrigen.PoDscrpcion)))
                {
                    //Validar que el codigo/Llave No exista.
                    var PuertoOrigenExiste = await ObjPuertoOrigen.VerificarPuertoOrigen(objPuertoOrigen.PoCdgo);
                    if (PuertoOrigenExiste == false)
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

        #region Validacion de PuertoOrigen Validar Busquedas ( Filtros)
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
