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
    public class ListadoClientesEncabezado : MdloDtos.IModelos.IListadoClientesEncabezado
    {
        
        //consultar Listado de Clientes por id Visita
        public async Task<List<VwListadoClientesEncabezado>> ListarClientesEncabezado(int IdVisita)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.VwListadoClientesEncabezados
                                 where p.IdVisita == IdVisita
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        
        #region Actualizar listado de clientes encabezado
        public async Task<bool> EditarEncabezadoClientes(MdloDtos.VwListadoClientesEncabezado _VwListadoClientesEncabezado)
        {
            bool resultado = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //Actualizar en la tabla de la visita 
                    var VisitaMotonaveExiste = await _dbContex.VisitaMotonaves.FindAsync(_VwListadoClientesEncabezado.IdVisita);
                    if (VisitaMotonaveExiste != null)
                    {
                        VisitaMotonaveExiste.VmRowidVnddor = _VwListadoClientesEncabezado.IdTercero;
                        VisitaMotonaveExiste.VmRowidsPrstdresSrvcios = _VwListadoClientesEncabezado.CodPrestadoServicio; //prestadores del servicio
                        _dbContex.VisitaMotonaves.Update(VisitaMotonaveExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                        resultado = true;
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

    }
}
