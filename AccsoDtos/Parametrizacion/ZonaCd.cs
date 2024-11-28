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
    /// CRUD para el manejo de la ZonaCd
    /// Daniel Alejandro Lopez
    /// </summary>
    /// 
    public class ZonaCd:MdloDtos.IModelos.IZonaCd
    {
        #region Ingresar datos a la entidad ZonaCd
        public async Task<MdloDtos.ZonaCd> IngresarZonaCd(MdloDtos.ZonaCd _ZonaCd)
        {
            var ObjZonaCd = new MdloDtos.ZonaCd();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ZonaCdExiste = await this.VerificarZonaCodigo(_ZonaCd.ZcdCdgo);

                    if (ZonaCdExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {

                        ObjZonaCd.ZcdCdgo = _ZonaCd.ZcdCdgo;
                        ObjZonaCd.ZcdNmbre = _ZonaCd.ZcdNmbre;
                        ObjZonaCd.ZcdActvo = _ZonaCd.ZcdActvo;
                        ObjZonaCd.ZcdRowidSde = _ZonaCd.ZcdRowidSde;
                        ObjZonaCd.ZcdBdga = _ZonaCd.ZcdBdga;
                        ObjZonaCd.ZcdSlo = _ZonaCd.ZcdSlo;
                        ObjZonaCd.ZcdMlle = _ZonaCd.ZcdMlle;
                        ObjZonaCd.ZcdPtio = _ZonaCd.ZcdPtio;
                        ObjZonaCd.ZcdCpcdad = _ZonaCd.ZcdCpcdad;
                        ObjZonaCd.ZcdPlnta = _ZonaCd.ZcdPlnta;

                        var res = await _dbContex.ZonaCds.AddAsync(ObjZonaCd);
                        await _dbContex.SaveChangesAsync();
                    }
                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjZonaCd;
            }

        }
        #endregion

        #region valida si existe una ZonaCd validando nombre y Sede mediante un Objeto ZonaCd
        public bool ValidacionZonaNombreIngresar(MdloDtos.ZonaCd objZonaCd)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.ZonaCds
                           where    e.ZcdNmbre == objZonaCd.ZcdNmbre && 
                                    e.ZcdRowidSde== objZonaCd.ZcdRowidSde
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

        #region valida si existe una ZonaCd validando RowId, nombre y Sede pasando como parámetro un Objeto ZonaCd
        public bool ValidacionZonaNombreActualizar(MdloDtos.ZonaCd objZonaCd)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.ZonaCds
                           where    e.ZcdRowid != objZonaCd.ZcdRowid &&  
                                    e.ZcdNmbre == objZonaCd.ZcdNmbre &&
                                    e.ZcdRowidSde == objZonaCd.ZcdRowidSde
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

        #region Consultar todos los datos de ZonaCd mediante un parametro Codigo de Sede
        public async Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdPorSede(int Codigo)
        {
            List<MdloDtos.ZonaCd> listadoZonaCd = new List<MdloDtos.ZonaCd>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from zonaCD in _dbContex.ZonaCds
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()

                                 where zonaCD.ZcdRowidSde == Codigo

                                 select new
                                 {
                                     //Atributos ZonaCargueDescargue
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     //Atributos Sede
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.ZonaCd objZonaCd = new MdloDtos.ZonaCd(
                                                                //Atributos Vehículo
                                                                item.ZcdRowid != null ? item.ZcdRowid : 0,
                                                                item.ZcdCdgo != null ? item.ZcdCdgo : String.Empty,
                                                                item.ZcdNmbre != null ? item.ZcdNmbre : String.Empty,
                                                                item.ZcdActvo,
                                                                item.ZcdRowidSde,
                                                                item.ZcdBdga,
                                                                item.ZcdSlo,
                                                                item.ZcdMlle,
                                                                item.ZcdPtio,
                                                                item.ZcdCpcdad,
                                                                item.ZcdPlnta,

                                                                //Atributos Configuración Vehícular
                                                                item.SeRowid != null ? item.SeRowid.ToString() : null,
                                                                item.SeCdgo != null ? item.SeCdgo : null,
                                                                item.SeNmbre != null ? item.SeNmbre : null
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoZonaCd.Add(objZonaCd);
                }
                _dbContex.Dispose();
                return listadoZonaCd;
            }

        }
        #endregion

        #region Listar todos los ZonaCd
        public async Task<List<MdloDtos.ZonaCd>> ListarZonaCd()
        {
            List<MdloDtos.ZonaCd> listadoZonaCd = new List<MdloDtos.ZonaCd>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from zonaCD in _dbContex.ZonaCds
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos ZonaCargueDescargue
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     //Atributos Sede
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.ZonaCd objZonaCd = new MdloDtos.ZonaCd(
                                                                //Atributos Vehículo
                                                                item.ZcdRowid != null ? item.ZcdRowid : 0,
                                                                item.ZcdCdgo != null ? item.ZcdCdgo : String.Empty,
                                                                item.ZcdNmbre != null ? item.ZcdNmbre : String.Empty,
                                                                item.ZcdActvo,
                                                                item.ZcdRowidSde,
                                                                item.ZcdBdga,
                                                                item.ZcdSlo,
                                                                item.ZcdMlle,
                                                                item.ZcdPtio,
                                                                item.ZcdCpcdad,
                                                                item.ZcdPlnta,

                                                                //Atributos Configuración Vehícular
                                                                item.SeRowid != null ? item.SeRowid.ToString() : null,
                                                                item.SeCdgo != null ? item.SeCdgo : null,
                                                                item.SeNmbre != null ? item.SeNmbre : null
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoZonaCd.Add(objZonaCd);
                }
                _dbContex.Dispose();
                return listadoZonaCd;
            }
        }
        #endregion

        #region Actualizar ZonaCd por el objeto _ZonaCd
        public async Task<MdloDtos.ZonaCd> EditarZonaCd(MdloDtos.ZonaCd _ZonaCd)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try {
                    MdloDtos.ZonaCd ZonaCdxiste = await _dbContex.ZonaCds.FindAsync(_ZonaCd.ZcdRowid);
                    if (ZonaCdxiste != null)
                    {
                        ZonaCdxiste.ZcdCdgo = _ZonaCd.ZcdCdgo;
                        ZonaCdxiste.ZcdNmbre = _ZonaCd.ZcdNmbre;
                        ZonaCdxiste.ZcdActvo = _ZonaCd.ZcdActvo;
                        ZonaCdxiste.ZcdRowidSde = _ZonaCd.ZcdRowidSde;
                        ZonaCdxiste.ZcdBdga = _ZonaCd.ZcdBdga;
                        ZonaCdxiste.ZcdSlo = _ZonaCd.ZcdSlo;
                        ZonaCdxiste.ZcdMlle = _ZonaCd.ZcdMlle;
                        ZonaCdxiste.ZcdPtio = _ZonaCd.ZcdPtio;
                        ZonaCdxiste.ZcdCpcdad = _ZonaCd.ZcdCpcdad;
                        ZonaCdxiste.ZcdPlnta = _ZonaCd.ZcdPlnta;

                        _dbContex.Entry(ZonaCdxiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return ZonaCdxiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }
        #endregion

        #region Filtrar ZonaCd por codigo General
        public async Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdGeneral(string Codigo)
        {
            List<MdloDtos.ZonaCd> listadoZonaCd = new List<MdloDtos.ZonaCd>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from zonaCD in _dbContex.ZonaCds
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()

                                 where zonaCD.ZcdCdgo.Contains(Codigo) || zonaCD.ZcdNmbre.Contains(Codigo)

                                 select new
                                 {
                                     //Atributos ZonaCargueDescargue
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     //Atributos Sede
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.ZonaCd objZonaCd = new MdloDtos.ZonaCd(
                                                                //Atributos Vehículo
                                                                item.ZcdRowid != null ? item.ZcdRowid : 0,
                                                                item.ZcdCdgo != null ? item.ZcdCdgo : String.Empty,
                                                                item.ZcdNmbre != null ? item.ZcdNmbre : String.Empty,
                                                                item.ZcdActvo,
                                                                item.ZcdRowidSde,
                                                                item.ZcdBdga,
                                                                item.ZcdSlo,
                                                                item.ZcdMlle,
                                                                item.ZcdPtio,
                                                                item.ZcdCpcdad,
                                                                item.ZcdPlnta,

                                                                //Atributos Configuración Vehícular
                                                                item.SeRowid != null ? item.SeRowid.ToString() : null,
                                                                item.SeCdgo != null ? item.SeCdgo : null,
                                                                item.SeNmbre != null ? item.SeNmbre : null
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoZonaCd.Add(objZonaCd);
                }
                _dbContex.Dispose();
                return listadoZonaCd;
            }
        }
        #endregion

        #region Filtrar ZonaCd por codigo Especifico
        public async Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdEspecifico(string Codigo)
        {
            List<MdloDtos.ZonaCd> listadoZonaCd = new List<MdloDtos.ZonaCd>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from zonaCD in _dbContex.ZonaCds
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()

                                 where zonaCD.ZcdCdgo == Codigo

                                 select new
                                 {
                                     //Atributos ZonaCargueDescargue
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     //Atributos Sede
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.ZonaCd objZonaCd = new MdloDtos.ZonaCd(
                                                                //Atributos Vehículo
                                                                item.ZcdRowid != null ? item.ZcdRowid : 0,
                                                                item.ZcdCdgo != null ? item.ZcdCdgo : String.Empty,
                                                                item.ZcdNmbre != null ? item.ZcdNmbre : String.Empty,
                                                                item.ZcdActvo,
                                                                item.ZcdRowidSde,
                                                                item.ZcdBdga,
                                                                item.ZcdSlo,
                                                                item.ZcdMlle,
                                                                item.ZcdPtio,
                                                                item.ZcdCpcdad,
                                                                item.ZcdPlnta,

                                                                //Atributos Configuración Vehícular
                                                                item.SeRowid != null ? item.SeRowid.ToString() : null,
                                                                item.SeCdgo != null ? item.SeCdgo : null,
                                                                item.SeNmbre != null ? item.SeNmbre : null
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoZonaCd.Add(objZonaCd);
                }
                _dbContex.Dispose();
                return listadoZonaCd;
            }
        }
        #endregion

        #region Filtrar ZonaCd por id
        public async Task<List<MdloDtos.ZonaCd>> FiltrarZonaCdId(int? id)
        {
            List<MdloDtos.ZonaCd> listadoZonaCd = new List<MdloDtos.ZonaCd>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from zonaCD in _dbContex.ZonaCds
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()

                                 where zonaCD.ZcdRowid == id
                                 select new
                                 {
                                     //Atributos ZonaCargueDescargue
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     //Atributos Sede
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.ZonaCd objZonaCd = new MdloDtos.ZonaCd(
                                                                //Atributos Vehículo
                                                                item.ZcdRowid != null ? item.ZcdRowid : 0,
                                                                item.ZcdCdgo != null ? item.ZcdCdgo : String.Empty,
                                                                item.ZcdNmbre != null ? item.ZcdNmbre : String.Empty,
                                                                item.ZcdActvo,
                                                                item.ZcdRowidSde,
                                                                item.ZcdBdga,
                                                                item.ZcdSlo,
                                                                item.ZcdMlle,
                                                                item.ZcdPtio,
                                                                item.ZcdCpcdad,
                                                                item.ZcdPlnta,

                                                                //Atributos Configuración Vehícular
                                                                item.SeRowid != null ? item.SeRowid.ToString() : null,
                                                                item.SeCdgo != null ? item.SeCdgo : null,
                                                                item.SeNmbre != null ? item.SeNmbre : null
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoZonaCd.Add(objZonaCd);
                }
                _dbContex.Dispose();
                return listadoZonaCd;
            }
        }
        #endregion

        #region Eliminar ZonaCd Por codigo.
        public async Task<MdloDtos.ZonaCd> EliminarZonaCd(int Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ZonaCdExiste = await _dbContex.ZonaCds.FindAsync(Codigo);
                    if (ZonaCdExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(ZonaCdExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ZonaCdExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

        }
        #endregion

        #region verificar ZonaCd por Id.
        public async Task<bool> VerificarZonaId(int? ZonaId)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.ZonaCds
                               where p.ZcdRowid == ZonaId
                               select p).Count();

                    var ObjZonaCd = lst;
                    if (ObjZonaCd == null || ObjZonaCd == 0)
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

        #region verificar ZonaCd por Codigo.
        public async Task<bool> VerificarZonaCodigo(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.ZonaCds
                               where p.ZcdCdgo == Codigo
                               select p).Count();

                    var ObjZonaCd = lst;
                    if (ObjZonaCd == null || ObjZonaCd == 0)
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

        #region listar zona cd si por bodega, silo patio o muelle
        public async Task<List<MdloDtos.ZonaCd>> cargarZonaSegunLugar(string zn)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Definir la consulta base para `ZonaCd`
                var consulta = _dbContex.ZonaCds.AsQueryable();

                // Filtrar según el valor de `zn`
                switch (zn.ToLower())
                {
                    case "b":
                        consulta = consulta.Where(e => e.ZcdBdga == true);
                        break;
                    case "m":
                        consulta = consulta.Where(e => e.ZcdMlle == true);
                        break;
                    case "s":
                        consulta = consulta.Where(e => e.ZcdSlo == true);
                        break;
                    case "p":
                        consulta = consulta.Where(e => e.ZcdPtio == true);
                        break;
                    default:
                        // Retorna lista vacía si no coincide con ninguno de los casos
                        return new List<MdloDtos.ZonaCd>();
                }

                // Realizar el `join` con la tabla `Sedes` para traer los datos de la sede relacionada
                var lst = await (from zonaCD in consulta
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()
                                 select new
                                 {
                                     // Atributos de `ZonaCd`
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     // Atributos de `Sede`
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }).ToListAsync();

                // Crear la lista de retorno con los atributos adicionales de `Sede`
                var listadoZonaCd = lst.Select(item => new MdloDtos.ZonaCd
                (
                    item.ZcdRowid ?? 0,
                    item.ZcdCdgo ?? string.Empty,
                    item.ZcdNmbre ?? string.Empty,
                    item.ZcdActvo,
                    item.ZcdRowidSde,
                    item.ZcdBdga,
                    item.ZcdSlo,
                    item.ZcdMlle,
                    item.ZcdPtio,
                    item.ZcdCpcdad,
                    item.ZcdPlnta,
                    // Atributos de la sede
                    item.SeRowid != null ? item.SeRowid.ToString() : null,
                    item.SeCdgo,
                    item.SeNmbre
                )).ToList();

                return listadoZonaCd;
            }
        }

        #endregion

        #region listar zona cd si por bodega, silo patio o muelle y filtro de busqueda
        public async Task<List<MdloDtos.ZonaCd>> cargarZonaSegunLugarBuscar(string zn, string busqueda = "")
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Definir la consulta base para `ZonaCd`
                var consulta = _dbContex.ZonaCds.AsQueryable();

                // Determinar el campo a filtrar según el valor del parámetro `zn`
                switch (zn.ToLower())
                {
                    case "b":
                        consulta = consulta.Where(e => e.ZcdBdga == true);
                        break;
                    case "m":
                        consulta = consulta.Where(e => e.ZcdMlle == true);
                        break;
                    case "s":
                        consulta = consulta.Where(e => e.ZcdSlo == true);
                        break;
                    case "p":
                        consulta = consulta.Where(e => e.ZcdPtio == true);
                        break;
                    default:
                        // Si no coincide con ninguno de los casos, retorna una lista vacía
                        return new List<MdloDtos.ZonaCd>();
                }

                // Aplicar el filtro de búsqueda adicional si el parámetro `busqueda` tiene valor
                if (!string.IsNullOrEmpty(busqueda))
                {
                    consulta = consulta.Where(e => e.ZcdNmbre.Contains(busqueda) || e.ZcdCdgo.Contains(busqueda));
                }

                // Realizar el `join` con la tabla `Sedes` para traer los datos de la sede relacionada
                var lst = await (from zonaCD in consulta
                                 join sede in _dbContex.Sedes on zonaCD.ZcdRowidSde equals sede.SeRowid into sedeJoin
                                 from sede in sedeJoin.DefaultIfEmpty()
                                 select new
                                 {
                                     // Atributos de `ZonaCd`
                                     zonaCD.ZcdRowid,
                                     zonaCD.ZcdCdgo,
                                     zonaCD.ZcdNmbre,
                                     zonaCD.ZcdActvo,
                                     zonaCD.ZcdRowidSde,
                                     zonaCD.ZcdBdga,
                                     zonaCD.ZcdSlo,
                                     zonaCD.ZcdMlle,
                                     zonaCD.ZcdPtio,
                                     zonaCD.ZcdCpcdad,
                                     zonaCD.ZcdPlnta,

                                     // Atributos de `Sede`
                                     sede.SeRowid,
                                     sede.SeCdgo,
                                     sede.SeNmbre
                                 }).ToListAsync();

                // Crear la lista de retorno con los atributos adicionales de `Sede`
                var listadoZonaCd = lst.Select(item => new MdloDtos.ZonaCd
                (
                    item.ZcdRowid ?? 0,
                    item.ZcdCdgo ?? string.Empty,
                    item.ZcdNmbre ?? string.Empty,
                    item.ZcdActvo,
                    item.ZcdRowidSde,
                    item.ZcdBdga,
                    item.ZcdSlo,
                    item.ZcdMlle,
                    item.ZcdPtio,
                    item.ZcdCpcdad,
                    item.ZcdPlnta,
                    // Atributos de la sede
                    item.SeRowid != null ? item.SeRowid.ToString() : null,
                    item.SeCdgo,
                    item.SeNmbre
                )).ToList();

                return listadoZonaCd;
            }
        }


        //public async Task<List<MdloDtos.ZonaCd>> cargarZonaSegunLugarBuscar(string zn, string busqueda = "")
        //{
        //    using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        //    {
        //        // Definir la consulta base
        //        IQueryable<MdloDtos.ZonaCd> consulta = _dbContex.ZonaCds;

        //        // Determinar el campo a filtrar según el valor del parámetro zn
        //        switch (zn.ToLower())
        //        {
        //            case "b":
        //                consulta = consulta.Where(e => e.ZcdBdga == true);
        //                break;
        //            case "m":
        //                consulta = consulta.Where(e => e.ZcdMlle == true);
        //                break;
        //            case "s":
        //                consulta = consulta.Where(e => e.ZcdSlo == true);
        //                break;
        //            case "p":
        //                consulta = consulta.Where(e => e.ZcdPtio == true);
        //                break;
        //            default:
        //                // Si no coincide con ninguno de los casos, retorna una lista vacía
        //                return new List<MdloDtos.ZonaCd>();
        //        }

        //        // Aplicar el filtro de búsqueda adicional si el parámetro `busqueda` tiene valor
        //        if (!string.IsNullOrEmpty(busqueda))
        //        {
        //            consulta = consulta.Where(e => e.ZcdNmbre.Contains(busqueda) || e.ZcdCdgo.Contains(busqueda));
        //        }

        //        // Ejecutar la consulta y devolver los resultados como lista
        //        var lst = await consulta.ToListAsync();
        //        return lst;
        //    }
        //}

        #endregion


    }
}
