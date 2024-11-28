using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para validar el grupo tercero.
    /// </summary>
    public class ValidacionGrupoTercero
    {
        AccsoDtos.Parametrizacion.GrupoTercero _ObjGrupoTercero = new AccsoDtos.Parametrizacion.GrupoTercero();

        #region Validacion de grupo Tercero , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.GrupoTercero ObjGrupoTercero)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjGrupoTercero.GtCdgo)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var GrupoTerceroExiste = await _ObjGrupoTercero.VerificarGrupoTercero(ObjGrupoTercero.GtCdgo);
                    if (GrupoTerceroExiste == true)
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

        #region Validacion de Grupo tercero , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.GrupoTercero ObjGrupoTercero)
        {
            int resultado = 0;
            try
            {
                string? Id = ObjGrupoTercero.GtCdgo;
                if (!string.IsNullOrEmpty(Id))
                {
                    //Validar que el codigo/Llave  exista.
                    var GrupoTerceroExiste = await _ObjGrupoTercero.VerificarGrupoTercero(Id);
                    if (GrupoTerceroExiste == false)
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

        #region Validacion de grupo Tercero , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.GrupoTercero ObjGrupoTercero)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(ObjGrupoTercero.GtCdgo))
                 {
                    //Validar que el codigo/Llave  No exista.
                    var GrupoTerceroExiste = await _ObjGrupoTercero.VerificarGrupoTercero(ObjGrupoTercero.GtCdgo);
                    if (GrupoTerceroExiste == false)
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

        #region Validacion de Filtro GrupoTercero para realizar Busquedas ( Filtros)
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
