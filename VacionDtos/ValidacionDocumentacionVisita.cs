using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionDocumentacionVisita
    {
        AccsoDtos.VisitaMotonave.DocumentacionVisita ObjDocumentacionVisita = new AccsoDtos.VisitaMotonave.DocumentacionVisita();
        AccsoDtos.Parametrizacion.TipoDocumento ObjTipoDocumento = new AccsoDtos.Parametrizacion.TipoDocumento();
        AccsoDtos.Parametrizacion.Usuario ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();
        AccsoDtos.VisitaMotonave.VisitaMotonave ObjVisitaMotonave = new AccsoDtos.VisitaMotonave.VisitaMotonave();
   


        #region Validacion Motonave asociada a la visita motonave encabezado ( Filtros: codigo usuario y codigo compania)
        public async Task<int> ValidarFiltroBusquedas(string? CodigoUsuario, string CodigoCompania)
        {
            int resultado = 0;
            try
            {
                if (/*((!string.IsNullOrEmpty(CodigoUsuario)) || (CodigoUsuario.Length > 0)) &&*/ ((!string.IsNullOrEmpty(CodigoCompania)) || (CodigoCompania.Length > 0)))
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

        #region Validacion Motonave asociada a la visita motonave encabezado ( Filtros: codigo compania)
        public async Task<int> ValidarFiltroBusquedasPorCompania(string CodigoCompania)
        {
            int resultado = 0;
            try
            {
                if (!string.IsNullOrEmpty(CodigoCompania))
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

        #region Validacion de viista motonave Documento, metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.VisitaMotonaveDocumento OVisitaMotonaveDocumento)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                // Validar los campos Obligatorios.
                if (
                    OVisitaMotonaveDocumento.VmdoRowidVstaMtnve > 0 &&
                    !string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto) &&
                    !string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoRta) &&
                    !string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoUsrioCrgue)
                    )
                {
                    //#1. Validamos que la visita motonave exista
                    bool VisitaMotonaveExiste = await ObjVisitaMotonave.VerificarVisitaMotonave((int)OVisitaMotonaveDocumento.VmdoRowidVstaMtnve);
                    if (!VisitaMotonaveExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }

                    //#2. validamos que el tipo de documento exista
                    if (!validarResultado)
                    {
                        bool TipoDocumentoExiste = await ObjTipoDocumento.VerificarTipoDocumento(OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto);
                        if (!TipoDocumentoExiste)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            validarResultado = true;
                        }
                    }
                    if (!validarResultado)
                    {
                        //#3. validamos que si existe un documento del mismo tipo, está en estado de NULL, C=cargado o R=rechazado para poder cargar un nuevo documento,
                        //En caso contrario que esté en A=aprobado  no permite subir otro documento
                        bool PodemosCargarNuevoDocumento = await ObjDocumentacionVisita.validarPosibilidadNuevoIngresoTipoDocumentoPorVisitaMotonave((int)OVisitaMotonaveDocumento.VmdoRowidVstaMtnve,
                                                                                                                                                    OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto);
                        resultado = PodemosCargarNuevoDocumento ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa :
                                                                  (int)MdloDtos.Utilidades.Constantes.TipoMensaje.DocumentoExistente;
                    }
                }
                else
                {
                    // Retorna valor del TipoMensaje: NoAceptaValoresNull
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
        public async Task<int> ValidarIngresoComentario(int? CodigoVisitaMotonaveDocumento, string codigoUsuario, string comentario)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                // Validar los campos Obligatorios.
                var OVisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveDocumento
                {
                    VmdoRowid = CodigoVisitaMotonaveDocumento
                };

                if (
                    OVisitaMotonaveDocumento.VmdoRowid > 0 &&
                    !string.IsNullOrEmpty(codigoUsuario) &&
                    !string.IsNullOrEmpty(comentario)
                    )
                {
                    //#1. Validamos que la visita motonave documento exista
                    bool VisitaMotonaveDocumentoExiste = await ObjDocumentacionVisita.VerificarVisitaMotonaveDocumento((int)CodigoVisitaMotonaveDocumento);
                    if (!VisitaMotonaveDocumentoExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }

                    //#2. validamos que el usuario exista
                    if (!validarResultado)
                    {
                        bool UsarioExiste = await ObjUsuario.VerificarUsuario(codigoUsuario);
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
                    // Retorna valor del TipoMensaje: NoAceptaValoresNull
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
        public async Task<int> ValidarConsultarComentario(int CodigoVisitaMotonaveDocumento)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                // Validar los campos Obligatorios.
                var OVisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveDocumento
                {
                    VmdoRowid = CodigoVisitaMotonaveDocumento
                };

                if (OVisitaMotonaveDocumento.VmdoRowid > 0)
                {
                    //#1. Validamos que la visita motonave documento exista
                    bool VisitaMotonaveDocumentoExiste = await ObjDocumentacionVisita.VerificarVisitaMotonaveDocumento(CodigoVisitaMotonaveDocumento);
                    if (!VisitaMotonaveDocumentoExiste)
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
                    // Retorna valor del TipoMensaje: NoAceptaValoresNull
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
        public async Task<int> ValidarIngresoPorArchivoEspecifico(MdloDtos.VisitaMotonaveDocumento OVisitaMotonaveDocumento)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;
                // Validar los campos Obligatorios.
                if (OVisitaMotonaveDocumento.VmdoRowidVstaMtnve > 0 && !string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto))
                {
                    //#1. Validamos que la visita motonave exista
                    bool VisitaMotonaveExiste = await ObjVisitaMotonave.VerificarVisitaMotonave((int)OVisitaMotonaveDocumento.VmdoRowidVstaMtnve);
                    if (!VisitaMotonaveExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        validarResultado = true;
                    }

                    //#2. validamos que el tipo de documento exista
                    if (!validarResultado)
                    {
                        bool TipoDocumentoExiste = await ObjTipoDocumento.VerificarTipoDocumento(OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto);
                        if (!TipoDocumentoExiste)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            validarResultado = true;
                        }
                    }
                    if (!validarResultado)
                    {
                        //#3. validamos que si existe un documento del mismo tipo, está en estado de NULL, C=cargado o R=rechazado para poder cargar un nuevo documento,
                        //En caso contrario que esté en A=aprobado  no permite subir otro documento
                        bool PodemosCargarNuevoDocumento = await ObjDocumentacionVisita.validarPosibilidadNuevoIngresoTipoDocumentoPorVisitaMotonave((int)OVisitaMotonaveDocumento.VmdoRowidVstaMtnve,
                                                                                                                                                    OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto);
                        resultado = PodemosCargarNuevoDocumento ? (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa :
                                                                  (int)MdloDtos.Utilidades.Constantes.TipoMensaje.DocumentoExistente;
                    }
                }
                else
                {
                    // Retorna valor del TipoMensaje: NoAceptaValoresNull
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


        #region Validacion de visita motonave Documento, metodo Ingreso
        public async Task<int> ValidarActualizar(MdloDtos.VisitaMotonaveDocumento OVisitaMotonaveDocumento)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (
                    ((OVisitaMotonaveDocumento.VmdoRowidVstaMtnve > 0))
                    && ((!string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto) && ((OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto.Length > 0)))) &&
                    (!string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoEstdo) && (OVisitaMotonaveDocumento.VmdoEstdo.Length > 0)) &&
                    ((!string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoRta) && ((OVisitaMotonaveDocumento.VmdoRta.Length > 0)))) &&
                    ((!string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoUsrioCrgue) && ((OVisitaMotonaveDocumento.VmdoCdgoUsrioCrgue.Length > 0)))) &&
                    ((!string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoUsrioAprbdo) && ((OVisitaMotonaveDocumento.VmdoCdgoUsrioAprbdo.Length > 0))))

                   )
                {
                    //Validar la llave relacional.
                    var DocumentoExiste = await ObjTipoDocumento.VerificarTipoDocumento(OVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto);

                    if (DocumentoExiste == true)
                    {
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

        #region Validacion Id de Visita Motonave
        public async Task<int> ValidarIdVisita(int IdVisita)
        {
            int resultado = 0;
            try
            {
                if (((!string.IsNullOrEmpty(IdVisita.ToString())) || (IdVisita.ToString().Length > 0)))
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


        #region Validacion de visita motonave Documento, metodo Ingreso
        public async Task<int> ValidarActualizarEstadoDocumento(MdloDtos.VisitaMotonaveDocumento OVisitaMotonaveDocumento)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ( OVisitaMotonaveDocumento.VmdoRowid != null && 
                     !string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoEstdo) && 
                     !string.IsNullOrEmpty(OVisitaMotonaveDocumento.VmdoCdgoUsrioAprbdo))
                {
                    if (!(OVisitaMotonaveDocumento.VmdoEstdo.Equals("A") || OVisitaMotonaveDocumento.VmdoEstdo.Equals("R")))
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                    }
                    var UsuarioExiste = await ObjUsuario.FiltrarUsuarioEspecifico(OVisitaMotonaveDocumento.VmdoCdgoUsrioAprbdo);
                    if (UsuarioExiste.Count <= 0)
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    bool VisitaMotonaveDocumentoExiste = await ObjDocumentacionVisita.VerificarVisitaMotonaveDocumento((int)OVisitaMotonaveDocumento.VmdoRowid);
                    if (!VisitaMotonaveDocumentoExiste)
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    List<MdloDtos.VisitaMotonaveDocumento> ObjVisitaMotonaveDocumento = await ObjDocumentacionVisita.ConsultarVisitaMotonaveDocumentoEspecifico((int)OVisitaMotonaveDocumento.VmdoRowid);
                   
                    if (!ObjVisitaMotonaveDocumento[0].VmdoEstdo.Equals("C"))
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.DocumentoAprobado;
                    }

                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;     
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

        #region validar las tarifas correspondientes a la visita motonave documento
        public async Task<int> ValidarActualizarTarifa(List<MdloDtos.VisitaMotonaveDocumento> listado)
        {
            int resultado = 0;
            bool validar = true;
            try
            { 
                foreach (MdloDtos.VisitaMotonaveDocumento item in listado)
                {
                    if (item.VmdoTrm == null || item.VmdoCstoSgroFlte == null || item.VmdoArncelImprtcion == null)
                    {
                        return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                    }
                }
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
            }
            catch (Exception ex)
            {
                return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
        }
        #endregion
    }
}
