using MdloDtos;
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
    /// CRUD para el manejo de Tercero
    /// Daniel Alejandro Lopez
    /// </summary>
    public class Tercero:MdloDtos.IModelos.ITercero
    {

        #region Ingresar datos a la entidad Tercero
        public async Task<MdloDtos.Tercero> IngresarTercero(MdloDtos.Tercero _Tercero)
        {
            var ObjTercero = new MdloDtos.Tercero();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TerceroExiste = await this.VerificarTercero(_Tercero.TeCdgo);

                    if (TerceroExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjTercero.TeCdgoCia = _Tercero.TeCdgoCia;
                        ObjTercero.TeCdgo = _Tercero.TeCdgo;
                        ObjTercero.TeNmbre = _Tercero.TeNmbre;
                        ObjTercero.TeIdntfccion = _Tercero.TeIdntfccion;
                        ObjTercero.TeTpoIdntfccion = _Tercero.TeTpoIdntfccion;
                        ObjTercero.TeDv = _Tercero.TeDv;
                        ObjTercero.TeDrccion = _Tercero.TeDrccion;
                        ObjTercero.TeTlfno = _Tercero.TeTlfno;
                        ObjTercero.TeEmail = _Tercero.TeEmail;
                        ObjTercero.TeActvo = _Tercero.TeActvo;
                        ObjTercero.TeClnte = _Tercero.TeClnte;
                        ObjTercero.TePrtclar = _Tercero.TePrtclar;
                        ObjTercero.TeFncnrio = _Tercero.TeFncnrio;
                        ObjTercero.TeTrnsprtdra = _Tercero.TeTrnsprtdra;
                        ObjTercero.TeAgnteMrtmo = _Tercero.TeAgnteMrtmo;
                        ObjTercero.TeVnddor = _Tercero.TeVnddor;
                        ObjTercero.TeOprdorPrtrio = _Tercero.TeOprdorPrtrio;
                        ObjTercero.TeMnjoPrpio = _Tercero.TeMnjoPrpio;
                        ObjTercero.TeNmbreCntcto = _Tercero.TeNmbreCntcto;
                        ObjTercero.TeCdgoGrpoTrcro = _Tercero.TeCdgoGrpoTrcro;
                        ObjTercero.TeAgnciaAdna = _Tercero.TeAgnciaAdna;
                        ObjTercero.TeOprdorScndrio = _Tercero.TeOprdorScndrio;
                        var res = await _dbContex.Terceros.AddAsync(ObjTercero);
                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjTercero;
            }

        }
        #endregion

        #region Consultar todos los datos de Tercero mediante un parametro Codigo general
        public async Task<List<MdloDtos.Tercero>> FiltrarTerceroGeneral(String Codigo)
        {
            List<MdloDtos.Tercero> listadoTercero = new List<MdloDtos.Tercero>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from tercero in _dbContex.Terceros
                                 join grupoTercero in _dbContex.GrupoTerceros on tercero.TeCdgoGrpoTrcro equals grupoTercero.GtCdgo into grupoTerceroJoin
                                 from grupoTercero in grupoTerceroJoin.DefaultIfEmpty()

                                 where tercero.TeCdgo.Contains(Codigo) || tercero.TeNmbre.Contains(Codigo)

                                 select new
                                 {
                                     //Atributos Tercero
                                     tercero.TeRowid,
                                     tercero.TeCdgoCia,
                                     tercero.TeCdgo,
                                     tercero.TeNmbre,
                                     tercero.TeIdntfccion,
                                     tercero.TeTpoIdntfccion,
                                     tercero.TeDv,
                                     tercero.TeDrccion,
                                     tercero.TeTlfno,
                                     tercero.TeEmail,
                                     tercero.TeActvo,
                                     tercero.TeClnte,
                                     tercero.TePrtclar,
                                     tercero.TeFncnrio,
                                     tercero.TeTrnsprtdra,
                                     tercero.TeAgnteMrtmo,
                                     tercero.TeVnddor,
                                     tercero.TeOprdorPrtrio,
                                     tercero.TeMnjoPrpio,
                                     tercero.TeNmbreCntcto,
                                     tercero.TeCdgoGrpoTrcro,
                                     tercero.TeAgnciaAdna,
                                     tercero.TeOprdorScndrio,

                                     //Atributos GrupoTercero
                                     grupoTercero.GtCdgo,
                                     grupoTercero.GtDscrpcion
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Tercero para agregar a la lista
                    MdloDtos.Tercero objTercero = new MdloDtos.Tercero(
                                                                    //Atributos Tercero
                                                                    item.TeRowid != null ? item.TeRowid : 0,
                                                                    item.TeCdgoCia != null ? item.TeCdgoCia : String.Empty,
                                                                    item.TeCdgo != null ? item.TeCdgo : String.Empty,
                                                                    item.TeNmbre != null ? item.TeNmbre : String.Empty,
                                                                    item.TeIdntfccion != null ? item.TeIdntfccion : String.Empty,
                                                                    item.TeTpoIdntfccion != null ? item.TeTpoIdntfccion : String.Empty,
                                                                    item.TeDv != null ? item.TeDv : String.Empty,
                                                                    item.TeDrccion != null ? item.TeDrccion : String.Empty,
                                                                    item.TeTlfno != null ? item.TeTlfno : String.Empty,
                                                                    item.TeEmail != null ? item.TeEmail : String.Empty,
                                                                    item.TeActvo,
                                                                    item.TeClnte,
                                                                    item.TePrtclar,
                                                                    item.TeFncnrio,
                                                                    item.TeTrnsprtdra,
                                                                    item.TeAgnteMrtmo,
                                                                    item.TeVnddor,
                                                                    item.TeOprdorPrtrio,
                                                                    item.TeMnjoPrpio,
                                                                    item.TeNmbreCntcto != null ? item.TeNmbreCntcto : String.Empty,
                                                                    item.TeCdgoGrpoTrcro != null ? item.TeCdgoGrpoTrcro : String.Empty,
                                                                    item.TeAgnciaAdna,
                                                                    item.TeOprdorScndrio,

                                                                    //Atributos GrupoTercero
                                                                    item.GtCdgo != null ? item.GtCdgo : String.Empty,
                                                                    item.GtDscrpcion != null ? item.GtDscrpcion : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoTercero.Add(objTercero);
                }
                _dbContex.Dispose();
                return listadoTercero;
            }

        }
        #endregion

        #region Consultar todos los datos de Tercero mediante un parametro Codigo especifico
        public async Task<List<MdloDtos.Tercero>> FiltrarTerceroEspecifico(String Codigo)
        {
            List<MdloDtos.Tercero> listadoTercero = new List<MdloDtos.Tercero>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from tercero in _dbContex.Terceros
                                 join grupoTercero in _dbContex.GrupoTerceros on tercero.TeCdgoGrpoTrcro equals grupoTercero.GtCdgo into grupoTerceroJoin
                                 from grupoTercero in grupoTerceroJoin.DefaultIfEmpty()

                                 where tercero.TeCdgo == Codigo

                                 select new
                                 {
                                     //Atributos Tercero
                                     tercero.TeRowid,
                                     tercero.TeCdgoCia,
                                     tercero.TeCdgo,
                                     tercero.TeNmbre,
                                     tercero.TeIdntfccion,
                                     tercero.TeTpoIdntfccion,
                                     tercero.TeDv,
                                     tercero.TeDrccion,
                                     tercero.TeTlfno,
                                     tercero.TeEmail,
                                     tercero.TeActvo,
                                     tercero.TeClnte,
                                     tercero.TePrtclar,
                                     tercero.TeFncnrio,
                                     tercero.TeTrnsprtdra,
                                     tercero.TeAgnteMrtmo,
                                     tercero.TeVnddor,
                                     tercero.TeOprdorPrtrio,
                                     tercero.TeMnjoPrpio,
                                     tercero.TeNmbreCntcto,
                                     tercero.TeCdgoGrpoTrcro,
                                     tercero.TeAgnciaAdna,
                                     tercero.TeOprdorScndrio,

                                     //Atributos GrupoTercero
                                     grupoTercero.GtCdgo,
                                     grupoTercero.GtDscrpcion
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Tercero para agregar a la lista
                    MdloDtos.Tercero objTercero = new MdloDtos.Tercero(
                                                                    //Atributos Tercero
                                                                    item.TeRowid != null ? item.TeRowid : 0,
                                                                    item.TeCdgoCia != null ? item.TeCdgoCia : String.Empty,
                                                                    item.TeCdgo != null ? item.TeCdgo : String.Empty,
                                                                    item.TeNmbre != null ? item.TeNmbre : String.Empty,
                                                                    item.TeIdntfccion != null ? item.TeIdntfccion : String.Empty,
                                                                    item.TeTpoIdntfccion != null ? item.TeTpoIdntfccion : String.Empty,
                                                                    item.TeDv != null ? item.TeDv : String.Empty,
                                                                    item.TeDrccion != null ? item.TeDrccion : String.Empty,
                                                                    item.TeTlfno != null ? item.TeTlfno : String.Empty,
                                                                    item.TeEmail != null ? item.TeEmail : String.Empty,
                                                                    item.TeActvo,
                                                                    item.TeClnte,
                                                                    item.TePrtclar,
                                                                    item.TeFncnrio,
                                                                    item.TeTrnsprtdra,
                                                                    item.TeAgnteMrtmo,
                                                                    item.TeVnddor,
                                                                    item.TeOprdorPrtrio,
                                                                    item.TeMnjoPrpio,
                                                                    item.TeNmbreCntcto != null ? item.TeNmbreCntcto : String.Empty,
                                                                    item.TeCdgoGrpoTrcro != null ? item.TeCdgoGrpoTrcro : String.Empty,
                                                                    item.TeAgnciaAdna,
                                                                    item.TeOprdorScndrio,
                                                                    //Atributos GrupoTercero
                                                                    item.GtCdgo != null ? item.GtCdgo : String.Empty,
                                                                    item.GtDscrpcion != null ? item.GtDscrpcion : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoTercero.Add(objTercero);
                }
                _dbContex.Dispose();
                return listadoTercero;
            }

        }
        #endregion

        #region Consultar todos los datos de Tercero mediante un parametro Codigo que referencia al tipo de tercero
        public async Task<List<MdloDtos.Tercero>> FiltrarTerceroPorTipo(int tipoTercero)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                switch (tipoTercero)
                {
                    case 1: //Es Cliente
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeClnte == true
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 2: //Es particular
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TePrtclar == true
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 3: //Es funcionario
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeFncnrio == true
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 4: //Es transportadora
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeTrnsprtdra == true
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 5: //Es agente marimito
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeAgnteMrtmo == true
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 6: //Es vendedor
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeVnddor == true
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 7: //Es Operador Portuario  Todos
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeOprdorPrtrio == true 
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 8: //Es Operador Portuario manejo propio
                    {
                        var lst = await (from p in _dbContex.Terceros
                                            where p.TeOprdorPrtrio == true  && p.TeMnjoPrpio == true 
                                            select p).ToListAsync();
                        _dbContex.Dispose();
                        return lst;
                    }
                    case 9: //Es Agencia de Aduanas
                        {
                            var lst = await (from p in _dbContex.Terceros
                                             where p.TeAgnciaAdna == true
                                             select p).ToListAsync();
                            _dbContex.Dispose();
                            return lst;
                        }
                    case 10: //Es Operador Secundario
                        {
                            var lst = await (from p in _dbContex.Terceros
                                             where p.TeOprdorScndrio == true
                                             select p).ToListAsync();
                            _dbContex.Dispose();
                            return lst;
                        }
                    default: 
                    {
                        _dbContex.Dispose();
                        return new List<MdloDtos.Tercero>();
                    }

                }
            }

        }
        #endregion


        #region valida si existe un Tercero validando nombre y Compañia mediante un Objeto Tercero

        public bool ValidacionTerceroNombreIngresar(MdloDtos.Tercero _Tercero)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Terceros
                           where    e.TeNmbre == _Tercero.TeNmbre &&
                                    e.TeCdgoCia == _Tercero.TeCdgoCia
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

        #region valida si existe un Tercero validando RowId, nombre y Compañia pasando como parámetro un Objeto Tercero

        public bool ValidacionTerceroNombreActualizar(MdloDtos.Tercero _Tercero)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Terceros
                           where    e.TeRowid != _Tercero.TeRowid &&  
                                    e.TeNmbre == _Tercero.TeNmbre &&
                                    e.TeCdgoCia == _Tercero.TeCdgoCia
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


        #region Actualizar Tercero pasando el objeto _Tercero
        public async Task<MdloDtos.Tercero> EditarTercero(MdloDtos.Tercero _Tercero)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Tercero TerceroExiste = await _dbContex.Terceros.FindAsync(_Tercero.TeRowid);
                    if (TerceroExiste != null)
                    {

                        TerceroExiste.TeCdgo = _Tercero.TeCdgo;
                        TerceroExiste.TeNmbre = _Tercero.TeNmbre;
                        TerceroExiste.TeIdntfccion = _Tercero.TeIdntfccion;
                        TerceroExiste.TeTpoIdntfccion = _Tercero.TeTpoIdntfccion;
                        TerceroExiste.TeDv = _Tercero.TeDv;
                        TerceroExiste.TeDrccion = _Tercero.TeDrccion;
                        TerceroExiste.TeTlfno = _Tercero.TeTlfno;
                        TerceroExiste.TeEmail = _Tercero.TeEmail;
                        TerceroExiste.TeActvo = _Tercero.TeActvo;
                        TerceroExiste.TeClnte = _Tercero.TeClnte;
                        TerceroExiste.TePrtclar = _Tercero.TePrtclar;
                        TerceroExiste.TeFncnrio = _Tercero.TeFncnrio;
                        TerceroExiste.TeTrnsprtdra = _Tercero.TeTrnsprtdra;
                        TerceroExiste.TeAgnteMrtmo = _Tercero.TeAgnteMrtmo;
                        TerceroExiste.TeVnddor = _Tercero.TeVnddor;
                        TerceroExiste.TeOprdorPrtrio = _Tercero.TeOprdorPrtrio;
                        TerceroExiste.TeMnjoPrpio = _Tercero.TeMnjoPrpio;
                        TerceroExiste.TeNmbreCntcto = _Tercero.TeNmbreCntcto;
                        TerceroExiste.TeCdgoGrpoTrcro = _Tercero.TeCdgoGrpoTrcro;
                        TerceroExiste.TeAgnciaAdna = _Tercero.TeAgnciaAdna;
                        TerceroExiste.TeOprdorScndrio = _Tercero.TeOprdorScndrio;

                        _dbContex.Entry(TerceroExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return TerceroExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region Consultar todos los datos de Tercero
        public async Task<List<MdloDtos.Tercero>> ListarTercero()
        {
            List<MdloDtos.Tercero> listadoTercero = new List<MdloDtos.Tercero>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from tercero in _dbContex.Terceros
                                 join grupoTercero in _dbContex.GrupoTerceros on tercero.TeCdgoGrpoTrcro equals grupoTercero.GtCdgo into grupoTerceroJoin
                                 from grupoTercero in grupoTerceroJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Tercero
                                     tercero.TeRowid,
                                     tercero.TeCdgoCia,
                                     tercero.TeCdgo,
                                     tercero.TeNmbre,
                                     tercero.TeIdntfccion,
                                     tercero.TeTpoIdntfccion,
                                     tercero.TeDv,
                                     tercero.TeDrccion,
                                     tercero.TeTlfno,
                                     tercero.TeEmail,
                                     tercero.TeActvo,
                                     tercero.TeClnte,
                                     tercero.TePrtclar,
                                     tercero.TeFncnrio,
                                     tercero.TeTrnsprtdra,
                                     tercero.TeAgnteMrtmo,
                                     tercero.TeVnddor,
                                     tercero.TeOprdorPrtrio,
                                     tercero.TeMnjoPrpio,
                                     tercero.TeNmbreCntcto,
                                     tercero.TeCdgoGrpoTrcro,
                                     tercero.TeAgnciaAdna,
                                     tercero.TeOprdorScndrio,

                                     //Atributos GrupoTercero
                                     grupoTercero.GtCdgo,
                                     grupoTercero.GtDscrpcion
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Tercero para agregar a la lista
                    MdloDtos.Tercero objTercero = new MdloDtos.Tercero(
                                                                    //Atributos Tercero
                                                                    item.TeRowid != null ? item.TeRowid : 0,
                                                                    item.TeCdgoCia != null ? item.TeCdgoCia : String.Empty,
                                                                    item.TeCdgo != null ? item.TeCdgo : String.Empty,
                                                                    item.TeNmbre != null ? item.TeNmbre : String.Empty,
                                                                    item.TeIdntfccion != null ? item.TeIdntfccion : String.Empty,
                                                                    item.TeTpoIdntfccion != null ? item.TeTpoIdntfccion : String.Empty,
                                                                    item.TeDv != null ? item.TeDv : String.Empty,
                                                                    item.TeDrccion != null ? item.TeDrccion : String.Empty,
                                                                    item.TeTlfno != null ? item.TeTlfno : String.Empty,
                                                                    item.TeEmail != null ? item.TeEmail : String.Empty,
                                                                    item.TeActvo,
                                                                    item.TeClnte,
                                                                    item.TePrtclar,
                                                                    item.TeFncnrio,
                                                                    item.TeTrnsprtdra,
                                                                    item.TeAgnteMrtmo,
                                                                    item.TeVnddor,
                                                                    item.TeOprdorPrtrio,
                                                                    item.TeMnjoPrpio,
                                                                    item.TeNmbreCntcto != null ? item.TeNmbreCntcto : String.Empty,
                                                                    item.TeCdgoGrpoTrcro != null ? item.TeCdgoGrpoTrcro : String.Empty,
                                                                    item.TeAgnciaAdna,
                                                                    item.TeOprdorScndrio,

                                                                    //Atributos GrupoTercero
                                                                    item.GtCdgo != null ? item.GtCdgo : String.Empty,
                                                                    item.GtDscrpcion != null ? item.GtDscrpcion : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoTercero.Add(objTercero);
                }
                _dbContex.Dispose();
                return listadoTercero;
            }
        }

        #endregion

        #region Eliminar Tercero
        public async Task<MdloDtos.Tercero> EliminarTercero(int Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TercerosExiste = await _dbContex.Terceros.FindAsync(Codigo);
                    if (TercerosExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {

                        _dbContex.Remove(TercerosExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return TercerosExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

        }

        #endregion

        #region verificar Terceros
        public async Task<bool> VerificarTercero(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Terceros
                               where p.TeCdgo == Codigo
                               select p).Count();

                    var ObjTercero = lst;
                    if (ObjTercero == null || ObjTercero == 0)
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

        #region verificar Terceros por Id
        public async Task<bool> VerificarTerceroPorId(int? Id)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Terceros
                               where p.TeRowid == Id
                               select p).Count();

                    var ObjTercero = lst;
                    if (ObjTercero == null || ObjTercero == 0)
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

        #region verificar que el Terceros sea agencia de aduanas por Id
        public async Task<bool> VerificarTerceroEsAgenciaAduanaPorId(int? Id)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Terceros
                               where p.TeRowid == Id && p.TeAgnciaAdna == true
                               select p).Count();

                    var ObjTercero = lst;
                    if (ObjTercero == null || ObjTercero == 0)
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


        #region verificar Terceros por medio de su Id
        public async Task<bool> VerificarTerceroPorId(int IdTercero)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Terceros
                               where p.TeRowid == IdTercero
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
