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

namespace AccsoDtos.EstadoHechos
{
    /// <summary>
    /// Clase para el acceso a datos de la clase equipo
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Equipo:MdloDtos.IModelos.IEquipo
    {
        private readonly CcVenturaContext _dbContext;
        private readonly IMapper _mapper;

        public Equipo(IMapper mapper, MdloDtos.CcVenturaContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        #region Ingresar datos a la entidad Equipo
        public async Task<MdloDtos.DTO.EquipoDTO> IngresarEquipo(MdloDtos.DTO.EquipoDTO _EquipoDto)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjEquipo = new MdloDtos.Equipo();
                try
                {
                    var EquipoExiste = await this.VerificarEquipo(_EquipoDto.Id);

                    if (EquipoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {

                        DateTime fechaSistema = DateTime.Now;

                        ObjEquipo.EqNmbre = _EquipoDto.Nombre;
                        ObjEquipo.EqDscrpcion = _EquipoDto.Descripcion;
                        ObjEquipo.EqFchaCrcion = fechaSistema;
                        ObjEquipo.EqCdgoUsrio = _EquipoDto.CodigoUsuario;
                        ObjEquipo.EqCdgo = _EquipoDto.codigoEquipo;
                        ObjEquipo.EqActvo = true;


                        var res = await _dbContex.Equipos.AddAsync(ObjEquipo);

                        await _dbContex.SaveChangesAsync();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _EquipoDto;
            }

        }
        #endregion

        #region Listar todos las equipo
        public async Task<List<MdloDtos.DTO.EquipoDTO>> ListarEquipo(bool estado = true)
        {
            List<MdloDtos.Equipo > listEquipo = new List<MdloDtos.Equipo>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from equipo in _dbContex.Equipos
                                   where equipo.EqActvo == estado
                                   select equipo).ToListAsync();
                
                var list = _mapper.Map<List<EquipoDTO>>(query);
                return list;

            }
        }
        #endregion

        #region Actualizar departamentos por el objeto _Equipo
        public async Task<MdloDtos.DTO.EquipoDTO> EditarEquipo(MdloDtos.DTO.EquipoDTO _EquipoDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Equipo EquipoExiste = await _dbContex.Equipos.FindAsync(_EquipoDTO.Id);
                    if (EquipoExiste != null)
                    {
                        EquipoExiste.EqNmbre = _EquipoDTO.Nombre;
                        EquipoExiste.EqDscrpcion = _EquipoDTO.Descripcion;
                        EquipoExiste.EqCdgoUsrio = _EquipoDTO.CodigoUsuario;
                        EquipoExiste.EqCdgo = _EquipoDTO.codigoEquipo;
                        EquipoExiste.EqActvo = _EquipoDTO.Estado;
              
                        _dbContex.Entry(EquipoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _EquipoDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
               
            }
            
        }
        #endregion

        #region Filtrar Equipo por codigo general
        public async Task<List<MdloDtos.DTO.EquipoDTO>> FiltrarEquipoGeneral(string Codigo, bool estado)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código (RowID o nombre) y el estado
                var query = await (from eq in _dbContex.Equipos
                                 where (eq.EqRowid.ToString().Contains(Codigo) || eq.EqNmbre.Contains(Codigo))
                                       && eq.EqActvo == estado // Validar el estado
                                  select eq).ToListAsync();

                var list = _mapper.Map<List<EquipoDTO>>(query);
                return list;
            }
        }
        #endregion

        #region Filtrar Equipo por codigo Especifico 
        public async Task<List<MdloDtos.DTO.EquipoDTO>> FiltrarEquipoEspecifico(string Codigo, bool estado)
        {
            // Convertir el código a entero
            int codigoConvert = int.Parse(Codigo);

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código específico y estado
                var query = await (from eq in _dbContex.Equipos
                                 where eq.EqRowid == codigoConvert && eq.EqActvo == estado
                                 select eq).ToListAsync();

                var list = _mapper.Map<List<EquipoDTO>>(query);
                return list;
            }
        }
        #endregion

        #region inactivar Equipo Por codigo.
        public async Task<MdloDtos.DTO.EquipoDTO> InactivarEquipo(MdloDtos.DTO.EquipoDTO _EquipoDTO)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Equipo EquipoExiste = await _dbContex.Equipos.FindAsync(_EquipoDTO.Id);
                    if (EquipoExiste != null)
                    {
                        EquipoExiste.EqActvo = _EquipoDTO.Estado;

                        _dbContex.Entry(EquipoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _EquipoDTO;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }
        }
        #endregion

        #region verificar Equipo por RowId.
        public async Task<bool> VerificarEquipo(int Codigo)
        {
            bool respuesta = false;
            if(Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from e in _dbContex.Equipos
                                   where e.EqRowid == Codigo
                                   select e).Count();

                        var ObjEquipo = lst;
                        if (ObjEquipo == null || ObjEquipo == 0)
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
                }
            }
            return respuesta;
        }
        #endregion

    }
}
