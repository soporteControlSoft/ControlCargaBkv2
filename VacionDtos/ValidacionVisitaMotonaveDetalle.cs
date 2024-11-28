using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar la Visita Motonave Detalle
    /// </summary>
    public class ValidacionVisitaMotonaveDetalle
    {
        AccsoDtos.VisitaMotonave.VisitaMotonaveDetalle ObjVisitaMotonaveDetalle = new AccsoDtos.VisitaMotonave.VisitaMotonaveDetalle();
        AccsoDtos.VisitaMotonave.VisitaMotonave ObjVisitaMotonave = new AccsoDtos.VisitaMotonave.VisitaMotonave();
        AccsoDtos.Parametrizacion.Tercero ObjTercero = new AccsoDtos.Parametrizacion.Tercero();

        #region Validacion de VisitaMotonaveDetalle , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.VisitaMotonaveDetalle objVisitaMotonaveDetalle_)
        {
            int resultado = 0;
            try
            {
                if(objVisitaMotonaveDetalle_.VmdRowid != null && objVisitaMotonaveDetalle_.VmdRowid > 0)
                {
                    //Validar que el codigo/Llave exista.
                    var VisitaMotonaveDetalleExiste = await ObjVisitaMotonaveDetalle.FiltrarVisitaMotonaveDetalleEspecifico(objVisitaMotonaveDetalle_.VmdRowid);
                    if (VisitaMotonaveDetalleExiste.Count ==0)
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

        #region Validacion de VisitaMotonaveDetalle , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.VisitaMotonaveDetalle objVisitaMotonaveDetalle)
        {
            try
            {
                if( objVisitaMotonaveDetalle.VmdRowid < 0 || string.IsNullOrEmpty(objVisitaMotonaveDetalle.VmdRowid.ToString()) ||
                    objVisitaMotonaveDetalle.VmdRowidAgnciaAdna < 0 || string.IsNullOrEmpty(objVisitaMotonaveDetalle.VmdRowidAgnciaAdna.ToString()))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                var VisitaMotonaveDetalleExiste = await ObjVisitaMotonaveDetalle.FiltrarVisitaMotonaveDetalleEspecifico(objVisitaMotonaveDetalle.VmdRowid);
                var AgenciaAduanaExiste = await ObjTercero.VerificarTerceroEsAgenciaAduanaPorId(objVisitaMotonaveDetalle.VmdRowidAgnciaAdna);

                if (VisitaMotonaveDetalleExiste.Count == 0 || AgenciaAduanaExiste == false)
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de VisitaMotonaveDetalle Validar Busquedas ( Filtros)
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

        #region Validacion de filtro de busquedas por IdVisitaMotonave para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdVisitaMotonave(int? idVisitaMotonave)
        {
            int resultado = 0;
            try
            {
                if (idVisitaMotonave != null && idVisitaMotonave > 0)
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

        #region Validacion de dato idVisitaMotonaveDetalle para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdVisitaMotonaveDetalle(int? idVisitaMotonaveDetalle)
        {
            int resultado = 0;
            try
            {
                if (idVisitaMotonaveDetalle != null && idVisitaMotonaveDetalle > 0)
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


        #region Validacion de VisitaMotonaveDetalle , metodo Eliminar
        public async Task<int> ValidarEliminarPorVisitaMotonave(MdloDtos.VisitaMotonave objVisitaMotonave)
        {
            int resultado = 0;
            try
            {
                if (objVisitaMotonave.VmRowid != null && objVisitaMotonave.VmRowid > 0)
                {
                    //Validar que el codigo/Llave exista.

                    var VisitaMotonaveExiste = await ObjVisitaMotonave.VerificarVisitaMotonave(objVisitaMotonave.VmRowid);
                    if (VisitaMotonaveExiste == false)
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
    }
}
