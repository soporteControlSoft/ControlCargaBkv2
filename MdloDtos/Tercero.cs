using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Tercero
{
    [Key]
    [JsonPropertyName("IdTercero")]
    public int? TeRowid { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoCompania")]
    public string? TeCdgoCia { get; set; } = null!;

    [StringLength(20)]
    [JsonPropertyName("Codigo")]
    public string? TeCdgo { get; set; } = null!;

    [StringLength(60)]
    [JsonPropertyName("Nombre")]
    public string? TeNmbre { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Identificacion")]
    public string? TeIdntfccion { get; set; }

    [JsonPropertyName("TipoIdentificacion")]
    public string? TeTpoIdntfccion { get; set; }

    [StringLength(1)]
    [JsonPropertyName("Dv")]
    public string? TeDv { get; set; }

    [StringLength(120)]
    [JsonPropertyName("Direccion")]
    public string? TeDrccion { get; set; }

    [StringLength(80)]
    [JsonPropertyName("Telefono")]
    public string? TeTlfno { get; set; }

    [StringLength(80)]
    [JsonPropertyName("Email")]
    public string? TeEmail { get; set; }

    [JsonPropertyName("Estado")]
    public bool? TeActvo { get; set; }

    [JsonPropertyName("EsCliente")]
    public bool? TeClnte { get; set; }

    [JsonPropertyName("EsParticular")]
    public bool? TePrtclar { get; set; }

    [JsonPropertyName("EsFuncionario")]
    public bool? TeFncnrio { get; set; }

    [JsonPropertyName("EsTrasnportadora")]
    public bool? TeTrnsprtdra { get; set; }

    [JsonPropertyName("EsAgenteMaritimo")]
    public bool? TeAgnteMrtmo { get; set; }

    [JsonPropertyName("EsVendedor")]
    public bool? TeVnddor { get; set; }

    [JsonPropertyName("EsOperadorPuerturario")]
    public bool? TeOprdorPrtrio { get; set; }

    [JsonPropertyName("EsManejoPropio")]
    public bool? TeMnjoPrpio { get; set; }

    [StringLength(80)]
    [JsonPropertyName("NombreContacto")]
    public string? TeNmbreCntcto { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoGrupoTercero")]
    public string? TeCdgoGrpoTrcro { get; set; }

    [JsonPropertyName("EsAgenciaAduana")]
    public bool? TeAgnciaAdna { get; set; }

    [JsonPropertyName("EsOperadorSecundario")]
    public bool? TeOprdorScndrio { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Conductor> Conductors { get; set; } = new List<Conductor>();


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito>? DepositoDeRowidTrcroFctrcionNavigations { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito>? DepositoDeRowidTrcroNavigations { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuarium>? SituacionPortuaria { get; set; } = new List<SituacionPortuarium>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuariaDetalle>? SituacionPortuariaDetalleSpdRowidOprdorPrtrioNavigations { get; set; } = new List<SituacionPortuariaDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuariaDetalle>? SituacionPortuariaDetalleSpdRowidTrcroNavigations { get; set; } = new List<SituacionPortuariaDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? TeCdgoCiaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual GrupoTercero? TeCdgoGrpoTrcroNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual TipoIdentificacion? TeTpoIdntfccionNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<TerceroCertificado> TerceroCertificados { get; set; } = new List<TerceroCertificado>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDetalle> VisitaMotonaveDetalles { get; set; } = new List<VisitaMotonaveDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? GrupoTerceroCodigo { get; set; }



    [NotMapped]
    public string? GrupoTerceroNombre { get; set; }




    public Tercero()
    {

    }

    public Tercero(
                    int? TeRowid,
                    string? TeCdgoCia,
                    string? TeCdgo,
                    string? TeNmbre,
                    string? TeIdntfccion,
                    string? TeTpoIdntfccion,
                    string? TeDv,
                    string? TeDrccion,
                    string? TeTlfno,
                    string? TeEmail,
                    bool? TeActvo,
                    bool? TeClnte,
                    bool? TePrtclar,
                    bool? TeFncnrio,
                    bool? TeTrnsprtdra,
                    bool? TeAgnteMrtmo,
                    bool? TeVnddor,
                    bool? TeOprdorPrtrio,
                    bool? TeMnjoPrpio,
                    string? TeNmbreCntcto,
                    string TeCdgoGrpoTrcro,
                    bool? TeAgnciaAdna,
                    bool? TeOprdorScndrio,
                    string? GrupoTerceroCodigo,
                    string? GrupoTerceroNombre
                    )
    {
        //Atributos tercero
        this.TeRowid = TeRowid;
        this.TeCdgoCia = TeCdgoCia;
        this.TeCdgo = TeCdgo;
        this.TeNmbre = TeNmbre;
        this.TeIdntfccion = TeIdntfccion;
        this.TeTpoIdntfccion = TeTpoIdntfccion;
        this.TeDv = TeDv;
        this.TeDrccion = TeDrccion;
        this.TeTlfno = TeTlfno;
        this.TeEmail = TeEmail;
        this.TeActvo = TeActvo;
        this.TeClnte = TeClnte;
        this.TePrtclar = TePrtclar;
        this.TeFncnrio = TeFncnrio;
        this.TeTrnsprtdra = TeTrnsprtdra;
        this.TeAgnteMrtmo = TeAgnteMrtmo;
        this.TeVnddor = TeVnddor;
        this.TeOprdorPrtrio = TeOprdorPrtrio;
        this.TeMnjoPrpio = TeMnjoPrpio;
        this.TeNmbreCntcto = TeNmbreCntcto;
        this.TeCdgoGrpoTrcro = TeCdgoGrpoTrcro;
        this.TeAgnciaAdna = TeAgnciaAdna;
        this.TeOprdorScndrio = TeOprdorScndrio;

        //Atributos grupo a tercero
        this.GrupoTerceroCodigo = GrupoTerceroCodigo;
        this.GrupoTerceroNombre = GrupoTerceroNombre;
    }
    [NotMapped]
    public virtual ICollection<SolicitudRetiroAutorizacion> SolicitudRetiroAutorizacions { get; set; } = new List<SolicitudRetiroAutorizacion>();
    [NotMapped]
    public virtual ICollection<SolicitudRetiroTransportadora> SolicitudRetiroTransportadoras { get; set; } = new List<SolicitudRetiroTransportadora>();
}
