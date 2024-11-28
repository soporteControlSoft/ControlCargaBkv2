using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los Terminales Maritimos.
    /// </summary>
    public class ValidacionTerminalMaritimo
    {
        AccsoDtos.Parametrizacion.TerminalMaritimo ObjTerminalMaritimo = new AccsoDtos.Parametrizacion.TerminalMaritimo();

        #region Validacion de TerminalMaritimo , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.TerminalMaritimo objTerminalMaritimo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objTerminalMaritimo.TmCdgo)) && (!string.IsNullOrEmpty(objTerminalMaritimo.TmDscrpcion)))
                {
                    //Validar que el codigo/Llave  No exista.
                    var TerminalMaritimoExiste = await ObjTerminalMaritimo.VerificarTerminalMaritimo(objTerminalMaritimo.TmCdgo);
                    if (TerminalMaritimoExiste == true)
                    {
                        //Retorna valor del TipoMensaje: CodigoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        var NombreExiste =  ObjTerminalMaritimo.ValidacionTerminalNombreIngresar(objTerminalMaritimo.TmDscrpcion);
                        //validar si el nombre existe
                        if (NombreExiste == true)
                        {
                            //Retorna el valor del tipo de mensaje: Nombre existe
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                        }
                        else {

                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
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

        #region Validacion de TerminalMaritimo , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.TerminalMaritimo objTerminalMaritimo_)
        {
            int resultado = 0;
            try
            {
                if(!string.IsNullOrEmpty(objTerminalMaritimo_.TmCdgo))
                {
                    //Validar que el codigo/Llave exista.
                    var TerminalMaritimoExiste = await ObjTerminalMaritimo.VerificarTerminalMaritimo(objTerminalMaritimo_.TmCdgo);
                    if (TerminalMaritimoExiste == false)
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

        #region Validacion de TerminalMaritimo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.TerminalMaritimo objTerminalMaritimo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objTerminalMaritimo.TmCdgo)) && (!string.IsNullOrEmpty(objTerminalMaritimo.TmDscrpcion)))
                {
                    //Validar que el codigo/Llave No exista.
                    var TerminalMaritimoExiste = await ObjTerminalMaritimo.VerificarTerminalMaritimo(objTerminalMaritimo.TmCdgo);
                    if (TerminalMaritimoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        var NombreExiste = ObjTerminalMaritimo.ValidacionTerminalNombreActualizar(objTerminalMaritimo);
                        //validar si el nombre existe
                        if (NombreExiste == true)
                        {
                            //Retorna el valor del tipo de mensaje: Nombre existe
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                        }
                        else
                        {

                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
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

        #region Validacion de TerminalMaritimo Validar Busquedas ( Filtros)
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
