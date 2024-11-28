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
    public class ValidacionResponsable
    {

       
        AccsoDtos.EstadoHechos.Responsable ObjResponsable = new AccsoDtos.EstadoHechos.Responsable();
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de Responsable , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Responsable objResponsable) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objResponsable.ReNmbre) &&
                    !string.IsNullOrEmpty(objResponsable.ReDscrpcion)
                   )
                {
                    //Validar la llave relacional.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objResponsable.ReCdgoUsrio);
                    if (UsuarioExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        //Retorna valor del TipoMensaje: RelacionNoExiste
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

        #region Validacion de Responsable , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Responsable objResponsable)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                var ResponsableExiste = await ObjResponsable.VerificarResponsable(objResponsable.ReRowid);
                if (ResponsableExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                       objResponsable.ReActvo == true || objResponsable.ReActvo == false
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
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
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
        public async Task<int> ValidarActualizacion(MdloDtos.Responsable objResponsable)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                var ResponsableExiste = await ObjResponsable.VerificarResponsable(objResponsable.ReRowid);
                if (ResponsableExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                    !string.IsNullOrEmpty(objResponsable.ReNmbre) &&
                    !string.IsNullOrEmpty(objResponsable.ReDscrpcion)
                   )
                    {
                        //Validar la llave relacional.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objResponsable.ReCdgoUsrio);
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
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
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

        #region Validacion de Ciudad, Validar Busquedas por IdDepartamento ( Filtros)
        //public async Task<int> ValidarFiltroBusquedasPorIdDepartamento(int IdDepartamento)
        //{
        //    int resultado = 0;
        //    try
        //    {
        //        if (IdDepartamento  != null && IdDepartamento > 0)
        //        {
        //            //Retorna valor del TipoMensaje: TransaccionExitosa
        //            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
        //        }
        //        else
        //        {
        //            //Retorna valor del TipoMensaje: NoAceptaValoresNull
        //            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        //Retorna valor del TipoMensaje: TransaccionIncorrecta
        //        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
        //    }
        //    return resultado;
        //}
        #endregion
    }
}
