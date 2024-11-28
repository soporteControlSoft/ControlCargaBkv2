using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las Unidades Medidas
    /// </summary>
    public class ValidacionUnidadMedida
    {
        AccsoDtos.Parametrizacion.UnidadMedida ObjUnidadMedida = new AccsoDtos.Parametrizacion.UnidadMedida();

        #region Validacion de UnidadMedida , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.UnidadMedidum objUnidadMedida)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objUnidadMedida.UmCdgo)) && (!string.IsNullOrEmpty(objUnidadMedida.UmNmbre)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var UnidadMedidaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objUnidadMedida.UmCdgo);
                    if (UnidadMedidaExiste == true)
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

        #region Validacion de UnidadMedida , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.UnidadMedidum objUnidadMedida_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objUnidadMedida_.UmCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var UnidadMedidaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objUnidadMedida_.UmCdgo);
                    if (UnidadMedidaExiste == false)
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

        #region Validacion de UnidadMedida , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.UnidadMedidum objUnidadMedida)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objUnidadMedida.UmCdgo) && !string.IsNullOrEmpty(objUnidadMedida.UmNmbre) && objUnidadMedida.UmGrnel != null && objUnidadMedida.UmActvo != null)
                {
                    //Validar que el codigo/Llave No exista.
                    var UnidadMedidaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objUnidadMedida.UmCdgo);
                    if (UnidadMedidaExiste == false)
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

        #region Validacion de UnidadMedida Validar Busquedas ( Filtros)
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
