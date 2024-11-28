using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las ciudades.
    /// </summary>
    public class ValidacionClasificacion
    {
        AccsoDtos.EstadoHechos.Clasificacion ObjClasificacion = new AccsoDtos.EstadoHechos.Clasificacion();
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de Clasificacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Clasificacion objClasificacion) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objClasificacion.ClNmbre) &&
                    !string.IsNullOrEmpty(objClasificacion.ClDscrpcion)
                   )
                {
                    //Validar la llave relacional.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objClasificacion.ClCdgoUsrio);
                    if (UsuarioExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de Ciudad , metodo Inactivar
        public async Task<int> ValidarEliminar(MdloDtos.Clasificacion objClasificacion)
        {
            int resultado = 0;
            try
            {
                var ClasificacionExiste = await ObjClasificacion.VerificarClasificacion(objClasificacion.ClRowid);
                if (ClasificacionExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                        objClasificacion.ClActvo == true || objClasificacion.ClActvo == false
                       )
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: NoAceptaValoresNull
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
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

        #region Validacion de Ciudad , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Clasificacion objClasificacion)
        {
            int resultado = 0;
            try
            {
                var ClasificacionExiste = await ObjClasificacion.VerificarClasificacion(objClasificacion.ClRowid);
                if (ClasificacionExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                        !string.IsNullOrEmpty(objClasificacion.ClNmbre) &&
                        !string.IsNullOrEmpty(objClasificacion.ClDscrpcion)
                       )
                    {
                        //Validar la llave relacional.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objClasificacion.ClCdgoUsrio);
                        if (UsuarioExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            //Validar que el codigo/Llave  No exista.
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: NoAceptaValoresNull
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
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

        #region Validacion de clasificacion Validar Busquedas ( Filtros)
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
