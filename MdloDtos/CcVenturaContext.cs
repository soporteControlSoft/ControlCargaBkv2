using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace MdloDtos;

public partial class CcVenturaContext : DbContext
{
    public CcVenturaContext()
    {
    }

    public CcVenturaContext(DbContextOptions<CcVenturaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Accione> Acciones { get; set; }

    public virtual DbSet<AuditoriaModulo> AuditoriaModulos { get; set; }

    public virtual DbSet<AuditoriaMotivo> AuditoriaMotivos { get; set; }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<AutorizacionRemotum> AutorizacionRemota { get; set; }

    public virtual DbSet<BarcoListadoCliente> BarcoListadoClientes { get; set; }

    public virtual DbSet<CausalCancelacion> CausalCancelacions { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Clasificacion> Clasificacions { get; set; }

    public virtual DbSet<Companium> Compania { get; set; }

    public virtual DbSet<ConceptoPesaje> ConceptoPesajes { get; set; }

    public virtual DbSet<CondicionFacturacion> CondicionFacturacions { get; set; }

    public virtual DbSet<ConfiguracionIp> ConfiguracionIps { get; set; }

    public virtual DbSet<ConfiguracionVehicular> ConfiguracionVehiculars { get; set; }

    public virtual DbSet<Consecutivo> Consecutivos { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Deposito> Depositos { get; set; }

    public virtual DbSet<DepositoBl> DepositoBls { get; set; }

    public virtual DbSet<Empaque> Empaques { get; set; }

    public virtual DbSet<Equipo> Equipos { get; set; }

    public virtual DbSet<EstadoHecho> EstadoHechos { get; set; }

    public virtual DbSet<EstadoMotonave> EstadoMotonaves { get; set; }

    public virtual DbSet<Evento> Eventos { get; set; }

    public virtual DbSet<GrupoTercero> GrupoTerceros { get; set; }

    public virtual DbSet<Motonave> Motonaves { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    public virtual DbSet<Parametro> Parametros { get; set; }

    public virtual DbSet<Perfil> Perfils { get; set; }

    public virtual DbSet<PerfilPermiso> PerfilPermisos { get; set; }

    public virtual DbSet<PerfilUsuario> PerfilUsuarios { get; set; }

    public virtual DbSet<PeriodoFacturacion> PeriodoFacturacions { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<PuertoOrigen> PuertoOrigens { get; set; }

    public virtual DbSet<Responsable> Responsables { get; set; }

    public virtual DbSet<RutaAccione> RutaAcciones { get; set; }

    public virtual DbSet<Rutum> Ruta { get; set; }

    public virtual DbSet<Sector> Sectors { get; set; }

    public virtual DbSet<SectorEvento> SectorEventos { get; set; }

    public virtual DbSet<Sede> Sedes { get; set; }

    public virtual DbSet<SituacionPortuariaDetalle> SituacionPortuariaDetalles { get; set; }

    public virtual DbSet<SituacionPortuarium> SituacionPortuaria { get; set; }

    public virtual DbSet<SolicitudRetiro> SolicitudRetiros { get; set; }

    public virtual DbSet<SolicitudRetiroAutorizacion> SolicitudRetiroAutorizacions { get; set; }

    public virtual DbSet<SolicitudRetiroAutorizacionHistorial> SolicitudRetiroAutorizacionHistorials { get; set; }

    public virtual DbSet<SolicitudRetiroTransportadora> SolicitudRetiroTransportadoras { get; set; }

    public virtual DbSet<SolicitudRetiroTransportadoraHistorial> SolicitudRetiroTransportadoraHistorials { get; set; }

    public virtual DbSet<Tercero> Terceros { get; set; }

    public virtual DbSet<TerceroCertificado> TerceroCertificados { get; set; }

    public virtual DbSet<TerminalMaritimo> TerminalMaritimos { get; set; }

    public virtual DbSet<TipoConcepto> TipoConceptos { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<TipoIdentificacion> TipoIdentificacions { get; set; }

    public virtual DbSet<UnidadMedidum> UnidadMedida { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    public virtual DbSet<VisitaMotonave> VisitaMotonaves { get; set; }

    public virtual DbSet<VisitaMotonaveBl> VisitaMotonaveBls { get; set; }

    public virtual DbSet<VisitaMotonaveBl1> VisitaMotonaveBl1s { get; set; }

    public virtual DbSet<VisitaMotonaveComentario> VisitaMotonaveComentarios { get; set; }

    public virtual DbSet<VisitaMotonaveDetalle> VisitaMotonaveDetalles { get; set; }

    public virtual DbSet<VisitaMotonaveDocumento> VisitaMotonaveDocumentos { get; set; }

    public virtual DbSet<VwConsultarProductosSubdeposito> VwConsultarProductosSubdepositos { get; set; }

    public virtual DbSet<VwConsultarSubdeposito> VwConsultarSubdepositos { get; set; }

    public virtual DbSet<VwEstdoHchoLstarVstaMtnve> VwEstdoHchoLstarVstaMtnves { get; set; }

    public virtual DbSet<VwListadoClientesDetalle> VwListadoClientesDetalles { get; set; }

    public virtual DbSet<VwListadoClientesDetalleCopium> VwListadoClientesDetalleCopia { get; set; }

    public virtual DbSet<VwListadoClientesEncabezado> VwListadoClientesEncabezados { get; set; }

    public virtual DbSet<VwMdloDpstoAprbcionLstarClntesPorVstaMtnve> VwMdloDpstoAprbcionLstarClntesPorVstaMtnves { get; set; }

    public virtual DbSet<VwMdloDpstoAprbcionLstarVstaMtnve> VwMdloDpstoAprbcionLstarVstaMtnves { get; set; }

    public virtual DbSet<VwMdloDpstoCrcionLstarVstaMtnve> VwMdloDpstoCrcionLstarVstaMtnves { get; set; }

    public virtual DbSet<VwMdloDpstoGnrarCdgoTmpralDpsto> VwMdloDpstoGnrarCdgoTmpralDpstos { get; set; }

    public virtual DbSet<VwMdloDpstoLstarPrdctoPorVstaMtnve> VwMdloDpstoLstarPrdctoPorVstaMtnves { get; set; }

    public virtual DbSet<VwMdloDpstoLstarVstaMtnve> VwMdloDpstoLstarVstaMtnves { get; set; }

    public virtual DbSet<VwModuloSituacionPortuariaListarSituacionPortuarium> VwModuloSituacionPortuariaListarSituacionPortuaria { get; set; }

    public virtual DbSet<VwModuloVisitaMotonaveListarVisitaMotonave> VwModuloVisitaMotonaveListarVisitaMotonaves { get; set; }

    public virtual DbSet<VwResumenListadoCliente> VwResumenListadoClientes { get; set; }

    public virtual DbSet<VwResumenListadoClientesOld> VwResumenListadoClientesOlds { get; set; }

    public virtual DbSet<WmDepositosSolicitudRetiro> WmDepositosSolicitudRetiros { get; set; }

    public virtual DbSet<WmGraficoListadoCliente> WmGraficoListadoClientes { get; set; }

    public virtual DbSet<WmGraficoListadoClientesOld> WmGraficoListadoClientesOlds { get; set; }

    public virtual DbSet<WvConsultaDepositosSubdeposito> WvConsultaDepositosSubdepositos { get; set; }

    public virtual DbSet<WxConsultaTipoDocumento> WxConsultaTipoDocumentos { get; set; }

    public virtual DbSet<ZonaCd> ZonaCds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=172.30.200.110\\MSSQLSERVER,2330;Initial Catalog=cc_ventura;Persist Security Info=False;User ID=sa;Password=V3ntuRAdata.2;Connection Timeout=30;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=FALSE;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Accione>(entity =>
        {
            entity.HasKey(e => e.AcRowid);

            entity.ToTable("acciones");

            entity.Property(e => e.AcRowid).HasColumnName("ac_rowid");
            entity.Property(e => e.AcNmbre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ac_nmbre");
            entity.Property(e => e.AcTpo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ac_tpo");
        });

        modelBuilder.Entity<AuditoriaModulo>(entity =>
        {
            entity.HasKey(e => e.AmCdgo);

            entity.ToTable("auditoria_modulo");

            entity.HasIndex(e => e.AmNmbre, "idx_auditoria_modulo_am_nmbre");

            entity.Property(e => e.AmCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("am_cdgo");
            entity.Property(e => e.AmNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("am_nmbre");
        });

        modelBuilder.Entity<AuditoriaMotivo>(entity =>
        {
            entity.HasKey(e => e.AmCdgo);

            entity.ToTable("auditoria_motivo");

            entity.HasIndex(e => e.AmDscrpcion, "idx_auditoria_motivo_am_dscrpcion");

            entity.Property(e => e.AmCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("am_cdgo");
            entity.Property(e => e.AmDscrpcion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("am_dscrpcion");
            entity.Property(e => e.AmRqrePdirRzon).HasColumnName("am_rqre_pdir_rzon");
        });

        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.AuRowid).HasName("PK_audtria");

            entity.ToTable("auditoria");

            entity.Property(e => e.AuRowid).HasColumnName("au_rowid");
            entity.Property(e => e.AuCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("au_cdgo_cia");
            entity.Property(e => e.AuCdgoMdlo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("au_cdgo_mdlo");
            entity.Property(e => e.AuCdgoMtvo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("au_cdgo_mtvo");
            entity.Property(e => e.AuCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("au_cdgo_usrio");
            entity.Property(e => e.AuCdgoUsrioAutrza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("au_cdgo_usrio_autrza");
            entity.Property(e => e.AuDtlle)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("au_dtlle");
            entity.Property(e => e.AuEqpo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("au_eqpo");
            entity.Property(e => e.AuEqpoAutrza)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("au_eqpo_autrza");
            entity.Property(e => e.AuFcha)
                .HasColumnType("smalldatetime")
                .HasColumnName("au_fcha");
            entity.Property(e => e.AuLlve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("au_llve");
            entity.Property(e => e.AuObsrvcnes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("au_obsrvcnes");
            entity.Property(e => e.AuRowidRgstro).HasColumnName("au_rowid_rgstro");
            entity.Property(e => e.AuRowidRgstroAutrzcionRmta).HasColumnName("au_rowid_rgstro_autrzcion_rmta");
            entity.Property(e => e.AuRzon)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("au_rzon");

            entity.HasOne(d => d.AuCdgoCiaNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.AuCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_auditoria_compania_cia_cdgo");

            entity.HasOne(d => d.AuCdgoMdloNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.AuCdgoMdlo)
                .HasConstraintName("FK_auditoria_auditoria_modulo_am_cdgo");

            entity.HasOne(d => d.AuCdgoMtvoNavigation).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.AuCdgoMtvo)
                .HasConstraintName("FK_auditoria_auditoria_motivo_am_cdgo");

            entity.HasOne(d => d.AuCdgoUsrioNavigation).WithMany(p => p.AuditoriumAuCdgoUsrioNavigations)
                .HasForeignKey(d => d.AuCdgoUsrio)
                .HasConstraintName("FK_auditoria_usuario_us_cdgo");

            entity.HasOne(d => d.AuCdgoUsrioAutrzaNavigation).WithMany(p => p.AuditoriumAuCdgoUsrioAutrzaNavigations)
                .HasForeignKey(d => d.AuCdgoUsrioAutrza)
                .HasConstraintName("FK_auditoria_usuario_us_cdgo_autrza");
        });

        modelBuilder.Entity<AutorizacionRemotum>(entity =>
        {
            entity.HasKey(e => e.ArRowid).HasName("PK_atrzcion_rmta");

            entity.ToTable("autorizacion_remota");

            entity.HasIndex(e => e.ArCdgoUsrioSlcta, "idx_autorizacion_remota_ar_cdgo_usrio_slcta");

            entity.HasIndex(e => e.ArEqpoAutrza, "idx_autorizacion_remota_ar_eqpo_autrza");

            entity.HasIndex(e => e.ArFchaSlctud, "idx_autorizacion_remota_ar_fcha_slctud");

            entity.Property(e => e.ArRowid).HasColumnName("ar_rowid");
            entity.Property(e => e.ArAutrzda).HasColumnName("ar_autrzda");
            entity.Property(e => e.ArCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ar_cdgo_cia");
            entity.Property(e => e.ArCdgoPrmso)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ar_cdgo_prmso");
            entity.Property(e => e.ArCdgoUsrioAutrza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ar_cdgo_usrio_autrza");
            entity.Property(e => e.ArCdgoUsrioSlcta)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ar_cdgo_usrio_slcta");
            entity.Property(e => e.ArCnfrmda).HasColumnName("ar_cnfrmda");
            entity.Property(e => e.ArDtlle)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("ar_dtlle");
            entity.Property(e => e.ArEqpoAutrza)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ar_eqpo_autrza");
            entity.Property(e => e.ArEqpoSlcta)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ar_eqpo_slcta");
            entity.Property(e => e.ArFchaAutrza)
                .HasColumnType("smalldatetime")
                .HasColumnName("ar_fcha_autrza");
            entity.Property(e => e.ArFchaSlctud)
                .HasColumnType("smalldatetime")
                .HasColumnName("ar_fcha_slctud");
            entity.Property(e => e.ArIdntfcdor)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("ar_idntfcdor");
            entity.Property(e => e.ArObsrvcnes)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ar_obsrvcnes");

            entity.HasOne(d => d.ArCdgoCiaNavigation).WithMany(p => p.AutorizacionRemota)
                .HasForeignKey(d => d.ArCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_autorizacion_remota_compania_cia_cdgo");

            entity.HasOne(d => d.ArCdgoUsrioAutrzaNavigation).WithMany(p => p.AutorizacionRemotumArCdgoUsrioAutrzaNavigations)
                .HasForeignKey(d => d.ArCdgoUsrioAutrza)
                .HasConstraintName("FK_autorizacion_remota_usuario_us_cdgo_autrza");

            entity.HasOne(d => d.ArCdgoUsrioSlctaNavigation).WithMany(p => p.AutorizacionRemotumArCdgoUsrioSlctaNavigations)
                .HasForeignKey(d => d.ArCdgoUsrioSlcta)
                .HasConstraintName("FK_autorizacion_remota_usuario_us_cdgo_slcta");
        });

        modelBuilder.Entity<BarcoListadoCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("Barco_ListadoClientes");

            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.Ecotilla).HasColumnName("ECOTILLA");
            entity.Property(e => e.IdOperador).HasColumnName("ID_OPERADOR");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.NombreOperador)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_OPERADOR");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<CausalCancelacion>(entity =>
        {
            entity.HasKey(e => e.CcCdgo);

            entity.ToTable("causal_cancelacion");

            entity.Property(e => e.CcCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cc_cdgo");
            entity.Property(e => e.CcDscrpcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cc_dscrpcion");
            entity.Property(e => e.CcOrgen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("cc_orgen");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiRowid);

            entity.ToTable("ciudad");

            entity.HasIndex(e => e.CiRowidDprtmnto, "idx_ciudad_ci_rowid_dprtmnto");

            entity.Property(e => e.CiRowid).HasColumnName("ci_rowid");
            entity.Property(e => e.CiCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ci_cdgo");
            entity.Property(e => e.CiNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ci_nmbre");
            entity.Property(e => e.CiRowidDprtmnto).HasColumnName("ci_rowid_dprtmnto");

            entity.HasOne(d => d.CiRowidDprtmntoNavigation).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.CiRowidDprtmnto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ciudad_departamento_de_rowid");
        });

        modelBuilder.Entity<Clasificacion>(entity =>
        {
            entity.HasKey(e => e.ClRowid);

            entity.ToTable("clasificacion");

            entity.Property(e => e.ClRowid).HasColumnName("cl_rowid");
            entity.Property(e => e.ClActvo).HasColumnName("cl_actvo");
            entity.Property(e => e.ClCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cl_cdgo_usrio");
            entity.Property(e => e.ClDscrpcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cl_dscrpcion");
            entity.Property(e => e.ClFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("cl_fcha_crcion");
            entity.Property(e => e.ClNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cl_nmbre");

            entity.HasOne(d => d.ClCdgoUsrioNavigation).WithMany(p => p.Clasificacions).HasForeignKey(d => d.ClCdgoUsrio);
        });

        modelBuilder.Entity<Companium>(entity =>
        {
            entity.HasKey(e => e.CiaCdgo);

            entity.ToTable("compania");

            entity.Property(e => e.CiaCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cia_cdgo");
            entity.Property(e => e.CiaActva).HasColumnName("cia_actva");
            entity.Property(e => e.CiaDrccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cia_drccion");
            entity.Property(e => e.CiaEmail)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_email");
            entity.Property(e => e.CiaIdSstmaEntrnmnto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_id_sstma_entrnmnto");
            entity.Property(e => e.CiaIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cia_idntfccion");
            entity.Property(e => e.CiaInsideClveUsrio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_inside_clve_usrio");
            entity.Property(e => e.CiaInsideIdUsrio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_inside_id_usrio");
            entity.Property(e => e.CiaInsideUrl1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cia_inside_url1");
            entity.Property(e => e.CiaInsideUrl2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cia_inside_url2");
            entity.Property(e => e.CiaLgo)
                .HasColumnType("image")
                .HasColumnName("cia_lgo");
            entity.Property(e => e.CiaNmbre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("cia_nmbre");
            entity.Property(e => e.CiaNmbreCntcto)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_nmbre_cntcto");
            entity.Property(e => e.CiaRndcClveUsrio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_rndc_clve_usrio");
            entity.Property(e => e.CiaRndcIdUsrio)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_rndc_id_usrio");
            entity.Property(e => e.CiaRndcUrl1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cia_rndc_url1");
            entity.Property(e => e.CiaRndcUrl2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cia_rndc_url2");
            entity.Property(e => e.CiaTlfno)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cia_tlfno");
        });

        modelBuilder.Entity<ConceptoPesaje>(entity =>
        {
            entity.HasKey(e => new { e.CpCia, e.CpCdgo });

            entity.ToTable("concepto_pesaje");

            entity.Property(e => e.CpCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cp_cia");
            entity.Property(e => e.CpCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cp_cdgo");
            entity.Property(e => e.CpActvo).HasColumnName("cp_actvo");
            entity.Property(e => e.CpCdgoTpoCncpto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cp_cdgo_tpo_cncpto");
            entity.Property(e => e.CpCmprtdo).HasColumnName("cp_cmprtdo");
            entity.Property(e => e.CpCnfrmarIdEntrda).HasColumnName("cp_cnfrmar_id_entrda");
            entity.Property(e => e.CpCnfrmarIdSlda).HasColumnName("cp_cnfrmar_id_slda");
            entity.Property(e => e.CpCntrlarCrgue).HasColumnName("cp_cntrlar_crgue");
            entity.Property(e => e.CpCntrlarSbrepso).HasColumnName("cp_cntrlar_sbrepso");
            entity.Property(e => e.CpDsactvarPrgrmcion).HasColumnName("cp_dsactvar_prgrmcion");
            entity.Property(e => e.CpDscrpcion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("cp_dscrpcion");
            entity.Property(e => e.CpFchaCrcion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("cp_fcha_crcion");
            entity.Property(e => e.CpFrmtoImprsion)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("cp_frmto_imprsion");
            entity.Property(e => e.CpNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("cp_nmbre");
            entity.Property(e => e.CpNmroCpiasTqte).HasColumnName("cp_nmro_cpias_tqte");
            entity.Property(e => e.CpNmroPsdasTra).HasColumnName("cp_nmro_psdas_tra");
            entity.Property(e => e.CpNtrlza)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("cp_ntrlza");
            entity.Property(e => e.CpPdirBdga).HasColumnName("cp_pdir_bdga");
            entity.Property(e => e.CpPdirCnfgrcionVhclar).HasColumnName("cp_pdir_cnfgrcion_vhclar");
            entity.Property(e => e.CpPdirEsctlla).HasColumnName("cp_pdir_esctlla");
            entity.Property(e => e.CpPdirIdScdad).HasColumnName("cp_pdir_id_scdad");
            entity.Property(e => e.CpPdirIdntfccionCndctor).HasColumnName("cp_pdir_idntfccion_cndctor");
            entity.Property(e => e.CpPdirMdldadDscrgue).HasColumnName("cp_pdir_mdldad_dscrgue");
            entity.Property(e => e.CpPdirOrdenIntrna).HasColumnName("cp_pdir_orden_intrna");
            entity.Property(e => e.CpPdirPtio).HasColumnName("cp_pdir_ptio");
            entity.Property(e => e.CpPdirRmlque).HasColumnName("cp_pdir_rmlque");
            entity.Property(e => e.CpPrmtirPrpsje).HasColumnName("cp_prmtir_prpsje");
            entity.Property(e => e.CpPrmtroGnral)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("cp_prmtro_gnral");
            entity.Property(e => e.CpRowidCnsctvo).HasColumnName("cp_rowid_cnsctvo");
            entity.Property(e => e.CpRprtaInsde).HasColumnName("cp_rprta_insde");
            entity.Property(e => e.CpUsoBscla).HasColumnName("cp_uso_bscla");
            entity.Property(e => e.CpUsoRsrva).HasColumnName("cp_uso_rsrva");
            entity.Property(e => e.CpVldaMnfsto).HasColumnName("cp_vlda_mnfsto");

            entity.HasOne(d => d.CpCdgoTpoCncptoNavigation).WithMany(p => p.ConceptoPesajes)
                .HasForeignKey(d => d.CpCdgoTpoCncpto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_concepto_pesaje_tc_cdgo");

            entity.HasOne(d => d.CpCiaNavigation).WithMany(p => p.ConceptoPesajes)
                .HasForeignKey(d => d.CpCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_concepto_pesaje_cia_cdgo");

            entity.HasOne(d => d.CpRowidCnsctvoNavigation).WithMany(p => p.ConceptoPesajes)
                .HasForeignKey(d => d.CpRowidCnsctvo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_concepto_pesaje_co_rowid");
        });

        modelBuilder.Entity<CondicionFacturacion>(entity =>
        {
            entity.HasKey(e => e.CfCdgo);

            entity.ToTable("condicion_facturacion");

            entity.Property(e => e.CfCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("cf_cdgo");
            entity.Property(e => e.CfFchaBse)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("cf_fcha_bse");
            entity.Property(e => e.CfNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cf_nmbre");
        });

        modelBuilder.Entity<ConfiguracionIp>(entity =>
        {
            entity.HasKey(e => e.CiRowid);

            entity.ToTable("configuracion_ip");

            entity.Property(e => e.CiRowid).HasColumnName("ci_rowid");
            entity.Property(e => e.CiDscrpcionPrvdor)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ci_dscrpcion_prvdor");
            entity.Property(e => e.CiDscrpcionTpo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ci_dscrpcion_tpo");
            entity.Property(e => e.CiIpPrvdor)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ci_ip_prvdor");
            entity.Property(e => e.CiPrtoIp).HasColumnName("ci_prto_ip");
            entity.Property(e => e.CiTpo).HasColumnName("ci_tpo");
        });

        modelBuilder.Entity<ConfiguracionVehicular>(entity =>
        {
            entity.HasKey(e => e.CvRowid);

            entity.ToTable("configuracion_vehicular");

            entity.HasIndex(e => e.CvNmbre, "idx_configuracion_vehicular_cv_nmbre");

            entity.Property(e => e.CvRowid).HasColumnName("cv_rowid");
            entity.Property(e => e.CvActvo).HasColumnName("cv_actvo");
            entity.Property(e => e.CvCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cv_cdgo");
            entity.Property(e => e.CvCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("cv_cdgo_cia");
            entity.Property(e => e.CvNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("cv_nmbre");
            entity.Property(e => e.CvPsoMxmo).HasColumnName("cv_pso_mxmo");
            entity.Property(e => e.CvTlrncia).HasColumnName("cv_tlrncia");

            entity.HasOne(d => d.CvCdgoCiaNavigation).WithMany(p => p.ConfiguracionVehiculars)
                .HasForeignKey(d => d.CvCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_configuracion_vehicular_compania_cia_cdgo");
        });

        modelBuilder.Entity<Consecutivo>(entity =>
        {
            entity.HasKey(e => e.CoRowid);

            entity.ToTable("consecutivo");

            entity.HasIndex(e => new { e.CoCdgoCia, e.CoCdgo }, "IX_consecutivo").IsUnique();

            entity.Property(e => e.CoRowid).HasColumnName("co_rowid");
            entity.Property(e => e.CoCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("co_cdgo");
            entity.Property(e => e.CoCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("co_cdgo_cia");
            entity.Property(e => e.CoCntdor).HasColumnName("co_cntdor");
            entity.Property(e => e.CoNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("co_nmbre");

            entity.HasOne(d => d.CoCdgoCiaNavigation).WithMany(p => p.Consecutivos)
                .HasForeignKey(d => d.CoCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_consecutivo_cia_cdgo");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.DeRowid);

            entity.ToTable("departamento");

            entity.Property(e => e.DeRowid).HasColumnName("de_rowid");
            entity.Property(e => e.DeCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo");
            entity.Property(e => e.DeCdgoPais)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_pais");
            entity.Property(e => e.DeNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("de_nmbre");

            entity.HasOne(d => d.DeCdgoPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.DeCdgoPais)
                .HasConstraintName("FK_departamento_pais_pa_cdgo");
        });

        modelBuilder.Entity<Deposito>(entity =>
        {
            entity.HasKey(e => e.DeRowid);

            entity.ToTable("deposito");

            entity.Property(e => e.DeRowid).HasColumnName("de_rowid");
            entity.Property(e => e.DeActvo).HasColumnName("de_actvo");
            entity.Property(e => e.DeAprbdo).HasColumnName("de_aprbdo");
            entity.Property(e => e.DeBlKlos).HasColumnName("de_bl_klos");
            entity.Property(e => e.DeBlKlosOrgnal).HasColumnName("de_bl_klos_orgnal");
            entity.Property(e => e.DeBlUnddes).HasColumnName("de_bl_unddes");
            entity.Property(e => e.DeBlUnddesOrgnal).HasColumnName("de_bl_unddes_orgnal");
            entity.Property(e => e.DeCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo");
            entity.Property(e => e.DeCdgoCndcionFctrcion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_cndcion_fctrcion");
            entity.Property(e => e.DeCdgoDpstoPdre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_dpsto_pdre");
            entity.Property(e => e.DeCdgoPrdcto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_prdcto");
            entity.Property(e => e.DeCdgoPrdoFctrcion)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_prdo_fctrcion");
            entity.Property(e => e.DeCdgoUsrioAprba)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_usrio_aprba");
            entity.Property(e => e.DeCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_usrio_crea");
            entity.Property(e => e.DeCdgoUsrioRchza)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cdgo_usrio_rchza");
            entity.Property(e => e.DeCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cia");
            entity.Property(e => e.DeCiaFctrcion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cia_fctrcion");
            entity.Property(e => e.DeCmntrioRchzo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("de_cmntrio_rchzo");
            entity.Property(e => e.DeCmntrios)
                .IsUnicode(false)
                .HasColumnName("de_cmntrios");
            entity.Property(e => e.DeCmpoClnte1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("de_cmpo_clnte1");
            entity.Property(e => e.DeCmpoClnte2)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("de_cmpo_clnte2");
            entity.Property(e => e.DeCmpoClnte3)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("de_cmpo_clnte3");
            entity.Property(e => e.DeCmprmtdoKlos).HasColumnName("de_cmprmtdo_klos");
            entity.Property(e => e.DeCmprmtdoUnddes).HasColumnName("de_cmprmtdo_unddes");
            entity.Property(e => e.DeCmun).HasColumnName("de_cmun");
            entity.Property(e => e.DeCndcionPgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_cndcion_pgo");
            entity.Property(e => e.DeCntdad).HasColumnName("de_cntdad");
            entity.Property(e => e.DeCntrolUnddes).HasColumnName("de_cntrol_unddes");
            entity.Property(e => e.DeCpiasTqte).HasColumnName("de_cpias_tqte");
            entity.Property(e => e.DeDiasCbro).HasColumnName("de_dias_cbro");
            entity.Property(e => e.DeDiasGrcia).HasColumnName("de_dias_grcia");
            entity.Property(e => e.DeDiasPrdo).HasColumnName("de_dias_prdo");
            entity.Property(e => e.DeEntrdasKlos).HasColumnName("de_entrdas_klos");
            entity.Property(e => e.DeEntrdasUnddes).HasColumnName("de_entrdas_unddes");
            entity.Property(e => e.DeEsSubdpsto).HasColumnName("de_es_subdpsto");
            entity.Property(e => e.DeEstdo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("de_estdo");
            entity.Property(e => e.DeFchaAgrpcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("de_fcha_agrpcion");
            entity.Property(e => e.DeFchaAprbcionRchzo)
                .HasColumnType("smalldatetime")
                .HasColumnName("de_fcha_aprbcion_rchzo");
            entity.Property(e => e.DeFchaIncioFctrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("de_fcha_incio_fctrcion");
            entity.Property(e => e.DeFchaPrmerMvmnto)
                .HasColumnType("smalldatetime")
                .HasColumnName("de_fcha_prmer_mvmnto");
            entity.Property(e => e.DeFchaUltmaFctra)
                .HasColumnType("smalldatetime")
                .HasColumnName("de_fcha_ultma_fctra");
            entity.Property(e => e.DeFctrcionFnlzda).HasColumnName("de_fctrcion_fnlzda");
            entity.Property(e => e.DeKlos).HasColumnName("de_klos");
            entity.Property(e => e.DeLqdaDlar).HasColumnName("de_lqda_dlar");
            entity.Property(e => e.DeMdldadFctrcion)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("de_mdldad_fctrcion");
            entity.Property(e => e.DeNcnlzdoKlos).HasColumnName("de_ncnlzdo_klos");
            entity.Property(e => e.DeNcnlzdoUnddes).HasColumnName("de_ncnlzdo_unddes");
            entity.Property(e => e.DeNmroUltmaFctra)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("de_nmro_ultma_fctra");
            entity.Property(e => e.DeObsrvcnes)
                .IsUnicode(false)
                .HasColumnName("de_obsrvcnes");
            entity.Property(e => e.DePsoPrmdio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("de_pso_prmdio");
            entity.Property(e => e.DeRowidEmpque).HasColumnName("de_rowid_empque");
            entity.Property(e => e.DeRowidSdeDspcho).HasColumnName("de_rowid_sde_dspcho");
            entity.Property(e => e.DeRowidSubdpstoFac1).HasColumnName("de_rowid_subdpsto_fac1");
            entity.Property(e => e.DeRowidSubdpstoFac2).HasColumnName("de_rowid_subdpsto_fac2");
            entity.Property(e => e.DeRowidSubdpstoFac3).HasColumnName("de_rowid_subdpsto_fac3");
            entity.Property(e => e.DeRowidTrcro).HasColumnName("de_rowid_trcro");
            entity.Property(e => e.DeRowidTrcroFctrcion).HasColumnName("de_rowid_trcro_fctrcion");
            entity.Property(e => e.DeRowidVstaMtnve).HasColumnName("de_rowid_vsta_mtnve");
            entity.Property(e => e.DeRtndoKlos).HasColumnName("de_rtndo_klos");
            entity.Property(e => e.DeRtndoUnddes)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("de_rtndo_unddes");
            entity.Property(e => e.DeSeFctra).HasColumnName("de_se_fctra");
            entity.Property(e => e.DeSldasKlos).HasColumnName("de_sldas_klos");
            entity.Property(e => e.DeSldasUnddes).HasColumnName("de_sldas_unddes");
            entity.Property(e => e.DeSspnddo).HasColumnName("de_sspnddo");
            entity.Property(e => e.DeTrfaPrdo1)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("de_trfa_prdo_1");
            entity.Property(e => e.DeTrfaPrdo2)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("de_trfa_prdo_2");
            entity.Property(e => e.DeTrfaPrdo3)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("de_trfa_prdo_3");
            entity.Property(e => e.DeTrfaPrdo4)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("de_trfa_prdo_4");
            entity.Property(e => e.DeTrfaPrdo5)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("de_trfa_prdo_5");
            entity.Property(e => e.DeTrfaPrdo6)
                .HasColumnType("decimal(8, 4)")
                .HasColumnName("de_trfa_prdo_6");
            entity.Property(e => e.DeTrm)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("de_trm");
            entity.Property(e => e.DeUltmoPrdoFctrdo).HasColumnName("de_ultmo_prdo_fctrdo");
            entity.Property(e => e.DeVlorCifClnte)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("de_vlor_cif_clnte");
            entity.Property(e => e.DeVlorCifLo)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("de_vlor_cif_lo");
            entity.Property(e => e.DeVlorCifPrmerPrdo)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("de_vlor_cif_prmer_prdo");
            entity.Property(e => e.DeVlorCifUs)
                .HasColumnType("decimal(16, 4)")
                .HasColumnName("de_vlor_cif_us");
            entity.Property(e => e.DeVlorFjoXTnlda)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("de_vlor_fjo_x_tnlda");
            entity.Property(e => e.DeVlorUntrio)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("de_vlor_untrio");

            entity.HasOne(d => d.DeCdgoCndcionFctrcionNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.DeCdgoCndcionFctrcion)
                .HasConstraintName("FK_deposito_condicion_facturacion_cf_cdgo");

            entity.HasOne(d => d.DeCdgoPrdctoNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.DeCdgoPrdcto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deposito_producto_pr_cdgo");

            entity.HasOne(d => d.DeCdgoPrdoFctrcionNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.DeCdgoPrdoFctrcion)
                .HasConstraintName("FK_deposito_periodo_facturacion_pf_cdgo");

            entity.HasOne(d => d.DeCdgoUsrioAprbaNavigation).WithMany(p => p.DepositoDeCdgoUsrioAprbaNavigations)
                .HasForeignKey(d => d.DeCdgoUsrioAprba)
                .HasConstraintName("FK_deposito_usuario_us_cdgo_aprba");

            entity.HasOne(d => d.DeCdgoUsrioCreaNavigation).WithMany(p => p.DepositoDeCdgoUsrioCreaNavigations)
                .HasForeignKey(d => d.DeCdgoUsrioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deposito_usuario_us_cdgo_crea");

            entity.HasOne(d => d.DeCiaNavigation).WithMany(p => p.DepositoDeCiaNavigations)
                .HasForeignKey(d => d.DeCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deposito_compania_cia_cdgo");

            entity.HasOne(d => d.DeCiaFctrcionNavigation).WithMany(p => p.DepositoDeCiaFctrcionNavigations)
                .HasForeignKey(d => d.DeCiaFctrcion)
                .HasConstraintName("FK_deposito_compania_cia_cdgo_fctrcion");

            entity.HasOne(d => d.DeRowidEmpqueNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.DeRowidEmpque)
                .HasConstraintName("FK_deposito_empaque_em_rowid");

            entity.HasOne(d => d.DeRowidSdeDspchoNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.DeRowidSdeDspcho)
                .HasConstraintName("FK_deposito_sede_se_rowid");

            entity.HasOne(d => d.DeRowidSubdpstoFac1Navigation).WithMany(p => p.InverseDeRowidSubdpstoFac1Navigation).HasForeignKey(d => d.DeRowidSubdpstoFac1);

            entity.HasOne(d => d.DeRowidSubdpstoFac2Navigation).WithMany(p => p.InverseDeRowidSubdpstoFac2Navigation).HasForeignKey(d => d.DeRowidSubdpstoFac2);

            entity.HasOne(d => d.DeRowidSubdpstoFac3Navigation).WithMany(p => p.InverseDeRowidSubdpstoFac3Navigation).HasForeignKey(d => d.DeRowidSubdpstoFac3);

            entity.HasOne(d => d.DeRowidTrcroNavigation).WithMany(p => p.DepositoDeRowidTrcroNavigations)
                .HasForeignKey(d => d.DeRowidTrcro)
                .HasConstraintName("FK_deposito_tercero_te_rowid_trcro");

            entity.HasOne(d => d.DeRowidTrcroFctrcionNavigation).WithMany(p => p.DepositoDeRowidTrcroFctrcionNavigations)
                .HasForeignKey(d => d.DeRowidTrcroFctrcion)
                .HasConstraintName("FK_deposito_tercero_te_rowid_trcro_fctrcion");

            entity.HasOne(d => d.DeRowidVstaMtnveNavigation).WithMany(p => p.Depositos)
                .HasForeignKey(d => d.DeRowidVstaMtnve)
                .HasConstraintName("FK_deposito_visita_motonave_vm_rowid");
        });

        modelBuilder.Entity<DepositoBl>(entity =>
        {
            entity.HasKey(e => e.DblRowid);

            entity.ToTable("deposito_bl");

            entity.Property(e => e.DblRowid).HasColumnName("dbl_rowid");
            entity.Property(e => e.DblRowidDpsto).HasColumnName("dbl_rowid_dpsto");
            entity.Property(e => e.DblRowidVstaMtnveBl).HasColumnName("dbl_rowid_vsta_mtnve_bl");

            entity.HasOne(d => d.DblRowidDpstoNavigation).WithMany(p => p.DepositoBls)
                .HasForeignKey(d => d.DblRowidDpsto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deposito_bl_deposito_de_rowid");

            entity.HasOne(d => d.DblRowidVstaMtnveBlNavigation).WithMany(p => p.DepositoBls)
                .HasForeignKey(d => d.DblRowidVstaMtnveBl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_deposito_bl_visita_motonave_bl_vmbl_rowid");
        });

        modelBuilder.Entity<Empaque>(entity =>
        {
            entity.HasKey(e => e.EmRowid);

            entity.ToTable("empaque");

            entity.HasIndex(e => new { e.EmCdgoCia, e.EmNmbre }, "IX_empaque").IsUnique();

            entity.Property(e => e.EmRowid).HasColumnName("em_rowid");
            entity.Property(e => e.EmActvo).HasColumnName("em_actvo");
            entity.Property(e => e.EmCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("em_cdgo");
            entity.Property(e => e.EmCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("em_cdgo_cia");
            entity.Property(e => e.EmNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("em_nmbre");
            entity.Property(e => e.EmTra)
                .HasColumnType("decimal(8, 3)")
                .HasColumnName("em_tra");

            entity.HasOne(d => d.EmCdgoCiaNavigation).WithMany(p => p.Empaques)
                .HasForeignKey(d => d.EmCdgoCia)
                .HasConstraintName("FK_empaque_compania_cia_cdgo");
        });

        modelBuilder.Entity<Equipo>(entity =>
        {
            entity.HasKey(e => e.EqRowid);

            entity.ToTable("equipo");

            entity.Property(e => e.EqRowid).HasColumnName("eq_rowid");
            entity.Property(e => e.EqActvo).HasColumnName("eq_actvo");
            entity.Property(e => e.EqCdgo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("eq_cdgo");
            entity.Property(e => e.EqCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("eq_cdgo_usrio");
            entity.Property(e => e.EqDscrpcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eq_dscrpcion");
            entity.Property(e => e.EqFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("eq_fcha_crcion");
            entity.Property(e => e.EqNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("eq_nmbre");

            entity.HasOne(d => d.EqCdgoUsrioNavigation).WithMany(p => p.Equipos).HasForeignKey(d => d.EqCdgoUsrio);
        });

        modelBuilder.Entity<EstadoHecho>(entity =>
        {
            entity.HasKey(e => e.EhRowid);

            entity.ToTable("estado_hechos");

            entity.Property(e => e.EhRowid).HasColumnName("eh_rowid");
            entity.Property(e => e.EhCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("eh_cdgo_usrio");
            entity.Property(e => e.EhEsctlla).HasColumnName("eh_esctlla");
            entity.Property(e => e.EhEstdo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("eh_estdo");
            entity.Property(e => e.EhFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("eh_fcha_crcion");
            entity.Property(e => e.EhFchaFin)
                .HasColumnType("smalldatetime")
                .HasColumnName("eh_fcha_fin");
            entity.Property(e => e.EhFchaIncio)
                .HasColumnType("smalldatetime")
                .HasColumnName("eh_fcha_incio");
            entity.Property(e => e.EhObsrvcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("eh_obsrvcion");
            entity.Property(e => e.EhRowidEqpo).HasColumnName("eh_rowid_eqpo");
            entity.Property(e => e.EhRowidEvnto).HasColumnName("eh_rowid_evnto");
            entity.Property(e => e.EhRowidSctor).HasColumnName("eh_rowid_sctor");
            entity.Property(e => e.EhRowidVstaMtnve).HasColumnName("eh_rowid_vsta_mtnve");
            entity.Property(e => e.EhRowidZnaCd).HasColumnName("eh_rowid_zna_cd");

            entity.HasOne(d => d.EhCdgoUsrioNavigation).WithMany(p => p.EstadoHechoes).HasForeignKey(d => d.EhCdgoUsrio);

            entity.HasOne(d => d.EhRowidEqpoNavigation).WithMany(p => p.EstadoHechoes)
                .HasForeignKey(d => d.EhRowidEqpo)
                .HasConstraintName("FK_estado_hechos_equipo_eq_rowid");

            entity.HasOne(d => d.EhRowidEvntoNavigation).WithMany(p => p.EstadoHechoes)
                .HasForeignKey(d => d.EhRowidEvnto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estado_hechos_evento_ev_rowid");

            entity.HasOne(d => d.EhRowidSctorNavigation).WithMany(p => p.EstadoHechoes)
                .HasForeignKey(d => d.EhRowidSctor)
                .HasConstraintName("FK_estado_hechos_sector_se_rowid");

            entity.HasOne(d => d.EhRowidVstaMtnveNavigation).WithMany(p => p.EstadoHechoes)
                .HasForeignKey(d => d.EhRowidVstaMtnve)
                .HasConstraintName("FK_estado_hechos_visita_motonave_vm_rowid");

            entity.HasOne(d => d.EhRowidZnaCdNavigation).WithMany(p => p.EstadoHechoes)
                .HasForeignKey(d => d.EhRowidZnaCd)
                .HasConstraintName("FK_estado_hechos_zona_cd_zcd_rowid");
        });

        modelBuilder.Entity<EstadoMotonave>(entity =>
        {
            entity.HasKey(e => e.EmCdgo).HasName("PK__estado_m__D431D6033F5D76AA");

            entity.ToTable("estado_motonave");

            entity.Property(e => e.EmCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("em_cdgo");
            entity.Property(e => e.EmNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("em_nmbre");
        });

        modelBuilder.Entity<Evento>(entity =>
        {
            entity.HasKey(e => e.EvRowid);

            entity.ToTable("evento");

            entity.Property(e => e.EvRowid).HasColumnName("ev_rowid");
            entity.Property(e => e.EvActvo).HasColumnName("ev_actvo");
            entity.Property(e => e.EvCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ev_cdgo_usrio");
            entity.Property(e => e.EvEqpo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ev_eqpo");
            entity.Property(e => e.EvEsctlla)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ev_esctlla");
            entity.Property(e => e.EvFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("ev_fcha_crcion");
            entity.Property(e => e.EvFchaFin)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ev_fcha_fin");
            entity.Property(e => e.EvFchaIncio)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ev_fcha_incio");
            entity.Property(e => e.EvNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("ev_nmbre");
            entity.Property(e => e.EvObsrvcion)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ev_obsrvcion");
            entity.Property(e => e.EvRowidClsfccion).HasColumnName("ev_rowid_clsfccion");
            entity.Property(e => e.EvRowidRspnsble).HasColumnName("ev_rowid_rspnsble");

            entity.HasOne(d => d.EvCdgoUsrioNavigation).WithMany(p => p.Eventos).HasForeignKey(d => d.EvCdgoUsrio);

            entity.HasOne(d => d.EvRowidClsfccionNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.EvRowidClsfccion)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EvRowidRspnsbleNavigation).WithMany(p => p.Eventos)
                .HasForeignKey(d => d.EvRowidRspnsble)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<GrupoTercero>(entity =>
        {
            entity.HasKey(e => e.GtCdgo);

            entity.ToTable("grupo_tercero");

            entity.Property(e => e.GtCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("gt_cdgo");
            entity.Property(e => e.GtActvo).HasColumnName("gt_actvo");
            entity.Property(e => e.GtDscrpcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("gt_dscrpcion");
        });

        modelBuilder.Entity<Motonave>(entity =>
        {
            entity.HasKey(e => e.MoCdgo);

            entity.ToTable("motonave");

            entity.HasIndex(e => e.MoNmbre, "idx_motonave_mo_nmbre");

            entity.Property(e => e.MoCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mo_cdgo");
            entity.Property(e => e.MoBndra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mo_bndra");
            entity.Property(e => e.MoCldo)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("mo_cldo");
            entity.Property(e => e.MoCntdadEsctllas).HasColumnName("mo_cntdad_esctllas");
            entity.Property(e => e.MoEslra)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("mo_eslra");
            entity.Property(e => e.MoMtrcla)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mo_mtrcla");
            entity.Property(e => e.MoNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mo_nmbre");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.PaCdgo);

            entity.ToTable("pais");

            entity.Property(e => e.PaCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pa_cdgo");
            entity.Property(e => e.PaNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pa_nmbre");
        });

        modelBuilder.Entity<Parametro>(entity =>
        {
            entity.HasKey(e => e.PaId).HasName("PK_prmtro");

            entity.ToTable("parametros");

            entity.Property(e => e.PaId).HasColumnName("pa_id");
            entity.Property(e => e.PaClvesAntrres).HasColumnName("pa_clves_antrres");
            entity.Property(e => e.PaCrreoClve)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pa_crreo_clve");
            entity.Property(e => e.PaCrreoCnxionSgra).HasColumnName("pa_crreo_cnxion_sgra");
            entity.Property(e => e.PaCrreoPrto).HasColumnName("pa_crreo_prto");
            entity.Property(e => e.PaCrreoSrvdor)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pa_crreo_srvdor");
            entity.Property(e => e.PaCrreoUsrio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pa_crreo_usrio");
            entity.Property(e => e.PaDiasInctvcionExtrnos).HasColumnName("pa_dias_inctvcion_extrnos");
            entity.Property(e => e.PaDiasVgnciaClveExtrnos).HasColumnName("pa_dias_vgncia_clve_extrnos");
            entity.Property(e => e.PaDiasVgnciaClveIntrnos).HasColumnName("pa_dias_vgncia_clve_intrnos");
            entity.Property(e => e.PaEmprsa)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pa_emprsa");
            entity.Property(e => e.PaNasClave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pa_nas_clave");
            entity.Property(e => e.PaNasPuerto).HasColumnName("pa_nas_puerto");
            entity.Property(e => e.PaNasRuta)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("pa_nas_ruta");
            entity.Property(e => e.PaNasUsuario)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pa_nas_usuario");
            entity.Property(e => e.PaUrlPrtalLgstco)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("pa_url_prtal_lgstco");
        });

        modelBuilder.Entity<Perfil>(entity =>
        {
            entity.HasKey(e => e.PeCdgo);

            entity.ToTable("perfil");

            entity.Property(e => e.PeCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pe_cdgo");
            entity.Property(e => e.PeActvo).HasColumnName("pe_actvo");
            entity.Property(e => e.PeNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pe_nmbre");
            entity.Property(e => e.PePrmsos)
                .IsUnicode(false)
                .HasColumnName("pe_prmsos");
        });

        modelBuilder.Entity<PerfilPermiso>(entity =>
        {
            entity.HasKey(e => e.PpRowid).HasName("PK_prfil_prmso");

            entity.ToTable("perfil_permiso");

            entity.Property(e => e.PpRowid).HasColumnName("pp_rowid");
            entity.Property(e => e.PpAccnes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("pp_accnes");
            entity.Property(e => e.PpCdgoPrfil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pp_cdgo_prfil");
            entity.Property(e => e.PpPrmso)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("pp_prmso");
            entity.Property(e => e.PpRta).HasColumnName("pp_rta");
        });

        modelBuilder.Entity<PerfilUsuario>(entity =>
        {
            entity.HasKey(e => e.PuRowid).IsClustered(false);

            entity.ToTable("perfil_usuario");

            entity.Property(e => e.PuRowid).HasColumnName("pu_rowid");
            entity.Property(e => e.PuActvo).HasColumnName("pu_actvo");
            entity.Property(e => e.PuCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pu_cdgo_cia");
            entity.Property(e => e.PuCdgoPrfil)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pu_cdgo_prfil");
            entity.Property(e => e.PuCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pu_cdgo_usrio");

            entity.HasOne(d => d.PuCdgoCiaNavigation).WithMany(p => p.PerfilUsuarios)
                .HasForeignKey(d => d.PuCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_perfil_usuario_compania_cia_cdgo");

            entity.HasOne(d => d.PuCdgoPrfilNavigation).WithMany(p => p.PerfilUsuarios)
                .HasForeignKey(d => d.PuCdgoPrfil)
                .HasConstraintName("FK_perfil_usuario_perfil_pe_cdgo");

            entity.HasOne(d => d.PuCdgoUsrioNavigation).WithMany(p => p.PerfilUsuarios)
                .HasForeignKey(d => d.PuCdgoUsrio)
                .HasConstraintName("FK_perfil_usuario_usuario_us_cdgo");
        });

        modelBuilder.Entity<PeriodoFacturacion>(entity =>
        {
            entity.HasKey(e => e.PfCdgo);

            entity.ToTable("periodo_facturacion");

            entity.Property(e => e.PfCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("pf_cdgo");
            entity.Property(e => e.PfCdgoErp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pf_cdgo_erp");
            entity.Property(e => e.PfDias).HasColumnName("pf_dias");
            entity.Property(e => e.PfNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pf_nmbre");
            entity.Property(e => e.PfPrmdio).HasColumnName("pf_prmdio");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.PrCdgo);

            entity.ToTable("producto");

            entity.HasIndex(e => e.PrNmbre, "IX_producto").IsUnique();

            entity.Property(e => e.PrCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pr_cdgo");
            entity.Property(e => e.PrActvo).HasColumnName("pr_actvo");
            entity.Property(e => e.PrCdgoErp)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("pr_cdgo_erp");
            entity.Property(e => e.PrNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pr_nmbre");
            entity.Property(e => e.PrSlctarEmpque).HasColumnName("pr_slctar_empque");
            entity.Property(e => e.PrSstnciaCntrlda).HasColumnName("pr_sstncia_cntrlda");
        });

        modelBuilder.Entity<PuertoOrigen>(entity =>
        {
            entity.HasKey(e => e.PoCdgo);

            entity.ToTable("puerto_origen");

            entity.Property(e => e.PoCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("po_cdgo");
            entity.Property(e => e.PoActvo).HasColumnName("po_actvo");
            entity.Property(e => e.PoDscrpcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("po_dscrpcion");
        });

        modelBuilder.Entity<Responsable>(entity =>
        {
            entity.HasKey(e => e.ReRowid);

            entity.ToTable("responsable");

            entity.Property(e => e.ReRowid).HasColumnName("re_rowid");
            entity.Property(e => e.ReActvo).HasColumnName("re_actvo");
            entity.Property(e => e.ReCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("re_cdgo_usrio");
            entity.Property(e => e.ReDscrpcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("re_dscrpcion");
            entity.Property(e => e.ReFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("re_fcha_crcion");
            entity.Property(e => e.ReNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("re_nmbre");

            entity.HasOne(d => d.ReCdgoUsrioNavigation).WithMany(p => p.Responsables).HasForeignKey(d => d.ReCdgoUsrio);
        });

        modelBuilder.Entity<RutaAccione>(entity =>
        {
            entity.HasKey(e => e.RaRowid);

            entity.ToTable("ruta_acciones");

            entity.Property(e => e.RaRowid).HasColumnName("ra_rowid");
            entity.Property(e => e.RaAccnes)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("ra_accnes");
            entity.Property(e => e.RaRowidRta).HasColumnName("ra_rowid_rta");

            entity.HasOne(d => d.RaRowidRtaNavigation).WithMany(p => p.RutaAcciones)
                .HasForeignKey(d => d.RaRowidRta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ruta_acciones_ruta_rowid");
        });

        modelBuilder.Entity<Rutum>(entity =>
        {
            entity.HasKey(e => e.RuRowid);

            entity.ToTable("ruta");

            entity.Property(e => e.RuRowid).HasColumnName("ru_rowid");
            entity.Property(e => e.RuNmbre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("ru_nmbre");
            entity.Property(e => e.RuTpo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ru_tpo");
        });

        modelBuilder.Entity<Sector>(entity =>
        {
            entity.HasKey(e => e.SeRowid);

            entity.ToTable("sector");

            entity.Property(e => e.SeRowid).HasColumnName("se_rowid");
            entity.Property(e => e.SeCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("se_cdgo");
            entity.Property(e => e.SeNmbre)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("se_nmbre");
        });

        modelBuilder.Entity<SectorEvento>(entity =>
        {
            entity.HasKey(e => new { e.SeRowidSctor, e.SeRowidEvnto });

            entity.ToTable("sector_evento");

            entity.Property(e => e.SeRowidSctor).HasColumnName("se_rowid_sctor");
            entity.Property(e => e.SeRowidEvnto).HasColumnName("se_rowid_evnto");
            entity.Property(e => e.SeRowid)
                .ValueGeneratedOnAdd()
                .HasColumnName("se_rowid");
        });

        modelBuilder.Entity<Sede>(entity =>
        {
            entity.HasKey(e => e.SeRowid);

            entity.ToTable("sede");

            entity.HasIndex(e => new { e.SeCdgoCia, e.SeNmbre }, "IX_sede").IsUnique();

            entity.HasIndex(e => e.SeCdgoCia, "idx_sede_se_cdgo_cia");

            entity.Property(e => e.SeRowid).HasColumnName("se_rowid");
            entity.Property(e => e.SeActvo).HasColumnName("se_actvo");
            entity.Property(e => e.SeCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("se_cdgo");
            entity.Property(e => e.SeCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("se_cdgo_cia");
            entity.Property(e => e.SeCdgoDpstoAdnro)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("se_cdgo_dpsto_adnro");
            entity.Property(e => e.SeDpstoAdnro).HasColumnName("se_dpsto_adnro");
            entity.Property(e => e.SeNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("se_nmbre");

            entity.HasOne(d => d.SeCdgoCiaNavigation).WithMany(p => p.Sedes)
                .HasForeignKey(d => d.SeCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sede_compania_cia_cdgo");
        });

        modelBuilder.Entity<SituacionPortuariaDetalle>(entity =>
        {
            entity.HasKey(e => e.SpdRowid).HasName("PK__situacio__E45866D0D4C8B0CA");

            entity.ToTable("situacion_portuaria_detalle");

            entity.Property(e => e.SpdRowid).HasColumnName("spd_rowid");
            entity.Property(e => e.SdpCdgoPrdcto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sdp_cdgo_prdcto");
            entity.Property(e => e.SdpTmBl).HasColumnName("sdp_tm_bl");
            entity.Property(e => e.SpdCdgoUndadMdda)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("spd_cdgo_undad_mdda");
            entity.Property(e => e.SpdCntdad).HasColumnName("spd_cntdad");
            entity.Property(e => e.SpdEsctlla).HasColumnName("spd_esctlla");
            entity.Property(e => e.SpdRowidOprdorPrtrio).HasColumnName("spd_rowid_oprdor_prtrio");
            entity.Property(e => e.SpdRowidStcionPrtria).HasColumnName("spd_rowid_stcion_prtria");
            entity.Property(e => e.SpdRowidTrcro).HasColumnName("spd_rowid_trcro");

            entity.HasOne(d => d.SdpCdgoPrdctoNavigation).WithMany(p => p.SituacionPortuariaDetalles)
                .HasForeignKey(d => d.SdpCdgoPrdcto)
                .HasConstraintName("FK_situacion_portuaria_detalle_producto_pr_cdgo");

            entity.HasOne(d => d.SpdCdgoUndadMddaNavigation).WithMany(p => p.SituacionPortuariaDetalles)
                .HasForeignKey(d => d.SpdCdgoUndadMdda)
                .HasConstraintName("FK_situacion_portuaria_detalle_unidad_medida_um_cdgo");

            entity.HasOne(d => d.SpdRowidOprdorPrtrioNavigation).WithMany(p => p.SituacionPortuariaDetalleSpdRowidOprdorPrtrioNavigations)
                .HasForeignKey(d => d.SpdRowidOprdorPrtrio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_situacion_portuaria_detalle_tercero_te_rowid_oprdor_prtrio");

            entity.HasOne(d => d.SpdRowidStcionPrtriaNavigation).WithMany(p => p.SituacionPortuariaDetalles)
                .HasForeignKey(d => d.SpdRowidStcionPrtria)
                .HasConstraintName("FK_situacion_portuaria_detalle_situacion_portuaria_sp_rowid");

            entity.HasOne(d => d.SpdRowidTrcroNavigation).WithMany(p => p.SituacionPortuariaDetalleSpdRowidTrcroNavigations)
                .HasForeignKey(d => d.SpdRowidTrcro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_situacion_portuaria_detalle_tercero_te_rowid");
        });

        modelBuilder.Entity<SituacionPortuarium>(entity =>
        {
            entity.HasKey(e => e.SpRowid).HasName("PK__situacio__FCDEE058EC3B2C5E");

            entity.ToTable("situacion_portuaria");

            entity.Property(e => e.SpRowid).HasColumnName("sp_rowid");
            entity.Property(e => e.SpCdgoEstdoMtnve)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_estdo_mtnve");
            entity.Property(e => e.SpCdgoMtnve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_mtnve");
            entity.Property(e => e.SpCdgoPais)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_pais");
            entity.Property(e => e.SpCdgoTrmnalMrtmo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_trmnal_mrtmo");
            entity.Property(e => e.SpCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_usrio_crea");
            entity.Property(e => e.SpFchaArrbo)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_arrbo");
            entity.Property(e => e.SpFchaAtrque)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_atrque");
            entity.Property(e => e.SpFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_crcion");
            entity.Property(e => e.SpFchaZrpe)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_zrpe");
            entity.Property(e => e.SpRowidAgnteNvro).HasColumnName("sp_rowid_agnte_nvro");
            entity.Property(e => e.SpRowidZnaCd).HasColumnName("sp_rowid_zna_cd");

            entity.HasOne(d => d.SpCdgoEstdoMtnveNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpCdgoEstdoMtnve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_situacion_portuaria_estado_motonave_em_cdgo");

            entity.HasOne(d => d.SpCdgoMtnveNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpCdgoMtnve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_situacion_portuaria_motonave_mo_cdgo");

            entity.HasOne(d => d.SpCdgoPaisNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpCdgoPais)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_situacion_portuaria_pais_pa_cdgo");

            entity.HasOne(d => d.SpCdgoTrmnalMrtmoNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpCdgoTrmnalMrtmo)
                .HasConstraintName("FK_situacion_portuaria_terminal_maritimo_tm_cdgo");

            entity.HasOne(d => d.SpCdgoUsrioCreaNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpCdgoUsrioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_situacion_portuaria_usuario_us_cdgo_usrio_crea");

            entity.HasOne(d => d.SpRowidAgnteNvroNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpRowidAgnteNvro)
                .HasConstraintName("FK_situacion_portuaria_tercero_te_rowid_agnte_nvro");

            entity.HasOne(d => d.SpRowidZnaCdNavigation).WithMany(p => p.SituacionPortuaria)
                .HasForeignKey(d => d.SpRowidZnaCd)
                .HasConstraintName("FK_situacion_portuaria_zona_cd_zcd_rowid");
        });

        modelBuilder.Entity<SolicitudRetiro>(entity =>
        {
            entity.HasKey(e => e.SrRowid);

            entity.ToTable("solicitud_retiro");

            entity.Property(e => e.SrRowid).HasColumnName("sr_rowid");
            entity.Property(e => e.SrAbrta).HasColumnName("sr_abrta");
            entity.Property(e => e.SrActva).HasColumnName("sr_actva");
            entity.Property(e => e.SrAutrzdoCntdad).HasColumnName("sr_autrzdo_cntdad");
            entity.Property(e => e.SrAutrzdoKlos).HasColumnName("sr_autrzdo_klos");
            entity.Property(e => e.SrCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sr_cdgo");
            entity.Property(e => e.SrCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sr_cia");
            entity.Property(e => e.SrCmpoPrsnlzdo1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sr_cmpo_prsnlzdo1");
            entity.Property(e => e.SrCmpoPrsnlzdo2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sr_cmpo_prsnlzdo2");
            entity.Property(e => e.SrCmpoPrsnlzdo3)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sr_cmpo_prsnlzdo3");
            entity.Property(e => e.SrDspchdoCntdad).HasColumnName("sr_dspchdo_cntdad");
            entity.Property(e => e.SrDspchdoKlos).HasColumnName("sr_dspchdo_klos");
            entity.Property(e => e.SrEntrgaSspndda).HasColumnName("sr_entrga_sspndda");
            entity.Property(e => e.SrEntrgarPsoExcto).HasColumnName("sr_entrgar_pso_excto");
            entity.Property(e => e.SrFchaAprtra)
                .HasColumnType("smalldatetime")
                .HasColumnName("sr_fcha_aprtra");
            entity.Property(e => e.SrObsrvcnes)
                .IsUnicode(false)
                .HasColumnName("sr_obsrvcnes");
            entity.Property(e => e.SrPlntaDstno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sr_plnta_dstno");
            entity.Property(e => e.SrRowidCdad).HasColumnName("sr_rowid_cdad");
            entity.Property(e => e.SrRowidDpsto).HasColumnName("sr_rowid_dpsto");
            entity.Property(e => e.SrRowidZnaCd).HasColumnName("sr_rowid_zna_cd");

            entity.HasOne(d => d.SrRowidCdadNavigation).WithMany(p => p.SolicitudRetiros)
                .HasForeignKey(d => d.SrRowidCdad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_ciudad");

            entity.HasOne(d => d.SrRowidDpstoNavigation).WithMany(p => p.SolicitudRetiros)
                .HasForeignKey(d => d.SrRowidDpsto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_deposito");
        });

        modelBuilder.Entity<SolicitudRetiroAutorizacion>(entity =>
        {
            entity.HasKey(e => e.SraRowid);

            entity.ToTable("solicitud_retiro_autorizacion");

            entity.Property(e => e.SraRowid).HasColumnName("sra_rowid");
            entity.Property(e => e.SraAutrzdoKlos).HasColumnName("sra_autrzdo_klos");
            entity.Property(e => e.SraAutrzdoUnddes).HasColumnName("sra_autrzdo_unddes");
            entity.Property(e => e.SraCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sra_cdgo_usrio");
            entity.Property(e => e.SraFcha)
                .HasColumnType("smalldatetime")
                .HasColumnName("sra_fcha");
            entity.Property(e => e.SraRowidSlctudRtro).HasColumnName("sra_rowid_slctud_rtro");
            entity.Property(e => e.SraRowidTrnsprtdra).HasColumnName("sra_rowid_trnsprtdra");

            entity.HasOne(d => d.SraCdgoUsrioNavigation).WithMany(p => p.SolicitudRetiroAutorizacions)
                .HasForeignKey(d => d.SraCdgoUsrio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_autorizacion_usuario");

            entity.HasOne(d => d.SraRowidSlctudRtroNavigation).WithMany(p => p.SolicitudRetiroAutorizacions)
                .HasForeignKey(d => d.SraRowidSlctudRtro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_autorizacion_solicitud_retiro");

            entity.HasOne(d => d.SraRowidTrnsprtdraNavigation).WithMany(p => p.SolicitudRetiroAutorizacions)
                .HasForeignKey(d => d.SraRowidTrnsprtdra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_autorizacion_transportadora");
        });

        modelBuilder.Entity<SolicitudRetiroAutorizacionHistorial>(entity =>
        {
            entity.HasKey(e => e.SrahRowid);

            entity.ToTable("solicitud_retiro_autorizacion_historial");

            entity.Property(e => e.SrahRowid).HasColumnName("srah_rowid");
            entity.Property(e => e.SraCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sra_cdgo_usrio");
            entity.Property(e => e.SrahAutrzdoKlos).HasColumnName("srah_autrzdo_klos");
            entity.Property(e => e.SrahAutrzdoUnddes).HasColumnName("srah_autrzdo_unddes");
            entity.Property(e => e.SrahFcha)
                .HasColumnType("smalldatetime")
                .HasColumnName("srah_fcha");
            entity.Property(e => e.SrahRowidSlctudRtroAutrzcion).HasColumnName("srah_rowid_slctud_rtro_autrzcion");

            entity.HasOne(d => d.SrahRowidSlctudRtroAutrzcionNavigation).WithMany(p => p.SolicitudRetiroAutorizacionHistorials)
                .HasForeignKey(d => d.SrahRowidSlctudRtroAutrzcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_autorizacion_historial_solicitud_retiro_autorizacion");
        });

        modelBuilder.Entity<SolicitudRetiroTransportadora>(entity =>
        {
            entity.HasKey(e => e.SrtRowid);

            entity.ToTable("solicitud_retiro_transportadora");

            entity.Property(e => e.SrtRowid).HasColumnName("srt_rowid");
            entity.Property(e => e.SrtActva).HasColumnName("srt_actva");
            entity.Property(e => e.SrtAutrzdoKlos).HasColumnName("srt_autrzdo_klos");
            entity.Property(e => e.SrtAutrzdoUnddes).HasColumnName("srt_autrzdo_unddes");
            entity.Property(e => e.SrtDspchdoKlos).HasColumnName("srt_dspchdo_klos");
            entity.Property(e => e.SrtDspchdoUnddes).HasColumnName("srt_dspchdo_unddes");
            entity.Property(e => e.SrtRowidSlctudRtro).HasColumnName("srt_rowid_slctud_rtro");
            entity.Property(e => e.SrtRowidTrnsprtdra).HasColumnName("srt_rowid_trnsprtdra");

            entity.HasOne(d => d.SrtRowidSlctudRtroNavigation).WithMany(p => p.SolicitudRetiroTransportadoras)
                .HasForeignKey(d => d.SrtRowidSlctudRtro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_transportadora_solicitud_retiro");

            entity.HasOne(d => d.SrtRowidTrnsprtdraNavigation).WithMany(p => p.SolicitudRetiroTransportadoras)
                .HasForeignKey(d => d.SrtRowidTrnsprtdra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_transportadora_transportadora");
        });

        modelBuilder.Entity<SolicitudRetiroTransportadoraHistorial>(entity =>
        {
            entity.HasKey(e => e.SrthRowid);

            entity.ToTable("solicitud_retiro_transportadora_historial");

            entity.Property(e => e.SrthRowid).HasColumnName("srth_rowid");
            entity.Property(e => e.SrthAutrzdoKlos).HasColumnName("srth_autrzdo_klos");
            entity.Property(e => e.SrthAutrzdoUnddes).HasColumnName("srth_autrzdo_unddes");
            entity.Property(e => e.SrthFcha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("srth_fcha");
            entity.Property(e => e.SrthRowidSlctudRtroTrnsprtdra).HasColumnName("srth_rowid_slctud_rtro_trnsprtdra");

            entity.HasOne(d => d.SrthRowidSlctudRtroTrnsprtdraNavigation).WithMany(p => p.SolicitudRetiroTransportadoraHistorials)
                .HasForeignKey(d => d.SrthRowidSlctudRtroTrnsprtdra)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_solicitud_retiro_transportadora_historial_solicitud_retiro_transportadora");
        });

        modelBuilder.Entity<Tercero>(entity =>
        {
            entity.HasKey(e => e.TeRowid);

            entity.ToTable("tercero");

            entity.HasIndex(e => new { e.TeCdgoCia, e.TeCdgo }, "IX_tercero").IsUnique();

            entity.HasIndex(e => e.TeActvo, "idx_tercero_te_actvo");

            entity.HasIndex(e => e.TeAgnteMrtmo, "idx_tercero_te_agnte_mrtmo");

            entity.HasIndex(e => e.TeCdgoGrpoTrcro, "idx_tercero_te_cdgo_grpo_trcro");

            entity.HasIndex(e => e.TeClnte, "idx_tercero_te_clnte");

            entity.HasIndex(e => e.TeFncnrio, "idx_tercero_te_fncnrio");

            entity.HasIndex(e => e.TeNmbre, "idx_tercero_te_nmbre");

            entity.HasIndex(e => e.TeOprdorPrtrio, "idx_tercero_te_oprdor_prtrio");

            entity.HasIndex(e => e.TePrtclar, "idx_tercero_te_prtclar");

            entity.HasIndex(e => e.TeTrnsprtdra, "idx_tercero_te_trnsprtdra");

            entity.HasIndex(e => e.TeVnddor, "idx_tercero_te_vnddor");

            entity.Property(e => e.TeRowid).HasColumnName("te_rowid");
            entity.Property(e => e.TeActvo).HasColumnName("te_actvo");
            entity.Property(e => e.TeAgnciaAdna).HasColumnName("te_agncia_adna");
            entity.Property(e => e.TeAgnteMrtmo).HasColumnName("te_agnte_mrtmo");
            entity.Property(e => e.TeCdgo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("te_cdgo");
            entity.Property(e => e.TeCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("te_cdgo_cia");
            entity.Property(e => e.TeCdgoGrpoTrcro)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("te_cdgo_grpo_trcro");
            entity.Property(e => e.TeClnte).HasColumnName("te_clnte");
            entity.Property(e => e.TeDrccion)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("te_drccion");
            entity.Property(e => e.TeDv)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("te_dv");
            entity.Property(e => e.TeEmail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("te_email");
            entity.Property(e => e.TeFncnrio).HasColumnName("te_fncnrio");
            entity.Property(e => e.TeIdntfccion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("te_idntfccion");
            entity.Property(e => e.TeMnjoPrpio).HasColumnName("te_mnjo_prpio");
            entity.Property(e => e.TeNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("te_nmbre");
            entity.Property(e => e.TeNmbreCntcto)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("te_nmbre_cntcto");
            entity.Property(e => e.TeOprdorPrtrio).HasColumnName("te_oprdor_prtrio");
            entity.Property(e => e.TeOprdorScndrio).HasColumnName("te_oprdor_scndrio");
            entity.Property(e => e.TePrtclar).HasColumnName("te_prtclar");
            entity.Property(e => e.TeTlfno)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("te_tlfno");
            entity.Property(e => e.TeTpoIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("te_tpo_idntfccion");
            entity.Property(e => e.TeTrnsprtdra).HasColumnName("te_trnsprtdra");
            entity.Property(e => e.TeVnddor).HasColumnName("te_vnddor");

            entity.HasOne(d => d.TeCdgoCiaNavigation).WithMany(p => p.Terceros)
                .HasForeignKey(d => d.TeCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tercero_compania_cia_cdgo");

            entity.HasOne(d => d.TeCdgoGrpoTrcroNavigation).WithMany(p => p.Terceros)
                .HasForeignKey(d => d.TeCdgoGrpoTrcro)
                .HasConstraintName("FK_tercero_grupo_tercero_gt_cdgo");

            entity.HasOne(d => d.TeTpoIdntfccionNavigation).WithMany(p => p.Terceros)
                .HasForeignKey(d => d.TeTpoIdntfccion)
                .HasConstraintName("FK_tercero_tipo_identificacion_ti_cdgo");
        });

        modelBuilder.Entity<TerceroCertificado>(entity =>
        {
            entity.HasKey(e => e.TcRowid);

            entity.ToTable("tercero_certificado");

            entity.Property(e => e.TcRowid).HasColumnName("tc_rowid");
            entity.Property(e => e.TcAprbdo).HasColumnName("tc_aprbdo");
            entity.Property(e => e.TcCdgo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tc_cdgo");
            entity.Property(e => e.TcCdgoPrdcto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tc_cdgo_prdcto");
            entity.Property(e => e.TcCdgoUsrioAprbdo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tc_cdgo_usrio_aprbdo");
            entity.Property(e => e.TcCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tc_cia");
            entity.Property(e => e.TcFchaAprbcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("tc_fcha_aprbcion");
            entity.Property(e => e.TcFchaCrgue)
                .HasColumnType("smalldatetime")
                .HasColumnName("tc_fcha_crgue");
            entity.Property(e => e.TcFchaIncio)
                .HasColumnType("smalldatetime")
                .HasColumnName("tc_fcha_incio");
            entity.Property(e => e.TcFchaVncmnto)
                .HasColumnType("smalldatetime")
                .HasColumnName("tc_fcha_vncmnto");
            entity.Property(e => e.TcRowidTrcro).HasColumnName("tc_rowid_trcro");

            entity.HasOne(d => d.TcCdgoPrdctoNavigation).WithMany(p => p.TerceroCertificados)
                .HasForeignKey(d => d.TcCdgoPrdcto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tercero_certificado_producto_pr_cdgo");

            entity.HasOne(d => d.TcCdgoUsrioAprbdoNavigation).WithMany(p => p.TerceroCertificados)
                .HasForeignKey(d => d.TcCdgoUsrioAprbdo)
                .HasConstraintName("FK_tercero_certificado_usuario_us_cdgo_aprbdo");

            entity.HasOne(d => d.TcCiaNavigation).WithMany(p => p.TerceroCertificados)
                .HasForeignKey(d => d.TcCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tercero_certificado_compania_cia_cdgo");

            entity.HasOne(d => d.TcRowidTrcroNavigation).WithMany(p => p.TerceroCertificados)
                .HasForeignKey(d => d.TcRowidTrcro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tercero_certificado_tercero_te_rowid");
        });

        modelBuilder.Entity<TerminalMaritimo>(entity =>
        {
            entity.HasKey(e => e.TmCdgo);

            entity.ToTable("terminal_maritimo");

            entity.HasIndex(e => e.TmDscrpcion, "IX_terminal_maritimo").IsUnique();

            entity.Property(e => e.TmCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tm_cdgo");
            entity.Property(e => e.TmActvo).HasColumnName("tm_actvo");
            entity.Property(e => e.TmDscrpcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("tm_dscrpcion");
        });

        modelBuilder.Entity<TipoConcepto>(entity =>
        {
            entity.HasKey(e => e.TcCdgo);

            entity.ToTable("tipo_concepto");

            entity.Property(e => e.TcCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tc_cdgo");
            entity.Property(e => e.TcNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("tc_nmbre");
            entity.Property(e => e.TcNtrlza)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("tc_ntrlza");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.TdCdgo).HasName("PK_tpo_dcmnto");

            entity.ToTable("tipo_documento");

            entity.Property(e => e.TdCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("td_cdgo");
            entity.Property(e => e.TdActvo).HasColumnName("td_actvo");
            entity.Property(e => e.TdNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("td_nmbre");
            entity.Property(e => e.TdNmbreAAsgnar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("td_nmbre_a_asgnar");
            entity.Property(e => e.TdOblgtrio).HasColumnName("td_oblgtrio");
            entity.Property(e => e.TdOrgen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("td_orgen");
        });

        modelBuilder.Entity<TipoIdentificacion>(entity =>
        {
            entity.HasKey(e => e.TiCdgo).HasName("PK_tpo_idntfccion");

            entity.ToTable("tipo_identificacion");

            entity.Property(e => e.TiCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ti_cdgo");
            entity.Property(e => e.TiNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ti_nmbre");
        });

        modelBuilder.Entity<UnidadMedidum>(entity =>
        {
            entity.HasKey(e => e.UmCdgo).HasName("PK__unidad_m__EB30414BA3461D11");

            entity.ToTable("unidad_medida");

            entity.Property(e => e.UmCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("um_cdgo");
            entity.Property(e => e.UmActvo).HasColumnName("um_actvo");
            entity.Property(e => e.UmGrnel).HasColumnName("um_grnel");
            entity.Property(e => e.UmNmbre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("um_nmbre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsCdgo).IsClustered(false);

            entity.ToTable("usuario");

            entity.Property(e => e.UsCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("us_cdgo");
            entity.Property(e => e.Us2fa).HasColumnName("us_2fa");
            entity.Property(e => e.UsActvo).HasColumnName("us_actvo");
            entity.Property(e => e.UsBlqdo)
                .HasDefaultValue(false)
                .HasColumnName("us_blqdo");
            entity.Property(e => e.UsCdgo2fa)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("us_cdgo_2fa");
            entity.Property(e => e.UsClve1)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("us_clve1");
            entity.Property(e => e.UsClve2)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("us_clve2");
            entity.Property(e => e.UsClve3)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("us_clve3");
            entity.Property(e => e.UsClve4)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("us_clve4");
            entity.Property(e => e.UsClve5)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("us_clve5");
            entity.Property(e => e.UsDbeCmbiarClve)
                .HasDefaultValue(false)
                .HasColumnName("us_dbe_cmbiar_clve");
            entity.Property(e => e.UsEmail)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("us_email");
            entity.Property(e => e.UsFchaUltmaClve)
                .HasColumnType("smalldatetime")
                .HasColumnName("us_fcha_ultma_clve");
            entity.Property(e => e.UsFchaUltmoIngso)
                .HasColumnType("smalldatetime")
                .HasColumnName("us_fcha_ultmo_ingso");
            entity.Property(e => e.UsIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("us_idntfccion");
            entity.Property(e => e.UsIncles)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("us_incles");
            entity.Property(e => e.UsNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("us_nmbre");
            entity.Property(e => e.UsNmroIntntos)
                .HasDefaultValue((short)0)
                .HasColumnName("us_nmro_intntos");
            entity.Property(e => e.UsRowidTrcro).HasColumnName("us_rowid_trcro");
            entity.Property(e => e.UsSper).HasColumnName("us_sper");
            entity.Property(e => e.UsSperVldcion)
                .HasMaxLength(32)
                .IsUnicode(false)
                .HasColumnName("us_sper_vldcion");

            entity.HasOne(d => d.UsRowidTrcroNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.UsRowidTrcro)
                .HasConstraintName("FK_usuario_tercero_te_rowid");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.VeMtrcla);

            entity.ToTable("vehiculo");

            entity.HasIndex(e => e.VeCdgoUsrioCrea, "idx_vehiculo_ve_cdgo_usrio_crea");

            entity.Property(e => e.VeMtrcla)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ve_mtrcla");
            entity.Property(e => e.VeCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("ve_cdgo_usrio_crea");
            entity.Property(e => e.VeFchaRgstro)
                .HasColumnType("smalldatetime")
                .HasColumnName("ve_fcha_rgstro");
            entity.Property(e => e.VeFchaRvsion)
                .HasColumnType("smalldatetime")
                .HasColumnName("ve_fcha_rvsion");
            entity.Property(e => e.VeFchaSgro)
                .HasColumnType("smalldatetime")
                .HasColumnName("ve_fcha_sgro");
            entity.Property(e => e.VeMdlo).HasColumnName("ve_mdlo");
            entity.Property(e => e.VeRowidCnfgrcionVhclar).HasColumnName("ve_rowid_cnfgrcion_vhclar");

            entity.HasOne(d => d.VeCdgoUsrioCreaNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.VeCdgoUsrioCrea)
                .HasConstraintName("FK_vehiculo_usuario_us_cdgo_crea");

            entity.HasOne(d => d.VeRowidCnfgrcionVhclarNavigation).WithMany(p => p.Vehiculos)
                .HasForeignKey(d => d.VeRowidCnfgrcionVhclar)
                .HasConstraintName("FK_vehiculo_configuracion_vehicular_cv_rowid");
        });

        modelBuilder.Entity<VisitaMotonave>(entity =>
        {
            entity.HasKey(e => e.VmRowid);

            entity.ToTable("visita_motonave");

            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
            entity.Property(e => e.VmCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_cia");
            entity.Property(e => e.VmCdgoMtnve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_mtnve");
            entity.Property(e => e.VmCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_usrio_crea");
            entity.Property(e => e.VmDscrpcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("vm_dscrpcion");
            entity.Property(e => e.VmFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_crcion");
            entity.Property(e => e.VmFchaFinOprcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_fin_oprcion");
            entity.Property(e => e.VmFchaFndeo)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_fndeo");
            entity.Property(e => e.VmFchaIncioOprcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_incio_oprcion");
            entity.Property(e => e.VmRowidStcionPrtria).HasColumnName("vm_rowid_stcion_prtria");
            entity.Property(e => e.VmRowidVnddor).HasColumnName("vm_rowid_vnddor");
            entity.Property(e => e.VmRowidZnaCdAltrno).HasColumnName("vm_rowid_zna_cd_altrno");
            entity.Property(e => e.VmRowidsPrstdresSrvcios)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("vm_rowids_prstdres_srvcios");
            entity.Property(e => e.VmScncia).HasColumnName("vm_scncia");

            entity.HasOne(d => d.VmCdgoCiaNavigation).WithMany(p => p.VisitaMotonaves)
                .HasForeignKey(d => d.VmCdgoCia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_compania_cia_cdgo");

            entity.HasOne(d => d.VmCdgoMtnveNavigation).WithMany(p => p.VisitaMotonaves)
                .HasForeignKey(d => d.VmCdgoMtnve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_motonave_mo_cdgo");

            entity.HasOne(d => d.VmCdgoUsrioCreaNavigation).WithMany(p => p.VisitaMotonaves)
                .HasForeignKey(d => d.VmCdgoUsrioCrea)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_usuario_us_cdgo_usrio_crea");

            entity.HasOne(d => d.VmRowidStcionPrtriaNavigation).WithMany(p => p.VisitaMotonaves)
                .HasForeignKey(d => d.VmRowidStcionPrtria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_situacion_portuaria_sp_rowid");

            entity.HasOne(d => d.VmRowidVnddorNavigation).WithMany(p => p.VisitaMotonaves)
                .HasForeignKey(d => d.VmRowidVnddor)
                .HasConstraintName("FK_visita_motonave_tercero_te_rowid_vnddor");

            entity.HasOne(d => d.VmRowidZnaCdAltrnoNavigation).WithMany(p => p.VisitaMotonaves)
                .HasForeignKey(d => d.VmRowidZnaCdAltrno)
                .HasConstraintName("FK_visita_motonave_zona_cd_zcd_rowid_altrno");
        });

        modelBuilder.Entity<VisitaMotonaveBl>(entity =>
        {
            entity.HasKey(e => e.VmblRowid);

            entity.ToTable("visita_motonave_bl");

            entity.Property(e => e.VmblRowid).HasColumnName("vmbl_rowid");
            entity.Property(e => e.VmblCdgoUndadMdda)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmbl_cdgo_undad_mdda");
            entity.Property(e => e.VmblCdgoUsrioAprbdo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmbl_cdgo_usrio_aprbdo");
            entity.Property(e => e.VmblCdgoUsrioCrgue)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmbl_cdgo_usrio_crgue");
            entity.Property(e => e.VmblCmntriosRchzo)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("vmbl_cmntrios_rchzo");
            entity.Property(e => e.VmblCntdad).HasColumnName("vmbl_cntdad");
            entity.Property(e => e.VmblEsctlla).HasColumnName("vmbl_esctlla");
            entity.Property(e => e.VmblEstdo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("vmbl_estdo");
            entity.Property(e => e.VmblFchaAprbcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vmbl_fcha_aprbcion");
            entity.Property(e => e.VmblFchaCrgue)
                .HasColumnType("smalldatetime")
                .HasColumnName("vmbl_fcha_crgue");
            entity.Property(e => e.VmblKlosCmprmsoAlmcnar).HasColumnName("vmbl_klos_cmprmso_almcnar");
            entity.Property(e => e.VmblKlosCmprmsoDrcto).HasColumnName("vmbl_klos_cmprmso_drcto");
            entity.Property(e => e.VmblNmro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vmbl_nmro");
            entity.Property(e => e.VmblRowidStcionPrtriaDtlle).HasColumnName("vmbl_rowid_stcion_prtria_dtlle");
            entity.Property(e => e.VmblRowidVstaMtnveDtlle).HasColumnName("vmbl_rowid_vsta_mtnve_dtlle");
            entity.Property(e => e.VmblRowidsSdes)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("vmbl_rowids_sdes");
            entity.Property(e => e.VmblRqstoClnte)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("vmbl_rqsto_clnte");
            entity.Property(e => e.VmblRta)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("vmbl_rta");
            entity.Property(e => e.VmblTnldasMtrcas).HasColumnName("vmbl_tnldas_mtrcas");

            entity.HasOne(d => d.VmblCdgoUndadMddaNavigation).WithMany(p => p.VisitaMotonaveBls)
                .HasForeignKey(d => d.VmblCdgoUndadMdda)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_bl_unidad_medida_um_cdgo");

            entity.HasOne(d => d.VmblCdgoUsrioAprbdoNavigation).WithMany(p => p.VisitaMotonaveBlVmblCdgoUsrioAprbdoNavigations)
                .HasForeignKey(d => d.VmblCdgoUsrioAprbdo)
                .HasConstraintName("FK_visita_motonave_bl_usuario_us_cdgo_usrio_aprbdo");

            entity.HasOne(d => d.VmblCdgoUsrioCrgueNavigation).WithMany(p => p.VisitaMotonaveBlVmblCdgoUsrioCrgueNavigations)
                .HasForeignKey(d => d.VmblCdgoUsrioCrgue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_bl_usuario_us_cdgo_usrio_crgue");

            entity.HasOne(d => d.VmblRowidStcionPrtriaDtlleNavigation).WithMany(p => p.VisitaMotonaveBls)
                .HasForeignKey(d => d.VmblRowidStcionPrtriaDtlle)
                .HasConstraintName("FK_visita_motonave_bl_situacion_portuaria_detalle_spd_rowid");

            entity.HasOne(d => d.VmblRowidVstaMtnveDtlleNavigation).WithMany(p => p.VisitaMotonaveBls)
                .HasForeignKey(d => d.VmblRowidVstaMtnveDtlle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_bl_visita_motonave_detalle_vmd_rowid");
        });

        modelBuilder.Entity<VisitaMotonaveBl1>(entity =>
        {
            entity.HasKey(e => e.Vmbl1Rowid);

            entity.ToTable("visita_motonave_bl1");

            entity.Property(e => e.Vmbl1Rowid).HasColumnName("vmbl1_rowid");
            entity.Property(e => e.Vmbl1Lnea).HasColumnName("vmbl1_lnea");
            entity.Property(e => e.Vmbl1NmroLvnte)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vmbl1_nmro_lvnte");
            entity.Property(e => e.Vmbl1RowidVstaMtnveBl).HasColumnName("vmbl1_rowid_vsta_mtnve_bl");

            entity.HasOne(d => d.Vmbl1RowidVstaMtnveBlNavigation).WithMany(p => p.VisitaMotonaveBl1s)
                .HasForeignKey(d => d.Vmbl1RowidVstaMtnveBl)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_bl1_visita_motonave_bl_vmbl_rowid");
        });

        modelBuilder.Entity<VisitaMotonaveComentario>(entity =>
        {
            entity.HasKey(e => e.VmcRowid);

            entity.ToTable("visita_motonave_comentario");

            entity.Property(e => e.VmcRowid).HasColumnName("vmc_rowid");
            entity.Property(e => e.VmcCdgoUsrio)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmc_cdgo_usrio");
            entity.Property(e => e.VmcCmntrios)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("vmc_cmntrios");
            entity.Property(e => e.VmcFcha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("smalldatetime")
                .HasColumnName("vmc_fcha");
            entity.Property(e => e.VmcRowidVstaMtnve).HasColumnName("vmc_rowid_vsta_mtnve");
            entity.Property(e => e.VmcRowidVstaMtnveBl).HasColumnName("vmc_rowid_vsta_mtnve_bl");
            entity.Property(e => e.VmcTtlo)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("vmc_ttlo");

            entity.HasOne(d => d.VmcCdgoUsrioNavigation).WithMany(p => p.VisitaMotonaveComentarios)
                .HasForeignKey(d => d.VmcCdgoUsrio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_comentario_usuario_us_cdgo");

            entity.HasOne(d => d.VmcRowidVstaMtnveNavigation).WithMany(p => p.VisitaMotonaveComentarios)
                .HasForeignKey(d => d.VmcRowidVstaMtnve)
                .HasConstraintName("FK_visita_motonave_comentario_visita_motonave_vm_rowid");

            entity.HasOne(d => d.VmcRowidVstaMtnveBlNavigation).WithMany(p => p.VisitaMotonaveComentarios)
                .HasForeignKey(d => d.VmcRowidVstaMtnveBl)
                .HasConstraintName("FK_visita_motonave_comentario_visita_motonave_bl_vmbl_rowid");
        });

        modelBuilder.Entity<VisitaMotonaveDetalle>(entity =>
        {
            entity.HasKey(e => e.VmdRowid);

            entity.ToTable("visita_motonave_detalle");

            entity.Property(e => e.VmdRowid).HasColumnName("vmd_rowid");
            entity.Property(e => e.VmdActvo).HasColumnName("vmd_actvo");
            entity.Property(e => e.VmdRowidAgnciaAdna).HasColumnName("vmd_rowid_agncia_adna");
            entity.Property(e => e.VmdRowidStcionPrtriaDtlle).HasColumnName("vmd_rowid_stcion_prtria_dtlle");
            entity.Property(e => e.VmdRowidVstaMtnve).HasColumnName("vmd_rowid_vsta_mtnve");

            entity.HasOne(d => d.VmdRowidAgnciaAdnaNavigation).WithMany(p => p.VisitaMotonaveDetalles)
                .HasForeignKey(d => d.VmdRowidAgnciaAdna)
                .HasConstraintName("FK_visita_motonave_detalle_tercero_te_rowid_agncia_adna");

            entity.HasOne(d => d.VmdRowidStcionPrtriaDtlleNavigation).WithMany(p => p.VisitaMotonaveDetalles)
                .HasForeignKey(d => d.VmdRowidStcionPrtriaDtlle)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_detalle_situacion_portuaria_detalle_spd_rowid");

            entity.HasOne(d => d.VmdRowidVstaMtnveNavigation).WithMany(p => p.VisitaMotonaveDetalles)
                .HasForeignKey(d => d.VmdRowidVstaMtnve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_detalle_visita_motonave_vm_rowid");
        });

        modelBuilder.Entity<VisitaMotonaveDocumento>(entity =>
        {
            entity.HasKey(e => e.VmdoRowid);

            entity.ToTable("visita_motonave_documento");

            entity.Property(e => e.VmdoRowid).HasColumnName("vmdo_rowid");
            entity.Property(e => e.VmdoArncelImprtcion)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("vmdo_arncel_imprtcion");
            entity.Property(e => e.VmdoCdgoTpoDcmnto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmdo_cdgo_tpo_dcmnto");
            entity.Property(e => e.VmdoCdgoUsrioAprbdo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmdo_cdgo_usrio_aprbdo");
            entity.Property(e => e.VmdoCdgoUsrioCrgue)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmdo_cdgo_usrio_crgue");
            entity.Property(e => e.VmdoCmntrio)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("vmdo_cmntrio");
            entity.Property(e => e.VmdoCntdad).HasColumnName("vmdo_cntdad");
            entity.Property(e => e.VmdoCstoSgroFlte)
                .HasColumnType("decimal(14, 4)")
                .HasColumnName("vmdo_csto_sgro_flte");
            entity.Property(e => e.VmdoEstdo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("vmdo_estdo");
            entity.Property(e => e.VmdoFchaAprbcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vmdo_fcha_aprbcion");
            entity.Property(e => e.VmdoFchaCrgue)
                .HasColumnType("smalldatetime")
                .HasColumnName("vmdo_fcha_crgue");
            entity.Property(e => e.VmdoLnea).HasColumnName("vmdo_lnea");
            entity.Property(e => e.VmdoNmro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vmdo_nmro");
            entity.Property(e => e.VmdoRowidVstaMtnve).HasColumnName("vmdo_rowid_vsta_mtnve");
            entity.Property(e => e.VmdoRowidVstaMtnveBl).HasColumnName("vmdo_rowid_vsta_mtnve_bl");
            entity.Property(e => e.VmdoRta)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("vmdo_rta");
            entity.Property(e => e.VmdoTrm)
                .HasColumnType("decimal(10, 4)")
                .HasColumnName("vmdo_trm");

            entity.HasOne(d => d.VmdoCdgoTpoDcmntoNavigation).WithMany(p => p.VisitaMotonaveDocumentos)
                .HasForeignKey(d => d.VmdoCdgoTpoDcmnto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_documento_tipo_documento_td_cdgo");

            entity.HasOne(d => d.VmdoCdgoUsrioAprbdoNavigation).WithMany(p => p.VisitaMotonaveDocumentoVmdoCdgoUsrioAprbdoNavigations)
                .HasForeignKey(d => d.VmdoCdgoUsrioAprbdo)
                .HasConstraintName("FK_visita_motonave_documento_usuario_us_cdgo_usrio_aprbdo");

            entity.HasOne(d => d.VmdoCdgoUsrioCrgueNavigation).WithMany(p => p.VisitaMotonaveDocumentoVmdoCdgoUsrioCrgueNavigations)
                .HasForeignKey(d => d.VmdoCdgoUsrioCrgue)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_documento_usuario_us_cdgo_usrio_crgue");

            entity.HasOne(d => d.VmdoRowidVstaMtnveNavigation).WithMany(p => p.VisitaMotonaveDocumentos)
                .HasForeignKey(d => d.VmdoRowidVstaMtnve)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_visita_motonave_documento_visita_motonave_vm_rowid");

            entity.HasOne(d => d.VmdoRowidVstaMtnveBlNavigation).WithMany(p => p.VisitaMotonaveDocumentos)
                .HasForeignKey(d => d.VmdoRowidVstaMtnveBl)
                .HasConstraintName("FK_visita_motonave_documento_visita_motonave_bl_vmbl_rowid");
        });

        modelBuilder.Entity<VwConsultarProductosSubdeposito>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ConsultarProductos_Subdepositos");

            entity.Property(e => e.PrCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pr_cdgo");
            entity.Property(e => e.PrNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pr_nmbre");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
        });

        modelBuilder.Entity<VwConsultarSubdeposito>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Consultar_Subdepositos");

            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.CodigoPadre)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PADRE");
            entity.Property(e => e.CodigoSubdeposito)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_SUBDEPOSITO");
            entity.Property(e => e.IdTercero).HasColumnName("ID_TERCERO");
            entity.Property(e => e.NombreTercero)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TERCERO");
            entity.Property(e => e.Unidades).HasColumnName("UNIDADES");
        });

        modelBuilder.Entity<VwEstdoHchoLstarVstaMtnve>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_EstdoHcho_LstarVstaMtnve");

            entity.Property(e => e.EmCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("em_cdgo");
            entity.Property(e => e.EmNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("em_nmbre");
            entity.Property(e => e.MoCntdadEsctllas).HasColumnName("mo_cntdad_esctllas");
            entity.Property(e => e.SpCdgoEstdoMtnve)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_estdo_mtnve");
            entity.Property(e => e.SpCdgoMtnve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_mtnve");
            entity.Property(e => e.SpFchaArrbo)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_arrbo");
            entity.Property(e => e.SpFchaAtrque)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_atrque");
            entity.Property(e => e.SpFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_crcion");
            entity.Property(e => e.SpFchaZrpe)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_zrpe");
            entity.Property(e => e.SpRowid).HasColumnName("sp_rowid");
            entity.Property(e => e.VmDscrpcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("vm_dscrpcion");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
            entity.Property(e => e.VmScncia).HasColumnName("vm_scncia");
        });

        modelBuilder.Entity<VwListadoClientesDetalle>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ListadoClientes_Detalle");

            entity.Property(e => e.Almacenar).HasColumnName("ALMACENAR");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.Directo).HasColumnName("DIRECTO");
            entity.Property(e => e.Ecotilla).HasColumnName("ECOTILLA");
            entity.Property(e => e.IdImportador).HasColumnName("ID_IMPORTADOR");
            entity.Property(e => e.IdOperador).HasColumnName("ID_OPERADOR");
            entity.Property(e => e.IdSituacion).HasColumnName("ID_SITUACION");
            entity.Property(e => e.IdSituacionDetalle).HasColumnName("ID_SITUACION_DETALLE");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.IdVisitaBl).HasColumnName("ID_VISITA_BL");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.Localizacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LOCALIZACION");
            entity.Property(e => e.NombreImportador)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_IMPORTADOR");
            entity.Property(e => e.NombreOperador)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_OPERADOR");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.NroBl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NRO_BL");
            entity.Property(e => e.RequisitoCliente)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("REQUISITO_CLIENTE");
        });

        modelBuilder.Entity<VwListadoClientesDetalleCopium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ListadoClientes_Detalle_copia");

            entity.Property(e => e.Almacenar).HasColumnName("ALMACENAR");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.Directo).HasColumnName("DIRECTO");
            entity.Property(e => e.Ecotilla).HasColumnName("ECOTILLA");
            entity.Property(e => e.IdImportador).HasColumnName("ID_IMPORTADOR");
            entity.Property(e => e.IdOperador).HasColumnName("ID_OPERADOR");
            entity.Property(e => e.IdSituacion).HasColumnName("ID_SITUACION");
            entity.Property(e => e.IdSituacionDetalle).HasColumnName("ID_SITUACION_DETALLE");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.IdVisitaBl).HasColumnName("ID_VISITA_BL");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.Localizacion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("LOCALIZACION");
            entity.Property(e => e.NombreImportador)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_IMPORTADOR");
            entity.Property(e => e.NombreOperador)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_OPERADOR");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.NroBl)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("NRO_BL");
            entity.Property(e => e.RequisitoCliente)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("REQUISITO_CLIENTE");
        });

        modelBuilder.Entity<VwListadoClientesEncabezado>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ListadoClientes_Encabezado");

            entity.Property(e => e.CodPrestadoServicio)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("COD_PRESTADO_SERVICIO");
            entity.Property(e => e.CodTerminalMaritimo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("COD_TERMINAL_MARITIMO");
            entity.Property(e => e.CodigoMotonave)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_MOTONAVE");
            entity.Property(e => e.CodigoPais)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PAIS");
            entity.Property(e => e.Eslora)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("ESLORA");
            entity.Property(e => e.FechaArribo)
                .HasColumnType("smalldatetime")
                .HasColumnName("FECHA_ARRIBO");
            entity.Property(e => e.IdAgenteNaviero).HasColumnName("ID_AGENTE_NAVIERO");
            entity.Property(e => e.IdSituacion).HasColumnName("ID_SITUACION");
            entity.Property(e => e.IdTercero).HasColumnName("ID_TERCERO");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.MatriculaMotonave)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("MATRICULA_MOTONAVE");
            entity.Property(e => e.NombreMotonave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MOTONAVE");
            entity.Property(e => e.NombrePais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PAIS");
            entity.Property(e => e.NombreTerminalMaritimo)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TERMINAL_MARITIMO");
            entity.Property(e => e.NombreVendedor)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_VENDEDOR");
            entity.Property(e => e.NomnbreAgenteNaviero)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("NOMNBRE_AGENTE_NAVIERO");
            entity.Property(e => e.TeMnjoPrpio).HasColumnName("te_mnjo_prpio");
        });

        modelBuilder.Entity<VwMdloDpstoAprbcionLstarClntesPorVstaMtnve>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MdloDpstoAprbcion_LstarClntesPorVstaMtnve");

            entity.Property(e => e.TeCdgo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("te_cdgo");
            entity.Property(e => e.TeNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("te_nmbre");
            entity.Property(e => e.TeRowid).HasColumnName("te_rowid");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
        });

        modelBuilder.Entity<VwMdloDpstoAprbcionLstarVstaMtnve>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MdloDpstoAprbcion_LstarVstaMtnve");

            entity.Property(e => e.VmCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_cia");
            entity.Property(e => e.VmMotonaveCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_cdgo");
            entity.Property(e => e.VmMotonaveNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_nmbre");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
            entity.Property(e => e.VmScncia).HasColumnName("vm_scncia");
        });

        modelBuilder.Entity<VwMdloDpstoCrcionLstarVstaMtnve>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MdloDpstoCrcion_LstarVstaMtnve");

            entity.Property(e => e.VmCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_cia");
            entity.Property(e => e.VmMotonaveCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_cdgo");
            entity.Property(e => e.VmMotonaveNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_nmbre");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
            entity.Property(e => e.VmScncia).HasColumnName("vm_scncia");
        });

        modelBuilder.Entity<VwMdloDpstoGnrarCdgoTmpralDpsto>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MdloDpsto_GnrarCdgoTmpralDpsto");

            entity.Property(e => e.CdgoDpsto)
                .HasMaxLength(18)
                .IsUnicode(false)
                .HasColumnName("cdgo_dpsto");
        });

        modelBuilder.Entity<VwMdloDpstoLstarPrdctoPorVstaMtnve>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MdloDpsto_LstarPrdctoPorVstaMtnve");

            entity.Property(e => e.PrCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pr_cdgo");
            entity.Property(e => e.PrNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("pr_nmbre");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
        });

        modelBuilder.Entity<VwMdloDpstoLstarVstaMtnve>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_MdloDpsto_LstarVstaMtnve");

            entity.Property(e => e.UsCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("us_cdgo");
            entity.Property(e => e.VmCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_cia");
            entity.Property(e => e.VmMotonaveCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_cdgo");
            entity.Property(e => e.VmMotonaveNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_nmbre");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
            entity.Property(e => e.VmScncia).HasColumnName("vm_scncia");
        });

        modelBuilder.Entity<VwModuloSituacionPortuariaListarSituacionPortuarium>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ModuloSituacionPortuaria_ListarSituacionPortuaria");

            entity.Property(e => e.EmCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("em_cdgo");
            entity.Property(e => e.EmNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("em_nmbre");
            entity.Property(e => e.MoBndra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("mo_bndra");
            entity.Property(e => e.MoCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("mo_cdgo");
            entity.Property(e => e.MoCldo)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("mo_cldo");
            entity.Property(e => e.MoCntdadEsctllas).HasColumnName("mo_cntdad_esctllas");
            entity.Property(e => e.MoEslra)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("mo_eslra");
            entity.Property(e => e.MoMtrcla)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("mo_mtrcla");
            entity.Property(e => e.MoNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("mo_nmbre");
            entity.Property(e => e.PaCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("pa_cdgo");
            entity.Property(e => e.PaNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pa_nmbre");
            entity.Property(e => e.SpCdgoEstdoMtnve)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_estdo_mtnve");
            entity.Property(e => e.SpCdgoMtnve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_mtnve");
            entity.Property(e => e.SpCdgoPais)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_pais");
            entity.Property(e => e.SpCdgoTrmnalMrtmo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_trmnal_mrtmo");
            entity.Property(e => e.SpCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_usrio_crea");
            entity.Property(e => e.SpFchaArrbo)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_arrbo");
            entity.Property(e => e.SpFchaAtrque)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_atrque");
            entity.Property(e => e.SpFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_crcion");
            entity.Property(e => e.SpFchaZrpe)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_zrpe");
            entity.Property(e => e.SpRowid).HasColumnName("sp_rowid");
            entity.Property(e => e.SpRowidAgnteNvro).HasColumnName("sp_rowid_agnte_nvro");
            entity.Property(e => e.SpRowidZnaCd).HasColumnName("sp_rowid_zna_cd");
            entity.Property(e => e.TeAgnteMrtmo).HasColumnName("te_agnte_mrtmo");
            entity.Property(e => e.TeCdgo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("te_cdgo");
            entity.Property(e => e.TeCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("te_cdgo_cia");
            entity.Property(e => e.TeNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("te_nmbre");
            entity.Property(e => e.TeRowid).HasColumnName("te_rowid");
            entity.Property(e => e.TmCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("tm_cdgo");
            entity.Property(e => e.TmDscrpcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("tm_dscrpcion");
            entity.Property(e => e.UsCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("us_cdgo");
            entity.Property(e => e.UsIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("us_idntfccion");
            entity.Property(e => e.UsNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("us_nmbre");
            entity.Property(e => e.UsRowidTrcro).HasColumnName("us_rowid_trcro");
            entity.Property(e => e.ZcdCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("zcd_cdgo");
            entity.Property(e => e.ZcdNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("zcd_nmbre");
            entity.Property(e => e.ZcdRowid).HasColumnName("zcd_rowid");
        });

        modelBuilder.Entity<VwModuloVisitaMotonaveListarVisitaMotonave>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ModuloVisitaMotonave_ListarVisitaMotonave");

            entity.Property(e => e.SpCdgoEstdoMtnve)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_estdo_mtnve");
            entity.Property(e => e.SpCdgoMtnve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_mtnve");
            entity.Property(e => e.SpCdgoPais)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_pais");
            entity.Property(e => e.SpCdgoTrmnalMrtmo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_trmnal_mrtmo");
            entity.Property(e => e.SpCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_cdgo_usrio_crea");
            entity.Property(e => e.SpCodigoVisitaMotonave).HasColumnName("sp_CodigoVisitaMotonave");
            entity.Property(e => e.SpCrearVisitaMotonave).HasColumnName("sp_CrearVisitaMotonave");
            entity.Property(e => e.SpEstadoMotonaveCdgo)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("sp_estado_motonave_cdgo");
            entity.Property(e => e.SpEstadoMotonaveNmbre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("sp_estado_motonave_nmbre");
            entity.Property(e => e.SpFchaArrbo)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_arrbo");
            entity.Property(e => e.SpFchaAtrque)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_atrque");
            entity.Property(e => e.SpFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_crcion");
            entity.Property(e => e.SpFchaZrpe)
                .HasColumnType("smalldatetime")
                .HasColumnName("sp_fcha_zrpe");
            entity.Property(e => e.SpMotonaveBndra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sp_motonave_bndra");
            entity.Property(e => e.SpMotonaveCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_motonave_cdgo");
            entity.Property(e => e.SpMotonaveCldo)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("sp_motonave_cldo");
            entity.Property(e => e.SpMotonaveCntdadEsctllas).HasColumnName("sp_motonave_cntdad_esctllas");
            entity.Property(e => e.SpMotonaveEslra)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("sp_motonave_eslra");
            entity.Property(e => e.SpMotonaveMtrcla)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("sp_motonave_mtrcla");
            entity.Property(e => e.SpMotonaveNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sp_motonave_nmbre");
            entity.Property(e => e.SpPaisCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_pais_cdgo");
            entity.Property(e => e.SpPaisNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("sp_pais_nmbre");
            entity.Property(e => e.SpRowid).HasColumnName("sp_rowid");
            entity.Property(e => e.SpRowidAgnteNvro).HasColumnName("sp_rowid_agnte_nvro");
            entity.Property(e => e.SpRowidZnaCd).HasColumnName("sp_rowid_zna_cd");
            entity.Property(e => e.SpTerceroAgnteNvroCdgo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sp_tercero_agnte_nvro_cdgo");
            entity.Property(e => e.SpTerceroAgnteNvroNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("sp_tercero_agnte_nvro_nmbre");
            entity.Property(e => e.SpTerceroAgnteNvrocdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_tercero_agnte_nvrocdgo_cia");
            entity.Property(e => e.SpTerceroAgnteRowid).HasColumnName("sp_tercero_agnte_rowid");
            entity.Property(e => e.SpTerminalMaritimoCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_terminal_maritimo_cdgo");
            entity.Property(e => e.SpTerminalMaritimoDscrpcion)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sp_terminal_maritimo_dscrpcion");
            entity.Property(e => e.SpUsuarioCreaCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_usuario_crea_cdgo");
            entity.Property(e => e.SpUsuarioCreaIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_usuario_crea_idntfccion");
            entity.Property(e => e.SpUsuarioCreaNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("sp_usuario_crea_nmbre");
            entity.Property(e => e.SpUsuarioCreaRowidTrcro).HasColumnName("sp_usuario_crea_rowid_trcro");
            entity.Property(e => e.SpZonaCdCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("sp_zona_cd_cdgo");
            entity.Property(e => e.SpZonaCdNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("sp_zona_cd_nmbre");
            entity.Property(e => e.SpZonaCdRowid).HasColumnName("sp_zona_cd_rowid");
            entity.Property(e => e.VmCdgoCia)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_cia");
            entity.Property(e => e.VmCdgoMtnve)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_mtnve");
            entity.Property(e => e.VmCdgoUsrioCrea)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_cdgo_usrio_crea");
            entity.Property(e => e.VmCompaniaCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_compania_cdgo");
            entity.Property(e => e.VmCompaniaIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_compania_idntfccion");
            entity.Property(e => e.VmCompaniaNmbre)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("vm_compania_nmbre");
            entity.Property(e => e.VmDscrpcion)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("vm_dscrpcion");
            entity.Property(e => e.VmFchaCrcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_crcion");
            entity.Property(e => e.VmFchaFinOprcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_fin_oprcion");
            entity.Property(e => e.VmFchaFndeo)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_fndeo");
            entity.Property(e => e.VmFchaIncioOprcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vm_fcha_incio_oprcion");
            entity.Property(e => e.VmMotonaveBndra)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_bndra");
            entity.Property(e => e.VmMotonaveCldo)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("vm_motonave_cldo");
            entity.Property(e => e.VmMotonaveCntdadEsctllas).HasColumnName("vm_motonave_cntdad_esctllas");
            entity.Property(e => e.VmMotonaveEslra)
                .HasColumnType("decimal(6, 2)")
                .HasColumnName("vm_motonave_eslra");
            entity.Property(e => e.VmMotonaveMtrcla)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_mtrcla");
            entity.Property(e => e.VmMotonaveNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("vm_motonave_nmbre");
            entity.Property(e => e.VmMotonaveeCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_motonavee_cdgo");
            entity.Property(e => e.VmRowid).HasColumnName("vm_rowid");
            entity.Property(e => e.VmRowidStcionPrtria).HasColumnName("vm_rowid_stcion_prtria");
            entity.Property(e => e.VmRowidVnddor).HasColumnName("vm_rowid_vnddor");
            entity.Property(e => e.VmRowidZnaCdAltrno).HasColumnName("vm_rowid_zna_cd_altrno");
            entity.Property(e => e.VmRowidsPrstdresSrvcios)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("vm_rowids_prstdres_srvcios");
            entity.Property(e => e.VmScncia).HasColumnName("vm_scncia");
            entity.Property(e => e.VmUsrioCreaCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_usrio_crea_cdgo");
            entity.Property(e => e.VmUsrioCreaIdntfccion)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_usrio_crea_idntfccion");
            entity.Property(e => e.VmUsrioCreaNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("vm_usrio_crea_nmbre");
            entity.Property(e => e.VmVnddorTrcroCdgo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vm_vnddor_trcro_cdgo");
            entity.Property(e => e.VmVnddorTrcroNmbre)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("vm_vnddor_trcro_nmbre");
            entity.Property(e => e.VmVnddorTrcroRowid).HasColumnName("vm_vnddor_trcro_rowid");
            entity.Property(e => e.VmZnaCdAltrnoCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vm_zna_cd_altrno_cdgo");
            entity.Property(e => e.VmZnaCdAltrnoNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("vm_zna_cd_altrno_nmbre");
            entity.Property(e => e.VmZnaCdAltrnoRowid).HasColumnName("vm_zna_cd_altrno_rowid");
            entity.Property(e => e.VnddorTrcroIdntfccion)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vnddor_trcro_idntfccion");
        });

        modelBuilder.Entity<VwResumenListadoCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Resumen_ListadoClientes");

            entity.Property(e => e.Almacenar).HasColumnName("ALMACENAR");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.Directo).HasColumnName("DIRECTO");
            entity.Property(e => e.Ecotilla).HasColumnName("ECOTILLA");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<VwResumenListadoClientesOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_Resumen_ListadoClientes_old");

            entity.Property(e => e.Almacenar).HasColumnName("ALMACENAR");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.Directo).HasColumnName("DIRECTO");
            entity.Property(e => e.Ecotilla).HasColumnName("ECOTILLA");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<WmDepositosSolicitudRetiro>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wm_Depositos_SolicitudRetiro");

            entity.Property(e => e.Cantidad).HasColumnName("CANTIDAD");
            entity.Property(e => e.CantidadDespachados).HasColumnName("CANTIDAD_DESPACHADOS");
            entity.Property(e => e.CantidadRetiro).HasColumnName("CANTIDAD_RETIRO");
            entity.Property(e => e.CodigoCliente).HasColumnName("CODIGO_CLIENTE");
            entity.Property(e => e.CodigoDeposito)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DEPOSITO");
            entity.Property(e => e.CodigoMotonave)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_MOTONAVE");
            entity.Property(e => e.CodigoPadreDeposito)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PADRE_DEPOSITO");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_USUARIO");
            entity.Property(e => e.EstadoSolicitud).HasColumnName("ESTADO_SOLICITUD");
            entity.Property(e => e.FechaApertura)
                .HasColumnType("smalldatetime")
                .HasColumnName("FECHA_APERTURA");
            entity.Property(e => e.IdDeposito).HasColumnName("ID_DEPOSITO");
            entity.Property(e => e.IdRetiro).HasColumnName("ID_RETIRO");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.KilosAutorizado).HasColumnName("KILOS_AUTORIZADO");
            entity.Property(e => e.KilosDespachados).HasColumnName("KILOS_DESPACHADOS");
            entity.Property(e => e.NombreMotonave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MOTONAVE");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.PesoExacto).HasColumnName("PESO_EXACTO");
            entity.Property(e => e.PlantaDestino)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PLANTA_DESTINO");
            entity.Property(e => e.Saldos).HasColumnName("SALDOS");
            entity.Property(e => e.SrAbrta).HasColumnName("sr_abrta");
            entity.Property(e => e.SrCmpoPrsnlzdo1)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sr_cmpo_prsnlzdo1");
            entity.Property(e => e.SrCmpoPrsnlzdo2)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sr_cmpo_prsnlzdo2");
            entity.Property(e => e.SrCmpoPrsnlzdo3)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("sr_cmpo_prsnlzdo3");
            entity.Property(e => e.SrEntrgaSspndda).HasColumnName("sr_entrga_sspndda");
            entity.Property(e => e.SrObsrvcnes)
                .IsUnicode(false)
                .HasColumnName("sr_obsrvcnes");
            entity.Property(e => e.ZonaSolicitud).HasColumnName("ZONA_SOLICITUD");
        });

        modelBuilder.Entity<WmGraficoListadoCliente>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wm_graficoListadoClientes");

            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<WmGraficoListadoClientesOld>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wm_graficoListadoClientes_old");

            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.Kilos).HasColumnName("KILOS");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
        });

        modelBuilder.Entity<WvConsultaDepositosSubdeposito>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wv_consultaDepositos_Subdepositos");

            entity.Property(e => e.CodigoCliente).HasColumnName("CODIGO_CLIENTE");
            entity.Property(e => e.CodigoDeposito)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DEPOSITO");
            entity.Property(e => e.CodigoMotonave)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_MOTONAVE");
            entity.Property(e => e.CodigoPadreDeposito)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PADRE_DEPOSITO");
            entity.Property(e => e.CodigoProducto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PRODUCTO");
            entity.Property(e => e.CodigoUsuario)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("CODIGO_USUARIO");
            entity.Property(e => e.IdDeposito).HasColumnName("ID_DEPOSITO");
            entity.Property(e => e.IdVisita).HasColumnName("ID_VISITA");
            entity.Property(e => e.NombreMotonave)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_MOTONAVE");
            entity.Property(e => e.NombreProducto)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_PRODUCTO");
            entity.Property(e => e.Saldos).HasColumnName("SALDOS");
        });

        modelBuilder.Entity<WxConsultaTipoDocumento>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("wx_consultaTipoDocumento");

            entity.Property(e => e.BotonColor)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("botonColor");
            entity.Property(e => e.RowIdVmdo).HasColumnName("rowId_vmdo");
            entity.Property(e => e.TdActvo).HasColumnName("td_actvo");
            entity.Property(e => e.TdCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("td_cdgo");
            entity.Property(e => e.TdNmbre)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("td_nmbre");
            entity.Property(e => e.TdNmbreAAsgnar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("td_nmbre_a_asgnar");
            entity.Property(e => e.TdOblgtrio).HasColumnName("td_oblgtrio");
            entity.Property(e => e.TdOrgen)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("td_orgen");
            entity.Property(e => e.VmdoCdgoTpoDcmnto)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmdo_cdgo_tpo_dcmnto");
            entity.Property(e => e.VmdoCdgoUsrioAprbdo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmdo_cdgo_usrio_aprbdo");
            entity.Property(e => e.VmdoCdgoUsrioCrgue)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("vmdo_cdgo_usrio_crgue");
            entity.Property(e => e.VmdoEstdo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("vmdo_estdo");
            entity.Property(e => e.VmdoFchaAprbcion)
                .HasColumnType("smalldatetime")
                .HasColumnName("vmdo_fcha_aprbcion");
            entity.Property(e => e.VmdoFchaCrgue)
                .HasColumnType("smalldatetime")
                .HasColumnName("vmdo_fcha_crgue");
            entity.Property(e => e.VmdoRowid).HasColumnName("vmdo_rowid");
            entity.Property(e => e.VmdoRowidVstaMtnve).HasColumnName("vmdo_rowid_vsta_mtnve");
            entity.Property(e => e.VmdoRta)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("vmdo_rta");
        });

        modelBuilder.Entity<ZonaCd>(entity =>
        {
            entity.HasKey(e => e.ZcdRowid);

            entity.ToTable("zona_cd");

            entity.Property(e => e.ZcdRowid).HasColumnName("zcd_rowid");
            entity.Property(e => e.ZcdActvo).HasColumnName("zcd_actvo");
            entity.Property(e => e.ZcdBdga).HasColumnName("zcd_bdga");
            entity.Property(e => e.ZcdCdgo)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("zcd_cdgo");
            entity.Property(e => e.ZcdCpcdad).HasColumnName("zcd_cpcdad");
            entity.Property(e => e.ZcdMlle).HasColumnName("zcd_mlle");
            entity.Property(e => e.ZcdNmbre)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("zcd_nmbre");
            entity.Property(e => e.ZcdPlnta)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("zcd_plnta");
            entity.Property(e => e.ZcdPtio).HasColumnName("zcd_ptio");
            entity.Property(e => e.ZcdRowidSde).HasColumnName("zcd_rowid_sde");
            entity.Property(e => e.ZcdSlo).HasColumnName("zcd_slo");

            entity.HasOne(d => d.ZcdRowidSdeNavigation).WithMany(p => p.ZonaCds)
                .HasForeignKey(d => d.ZcdRowidSde)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_zona_cd_sede_se_rowid");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    public DbSet<MdloDtos.SpListaDocumentosAprobacionCargue> SpListaDocumentosAprobacionCargues { get; set; }

    public DbSet<MdloDtos.SpListaBls> SpListaBls { get; set; }

    public DbSet<MdloDtos.SpListaDeposito> SpListaDeposito { get; set; }

    public DbSet<MdloDtos.SpListarEstadosHecho> SpListarEstadosHecho { get; set; }

    public DbSet<MdloDtos.SpReturnAprbrRchzarDpsto> SpReturnAprbrRchzarDpsto { get; set; }

    public DbSet<MdloDtos.SpDtlleDpstoAprbcion> SpDtlleDpstoAprbcion { get; set; }

    public DbSet<MdloDtos.SpListaDocumentosAprobacionCargue> SpListaVisitaMotonaveBlCrearDepositos { get; set; }

    public DbSet<MdloDtos.Producto> spMdloDpstoCrcionLstarPrdctos { get; set; }

    public DbSet<MdloDtos.SpDeposito> spMdloDpstoAdmnstrcion_LstarDpstos { get; set; }

    public DbSet<MdloDtos.SpDepositoDetalle> spMdloDpstoAdmnstrcion_LstarDpstosDetalle { get; set; }

    public DbSet<MdloDtos.SpSubDeposito> spMdloDpstoAdmnstrcion_LstarSubDpstos { get; set; }



    public async Task<List<MdloDtos.SpListaDocumentosAprobacionCargue>> ListarDocumentosAprobarPorVisitaMotonave(int rowIdVisitaMotonave)
    {
        try
        {
            var param = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
            return await this.SpListaDocumentosAprobacionCargues.FromSqlRaw("EXEC sp_ModuloAprobacionDocumentacion_listarDocumentosPorIdVisitaMotonave @rowIdVisitaMotonave", param).ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace.ToString());
            return null;
        }
    }

    public async Task<List<MdloDtos.SpListaDocumentosAprobacionCargue>> ListarDocumentosAduanasDeCarguePorVisitaMotonave(int rowIdVisitaMotonave, string codigoUsuario)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        var param2 = new SqlParameter("@codigoUsuario", codigoUsuario);
        return await this.SpListaDocumentosAprobacionCargues.FromSqlRaw("EXEC sp_ModuloDocumentacionAduana_listarDocumentosPorIdVisitaMotonave @rowIdVisitaMotonave ,@codigoUsuario", param1, param2).ToListAsync();
    }

    public async Task<List<MdloDtos.SpListaBls>> ListarBlsPorVisitaMotonaveCliente(int rowIdVisitaMotonave, string codigoUsuario)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        var param2 = new SqlParameter("@codigoUsuario", codigoUsuario);
        return await this.SpListaBls.FromSqlRaw("EXEC sp_MdloDpsto_LstarBls @rowIdVisitaMotonave ,@codigoUsuario", param1, param2).ToListAsync();
    }

    public async Task<List<MdloDtos.SpListaBls>> ListarBlsPorVisitaMotonaveClienteProducto(int rowIdVisitaMotonave, string codigoUsuario, string codigoProducto)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        var param2 = new SqlParameter("@codigoUsuario", codigoUsuario);
        var param3 = new SqlParameter("@codigoProducto", codigoProducto);
        return await this.SpListaBls.FromSqlRaw("EXEC sp_MdloDpsto_LstarBlsPorProducto @rowIdVisitaMotonave ,@codigoUsuario, @codigoProducto", param1, param2, param3).ToListAsync();
    }

    public async Task<List<MdloDtos.SpListaDeposito>> ListarDepositosAprobacionPorVisitaMotonave(int rowIdVisitaMotonave)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        return await this.SpListaDeposito.FromSqlRaw("EXEC sp_MdloDpstoAprbcion_LstarDpstos @rowIdVisitaMotonave", param1).ToListAsync();
    }

    public async Task<List<MdloDtos.SpListaDeposito>> ListarDepositosAprobacionPorVisitaCliente(int rowIdVisitaMotonave, int idCliente)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        var param2 = new SqlParameter("@codigoCliente", idCliente);
        return await this.SpListaDeposito.FromSqlRaw("EXEC sp_MdloDpstoAprbcion_LstarDpstosPorClntes @rowIdVisitaMotonave, @codigoCliente", param1, param2).ToListAsync();
    }

    //procedimiento almacenado para traer los eventos segun su estado si es C = Cerrado, NC =no cerrado y I = inactivo
    public async Task<List<MdloDtos.SpListarEstadosHecho>> SpListarEstadosHechoSegunEstado(int? idEstadohechoVmOZc, string estado)
    {
        var param1 = new SqlParameter("@codigoVMoZC", idEstadohechoVmOZc);
        var param2 = new SqlParameter("@Estado", estado);
        return await this.SpListarEstadosHecho.FromSqlRaw("EXEC sp_listarEstadoHechoPorVisitaMotonaveOZona @codigoVMoZC, @Estado", param1, param2).ToListAsync();
    }

    public async Task<bool> AprobarRechazarDeposito(int rowIdDeposito, bool? fueAprobado)
    {
        // Configuración de parámetros de entrada
        var param1 = new SqlParameter("@rowIdDeposito", rowIdDeposito);
        var param2 = new SqlParameter("@fueAprobado", fueAprobado);

        // Configuración de parámetro de salida
        var paramResultado = new SqlParameter("@retorno", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };

        // Ejecutar el procedimiento almacenado
        await this.SpReturnAprbrRchzarDpsto.FromSqlRaw(
            "EXEC sp_MdloDpstoAprbcion_AprbarRchzarDsto @rowIdDeposito, @fueAprobado, @retorno OUTPUT",
            param1, param2, paramResultado).ToListAsync();

        // Obtener el valor del parámetro de salida
        return (bool)paramResultado.Value;
    }
    //new
    public async Task<List<MdloDtos.SpDtlleDpstoAprbcion>> ListarDetalleDepositoAprobacion(int rowIdDeposito)
    {
        var param1 = new SqlParameter("@rowIdDeposito", rowIdDeposito);
        return await this.SpDtlleDpstoAprbcion.FromSqlRaw("EXEC sp_MdloDpstoAprbcion_DtlleDpsto @rowIdDeposito", param1).ToListAsync();
    }

    public async Task<bool> DepositoAprobar(MdloDtos.SpDpstoAprbcion spDpstoAprbcion)
    {
        // Configuración de parámetros de entrada
        var param1 = new SqlParameter("@rowIdDpsto", spDpstoAprbcion.rowIdDpsto);
        var param2 = new SqlParameter("@cdgoCmpniaFctrcion", spDpstoAprbcion.cdgoCmpniaFctrcion);
        var param3 = new SqlParameter("@rowIdSde", spDpstoAprbcion.rowIdSde);
        var param4 = new SqlParameter("@cdgoUsrioAprba", spDpstoAprbcion.cdgoUsrioAprba);
        var param5 = new SqlParameter("@CntdadImprsionTqte", spDpstoAprbcion.CntdadImprsionTqte);
        var param6 = new SqlParameter("@estdoDpsto", spDpstoAprbcion.estdoDpsto);
        var param7 = new SqlParameter("@cntrlUnddes", spDpstoAprbcion.cntrlUnddes);
        var param8 = new SqlParameter("@obsrvcnes", spDpstoAprbcion.obsrvcnes);

        // Configuración de parámetro de salida
        var paramResultado = new SqlParameter("@retorno", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };

        // Ejecutar el procedimiento almacenado
        await this.SpReturnAprbrRchzarDpsto.FromSqlRaw(
            "EXEC sp_MdloDpstoAprbcion_AprbarDsto @rowIdDpsto, @cdgoCmpniaFctrcion , @rowIdSde , @cdgoUsrioAprba,@CntdadImprsionTqte,@estdoDpsto,@cntrlUnddes,@obsrvcnes, @retorno OUTPUT",
            param1, param2, param3, param4, param5, param6, param7, param8, paramResultado).ToListAsync();

        // Obtener el valor del parámetro de salida
        return (bool)paramResultado.Value;
    }

    public async Task<bool> DepositoRechazar(MdloDtos.SpDpstoRchzo spDpstoRchzo)
    {
        // Configuración de parámetros de entrada
        var param1 = new SqlParameter("@rowIdDpsto", spDpstoRchzo.rowIdDpsto);
        var param2 = new SqlParameter("@cdgoUsrioRchza", spDpstoRchzo.cdgoUsrioRchza);
        var param3 = new SqlParameter("@cmntrioRchzo", spDpstoRchzo.cmntrioRchzo);


        // Configuración de parámetro de salida
        var paramResultado = new SqlParameter("@retorno", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };

        // Ejecutar el procedimiento almacenado
        await this.SpReturnAprbrRchzarDpsto.FromSqlRaw(
            "EXEC sp_MdloDpstoAprbcion_RchzarDsto @rowIdDpsto, @cdgoUsrioRchza , @cmntrioRchzo, @retorno OUTPUT",
            param1, param2, param3, paramResultado).ToListAsync();

        // Obtener el valor del parámetro de salida
        return (bool)paramResultado.Value;
    }
    public async Task<int> CantidadCopiasImpresion()
    {
        // Configuración de parámetro de salida
        var paramResultado = new SqlParameter("@retorno", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };

        // Ejecutar el procedimiento almacenado
        await this.SpReturnAprbrRchzarDpsto.FromSqlRaw(
            "EXEC sp_MdloDpstoAprbcion_CntdadTqteImprsion @retorno OUTPUT", paramResultado).ToListAsync();

        // Obtener el valor del parámetro de salida
        return (int)paramResultado.Value;
    }

    //Servicios Creación Depositos

    public async Task<List<MdloDtos.Producto>> ListarProductosCreacionDeposito(int rowIdVisitaMotonave, int? idCliente)
    {
        if (idCliente != null)
        {
            var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
            var param2 = new SqlParameter("@rowIdTercero", idCliente);
            return await this.spMdloDpstoCrcionLstarPrdctos.FromSqlRaw("EXEC sp_MdloDpstoCrcion_LstarPrdctosPorClntes @rowIdVisitaMotonave, @rowIdTercero", param1, param2).ToListAsync();
        }
        else
        {
            var param3 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
            return await this.spMdloDpstoCrcionLstarPrdctos.FromSqlRaw("EXEC sp_MdloDpstoCrcion_LstarPrdctos @rowIdVisitaMotonave", param3).ToListAsync();
        }
    }

    public async Task<List<MdloDtos.SpListaDocumentosAprobacionCargue>> ListarVisitaMotonaveBlCrearDepositos(int rowIdVisitaMotonave, int rowIdTercero, string codigoProducto)
    {
        try
        {
            var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
            var param2 = new SqlParameter("@rowIdTercero", rowIdTercero);
            var param3 = new SqlParameter("@codigoProducto", codigoProducto);
            return await this.SpListaVisitaMotonaveBlCrearDepositos.FromSqlRaw("EXEC sp_MdloDpstoCrcion_LstarBls @rowIdVisitaMotonave,@rowIdTercero,@codigoProducto", param1, param2, param3).ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace.ToString());
            return null;
        }
    }

    public async Task<bool> DepositoAprobarColaboradorInterno(MdloDtos.SpDpstoAprbcion spDpstoAprbcion)
    {
        // Configuración de parámetros de entrada
        var param1 = new SqlParameter("@rowIdDpsto", spDpstoAprbcion.rowIdDpsto);
        var param2 = new SqlParameter("@cdgoUsrioAprba", spDpstoAprbcion.cdgoUsrioAprba);

        // Configuración de parámetro de salida
        var paramResultado = new SqlParameter("@retorno", SqlDbType.Bit)
        {
            Direction = ParameterDirection.Output
        };

        // Ejecutar el procedimiento almacenado
        await this.SpReturnAprbrRchzarDpsto.FromSqlRaw(
            "EXEC sp_MdloDpstoCrcion_AprbarDpstoClbrdorIntrno @rowIdDpsto, @cdgoUsrioAprba, @retorno OUTPUT",
            param1, param2, paramResultado).ToListAsync();

        // Obtener el valor del parámetro de salida
        return (bool)paramResultado.Value;
    }

    public async Task<List<MdloDtos.SpDeposito>> DpsitoAdmnstrcion_LstarDpstos(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        var param2 = new SqlParameter("@rowIdTercero", rowIdTercero.HasValue ? (object)rowIdTercero.Value : DBNull.Value)
        {
            SqlDbType = SqlDbType.Int
        };

        var param3 = new SqlParameter("@cdgoProducto", string.IsNullOrEmpty(cdgoProducto) ? DBNull.Value : (object)cdgoProducto)
        {
            SqlDbType = SqlDbType.NVarChar
        };

        var param4 = new SqlParameter("@cdgoCmpnia", string.IsNullOrEmpty(cdgoCmpnia) ? DBNull.Value : (object)cdgoCmpnia)
        {
            SqlDbType = SqlDbType.NVarChar
        };

        return await this.spMdloDpstoAdmnstrcion_LstarDpstos
            .FromSqlRaw("EXEC sp_MdloDpstoAdmnstrcion_LstarDpsto @rowIdVisitaMotonave, @rowIdTercero, @cdgoProducto, @cdgoCmpnia", param1, param2, param3, param4)
            .ToListAsync();


    }
    public async Task<List<MdloDtos.SpDepositoDetalle>> DpsitoAdmnstrcion_LstarDpstosDetalle(int rowIdVisitaMotonave, int? rowIdTercero, string? cdgoProducto, string? cdgoCmpnia, bool estadoDeposito)
    {
        var param1 = new SqlParameter("@rowIdVisitaMotonave", rowIdVisitaMotonave);
        var param2 = new SqlParameter("@rowIdTercero", rowIdTercero.HasValue ? (object)rowIdTercero.Value : DBNull.Value)
        {
            SqlDbType = SqlDbType.Int
        };

        var param3 = new SqlParameter("@cdgoProducto", string.IsNullOrEmpty(cdgoProducto) ? DBNull.Value : (object)cdgoProducto)
        {
            SqlDbType = SqlDbType.NVarChar
        };

        var param4 = new SqlParameter("@cdgoCmpnia", string.IsNullOrEmpty(cdgoCmpnia) ? DBNull.Value : (object)cdgoCmpnia)
        {
            SqlDbType = SqlDbType.NVarChar
        };

        var param5 = new SqlParameter("@estadoDpsto", estadoDeposito);

        return await this.spMdloDpstoAdmnstrcion_LstarDpstosDetalle
                .FromSqlRaw("EXEC sp_MdloDpstoAdmnstrcion_CnsltarDpsto @rowIdVisitaMotonave, @rowIdTercero, @cdgoProducto, @cdgoCmpnia, @estadoDpsto", param1, param2, param3, param4, param5)
                .ToListAsync();

    }

    public async Task<List<MdloDtos.SpSubDeposito>> DpsitoAdmnstrcion_LstarSubDpstos(string cdgoDpstoPdre)
    {
        var param1 = new SqlParameter("@cdgoDpstoPdre", cdgoDpstoPdre);


        return await this.spMdloDpstoAdmnstrcion_LstarSubDpstos
                .FromSqlRaw("EXEC sp_MdloDpstoAdmnstrcion_CnsltarSbDpstos @cdgoDpstoPdre", param1)
                .ToListAsync();

    }


    /* public async Task<List<MdloDtos.SpListaDocumentosAprobacionCargue>> DspstoAdmnstrcion_LstarBls(int rowidDeposito)
     {
         try
         {
             var param1 = new SqlParameter("@de_rowid", rowidDeposito);

             return await this.SpListaVisitaMotonaveBlCrearDepositos.FromSqlRaw("EXEC sp_MdloDpstoCrcion_LstarBls @de_rowid", param1).ToListAsync();

         }
         catch (Exception ex)
         {
             Console.WriteLine(ex.StackTrace.ToString());
             return null;
         }
     }*/
    public async Task<List<MdloDtos.SpListaDocumentosAprobacionCargue>> DspstoAdmnstrcion_LstarBls(int rowidDeposito)
    {
        try
        {
            var param1 = new SqlParameter("@rowIdDeposito", rowidDeposito);

            return await this.SpListaVisitaMotonaveBlCrearDepositos.FromSqlRaw("EXEC sp_MdloDpstoAdmnstrcion_LstarBls @rowIdDeposito", param1).ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace.ToString());
            return null;
        }
    }

    public DbSet<MdloDtos.Sp_IngresarSubdepositos> Sp_IngresarSubdepositos { get; set; }
    public async Task<List<MdloDtos.Sp_IngresarSubdepositos>> IngresarSubdepositos(string? codigoCompania, int? cantidad,
        int? kilos, int? idtercero, int? idsede, string? codigoPadre, string? codigoProducto, string? usuarioCreador)
    {
        var param1 = new SqlParameter("@CodigoCompania", codigoCompania);
        var param2 = new SqlParameter("@Cantidad", cantidad);
        var param3 = new SqlParameter("@Kilos", kilos);
        var param4 = new SqlParameter("@IdTercero", idtercero);
        var param5 = new SqlParameter("@IdSede", idsede);
        var param6 = new SqlParameter("@CodigoPadre", codigoPadre);
        var param7 = new SqlParameter("@CodigoProducto", codigoProducto);
        var param8 = new SqlParameter("@UsuarioCreador", usuarioCreador);
        return await this.Sp_IngresarSubdepositos.FromSqlRaw("EXEC Sp_IngresarSubdepositos @CodigoCompania ,@Cantidad,@Kilos,@IdTercero,@IdSede,@CodigoPadre,@CodigoProducto,@UsuarioCreador", param1, param2, param3, param4, param5, param6, param7, param8).ToListAsync();
    }

    public DbSet<MdloDtos.Sp_IngresarSolicitudRetiro> sp_Ingresar_SolicitudRetiro { get; set; }
    public async Task<List<MdloDtos.Sp_IngresarSolicitudRetiro>> Ingresar_SolicitudRetiro(string? sr_cia, string? sr_cdgo,
        int? sr_rowid_dpsto, int? sr_rowid_cdad, string? sr_plnta_dstno, DateTime? sr_fcha_aprtra, int? sr_autrzdo_klos, int? sr_autrzdo_cntdad,
        int? sr_dspchdo_klos, int? sr_dspchdo_cntdad, bool? sr_actva, bool? sr_abrta, bool? sr_entrga_sspndda, string? sr_obsrvcnes, string? sr_cmpo_prsnlzdo1, string? sr_cmpo_prsnlzdo2, string? sr_cmpo_prsnlzdo3, int? sr_rowid_zna_cd,
       bool? sr_entrgar_pso_excto)
    {
        var param1 = new SqlParameter("@sr_cia", sr_cia);
        var param2 = new SqlParameter("@sr_cdgo", sr_cdgo);
        var param3 = new SqlParameter("@sr_rowid_dpsto", sr_rowid_dpsto);
        var param4 = new SqlParameter("@sr_rowid_cdad", sr_rowid_cdad);
        var param5 = new SqlParameter("@sr_plnta_dstno", sr_plnta_dstno);
        var param6 = new SqlParameter("@sr_fcha_aprtra", sr_fcha_aprtra);
        var param7 = new SqlParameter("@sr_autrzdo_klos", sr_autrzdo_klos);
        var param8 = new SqlParameter("@sr_autrzdo_cntdad", sr_autrzdo_cntdad);
        var param9 = new SqlParameter("@sr_dspchdo_klos", sr_dspchdo_klos);
        var param10 = new SqlParameter("@sr_dspchdo_cntdad", sr_dspchdo_cntdad);
        var param11 = new SqlParameter("@sr_actva", sr_actva);
        var param12 = new SqlParameter("@sr_abrta", sr_abrta);
        var param13 = new SqlParameter("@sr_entrga_sspndda", sr_entrga_sspndda);
        var param14 = new SqlParameter("@sr_obsrvcnes", sr_obsrvcnes);
        var param15 = new SqlParameter("@sr_cmpo_prsnlzdo1", sr_cmpo_prsnlzdo1);
        var param16 = new SqlParameter("@sr_cmpo_prsnlzdo2", sr_cmpo_prsnlzdo2);
        var param17 = new SqlParameter("@sr_cmpo_prsnlzdo3", sr_cmpo_prsnlzdo3);
        var param18 = new SqlParameter("@sr_rowid_zna_cd", sr_rowid_zna_cd);
        var param19 = new SqlParameter("@sr_entrgar_pso_excto", sr_entrgar_pso_excto);
        return await this.sp_Ingresar_SolicitudRetiro.FromSqlRaw("EXEC Sp_IngresarSolicitudRetiro @sr_cia ,@sr_cdgo,@sr_rowid_dpsto,@sr_rowid_cdad,@sr_plnta_dstno,@sr_fcha_aprtra,@sr_autrzdo_klos,@sr_autrzdo_cntdad,@sr_dspchdo_klos,@sr_dspchdo_cntdad,@sr_actva,@sr_abrta,@sr_entrga_sspndda,@sr_obsrvcnes,@sr_cmpo_prsnlzdo1,@sr_cmpo_prsnlzdo2,@sr_cmpo_prsnlzdo3,@sr_rowid_zna_cd,@sr_entrgar_pso_excto", param1, param2, param3, param4, param5, param6, param7, param8, param9, param10, param11, param12, param13, param14, param15, param16, param17, param18, param19).ToListAsync();
    }
    public DbSet<MdloDtos.sp_Cerrar_SolicitudRetiro> sp_Cerrar_SolicitudRetiro { get; set; }
    public async Task<List<MdloDtos.sp_Cerrar_SolicitudRetiro>> Cerrar_SolicitudRetiro(int sr_rowid)
    {
        var param1 = new SqlParameter("@sr_rowid", sr_rowid);
        return await this.sp_Cerrar_SolicitudRetiro.FromSqlRaw("EXEC sp_Cerrar_SolicitudRetiro sr_rowid", param1).ToListAsync();
    }


    /*public async Task<List<MdloDtos.SpListaDocumentosAprobacionCargue>> DspstoAdmnstrcion_LstarBls(int rowidDeposito)
    {
        try
        {
            var param1 = new SqlParameter("@de_rowid", rowidDeposito);

            return await this.SpListaVisitaMotonaveBlCrearDepositos.FromSqlRaw("EXEC sp_MdloDpstoCrcion_LstarBls @de_rowid", param1).ToListAsync();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.StackTrace.ToString());
            return null;
        }
    }

    */
}

