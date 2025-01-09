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
    /// CRUD para el manejo de motonaves
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Motonave : MdloDtos.IModelos.IMotonave
    {

        private readonly IMapper _mapper;

        public Motonave(IMapper mapper)
        {
            _mapper = mapper;
        }


        #region ingreso de datos a la entidad Motonave
        public async Task<dynamic> IngresarMotonave(MdloDtos.DTO.MotonaveDTO _Motonave)
        { 
            var ObjMotonave = new MdloDtos.Motonave();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var MotonaveExiste = await this.VerificarMotonave(_Motonave.Codigo);
                    if (MotonaveExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjMotonave.MoCdgo = _Motonave.Codigo;
                        ObjMotonave.MoNmbre = _Motonave.Nombre;
                        ObjMotonave.MoEslra = _Motonave.Eslra;
                        ObjMotonave.MoMtrcla = _Motonave.Mtrcla;
                        ObjMotonave.MoBndra = _Motonave.MoBndra;
                        ObjMotonave.MoCntdadEsctllas = _Motonave.CantidadEscotillas;
                        ObjMotonave.MoCldo = _Motonave.Calado;
                        var res = await _dbContex.Motonaves.AddAsync(ObjMotonave);
                        await _dbContex.SaveChangesAsync();
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _Motonave;
                
            }
        }
        #endregion

        #region Consulta los datos de motonaves mediante un parámetro Codigo General
        public async Task<List<MdloDtos.DTO.MotonaveDTO>> FiltrarMotonaveGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.Motonaves
                                 where m.MoCdgo.Contains(Codigo) || m.MoNmbre.Contains(Codigo)
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();

                var result = _mapper.Map<List<MotonaveDTO>>(lst);

                return result;
            }
        }
        #endregion

        #region Consulta los datos de motonaves mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.DTO.MotonaveDTO>> FiltrarMotonaveEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from m in _dbContex.Motonaves
                                 where m.MoCdgo == Codigo
                                 select m
                             ).ToListAsync();
                _dbContex.Dispose();
                var result = _mapper.Map<List<MotonaveDTO>>(lst);
                return result;
            }
        }
        #endregion

        #region Actualiza una Motonave pasando un objeto _Motonave
        public async Task<MdloDtos.DTO.MotonaveDTO> EditarMotonave(MdloDtos.DTO.MotonaveDTO _Motonave)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Motonave MotonaveExiste = await _dbContex.Motonaves.FindAsync(_Motonave.Codigo);
                    if (MotonaveExiste != null)
                    {
                        MotonaveExiste.MoNmbre = _Motonave.Nombre;
                        MotonaveExiste.MoEslra = _Motonave.Eslra;
                        MotonaveExiste.MoMtrcla = _Motonave.Mtrcla;
                        MotonaveExiste.MoBndra = _Motonave.MoBndra;
                        MotonaveExiste.MoCntdadEsctllas = _Motonave.CantidadEscotillas;
                        MotonaveExiste.MoCldo = _Motonave.Calado;
                        
                        _dbContex.Motonaves.Entry(MotonaveExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _Motonave;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de Motonave.
        public async Task<List<MdloDtos.DTO.MotonaveDTO>> ListarMotonave()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.Motonaves.ToListAsync();
                _dbContex.Dispose();
                var result = _mapper.Map<List<MotonaveDTO>>(lst);
                return result;
            }
        }
        #endregion

        #region Elimina una Motonave pasando como parámetro Codigo
        public async Task<dynamic> EliminarMotonave(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var MotonaveExiste = await _dbContex.Motonaves.FindAsync(Codigo);
                    if (MotonaveExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Motonaves.Remove(MotonaveExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();

                   
                    return MotonaveExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar una Motonave
        public async Task<bool> VerificarMotonave(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjMotonave = await _dbContex.Motonaves.FindAsync(Codigo);
                    if (ObjMotonave == null)
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
