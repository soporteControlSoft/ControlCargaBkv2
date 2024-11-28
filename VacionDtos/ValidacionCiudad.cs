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
    public class ValidacionCiudad
    {

        AccsoDtos.Parametrizacion.Departamento ObjDepartamento = new AccsoDtos.Parametrizacion.Departamento();
        AccsoDtos.Parametrizacion.Ciudad ObjCiudad = new AccsoDtos.Parametrizacion.Ciudad();

        #region Validacion de Ciudad , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Ciudad objCiudad) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCiudad.CiCdgo) && (objCiudad.CiCdgo.Length > 0)) && ((!string.IsNullOrEmpty(objCiudad.CiNmbre) && ((objCiudad.CiNmbre.Length > 0)))) &&
                   ((objCiudad.CiRowidDprtmnto > 0)))
                {
                    //Validar la llave relacional.
                    var departamentoExiste = await ObjDepartamento.VerificarDepartamentoId(objCiudad.CiRowidDprtmnto);
                    if (departamentoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var CiudadExiste = await ObjCiudad.VerificarCiudad(objCiudad.CiCdgo);
                        if (CiudadExiste == true)
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

        #region Validacion de Ciudad , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Ciudad objCiudad_)
        {
            int resultado = 0;
            try
            {
                if(objCiudad_.CiRowid != null)
                {
                    //Validar que el codigo/Llave  exista.
                    var CiudadExiste = await ObjCiudad.VerificarCiudadPorRowId((int)objCiudad_.CiRowid);
                    if (CiudadExiste == false)
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

        #region Validacion de Ciudad , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Ciudad objCiudad)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objCiudad.CiCdgo) && (objCiudad.CiCdgo.Length > 0)) && ((!string.IsNullOrEmpty(objCiudad.CiNmbre) && ((objCiudad.CiNmbre.Length > 0)))) &&
                   ((objCiudad.CiRowidDprtmnto > 0)))
                {
                    //Validar la llave relacional.
                    var DepartamentoExiste = await ObjDepartamento.VerificarDepartamentoId(objCiudad.CiRowidDprtmnto);
                    if (DepartamentoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var CiudadExiste = await ObjCiudad.VerificarCiudad(objCiudad.CiCdgo);
                        if (CiudadExiste == false)
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

        #region Validacion de Ciudad Validar Busquedas ( Filtros)
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
        public async Task<int> ValidarFiltroBusquedasPorIdDepartamento(int IdDepartamento)
        {
            int resultado = 0;
            try
            {
                if (IdDepartamento  != null && IdDepartamento > 0)
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
