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

namespace AccsoDtos.Reserva
{
    /// <summary>
    /// Clase para el acceso a datos de las reservas
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Reserva: MdloDtos.IModelos.IReserva
    {
        private readonly IMapper _mapper;

        public Reserva(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Consultar todas las visita de motonave para una compañia en particular
        public async Task<List<MdloDtos.DTO.VwMdloRsrvaLstarVstaMtnveDTO>> ConsultarVisitaMotonave(String codigoCompania)
        {
            List<MdloDtos.VwMdloRsrvaLstarVstaMtnve> list= new List<MdloDtos.VwMdloRsrvaLstarVstaMtnve>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from vstaMtnve in _dbContex.VwMdloRsrvaLstarVstaMtnves
                                 where vstaMtnve.VmCdgoCia == codigoCompania
                                 select vstaMtnve
                               ).ToListAsync();
                _dbContex.Dispose();
                var result = (lst.Count > 0) ? _mapper.Map<List<VwMdloRsrvaLstarVstaMtnveDTO>>(lst) : new List<VwMdloRsrvaLstarVstaMtnveDTO>();
                return result;
            }
        }
        #endregion

        #region Consultar todos los depositos de una visita de motonave en particular
        public async Task<List<MdloDtos.DTO.VwMdloRsrvaLstarDpstoDTO>> ConsultarDeposito(int idVisitaMotonave)
        {
            List<MdloDtos.VwMdloRsrvaLstarDpsto> list = new List<MdloDtos.VwMdloRsrvaLstarDpsto>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from listDpsto in _dbContex.VwMdloRsrvaLstarDpstos
                                 where listDpsto.VmRowid == idVisitaMotonave
                                 select listDpsto
                               ).ToListAsync();
                _dbContex.Dispose();

                var result = (lst.Count > 0) ? _mapper.Map<List<VwMdloRsrvaLstarDpstoDTO>>(lst) : new List<VwMdloRsrvaLstarDpstoDTO>();
                return result;
            }
        }
        #endregion

        #region Consultar todas las solicitudes de retiro para un deposito y una transportadora en particular
        public async Task<List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>> ConsultarSolicitudRetiroModal(int idDeposito, int idTransportadora)
        {
            List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal> list = new List<MdloDtos.VwMdloRsrvaLstarSlctudRtroMdal>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from slctudRtro in _dbContex.VwMdloRsrvaLstarSlctudRtroMdals
                                 where slctudRtro.SrtRowidTrnsprtdra == idTransportadora && slctudRtro.DeRowid== idDeposito
                                 select slctudRtro
                               ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region Consultar el detalle de una solicitud de retiro para una solicitud de retiro en particular y una transportadora particular
        public async Task<List<MdloDtos.DTO.SpMdloRsrvaDtlleSlctudRtroDTO>> ListarDetalleSolicitudRetiro(int IdSolicitudRetiro, int idTransportadora)
        {
            List<MdloDtos.SpMdloRsrvaDtlleSlctudRtro> list = new List<MdloDtos.SpMdloRsrvaDtlleSlctudRtro>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                list = await _dbContex.ListarDetalleSolicitudRetiro(IdSolicitudRetiro, idTransportadora);          
                _dbContex.Dispose();

                var result = (list.Count > 0) ? _mapper.Map<List<SpMdloRsrvaDtlleSlctudRtroDTO>>(list) : new List<SpMdloRsrvaDtlleSlctudRtroDTO>();
                return result;
            }
        }
        #endregion

        #region Consultar el detalle de una orden o reserva para una orden en particular a partir de su codigo.
        public async Task<List<MdloDtos.DTO.SpMdloRsrvaDtlleOrdenDTO>> ListarDetalleOrden(int cdgoOrden)
        {
            List<MdloDtos.SpMdloRsrvaDtlleOrden> list = new List<MdloDtos.SpMdloRsrvaDtlleOrden>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                list = await _dbContex.ListarDetalleOrden(cdgoOrden);
                _dbContex.Dispose();

                var result = (list.Count > 0) ? _mapper.Map<List<SpMdloRsrvaDtlleOrdenDTO>>(list) : new List<SpMdloRsrvaDtlleOrdenDTO>();
                return result;
            }
        }
        #endregion

        #region verificar la existencia de una solicitd de retiro por su rowId
        public async Task<bool> VerificarSolicitudRetiro(int IdSolicitudRetiro)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjSolicitudRetiro = await _dbContex.SolicitudRetiros.FindAsync(IdSolicitudRetiro);
                    respuesta = ObjSolicitudRetiro != null ? true : false;
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

        #region verificar la existencia de una orden por su rowId
        public async Task<bool> VerificarOrden(int CodigoOrden)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjOrden = await _dbContex.Ordens.FindAsync(CodigoOrden);
                    respuesta = ObjOrden != null ? true : false;
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

        #region Ingresar datos a la entidad Orden
        public async Task<dynamic> RegistrarOrden(MdloDtos.DTO.OrdenDTO _Orden)
        {
            string retorno = "";
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                retorno = await _dbContex.RegistrarOrden(_Orden);
                _dbContex.Dispose();
                return retorno;
            }
        }
        #endregion

        #region verificar una orden en especifico
        public async Task<int> ConsultarOrdenEspecifica(int IdTransportadora, DateTime FechaReserva, DateTime FechaRegistroReserva, String Placa, String Manifiesto)
        {
            int cdgoOrden = -1;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var listOrden = await (from orden in _dbContex.Ordens 
                                            where   orden.OrRowidTrnsprtdra == IdTransportadora && orden.OrFchaRsrva== FechaReserva &&
                                                    orden.OrFchaRgstroRsrva == FechaRegistroReserva && orden.OrPlca == Placa &&
                                                    orden.OrMnfsto == Manifiesto
                                            select new
                                            {
                                                orden.OrCdgo
                                            }).ToListAsync();
                    cdgoOrden = (listOrden.Count > 0) ? cdgoOrden = listOrden[0].OrCdgo : cdgoOrden;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                _dbContex.Dispose();
                return cdgoOrden;
            }
        }
        #endregion


        #region Ingresa una observacion a la orden
        public async Task<List<MdloDtos.Mensaje>> IngresarObservacion(int CodigoOrden, string CodigoUsuario, string Observaciones)
        {
            List<MdloDtos.Mensaje> listaObservaciones = null;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var OrdenExiste = await _dbContex.Ordens.FindAsync(CodigoOrden);
                    if (OrdenExiste != null)
                    {
                        DateTime Hoy = DateTime.Now;
                        Observaciones = Observaciones.Replace("]#&&#[", "").Replace("]#&&[", "").Replace("#&&#", "");//codigo para evitar que se registre un separador dentro del comentario.

                        OrdenExiste.OrObsrvcnes = (OrdenExiste.OrObsrvcnes != null) ?
                                    OrdenExiste.OrObsrvcnes + "#&&#[" + Hoy.ToString() + "]#&&[" + CodigoUsuario + "]#&&[" + Observaciones + "]" :
                                    "[" + Hoy.ToString() + "]#&&[" + CodigoUsuario + "]#&&[" + Observaciones + "]";

                        _dbContex.Ordens.Update(OrdenExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                        if (OrdenExiste.OrObsrvcnes != null)
                        {
                            listaObservaciones = new List<Mensaje>();
                            foreach (var items in OrdenExiste.OrObsrvcnes.Split("#&&#"))
                            {
                                var item = items.Split("#&&");
                                //Intentamos extraer el nombre del usuario que ingresó la observación con el codigo
                                try
                                {
                                    MdloDtos.Usuario usuario = new MdloDtos.Usuario();
                                    usuario.UsCdgo = item[1].Replace("[", "").Replace("]", "");
                                    usuario.UsNmbre = null;
                                    {
                                        var lstUsuario = await (from usr in _dbContex.Usuarios
                                                                where (usr.UsCdgo == item[1].Replace("[", "").Replace("]", ""))
                                                                select new
                                                                {
                                                                    usr.UsCdgo,
                                                                    usr.UsNmbre
                                                                }).ToListAsync();
                                        foreach (var itemUsr in lstUsuario)
                                        {
                                            usuario = new MdloDtos.Usuario
                                            {
                                                UsCdgo = itemUsr.UsCdgo,
                                                UsNmbre = itemUsr.UsNmbre
                                            };
                                        }
                                    }
                                    listaObservaciones.Add(
                                        new MdloDtos.Mensaje
                                        {
                                            fechaHoraIngreso = Convert.ToDateTime(item[0].Replace("[", "").Replace("]", "")),
                                            usuario = usuario,
                                            comentario = item[2].Replace("[", "").Replace("]", "")
                                        }
                                    );
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return listaObservaciones;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta las observaciones registradas a una orden en particular
        public async Task<List<MdloDtos.Mensaje>> ConsultarObservaciones(int CodigoOrden)
        {
            List<MdloDtos.Mensaje> listaObservaciones = new List<Mensaje>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var OrdenExiste = await _dbContex.Ordens.FindAsync(CodigoOrden);
                    if (OrdenExiste != null)
                    {
                        if (OrdenExiste.OrObsrvcnes != null)
                        {
                            foreach (var items in OrdenExiste.OrObsrvcnes.Split("#&&#"))
                            {
                                var item = items.Split("#&&");

                                //Intentamos extraer el nombre del usuario que ingresó la observaciones
                                try
                                {
                                    MdloDtos.Usuario usuario = new MdloDtos.Usuario();
                                    usuario.UsCdgo = item[1].Replace("[", "").Replace("]", "");
                                    usuario.UsNmbre = null;
                                    {
                                        var lstUsuario = await (from usr in _dbContex.Usuarios
                                                                where (usr.UsCdgo == item[1].Replace("[", "").Replace("]", ""))
                                                                select new
                                                                {
                                                                    usr.UsCdgo,
                                                                    usr.UsNmbre
                                                                }).ToListAsync();
                                        foreach (var itemUsr in lstUsuario)
                                        {
                                            usuario = new MdloDtos.Usuario
                                            {
                                                UsCdgo = itemUsr.UsCdgo,
                                                UsNmbre = itemUsr.UsNmbre
                                            };
                                        }
                                    }
                                    listaObservaciones.Add(
                                        new MdloDtos.Mensaje
                                        {
                                            fechaHoraIngreso = Convert.ToDateTime(item[0].Replace("[", "").Replace("]", "")),
                                            usuario = usuario,
                                            comentario = item[2].Replace("[", "").Replace("]", "")
                                        }
                                    );
                                }
                                catch (Exception e)
                                {

                                }
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return listaObservaciones;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion
    }
}
