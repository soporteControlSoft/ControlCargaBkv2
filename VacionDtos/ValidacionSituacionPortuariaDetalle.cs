using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar la SituacionPortuariaDetalle
    /// </summary>
    public class ValidacionSituacionPortuariaDetalle
    {
        AccsoDtos.SituacionPortuaria.SituacionPortuariaDetalle ObjSituacionPortuariaDetalle = new AccsoDtos.SituacionPortuaria.SituacionPortuariaDetalle();
        AccsoDtos.SituacionPortuaria.SituacionPortuaria ObjSituacionPortuaria = new AccsoDtos.SituacionPortuaria.SituacionPortuaria();
        AccsoDtos.Parametrizacion.Tercero ObjTercero = new AccsoDtos.Parametrizacion.Tercero();

        #region Validacion de SituacionPortuariaDetalle , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.SituacionPortuariaDetalle objSituacionPortuariaDetalle)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (objSituacionPortuariaDetalle.SpdRowidStcionPrtria != null && objSituacionPortuariaDetalle.SpdRowidTrcro != null &&
                   objSituacionPortuariaDetalle.SdpCdgoPrdcto != null)
                {  
                    //Validar que el codigo/Llave  No exista.
                    var SituacionPortuariaDetalleExiste = await ObjSituacionPortuariaDetalle.VerificarSituacionPortuariaDetalleRelaciones(objSituacionPortuariaDetalle);
                    if (SituacionPortuariaDetalleExiste == false)
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

        #region Validacion de SituacionPortuariaDetalle , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.SituacionPortuariaDetalle objSituacionPortuariaDetalle_)
        {
            int resultado = 0;
            try
            {
                if(objSituacionPortuariaDetalle_.SpdRowid != null && objSituacionPortuariaDetalle_.SpdRowid >0)
                {
                    //Validar que el codigo/Llave exista.
                    var SituacionPortuariaDetalleExiste = await ObjSituacionPortuariaDetalle.FiltrarSituacionPortuariaDetalleEspecifico(objSituacionPortuariaDetalle_.SpdRowid);
                    if (SituacionPortuariaDetalleExiste.SpdRowidStcionPrtria == null)
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

        #region Validacion de SituacionPortuariaDetalle , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.SituacionPortuariaDetalle objSituacionPortuariaDetalle)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (objSituacionPortuariaDetalle.SpdRowidStcionPrtria != null && objSituacionPortuariaDetalle.SpdRowidTrcro != null &&
                   objSituacionPortuariaDetalle.SdpCdgoPrdcto != null)
                {
                    //Validar que el codigo/Llave No exista.
                    var SituacionPortuariaDetalleExiste = await ObjSituacionPortuariaDetalle.ValidarExistenciaSituacionPortuariaDetalleEspecifico(objSituacionPortuariaDetalle);
                    if (SituacionPortuariaDetalleExiste == false)
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

        #region Validacion de SituacionPortuariaDetalle Validar Busquedas ( Filtros)
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

        #region Validacion de idSituacionPortuaria para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdSituacionPortuaria(int? idSituacionPortuaria)
        {
            int resultado = 0;
            try
            {
                if (idSituacionPortuaria != null && idSituacionPortuaria > 0)
                {
                    //Validar la llave relacional.
                    var ListaSituacionPortuaria = await ObjSituacionPortuaria.FiltrarSituacionPortuariaPorIdSituacion((int)idSituacionPortuaria);

                    if (ListaSituacionPortuaria == null || ListaSituacionPortuaria.Count == 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de dato idSituacionPortuariaDetalle para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdSituacionPortuariaDetalle(int? idSituacionPortuariaDetalle)
        {
            int resultado = 0;
            try
            {
                if (idSituacionPortuariaDetalle != null && idSituacionPortuariaDetalle > 0)
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

        #region Validacion de SituacionPortuariaDetalle , metodo Eliminar
        public async Task<int> ValidarEliminarPorSituacionPortuaria(MdloDtos.SituacionPortuarium objSituacionPortuarium)
        {
            int resultado = 0;
            try
            {
                if (objSituacionPortuarium.SpRowid != null && objSituacionPortuarium.SpRowid > 0)
                {
                    //Validar que el codigo/Llave exista.
                    var SituacionPortuariaDetalleExiste = await ObjSituacionPortuaria.VerificarSituacionPortuaria(objSituacionPortuarium.SpRowid);
                    if (SituacionPortuariaDetalleExiste == false)
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
