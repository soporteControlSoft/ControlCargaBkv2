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
        #region ingreso de datos a la entidad  Tipo de Documento
        public async Task<MdloDtos.TipoDocumento> IngresarTipoDocumento(MdloDtos.TipoDocumento ObjTipoDocumento)
        {
            var ObjTipoDocumento_ = new MdloDtos.TipoDocumento();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TipoDocumentoExiste = await this.VerificarTipoDocumento(ObjTipoDocumento.TdCdgo);
                    if (TipoDocumentoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjTipoDocumento_.TdCdgo = ObjTipoDocumento.TdCdgo;
                        ObjTipoDocumento_.TdNmbre = ObjTipoDocumento.TdNmbre;
                        ObjTipoDocumento_.TdOrgen = ObjTipoDocumento.TdOrgen;
                        ObjTipoDocumento_.TdNmbreAAsgnar = ObjTipoDocumento.TdNmbreAAsgnar;
                        ObjTipoDocumento_.TdActvo = ObjTipoDocumento.TdActvo;
                        ObjTipoDocumento_.TdOblgtrio = ObjTipoDocumento.TdOblgtrio;
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
        public async Task<List<MdloDtos.TipoDocumento>> ListarTipoDocumento()
        {
            List<MdloDtos.TipoDocumento> listadoTipoDocumento = new List<MdloDtos.TipoDocumento>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 select tipo).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consulta los datos de Tipo de Vehiculo mediante un parámetro Codigo general
        public async Task<List<MdloDtos.TipoDocumento>> FiltrarTipoDocumentoGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 where tipo.TdCdgo.Contains(Codigo) || tipo.TdNmbre.Contains(Codigo)
                                 select tipo).ToListAsync();
                _dbContex.Dispose();

                return lst;
            }
        }
        #endregion

        #region Consulta los datos de Tipo de Vehiculo mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.TipoDocumento>> FiltrarTipoDocumentoEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 where tipo.TdCdgo == Codigo
                                 select tipo).ToListAsync();
                _dbContex.Dispose();

                return lst;
            }
        }
        #endregion

        #region Actualiza Tipo de Vehiculo pasando un objeto _TipoDocumento
        public async Task<MdloDtos.TipoDocumento> EditarTipoDocumento(MdloDtos.TipoDocumento ObjTipoDocumento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.TipoDocumento TipoDocumentoExiste = await _dbContex.TipoDocumentos.FindAsync(ObjTipoDocumento.TdCdgo);
                    if (TipoDocumentoExiste != null)
                    {
                        TipoDocumentoExiste.TdCdgo = ObjTipoDocumento.TdCdgo;
                        TipoDocumentoExiste.TdNmbre = ObjTipoDocumento.TdNmbre;
                        TipoDocumentoExiste.TdOrgen = ObjTipoDocumento.TdOrgen;
                        TipoDocumentoExiste.TdNmbreAAsgnar = ObjTipoDocumento.TdNmbreAAsgnar;
                        TipoDocumentoExiste.TdActvo = ObjTipoDocumento.TdActvo;
                        TipoDocumentoExiste.TdOblgtrio = ObjTipoDocumento.TdOblgtrio;

                        _dbContex.TipoDocumentos.Entry(TipoDocumentoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return TipoDocumentoExiste;
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
                    if (ObjTipoDocumento == null)
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

        #region Consulta los datos de Tipos de documentos donde M
        public async Task<List<MdloDtos.TipoDocumento>> FiltrarTipoDocumentoDetalle()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from tipo in _dbContex.TipoDocumentos
                                 where tipo.TdActvo==true && tipo.TdOrgen.Contains("M")
                                 select tipo).ToListAsync();
                _dbContex.Dispose();

                return lst;
            }
        }
        #endregion
    }
}
