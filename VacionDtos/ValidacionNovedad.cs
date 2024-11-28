using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Crud tipo de Novedad 
    /// </summary>
    public class ValidacionNovedad
    {
        /*AccsoDtos.VisitaMotonave.Novedad _ObjNovedad = new AccsoDtos.VisitaMotonave.Novedad();

        #region Validacion de Novedades , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.VisitaMotonaveNovedad _Novedad)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(_Novedad.VmnRowidVstaMtnve.ToString())) && (_Novedad.VmnRowidVstaMtnve > 0)
                    &&
                    (!string.IsNullOrEmpty(_Novedad.VmnTtlo)) && (_Novedad.VmnTtlo.Length > 0)
                    &&
                    (!string.IsNullOrEmpty(_Novedad.VmnCmntrios)) && (_Novedad.VmnCmntrios.Length > 0)
                    &&
                    (!string.IsNullOrEmpty(_Novedad.VmnCdgoUsrio)) && (_Novedad.VmnCdgoUsrio.Length > 0))
                {
                    //Validar la llave relacional.
                    var ListaConfiguracion = await _ObjNovedad.VerificarNovedadVisita(_Novedad.VmnRowidVstaMtnve);

                    if (ListaConfiguracion == null || ListaConfiguracion== false)
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

        #region Validacion de Novedad,  Validar Busquedas ( Filtros)
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
        #endregion*/
    }
}
