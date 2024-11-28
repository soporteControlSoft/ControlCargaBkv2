using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Configuraciones Vehicular
    /// </summary>
    public class ValidacionConfiguracionVehicular
    {
        AccsoDtos.Parametrizacion.ConfiguracionVehicular ObjConfiguracionVehicular = new AccsoDtos.Parametrizacion.ConfiguracionVehicular();

        #region Validacion de AuditoriaModulo , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.ConfiguracionVehicular objConfiguracionVehicular)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objConfiguracionVehicular.CvCdgo) && ((objConfiguracionVehicular.CvCdgo.Length > 0))) &&
                   ((!string.IsNullOrEmpty(objConfiguracionVehicular.CvNmbre) && ((objConfiguracionVehicular.CvNmbre.Length > 0)))) &&
                    ((!string.IsNullOrEmpty(objConfiguracionVehicular.CvCdgoCia) && ((objConfiguracionVehicular.CvCdgoCia.Length > 0)))))
                {                     
                    //Validar que el codigo/Llave  No exista.
                    var ConfiguracionVehicularExiste = await ObjConfiguracionVehicular.VerificarConfiguracionVehicular(objConfiguracionVehicular.CvCdgo);
                    if (ConfiguracionVehicularExiste == true)
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

        #region Validacion de ConfiguracionVehicular , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.ConfiguracionVehicular objConfiguracionVehicular_)
        {
            int resultado = 0;
            try
            {
                if (objConfiguracionVehicular_.CvRowid != null)
                {
                    //Validar que el codigo/Llave exista.
                    var ConfiguracionVehicularExiste = await ObjConfiguracionVehicular.VerificarConfiguracionVehicularPorRowdId((int)objConfiguracionVehicular_.CvRowid);
                    if (ConfiguracionVehicularExiste == false)
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

        #region Validacion de ConfiguracionVehicular , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.ConfiguracionVehicular objConfiguracionVehicular)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objConfiguracionVehicular.CvCdgo) && ((objConfiguracionVehicular.CvCdgo.Length > 0))) &&
                  ((!string.IsNullOrEmpty(objConfiguracionVehicular.CvNmbre) && ((objConfiguracionVehicular.CvNmbre.Length > 0)))) &&
                   ((!string.IsNullOrEmpty(objConfiguracionVehicular.CvCdgoCia) && ((objConfiguracionVehicular.CvCdgoCia.Length > 0)))))
                {
                    //Validar que el codigo/Llave No exista.
                    var ConfiguracionVehicularExiste = await ObjConfiguracionVehicular.VerificarConfiguracionVehicular(objConfiguracionVehicular.CvCdgo);
                    if (ConfiguracionVehicularExiste == false)
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

        #region Validacion de ConfiguracionVehicular Validar Busquedas ( Filtros)
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
