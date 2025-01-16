using AutoMapper;
using MdloDtos.DTO;
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
        private readonly IMapper _mapper;

        public EstadosMotonave(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Consultar todos los datos estado de motonaves
        public async Task<List<MdloDtos.DTO.EstadoMotonaveDTO>> ListarEstadoMotonave()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.EstadoMotonaves
                                 select p).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<EstadoMotonaveDTO>>(lst) : new List<EstadoMotonaveDTO>();
                return result;
            }

        }
        #endregion

        #region Consulta los datos de EstadoMotonave mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.DTO.EstadoMotonaveDTO>> FiltrarEstadoMotonaveEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.EstadoMotonaves
                                 where m.EmCdgo == Codigo
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<EstadoMotonaveDTO>>(lst) : new List<EstadoMotonaveDTO>();
                return result;
            }
        }
        #endregion
    }
}
