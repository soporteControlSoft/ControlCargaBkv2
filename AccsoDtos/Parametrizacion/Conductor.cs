using AutoMapper;
using MdloDtos;
using MdloDtos.IModelos;
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
    /// Clase para el acceso a datos de la clase Conductor
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Conductor : MdloDtos.IModelos.IConductor
    {

        private readonly IMapper _mapper;

        public Conductor(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Ingresar datos a la entidad Conductor
        public async Task<dynamic> IngresarConductor(MdloDtos.DTO.ConductorDTO conductor)       {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjConductor = new MdloDtos.Conductor();
                try
                {
                    bool conductorExiste = await this.VerificarExistenciaConductor(conductor.Identificacion);
                    if (conductorExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjConductor.CnIdntfccion = conductor.Identificacion;
                        ObjConductor.CnNmbre = conductor.Nombre;
                        ObjConductor.CnFeatures = conductor.Imagen;
                        ObjConductor.CnVhclo = conductor.Vehiculo;
                        ObjConductor.CnRowidTrnsprtdra = conductor.IdTransportadora;
                        ObjConductor.CnFchaRgstro = conductor.FechaRegistro;
                        ObjConductor.CnCdgoUsrioEnrlo = conductor.CodigoUsuarioEnrolo;
                        ObjConductor.CnFchaEnrlmnto = conductor.FechaEnrolamiento;
                        ObjConductor.CnMvil = conductor.Movil;
                        ObjConductor.CnNmroLcncia = conductor.NumeroLicencia;
                        ObjConductor.CnTpoLcncia = conductor.TipoLicencia;
                        ObjConductor.CnFchaVncmntoLcncia = conductor.FechaVencimientoLcncia;
                        ObjConductor.CnActvo = conductor.Activo;
                        ObjConductor.CnUrbno = conductor.Urbano;
                        var res = await _dbContex.Conductors.AddAsync(ObjConductor);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjConductor;
            }
        }
        #endregion

        #region Listar todos los Conductores
        public async Task<List<MdloDtos.VwCndctorLstar>> ListarConductor()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lts = await (from vwCndctorLsta in _dbContex.VwCndctorLstars
                                 select vwCndctorLsta
                               ).ToListAsync();
                _dbContex.Dispose();     
                return lts;
            }
        }
        #endregion

        #region Actualizar Un conductor
        public async Task<MdloDtos.DTO.ConductorDTO> EditarConductor(MdloDtos.DTO.ConductorDTO _Conductor)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Conductor ConductorExiste = await _dbContex.Conductors.FindAsync(_Conductor.Identificacion);
                    if (ConductorExiste != null)
                    {
                        ConductorExiste.CnIdntfccion = _Conductor.Identificacion;
                        ConductorExiste.CnNmbre = _Conductor.Nombre;
                        ConductorExiste.CnFeatures = _Conductor.Imagen;
                        ConductorExiste.CnVhclo = _Conductor.Vehiculo;
                        ConductorExiste.CnRowidTrnsprtdra = _Conductor.IdTransportadora;
                        ConductorExiste.CnFchaRgstro = _Conductor.FechaRegistro;
                        ConductorExiste.CnCdgoUsrioEnrlo = _Conductor.CodigoUsuarioEnrolo;
                        ConductorExiste.CnFchaEnrlmnto = _Conductor.FechaEnrolamiento;
                        ConductorExiste.CnMvil = _Conductor.Movil;
                        ConductorExiste.CnNmroLcncia = _Conductor.NumeroLicencia;
                        ConductorExiste.CnTpoLcncia = _Conductor.TipoLicencia;
                        ConductorExiste.CnFchaVncmntoLcncia = _Conductor.FechaVencimientoLcncia;
                        ConductorExiste.CnActvo = _Conductor.Activo;
                        ConductorExiste.CnUrbno = _Conductor.Urbano;

                        _dbContex.Entry(ConductorExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _Conductor;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Filtrar Conductor por codigo general
        public async Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lts = await (from vwCndctorLsta in _dbContex.VwCndctorLstars
                                 where vwCndctorLsta.CnIdntfccion.Contains(Codigo) || vwCndctorLsta.CnNmbre.Contains(Codigo)
                                 select vwCndctorLsta
                               ).ToListAsync();
                _dbContex.Dispose();
                return lts;
            }
        }
        #endregion

        #region Filtrar Conductor por una identificacion Especifica
        public async Task<List<MdloDtos.VwCndctorLstar>> FiltrarConductorEspecifico(string Identificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from vwCndctorLsta in _dbContex.VwCndctorLstars
                                 where vwCndctorLsta.CnIdntfccion.Equals(Identificacion.ToString())
                                 select vwCndctorLsta
                               ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Eliminar Conductor Por Identificacion.
        public async Task<dynamic> EliminarConductor(string Identificacion)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ConductorExiste = await _dbContex.Conductors.FindAsync(Identificacion);
                    if (ConductorExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(ConductorExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ConductorExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar Un conductor a partir de su Identificación .
        public async Task<bool> VerificarExistenciaConductor(string Identificacion)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.VwCndctorLstars
                               where p.CnIdntfccion.Equals(Identificacion)
                               select p).Count();
                    respuesta = (lst == null || lst == 0) ? false : true;                
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
