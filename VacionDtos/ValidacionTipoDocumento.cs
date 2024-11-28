using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Validar el crud del tipo de documento 
    /// </summary>
    public class ValidacionTipoDocumento
    {
       AccsoDtos.Parametrizacion.TipoDocumento _TipoDocumento = new AccsoDtos.Parametrizacion.TipoDocumento();

        #region Validacion de vehiculos , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.TipoDocumento ObjTipoDocumento)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjTipoDocumento.TdCdgo)) && (ObjTipoDocumento.TdCdgo.Length > 0)
                    &&
                    (!string.IsNullOrEmpty(ObjTipoDocumento.TdNmbre)) && (ObjTipoDocumento.TdNmbre.Length > 0)
                    &&
                    (!string.IsNullOrEmpty(ObjTipoDocumento.TdOrgen)) && (ObjTipoDocumento.TdOrgen.Length > 0)
                    &&
                    (!string.IsNullOrEmpty(ObjTipoDocumento.TdNmbreAAsgnar)) && (ObjTipoDocumento.TdNmbreAAsgnar.Length > 0)
                    )
                {
                    
                        //Validar que el codigo/Llave  No exista.
                        var VehiculoExiste = await _TipoDocumento.VerificarTipoDocumento(ObjTipoDocumento.TdCdgo);
                        if (VehiculoExiste == true)
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

        #region Validacion de Tipo Documento , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.TipoDocumento ObjTipoDocumento)
        {
            int resultado = 0;
            try
            {
                string? Id = ObjTipoDocumento.TdCdgo;
                if (!string.IsNullOrEmpty(Id))
                {
                    //Validar que el codigo/Llave  exista.
                    var VehiculoExiste = await _TipoDocumento.VerificarTipoDocumento(Id);
                    if (VehiculoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: TransaccionIncorrecta
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

        #region Validacion de Tipo Vehiculo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.TipoDocumento ObjTipoDocumento)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjTipoDocumento.TdCdgo)) && (ObjTipoDocumento.TdCdgo.Length > 0)
                   &&
                   (!string.IsNullOrEmpty(ObjTipoDocumento.TdNmbre)) && (ObjTipoDocumento.TdNmbre.Length > 0)
                   &&
                   (!string.IsNullOrEmpty(ObjTipoDocumento.TdOrgen)) && (ObjTipoDocumento.TdOrgen.Length > 0)
                   &&
                   (!string.IsNullOrEmpty(ObjTipoDocumento.TdNmbreAAsgnar)) && (ObjTipoDocumento.TdNmbreAAsgnar.Length > 0)
                   )
                {
                    
                        //Validar que el codigo/Llave  No exista.
                        var VehiculoExiste = await _TipoDocumento.VerificarTipoDocumento(ObjTipoDocumento.TdCdgo);
                        if (VehiculoExiste == false)
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

        #region Validacion de vehiculo,  Validar Busquedas ( Filtros)
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
