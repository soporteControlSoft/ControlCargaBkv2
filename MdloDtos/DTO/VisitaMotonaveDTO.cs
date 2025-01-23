using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VisitaMotonaveDTO
{
    [Key]
    [JsonPropertyName("IdVisita")]
    public int IdVisita { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? CodigoCompania { get; set; } = null!;

    [JsonPropertyName("CodigoMotonave")]
    public string? CodigoMotonave { get; set; } = null!;

    [JsonPropertyName("FechaCreacion")]
    public DateTime? FechaCreacion { get; set; }

    [JsonPropertyName("FechaInicioOperacion")]
    public DateTime? FechaInicioOperacion { get; set; }

    [JsonPropertyName("FechaFinOperacion")]
    public DateTime? FechaFinOperacion { get; set; }

    [JsonPropertyName("FechaFondeo")]
    public DateTime? FechaFondeo { get; set; }

    [JsonPropertyName("Secuencia")]
    public short? Secuencia { get; set; }

    [JsonPropertyName("Descripcion")]
    public string? Descripcion { get; set; } = null!;

    [JsonPropertyName("IdVendendor")]
    public int? IdVendendor { get; set; }

    [JsonPropertyName("IdZonaAlterno")]
    public int? IdZonaAlterno { get; set; }

    [JsonPropertyName("IdSituacion")]
    public int? IdSituacion { get; set; }

    [JsonPropertyName("PrestadoresServicios")]
    public string? PrestadoresServicios { get; set; }

    [JsonPropertyName("CodigoUsuarioCreador")]
    public string? CodigoUsuarioCreador { get; set; } = null!;

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


    public VisitaMotonaveDTO() { }


    public VisitaMotonaveDTO(int VmRowid, string VmCdgoCia, string VmCdgoMtnve,
        DateTime? VmFchaCrcion, DateTime? VmFchaIncioOprcion,
        DateTime? VmFchaFinOprcion, DateTime? VmFchaFndeo, short? VmScncia, string VmDscrpcion,
        int VmRowidVnddor, int VmRowidZnaCdAltrno, int? VmRowidStcionPrtria, string NombreMotonave,
        string NombreCompania, string NombreAgente, string NombreVendedor, string NombrePuertoOrigen,
        string NombreZona, string NombreZonaAlterna, string NombreTerminal
        )
    {
        this.IdVisita = VmRowid;
        this.CodigoCompania = VmCdgoCia;
        this.CodigoMotonave = VmCdgoMtnve;
        this.NombreMotonave = NombreMotonave;
        this.FechaCreacion = VmFchaCrcion;
        this.FechaInicioOperacion = VmFchaIncioOprcion;
        this.FechaFinOperacion = VmFchaFinOprcion;
        this.FechaFinOperacion = VmFchaFinOprcion;
        this.FechaFondeo = VmFchaFndeo;
        this.Secuencia = VmScncia;
        this.Descripcion = VmDscrpcion;
        this.IdVendendor = VmRowidVnddor;
        this.IdZonaAlterno = VmRowidZnaCdAltrno;
        this.IdSituacion = VmRowidStcionPrtria;
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
