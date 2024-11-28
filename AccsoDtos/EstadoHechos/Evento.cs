using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.EstadoHechos
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Evento
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class Evento:MdloDtos.IModelos.IEventos
    {
        #region Ingresar datos a la entidad Evento
        public async Task<MdloDtos.Evento> IngresarEvento(MdloDtos.Evento _Evento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var ObjEvento = new MdloDtos.Evento();
                try
                {
                    var EvntoExiste = await this.VerificarEvento(_Evento.EvRowid);

                    if (EvntoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        DateTime fechaSistema = DateTime.Now;

                        ObjEvento.EvNmbre = _Evento.EvNmbre;
                        ObjEvento.EvObsrvcion = _Evento.EvObsrvcion;
                        ObjEvento.EvFchaCrcion = fechaSistema;
                        ObjEvento.EvFchaIncio = _Evento.EvFchaIncio;
                        ObjEvento.EvFchaFin = _Evento.EvFchaFin;
                        ObjEvento.EvEsctlla = _Evento.EvEsctlla;
                        ObjEvento.EvRowidClsfccion = _Evento.EvRowidClsfccion;
                        ObjEvento.EvRowidRspnsble = _Evento.EvRowidRspnsble;
                        ObjEvento.EvEqpo = _Evento.EvEqpo;
                        ObjEvento.EvCdgoUsrio = _Evento.EvCdgoUsrio;
                        ObjEvento.EvActvo = true;

                        var res = await _dbContex.Eventos.AddAsync(ObjEvento);


                        await _dbContex.SaveChangesAsync();
                    }

                    
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjEvento;
            }

        }
        #endregion

        //#region Consultar todos los datos de Ciudad mediante un parametro Codigo de Departamento
        //public async Task<List<MdloDtos.Ciudad>> FiltrarCiudadPorDepartamento(int Codigo)
        //{
        //    List<MdloDtos.Ciudad> listCiudad = new List<MdloDtos.Ciudad>();
        //    using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        //    {

        //        var lst = await (from ciudad in _dbContex.Ciudads
        //                         join departamento in _dbContex.Departamentos on ciudad.CiRowidDprtmnto equals departamento.DeRowid into departamentoJoin
        //                         from departamento in departamentoJoin.DefaultIfEmpty()


        //                         where ciudad.CiRowidDprtmnto == Codigo

        //                         select new
        //                         {
        //                             //Atributos Ciudad
        //                             ciudadRowId = ciudad.CiRowid,
        //                             ciudadCodigo = ciudad.CiCdgo,
        //                             ciudadNombre = ciudad.CiNmbre,
        //                             ciudadDepartamentoRowId = ciudad.CiRowidDprtmnto,

        //                             //Atributos departamentos
        //                             DepartamentoRowId = departamento.DeRowid,
        //                             DepartamentoCodigo = departamento.DeCdgo,
        //                             DepartamentoNombre = departamento.DeNmbre
        //                         }
        //                       ).ToListAsync();
        //        _dbContex.Dispose();
        //        foreach (var item in lst)
        //        {
        //            //Creamos una entidad Ciudad para agregar a la lista
        //            MdloDtos.Ciudad objCiudad = new MdloDtos.Ciudad(
        //                                                            //Atributos ciudad
        //                                                            item.ciudadRowId != null ? item.ciudadRowId : 0,
        //                                                            item.ciudadCodigo != null ? item.ciudadCodigo : String.Empty,
        //                                                            item.ciudadNombre != null ? item.ciudadNombre : String.Empty,
        //                                                            item.ciudadDepartamentoRowId != null ? item.ciudadDepartamentoRowId : 0,

        //                                                            //Atributos departamento
        //                                                            item.DepartamentoRowId != null ? item.DepartamentoRowId.ToString() : String.Empty,
        //                                                            item.DepartamentoCodigo != null ? item.DepartamentoCodigo : String.Empty,
        //                                                            item.DepartamentoNombre != null ? item.DepartamentoNombre : String.Empty
        //                                                            );

        //            //Agregamnos la ciudad a la lista
        //            listCiudad.Add(objCiudad);
        //        }


        //        _dbContex.Dispose();
        //        return listCiudad;
        //    }

        //}
        //#endregion

        #region Listar todos las Evento
        public async Task<List<MdloDtos.Evento>> ListarEvento(bool estado = true)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = from eventos in _dbContex.Eventos
                            where eventos.EvActvo == estado
                            select eventos;
                var listEventos = await query.ToListAsync();

                return listEventos;
            }
        }
        #endregion

        #region Actualizar Eventos por el objeto Evento
        public async Task<MdloDtos.Evento> EditarEvento(MdloDtos.Evento _Evento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Evento EventoExiste = await _dbContex.Eventos.FindAsync(_Evento.EvRowid);
                    if (EventoExiste != null)
                    {

                        EventoExiste.EvNmbre = _Evento.EvNmbre;
                        EventoExiste.EvObsrvcion = _Evento.EvObsrvcion;
                        EventoExiste.EvFchaIncio = _Evento.EvFchaIncio;
                        EventoExiste.EvFchaFin = _Evento.EvFchaFin;
                        EventoExiste.EvEsctlla = _Evento.EvEsctlla;
                        EventoExiste.EvRowidClsfccion = _Evento.EvRowidClsfccion;
                        EventoExiste.EvRowidRspnsble = _Evento.EvRowidRspnsble;
                        EventoExiste.EvEqpo = _Evento.EvEqpo;
                        EventoExiste.EvCdgoUsrio = _Evento.EvCdgoUsrio;
                        EventoExiste.EvActvo = _Evento.EvActvo;

                        _dbContex.Entry(EventoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return EventoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
               
            }
            
        }
        #endregion

        #region Filtrar eventos por codigo general
        public async Task<List<MdloDtos.Evento>> FiltrarEventoGeneral(string Codigo, bool estado)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código (RowID o nombre) y estado
                var lst = await (from ev in _dbContex.Eventos
                                 where (ev.EvRowid.ToString().Contains(Codigo) || ev.EvNmbre.Contains(Codigo))
                                       && ev.EvActvo == estado // Validar el estado
                                 select ev).ToListAsync();

                return lst;
            }
        }
        #endregion

        #region Filtrar evento por codigo Especifico clasificacion
        public async Task<List<MdloDtos.Evento>> FiltrarEventoEspecifico(string Codigo, bool estado)
        {
            // Convertir el código a entero
            int codigoConvert = int.Parse(Codigo);

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Filtrar por código específico y estado
                var lst = await (from ev in _dbContex.Eventos
                                 where ev.EvRowid == codigoConvert && ev.EvActvo == estado
                                 select ev).ToListAsync();

                return lst;
            }
        }
        #endregion

        #region Inactivar Evento Por codigo.
        public async Task<MdloDtos.Evento> InactivarEvento(MdloDtos.Evento _Evento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Evento EventoExiste = await _dbContex.Eventos.FindAsync(_Evento.EvRowid);
                    if (EventoExiste != null)
                    {
                        EventoExiste.EvActvo = _Evento.EvActvo;

                        _dbContex.Entry(EventoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return EventoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }

            }
        }
        #endregion

        #region verificar Ciudad por RowId.
        public async Task<bool> VerificarEvento(int Codigo)
        {
            bool respuesta = false;
            if(Codigo != null)
            {
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    try
                    {
                        var lst = (from e in _dbContex.Eventos
                                   where e.EvRowid == Codigo
                                   select e).Count();

                        var ObjClasificacion = lst;
                        if (ObjClasificacion == null || ObjClasificacion == 0)
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
