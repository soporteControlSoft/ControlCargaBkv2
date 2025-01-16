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
    public class PuertoOrigen : MdloDtos.IModelos.IPuertoOrigen
    {
        private readonly IMapper _mapper;

        public PuertoOrigen(IMapper mapper)
        {
            _mapper = mapper;
        }
        #region Ingresar datos a la entidad Puerto Origen
        public async Task<MdloDtos.DTO.PuertoOrigenDTO> IngresarPuertoOrigen(MdloDtos.DTO.PuertoOrigenDTO _PuertoOrigenDTO)
        {
            var ObjPuertoOrigen = new MdloDtos.PuertoOrigen();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PuertoOrigenExiste = await this.VerificarPuertoOrigen(_PuertoOrigenDTO.PoCdgo);

                    if (PuertoOrigenExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPuertoOrigen.PoCdgo = _PuertoOrigenDTO.PoCdgo;
                        ObjPuertoOrigen.PoDscrpcion = _PuertoOrigenDTO.PoDscrpcion;
                        ObjPuertoOrigen.PoActvo = _PuertoOrigenDTO.PoActvo;
                        var res = await _dbContex.PuertoOrigens.AddAsync(ObjPuertoOrigen);
                        await _dbContex.SaveChangesAsync();
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _PuertoOrigenDTO;
            }

        }
        #endregion

        #region Consultar todos los datos de Puerto Origen mediante un parametro Codigo
        public async Task<List<MdloDtos.DTO.PuertoOrigenDTO>> FiltrarPuertoOrigenGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.PuertoOrigens
                                 where p.PoCdgo.Contains(Codigo) || p.PoDscrpcion.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();

                var lst = (query.Count > 0) ? _mapper.Map<List<PuertoOrigenDTO>>(query) : new List<PuertoOrigenDTO>();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Puerto Origen mediante un parametro Codigo especifico
        public async Task<List<MdloDtos.DTO.PuertoOrigenDTO>> FiltrarPuertoOrigenEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.PuertoOrigens
                                 where p.PoCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                var lst = (query.Count > 0) ? _mapper.Map<List<PuertoOrigenDTO>>(query) : new List<PuertoOrigenDTO>();
                return lst;
            }

        }
        #endregion

        #region Actualizar Puerto Origen pasando el objeto _PuertoOrigen
        public async Task<MdloDtos.DTO.PuertoOrigenDTO> EditarPuertoOrigen(MdloDtos.DTO.PuertoOrigenDTO _PuertoOrigenDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.PuertoOrigen PuertoOrigenExiste = await _dbContex.PuertoOrigens.FindAsync(_PuertoOrigenDTO.PoCdgo);
                    if (PuertoOrigenExiste != null)
                    {

                        PuertoOrigenExiste.PoCdgo = _PuertoOrigenDTO.PoCdgo;
                        PuertoOrigenExiste.PoDscrpcion = _PuertoOrigenDTO.PoDscrpcion;
                        PuertoOrigenExiste.PoActvo = _PuertoOrigenDTO.PoActvo;
                        _dbContex.Entry(PuertoOrigenExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _PuertoOrigenDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region Consultar todos los datos de Puerto Origen
        public async Task<List<MdloDtos.DTO.PuertoOrigenDTO>> ListarPuertoOrigen()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.PuertoOrigens.ToListAsync();
                _dbContex.Dispose();

                var lst = (query.Count > 0) ? _mapper.Map<List<PuertoOrigenDTO>>(query) : new List<PuertoOrigenDTO>();
                return lst;
            }

        }

        #endregion

        #region Eliminar Puerto Origen
        public async Task<dynamic> EliminarPuertoOrigen(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PuertoOrigenExiste = await _dbContex.PuertoOrigens.FindAsync(Codigo);
                    if (PuertoOrigenExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(PuertoOrigenExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return PuertoOrigenExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


        }

        #endregion

        #region verificar Puerto Origen
        public async Task<bool> VerificarPuertoOrigen(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPuertoOrigenExiste = await _dbContex.PuertoOrigens.FindAsync(Codigo);
                    if (ObjPuertoOrigenExiste == null)
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
                return respuesta;
            }

        }
        #endregion
    }
}
