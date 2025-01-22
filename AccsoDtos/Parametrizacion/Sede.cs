using AutoMapper;
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
    /// CRUD para el manejo de la Sede
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 


    public class Sede:MdloDtos.IModelos.ISede
    {

        private readonly IMapper _mapper;

        public Sede(IMapper mapper)
        {
            _mapper = mapper;
        }
        #region Ingresar datos a la entidad Sede
        public async Task<dynamic> IngresarSede(MdloDtos.DTO.SedeDTO _Sede)
        {
            var ObjSede = new MdloDtos.Sede();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var SedeExiste = await this.VerificarSede(_Sede.SeCdgo);

                    if (SedeExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjSede.SeCdgo = _Sede.SeCdgo;
                        ObjSede.SeCdgoCia = _Sede.SeCdgoCia;
                        ObjSede.SeNmbre = _Sede.SeNmbre;
                        ObjSede.SeActvo = _Sede.SeActvo;
                        ObjSede.SeDpstoAdnro = _Sede.SeDpstoAdnro;
                        ObjSede.SeCdgoDpstoAdnro = _Sede.SeCdgoDpstoAdnro;

                        var res = await _dbContex.Sedes.AddAsync(ObjSede);
                        await _dbContex.SaveChangesAsync();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSede;
            }

        }
        #endregion

        #region Consultar todos los datos de Sede mediante un parametro Codigo de Compania
        public async Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedePorCompania(string Codigo)
        {
            List<MdloDtos.DTO.SedeDTO> listadoSede = new List<MdloDtos.DTO.SedeDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from sede in _dbContex.Sedes
                                 join compania in _dbContex.Compania on sede.SeCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where sede.SeCdgoCia == Codigo

                                 select new
                                 {
                                     //Atributos Sedes
                                     sedeRowId = sede.SeRowid,
                                     sedeCodigo = sede.SeCdgo,
                                     sedeCodigoCompania = sede.SeCdgoCia,
                                     sedeNombre = sede.SeNmbre,
                                     sedeActivo = sede.SeActvo,
                                     sedeDepositoAduanero = sede.SeDpstoAdnro,
                                     sedeCodigoDepositoAduanero = sede.SeCdgoDpstoAdnro,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.SedeDTO objSede = new MdloDtos.DTO.SedeDTO(
                                                                //Atributos Sede
                                                                item.sedeRowId != null ? item.sedeRowId : 0,
                                                                item.sedeCodigo != null ? item.sedeCodigo : String.Empty,
                                                                item.sedeCodigoCompania != null ? item.sedeCodigoCompania : String.Empty,
                                                                item.sedeNombre != null ? item.sedeNombre : String.Empty,
                                                                item.sedeActivo,
                                                                item.sedeDepositoAduanero,
                                                                item.sedeCodigoDepositoAduanero != null ? item.sedeCodigoDepositoAduanero : String.Empty,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoSede.Add(objSede);
                }
                _dbContex.Dispose();
                return listadoSede;
            }

        }
        #endregion

        #region Listar todos las Sedes
        public async Task<List<MdloDtos.DTO.SedeDTO>> ListarSede()
        {
            List<MdloDtos.DTO.SedeDTO> listadoSede = new List<MdloDtos.DTO.SedeDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from sede in _dbContex.Sedes
                                 join compania in _dbContex.Compania on sede.SeCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Sedes
                                     sedeRowId = sede.SeRowid,
                                     sedeCodigo = sede.SeCdgo,
                                     sedeCodigoCompania = sede.SeCdgoCia,
                                     sedeNombre = sede.SeNmbre,
                                     sedeActivo = sede.SeActvo,
                                     sedeDepositoAduanero = sede.SeDpstoAdnro,
                                     sedeCodigoDepositoAduanero = sede.SeCdgoDpstoAdnro,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.SedeDTO objSede = new MdloDtos.DTO.SedeDTO(
                                                                //Atributos Sede
                                                                item.sedeRowId != null ? item.sedeRowId : 0,
                                                                item.sedeCodigo != null ? item.sedeCodigo : String.Empty,
                                                                item.sedeCodigoCompania != null ? item.sedeCodigoCompania : String.Empty,
                                                                item.sedeNombre != null ? item.sedeNombre : String.Empty,
                                                                item.sedeActivo,
                                                                item.sedeDepositoAduanero,
                                                                item.sedeCodigoDepositoAduanero != null ? item.sedeCodigoDepositoAduanero : String.Empty,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoSede.Add(objSede);
                }
                _dbContex.Dispose();
                return listadoSede;
            }
        }
        #endregion

        #region Actualizar Sede por el objeto _Sede
        public async Task<MdloDtos.DTO.SedeDTO> EditarSede(MdloDtos.DTO.SedeDTO _Sede)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Sede SedeExiste = await _dbContex.Sedes.FindAsync(_Sede.SeRowid);
                    if (SedeExiste != null)
                    {

                        SedeExiste.SeCdgo = _Sede.SeCdgo;
                        SedeExiste.SeCdgoCia = _Sede.SeCdgoCia;
                        SedeExiste.SeNmbre = _Sede.SeNmbre;
                        SedeExiste.SeActvo = _Sede.SeActvo;
                        SedeExiste.SeDpstoAdnro = _Sede.SeDpstoAdnro;
                        SedeExiste.SeCdgoDpstoAdnro = _Sede.SeCdgoDpstoAdnro;
                        _dbContex.Entry(SedeExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _Sede;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Filtrar Sede por codigo general
        public async Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedeGeneral(string Codigo)
        {
            List<MdloDtos.DTO.SedeDTO> listadoSede = new List<MdloDtos.DTO.SedeDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from sede in _dbContex.Sedes
                                 join compania in _dbContex.Compania on sede.SeCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where sede.SeCdgo.Contains(Codigo) || sede.SeNmbre.Contains(Codigo)
                                 select new
                                 {
                                     //Atributos Sedes
                                     sedeRowId = sede.SeRowid,
                                     sedeCodigo = sede.SeCdgo,
                                     sedeCodigoCompania = sede.SeCdgoCia,
                                     sedeNombre = sede.SeNmbre,
                                     sedeActivo = sede.SeActvo,
                                     sedeDepositoAduanero = sede.SeDpstoAdnro,
                                     sedeCodigoDepositoAduanero = sede.SeCdgoDpstoAdnro,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.SedeDTO objSede = new MdloDtos.DTO.SedeDTO(
                                                                //Atributos Sede
                                                                item.sedeRowId != null ? item.sedeRowId : 0,
                                                                item.sedeCodigo != null ? item.sedeCodigo : String.Empty,
                                                                item.sedeCodigoCompania != null ? item.sedeCodigoCompania : String.Empty,
                                                                item.sedeNombre != null ? item.sedeNombre : String.Empty,
                                                                item.sedeActivo,
                                                                item.sedeDepositoAduanero,
                                                                item.sedeCodigoDepositoAduanero != null ? item.sedeCodigoDepositoAduanero : String.Empty,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoSede.Add(objSede);
                }
                _dbContex.Dispose();
                return listadoSede;
            }
        }
        #endregion

        #region Filtrar Sede por codigo especifico
        public async Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedeEspecifico(string Codigo)
        {
            List<MdloDtos.DTO.SedeDTO> listadoSede = new List<MdloDtos.DTO.SedeDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from sede in _dbContex.Sedes
                                 join compania in _dbContex.Compania on sede.SeCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()
                                 where sede.SeCdgo == Codigo
                                 select new
                                 {
                                     //Atributos Sedes
                                     sedeRowId = sede.SeRowid,
                                     sedeCodigo = sede.SeCdgo,
                                     sedeCodigoCompania = sede.SeCdgoCia,
                                     sedeNombre = sede.SeNmbre,
                                     sedeActivo = sede.SeActvo,
                                     sedeDepositoAduanero = sede.SeDpstoAdnro,
                                     sedeCodigoDepositoAduanero = sede.SeCdgoDpstoAdnro,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.SedeDTO objSede = new MdloDtos.DTO.SedeDTO(
                                                                //Atributos Sede
                                                                item.sedeRowId != null ? item.sedeRowId : 0,
                                                                item.sedeCodigo != null ? item.sedeCodigo : String.Empty,
                                                                item.sedeCodigoCompania != null ? item.sedeCodigoCompania : String.Empty,
                                                                item.sedeNombre != null ? item.sedeNombre : String.Empty,
                                                                item.sedeActivo,
                                                                item.sedeDepositoAduanero,
                                                                item.sedeCodigoDepositoAduanero != null ? item.sedeCodigoDepositoAduanero : String.Empty,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoSede.Add(objSede);
                }
                _dbContex.Dispose();
                return listadoSede;
            }
        }
        #endregion

        #region Filtrar Sede por Id especifico
        public async Task<List<MdloDtos.DTO.SedeDTO>> FiltrarSedeId(int SedeId)
        {
            List<MdloDtos.DTO.SedeDTO> listadoSede = new List<MdloDtos.DTO.SedeDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from sede in _dbContex.Sedes
                                 join compania in _dbContex.Compania on sede.SeCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()
                                 where sede.SeRowid == SedeId
                                 select new
                                 {
                                     //Atributos Sedes
                                     sedeRowId = sede.SeRowid,
                                     sedeCodigo = sede.SeCdgo,
                                     sedeCodigoCompania = sede.SeCdgoCia,
                                     sedeNombre = sede.SeNmbre,
                                     sedeActivo = sede.SeActvo,
                                     sedeDepositoAduanero = sede.SeDpstoAdnro,
                                     sedeCodigoDepositoAduanero = sede.SeCdgoDpstoAdnro,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.SedeDTO objSede = new MdloDtos.DTO.SedeDTO(
                                                                //Atributos Sede
                                                                item.sedeRowId != null ? item.sedeRowId : 0,
                                                                item.sedeCodigo != null ? item.sedeCodigo : String.Empty,
                                                                item.sedeCodigoCompania != null ? item.sedeCodigoCompania : String.Empty,
                                                                item.sedeNombre != null ? item.sedeNombre : String.Empty,
                                                                item.sedeActivo,
                                                                item.sedeDepositoAduanero,
                                                                item.sedeCodigoDepositoAduanero != null ? item.sedeCodigoDepositoAduanero : String.Empty,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoSede.Add(objSede);
                }
                _dbContex.Dispose();
                return listadoSede;
            }
        }
        #endregion

        #region Eliminar Sede Por codigo.
        public async Task<dynamic> EliminarSede(int Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {

                    var SedeExiste = await _dbContex.Sedes.FindAsync(Codigo);
                    if (SedeExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(SedeExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return SedeExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

        }
        #endregion

        #region valida si existe una sede validando nombre y compañia mediante un Objeto Sede
        public bool ValidacionSedeNombreIngresar(MdloDtos.DTO.SedeDTO objSede)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Sedes
                           where e.SeNmbre == objSede.SeNmbre
                            && e.SeCdgoCia == objSede.SeCdgoCia
                           select e).Count();

                if (lst > 0)
                {
                    retorno = true;

                }

                _dbContex.Dispose();
                return retorno;

            }
        }
        #endregion


        #region valida si existe una sede validando codigo, nombre y compañia pasando como parámetro un Objeto Sede
        public bool ValidacionSedeNombreActualizar(MdloDtos.DTO.SedeDTO objSede)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Sedes
                           where    e.SeCdgo != objSede.SeCdgo &&
                                    e.SeNmbre == objSede.SeNmbre &&
                                    e.SeCdgoCia == objSede.SeCdgoCia
                           select e).Count();

                if (lst > 0)
                {
                    retorno = true;

                }

                _dbContex.Dispose();
                return retorno;

            }
        }
        #endregion

        #region verificar Sede por codigo.
        public async Task<bool> VerificarSede(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Sedes
                               where p.SeCdgo == Codigo
                               select p).Count();

                    var ObjSede = lst;
                    if (ObjSede == null || ObjSede == 0)
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

        #region verificar Sede por RowId.
        public async Task<bool> VerificarSedePorRowId(int RowId)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Sedes
                               where p.SeRowid == RowId
                               select p).Count();

                    var ObjSede = lst;
                    if (ObjSede == null || ObjSede == 0)
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
