using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VisitaMotonaveBlDTO
{
    [Key]
    [JsonPropertyName("IdMotonaveBL")]
    public int IdMotonaveBL { get; set; }

    [JsonPropertyName("IdVisitaMotonaveDetalle")]
    public int? IdVisitaMotonaveDetalle { get; set; }

    [JsonPropertyName("NumeroBL")]
    [StringLength(20)]
    public string? NumeroBL { get; set; } = null!;

    [JsonPropertyName("CodigoUnidadMedida")]
    [StringLength(15)]
    public string? CodigoUnidadMedida { get; set; } = null!;

    [JsonPropertyName("Cantidad")]
    public int? Cantidad { get; set; }

    [JsonPropertyName("ToneladasMetricas")]
    public int? ToneladasMetricas { get; set; }

    [JsonPropertyName("Estado")]
    public string? Estado { get; set; } = null!;

    [JsonPropertyName("RutaDocumento")]
    [StringLength(300)]
    public string? RutaDocumento { get; set; } = null!;

    [JsonPropertyName("FechaCargue")]
    public DateTime? FechaCargue { get; set; }

    [JsonPropertyName("FechaAprobacion")]
    public DateTime? FechaAprobacion { get; set; }

    [JsonPropertyName("CodigoUsuarioCargue")]
    [StringLength(15)]
    public string? CodigoUsuarioCargue { get; set; } = null!;

    [JsonPropertyName("CodigoUsuarioAprobacion")]
    [StringLength(15)]
    public string? CodigoUsuarioAprobacion { get; set; }

    [JsonPropertyName("IdSituacionPortuariaDetalle")]
    public int? IdSituacionPortuariaDetalle { get; set; }

    [JsonPropertyName("Escotilla")]
    public int? Escotilla { get; set; }

    [JsonPropertyName("KiloCompromisoDirecto")]
    public int? KiloCompromisoDirecto { get; set; }

    [JsonPropertyName("KiloCompromisoAlmacenar")]
    public int? KiloCompromisoAlmacenar { get; set; }

    [JsonPropertyName("IdsSedes")]
    public string? IdsSedes { get; set; }

    [JsonPropertyName("RequisitoCliente")]
    public string? RequisitoCliente { get; set; }

    [JsonPropertyName("ComentariosRechazos")]
    public string? ComentariosRechazos { get; set; }

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
    public bool? BlAsociadoADeposito { get; set; }

    //Propiedades para identificar


    public VisitaMotonaveBlDTO() { }

    public VisitaMotonaveBlDTO(
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
        this.IdMotonaveBL = VmblRowid;
        this.IdVisitaMotonaveDetalle = VmblRowidVstaMtnveDtlle;
        this.NumeroBL = VmblNmro;
        this.CodigoUnidadMedida = VmblCdgoUndadMdda;
        this.Cantidad = VmblCntdad;
        this.ToneladasMetricas = VmblTnldasMtrcas;
        this.Estado = VmblEstdo;
        this.RutaDocumento = VmblRta;
        this.FechaCargue = VmblFchaCrgue;
        this.FechaAprobacion = VmblFchaAprbcion;
        this.CodigoUsuarioCargue = VmblCdgoUsrioCrgue;
        this.CodigoUsuarioAprobacion = VmblCdgoUsrioAprbdo;
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

    public VisitaMotonaveBlDTO(
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
        this.IdMotonaveBL = VmblRowid;
        this.IdVisitaMotonaveDetalle = VmblRowidVstaMtnveDtlle;
        this.IdSituacionPortuariaDetalle = VmblRowidStcionPrtriaDtlle;
        this.NumeroBL = VmblNmro;
        this.CodigoUnidadMedida = VmblCdgoUndadMdda;
        this.Cantidad = VmblCntdad;
        this.ToneladasMetricas = VmblTnldasMtrcas;
        this.Estado = VmblEstdo;
        this.RutaDocumento = VmblRta;
        this.FechaCargue = VmblFchaCrgue;
        this.FechaAprobacion = VmblFchaAprbcion;
        this.CodigoUsuarioCargue = VmblCdgoUsrioCrgue;
        this.CodigoUsuarioAprobacion = VmblCdgoUsrioAprbdo;
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
