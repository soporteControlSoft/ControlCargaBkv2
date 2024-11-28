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
    /// Clase para el acceso a datos de la clase Ciudad
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 
    public class Ciudad:MdloDtos.IModelos.ICiudad
    {
        #region Ingresar datos a la entidad Ciudad
        public async Task<MdloDtos.Ciudad> IngresarCiudad(MdloDtos.Ciudad _Ciudad)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjCiudad = new MdloDtos.Ciudad();
                try
                {
                    var CiudadExiste = await this.VerificarCiudad(_Ciudad.CiCdgo);

                    if (CiudadExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjCiudad.CiCdgo = _Ciudad.CiCdgo;
                        ObjCiudad.CiNmbre = _Ciudad.CiNmbre;
                        ObjCiudad.CiRowidDprtmnto = _Ciudad.CiRowidDprtmnto;
                        var res = await _dbContex.Ciudads.AddAsync(ObjCiudad);
                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjCiudad;
            }

        }
        #endregion

        #region Consultar todos los datos de Ciudad mediante un parametro Codigo de Departamento
        public async Task<List<MdloDtos.Ciudad>> FiltrarCiudadPorDepartamento(int Codigo)
        {
            List<MdloDtos.Ciudad> listCiudad = new List<MdloDtos.Ciudad>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from ciudad in _dbContex.Ciudads
                                 join departamento in _dbContex.Departamentos on ciudad.CiRowidDprtmnto equals departamento.DeRowid into departamentoJoin
                                 from departamento in departamentoJoin.DefaultIfEmpty()


                                 where ciudad.CiRowidDprtmnto == Codigo

                                 select new
                                 {
                                     //Atributos Ciudad
                                     ciudadRowId = ciudad.CiRowid,
                                     ciudadCodigo = ciudad.CiCdgo,
                                     ciudadNombre = ciudad.CiNmbre,
                                     ciudadDepartamentoRowId = ciudad.CiRowidDprtmnto,

                                     //Atributos departamentos
                                     DepartamentoRowId = departamento.DeRowid,
                                     DepartamentoCodigo = departamento.DeCdgo,
                                     DepartamentoNombre = departamento.DeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Ciudad para agregar a la lista
                    MdloDtos.Ciudad objCiudad = new MdloDtos.Ciudad(
                                                                    //Atributos ciudad
                                                                    item.ciudadRowId != null ? item.ciudadRowId : 0,
                                                                    item.ciudadCodigo != null ? item.ciudadCodigo : String.Empty,
                                                                    item.ciudadNombre != null ? item.ciudadNombre : String.Empty,
                                                                    item.ciudadDepartamentoRowId != null ? item.ciudadDepartamentoRowId : 0,

                                                                    //Atributos departamento
                                                                    item.DepartamentoRowId != null ? item.DepartamentoRowId.ToString() : String.Empty,
                                                                    item.DepartamentoCodigo != null ? item.DepartamentoCodigo : String.Empty,
                                                                    item.DepartamentoNombre != null ? item.DepartamentoNombre : String.Empty
                                                                    );

                    //Agregamnos la ciudad a la lista
                    listCiudad.Add(objCiudad);
                }


                _dbContex.Dispose();
                return listCiudad;
            }

        }
        #endregion

        #region Listar todos los Ciudad
        public async Task<List<MdloDtos.Ciudad>> ListarCiudad()
        {
            List<MdloDtos.Ciudad> listCiudad = new List<MdloDtos.Ciudad>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from ciudad in _dbContex.Ciudads
                                 join departamento in _dbContex.Departamentos on ciudad.CiRowidDprtmnto equals departamento.DeRowid into departamentoJoin
                                 from departamento in departamentoJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Ciudad
                                     ciudadRowId = ciudad.CiRowid,
                                     ciudadCodigo = ciudad.CiCdgo,
                                     ciudadNombre = ciudad.CiNmbre,
                                     ciudadDepartamentoRowId = ciudad.CiRowidDprtmnto,

                                     //Atributos departamentos
                                     DepartamentoRowId = departamento.DeRowid,
                                     DepartamentoCodigo = departamento.DeCdgo,
                                     DepartamentoNombre = departamento.DeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Ciudad para agregar a la lista
                    MdloDtos.Ciudad objCiudad = new MdloDtos.Ciudad(
                                                                    //Atributos ciudad
                                                                    item.ciudadRowId != null ? item.ciudadRowId : 0,
                                                                    item.ciudadCodigo != null ? item.ciudadCodigo : String.Empty,
                                                                    item.ciudadNombre != null ? item.ciudadNombre : String.Empty,
                                                                    item.ciudadDepartamentoRowId != null ? item.ciudadDepartamentoRowId : 0,

                                                                    //Atributos departamento
                                                                    item.DepartamentoRowId != null ? item.DepartamentoRowId.ToString() : String.Empty,
                                                                    item.DepartamentoCodigo != null ? item.DepartamentoCodigo : String.Empty,
                                                                    item.DepartamentoNombre != null ? item.DepartamentoNombre : String.Empty
                                                                    );

                    //Agregamnos la ciudad a la lista
                    listCiudad.Add(objCiudad);
                }


                _dbContex.Dispose();
                return listCiudad;
            }
        }
        #endregion

        #region Actualizar departamentos por el objeto _Ciudad
        public async Task<MdloDtos.Ciudad> EditarCiudad(MdloDtos.Ciudad _Ciudad)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Ciudad CiudadExiste = await _dbContex.Ciudads.FindAsync(_Ciudad.CiRowid);
                    if (CiudadExiste != null)
                    {

                        CiudadExiste.CiCdgo = _Ciudad.CiCdgo;
                        CiudadExiste.CiNmbre = _Ciudad.CiNmbre;
                        CiudadExiste.CiRowidDprtmnto = _Ciudad.CiRowidDprtmnto;
                        _dbContex.Entry(CiudadExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return CiudadExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
               
            }
            
        }
        #endregion

        #region Filtrar Ciudad por codigo general
        public async Task<List<MdloDtos.Ciudad>> FiltrarCiudadGeneral(string Codigo)
        {
            List<MdloDtos.Ciudad> listCiudad = new List<MdloDtos.Ciudad>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from ciudad in _dbContex.Ciudads
                                 join departamento in _dbContex.Departamentos on ciudad.CiRowidDprtmnto equals departamento.DeRowid into departamentoJoin
                                 from departamento in departamentoJoin.DefaultIfEmpty()

                                 where ciudad.CiCdgo.Contains(Codigo) || ciudad.CiNmbre.Contains(Codigo)
                                 select new
                                 {
                                     //Atributos Ciudad
                                     ciudadRowId = ciudad.CiRowid,
                                     ciudadCodigo = ciudad.CiCdgo,
                                     ciudadNombre = ciudad.CiNmbre,
                                     ciudadDepartamentoRowId = ciudad.CiRowidDprtmnto,

                                     //Atributos departamentos
                                     DepartamentoRowId = departamento.DeRowid,
                                     DepartamentoCodigo = departamento.DeCdgo,
                                     DepartamentoNombre = departamento.DeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Ciudad para agregar a la lista
                    MdloDtos.Ciudad objCiudad = new MdloDtos.Ciudad(
                                                                    //Atributos ciudad
                                                                    item.ciudadRowId != null ? item.ciudadRowId : 0,
                                                                    item.ciudadCodigo != null ? item.ciudadCodigo : String.Empty,
                                                                    item.ciudadNombre != null ? item.ciudadNombre : String.Empty,
                                                                    item.ciudadDepartamentoRowId != null ? item.ciudadDepartamentoRowId : 0,

                                                                    //Atributos departamento
                                                                    item.DepartamentoRowId != null ? item.DepartamentoRowId.ToString() : String.Empty,
                                                                    item.DepartamentoCodigo != null ? item.DepartamentoCodigo : String.Empty,
                                                                    item.DepartamentoNombre != null ? item.DepartamentoNombre : String.Empty
                                                                    );

                    //Agregamnos la ciudad a la lista
                    listCiudad.Add(objCiudad);
                }


                _dbContex.Dispose();
                return listCiudad;
            }
        }
        #endregion

        #region Filtrar Ciudad por codigo Especifico Ciudad
        public async Task<List<MdloDtos.Ciudad>> FiltrarCiudadEspecifico(string Codigo)
        {
            List<MdloDtos.Ciudad> listCiudad = new List<MdloDtos.Ciudad>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from ciudad in _dbContex.Ciudads
                                 join departamento in _dbContex.Departamentos on ciudad.CiRowidDprtmnto equals departamento.DeRowid into departamentoJoin
                                 from departamento in departamentoJoin.DefaultIfEmpty()

                                 where ciudad.CiCdgo == Codigo
                                 select new
                                 {
                                     //Atributos Ciudad
                                     ciudadRowId = ciudad.CiRowid,
                                     ciudadCodigo = ciudad.CiCdgo,
                                     ciudadNombre = ciudad.CiNmbre,
                                     ciudadDepartamentoRowId = ciudad.CiRowidDprtmnto,

                                     //Atributos departamentos
                                     DepartamentoRowId = departamento.DeRowid,
                                     DepartamentoCodigo = departamento.DeCdgo,
                                     DepartamentoNombre = departamento.DeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Ciudad para agregar a la lista
                    MdloDtos.Ciudad objCiudad = new MdloDtos.Ciudad(
                                                                    //Atributos ciudad
                                                                    item.ciudadRowId != null ? item.ciudadRowId : 0,
                                                                    item.ciudadCodigo != null ? item.ciudadCodigo : String.Empty,
                                                                    item.ciudadNombre != null ? item.ciudadNombre : String.Empty,
                                                                    item.ciudadDepartamentoRowId != null ? item.ciudadDepartamentoRowId : 0,

                                                                    //Atributos departamento
                                                                    item.DepartamentoRowId != null ? item.DepartamentoRowId.ToString() : String.Empty,
                                                                    item.DepartamentoCodigo != null ? item.DepartamentoCodigo : String.Empty,
                                                                    item.DepartamentoNombre != null ? item.DepartamentoNombre : String.Empty
                                                                    );

                    //Agregamnos la ciudad a la lista
                    listCiudad.Add(objCiudad);
                }


                _dbContex.Dispose();
                return listCiudad;
            }
        }
        #endregion

        #region Eliminar Ciudad Por codigo.
        public async Task<MdloDtos.Ciudad> EliminarCiudad(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    int id = Convert.ToInt32(Codigo);
                    var CiudadExiste = await _dbContex.Ciudads.FindAsync(id);
                    if (CiudadExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(CiudadExiste);
                        await _dbContex.SaveChangesAsync();
                    }

                    _dbContex.Dispose();
                    return CiudadExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                
            }
        }
        #endregion

        #region verificar Ciudad por codigo.
        public async Task<bool> VerificarCiudad(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Ciudads
                               where p.CiCdgo == Codigo
                               select p).Count();

                    var ObjCiudad = lst;
                    if (ObjCiudad == null || ObjCiudad == 0)
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

        #region verificar Ciudad por RowId.
        public async Task<bool> VerificarCiudadPorRowId(int RowId)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Ciudads
                               where p.CiRowid == RowId
                               select p).Count();

                    var ObjCiudad = lst;
                    if (ObjCiudad == null || ObjCiudad == 0)
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
