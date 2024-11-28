using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Auditoria
{
    public class SolicitudAutorizacion:MdloDtos.IModelos.ISolicitudAutorizacion
    {
        #region Ingresar datos a la entidad Solicitud Autorizacion
        public async Task<MdloDtos.AutorizacionRemotum> IngresarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum _AutorizacionRemotum)
        {
            var ObjAutorizacionRemotum = new MdloDtos.AutorizacionRemotum();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    ObjAutorizacionRemotum.ArCdgoCia = _AutorizacionRemotum.ArCdgoCia;
                    ObjAutorizacionRemotum.ArIdntfcdor = _AutorizacionRemotum.ArIdntfcdor;
                    ObjAutorizacionRemotum.ArCdgoUsrioSlcta = _AutorizacionRemotum.ArCdgoUsrioSlcta;
                    ObjAutorizacionRemotum.ArEqpoSlcta = _AutorizacionRemotum.ArEqpoSlcta;
                    ObjAutorizacionRemotum.ArDtlle = _AutorizacionRemotum.ArDtlle;
                    ObjAutorizacionRemotum.ArCdgoPrmso = _AutorizacionRemotum.ArCdgoPrmso;
                    ObjAutorizacionRemotum.ArFchaSlctud = _AutorizacionRemotum.ArFchaSlctud;
                    ObjAutorizacionRemotum.ArCnfrmda = _AutorizacionRemotum.ArCnfrmda;
                    ObjAutorizacionRemotum.ArAutrzda = _AutorizacionRemotum.ArAutrzda;
                    ObjAutorizacionRemotum.ArObsrvcnes = _AutorizacionRemotum.ArObsrvcnes;
                    var res = await _dbContex.AutorizacionRemota.AddAsync(ObjAutorizacionRemotum);
                    await _dbContex.SaveChangesAsync();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjAutorizacionRemotum;
            }

        }
        #endregion

        #region Actualizar Solicitud Autorizacion por el objeto _SolicitudAutorizacion
        public async Task<MdloDtos.AutorizacionRemotum> EditarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum _AutorizacionRemotum)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.AutorizacionRemotum AutorizacionRemotumExiste = await _dbContex.AutorizacionRemota.FindAsync(_AutorizacionRemotum.ArRowid);
                    if (AutorizacionRemotumExiste != null)
                    {

                        AutorizacionRemotumExiste.ArCdgoCia = _AutorizacionRemotum.ArCdgoCia;
                        AutorizacionRemotumExiste.ArIdntfcdor = _AutorizacionRemotum.ArIdntfcdor;
                        AutorizacionRemotumExiste.ArCdgoUsrioSlcta = _AutorizacionRemotum.ArCdgoUsrioSlcta;
                        AutorizacionRemotumExiste.ArEqpoSlcta = _AutorizacionRemotum.ArEqpoSlcta;
                        AutorizacionRemotumExiste.ArDtlle = _AutorizacionRemotum.ArDtlle;
                        AutorizacionRemotumExiste.ArCdgoPrmso = _AutorizacionRemotum.ArCdgoPrmso;
                        AutorizacionRemotumExiste.ArFchaSlctud = _AutorizacionRemotum.ArFchaSlctud;
                        AutorizacionRemotumExiste.ArCnfrmda = _AutorizacionRemotum.ArCnfrmda;
                        AutorizacionRemotumExiste.ArAutrzda = _AutorizacionRemotum.ArAutrzda;
                        AutorizacionRemotumExiste.ArFchaAutrza = _AutorizacionRemotum.ArFchaAutrza;
                        AutorizacionRemotumExiste.ArCdgoUsrioAutrza = _AutorizacionRemotum.ArCdgoUsrioAutrza;
                        AutorizacionRemotumExiste.ArEqpoAutrza = _AutorizacionRemotum.ArEqpoAutrza;
                        AutorizacionRemotumExiste.ArObsrvcnes = _AutorizacionRemotum.ArObsrvcnes;
                        _dbContex.Entry(AutorizacionRemotumExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return AutorizacionRemotumExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion


        #region Confirmacion de Solicitud a la entidad Solicitud Autorizacion
        public async Task<MdloDtos.AutorizacionRemotum> ConfirmarSolicitudAutorizacion(MdloDtos.AutorizacionRemotum _AutorizacionRemotum)
        {
            var ObjAutorizacionRemotum = new MdloDtos.AutorizacionRemotum();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    ObjAutorizacionRemotum.ArCdgoCia = _AutorizacionRemotum.ArCdgoCia;
                    ObjAutorizacionRemotum.ArIdntfcdor = _AutorizacionRemotum.ArIdntfcdor;
                    
                    ObjAutorizacionRemotum.ArDtlle = _AutorizacionRemotum.ArDtlle;
                    ObjAutorizacionRemotum.ArCdgoPrmso = _AutorizacionRemotum.ArCdgoPrmso;
                    ObjAutorizacionRemotum.ArCnfrmda = _AutorizacionRemotum.ArCnfrmda;
                    ObjAutorizacionRemotum.ArAutrzda = _AutorizacionRemotum.ArAutrzda;
                    ObjAutorizacionRemotum.ArFchaAutrza = _AutorizacionRemotum.ArFchaAutrza;
                    ObjAutorizacionRemotum.ArCdgoUsrioAutrza = _AutorizacionRemotum.ArCdgoUsrioAutrza;
                    ObjAutorizacionRemotum.ArEqpoAutrza = _AutorizacionRemotum.ArEqpoAutrza;
                    ObjAutorizacionRemotum.ArObsrvcnes = _AutorizacionRemotum.ArObsrvcnes;
                    var res = await _dbContex.AutorizacionRemota.AddAsync(ObjAutorizacionRemotum);
                    await _dbContex.SaveChangesAsync();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjAutorizacionRemotum;
            }

        }
        #endregion

    }
}
