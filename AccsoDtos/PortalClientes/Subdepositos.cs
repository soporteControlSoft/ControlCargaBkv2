using AccsoDtos.VisitaMotonave;
using MdloDtos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccsoDtos.PortalClientes
{
    public class Subdepositos : MdloDtos.IModelos.ISubdepositos
    {
        //Consultar Depositos segun filtros iniciales
        public async Task<List<WvConsultaDepositosSubdeposito>> ConsultarDepositosSegunSubDeposito(int Visita, string CodigoProducto,string codigoUsuario)
        {
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.WvConsultaDepositosSubdepositos
                                 where p.IdVisita == Visita && p.CodigoProducto==CodigoProducto &&  p.CodigoUsuario== codigoUsuario
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        //consultar productos para filtrar y tener los depositos
        public async Task<List<VwConsultarProductosSubdeposito>> ConsultarProductoSubDeposito(int idvisita)
        {

            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.VwConsultarProductosSubdepositos
                                 where p.VmRowid == idvisita
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        //ingresar datos del sub deposito
        public async Task<List<VwConsultarSubdeposito>> ConsultarSubDeposito(string codigoDepositoPadre)
        {

            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                var lst = await (from p in _dbContex.VwConsultarSubdepositos
                                 where p.CodigoPadre == codigoDepositoPadre
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        public DbSet<MdloDtos.Sp_IngresarSubdepositos> sp_Ingresar_SolicitudRetiro { get; set; }
        // ingreso de datos a la entidad Depositos como si fuera un sub deposito
        public async Task<MdloDtos.Deposito> IngresarSubDeposito(MdloDtos.Deposito _subdeposito)
        {
            var ObjSubDeposito = new MdloDtos.Deposito();
            using (CcVenturaContext _dbContex = new CcVenturaContext())
            {
                try
                {
                    string? DeCia = _subdeposito.DeCia;
                    int? DeCntdad = _subdeposito.DeCntdad;
                    int? DeKlos = _subdeposito.DeKlos;
                    int? DeRowidTrcro = _subdeposito.DeRowidTrcro;
                    int? DeRowidSdeDspcho = _subdeposito.DeRowidSdeDspcho;
                    string? DeCdgoDpstoPdre = _subdeposito.DeCdgoDpstoPdre;
                    string? DeCdgoPrdcto = _subdeposito.DeCdgoPrdcto;
                    string? DeCdgoUsrioCrea = _subdeposito.DeCdgoUsrioCrea;

 

                    var res = await _dbContex.IngresarSubdepositos(DeCia, DeCntdad, DeKlos, DeRowidTrcro, DeRowidSdeDspcho,DeCdgoDpstoPdre ,
                       DeCdgoPrdcto, DeCdgoUsrioCrea);

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSubDeposito;

            }
        }

        #region Actualizar Deposito para tener el comentario
        public async Task<MdloDtos.Deposito> IngresarComentario(MdloDtos.Deposito _subdeposito)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Deposito DepositoExiste = await _dbContex.Depositos.FindAsync(_subdeposito.DeRowid);
                    if (DepositoExiste != null)
                    {
                        DepositoExiste.DeCmntrios = _subdeposito.DeCmntrios;
                        _dbContex.Entry(DepositoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return DepositoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion
    }
}
