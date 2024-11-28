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
    ///     CRUD para el manejo de empaques
    ///     Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Empaque : MdloDtos.IModelos.IEmpaque
    {
       
        #region ingreso de datos a la entidad Empaque
        public async Task<MdloDtos.Empaque> IngresarEmpaque(MdloDtos.Empaque _Empaque)
        {
            var ObjEmpaque = new MdloDtos.Empaque();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var EmpaqueExiste = await this.VerificarEmpaque(_Empaque.EmCdgo);
                    if (EmpaqueExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {

                        ObjEmpaque.EmCdgoCia = _Empaque.EmCdgoCia;
                        ObjEmpaque.EmCdgo = _Empaque.EmCdgo;
                        ObjEmpaque.EmNmbre = _Empaque.EmNmbre;
                        ObjEmpaque.EmTra = _Empaque.EmTra;
                        ObjEmpaque.EmActvo = _Empaque.EmActvo;
                        var res = await _dbContex.Empaques.AddAsync(ObjEmpaque);
                        await _dbContex.SaveChangesAsync();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjEmpaque;
            }
        }
        #endregion

        #region Consulta los datos del empaque mediante un parámetro Codigo General
        public async Task<List<MdloDtos.Empaque>> FiltrarEmpaqueGeneral(string Codigo)
        {
            List<MdloDtos.Empaque> listadoEmpaque = new List<MdloDtos.Empaque>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from empaque in _dbContex.Empaques
                                 join compania in _dbContex.Compania on empaque.EmCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where empaque.EmCdgo.Contains(Codigo) || empaque.EmNmbre.Contains(Codigo)
                                 select new
                                 {
                                     //Atributos Empaque
                                     empaque.EmRowid,
                                     empaque.EmCdgoCia,
                                     empaque.EmCdgo,
                                     empaque.EmNmbre,
                                     empaque.EmTra,
                                     empaque.EmActvo,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Empaque para agregar a la lista
                    MdloDtos.Empaque objEmpaque = new MdloDtos.Empaque(
                                                                //Atributos Empaque
                                                                item.EmRowid != null ? item.EmRowid : 0,
                                                                item.EmCdgoCia != null ? item.EmCdgoCia : String.Empty,
                                                                item.EmCdgo != null ? item.EmCdgo : String.Empty,
                                                                item.EmNmbre != null ? item.EmNmbre : String.Empty,
                                                                item.EmTra != null ? (decimal?)Convert.ToDecimal(item.EmTra) : null,
                                                                item.EmActvo,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos el Modelo Empaque a la lista
                    listadoEmpaque.Add(objEmpaque);
                }
                _dbContex.Dispose();
                return listadoEmpaque;
            }
        }
        #endregion

        #region valida si existe un Empaque validando nombre y Compañia mediante un Objeto Empaque

        public bool ValidacionEmpaqueNombreIngresar(MdloDtos.Empaque _Empaque)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Empaques
                           where     e.EmNmbre == _Empaque.EmNmbre 
                                 &&  e.EmCdgoCia == _Empaque.EmCdgoCia
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

        #region valida si existe un Empaque validando RowId, nombre y Compañia pasando como parámetro un Objeto Empaque
        public bool ValidacionEmpaqueNombreActualizar(MdloDtos.Empaque _Empaque)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Empaques
                           where e.EmRowid != _Empaque.EmRowid
                                 &&
                                 e.EmNmbre == _Empaque.EmNmbre
                                 && e.EmCdgoCia == _Empaque.EmCdgoCia
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


        #region Consulta los datos del empaque mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.Empaque>> FiltrarEmpaqueEspecifico(string Codigo)
        {
            List<MdloDtos.Empaque> listadoEmpaque = new List<MdloDtos.Empaque>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from empaque in _dbContex.Empaques
                                 join compania in _dbContex.Compania on empaque.EmCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where empaque.EmCdgo == Codigo
                                 select new
                                 {
                                     //Atributos Empaque
                                     empaque.EmRowid,
                                     empaque.EmCdgoCia,
                                     empaque.EmCdgo,
                                     empaque.EmNmbre,
                                     empaque.EmTra,
                                     empaque.EmActvo,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Empaque para agregar a la lista
                    MdloDtos.Empaque objEmpaque = new MdloDtos.Empaque(
                                                                //Atributos Empaque
                                                                item.EmRowid != null ? item.EmRowid : 0,
                                                                item.EmCdgoCia != null ? item.EmCdgoCia : String.Empty,
                                                                item.EmCdgo != null ? item.EmCdgo : String.Empty,
                                                                item.EmNmbre != null ? item.EmNmbre : String.Empty,
                                                                item.EmTra != null ? (decimal?)Convert.ToDecimal(item.EmTra) : null,
                                                                item.EmActvo,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos el Modelo Empaque a la lista
                    listadoEmpaque.Add(objEmpaque);
                }
                _dbContex.Dispose();
                return listadoEmpaque;
            }
        }
        #endregion

        #region Actualiza un Empaque pasando un objeto _Motonave
        public async Task<MdloDtos.Empaque> EditarEmpaque(MdloDtos.Empaque _Empaque)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Empaque EmpaqueExiste = await _dbContex.Empaques.FindAsync(_Empaque.EmRowid);
                    if (EmpaqueExiste != null)
                    {
                        EmpaqueExiste.EmCdgoCia = _Empaque.EmCdgoCia;
                        EmpaqueExiste.EmCdgo = _Empaque.EmCdgo;
                        EmpaqueExiste.EmNmbre = _Empaque.EmNmbre;
                        EmpaqueExiste.EmTra = _Empaque.EmTra;
                        EmpaqueExiste.EmActvo = _Empaque.EmActvo;

                        _dbContex.Empaques.Entry(EmpaqueExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return EmpaqueExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de los Empaques.
        public async Task<List<MdloDtos.Empaque>> ListarEmpaque()
        {
            List<MdloDtos.Empaque> listadoEmpaque = new List<MdloDtos.Empaque>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from empaque in _dbContex.Empaques
                                 join compania in _dbContex.Compania on empaque.EmCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Empaque
                                     empaque.EmRowid,
                                     empaque.EmCdgoCia,
                                     empaque.EmCdgo,
                                     empaque.EmNmbre,
                                     empaque.EmTra,
                                     empaque.EmActvo,

                                     //Atributos Compañia
                                     companiaCodigo = compania.CiaCdgo,
                                     companiaNombre = compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Empaque para agregar a la lista
                    MdloDtos.Empaque objEmpaque = new MdloDtos.Empaque(
                                                                //Atributos Empaque
                                                                item.EmRowid != null ? item.EmRowid : 0,
                                                                item.EmCdgoCia != null ? item.EmCdgoCia : String.Empty,
                                                                item.EmCdgo != null ? item.EmCdgo : String.Empty,
                                                                item.EmNmbre != null ? item.EmNmbre : String.Empty,
                                                                item.EmTra != null ? (decimal?)Convert.ToDecimal(item.EmTra) : null,
                                                                item.EmActvo,

                                                                //Atributos Compañia
                                                                item.companiaCodigo != null ? item.companiaCodigo.ToString() : String.Empty,
                                                                item.companiaNombre != null ? item.companiaNombre : String.Empty
                                                               );
                    //Agregamnos el Modelo Empaque a la lista
                    listadoEmpaque.Add(objEmpaque);
                }
                _dbContex.Dispose();
                return listadoEmpaque;
            }
        }
        #endregion

        #region Elimina un Empaque pasando como parámetro Codigo
        public async Task<MdloDtos.Empaque> EliminarEmpaque(int RowId)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var EmpaqueExiste = await _dbContex.Empaques.FindAsync(RowId);
                    if (EmpaqueExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Empaques.Remove(EmpaqueExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return EmpaqueExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar un Empaque
        public async Task<bool> VerificarEmpaque(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Empaques
                               where p.EmCdgo == Codigo
                               select p).Count();

                    var ObjEmpaque = lst;
                    if (ObjEmpaque == null || ObjEmpaque == 0)
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
