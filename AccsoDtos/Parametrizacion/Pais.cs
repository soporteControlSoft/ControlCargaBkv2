using AutoMapper;
using MdloDtos;
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
    public class Pais:MdloDtos.IModelos.IPais
    {
        /// <summary>
        /// CRUD para el manejo del Pais
        /// Daniel Alejandro Lopez
        /// </summary>
        /// 

        private readonly IMapper _mapper;

        public Pais(IMapper mapper)
        {
            _mapper = mapper;
        }
        #region Ingresar datos a la entidad Pais
        public async Task<dynamic> IngresarPais(MdloDtos.DTO.PaisDTO _PaisDTO)
        {
            var ObjPäis= new MdloDtos.Pai();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PäisExiste = await this.VerificarPais(_PaisDTO.PaCdgo);

                    if (PäisExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPäis.PaCdgo = _PaisDTO.PaCdgo;
                        ObjPäis.PaNmbre = _PaisDTO.PaNmbre;
                        var res = await _dbContex.Pais.AddAsync(ObjPäis);
                        await _dbContex.SaveChangesAsync();

                    }                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjPäis;
            }

        }
        #endregion

        #region Consultar todos los datos de Pais mediante un parametro Codigo General
        public async Task<List<MdloDtos.DTO.PaisDTO>> FiltrarPaisGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.Pais
                                 where p.PaCdgo.Contains(Codigo) || p.PaNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();

                var lst = _mapper.Map<List<MdloDtos.DTO.PaisDTO>>(query);
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Pais mediante un parametro Codigo Especifico
        public async Task<List<MdloDtos.DTO.PaisDTO>> FiltrarPaisEspecifico(String Codigo)
        { 
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {    var query = await (from p in _dbContex.Pais
                              where p.PaCdgo == Codigo
                              select p).ToListAsync();

                 _dbContex.Dispose();
                var lst = _mapper.Map<List<MdloDtos.DTO.PaisDTO>>(query);
                return lst;
            }
        }
        #endregion

        #region Actualizar Pais pasando el objeto _Pais
        public async Task<MdloDtos.DTO.PaisDTO> EditarPais(MdloDtos.DTO.PaisDTO _PaisDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Pai PäisExiste = await _dbContex.Pais.FindAsync(_PaisDTO.PaCdgo);
                    if (PäisExiste != null)
                    {

                        PäisExiste.PaCdgo = _PaisDTO.PaCdgo;
                        PäisExiste.PaNmbre = _PaisDTO.PaNmbre;
                        _dbContex.Entry(PäisExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _PaisDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                
            }
        }

        #endregion

        #region Consultar todos los datos de Pais
        public async Task<List<MdloDtos.DTO.PaisDTO>> ListarPais()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.Pais.ToListAsync();
                _dbContex.Dispose();
                var lst = _mapper.Map<List<MdloDtos.DTO.PaisDTO>>(query);
                return lst;
            }

        }

        #endregion

        #region Eliminar Pais
        public async Task<dynamic> EliminarPais(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PäisExiste = await _dbContex.Pais.FindAsync(Codigo);
                    if (PäisExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(PäisExiste);
                        await _dbContex.SaveChangesAsync();
                    }

                    _dbContex.Dispose();
                    return PäisExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                
            }


        }

        #endregion


        #region verificar Pais
        public async Task<bool> VerificarPais(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPerfil = await _dbContex.Pais.FindAsync(Codigo);
                    if (ObjPerfil == null)
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
