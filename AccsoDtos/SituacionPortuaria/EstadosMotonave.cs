using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.SituacionPortuaria
{
    public class EstadosMotonave:MdloDtos.IModelos.IEstadosMotonave
    {
        #region Consultar todos los datos de Sede mediante un parametro Codigo de Compania
        public async Task<List<MdloDtos.EstadoMotonave>> ListarEstadoMotonave()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.EstadoMotonaves
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consulta los datos de EstadoMotonave mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.EstadoMotonave>> FiltrarEstadoMotonaveEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.EstadoMotonaves
                                 where m.EmCdgo == Codigo
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion
    }
}
