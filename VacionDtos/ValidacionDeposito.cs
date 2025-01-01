using MdloDtos;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionDeposito
    {
        AccsoDtos.PortalClientes.Deposito _ObjDeposito = new AccsoDtos.PortalClientes.Deposito();
        AccsoDtos.Parametrizacion.Compania _ObjCompania = new AccsoDtos.Parametrizacion.Compania();
        AccsoDtos.Parametrizacion.Tercero _ObjTercero = new AccsoDtos.Parametrizacion.Tercero();
        AccsoDtos.Parametrizacion.Producto _ObjProducto = new AccsoDtos.Parametrizacion.Producto();
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        #region Validacion de creación Deposito , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Deposito ObjDeposito)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(ObjDeposito.DeCia) && ObjDeposito.DeRowidTrcro > 0 &&
                    !string.IsNullOrEmpty(ObjDeposito.DeCdgoPrdcto) && !string.IsNullOrEmpty(ObjDeposito.DeCdgoUsrioCrea))
                {
                    //Validar la llave relacional.
                    var CompaniaExiste = await _ObjCompania.VerificarCompania(ObjDeposito.DeCia);
                    var TerceroExiste = await _ObjTercero.VerificarTerceroPorId(ObjDeposito.DeRowidTrcro);
                    var ProductoExiste = await _ObjProducto.VerificarProducto(ObjDeposito.DeCdgoPrdcto);
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(ObjDeposito.DeCdgoUsrioCrea);

                    if (CompaniaExiste == false || TerceroExiste == false || ProductoExiste == false || UsuarioExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else 
                    {
                        //validamos que exista al menos un Bls para crear el deposito
                        List<MdloDtos.DepositoBl> listaDepositoBl = (List<DepositoBl>)ObjDeposito.DepositoBls;
                        if (listaDepositoBl != null)
                        {
                            bool validarDisponibilidad = await _ObjDeposito.validarDisponibilidadAsociacionBlsADeposito(listaDepositoBl);
                            if (!validarDisponibilidad)//todos los Bls no se encuentran disponibles
                            {
                                //No hay Bls cargados para proceder con la creación de deposito
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.BLsNoDisponible;
                            }
                            else 
                            {
                                bool validarMismoProducto = await _ObjDeposito.validarProductosEnBLs(listaDepositoBl);
                                if (!validarMismoProducto) //Hay Bls asociados con diferentes productos
                                {
                                    //Existen Bls que tienen distintos productos
                                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.BLsProductosDiferentes;
                                }
                                else 
                                {
                                    bool validarCerificadoVigente = await _ObjDeposito.validarProductosSustanciaControlada(listaDepositoBl);
                                    resultado = (!validarCerificadoVigente) ?
                                                (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CertificadoTerceroNoVigente:
                                                (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                                }
                            }
                        }
                        else 
                        {
                            //No hay Bls cargados para proceder con la creación de deposito
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }   
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de creación Deposito , metodo Ingreso
        public async Task<int> ValidarIngresoDpstoCmun(MdloDtos.Deposito ObjDeposito)
        {
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(ObjDeposito.DeCia)  &&
                    !string.IsNullOrEmpty(ObjDeposito.DeCdgoPrdcto) && !string.IsNullOrEmpty(ObjDeposito.DeCdgoUsrioCrea))
                {
                    //Validar la llave relacional.
                    var CompaniaExiste = await _ObjCompania.VerificarCompania(ObjDeposito.DeCia);
                    var ProductoExiste = await _ObjProducto.VerificarProducto(ObjDeposito.DeCdgoPrdcto);
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(ObjDeposito.DeCdgoUsrioCrea);

                    if (CompaniaExiste == false  || ProductoExiste == false || UsuarioExiste == false)
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa; 
                    }
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region Validacion de metodo de ingreso de comentario en deposito
        public async Task<int> ValidarIngresoComentario(int? codigoDeposito, string codigoUsuario, string comentario)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                if (
                    codigoDeposito > 0 &&
                    !string.IsNullOrEmpty(codigoUsuario) &&
                    !string.IsNullOrEmpty(comentario)
                    )
                {
                    //#1, validamos que exista el deposito
                    bool DepositoExisteExiste = await _ObjDeposito.VerificarDeposito((int)codigoDeposito);
                    if (!DepositoExisteExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }

                    //#2. validamos que el usuario exista
                    if (!validarResultado)
                    {
                        bool UsarioExiste = await _ObjUsuario.VerificarUsuario(codigoUsuario);
                        if (!UsarioExiste)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            validarResultado = true;
                        }
                    }
                    if (!validarResultado)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de metodo de ingreso de comentario en deposito
        public async Task<int> ValidarIngresoObservacion(int? codigoDeposito, string codigoUsuario, string comentario)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                if (
                    codigoDeposito > 0 &&
                    !string.IsNullOrEmpty(codigoUsuario) &&
                    !string.IsNullOrEmpty(comentario)
                    )
                {
                    //#1, validamos que exista el deposito
                    bool DepositoExisteExiste = await _ObjDeposito.VerificarDeposito((int)codigoDeposito);
                    if (!DepositoExisteExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }

                    //#2. validamos que el usuario exista
                    if (!validarResultado)
                    {
                        bool UsarioExiste = await _ObjUsuario.VerificarUsuario(codigoUsuario);
                        if (!UsarioExiste)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            validarResultado = true;
                        }
                    }
                    if (!validarResultado)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de viista motonave Documento, metodo Ingreso
        public async Task<int> ValidarConsultarComentario(int codigo)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;

                if (codigo > 0)
                {
                    bool DepositoExiste = await _ObjDeposito.VerificarDeposito(codigo);
                    if (!DepositoExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }
                    if (!validarResultado)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
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

        #region Validacion de viista motonave Documento, metodo Ingreso
        public async Task<int> ValidarExistenciaDeposito(int codigo)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;

                if (codigo > 0)
                {
                    bool DepositoExiste = await _ObjDeposito.VerificarDeposito(codigo);
                    if (!DepositoExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }
                    if (!validarResultado)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
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

        #region Validacion de viista motonave Documento, metodo Ingreso
        public async Task<int> ValidarDepositoParaCerrar(int codigo)
        {
            int resultado = 0;
            try
            {
                if (codigo > 0)
                {
                    bool DepositoAbierto = await _ObjDeposito.VerificarDepositoParaCerrar(codigo);
                    if (!DepositoAbierto)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else 
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
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

        

        #region valida que un deposito esté en estado de cargado
        public async Task<int> ValidarEstadoDeposito(MdloDtos.Deposito objDeposito)
        {
            try
            {
                if (objDeposito.DeRowid > 0)
                {
                    bool estadoCreacionDeposito = await _ObjDeposito.VerificarDepositoEnEstadoCreacion((int)objDeposito.DeRowid);
                    return estadoCreacionDeposito ?   (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa 
                                                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste; 
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion
        #region valida que un deposito esté en estado de cargado
        public async Task<int> ValidarEstadoAprobadoDeposito(MdloDtos.Deposito objDeposito)
        {
            try
            {
                if (objDeposito.DeRowid > 0)
                {
                    bool estadoCreacionDeposito = await _ObjDeposito.VerificarDepositoEnEstadoAprobado((int)objDeposito.DeRowid);
                    return estadoCreacionDeposito ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                                                    : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion

        #region valida que un deposito esté en estado de cargado
        public async Task<int> VerificarExistenciaDeposito(MdloDtos.Deposito objDeposito)
        {
            try
            {
                if (objDeposito.DeRowid > 0)
                {
                    bool existeDpsto = await _ObjDeposito.VerificarDeposito((int)objDeposito.DeRowid);
                    return existeDpsto ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa
                                         : (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                else
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion
    }
}
