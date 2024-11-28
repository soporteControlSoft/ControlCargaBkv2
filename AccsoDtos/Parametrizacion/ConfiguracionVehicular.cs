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
    /// Clase para el acceso a datos de la clase configuracion vehicular.
    /// Daniel Alejandro Lopez
    /// </summary>
    public class ConfiguracionVehicular: MdloDtos.IModelos.IConfiguracionVehicular
    {
        #region Ingresar datos a la Configuracion Vehicular
        public async Task<MdloDtos.ConfiguracionVehicular> IngresarConfiguracionVehicular(MdloDtos.ConfiguracionVehicular _ConfiguracionVehicular)
        {
            var ObjConfiguracionVehicular = new MdloDtos.ConfiguracionVehicular();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ConfiguracionVehicularExiste = await this.VerificarConfiguracionVehicular(_ConfiguracionVehicular.CvCdgo);

                    if (ConfiguracionVehicularExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjConfiguracionVehicular.CvCdgo = _ConfiguracionVehicular.CvCdgo;
                        ObjConfiguracionVehicular.CvNmbre = _ConfiguracionVehicular.CvNmbre;
                        ObjConfiguracionVehicular.CvPsoMxmo = _ConfiguracionVehicular.CvPsoMxmo;
                        ObjConfiguracionVehicular.CvTlrncia = _ConfiguracionVehicular.CvTlrncia;
                        ObjConfiguracionVehicular.CvCdgoCia = _ConfiguracionVehicular.CvCdgoCia;
                        ObjConfiguracionVehicular.CvActvo = _ConfiguracionVehicular.CvActvo;
                        var res = await _dbContex.ConfiguracionVehiculars.AddAsync(ObjConfiguracionVehicular);
                        await _dbContex.SaveChangesAsync();
                    }

                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjConfiguracionVehicular;
            }

        }
        #endregion

        #region Consultar todos los datos de Configuracion Vehicular mediante un parametro Codigo general
        public async Task<List<MdloDtos.ConfiguracionVehicular>> FiltrarConfiguracionVehicularGeneral(String Codigo)
        {
            List<MdloDtos.ConfiguracionVehicular> listadoConfiguracionVehicular = new List<MdloDtos.ConfiguracionVehicular>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from configuracionVehicular in _dbContex.ConfiguracionVehiculars
                                 join compania in _dbContex.Compania on configuracionVehicular.CvCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where configuracionVehicular.CvCdgo.Contains(Codigo) || configuracionVehicular.CvNmbre.Contains(Codigo)

                                 select new
                                 {
                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre,
                                     configuracionVehicular.CvPsoMxmo,
                                     configuracionVehicular.CvTlrncia,
                                     configuracionVehicular.CvCdgoCia,
                                     configuracionVehicular.CvActvo,

                                     //Atributos Compañia
                                     compania.CiaCdgo,
                                     compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Configuración Vehicular para agregar a la lista
                    MdloDtos.ConfiguracionVehicular objConfiguracionVehicular = new MdloDtos.ConfiguracionVehicular(
                                                                //Atributos Configuracion Vehícular
                                                                item.CvRowid != null ? item.CvRowid : 0,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty,
                                                                item.CvPsoMxmo != null ? item.CvPsoMxmo : 0,
                                                                item.CvTlrncia != null ? item.CvTlrncia : 0,
                                                                item.CvCdgoCia != null ? item.CvCdgoCia : String.Empty,
                                                                item.CvActvo,

                                                                //Atributos Compañia
                                                                item.CiaCdgo != null ? item.CiaCdgo.ToString() : String.Empty,
                                                                item.CiaNmbre != null ? item.CiaNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoConfiguracionVehicular.Add(objConfiguracionVehicular);
                }
                _dbContex.Dispose();
                return listadoConfiguracionVehicular;
            }

        }
        #endregion

        #region Consultar todos los datos de Configuracion Vehicular mediante un parametro Codigo Configuracion vehicular
        public async Task<List<MdloDtos.ConfiguracionVehicular>> FiltrarConfiguracionVehicularEspecifico(String Codigo)
        {
            List<MdloDtos.ConfiguracionVehicular> listadoConfiguracionVehicular = new List<MdloDtos.ConfiguracionVehicular>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from configuracionVehicular in _dbContex.ConfiguracionVehiculars
                                 join compania in _dbContex.Compania on configuracionVehicular.CvCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where configuracionVehicular.CvCdgo == Codigo

                                 select new
                                 {
                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre,
                                     configuracionVehicular.CvPsoMxmo,
                                     configuracionVehicular.CvTlrncia,
                                     configuracionVehicular.CvCdgoCia,
                                     configuracionVehicular.CvActvo,

                                     //Atributos Compañia
                                     compania.CiaCdgo,
                                     compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Configuración Vehicular para agregar a la lista
                    MdloDtos.ConfiguracionVehicular objConfiguracionVehicular = new MdloDtos.ConfiguracionVehicular(
                                                                //Atributos Configuracion Vehícular
                                                                item.CvRowid != null ? item.CvRowid : 0,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty,
                                                                item.CvPsoMxmo != null ? item.CvPsoMxmo : 0,
                                                                item.CvTlrncia != null ? item.CvTlrncia : 0,
                                                                item.CvCdgoCia != null ? item.CvCdgoCia : String.Empty,
                                                                item.CvActvo,

                                                                //Atributos Compañia
                                                                item.CiaCdgo != null ? item.CiaCdgo.ToString() : String.Empty,
                                                                item.CiaNmbre != null ? item.CiaNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoConfiguracionVehicular.Add(objConfiguracionVehicular);
                }
                _dbContex.Dispose();
                return listadoConfiguracionVehicular;
            }

        }
        #endregion

        #region Consultar todos los datos de Configuracion Vehicular mediante un parametro Id Configuracion vehicular
        public async Task<List<MdloDtos.ConfiguracionVehicular>> FiltrarConfiguracionVehicularId(int? IdConfiguracion)
        {
            List<MdloDtos.ConfiguracionVehicular> listadoConfiguracionVehicular = new List<MdloDtos.ConfiguracionVehicular>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from configuracionVehicular in _dbContex.ConfiguracionVehiculars
                                 join compania in _dbContex.Compania on configuracionVehicular.CvCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 where configuracionVehicular.CvRowid == IdConfiguracion

                                 select new
                                 {
                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre,
                                     configuracionVehicular.CvPsoMxmo,
                                     configuracionVehicular.CvTlrncia,
                                     configuracionVehicular.CvCdgoCia,
                                     configuracionVehicular.CvActvo,

                                     //Atributos Compañia
                                     compania.CiaCdgo,
                                     compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Configuración Vehicular para agregar a la lista
                    MdloDtos.ConfiguracionVehicular objConfiguracionVehicular = new MdloDtos.ConfiguracionVehicular(
                                                                //Atributos Configuracion Vehícular
                                                                item.CvRowid != null ? item.CvRowid : 0,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty,
                                                                item.CvPsoMxmo != null ? item.CvPsoMxmo : 0,
                                                                item.CvTlrncia != null ? item.CvTlrncia : 0,
                                                                item.CvCdgoCia != null ? item.CvCdgoCia : String.Empty,
                                                                item.CvActvo,

                                                                //Atributos Compañia
                                                                item.CiaCdgo != null ? item.CiaCdgo.ToString() : String.Empty,
                                                                item.CiaNmbre != null ? item.CiaNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoConfiguracionVehicular.Add(objConfiguracionVehicular);
                }
                _dbContex.Dispose();
                return listadoConfiguracionVehicular;
            }

        }
        #endregion

        #region Actualizar Configuracion Vehicular pasando el objeto _ConfiguracionVehicular
        public async Task<MdloDtos.ConfiguracionVehicular> EditarConfiguracionVehicular(MdloDtos.ConfiguracionVehicular _ConfiguracionVehicular)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.ConfiguracionVehicular ConfiguracionVehicularExiste = await _dbContex.ConfiguracionVehiculars.FindAsync(_ConfiguracionVehicular.CvRowid);
                    if (ConfiguracionVehicularExiste != null)
                    {

                        ConfiguracionVehicularExiste.CvCdgo = _ConfiguracionVehicular.CvCdgo;
                        ConfiguracionVehicularExiste.CvNmbre = _ConfiguracionVehicular.CvNmbre;
                        ConfiguracionVehicularExiste.CvPsoMxmo = _ConfiguracionVehicular.CvPsoMxmo;
                        ConfiguracionVehicularExiste.CvTlrncia = _ConfiguracionVehicular.CvTlrncia;
                        ConfiguracionVehicularExiste.CvCdgoCia = _ConfiguracionVehicular.CvCdgoCia;
                        ConfiguracionVehicularExiste.CvActvo = _ConfiguracionVehicular.CvActvo;
                        _dbContex.Entry(ConfiguracionVehicularExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return ConfiguracionVehicularExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }  
            }
        }

        #endregion

        #region Consultar todos los datos de Configuracion Vehicular
        public async Task<List<MdloDtos.ConfiguracionVehicular>> ListarConfiguracionVehicular()
        {
            List<MdloDtos.ConfiguracionVehicular> listadoConfiguracionVehicular = new List<MdloDtos.ConfiguracionVehicular>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from configuracionVehicular in _dbContex.ConfiguracionVehiculars
                                 join compania in _dbContex.Compania on configuracionVehicular.CvCdgoCia equals compania.CiaCdgo into companiaJoin
                                 from compania in companiaJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre,
                                     configuracionVehicular.CvPsoMxmo,
                                     configuracionVehicular.CvTlrncia,
                                     configuracionVehicular.CvCdgoCia,
                                     configuracionVehicular.CvActvo,

                                     //Atributos Compañia
                                     compania.CiaCdgo,
                                     compania.CiaNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Configuración Vehicular para agregar a la lista
                    MdloDtos.ConfiguracionVehicular objConfiguracionVehicular = new MdloDtos.ConfiguracionVehicular(
                                                                //Atributos Configuracion Vehícular
                                                                item.CvRowid != null ? item.CvRowid : 0,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty,
                                                                item.CvPsoMxmo != null ? item.CvPsoMxmo : 0,
                                                                item.CvTlrncia != null ? item.CvTlrncia : 0,
                                                                item.CvCdgoCia != null ? item.CvCdgoCia : String.Empty,
                                                                item.CvActvo,

                                                                //Atributos Compañia
                                                                item.CiaCdgo != null ? item.CiaCdgo.ToString() : String.Empty,
                                                                item.CiaNmbre != null ? item.CiaNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoConfiguracionVehicular.Add(objConfiguracionVehicular);
                }
                _dbContex.Dispose();
                return listadoConfiguracionVehicular;
            }
        }

        #endregion

        #region Eliminar Configuracion Vehicular
        public async Task<MdloDtos.ConfiguracionVehicular> EliminarConfiguracionVehicular(int Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ConfiguracionVehicularlExiste = await _dbContex.ConfiguracionVehiculars.FindAsync(Codigo);
                    if (ConfiguracionVehicularlExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(ConfiguracionVehicularlExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ConfiguracionVehicularlExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
                
            }


        }

        #endregion

        #region verificar Configuracion Vehicular por Codigo
        public async Task<bool> VerificarConfiguracionVehicular(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.ConfiguracionVehiculars
                               where p.CvCdgo == Codigo
                               select p).Count();

                    var ObjConfiguracionVehicular = lst;

                    if (ObjConfiguracionVehicular == null || ObjConfiguracionVehicular == 0)
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

        #region verificar Configuracion Vehicular por RowId
        public async Task<bool> VerificarConfiguracionVehicularPorRowdId(int RowId)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.ConfiguracionVehiculars
                               where p.CvRowid == RowId
                               select p).Count();

                    var ObjConfiguracionVehicular = lst;

                    if (ObjConfiguracionVehicular == null || ObjConfiguracionVehicular == 0)
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
