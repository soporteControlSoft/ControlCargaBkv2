 using AccsoDtos.Parametrizacion;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.VisitaMotonave
{
    /// <summary>
    /// Daniel Lopez
    /// Fecha: 30/04/2024
    /// Para lam documentacion encabezado
    /// </summary>
    public class DocumentacionVisita : MdloDtos.IModelos.IDocumentacionVisita
    {
        AccsoDtos.AccesoSistema.EnvioCorreoElectronico ObjEnvio = new AccsoDtos.AccesoSistema.EnvioCorreoElectronico();


        public async Task<List<MdloDtos.TipoDocumento>> ConsultarTipoDocumentos(int VisitaMotonave)
        {
            try
            {
                List<MdloDtos.TipoDocumento> listaTipoDocumentos = new List<MdloDtos.TipoDocumento>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())

                {
                    var listaTiposDocumentos = await (
                                                from td in _dbContex.TipoDocumentos
                                                where td.TdOrgen == "N" && td.TdActvo == true
                                                join MaxID in (
                                                    from vm in _dbContex.VisitaMotonaveDocumentos
                                                    where vm.VmdoRowidVstaMtnve == VisitaMotonave
                                                    group vm by vm.VmdoCdgoTpoDcmnto into g
                                                    select new
                                                    {
                                                        VmdoCdgoTpoDcmnto = g.Key,
                                                        RowIdVmdo = g.Max(x => x.VmdoRowid)
                                                    }
                                                ) on td.TdCdgo equals MaxID.VmdoCdgoTpoDcmnto into MaxIDJoin
                                                from MaxID in MaxIDJoin.DefaultIfEmpty()
                                                join vstaMtnveDcmntos in _dbContex.VisitaMotonaveDocumentos on MaxID.RowIdVmdo equals vstaMtnveDcmntos.VmdoRowid into vstaMtnveDcmntosJoin
                                                from vstaMtnveDcmntos in vstaMtnveDcmntosJoin.DefaultIfEmpty()
                                                select new
                                                {
                                                    td.TdCdgo,
                                                    td.TdNmbre,
                                                    td.TdOrgen,
                                                    td.TdNmbreAAsgnar,
                                                    td.TdActvo,
                                                    td.TdOblgtrio,
                                                    BotonColor = MaxID.RowIdVmdo == null ? "AZUL" :
                                                                 vstaMtnveDcmntos.VmdoEstdo == "C" ? "AMARILLO" :
                                                                 vstaMtnveDcmntos.VmdoEstdo == "A" ? "VERDE" :
                                                                 vstaMtnveDcmntos.VmdoEstdo == "R" ? "ROJO" : null
                                                }).ToListAsync();
                    foreach (var item in listaTiposDocumentos)
                    {
                        MdloDtos.TipoDocumento tipoDocumento = new MdloDtos.TipoDocumento(
                                                                                    item.TdCdgo,
                                                                                    item.TdNmbre,
                                                                                    item.TdOrgen,
                                                                                    item.TdNmbreAAsgnar,
                                                                                    item.TdActvo,
                                                                                    item.TdOblgtrio,
                                                                                    item.BotonColor);
                        listaTipoDocumentos.Add(tipoDocumento);
                    }
                    _dbContex.Dispose();
                    return listaTipoDocumentos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }

        #region Valida el estado en que se encuentra un documento en particular 
        public async Task<bool> validarPosibilidadNuevoIngresoTipoDocumentoPorVisitaMotonave(int VisitaMotonave, string tipoDocumentoAValidar)
        {
            try
            {

                bool respuesta = false;
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())

                {
                    var listaTiposDocumentos = await (
                                                from td in _dbContex.TipoDocumentos
                                                where td.TdOrgen == "N" && td.TdActvo == true
                                                join MaxID in (
                                                    from vm in _dbContex.VisitaMotonaveDocumentos
                                                    where vm.VmdoRowidVstaMtnve == VisitaMotonave
                                                    group vm by vm.VmdoCdgoTpoDcmnto into g
                                                    select new
                                                    {
                                                        VmdoCdgoTpoDcmnto = g.Key,
                                                        RowIdVmdo = g.Max(x => x.VmdoRowid)
                                                    }
                                                ) on td.TdCdgo equals MaxID.VmdoCdgoTpoDcmnto into MaxIDJoin
                                                from MaxID in MaxIDJoin.DefaultIfEmpty()
                                                join vstaMtnveDcmntos in _dbContex.VisitaMotonaveDocumentos on MaxID.RowIdVmdo equals vstaMtnveDcmntos.VmdoRowid into vstaMtnveDcmntosJoin
                                                from vstaMtnveDcmntos in vstaMtnveDcmntosJoin.DefaultIfEmpty()
                                                select new
                                                {
                                                    td.TdCdgo,
                                                    td.TdNmbre,
                                                    td.TdOrgen,
                                                    td.TdNmbreAAsgnar,
                                                    td.TdActvo,
                                                    td.TdOblgtrio,
                                                    BotonColor = MaxID.RowIdVmdo == null ? "AZUL" :
                                                                 vstaMtnveDcmntos.VmdoEstdo == "C" ? "AMARILLO" :
                                                                 vstaMtnveDcmntos.VmdoEstdo == "A" ? "VERDE" :
                                                                 vstaMtnveDcmntos.VmdoEstdo == "R" ? "ROJO" : null
                                                }).ToListAsync();
                    foreach (var item in listaTiposDocumentos)
                    {
                        if (tipoDocumentoAValidar.Equals(item.TdCdgo))
                        {
                            respuesta= (item.BotonColor.Equals("AZUL") || item.BotonColor.Equals("AMARILLO") || item.BotonColor.Equals("ROJO")) //Podemos cargar un nuevo documento en el sistema
                                        ?  true : false; 
                        }
                    }
                    _dbContex.Dispose();
                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }
        #endregion

        #region Consulta Documentos via id visita
        public async Task<List<VisitaMotonaveDocumento>> ConsultarTipoDocumentosIdVisita(int idVisitaMotonave)
        {
            try
            {
                List<MdloDtos.VisitaMotonaveDocumento> listaVisitaMotonaveDocumento = new List<MdloDtos.VisitaMotonaveDocumento>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    var listaTiposDocumentos = await (
                                                from visitaMotonaveDocumento in _dbContex.VisitaMotonaveDocumentos
                                                join MaxID in (
                                                                from vm in _dbContex.VisitaMotonaveDocumentos
                                                                where vm.VmdoRowidVstaMtnve == idVisitaMotonave
                                                                group vm by vm.VmdoCdgoTpoDcmnto into g
                                                                select new
                                                                {
                                                                    VmdoCdgoTpoDcmnto = g.Key,
                                                                    RowIdVmdo = g.Max(x => x.VmdoRowid)
                                                                }
                                                            ) on visitaMotonaveDocumento.VmdoRowid equals MaxID.RowIdVmdo
                                                join tipoDocumento in _dbContex.TipoDocumentos on MaxID.VmdoCdgoTpoDcmnto equals tipoDocumento.TdCdgo
                                                where visitaMotonaveDocumento.VmdoRowidVstaMtnve.Equals( idVisitaMotonave) && tipoDocumento.TdOrgen.Equals("N")
                                                select new {
                                                        visitaMotonaveDocumento.VmdoRowid,
                                                        visitaMotonaveDocumento.VmdoRowidVstaMtnve,
                                                        visitaMotonaveDocumento.VmdoCdgoTpoDcmnto,
                                                        visitaMotonaveDocumento.VmdoEstdo,
                                                        visitaMotonaveDocumento.VmdoRta,
                                                        visitaMotonaveDocumento.VmdoFchaCrgue,
                                                        visitaMotonaveDocumento.VmdoFchaAprbcion,
                                                        visitaMotonaveDocumento.VmdoCdgoUsrioCrgue,
                                                        visitaMotonaveDocumento.VmdoCdgoUsrioAprbdo,
                                                        tipoDocumento.TdCdgo,
                                                        tipoDocumento.TdNmbre,
                                                        tipoDocumento.TdOrgen,
                                                        tipoDocumento.TdNmbreAAsgnar,
                                                        tipoDocumento.TdActvo,
                                                        tipoDocumento.TdOblgtrio,
                                                        BotonColor = visitaMotonaveDocumento.VmdoEstdo == "C" ? "AMARILLO" :
                                                                        visitaMotonaveDocumento.VmdoEstdo == "A" ? "VERDE" :
                                                                        visitaMotonaveDocumento.VmdoEstdo == "R" ? "ROJO" : null
                                                    }
                                                ).ToListAsync();
                foreach (var item in listaTiposDocumentos)
                {
                    MdloDtos.VisitaMotonaveDocumento visitaMotonaveDocumento = new MdloDtos.VisitaMotonaveDocumento();
                    visitaMotonaveDocumento.VmdoRowid = item.VmdoRowid;
                    visitaMotonaveDocumento.VmdoRowidVstaMtnve = item.VmdoRowidVstaMtnve;
                    visitaMotonaveDocumento.VmdoCdgoTpoDcmnto = item.VmdoCdgoTpoDcmnto;
                    visitaMotonaveDocumento.VmdoEstdo = item.VmdoEstdo;
                    visitaMotonaveDocumento.VmdoRta = item.VmdoRta;
                    visitaMotonaveDocumento.VmdoFchaCrgue = item.VmdoFchaCrgue;
                    visitaMotonaveDocumento.VmdoFchaAprbcion = item.VmdoFchaAprbcion;
                    visitaMotonaveDocumento.VmdoCdgoUsrioCrgue = item.VmdoCdgoUsrioCrgue;
                    visitaMotonaveDocumento.VmdoCdgoUsrioAprbdo = item.VmdoCdgoUsrioAprbdo;
                    visitaMotonaveDocumento.Color = item.BotonColor;
                    MdloDtos.TipoDocumento tipoDocumento = new MdloDtos.TipoDocumento();
                        tipoDocumento.TdCdgo = item.TdCdgo;
                        tipoDocumento.TdNmbre = item.TdNmbre;
                        tipoDocumento.TdOrgen = item.TdOrgen;
                        tipoDocumento.TdNmbreAAsgnar = item.TdNmbreAAsgnar;
                        tipoDocumento.TdActvo = item.TdActvo;
                        tipoDocumento.TdOblgtrio = item.TdOblgtrio;
                        tipoDocumento.BotonColor = item.BotonColor;
                    visitaMotonaveDocumento.TipoDocumentoCargado=tipoDocumento;
                    listaVisitaMotonaveDocumento.Add(visitaMotonaveDocumento);
                }
                    _dbContex.Dispose();
                    return listaVisitaMotonaveDocumento;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }

        #endregion

        #region Consulta Documentos via id visita
        public async Task<List<VisitaMotonaveDocumento>> ConsultarVisitaMotonaveDocumentoEspecifico(int idVisitaMotonaveDocumento)
        {
            try
            {
                List<MdloDtos.VisitaMotonaveDocumento> listaVisitaMotonaveDocumento = new List<MdloDtos.VisitaMotonaveDocumento>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
                {
                    listaVisitaMotonaveDocumento = await (
                                                from visitaMotonaveDocumento in _dbContex.VisitaMotonaveDocumentos
                                               
                                                where visitaMotonaveDocumento.VmdoRowid.Equals(idVisitaMotonaveDocumento)
                                                select visitaMotonaveDocumento
                                                ).ToListAsync();
                    
                    _dbContex.Dispose();
                    return listaVisitaMotonaveDocumento;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());

            }
        }

        #endregion

        #region Consulta Motonave asociada a la visita motonave encabezado.
        public async Task<List<VisitaMotonaveDocumento>> ListaVisitaMotonave(string CodigoUsuario, string CodigoCompania)
        {
            try
            {
                List<MdloDtos.VisitaMotonaveDocumento> lista = new List<MdloDtos.VisitaMotonaveDocumento>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())

                {

                    var lstSituacion = await (from p in _dbContex.VisitaMotonaves
                                              join l in _dbContex.Motonaves on p.VmCdgoMtnve equals l.MoCdgo
                                              join sp in _dbContex.SituacionPortuaria on p.VmRowidStcionPrtria equals sp.SpRowid
                                              join w in _dbContex.Terceros on sp.SpRowidAgnteNvro equals w.TeRowid
                                              join j in _dbContex.Usuarios on w.TeRowid equals j.UsRowidTrcro
                                              orderby p.VmRowid descending
                                              where (j.UsCdgo.Equals(CodigoUsuario) && p.VmCdgoCia.Equals(CodigoCompania))
                                              select new
                                              {
                                                  IdVisita = p.VmRowid,
                                                  NombreMotonave = l.MoNmbre,
                                                  SecuenciaVisita = p.VmScncia

                                              }).ToListAsync();
                    foreach (var item in lstSituacion)
                    {
                        lista.Add(new MdloDtos.VisitaMotonaveDocumento((int)item.IdVisita, item.NombreMotonave, (short)item.SecuenciaVisita));
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

        #region Consulta Motonave asociada a la visita motonave encabezado por compañia.
        public async Task<List<VisitaMotonaveDocumento>> ListaVisitaMotonavePorCompania(string CodigoCompania)
        {
            try
            {
                List<MdloDtos.VisitaMotonaveDocumento> lista = new List<MdloDtos.VisitaMotonaveDocumento>();
                using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())

                {

                    var lstSituacion = await (from p in _dbContex.VisitaMotonaves
                                              join l in _dbContex.Motonaves on p.VmCdgoMtnve equals l.MoCdgo
                                              orderby p.VmRowid descending
                                              where ( p.VmCdgoCia == CodigoCompania)
                                              select new
                                              {
                                                  IdVisita = p.VmRowid,
                                                  NombreMotonave = l.MoNmbre,
                                                  SecuenciaVisita = p.VmScncia

                                              }).ToListAsync();
                    foreach (var item in lstSituacion)
                    {
                        lista.Add(new MdloDtos.VisitaMotonaveDocumento((int)item.IdVisita, item.NombreMotonave, (short)item.SecuenciaVisita));
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

        #region verificar Visita Motonave Documento
        public async Task<bool> VerificarVisitaMotonaveDocumento(int RowIdVisitaMotonaveDocumento)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjVisitaMotonave = await _dbContex.VisitaMotonaveDocumentos.FindAsync(RowIdVisitaMotonaveDocumento);
                    respuesta = ObjVisitaMotonave != null ? true : false;
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

        #region Ingresar Visita Motonave Documento
        public async Task<MdloDtos.VisitaMotonaveDocumento> IngresarVisitaMotonaveDocumento(MdloDtos.VisitaMotonaveDocumento _VisitaMotonaveDocumento)
        {
            var ObjVisitaMotonaveDocumento = new MdloDtos.VisitaMotonaveDocumento();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    DateTime Hoy =DateTime.Now;
                    ObjVisitaMotonaveDocumento.VmdoRowidVstaMtnve = _VisitaMotonaveDocumento.VmdoRowidVstaMtnve;
                    ObjVisitaMotonaveDocumento.VmdoCdgoTpoDcmnto = _VisitaMotonaveDocumento.VmdoCdgoTpoDcmnto;
                    ObjVisitaMotonaveDocumento.VmdoEstdo = "C";  //C = cargado por defecto
                    ObjVisitaMotonaveDocumento.VmdoFchaCrgue = Hoy;
                    ObjVisitaMotonaveDocumento.VmdoFchaAprbcion = null;
                    ObjVisitaMotonaveDocumento.VmdoCdgoUsrioCrgue = _VisitaMotonaveDocumento.VmdoCdgoUsrioCrgue;
                    ObjVisitaMotonaveDocumento.VmdoRta = _VisitaMotonaveDocumento.VmdoRta;
                    ObjVisitaMotonaveDocumento.VmdoCdgoUsrioAprbdo = null;
                    var res = await _dbContex.VisitaMotonaveDocumentos.AddAsync(ObjVisitaMotonaveDocumento);
                    await _dbContex.SaveChangesAsync();
                    _dbContex.Dispose();
                    return ObjVisitaMotonaveDocumento;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Actualiza estado Documentos.
        public async Task<MdloDtos.VisitaMotonaveDocumento> EditarEstadoDocumentos(MdloDtos.VisitaMotonaveDocumento _VisitaMotonaveDocumento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveDocumentoExiste = await _dbContex.VisitaMotonaveDocumentos.FindAsync(_VisitaMotonaveDocumento.VmdoRowid);
                    if (VisitaMotonaveDocumentoExiste != null)
                    {
                        string CorreoUsuario = "";
                        MdloDtos.CorreoElectronico ObjModeloCorreo = new CorreoElectronico();

                        var usuarioCorreo = (from us in _dbContex.Usuarios
                                             join visitaMotonaveDocumento in _dbContex.VisitaMotonaveDocumentos on us.UsCdgo equals visitaMotonaveDocumento.VmdoCdgoUsrioCrgue
                                             where visitaMotonaveDocumento.VmdoRowid == _VisitaMotonaveDocumento.VmdoRowid
                                             select us).ToList();

                        foreach (var la in usuarioCorreo)
                        {
                            CorreoUsuario = la.UsEmail;
                        }
                        if (VisitaMotonaveDocumentoExiste.VmdoEstdo=="C" && _VisitaMotonaveDocumento.VmdoEstdo == "A") {
                            //envio correo electronico.
                            var correo = (from l in _dbContex.Parametros select l).ToList();
                            if (correo.Count > 0 || correo != null)
                            {
                                foreach (var item in correo)
                                {
                                    ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                                    ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                                    ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                                    ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                                    ObjModeloCorreo.Para = CorreoUsuario;
                                    ObjModeloCorreo.Asunto = "Cambio de estado por aprobado";
                                    ObjModeloCorreo.Mensaje = "Cambio de estado por aprobado";

                                   /*string mensaje= "La documentación  YYYY cargada al[Cliente – Motonave: Visita], fueron Aprobados[Fecha:Hora]" +
                                    "IMPORTANTE: Este correo es informativo, favor no responder a esta dirección de correo, "
                                    + "ya que no se encuentra habilitada para recibir mensajes.";*/

                                                                        ObjModeloCorreo.Nombre_Archivo = "";
                                    ObjModeloCorreo.Msg_error = "";
                                }
                            }
                        }
                        if (VisitaMotonaveDocumentoExiste.VmdoEstdo == "C" && _VisitaMotonaveDocumento.VmdoEstdo == "R")
                        {
                            var correo = (from l in _dbContex.Parametros select l).ToList();
                            if (correo.Count > 0 || correo != null)
                            {
                                foreach (var item in correo)
                                {
                                    ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                                    ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                                    ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                                    ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                                    ObjModeloCorreo.Para = CorreoUsuario;
                                    ObjModeloCorreo.Asunto = "Cambio de estado por Rechazado";
                                    ObjModeloCorreo.Mensaje = "Cambio de estado por Rechazado";

                                    /*string mensaje= "La documentación  YYYY cargada al[Cliente – Motonave: Visita], fueron Aprobados[Fecha:Hora]" +
                                    "IMPORTANTE: Este correo es informativo, favor no responder a esta dirección de correo, "
                                    + "ya que no se encuentra habilitada para recibir mensajes.";*/

                                    ObjModeloCorreo.Nombre_Archivo = "";
                                    ObjModeloCorreo.Msg_error = "";
                                }
                            }
                        }
                       
                        DateTime hoy = DateTime.Now;
                        VisitaMotonaveDocumentoExiste.VmdoEstdo = _VisitaMotonaveDocumento.VmdoEstdo;
                        VisitaMotonaveDocumentoExiste.VmdoFchaAprbcion = hoy;
                        VisitaMotonaveDocumentoExiste.VmdoCdgoUsrioAprbdo = _VisitaMotonaveDocumento.VmdoCdgoUsrioAprbdo;

                        _dbContex.VisitaMotonaveDocumentos.Update(VisitaMotonaveDocumentoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                        //Procedemos a intentar guardar en la base de datos y si la respuesta es existada enviamos el correo.
                        try
                        {
                            await _dbContex.SaveChangesAsync();
                            ObjEnvio.Enviar_Correo_Directo(ObjModeloCorreo);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(ex.ToString());
                        }
                    }
                     _dbContex.Dispose();
                    return VisitaMotonaveDocumentoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Ingresa un comentario a la visita motonave documento.
        public async Task<List<MdloDtos.Comentario>> IngresarComentario(int CodigoVisitaMotonaveDocumento, string codigoUsuario, string comentario)
        {
            List <MdloDtos.Comentario> listaComentarios = new List<Comentario> ();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    //actualizar en visita motonave documentos.
                    var VisitaMotonaveDocumentoExiste = await _dbContex.VisitaMotonaveDocumentos.FindAsync(CodigoVisitaMotonaveDocumento);
                    if (VisitaMotonaveDocumentoExiste != null)
                    {
                        DateTime Hoy = DateTime.Now;
                        comentario=comentario.Replace("]#&&#[", "").Replace("]#&&[","").Replace("#&&#","");//codigo para evitar que se registre un separador dentro del comentario.
                        if (VisitaMotonaveDocumentoExiste.VmdoCmntrio != null)
                        {
                            VisitaMotonaveDocumentoExiste.VmdoCmntrio = VisitaMotonaveDocumentoExiste.VmdoCmntrio + "#&&#[" + Hoy.ToString() + "]#&&[" + codigoUsuario + "]#&&[" + comentario+"]";
                        }
                        else 
                        {
                            VisitaMotonaveDocumentoExiste.VmdoCmntrio = "["+Hoy.ToString() + "]#&&[" + codigoUsuario + "]#&&[" + comentario+"]";
                        }

                        _dbContex.VisitaMotonaveDocumentos.Update(VisitaMotonaveDocumentoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                        if (VisitaMotonaveDocumentoExiste.VmdoCmntrio != null)
                        {
                            foreach (var items in VisitaMotonaveDocumentoExiste.VmdoCmntrio.Split("#&&#"))
                            {
                                var item = items.Split("#&&");
                                //Intentamos extraer el nombre del usuario que ingresó el comentario con el codigo
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
                                    listaComentarios.Add(
                                        new MdloDtos.Comentario
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
                    return listaComentarios;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta un comentario a la visita motonave documento.
        public async Task<List<MdloDtos.Comentario>> ConsultarComentario(int CodigoVisitaMotonaveDocumento)
        {
            List<MdloDtos.Comentario> listaComentarios = new List<Comentario>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VisitaMotonaveDocumentoExiste = await _dbContex.VisitaMotonaveDocumentos.FindAsync(CodigoVisitaMotonaveDocumento);
                    if (VisitaMotonaveDocumentoExiste != null)
                    {
                        if (VisitaMotonaveDocumentoExiste.VmdoCmntrio != null)
                        {
                            foreach (var items in VisitaMotonaveDocumentoExiste.VmdoCmntrio.Split("#&&#"))
                            {
                                var item = items.Split("#&&");

                                //Intentamos extraer el nombre del usuario que ingresó el comentario con el codigo
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
                                    listaComentarios.Add(
                                        new MdloDtos.Comentario
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
                    return listaComentarios;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Actualiza estado Documentos.
        public async Task<List<MdloDtos.VisitaMotonaveDocumento>> ActualizarTarifas(List<MdloDtos.VisitaMotonaveDocumento> listVisitaMotonaveDocumento)
        {
            List<MdloDtos.VisitaMotonaveDocumento> listadoVisitaMotonaveDocumento = new List<VisitaMotonaveDocumento>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    foreach (MdloDtos.VisitaMotonaveDocumento _visitaMotonaveDocumento in listVisitaMotonaveDocumento)
                    {
                        var lst = await (from vstMtnveDcmnto in _dbContex.VisitaMotonaveDocumentos
                                         where vstMtnveDcmnto.VmdoLnea == _visitaMotonaveDocumento.VmdoLnea
                                         select vstMtnveDcmnto).ToListAsync();
                        foreach (MdloDtos.VisitaMotonaveDocumento _visitaMotonaveDocumento1 in lst)
                        {
                            var VisitaMotonaveDocumentoExiste = await _dbContex.VisitaMotonaveDocumentos.FindAsync(_visitaMotonaveDocumento1.VmdoRowid);
                            if (VisitaMotonaveDocumentoExiste != null)
                            {
                                VisitaMotonaveDocumentoExiste.VmdoTrm = _visitaMotonaveDocumento.VmdoTrm;
                                VisitaMotonaveDocumentoExiste.VmdoCstoSgroFlte = _visitaMotonaveDocumento.VmdoCstoSgroFlte;
                                VisitaMotonaveDocumentoExiste.VmdoArncelImprtcion = _visitaMotonaveDocumento.VmdoArncelImprtcion;

                                _dbContex.VisitaMotonaveDocumentos.Update(VisitaMotonaveDocumentoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                                await _dbContex.SaveChangesAsync();
                                listadoVisitaMotonaveDocumento.Add(VisitaMotonaveDocumentoExiste);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return listadoVisitaMotonaveDocumento;
            }
        }            
   
        #endregion
    }
}
