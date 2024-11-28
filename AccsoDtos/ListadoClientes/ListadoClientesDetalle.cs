using AccsoDtos.VisitaMotonave;
using MdloDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.ListadoClientes
{
    public class ListadoClientesDetalle: MdloDtos.IModelos.IListadoClientesDetalle
    {
        
        //consultar Listado de Clientes detalle por id Visita
        public async Task<List<VwListadoClientesDetalle>> ListarClientesDetalle(int IdVisita)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.VwListadoClientesDetalles
                                 where p.IdVisita == IdVisita
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        //listar escotillas.
        public async Task<List<string>> ListarMotonaveEscotillas(int IdVisita)
        {
            int a = 0;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                List<string> Escotillas = new List<string>();
                var lst = await (from m in _dbContex.Motonaves
                                 join v in _dbContex.VisitaMotonaves on m.MoCdgo equals v.VmCdgoMtnve
                                 where v.VmRowid == IdVisita select m).ToListAsync();
                foreach (var l in lst) {

                    a =Convert.ToInt32(l.MoCntdadEsctllas);
                }
              
                int i = 1;
                while (i <= a) {

                    Escotillas.Add( i.ToString());
                    i = i + 1;
                }
                _dbContex.Dispose();
                return Escotillas;
            }
        }
        #region Actualizar listado de clientes Detalle
        public async Task<bool> EditarDetalleClientes(MdloDtos.VwListadoClientesDetalle _VwListadoClientesDetalle)
        {
            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //Actualizar en la tabla de la visita motonave bl
                    var VisitaMotonaveBlExiste = await _dbContex.VisitaMotonaveBls.FindAsync(_VwListadoClientesDetalle.IdVisitaBl);
                    
                    if (VisitaMotonaveBlExiste != null)
                    {
                        if ((_VwListadoClientesDetalle.Almacenar + _VwListadoClientesDetalle.Directo) <= (VisitaMotonaveBlExiste.VmblTnldasMtrcas*1000))
                        {
                            VisitaMotonaveBlExiste.VmblEsctlla = _VwListadoClientesDetalle.Ecotilla;
                            VisitaMotonaveBlExiste.VmblKlosCmprmsoDrcto = _VwListadoClientesDetalle.Directo; //Directo
                            VisitaMotonaveBlExiste.VmblKlosCmprmsoAlmcnar = _VwListadoClientesDetalle.Almacenar; //Directo
                            VisitaMotonaveBlExiste.VmblRqstoClnte = _VwListadoClientesDetalle.RequisitoCliente; //Req Cliente
                            VisitaMotonaveBlExiste.VmblRowidsSdes = _VwListadoClientesDetalle.Localizacion; //Sedes
                            _dbContex.VisitaMotonaveBls.Update(VisitaMotonaveBlExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            await _dbContex.SaveChangesAsync();
                            resultado = true;
                        }
                        
                       
                    }

                    _dbContex.Dispose();
                    return true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }
        #endregion



        //consultar Listado de Clientes detalle por id Visita ( Tabla Resumen)
        public async Task<List<MdloDtos.VwResumenListadoCliente>> ListarClientesResumen(int IdVisita)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.VwResumenListadoClientes
                                 where p.IdVisita == IdVisita
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }


        //consultar Listado de Clientes detalle por id Visita ( Grafico Torta)
        public async Task<List<MdloDtos.WmGraficoListadoCliente>> ListarClientesGrafico(int IdVisita)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.WmGraficoListadoClientes
                                 where p.IdVisita == IdVisita
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

        //consultar Listado de Clientes detalle por id Visita (Barco)
        public async Task<List<MdloDtos.BarcoListadoCliente>> ListarClientesBarco(int IdVisita)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.BarcoListadoClientes
                                 where p.IdVisita == IdVisita
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }

    }
        
}
