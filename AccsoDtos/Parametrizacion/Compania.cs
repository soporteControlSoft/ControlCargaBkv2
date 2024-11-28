using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Compañia.
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 
    public class Compania:MdloDtos.IModelos.ICompania
    {
        #region Ingresar datos a la entidad Compañia
        public async Task<MdloDtos.Companium> IngresarCompania(MdloDtos.Companium _Companium)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjCompanium = new MdloDtos.Companium();
                try
                {
                    var CompaniumExiste = await this.VerificarCompania(_Companium.CiaCdgo);

                    if (CompaniumExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjCompanium.CiaCdgo = _Companium.CiaCdgo;
                        ObjCompanium.CiaIdntfccion = _Companium.CiaIdntfccion;
                        ObjCompanium.CiaNmbre = _Companium.CiaNmbre;
                        ObjCompanium.CiaDrccion = _Companium.CiaDrccion;
                        ObjCompanium.CiaNmbreCntcto = _Companium.CiaNmbreCntcto;
                        ObjCompanium.CiaEmail = _Companium.CiaEmail;
                        ObjCompanium.CiaTlfno = _Companium.CiaTlfno;
                        ObjCompanium.CiaIdSstmaEntrnmnto = _Companium.CiaIdSstmaEntrnmnto;
                        ObjCompanium.CiaInsideIdUsrio = _Companium.CiaInsideIdUsrio;
                        ObjCompanium.CiaInsideClveUsrio = _Companium.CiaInsideClveUsrio;
                        ObjCompanium.CiaInsideUrl1 = _Companium.CiaInsideUrl1;
                        ObjCompanium.CiaInsideUrl2 = _Companium.CiaInsideUrl2;
                        ObjCompanium.CiaRndcIdUsrio = _Companium.CiaRndcIdUsrio;
                        ObjCompanium.CiaRndcClveUsrio = _Companium.CiaRndcClveUsrio;
                        ObjCompanium.CiaRndcUrl1 = _Companium.CiaRndcUrl1;
                        ObjCompanium.CiaRndcUrl2 = _Companium.CiaRndcUrl2;
                        ObjCompanium.CiaActva = _Companium.CiaActva;
                        ObjCompanium.CiaLgo = _Companium.CiaLgo;

                        var res = await _dbContex.Compania.AddAsync(ObjCompanium);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjCompanium;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }


        }
        #endregion

        #region Listar todos los Compañia
        public async Task<List<MdloDtos.Companium>> ListarCompania()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.Compania.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion


        #region Actualizar Compañia por el objeto _Compañia
        public async Task<MdloDtos.Companium> EditarCompania(MdloDtos.Companium _Companium)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Companium CompaniumExiste = await _dbContex.Compania.FindAsync(_Companium.CiaCdgo);
                    if (CompaniumExiste != null)
                    {

                        CompaniumExiste.CiaCdgo = _Companium.CiaCdgo;
                        CompaniumExiste.CiaIdntfccion = _Companium.CiaIdntfccion;
                        CompaniumExiste.CiaNmbre = _Companium.CiaNmbre;
                        CompaniumExiste.CiaDrccion = _Companium.CiaDrccion;
                        CompaniumExiste.CiaNmbreCntcto = _Companium.CiaNmbreCntcto;
                        CompaniumExiste.CiaEmail = _Companium.CiaEmail;
                        CompaniumExiste.CiaTlfno = _Companium.CiaTlfno;
                        CompaniumExiste.CiaIdSstmaEntrnmnto = _Companium.CiaIdSstmaEntrnmnto;
                        CompaniumExiste.CiaInsideIdUsrio = _Companium.CiaInsideIdUsrio;
                        CompaniumExiste.CiaInsideClveUsrio = _Companium.CiaInsideClveUsrio;
                        CompaniumExiste.CiaInsideUrl1 = _Companium.CiaInsideUrl1;
                        CompaniumExiste.CiaInsideUrl2 = _Companium.CiaInsideUrl2;
                        CompaniumExiste.CiaRndcIdUsrio = _Companium.CiaRndcIdUsrio;
                        CompaniumExiste.CiaRndcClveUsrio = _Companium.CiaRndcClveUsrio;
                        CompaniumExiste.CiaRndcUrl1 = _Companium.CiaRndcUrl1;
                        CompaniumExiste.CiaRndcUrl2 = _Companium.CiaRndcUrl2;
                        CompaniumExiste.CiaActva = _Companium.CiaActva;
                        CompaniumExiste.CiaLgo = _Companium.CiaLgo;
                        _dbContex.Entry(CompaniumExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    
                    _dbContex.Dispose();
                    return CompaniumExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            
        }
        #endregion

        #region Filtrar Compañia por codigo General
        public async Task<List<MdloDtos.Companium>> FiltrarCompaniaGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Compania
                                 where p.CiaCdgo.Contains(Codigo) || p.CiaNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Filtrar Compañia por codigo Especifico
        public async Task<List<MdloDtos.Companium>> FiltrarCompaniaEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Compania
                                 where p.CiaCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Eliminar Compañia Por codigo.
        public async Task<MdloDtos.Companium> EliminarCompania(string RowId)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var CompaniumExiste = await _dbContex.Compania.FindAsync(RowId);
                    if (CompaniumExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(CompaniumExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return CompaniumExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

        }
        #endregion

        #region verificar Compañia por codigo.
        public async Task<bool> VerificarCompania(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjCompanium = await _dbContex.Compania.FindAsync(Codigo);
                    if (ObjCompanium == null)
                    {

                        respuesta = false;
                    }
                    else
                    {

                       respuesta = true;
                    }

                    _dbContex.Dispose();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
        #endregion

        #region Verificar Compañia por codigo Identificacion
        public async Task<bool> ValidarCompaniaPorIdentificacion(string CodigoIdentificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.Compania
                                 where p.CiaIdntfccion == CodigoIdentificacion
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return (lst.Count == 0 ? false : true);           
            }
        }
        #endregion
    }
}
