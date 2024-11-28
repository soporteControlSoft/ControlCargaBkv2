using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VisitaMotonaveBl
{
    [Key]
    [JsonPropertyName("IdMotonaveBL")]
    public int VmblRowid { get; set; }

    [JsonPropertyName("IdVisitaMotonaveDetalle")]
    public int? VmblRowidVstaMtnveDtlle { get; set; }

    [JsonPropertyName("NumeroBL")]
    [StringLength(20)]
    public string? VmblNmro { get; set; } = null!;

    [JsonPropertyName("CodigoUnidadMedida")]
    [StringLength(15)]
    public string? VmblCdgoUndadMdda { get; set; } = null!;

    [JsonPropertyName("Cantidad")]
    public int? VmblCntdad { get; set; }

    [JsonPropertyName("ToneladasMetricas")]
    public int? VmblTnldasMtrcas { get; set; }

    [JsonPropertyName("Estado")]
    public string? VmblEstdo { get; set; } = null!;

    [JsonPropertyName("RutaDocumento")]
    [StringLength(300)]
    public string? VmblRta { get; set; } = null!;

    [JsonPropertyName("FechaCargue")]
    public DateTime? VmblFchaCrgue { get; set; }

    [JsonPropertyName("FechaAprobacion")]
    public DateTime? VmblFchaAprbcion { get; set; }

    [JsonPropertyName("CodigoUsuarioCargue")]
    [StringLength(15)]
    public string? VmblCdgoUsrioCrgue { get; set; } = null!;

    [JsonPropertyName("CodigoUsuarioAprobacion")]
    [StringLength(15)]
    public string? VmblCdgoUsrioAprbdo { get; set; }

    [JsonPropertyName("IdSituacionPortuariaDetalle")]
    public int? VmblRowidStcionPrtriaDtlle { get; set; }

    [JsonPropertyName("Escotilla")]
    public int? VmblEsctlla { get; set; }

    [JsonPropertyName("KiloCompromisoDirecto")]
    public int? VmblKlosCmprmsoDrcto { get; set; }

    [JsonPropertyName("KiloCompromisoAlmacenar")]
    public int? VmblKlosCmprmsoAlmcnar { get; set; }

    [JsonPropertyName("IdsSedes")]
    public string? VmblRowidsSdes { get; set; }

    [JsonPropertyName("RequisitoCliente")]
    public string? VmblRqstoClnte { get; set; }

    [JsonPropertyName("ComentariosRechazos")]
    public string? VmblCmntriosRchzo { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual ICollection<DepositoBl> DepositoBls { get; set; } = new List<DepositoBl>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl1> VisitaMotonaveBl1s { get; set; } = new List<VisitaMotonaveBl1>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveComentario> VisitaMotonaveComentarios { get; set; } = new List<VisitaMotonaveComentario>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDocumento> VisitaMotonaveDocumentos { get; set; } = new List<VisitaMotonaveDocumento>();

    [JsonIgnore]
    [NotMapped]
    public virtual UnidadMedidum? VmblCdgoUndadMddaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? VmblCdgoUsrioAprbdoNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? VmblCdgoUsrioCrgueNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual SituacionPortuariaDetalle? VmblRowidStcionPrtriaDtlleNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonaveDetalle? VmblRowidVstaMtnveDtlleNavigation { get; set; } = null!;

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 
    [NotMapped]
    public string? UnidadMedidaCodigo { get; set; }

    [NotMapped]
    public string? UnidadMedidaNombre { get; set; }

    [NotMapped]
    public string? UnidadMedidaEsGranel { get; set; }

    [NotMapped]
    public string? usuarioCreaCodigo { get; set; }

    [NotMapped]
    public string? usuarioCreaNombre { get; set; }

    [NotMapped]
    public string? usuarioCreaCorreo { get; set; }

    [NotMapped]
    public string? usuarioApruebaCodigo { get; set; }

    [NotMapped]
    public string? usuarioApruebaNombre { get; set; }

    [NotMapped]
    public string? usuarioApruebaCorreo { get; set; }





    //Implementacion Wilbert
    [NotMapped]
    public MdloDtos.VisitaMotonaveDetalle? VisitaMotonaveDetalle { get; set; }


    [NotMapped]
    public List<MdloDtos.LineaVisitaMotonaveBl>? ListaLineasVisitaMotonaveBl { get; set; }
    // #####


    [JsonPropertyName("BlAsociadoADeposito")]
    [NotMapped]
    public bool? blAsociadoDeposito { get; set; }

    //Propiedades para identificar


    public VisitaMotonaveBl() { }

    public VisitaMotonaveBl(
                        int VmblRowid,
                        int? VmblRowidVstaMtnveDtlle,
                        string? VmblNmro,
                        string? VmblCdgoUndadMdda,
                        int? VmblCntdad,
                        int? VmblTnldasMtrcas,
                        string? VmblEstdo,
                        string? VmblRta,
                        DateTime? VmblFchaCrgue,
                        DateTime? VmblFchaAprbcion,
                        string? VmblCdgoUsrioCrgue,
                        string? VmblCdgoUsrioAprbdo,
                        string? UnidadMedidaCodigo,
                        string? UnidadMedidaNombre,
                        string? UnidadMedidaEsGranel,
                        string? usuarioCreaCodigo,
                        string? usuarioCreaNombre,
                        string? usuarioCreaCorreo,
                        string? usuarioApruebaCodigo,
                        string? usuarioApruebaNombre,
                        string? usuarioApruebaCorreo
                             )
    {
        this.VmblRowid = VmblRowid;
        this.VmblRowidVstaMtnveDtlle = VmblRowidVstaMtnveDtlle;
        this.VmblNmro = VmblNmro;
        this.VmblCdgoUndadMdda = VmblCdgoUndadMdda;
        this.VmblCntdad = VmblCntdad;
        this.VmblTnldasMtrcas = VmblTnldasMtrcas;
        this.VmblEstdo = VmblEstdo;
        this.VmblRta = VmblRta;
        this.VmblFchaCrgue = VmblFchaCrgue;
        this.VmblFchaAprbcion = VmblFchaAprbcion;
        this.VmblCdgoUsrioCrgue = VmblCdgoUsrioCrgue;
        this.VmblCdgoUsrioAprbdo = VmblCdgoUsrioAprbdo;
        this.UnidadMedidaCodigo = UnidadMedidaCodigo;
        this.UnidadMedidaNombre = UnidadMedidaNombre;
        this.UnidadMedidaEsGranel = UnidadMedidaEsGranel;
        this.usuarioCreaCodigo = usuarioCreaCodigo;
        this.usuarioCreaNombre = usuarioCreaNombre;
        this.usuarioCreaCorreo = usuarioCreaCorreo;
        this.usuarioApruebaCodigo = usuarioApruebaCodigo;
        this.usuarioApruebaNombre = usuarioApruebaNombre;
        this.usuarioApruebaCorreo = usuarioApruebaCorreo;
    }

    public VisitaMotonaveBl(
                        int VmblRowid,
                        int? VmblRowidVstaMtnveDtlle,
                        int? VmblRowidStcionPrtriaDtlle,
                        string? VmblNmro,
                        string? VmblCdgoUndadMdda,
                        int? VmblCntdad,
                        int? VmblTnldasMtrcas,
                        string? VmblEstdo,
                        string? VmblRta,
                        DateTime? VmblFchaCrgue,
                        DateTime? VmblFchaAprbcion,
                        string? VmblCdgoUsrioCrgue,
                        string? VmblCdgoUsrioAprbdo,
                        string? UnidadMedidaCodigo,
                        string? UnidadMedidaNombre,
                        string? UnidadMedidaEsGranel,
                        string? usuarioCreaCodigo,
                        string? usuarioCreaNombre,
                        string? usuarioCreaCorreo,
                        string? usuarioApruebaCodigo,
                        string? usuarioApruebaNombre,
                        string? usuarioApruebaCorreo
                             )
    {
        this.VmblRowid = VmblRowid;
        this.VmblRowidVstaMtnveDtlle = VmblRowidVstaMtnveDtlle;
        this.VmblRowidStcionPrtriaDtlle = VmblRowidStcionPrtriaDtlle;
        this.VmblNmro = VmblNmro;
        this.VmblCdgoUndadMdda = VmblCdgoUndadMdda;
        this.VmblCntdad = VmblCntdad;
        this.VmblTnldasMtrcas = VmblTnldasMtrcas;
        this.VmblEstdo = VmblEstdo;
        this.VmblRta = VmblRta;
        this.VmblFchaCrgue = VmblFchaCrgue;
        this.VmblFchaAprbcion = VmblFchaAprbcion;
        this.VmblCdgoUsrioCrgue = VmblCdgoUsrioCrgue;
        this.VmblCdgoUsrioAprbdo = VmblCdgoUsrioAprbdo;
        this.UnidadMedidaCodigo = UnidadMedidaCodigo;
        this.UnidadMedidaNombre = UnidadMedidaNombre;
        this.UnidadMedidaEsGranel = UnidadMedidaEsGranel;
        this.usuarioCreaCodigo = usuarioCreaCodigo;
        this.usuarioCreaNombre = usuarioCreaNombre;
        this.usuarioCreaCorreo = usuarioCreaCorreo;
        this.usuarioApruebaCodigo = usuarioApruebaCodigo;
        this.usuarioApruebaNombre = usuarioApruebaNombre;
        this.usuarioApruebaCorreo = usuarioApruebaCorreo;
    }
}
