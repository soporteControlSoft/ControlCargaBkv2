using AccsoDtos.Parametrizacion;
using AccsoDtos.SituacionPortuaria;
using MdloDtos;
using MdloDtos.IModelos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace AccsoDtos.VisitaMotonave
{
    public class VisitaMotonave : MdloDtos.IModelos.IVisitaMotonave
    {

        Parametrizacion.Motonave objMotonave = new Parametrizacion.Motonave();

        #region Consultar Secuencia de registro
        public async Task<string> ConsultarSecuenciaVisitaMotonave(string CodigoCompania, String CodigoMotonave)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                string SecuenciaGeneral = "";
                var visitas = from p in _dbContex.VisitaMotonaves
                              join j in _dbContex.Motonaves on p.VmCdgoMtnve equals j.MoCdgo
                              where p.VmCdgoMtnve == CodigoMotonave && p.VmCdgoCia == CodigoCompania
                              orderby p.VmRowid descending
                              select new { p.VmScncia, j.MoNmbre };

                int conteo = visitas.Count();
                if (conteo > 0)
                {
                    conteo++;
                }

                var nombreMotonave = visitas.Select(v => v.MoNmbre).Distinct().FirstOrDefault() ?? "";

                if (conteo == 0)
                {
                    var motonaves = from p in _dbContex.Motonaves
                                    where p.MoCdgo == CodigoMotonave
                                    select p.MoNmbre;

                    nombreMotonave = motonaves.Distinct().FirstOrDefault() ?? "";
                    conteo = 1;
                }
                SecuenciaGeneral = $"{nombreMotonave} - {conteo}";

                return SecuenciaGeneral;
            }
        }
        #endregion

        #region Consultar visita Motonave
        public async Task<List<MdloDtos.VisitaMotonave>> ConsultarVisitaMotonave()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.VisitaMotonave> lista = new List<MdloDtos.VisitaMotonave>();
                var listaVisitaMotonaves = (from listaVisitaMotonave in _dbContex.VwModuloVisitaMotonaveListarVisitaMotonaves
                                            orderby listaVisitaMotonave.VmRowid descending
                                            select listaVisitaMotonave).ToList();
                lista = IterarObjeto(listaVisitaMotonaves);

                _dbContex.Dispose();
                return lista;
            }
        }
        #endregion

        #region Ingresar visita Motonave
        public async Task<MdloDtos.VisitaMotonave> IngresarVisitaMotonave(MdloDtos.VisitaMotonave _ObjVisitaMotonave_)
        {
            var ObjVisitaMotonave = new MdloDtos.VisitaMotonave();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveExiste = await this.VerificarVisitaMotonave(_ObjVisitaMotonave_.VmRowid);
                    if (VisitaMotonaveExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        int conteo = 0;
                        conteo = (from p in _dbContex.VisitaMotonaves
                                  where (p.VmCdgoMtnve == _ObjVisitaMotonave_.VmCdgoMtnve && p.VmCdgoCia == _ObjVisitaMotonave_.VmCdgoCia)

                                  select new
                                  {
                                      secuencia = p.VmScncia

                                  }).Count();
                        conteo++;

                        //Consultamos la motonave para la descripción de la visitaMotonave
                        var motonaveExiste = await _dbContex.Motonaves.FindAsync(_ObjVisitaMotonave_.VmCdgoMtnve);

                        DateTime hoy = DateTime.Now;
                        ObjVisitaMotonave.VmCdgoMtnve = _ObjVisitaMotonave_.VmCdgoMtnve;
                        ObjVisitaMotonave.VmCdgoCia = _ObjVisitaMotonave_.VmCdgoCia;
                        ObjVisitaMotonave.VmFchaCrcion = hoy;
                        ObjVisitaMotonave.VmFchaIncioOprcion = _ObjVisitaMotonave_.VmFchaIncioOprcion;
                        ObjVisitaMotonave.VmFchaFinOprcion = _ObjVisitaMotonave_.VmFchaFinOprcion;
                        ObjVisitaMotonave.VmFchaFndeo = _ObjVisitaMotonave_.VmFchaFndeo;
                        ObjVisitaMotonave.VmScncia = Convert.ToInt16(conteo);

                        if (motonaveExiste != null)
                        {
                            ObjVisitaMotonave.VmDscrpcion = motonaveExiste.MoNmbre + " - " + Convert.ToInt16(conteo);
                        }

                        ObjVisitaMotonave.VmRowidVnddor = _ObjVisitaMotonave_.VmRowidVnddor;
                        ObjVisitaMotonave.VmRowidZnaCdAltrno = _ObjVisitaMotonave_.VmRowidZnaCdAltrno;
                        ObjVisitaMotonave.VmRowidStcionPrtria = _ObjVisitaMotonave_.VmRowidStcionPrtria;
                        ObjVisitaMotonave.VmRowidsPrstdresSrvcios = _ObjVisitaMotonave_.VmRowidsPrstdresSrvcios;
                        ObjVisitaMotonave.VmCdgoUsrioCrea = _ObjVisitaMotonave_.VmCdgoUsrioCrea;

                        var res = await _dbContex.VisitaMotonaves.AddAsync(ObjVisitaMotonave);
                        var result = await _dbContex.SaveChangesAsync();

                        if (result <= 0)
                        {
                            throw new Exception("Error al guardar la visita motonave en la base de datos.");
                        }
                        else
                        {
                            // validamos que se hizo el insert para proceder con el registro automático de los detalle de la visita motonave
                            var savedEntry = await _dbContex.VisitaMotonaves
                                                            .FirstOrDefaultAsync(v => v.VmCdgoMtnve == _ObjVisitaMotonave_.VmCdgoMtnve
                                                                                        && v.VmScncia == ObjVisitaMotonave.VmScncia
                                                                                        && v.VmCdgoCia == ObjVisitaMotonave.VmCdgoCia
                                                                                        && v.VmFchaCrcion == ObjVisitaMotonave.VmFchaCrcion);
                            if (savedEntry != null)
                            {
                                //Procedemos a guardar los registro de situacion portuaria detalle en visita motonave detalle
                                AccsoDtos.SituacionPortuaria.SituacionPortuariaDetalle ObjsituacionPortuariaDetalle = new AccsoDtos.SituacionPortuaria.SituacionPortuariaDetalle();

                                List<MdloDtos.SituacionPortuariaDetalle> listSituacionPortuariaDetalle = null;
                                listSituacionPortuariaDetalle = await ObjsituacionPortuariaDetalle.FiltrarSituacionPortuariaDetallePorIdSituacionPortuaria(Convert.ToInt32(savedEntry.VmRowidStcionPrtria));

                                if (listSituacionPortuariaDetalle != null)
                                {
                                    foreach (MdloDtos.SituacionPortuariaDetalle item in listSituacionPortuariaDetalle)
                                    {
                                        bool validarManejoPropio = item.SpdRowidOprdorPrtrioNavigation.TeMnjoPrpio != null ?
                                                                    (item.SpdRowidOprdorPrtrioNavigation.TeMnjoPrpio == true ? true : false) : false;
                                        if (validarManejoPropio)
                                        {
                                            //Procedemos a registrado los detalles de la VisitaMotonaveDetalles
                                            var ObjVisitaMotonaveDetalle = new MdloDtos.VisitaMotonaveDetalle();
                                            try
                                            {
                                                ObjVisitaMotonaveDetalle.VmdRowidVstaMtnve = savedEntry.VmRowid;
                                                ObjVisitaMotonaveDetalle.VmdRowidStcionPrtriaDtlle = item.SpdRowid;
                                                ObjVisitaMotonaveDetalle.VmdRowidAgnciaAdna = null;
                                                ObjVisitaMotonaveDetalle.VmdActvo = true;

                                                var response = await _dbContex.VisitaMotonaveDetalles.AddAsync(ObjVisitaMotonaveDetalle);
                                                await _dbContex.SaveChangesAsync();
                                            }
                                            catch (Exception ex)
                                            {
                                                throw new Exception(ex.ToString());
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjVisitaMotonave;
            }
        }
        #endregion

        #region verificar Visita Motonave
        public async Task<bool> VerificarVisitaMotonave(int RowId)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjVisitaMotonave = await _dbContex.VisitaMotonaves.FindAsync(RowId);
                    respuesta = ObjVisitaMotonave == null ? false : true;
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

        #region Actualizar la visitamotonave pasando un objeto VisitaMotonave.
        public async Task<MdloDtos.VisitaMotonave> EditarVisitaMotonave(MdloDtos.VisitaMotonave _VisitaMotonave)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.VisitaMotonave VisitaMotonaveExiste = await _dbContex.VisitaMotonaves.FindAsync(_VisitaMotonave.VmRowid);
                    MdloDtos.SituacionPortuarium SituacionPortuariaExiste = await _dbContex.SituacionPortuaria.FindAsync(_VisitaMotonave.VmRowidStcionPrtriaNavigation.SpRowid);

                    if (VisitaMotonaveExiste != null)
                    {
                        VisitaMotonaveExiste.VmFchaIncioOprcion = _VisitaMotonave.VmFchaIncioOprcion;
                        VisitaMotonaveExiste.VmFchaFinOprcion = _VisitaMotonave.VmFchaFinOprcion;
                        VisitaMotonaveExiste.VmFchaFndeo = _VisitaMotonave.VmFchaFndeo; 
                        VisitaMotonaveExiste.VmRowidZnaCdAltrno = _VisitaMotonave.VmRowidZnaCdAltrno;
                        _dbContex.Entry(VisitaMotonaveExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                        if (SituacionPortuariaExiste != null)
                        {
                            SituacionPortuariaExiste.SpFchaArrbo = _VisitaMotonave.VmRowidStcionPrtriaNavigation.SpFchaArrbo;
                            SituacionPortuariaExiste.SpFchaAtrque = _VisitaMotonave.VmRowidStcionPrtriaNavigation.SpFchaAtrque;
                            SituacionPortuariaExiste.SpFchaZrpe = _VisitaMotonave.VmRowidStcionPrtriaNavigation.SpFchaZrpe;
                            SituacionPortuariaExiste.SpCdgoEstdoMtnve = (SituacionPortuariaExiste.SpFchaZrpe != null) ? "4" :
                                                                        (SituacionPortuariaExiste.SpFchaAtrque != null) ? "3" :
                                                                        (_VisitaMotonave.VmFchaFndeo != null) ? "2" : 
                                                                        "1";
                            _dbContex.Entry(SituacionPortuariaExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        }
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return VisitaMotonaveExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region verificar un Visita
        public async Task<bool> VerificarVisita(int Id)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjVisita = await _dbContex.VisitaMotonaves.FindAsync(Id);
                    respuesta = ObjVisita == null ? false : true;
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

        #region Filtrar visita Motonave por Fecha o por codigo/ nombre de la motonave
        public async Task<List<MdloDtos.VisitaMotonave>> FiltrarVisitaMotonaveEspecifico(DateTime FechaInicio, DateTime FechaFin, string Motonave)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.VisitaMotonave> lista = new List<MdloDtos.VisitaMotonave>();
                //consulta por fecha y por motonave

                var VisitaMotonaveExiste = (from mtnve in _dbContex.Motonaves
                                            where (mtnve.MoCdgo.Contains(Motonave) || mtnve.MoNmbre.Contains(Motonave))
                                            select mtnve).ToList();
                var lstSituacion = new List<VwModuloVisitaMotonaveListarVisitaMotonave>();
                if (VisitaMotonaveExiste.Count > 0)
                {
                    lstSituacion = await (from listaVisitaMotonave in _dbContex.VwModuloVisitaMotonaveListarVisitaMotonaves
                                          where ((listaVisitaMotonave.VmFchaCrcion >= FechaInicio && listaVisitaMotonave.VmFchaCrcion <= FechaFin) &&
                                                  (listaVisitaMotonave.VmCdgoMtnve.Contains(Motonave) || listaVisitaMotonave.VmMotonaveNmbre.Contains(Motonave)))
                                          orderby listaVisitaMotonave.VmRowid descending
                                          select listaVisitaMotonave).ToListAsync();
                }

                else
                {//motonave es vacio
                    lstSituacion = await (from listaVisitaMotonave in _dbContex.VwModuloVisitaMotonaveListarVisitaMotonaves
                                          where (listaVisitaMotonave.VmFchaCrcion >= FechaInicio && listaVisitaMotonave.VmFchaCrcion <= FechaFin)
                                          orderby listaVisitaMotonave.VmRowid descending
                                          select listaVisitaMotonave).ToListAsync();
                }
                lista = IterarObjeto(lstSituacion);

                _dbContex.Dispose();
                return lista;
            }
        }
        #endregion

        #region Filtrar visita Motonave por id de visita
        public async Task<List<MdloDtos.VisitaMotonave>> FiltrarVisitaMotonaveId(int Id)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.VisitaMotonave> lista = new List<MdloDtos.VisitaMotonave>();

                var lstSituacion = await (from listaVisitaMotonave in _dbContex.VwModuloVisitaMotonaveListarVisitaMotonaves
                                          where (listaVisitaMotonave.VmRowid == Id)
                                          orderby listaVisitaMotonave.VmRowid descending
                                          select listaVisitaMotonave).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }
        }
        #endregion

        #region Filtrar visita Motonave por Codigo de Montonave
        public async Task<List<MdloDtos.VisitaMotonave>> FiltrarVisitaMotonaveMotonave(string Motonave)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                List<MdloDtos.VisitaMotonave> lista = new List<MdloDtos.VisitaMotonave>();

                var lstSituacion = await (from listaVisitaMotonave in _dbContex.VwModuloVisitaMotonaveListarVisitaMotonaves
                                          where (listaVisitaMotonave.VmMotonaveNmbre.Contains(Motonave) || listaVisitaMotonave.VmCdgoMtnve.Contains(Motonave))
                                          orderby listaVisitaMotonave.VmRowid descending
                                          select listaVisitaMotonave).ToListAsync();
                lista = IterarObjeto(lstSituacion);
                _dbContex.Dispose();
                return lista;
            }
        }
        #endregion

        #region Valida si ya existe una visita de motonave creada, para evitar duplicidad de visitaMotonave para la misma situaciónPortuaria , recibe como parámetro IdSituacion
        public async Task<bool> ValidarCrearVisitaMotonave(int IdSituacion)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lista = await (from VwStcionPrtriaLstar in _dbContex.VwModuloSituacionPortuariaListarSituacionPortuaria
                                   where VwStcionPrtriaLstar.SpRowid == IdSituacion

                                   select new
                                   {
                                       CrearVisitaMotonave = VwStcionPrtriaLstar.CrearVisitaMotonave == 1 ? true : false,
                                       CodigoVisitaMotonave = VwStcionPrtriaLstar.CodigoVisitaMotonave != null ? VwStcionPrtriaLstar.CodigoVisitaMotonave : 0
                                   }).ToListAsync();
                foreach (var item in lista)
                {
                    if (item.CrearVisitaMotonave == true && item.CodigoVisitaMotonave == 0) //Aún no se ha creado la visita de motonave
                    {
                        respuesta = true;
                    }
                    else
                    {
                        respuesta = false;
                    }
                }
                _dbContex.Dispose();
                return respuesta;
            }

        }
        #endregion

        #region Consulta  visita motonave encabezado por compañia y por fecha 
        public async Task<List<VisitaMotonaveDocumento>> ConsultaVisitaMotonaveCompania(string Compania, DateTime fechaInicio, DateTime FechaFin)
        {
            try
            {
                List<MdloDtos.VisitaMotonaveDocumento> lista = new List<MdloDtos.VisitaMotonaveDocumento>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    if (Compania == null)
                    {
                        var lstSituacion = await (from p in _dbContex.VisitaMotonaves
                                                  join l in _dbContex.Motonaves on p.VmCdgoMtnve equals l.MoCdgo
                                                  where (p.VmFchaIncioOprcion > fechaInicio && p.VmFchaFinOprcion <= FechaFin)
                                                  orderby p.VmRowid descending
                                                  select new
                                                  {
                                                      IdVisita = p.VmRowid,
                                                      NombreMotonave = l.MoNmbre,
                                                      SecuenciaVisita = p.VmScncia
                                                  }).ToListAsync();
                        foreach (var item in lstSituacion)
                        {
                            lista.Add(new MdloDtos.VisitaMotonaveDocumento(item.IdVisita, item.NombreMotonave, (short)item.SecuenciaVisita));
                        }
                    }
                    else
                    {
                        if (Compania != null)
                        {
                            var lstSituacion = await (from p in _dbContex.VisitaMotonaves
                                                      join l in _dbContex.Motonaves on p.VmCdgoMtnve equals l.MoCdgo
                                                      where (
                                                                ((p.VmFchaCrcion >= fechaInicio && p.VmFchaCrcion <= FechaFin) ||
                                                                (p.VmFchaIncioOprcion >= fechaInicio && p.VmFchaFinOprcion <= FechaFin) ||
                                                                (p.VmFchaFinOprcion >= fechaInicio && p.VmFchaFinOprcion <= FechaFin))
                                                             && (p.VmCdgoCia.Equals(Compania)))
                                                      orderby p.VmRowid descending
                                                      select new
                                                      {
                                                          IdVisita = p.VmRowid,
                                                          NombreMotonave = l.MoNmbre,
                                                          SecuenciaVisita = p.VmScncia
                                                      }).ToListAsync();
                            foreach (var item in lstSituacion)
                            {
                                lista.Add(new MdloDtos.VisitaMotonaveDocumento(item.IdVisita, item.NombreMotonave, (short)item.SecuenciaVisita));
                            }
                        }
                    }
                    _dbContex.Dispose();
                    return lista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #region Consulta Visita Motonave Aduana
        public async Task<List<MdloDtos.VisitaMotonave>> ConsultaVisitaMotonaveAduana(string Compania, string CodigoUsuario)
        {
            try
            {
                List<MdloDtos.VisitaMotonave> listaVisitaMotonave = new List<MdloDtos.VisitaMotonave>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    if (Compania != null && CodigoUsuario != null)
                    {
                        var lstSituacion = await (from p in _dbContex.VisitaMotonaves
                                                  join l in _dbContex.Motonaves on p.VmCdgoMtnve equals l.MoCdgo
                                                  join i in _dbContex.VisitaMotonaveDetalles on p.VmRowid equals i.VmdRowidVstaMtnve
                                                  join j in _dbContex.Terceros on i.VmdRowidAgnciaAdna equals j.TeRowid
                                                  join ha in _dbContex.Usuarios on j.TeRowid equals ha.UsRowidTrcro
                                                  where (ha.UsCdgo.Equals(CodigoUsuario) && p.VmCdgoCia.Equals(Compania))
                                                  orderby p.VmRowid descending
                                                  select new
                                                  {
                                                      IdVisita = p.VmRowid,
                                                      NombreMotonave = l.MoNmbre,
                                                      SecuenciaVisita = p.VmScncia
                                                  })
                                                  .Distinct()
                                                  .ToListAsync();
                        for (int i = lstSituacion.Count - 1; i >= 0; i--)
                        {
                            var item = lstSituacion[i];
                            listaVisitaMotonave.Add(
                                new MdloDtos.VisitaMotonave
                                {
                                    VmRowid = item.IdVisita,
                                    NombreMotonave = item.NombreMotonave,
                                    VmScncia = (short)item.SecuenciaVisita
                                }
                            );
                        }
                    }
                    _dbContex.Dispose();
                    return listaVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion


        #region Consulta documentosPendientesPorAprobacion
        public async Task<int> ConsultaCantidadDocumentosPendientesAprobacionPorVisitaMotonave(int IdVisitaMotonave)
        {
            AccsoDtos.VisitaMotonave.DocumentacionVisita ObjDocumentacionVisita = new AccsoDtos.VisitaMotonave.DocumentacionVisita();
            AccsoDtos.VisitaMotonave.VisitaMotonaveBl ObjVisitaMotonaveBl = new AccsoDtos.VisitaMotonave.VisitaMotonaveBl();

            List<VisitaMotonaveDocumento> listadoVisitaMotonaveDocumentoEncabezado = await ObjDocumentacionVisita.ConsultarTipoDocumentosIdVisita(IdVisitaMotonave);
            List<MdloDtos.VisitaMotonaveBl> listaVisitaMotonaveBl = await ObjVisitaMotonaveBl.FiltrarVisitaMotonaveBlPorIdVisitaMotonave(IdVisitaMotonave);
            int contadorDocumentosPendientes = 0;
            if (listadoVisitaMotonaveDocumentoEncabezado != null)
            {
                foreach (var item in listadoVisitaMotonaveDocumentoEncabezado) //Contador documentos pendientes en el encabezado
                {
                    int valor1 = item.VmdoEstdo.Equals("C") ? 1 : 0;
                    contadorDocumentosPendientes = contadorDocumentosPendientes + valor1;
                }
            }
            if (listaVisitaMotonaveBl != null)
            {
                foreach (var item in listaVisitaMotonaveBl)
                {
                    int value2 = item.VmblEstdo.Equals("C") ? 1 : 0;
                    contadorDocumentosPendientes = contadorDocumentosPendientes + value2; // contador documentos pendiente de BL

                    foreach (var linea in item.ListaLineasVisitaMotonaveBl)
                    {
                        int value3 = linea.VisitaMotonaveDocumentoUno.VmdoEstdo.Equals("C") ? 1 : 0; //Contador documento pendiente en VisitaMotonaveDocumento #1
                        int value4 = linea.VisitaMotonaveDocumentoDos.VmdoEstdo.Equals("C") ? 1 : 0; //Contador documento pendiente en VisitaMotonaveDocumento #2
                        contadorDocumentosPendientes = contadorDocumentosPendientes + value3 + value4;
                    }
                }
            }
            return contadorDocumentosPendientes;
        }
        #endregion

        #region Itera todos los objetos de tipo VwModuloVisitaMotonaveListarVisitaMotonave para retornar una lista de MdloDtos.VisitaMotonave
        public List<MdloDtos.VisitaMotonave> IterarObjeto(List<MdloDtos.VwModuloVisitaMotonaveListarVisitaMotonave> listaInput)
        {
            List<MdloDtos.VisitaMotonave> listaItem = new List<MdloDtos.VisitaMotonave>();
            foreach (var item in listaInput)
            {
                listaItem.Add(
                    new MdloDtos.VisitaMotonave
                    {
                        VmRowid = (int)item.VmRowid,
                        VmCdgoCia = item.VmCdgoCia,
                        //VmCdgoMtnve = !string.IsNullOrWhiteSpace(item.VmCdgoMtnve.ToString()) ? item.VmCdgoMtnve : 0,
                        VmCdgoMtnve = item.VmCdgoMtnve.ToString(),
                        VmFchaCrcion = item.VmFchaCrcion,
                        VmFchaIncioOprcion = item.VmFchaIncioOprcion,
                        VmFchaFinOprcion = item.VmFchaFinOprcion,
                        VmFchaFndeo = item.VmFchaFndeo,
                        VmScncia = item.VmScncia,
                        VmDscrpcion = item.VmDscrpcion,
                        VmRowidVnddor = item.VmRowidVnddor,
                        VmRowidZnaCdAltrno = item.VmRowidZnaCdAltrno,
                        VmRowidStcionPrtria = item.VmRowidStcionPrtria,
                        VmCdgoUsrioCrea = item.VmCdgoUsrioCrea,
                        NombreMotonave = item.VmMotonaveNmbre,
                        NombreCompania = item.VmCompaniaNmbre,
                        NombreAgente = item.SpTerceroAgnteNvroNmbre,
                        NombreVendedor = item.VmVnddorTrcroNmbre,
                        NombrePuertoOrigen = item.SpPaisNmbre,
                        NombreZona = item.SpZonaCdNmbre,
                        NombreZonaAlterna = item.VmZnaCdAltrnoNmbre,
                        NombreTerminal = item.SpTerminalMaritimoDscrpcion,
                        VmRowidStcionPrtriaNavigation = new MdloDtos.SituacionPortuarium
                        {
                            SpRowid = (int)item.SpRowid,
                            SpCdgoMtnve = item.SpCdgoMtnve,
                            SpRowidZnaCd = !string.IsNullOrWhiteSpace(item.SpRowidZnaCd.ToString()) ? item.SpRowidZnaCd : 0,
                            SpCdgoTrmnalMrtmo = item.SpCdgoTrmnalMrtmo,
                            SpFchaArrbo = item.SpFchaArrbo,
                            SpFchaAtrque = item.SpFchaAtrque,
                            SpFchaZrpe = item.SpFchaZrpe,
                            SpFchaCrcion = item.SpFchaCrcion,
                            SpCdgoEstdoMtnve = item.SpCdgoEstdoMtnve,
                            SpCdgoPais = item.SpCdgoPais,
                            SpRowidAgnteNvro = item.SpRowidAgnteNvro,
                            SpCdgoUsrioCrea = item.SpCdgoUsrioCrea,

                            SpCdgoMtnveNavigation = new MdloDtos.Motonave
                            {
                                MoCdgo = item.SpMotonaveCdgo,
                                MoNmbre = item.SpMotonaveNmbre,
                                MoEslra = item.SpMotonaveEslra,
                                MoMtrcla = item.SpMotonaveMtrcla,
                                MoBndra = item.SpMotonaveBndra,
                                MoCntdadEsctllas = item.SpMotonaveCntdadEsctllas,
                                MoCldo = item.SpMotonaveCldo
                            },
                            SpCdgoEstdoMtnveNavigation = new MdloDtos.EstadoMotonave
                            {
                                EmCdgo = item.SpEstadoMotonaveCdgo,
                                EmNmbre = item.SpEstadoMotonaveNmbre
                            },
                            SpCdgoPaisNavigation = new MdloDtos.Pai
                            {
                                PaCdgo = item.SpPaisCdgo,
                                PaNmbre = item.SpPaisNmbre
                            },
                            SpCdgoTrmnalMrtmoNavigation = new MdloDtos.TerminalMaritimo
                            {
                                TmCdgo = item.SpTerminalMaritimoCdgo,
                                TmDscrpcion = item.SpTerminalMaritimoDscrpcion
                            },
                            SpCdgoUsrioCreaNavigation = new MdloDtos.Usuario
                            {
                                UsCdgo = item.SpUsuarioCreaCdgo,
                                UsNmbre = item.SpUsuarioCreaNmbre,
                                UsIdntfccion = item.SpUsuarioCreaIdntfccion
                            },
                            SpRowidAgnteNvroNavigation = new MdloDtos.Tercero
                            {
                                TeRowid = item.SpTerceroAgnteRowid,
                                TeCdgoCia = item.SpTerceroAgnteNvrocdgoCia,
                                TeCdgo = item.SpTerceroAgnteNvroCdgo,
                                TeNmbre = item.SpTerceroAgnteNvroNmbre
                            },
                            SpRowidZnaCdNavigation = new MdloDtos.ZonaCd
                            {
                                ZcdRowid = item.SpZonaCdRowid,
                                ZcdCdgo = item.SpZonaCdCdgo,
                                ZcdNmbre = item.SpZonaCdNmbre,
                            },

                            NombreZona = item.SpZonaCdNmbre != null ? item.SpZonaCdNmbre : " ",
                            DescripcionMotonave = item.SpMotonaveNmbre.ToString(),
                            NombreTerminal = item.SpTerminalMaritimoDscrpcion != null ? item.SpTerminalMaritimoDscrpcion : " ",
                            NombreEstado = item.SpEstadoMotonaveNmbre.ToString(),
                            NombrePais = item.SpPaisNmbre.ToString(),
                            NombreAgente = item.SpTerceroAgnteNvroNmbre != null ? item.SpTerceroAgnteNvroNmbre : " ",
                            //implementacionBotonCrearVisita
                            CrearVisitaMotonave = item.SpCrearVisitaMotonave == 1 ? true : false,
                            CodigoVisitaMotonave = item.SpCodigoVisitaMotonave != null ? item.SpCodigoVisitaMotonave : 0
                        },
                        VmCdgoCiaNavigation = new MdloDtos.Companium
                        {
                            CiaCdgo = item.VmCompaniaCdgo,
                            CiaIdntfccion = item.VmCompaniaIdntfccion,
                            CiaNmbre = item.VmCompaniaNmbre
                        },
                        VmCdgoMtnveNavigation = new MdloDtos.Motonave
                        {
                            MoCdgo = item.VmMotonaveeCdgo,
                            MoNmbre = item.VmMotonaveNmbre,
                            MoEslra = item.VmMotonaveEslra,
                            MoMtrcla = item.VmMotonaveMtrcla,
                            MoBndra = item.VmMotonaveBndra,
                            MoCntdadEsctllas = item.VmMotonaveCntdadEsctllas,
                            MoCldo = item.VmMotonaveCldo
                        },
                        VmCdgoUsrioCreaNavigation = new MdloDtos.Usuario
                        {
                            UsCdgo = item.VmUsrioCreaCdgo,
                            UsNmbre = item.VmUsrioCreaNmbre,
                            UsIdntfccion = item.VmUsrioCreaIdntfccion
                        },
                        VmRowidVnddorNavigation = new MdloDtos.Tercero
                        {
                            TeRowid = item.VmVnddorTrcroRowid,
                            TeCdgo = item.VmVnddorTrcroCdgo,
                            TeNmbre = item.VmVnddorTrcroNmbre
                        },
                        VmRowidZnaCdAltrnoNavigation = new MdloDtos.ZonaCd
                        {
                            ZcdRowid = item.VmZnaCdAltrnoRowid,
                            ZcdCdgo = item.VmZnaCdAltrnoCdgo,
                            ZcdNmbre = item.VmZnaCdAltrnoNmbre,
                        }
                    }
                );
            }
            return listaItem;
        }
        #endregion


        #region Consulta Visita Motonave Modulo Deposito
        public async Task<List<MdloDtos.VwMdloDpstoLstarVstaMtnve>> ConsultaVisitaMotonaveDeposito(string Compania, string CodigoUsuario)
        {
            try
            {
                List<MdloDtos.VwMdloDpstoLstarVstaMtnve> listaVisitaMotonave = new List<MdloDtos.VwMdloDpstoLstarVstaMtnve>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    if (Compania != null && CodigoUsuario != null)
                    {
                        var _lstaVstaMtnve = await (from lstaVstaMtnve in _dbContex.VwMdloDpstoLstarVstaMtnves

                                                  where lstaVstaMtnve.VmCdgoCia.Equals(Compania) && lstaVstaMtnve.UsCdgo.Equals(CodigoUsuario)
                                                   orderby lstaVstaMtnve.VmRowid descending
                                                    select lstaVstaMtnve)
                                                  .ToListAsync();
                        foreach (var item in _lstaVstaMtnve)
                        {
                            listaVisitaMotonave.Add(
                                new MdloDtos.VwMdloDpstoLstarVstaMtnve
                                {
                                    VmRowid = item.VmRowid,
                                    VmMotonaveCdgo = item.VmMotonaveCdgo,
                                    VmMotonaveNmbre= item.VmMotonaveNmbre,
                                    VmScncia= item.VmScncia,
                                    UsCdgo = item.UsCdgo,
                                    VmCdgoCia= item.VmCdgoCia
                                }
                            );
                        }
                    }
                    _dbContex.Dispose();
                    return listaVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #region Consulta Visita Motonave Modulo Deposito Aprobacion
        public async Task<List<MdloDtos.VwMdloDpstoAprbcionLstarVstaMtnve>> ConsultaVisitaMotonaveDepositoAprobacion(string Compania)
        {
            try
            {
                List<MdloDtos.VwMdloDpstoAprbcionLstarVstaMtnve> listaVisitaMotonave = new List<MdloDtos.VwMdloDpstoAprbcionLstarVstaMtnve>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    if (Compania != null)
                    {
                        var _lstaVstaMtnve = await (from lstaVstaMtnve in _dbContex.VwMdloDpstoAprbcionLstarVstaMtnves

                                                    where lstaVstaMtnve.VmCdgoCia.Equals(Compania)
                                                    orderby lstaVstaMtnve.VmRowid descending
                                                    select lstaVstaMtnve)
                                                  .ToListAsync();
                        foreach (var item in _lstaVstaMtnve)
                        {
                            listaVisitaMotonave.Add(
                                new MdloDtos.VwMdloDpstoAprbcionLstarVstaMtnve
                                {
                                    VmRowid = item.VmRowid,
                                    VmMotonaveCdgo = item.VmMotonaveCdgo,
                                    VmMotonaveNmbre = item.VmMotonaveNmbre,
                                    VmScncia = item.VmScncia,
                                    VmCdgoCia = item.VmCdgoCia
                                }
                            );
                        }
                    }
                    _dbContex.Dispose();
                    return listaVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion

        #region Consulta Visita Motonave Modulo Deposito creacion
        public async Task<List<MdloDtos.VwMdloDpstoCrcionLstarVstaMtnve>> ConsultaVisitaMotonaveDepositoCreacion(string Compania)
        {
            try
            {
                List<MdloDtos.VwMdloDpstoCrcionLstarVstaMtnve> listaVisitaMotonave = new List<MdloDtos.VwMdloDpstoCrcionLstarVstaMtnve>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    if (Compania != null)
                    {
                        var _lstaVstaMtnve = await (from lstaVstaMtnve in _dbContex.VwMdloDpstoCrcionLstarVstaMtnves

                                                    where lstaVstaMtnve.VmCdgoCia.Equals(Compania)
                                                    orderby lstaVstaMtnve.VmRowid descending
                                                    select lstaVstaMtnve)
                                                  .ToListAsync();
                        foreach (var item in _lstaVstaMtnve)
                        {
                            listaVisitaMotonave.Add(
                                new MdloDtos.VwMdloDpstoCrcionLstarVstaMtnve
                                {
                                    VmRowid = item.VmRowid,
                                    VmMotonaveCdgo = item.VmMotonaveCdgo,
                                    VmMotonaveNmbre = item.VmMotonaveNmbre,
                                    VmScncia = item.VmScncia,
                                    VmCdgoCia = item.VmCdgoCia
                                }
                            );
                        }
                    }
                    _dbContex.Dispose();
                    return listaVisitaMotonave;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        #endregion
    }
}
