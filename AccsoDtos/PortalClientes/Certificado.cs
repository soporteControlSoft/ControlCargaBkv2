using AccsoDtos.VisitaMotonave;
using MdloDtos;
using MdloDtos.IModelos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccsoDtos.PortalClientes
{
    public class Certificado : MdloDtos.IModelos.ICertificado
    {
        //consultar Tercero Certificados
      /*  public async Task<List<VwConsultaCertificado>> ConsultarTerceroCertificado()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.VwConsultaCertificados
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
      */
        //Ingresar Tercero Certificados
        public async Task<TerceroCertificado> IngresarCertificado(TerceroCertificado _certificado)
        {
            var ObjCertificado = new TerceroCertificado();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    ObjCertificado.TcCia = _certificado.TcCia;
                    ObjCertificado.TcCdgo = _certificado.TcCdgo;
                    ObjCertificado.TcRowidTrcro = _certificado.TcRowidTrcro;
                    ObjCertificado.TcCdgoPrdcto = _certificado.TcCdgoPrdcto;
                    ObjCertificado.TcFchaVncmnto = _certificado.TcFchaVncmnto;
                    DateTime dateTime = DateTime.Now;
                    ObjCertificado.TcFchaCrgue = dateTime;
                    //ObjCertificado.TcFchaAprbcion = _certificado.TcFchaAprbcion;
                    //ObjCertificado.TcAprbdo = _certificado.TcAprbdo;
                    //ObjCertificado.TcCdgoUsrioAprbdo = _certificado.TcCdgoUsrioAprbdo;
                    ObjCertificado.TcFchaIncio = _certificado.TcFchaIncio;
                    var res = await _dbContex.TerceroCertificados.AddAsync(ObjCertificado);
                    await _dbContex.SaveChangesAsync();


                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjCertificado;

            }
        }
    }
}
