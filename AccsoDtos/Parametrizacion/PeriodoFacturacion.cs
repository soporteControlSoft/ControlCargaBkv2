using AutoMapper;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// CRUD para el manejo de los periodos de facturación
    /// Wilbert Rivas Granados
    /// Ajuste Daniel Lopez
    /// </summary>
    /// 
    public class PeriodoFacturacion : MdloDtos.IModelos.IPeriodoFacturacion
    {
        private readonly IMapper _mapper;

        public PeriodoFacturacion(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region ingreso de datos a la entidad Periodo Facturacion
        public async Task<dynamic> IngresarPeriodoFacturacion(MdloDtos.DTO.PeriodoFacturacionDTO _PeriodoFacturacion)
        { 
            var ObjPeriodoFacturacion = new MdloDtos.PeriodoFacturacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PeriodoFacturacionExiste = await this.VerificarPeriodoFacturacion(_PeriodoFacturacion.Codigo);
                    if (PeriodoFacturacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPeriodoFacturacion.PfCdgo = _PeriodoFacturacion.Codigo;
                        ObjPeriodoFacturacion.PfNmbre = _PeriodoFacturacion.Nombre;
                        ObjPeriodoFacturacion.PfDias = _PeriodoFacturacion.Dias;
                        ObjPeriodoFacturacion.PfPrmdio = _PeriodoFacturacion.Promedio;
                        ObjPeriodoFacturacion.PfCdgoErp = _PeriodoFacturacion.CodigoErp;
                        var res = await _dbContex.PeriodoFacturacions.AddAsync(ObjPeriodoFacturacion);
                        await _dbContex.SaveChangesAsync();
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _PeriodoFacturacion;
            }
        }
        #endregion

        #region Consulta los datos de Periodo Facturacion mediante un parámetro Codigo General
        public async Task<List<MdloDtos.DTO.PeriodoFacturacionDTO>> FiltrarPeriodoFacturacionGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.PeriodoFacturacions
                                 where m.PfCdgo.Contains(Codigo) || m.PfNmbre.Contains(Codigo)
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<PeriodoFacturacionDTO>>(lst) : new List<PeriodoFacturacionDTO>();
                return result;
            }
        }
        #endregion

        #region Consulta los datos de Periodo Facturacion mediante un parámetro Codigo Periodo Facturacion
        public async Task<List<MdloDtos.DTO.PeriodoFacturacionDTO>> FiltrarPeriodoFacturacionEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.PeriodoFacturacions
                                 where m.PfCdgo == Codigo
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<PeriodoFacturacionDTO>>(lst) : new List<PeriodoFacturacionDTO>();
                return result;
            }
        }
        #endregion

        #region Actualiza un Periodo Facturacion pasando un objeto _PeriodoFacturacion
        public async Task<dynamic> EditarPeriodoFacturacion(MdloDtos.DTO.PeriodoFacturacionDTO _PeriodoFacturacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.PeriodoFacturacion PeriodoFacturacionExiste = await _dbContex.PeriodoFacturacions.FindAsync(_PeriodoFacturacion.Codigo);
                    if (PeriodoFacturacionExiste != null)
                    {
                        PeriodoFacturacionExiste.PfNmbre = _PeriodoFacturacion.Nombre;
                        PeriodoFacturacionExiste.PfDias = _PeriodoFacturacion.Dias;
                        PeriodoFacturacionExiste.PfPrmdio = _PeriodoFacturacion.Promedio;
                        PeriodoFacturacionExiste.PfCdgoErp = _PeriodoFacturacion.CodigoErp;

                        _dbContex.PeriodoFacturacions.Entry(PeriodoFacturacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _PeriodoFacturacion;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de PeriodoFacturacion.
        public async Task<List<MdloDtos.DTO.PeriodoFacturacionDTO>> ListarPeriodoFacturacion()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.PeriodoFacturacions.ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<MdloDtos.DTO.PeriodoFacturacionDTO>>(lst) : new List<MdloDtos.DTO.PeriodoFacturacionDTO>();
                return result;
            }
        }
        #endregion

        #region Elimina un Periodo Facturacion pasando como parámetro Codigo
        public async Task<dynamic> EliminarPeriodoFacturacion(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PeriodoFacturacionExiste = await _dbContex.PeriodoFacturacions.FindAsync(Codigo);
                    if (PeriodoFacturacionExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.PeriodoFacturacions.Remove(PeriodoFacturacionExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return PeriodoFacturacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar un Periodo Facturacion pasando como párametro Codigo
        public async Task<bool> VerificarPeriodoFacturacion(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPeriodoFacturacion = await _dbContex.PeriodoFacturacions.FindAsync(Codigo);
                    respuesta = (ObjPeriodoFacturacion == null) ? false : true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                _dbContex.Dispose();
                return respuesta;
            }
        }
        #endregion
    }
}
