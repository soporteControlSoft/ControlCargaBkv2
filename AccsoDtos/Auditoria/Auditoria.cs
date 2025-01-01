using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Auditoria
{
    public class Auditoria : MdloDtos.IModelos.IAuditoria
    {
        #region Ingresar datos a la entidad Auditoria
        public async Task<MdloDtos.Auditorium> IngresarAuditoria(MdloDtos.Auditorium _Auditorium)
    {
        var ObjAuditorium = new MdloDtos.Auditorium();
        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        {
            try
            {

                ObjAuditorium.AuCdgoCia = _Auditorium.AuCdgoCia;
                ObjAuditorium.AuCdgoMtvo = _Auditorium.AuCdgoMtvo;
                ObjAuditorium.AuFcha = _Auditorium.AuFcha;
                ObjAuditorium.AuDtlle = _Auditorium.AuDtlle;
                ObjAuditorium.AuCdgoUsrio = _Auditorium.AuCdgoUsrio;
                ObjAuditorium.AuEqpo = _Auditorium.AuEqpo;
                ObjAuditorium.AuRowidRgstro = _Auditorium.AuRowidRgstro;
                ObjAuditorium.AuCdgoUsrioAutrza = _Auditorium.AuCdgoUsrioAutrza;
                ObjAuditorium.AuEqpoAutrza = _Auditorium.AuEqpoAutrza;
                    //ObjAuditorium.AuLlve1 = _Auditorium.AuLlve1;
                    //ObjAuditorium.AuLlve2 = _Auditorium.AuLlve2;
                    //ObjAuditorium.AuRowidRgstroAutrza = _Auditorium.AuRowidRgstroAutrza;
                    ObjAuditorium.AuRzon = _Auditorium.AuRzon;
                ObjAuditorium.AuObsrvcnes = _Auditorium.AuObsrvcnes;
                var res = await _dbContex.Auditoria.AddAsync(ObjAuditorium);
                await _dbContex.SaveChangesAsync();


            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            _dbContex.Dispose();
            return ObjAuditorium;
        }

    }
    #endregion
    }
}