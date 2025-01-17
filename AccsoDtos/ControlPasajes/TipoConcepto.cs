using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.ControlPasajes
{
    public class TipoConcepto : MdloDtos.IModelos.ITiposConceptos
    {
        /// <summary>
        /// Acceso a Datos Tabla consecutivos
        /// Daniel Alejandro Lopez.
        /// </summary>
        private readonly CcVenturaContext _dbContext;
        private readonly IMapper _mapper;

        public TipoConcepto(IMapper mapper, MdloDtos.CcVenturaContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        //Consultar toda la tipo de concepto
        public async Task<List<TipoConceptoDTO>> ConsultarTipoConcepto()
        {
            try
            {
                var tipoconceptoLst = await _dbContext.TipoConceptos
                    .ToListAsync();

                var result = _mapper.Map<List<TipoConceptoDTO>>(tipoconceptoLst);

                return result;
            }
            catch (Exception ex)
            {
                return [];
            }
        }

        //Filtrar un tipo de concepto por el codigo
        public async Task<List<TipoConceptoDTO>> FiltrarTipoConceptoPorCodigo(string Codigo)
        {
            try
            {
                var tipoconceptoLst = await _dbContext.TipoConceptos
                    .Where(p => p.TcCdgo == Codigo)
                    .ToListAsync();

                var result = _mapper.Map<List<TipoConceptoDTO>>(tipoconceptoLst);

                return result;
            }
            catch (Exception ex)
            {
                return [];
            }
        }


    }
}
