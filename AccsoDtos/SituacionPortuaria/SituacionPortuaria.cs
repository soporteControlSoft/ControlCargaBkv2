using MdloDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AccsoDtos.SituacionPortuaria
{
    /// <summary>
    /// CRUD para el manejo del Situacion Portuaria
    /// Wilbert Rivas Granados
    /// </summary>
    public class SituacionPortuaria : MdloDtos.IModelos.ISituacionPortuaria
    {
        #region Ingresar datos a la entidad Situacion Portuaria
        public async Task<MdloDtos.SituacionPortuarium> IngresarSituacionPortuaria(MdloDtos.SituacionPortuarium _SituacionPortuarium)
        {
            var ObjSituacionPortuarium = new MdloDtos.SituacionPortuarium();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var SituacionPortuariumExiste = await this.VerificarSituacionPortuaria(_SituacionPortuarium.SpRowid);

                    if (SituacionPortuariumExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        DateTime hoy = DateTime.Now;
                        ObjSituacionPortuarium.SpCdgoMtnve = _SituacionPortuarium.SpCdgoMtnve;
                        ObjSituacionPortuarium.SpRowidZnaCd = _SituacionPortuarium.SpRowidZnaCd;
                        ObjSituacionPortuarium.SpCdgoTrmnalMrtmo = _SituacionPortuarium.SpCdgoTrmnalMrtmo;
                        ObjSituacionPortuarium.SpFchaArrbo = _SituacionPortuarium.SpFchaArrbo;
                        ObjSituacionPortuarium.SpFchaAtrque = _SituacionPortuarium.SpFchaAtrque;
                        ObjSituacionPortuarium.SpFchaZrpe = _SituacionPortuarium.SpFchaZrpe;
                        ObjSituacionPortuarium.SpFchaCrcion = hoy;
                        ObjSituacionPortuarium.SpCdgoEstdoMtnve = _SituacionPortuarium.SpCdgoEstdoMtnve;
                        ObjSituacionPortuarium.SpCdgoPais = _SituacionPortuarium.SpCdgoPais;
                        ObjSituacionPortuarium.SpRowidAgnteNvro = _SituacionPortuarium.SpRowidAgnteNvro;
                        ObjSituacionPortuarium.SpCdgoUsrioCrea = _SituacionPortuarium.SpCdgoUsrioCrea;

                        var res = await _dbContex.SituacionPortuaria.AddAsync(ObjSituacionPortuarium);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjSituacionPortuarium;
            }
        }
        #endregion

        #region verificar Situacion Portuaria
        public async Task<bool> VerificarSituacionPortuaria(int? RowId)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjSituacionPortuaria = await _dbContex.SituacionPortuaria.FindAsync(RowId);
                    respuesta = ObjSituacionPortuaria == null ? false : true;
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


        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general por zona (IdZona)
        public async Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorZona(int IdZona)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria 
                                            where VwStcionPrtriaLstar.ZcdRowid == IdZona
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar ).ToListAsync();
                lista= IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }

        }
        #endregion


       

        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general que busque por codigo de Terminal,(CodigoTerminalMaritimo)
        public async Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorTerminal(string CodigoTerminalMaritimo)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                          where VwStcionPrtriaLstar.SpCdgoTrmnalMrtmo == CodigoTerminalMaritimo
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }
        }
        #endregion

        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general que busque por codigo de Motonave,(CodigoMotonave)
        public async Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorMotonave(string CodigoMotonave)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                          where VwStcionPrtriaLstar.SpCdgoMtnve == CodigoMotonave
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }
        }
        #endregion

        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general que busque por codigo Estado Motonave,(CodigoEstadoMotonave)
        public async Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorEstadoMotonave(string CodigoEstadoMotonave)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                          where VwStcionPrtriaLstar.SpCdgoEstdoMtnve == CodigoEstadoMotonave
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar).ToListAsync();
                lista = IterarObjeto(lstSituacion);

                _dbContex.Dispose();
                return lista;
            }

        }
        #endregion

        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general que busque por codigo Pais,(CodigoPais)
        public async Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorPais(string CodigoPais)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                          where VwStcionPrtriaLstar.SpCdgoPais == CodigoPais
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }

        }
        #endregion

        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general que busque por id Situacion Portuaria,(IdSituacion)
        public async Task<List<MdloDtos.SituacionPortuarium>> FiltrarSituacionPortuariaPorIdSituacion(int IdSituacion)
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                          where VwStcionPrtriaLstar.SpRowid == IdSituacion
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }

        }
        #endregion

        #region Consultar todos los datos de Situacion Portuaria mediante un parametro Codigo general 
        public async Task<List<MdloDtos.SituacionPortuarium>> ConsultarSituacionPortuaria()
        {

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.SituacionPortuarium> lista = new List<SituacionPortuarium>();
                var lstSituacion = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                          orderby VwStcionPrtriaLstar.SpRowid descending
                                          select VwStcionPrtriaLstar).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }

        }
        #endregion

        #region Actualizar Situacion Portuaria pasando el objeto _SituacionPortuaria
        public async Task<MdloDtos.SituacionPortuarium> EditarSituacionPortuaria(MdloDtos.SituacionPortuarium _SituacionPortuarium)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.SituacionPortuarium SituacionPortuariumExiste = await _dbContex.SituacionPortuaria.FindAsync(_SituacionPortuarium.SpRowid);
                    if (SituacionPortuariumExiste != null)
                    {
                        SituacionPortuariumExiste.SpCdgoMtnve = _SituacionPortuarium.SpCdgoMtnve;
                        SituacionPortuariumExiste.SpRowidZnaCd = _SituacionPortuarium.SpRowidZnaCd;
                        SituacionPortuariumExiste.SpCdgoTrmnalMrtmo = _SituacionPortuarium.SpCdgoTrmnalMrtmo;
                        SituacionPortuariumExiste.SpFchaArrbo = _SituacionPortuarium.SpFchaArrbo;
                        SituacionPortuariumExiste.SpFchaAtrque = _SituacionPortuarium.SpFchaAtrque;
                        SituacionPortuariumExiste.SpFchaZrpe = _SituacionPortuarium.SpFchaZrpe;
                        SituacionPortuariumExiste.SpFchaCrcion = SituacionPortuariumExiste.SpFchaCrcion;
                        SituacionPortuariumExiste.SpCdgoEstdoMtnve = _SituacionPortuarium.SpCdgoEstdoMtnve;
                        SituacionPortuariumExiste.SpCdgoPais = _SituacionPortuarium.SpCdgoPais;
                        SituacionPortuariumExiste.SpRowidAgnteNvro = _SituacionPortuarium.SpRowidAgnteNvro;
                        SituacionPortuariumExiste.SpCdgoUsrioCrea = _SituacionPortuarium.SpCdgoUsrioCrea;

                        _dbContex.Entry(SituacionPortuariumExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return SituacionPortuariumExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Eliminar Situacion Portuaria
        public async Task<MdloDtos.SituacionPortuarium> EliminarSituacionPortuaria(int RowId)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var SituacionPortuariumExiste = await _dbContex.SituacionPortuaria.FindAsync(RowId);
                    if (SituacionPortuariumExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(SituacionPortuariumExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return SituacionPortuariumExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }
        }

        #endregion

        #region Itera todos los objetos de tipo VwModuloSituacionPortuariaListarSituacionPortuarium para retornar una lista de MdloDtos.SituacionPortuarium
        public List<MdloDtos.SituacionPortuarium> IterarObjeto(List<MdloDtos.VwModuloSituacionPortuariaListarSituacionPortuarium> listaInput)
        {
            List<MdloDtos.SituacionPortuarium> listaItem = new List<SituacionPortuarium>();
            foreach (var item in listaInput)
            {
                listaItem.Add(
                    new MdloDtos.SituacionPortuarium
                    {
                        SpRowid = (int)item.SpRowid,
                        SpCdgoMtnve = item.MoCdgo,
                        SpRowidZnaCd = !string.IsNullOrWhiteSpace(item.SpRowidZnaCd.ToString()) ? item.SpRowidZnaCd : 0,
                        SpCdgoTrmnalMrtmo = item.TmCdgo,
                        SpFchaArrbo = item.SpFchaArrbo,
                        SpFchaAtrque = item.SpFchaAtrque,
                        SpFchaZrpe = item.SpFchaZrpe,
                        SpFchaCrcion = item.SpFchaCrcion,
                        SpCdgoEstdoMtnve = item.EmCdgo,
                        SpCdgoPais = item.PaCdgo,
                        SpRowidAgnteNvro = item.SpRowidAgnteNvro,
                        SpCdgoUsrioCrea = item.SpCdgoUsrioCrea,
                        SpCdgoEstdoMtnveNavigation = new MdloDtos.EstadoMotonave
                        {
                            EmCdgo = item.EmCdgo,
                            EmNmbre = item.EmNmbre
                        },
                        SpCdgoPaisNavigation = new MdloDtos.Pai
                        {
                            PaCdgo = item.PaCdgo,
                            PaNmbre = item.PaNmbre
                        },
                        SpCdgoTrmnalMrtmoNavigation = new MdloDtos.TerminalMaritimo
                        {
                            TmCdgo = item.TmCdgo,
                            TmDscrpcion = item.TmDscrpcion
                        },
                        SpCdgoUsrioCreaNavigation = new MdloDtos.Usuario
                        {
                            UsCdgo = item.UsCdgo,
                            UsNmbre = item.UsNmbre,
                            UsIdntfccion = item.UsIdntfccion
                        },
                        SpRowidAgnteNvroNavigation = new MdloDtos.Tercero
                        {
                            TeRowid = item.TeRowid,
                            TeCdgoCia = item.TeCdgoCia,
                            TeCdgo = item.TeCdgo,
                            TeNmbre = item.TeNmbre,
                            TeAgnteMrtmo = item.TeAgnteMrtmo
                        },
                        SpRowidZnaCdNavigation = new MdloDtos.ZonaCd
                        {
                            ZcdRowid = item.ZcdRowid,
                            ZcdCdgo = item.ZcdCdgo,
                            ZcdNmbre = item.ZcdNmbre,
                        },
                        NombreZona = item.ZcdNmbre != null ? item.ZcdNmbre : " ",
                        DescripcionMotonave = item.MoNmbre.ToString(),
                        NombreTerminal = item.TmDscrpcion != null ? item.TmDscrpcion : " ",
                        NombreEstado = item.EmNmbre.ToString(),
                        NombrePais = item.PaNmbre.ToString(),
                        NombreAgente = item.TeNmbre != null ? item.TeNmbre : " ",
                        //implementacionBotonCrearVisita
                        CrearVisitaMotonave = item.CrearVisitaMotonave == 1 ? true : false,
                        CodigoVisitaMotonave = item.CodigoVisitaMotonave != null ? item.CodigoVisitaMotonave : 0
                    }
                );
            }
            return listaItem;
        }
        #endregion

    }
}
