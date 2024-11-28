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
    public class ValidacionEquipo
    {

       
        AccsoDtos.EstadoHechos.Equipo ObjEquipo = new AccsoDtos.EstadoHechos.Equipo();
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de Equipo, metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Equipo objEquipo) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objEquipo.EqNmbre) &&
                    !string.IsNullOrEmpty(objEquipo.EqDscrpcion)
                   )
                {
                    //Validar la llave relacional.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objEquipo.EqCdgoUsrio);
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

        #region Validacion de equipo , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Equipo objEquipo)
        {
            int resultado = 0;
            try
            {
                var EquipoExiste = await ObjEquipo.VerificarEquipo(objEquipo.EqRowid);
                //Validar si existe el equipo
                if (EquipoExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                         objEquipo.EqActvo == true || objEquipo.EqActvo == false
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

        #region Validacion de Equipo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Equipo objEquipo)
        {
            int resultado = 0;
            try
            {
                var EquipoExiste = await ObjEquipo.VerificarEquipo(objEquipo.EqRowid);
                //Validar si existe el equipo
                if (EquipoExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                        !string.IsNullOrEmpty(objEquipo.EqNmbre) &&
                        !string.IsNullOrEmpty(objEquipo.EqDscrpcion)
                       )
                    {
                        //Validar la llave relacional.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objEquipo.EqCdgoUsrio);
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

        #region Validacion de Equipo Validar Busquedas ( Filtros)
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
