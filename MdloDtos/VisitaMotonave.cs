using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VisitaMotonave
{
    [Key]
    [JsonPropertyName("IdVisita")]
    public int VmRowid { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? VmCdgoCia { get; set; } = null!;

    [JsonPropertyName("CodigoMotonave")]
    public string? VmCdgoMtnve { get; set; } = null!;

    [JsonPropertyName("FechaCreacion")]
    public DateTime? VmFchaCrcion { get; set; }

    [JsonPropertyName("FechaInicioOperacion")]
    public DateTime? VmFchaIncioOprcion { get; set; }

    [JsonPropertyName("FechaFinOperacion")]
    public DateTime? VmFchaFinOprcion { get; set; }

    [JsonPropertyName("FechaFondeo")]
    public DateTime? VmFchaFndeo { get; set; }

    [JsonPropertyName("Secuencia")]
    public short? VmScncia { get; set; }

    [JsonPropertyName("Descripcion")]
    public string? VmDscrpcion { get; set; } = null!;

    [JsonPropertyName("IdVendendor")]
    public int? VmRowidVnddor { get; set; }

    [JsonPropertyName("IdZonaAlterno")]
    public int? VmRowidZnaCdAltrno { get; set; }

    [JsonPropertyName("IdSituacion")]
    public int? VmRowidStcionPrtria { get; set; }

    [JsonPropertyName("PrestadoresServicios")]
    public string? VmRowidsPrstdresSrvcios { get; set; }

    [JsonPropertyName("CodigoUsuarioCreador")]
    public string? VmCdgoUsrioCrea { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveComentario> VisitaMotonaveComentarios { get; set; } = new List<VisitaMotonaveComentario>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDetalle> VisitaMotonaveDetalles { get; set; } = new List<VisitaMotonaveDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDocumento> VisitaMotonaveDocumentos { get; set; } = new List<VisitaMotonaveDocumento>();
    
    //[JsonIgnore]
    [NotMapped]
    public virtual Companium? VmCdgoCiaNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual Motonave? VmCdgoMtnveNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual Usuario? VmCdgoUsrioCreaNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual SituacionPortuarium? VmRowidStcionPrtriaNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual Tercero? VmRowidVnddorNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual ZonaCd? VmRowidZnaCdAltrnoNavigation { get; set; }

    //Atributos creados de forma manual

    [NotMapped]
    public string? NombreMotonave { get; set; }

    [NotMapped]
    public string? NombreCompania { get; set; }


    [NotMapped]
    public string? NombreAgente { get; set; }

    [NotMapped]
    public string? NombreVendedor { get; set; }

    [NotMapped]
    public string? NombrePuertoOrigen { get; set; }

    [NotMapped]
    public string? NombreZona { get; set; }
    [NotMapped]

    public string? NombreZonaAlterna { get; set; }


    [NotMapped]
    public string? NombreTerminal { get; set; }


    public VisitaMotonave() { }


    public VisitaMotonave(int VmRowid, string VmCdgoCia, string VmCdgoMtnve,
        DateTime? VmFchaCrcion, DateTime? VmFchaIncioOprcion,
        DateTime? VmFchaFinOprcion, DateTime? VmFchaFndeo, short? VmScncia, string VmDscrpcion,
        int VmRowidVnddor, int VmRowidZnaCdAltrno, int? VmRowidStcionPrtria, string NombreMotonave,
        string NombreCompania, string NombreAgente, string NombreVendedor, string NombrePuertoOrigen,
        string NombreZona, string NombreZonaAlterna, string NombreTerminal
        )
    {
        this.VmRowid = VmRowid;
        this.VmCdgoCia = VmCdgoCia;
        this.VmCdgoMtnve = VmCdgoMtnve;
        this.NombreMotonave = NombreMotonave;
        this.VmFchaCrcion = VmFchaCrcion;
        this.VmFchaIncioOprcion = VmFchaIncioOprcion;
        this.VmFchaFinOprcion = VmFchaFinOprcion;
        this.VmFchaFinOprcion = VmFchaFinOprcion;
        this.VmFchaFndeo = VmFchaFndeo;
        this.VmScncia = VmScncia;
        this.VmDscrpcion = VmDscrpcion;
        this.VmRowidVnddor = VmRowidVnddor;
        this.VmRowidZnaCdAltrno = VmRowidZnaCdAltrno;
        this.VmRowidStcionPrtria = VmRowidStcionPrtria;
        this.NombreMotonave = NombreMotonave;
        this.NombreCompania = NombreCompania;
        this.NombreAgente = NombreAgente;
        this.NombreVendedor = NombreVendedor;
        this.NombrePuertoOrigen = NombrePuertoOrigen;
        this.NombreZona = NombreZona;
        this.NombreZonaAlterna = NombreZonaAlterna;
        this.NombreTerminal = NombreTerminal;
    }
    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();
}
