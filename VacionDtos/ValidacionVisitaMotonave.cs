using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionVisitaMotonave
    {
        AccsoDtos.VisitaMotonave.VisitaMotonave _ObjVisitaMotonave = new AccsoDtos.VisitaMotonave.VisitaMotonave();
        AccsoDtos.Parametrizacion.Compania _ObjCompania = new AccsoDtos.Parametrizacion.Compania();
        AccsoDtos.Parametrizacion.Motonave _ObjMotonave = new AccsoDtos.Parametrizacion.Motonave(null);
        AccsoDtos.Parametrizacion.Tercero _ObjTercero = new AccsoDtos.Parametrizacion.Tercero();
        AccsoDtos.Parametrizacion.PuertoOrigen _ObjPuertoOrigen = new AccsoDtos.Parametrizacion.PuertoOrigen();
        AccsoDtos.Parametrizacion.TerminalMaritimo _ObjTerminalMaritimo = new AccsoDtos.Parametrizacion.TerminalMaritimo();
        AccsoDtos.SituacionPortuaria.SituacionPortuaria _ObjSituacionPortuaria = new AccsoDtos.SituacionPortuaria.SituacionPortuaria();
        AccsoDtos.Parametrizacion.ZonaCd _ObjZona = new AccsoDtos.Parametrizacion.ZonaCd();

        #region Validacion de viista motonave , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.VisitaMotonave OVisitaMotonave)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(OVisitaMotonave.VmCdgoCia) && !string.IsNullOrEmpty(OVisitaMotonave.VmCdgoMtnve) && OVisitaMotonave.VmRowidStcionPrtria > 0)
                {
                    //Validar la llave relacional.
                    var CompaniaExiste = await _ObjCompania.VerificarCompania(OVisitaMotonave.VmCdgoCia);
                    var MotonaveExiste = await _ObjMotonave.VerificarMotonave(OVisitaMotonave.VmCdgoMtnve);
                    var SituacionExiste = await _ObjSituacionPortuaria.VerificarSituacionPortuaria(OVisitaMotonave.VmRowidStcionPrtria);
                    var visitaMotonaveCrear = await _ObjVisitaMotonave.ValidarCrearVisitaMotonave((int)OVisitaMotonave.VmRowidStcionPrtria);
              
                    if (OVisitaMotonave.VmRowidVnddor != null)
                    {

                        var VendedorExiste = await _ObjTercero.VerificarTerceroPorId(OVisitaMotonave.VmRowidVnddor);
                        if (VendedorExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                    }

                    if (CompaniaExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        if (MotonaveExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {

                            if (SituacionExiste == false)
                            {

                                //Retorna valor del TipoMensaje: RelacionNoExiste
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            }
                            else
                            {
                                if (resultado != (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste) {
                                    if (visitaMotonaveCrear)
                                    {
                                        //Retorna valor del TipoMensaje: TransaccionExitosa
                                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                                    }
                                    else
                                    {
                                        //Retorna valor del TipoMensaje: RelacionNoExiste
                                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                                    }
                                }  
                            }
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

        #region Valores Null para el left join de la visita motonave
        public MdloDtos.VisitaMotonave ValoresVisitaMotonave(MdloDtos.VisitaMotonave item)
        {
            int? VmRowidVnddor = 0;
            int? VmRowidZnaCdAltrno = 0;

            if ((item.VmRowidVnddor.ToString() == null || item.VmRowidVnddor.ToString().Length == 0 || item.VmRowidVnddor.ToString() == "" || (string.IsNullOrWhiteSpace(item.VmRowidVnddor.ToString()))))
            {
                VmRowidVnddor = 0;
            }
            else
            {
                VmRowidVnddor = item.VmRowidVnddor;
            }
           
            if ((item.VmRowidZnaCdAltrno.ToString() == null || item.VmRowidZnaCdAltrno.ToString().Length == 0 || item.VmRowidZnaCdAltrno.ToString() == "" || (string.IsNullOrWhiteSpace(item.VmRowidZnaCdAltrno.ToString()))))
            {
                VmRowidZnaCdAltrno = item.VmRowidZnaCdAltrno;
            }
            else
            {
                VmRowidZnaCdAltrno = 0;
            }
            
            return item;
        }
        #endregion

        #region Validacion de visita Motonave , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.VisitaMotonave OVisitaMotonave)
        {
            int resultado = 0;
            try
            {
                // Validar los campos Obligatorios.
                if (OVisitaMotonave.VmRowid>0 && OVisitaMotonave.VmRowidStcionPrtriaNavigation.SpRowid>0)
                {
                    var SituacionExiste = await _ObjSituacionPortuaria.VerificarSituacionPortuaria(OVisitaMotonave.VmRowidStcionPrtriaNavigation.SpRowid);
                    var VisitaExiste = await _ObjVisitaMotonave.VerificarVisita(OVisitaMotonave.VmRowid);

                    if (!VisitaExiste)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else if (!SituacionExiste)
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
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de visita motonave
        public async Task<int> ValidarExistenciaVisitaMotonave(int codigo)
        {
            int resultado = 0;
            try
            {
                bool validarResultado = false;

                if (codigo > 0)
                {
                    bool VstaMtnveExiste = await _ObjVisitaMotonave.VerificarVisita(codigo);
                    if (!VstaMtnveExiste)
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
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

    }
}
