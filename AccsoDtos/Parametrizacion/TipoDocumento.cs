using AccsoDtos.RNDC;
using AutoMapper;
using MdloDtos.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Crud tipo de documento 
    /// </summary>
    public class TipoDocumento : MdloDtos.IModelos.ITipoDocumento
    {

        private readonly IMapper _mapper;

        public TipoDocumento(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region ingreso de datos a la entidad  Tipo de Documento
        public async Task<dynamic> IngresarTipoDocumento(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento)
        {
            var ObjTipoDocumento_ = new MdloDtos.TipoDocumento();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TipoDocumentoExiste = await this.VerificarTipoDocumento(ObjTipoDocumento.IdTipoDocumento);
                    if (TipoDocumentoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjTipoDocumento_.TdCdgo = ObjTipoDocumento.IdTipoDocumento;
                        ObjTipoDocumento_.TdNmbre = ObjTipoDocumento.Nombre;
                        ObjTipoDocumento_.TdOrgen = ObjTipoDocumento.Origen;
                        ObjTipoDocumento_.TdNmbreAAsgnar = ObjTipoDocumento.Asignar;
                        ObjTipoDocumento_.TdActvo = ObjTipoDocumento.Estado;
                        ObjTipoDocumento_.TdOblgtrio = ObjTipoDocumento.EsObligatorio;
                        var res = await _dbContex.TipoDocumentos.AddAsync(ObjTipoDocumento_);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjTipoDocumento_;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de tipos de documentos.
        public async Task<List<MdloDtos.DTO.TipoDocumentoDTO>> ListarTipoDocumento()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 select tipo).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoDocumentoDTO>>(lst) : new List<TipoDocumentoDTO>();
                return result;
            }
        }
        #endregion

        #region Consulta los datos de Tipo de Vehiculo mediante un parámetro Codigo general
        public async Task<List<MdloDtos.DTO.TipoDocumentoDTO>> FiltrarTipoDocumentoGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 where tipo.TdCdgo.Contains(Codigo) || tipo.TdNmbre.Contains(Codigo)
                                 select tipo).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoDocumentoDTO>>(lst) : new List<TipoDocumentoDTO>();
                return result;
            }
        }
        #endregion

        #region Consulta los datos de Tipo de Vehiculo mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.DTO.TipoDocumentoDTO>> FiltrarTipoDocumentoEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 where tipo.TdCdgo == Codigo
                                 select tipo).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoDocumentoDTO>>(lst) : new List<TipoDocumentoDTO>();
                return result;
            }
        }
        #endregion

        #region Actualiza Tipo de Vehiculo pasando un objeto _TipoDocumento
        public async Task<MdloDtos.DTO.TipoDocumentoDTO> EditarTipoDocumento(MdloDtos.DTO.TipoDocumentoDTO ObjTipoDocumento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.TipoDocumento TipoDocumentoExiste = await _dbContex.TipoDocumentos.FindAsync(ObjTipoDocumento.IdTipoDocumento);
                    if (TipoDocumentoExiste != null)
                    {
                        TipoDocumentoExiste.TdCdgo = ObjTipoDocumento.IdTipoDocumento;
                        TipoDocumentoExiste.TdNmbre = ObjTipoDocumento.Nombre;
                        TipoDocumentoExiste.TdOrgen = ObjTipoDocumento.Origen;
                        TipoDocumentoExiste.TdNmbreAAsgnar = ObjTipoDocumento.Asignar;
                        TipoDocumentoExiste.TdActvo = ObjTipoDocumento.Estado;
                        TipoDocumentoExiste.TdOblgtrio = ObjTipoDocumento.EsObligatorio;

                        _dbContex.TipoDocumentos.Entry(TipoDocumentoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjTipoDocumento;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region verificar un Tipo de Documento
        public async Task<bool> VerificarTipoDocumento(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjTipoDocumento = await _dbContex.TipoDocumentos.FindAsync(Codigo);
                    respuesta = (ObjTipoDocumento == null) ? false : true;   
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

        #region Consulta los datos de Tipos de documentos donde M
        public async Task<List<MdloDtos.DTO.TipoDocumentoDTO>> FiltrarTipoDocumentoDetalle()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 where tipo.TdActvo==true && tipo.TdOrgen.Contains("M")
                                 select tipo).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<TipoDocumentoDTO>>(lst) : new List<TipoDocumentoDTO>();
                return result;
            }
        }
        #endregion
    }
}
