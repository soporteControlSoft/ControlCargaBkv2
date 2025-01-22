using AutoMapper;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Compañia.
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 
    public class Compania:MdloDtos.IModelos.ICompania
    {
        private readonly IMapper _mapper;

        public Compania(IMapper mapper)
        {
            _mapper = mapper;
        }
        #region Ingresar datos a la entidad Compañia
        public async Task<MdloDtos.DTO.companiaDTO> IngresarCompania(MdloDtos.DTO.companiaDTO _CompaniumDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjCompanium = new MdloDtos.Companium();
                try
                {
                    var CompaniumExiste = await this.VerificarCompania(_CompaniumDTO.CiaCdgo);

                    if (CompaniumExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjCompanium.CiaCdgo = _CompaniumDTO.CiaCdgo;
                        ObjCompanium.CiaIdntfccion = _CompaniumDTO.CiaIdntfccion;
                        ObjCompanium.CiaNmbre = _CompaniumDTO.CiaNmbre;
                        ObjCompanium.CiaDrccion = _CompaniumDTO.CiaDrccion;
                        ObjCompanium.CiaNmbreCntcto = _CompaniumDTO.CiaNmbreCntcto;
                        ObjCompanium.CiaEmail = _CompaniumDTO.CiaEmail;
                        ObjCompanium.CiaTlfno = _CompaniumDTO.CiaTlfno;
                        ObjCompanium.CiaIdSstmaEntrnmnto = _CompaniumDTO.CiaIdSstmaEntrnmnto;
                        ObjCompanium.CiaInsideIdUsrio = _CompaniumDTO.CiaInsideIdUsrio;
                        ObjCompanium.CiaInsideClveUsrio = _CompaniumDTO.CiaInsideClveUsrio;
                        ObjCompanium.CiaInsideUrl1 = _CompaniumDTO.CiaInsideUrl1;
                        ObjCompanium.CiaInsideUrl2 = _CompaniumDTO.CiaInsideUrl2;
                        ObjCompanium.CiaRndcIdUsrio = _CompaniumDTO.CiaRndcIdUsrio;
                        ObjCompanium.CiaRndcClveUsrio = _CompaniumDTO.CiaRndcClveUsrio;
                        ObjCompanium.CiaRndcUrl1 = _CompaniumDTO.CiaRndcUrl1;
                        ObjCompanium.CiaRndcUrl2 = _CompaniumDTO.CiaRndcUrl2;
                        ObjCompanium.CiaActva = _CompaniumDTO.CiaActva;
                        ObjCompanium.CiaLgo = _CompaniumDTO.CiaLgo;

                        var res = await _dbContex.Compania.AddAsync(ObjCompanium);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _CompaniumDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }


        }
        #endregion

        #region Listar todos los Compañia
        public async Task<List<MdloDtos.DTO.companiaDTO>> ListarCompania()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.Compania.ToListAsync();
                _dbContex.Dispose();

                var lst = _mapper.Map<List<companiaDTO>>(query);
                return lst;
            }
        }
        #endregion


        #region Actualizar Compañia por el objeto _Compañia
        public async Task<MdloDtos.DTO.companiaDTO> EditarCompania(MdloDtos.DTO.companiaDTO _CompaniumDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Companium CompaniumExiste = await _dbContex.Compania.FindAsync(_CompaniumDTO.CiaCdgo);
                    if (CompaniumExiste != null)
                    {
                        CompaniumExiste.CiaCdgo = _CompaniumDTO.CiaCdgo;
                        CompaniumExiste.CiaIdntfccion = _CompaniumDTO.CiaIdntfccion;
                        CompaniumExiste.CiaNmbre = _CompaniumDTO.CiaNmbre;
                        CompaniumExiste.CiaDrccion = _CompaniumDTO.CiaDrccion;
                        CompaniumExiste.CiaNmbreCntcto = _CompaniumDTO.CiaNmbreCntcto;
                        CompaniumExiste.CiaEmail = _CompaniumDTO.CiaEmail;
                        CompaniumExiste.CiaTlfno = _CompaniumDTO.CiaTlfno;
                        CompaniumExiste.CiaIdSstmaEntrnmnto = _CompaniumDTO.CiaIdSstmaEntrnmnto;
                        CompaniumExiste.CiaInsideIdUsrio = _CompaniumDTO.CiaInsideIdUsrio;
                        CompaniumExiste.CiaInsideClveUsrio = _CompaniumDTO.CiaInsideClveUsrio;
                        CompaniumExiste.CiaInsideUrl1 = _CompaniumDTO.CiaInsideUrl1;
                        CompaniumExiste.CiaInsideUrl2 = _CompaniumDTO.CiaInsideUrl2;
                        CompaniumExiste.CiaRndcIdUsrio = _CompaniumDTO.CiaRndcIdUsrio;
                        CompaniumExiste.CiaRndcClveUsrio = _CompaniumDTO.CiaRndcClveUsrio;
                        CompaniumExiste.CiaRndcUrl1 = _CompaniumDTO.CiaRndcUrl1;
                        CompaniumExiste.CiaRndcUrl2 = _CompaniumDTO.CiaRndcUrl2;
                        CompaniumExiste.CiaActva = _CompaniumDTO.CiaActva;
                        CompaniumExiste.CiaLgo = _CompaniumDTO.CiaLgo;
                        _dbContex.Entry(CompaniumExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    
                    _dbContex.Dispose();
                    return _CompaniumDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
            
        }
        #endregion

        #region Filtrar Compañia por codigo General
        public async Task<List<MdloDtos.DTO.companiaDTO>> FiltrarCompaniaGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.Compania
                                 where p.CiaCdgo.Contains(Codigo) || p.CiaNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();

                var lst = _mapper.Map<List<companiaDTO>>(query);
                return lst;
            }
        }
        #endregion

        #region Filtrar Compañia por codigo Especifico
        public async Task<List<MdloDtos.DTO.companiaDTO>> FiltrarCompaniaEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.Compania
                                 where p.CiaCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();

                var lst = _mapper.Map<List<companiaDTO>>(query);
                return lst;
            }
        }
        #endregion

        #region Eliminar Compañia Por codigo.
        public async Task<dynamic> EliminarCompania(string RowId)
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
