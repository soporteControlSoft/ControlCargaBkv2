using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Compañia
    /// </summary>
    public class ValidacionCompania
    {
        AccsoDtos.Parametrizacion.Compania ObjCompania = new AccsoDtos.Parametrizacion.Compania(null);

        #region Validacion de AuditoriaMotivo , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.companiaDTO objCompania)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCompania.CiaCdgo) && (!string.IsNullOrEmpty(objCompania.CiaNmbre))) &&
                    ((!string.IsNullOrEmpty(objCompania.CiaIdntfccion))))
                {
                    //Validar que el codigo/Llave  No exista.
                    var CompaniaExiste = await ObjCompania.VerificarCompania(objCompania.CiaCdgo);
                    var IdenticiacionExiste = await ObjCompania.ValidarCompaniaPorIdentificacion(objCompania.CiaIdntfccion);
                    if (CompaniaExiste == true || IdenticiacionExiste ==true)
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

        #region Validacion de Compania , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.companiaDTO objCompania_)
        {
            int resultado = 0;
            try
            {
                if (!string.IsNullOrEmpty(objCompania_.CiaCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var CompaniaExiste = await ObjCompania.VerificarCompania(objCompania_.CiaCdgo);
                    if (CompaniaExiste == false)
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

        #region Validacion de Compania , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.companiaDTO objCompania)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCompania.CiaCdgo) && (!string.IsNullOrEmpty(objCompania.CiaNmbre))) &&
                    ((!string.IsNullOrEmpty(objCompania.CiaIdntfccion) )))
                {
                    //Validar que el codigo/Llave exista.
                    var CompaniaExiste = await ObjCompania.VerificarCompania(objCompania.CiaCdgo);
                    if (CompaniaExiste == false)
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

        #region Validacion de Compania Validar Busquedas ( Filtros)
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
