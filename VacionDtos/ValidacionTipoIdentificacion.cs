using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// clase para validar el tipo de identificacion.
    /// </summary>
    public  class ValidacionTipoIdentificacion
    {
        AccsoDtos.Parametrizacion.TipoIdentificacion _ObjTipoIdentificacion = new AccsoDtos.Parametrizacion.TipoIdentificacion();

        #region Validacion de tipo de identificacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.TipoIdentificacion ObjTipoIdentificacion)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjTipoIdentificacion.TiCdgo))
                    )
                {
                    //Validar que el codigo/Llave  No exista.
                    var TipouIdentificacionExiste = await _ObjTipoIdentificacion.VerificarTipoIdentificacion(ObjTipoIdentificacion.TiCdgo);
                    if (TipouIdentificacionExiste == true)
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

        #region Validacion de tipo de identificacion , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.TipoIdentificacion ObjTipoIdentificacion)
        {

            int resultado = 0;
            try
            {
                string? Id = ObjTipoIdentificacion.TiCdgo;
                if (!string.IsNullOrEmpty(Id))
                {
                    //Validar que el codigo/Llave  exista.
                    var TipoIdentificacionExiste = await _ObjTipoIdentificacion.VerificarTipoIdentificacion(Id);
                    if (TipoIdentificacionExiste == false)
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

        #region Validacion de tipo de identificacion , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.TipoIdentificacion ObjTipoIdentificacion)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(ObjTipoIdentificacion.TiCdgo))
                {


                    //Validar que el codigo/Llave  No exista.
                    var TipoIdentificacionExiste = await _ObjTipoIdentificacion.VerificarTipoIdentificacion(ObjTipoIdentificacion.TiCdgo);
                    if (TipoIdentificacionExiste == false)
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

        #region Validacion de TipoIdentificacion, Validar Busquedas ( Filtros)
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
