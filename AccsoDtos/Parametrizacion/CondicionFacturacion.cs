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
    /// CRUD para el manejo de condiciones de facturación
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class CondicionFacturacion : MdloDtos.IModelos.ICondicionFacturacion
    {

        private readonly IMapper _mapper;

        public CondicionFacturacion(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region ingreso de datos a la entidad Condicion Facturacion
        public async Task<dynamic> IngresarCondicionFacturacion(MdloDtos.DTO.CondicionFacturacionDTO _CondicionFacturacion)
        { 
            var ObjCondicionFacturacion = new MdloDtos.CondicionFacturacion();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var CondicionFacturacionExiste = await this.VerificarCondicionFacturacion(_CondicionFacturacion.Codigo);
                    if (CondicionFacturacionExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjCondicionFacturacion.CfCdgo = _CondicionFacturacion.Codigo;
                        ObjCondicionFacturacion.CfNmbre = _CondicionFacturacion.Nombre;
                        ObjCondicionFacturacion.CfFchaBse = _CondicionFacturacion.Base;
                        var res = await _dbContex.CondicionFacturacions.AddAsync(ObjCondicionFacturacion);
                        await _dbContex.SaveChangesAsync();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _CondicionFacturacion;
            }
           
        }
        #endregion

        #region Consulta todos los datos de condicion facturacion mediante un parámetro Codigo General
        public async Task<List<MdloDtos.DTO.CondicionFacturacionDTO>> FiltrarCondicionFacturacionGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from c in _dbContex.CondicionFacturacions
                                 where c.CfCdgo.Contains(Codigo) || c.CfNmbre.Contains(Codigo)
                                 select c
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = _mapper.Map<List<CondicionFacturacionDTO>>(lst);
                return result;
            }
        }
        #endregion


        #region Consulta todos los datos de condicion facturacion mediante un parámetro Codigo Condicion Facturacion
        public async Task<List<MdloDtos.DTO.CondicionFacturacionDTO>> FiltrarCondicionFacturacionEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from c in _dbContex.CondicionFacturacions
                                 where c.CfCdgo == Codigo
                                 select c
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = _mapper.Map<List<CondicionFacturacionDTO>>(lst);
                return result;
            }
        }
        #endregion

        #region Actualiza una Condicion Facturacion pasando un objeto _CondicionFacturacion
        public async Task<MdloDtos.DTO.CondicionFacturacionDTO> EditarCondicionFacturacion(MdloDtos.DTO.CondicionFacturacionDTO _CondicionFacturacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    MdloDtos.CondicionFacturacion CondicionFacturacionExiste = await _dbContex.CondicionFacturacions.FindAsync(_CondicionFacturacion.Codigo);
                    if (CondicionFacturacionExiste != null)
                    {
                        CondicionFacturacionExiste.CfNmbre = _CondicionFacturacion.Nombre;
                        CondicionFacturacionExiste.CfFchaBse = _CondicionFacturacion.Base;
                        _dbContex.CondicionFacturacions.Entry(CondicionFacturacionExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _CondicionFacturacion;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de Condicion de facturacion.
        public async Task<List<MdloDtos.DTO.CondicionFacturacionDTO>> ListarCondicionFacturacion()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.CondicionFacturacions.ToListAsync();
                _dbContex.Dispose();
                var result = _mapper.Map<List<CondicionFacturacionDTO>>(lst);
                return result;
            }
        }
        #endregion

        #region Elimina una Condicion Facturacion pasando como parametro Codigo
        public async Task<dynamic> EliminarCondicionFacturacion(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var CondicionFacturacionExiste = await _dbContex.CondicionFacturacions.FindAsync(Codigo);
                    if (CondicionFacturacionExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.CondicionFacturacions.Remove(CondicionFacturacionExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return CondicionFacturacionExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar una Condicion de facturacion
        public async Task<bool> VerificarCondicionFacturacion(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjCondicionFacturacion = await _dbContex.CondicionFacturacions.FindAsync(Codigo);
                    if (ObjCondicionFacturacion == null)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        respuesta = true;
                    }
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
