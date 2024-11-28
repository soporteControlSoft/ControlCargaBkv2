using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SituacionPortuarium
{
    [Key]
    [JsonPropertyName("IdSituacion")]
    public int? SpRowid { get; set; }

    [JsonPropertyName("CodigoMotonave")]
    public string? SpCdgoMtnve { get; set; } = null!;

    [JsonPropertyName("IdZona")]
    public int? SpRowidZnaCd { get; set; }

    [JsonPropertyName("CodigoTerminalMaritimo")]
    public string? SpCdgoTrmnalMrtmo { get; set; }

    [JsonPropertyName("FechaArribo")]
    public DateTime? SpFchaArrbo { get; set; }

    [JsonPropertyName("FechaAtraque")]
    public DateTime? SpFchaAtrque { get; set; }

    [JsonPropertyName("FechaZarpe")]
    public DateTime? SpFchaZrpe { get; set; }

    [JsonPropertyName("FechaCreacion")]
    public DateTime? SpFchaCrcion { get; set; }

    [JsonPropertyName("CodigoEstadoMotonave")]
    public string? SpCdgoEstdoMtnve { get; set; } = null!;

    [JsonPropertyName("CodigoPais")]
    public string? SpCdgoPais { get; set; } = null!;

    [JsonPropertyName("IdAgenteMaritimo")]
    public int? SpRowidAgnteNvro { get; set; }

    [JsonPropertyName("CodigoUsuarioCreador")]
    public string? SpCdgoUsrioCrea { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SituacionPortuariaDetalle> SituacionPortuariaDetalles { get; set; } = new List<SituacionPortuariaDetalle>();

    [JsonIgnore]
    [NotMapped]
    public virtual EstadoMotonave? SpCdgoEstdoMtnveNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual Motonave? SpCdgoMtnveNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual Pai? SpCdgoPaisNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual TerminalMaritimo? SpCdgoTrmnalMrtmoNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual Usuario? SpCdgoUsrioCreaNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual Tercero? SpRowidAgnteNvroNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual ZonaCd? SpRowidZnaCdNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonave> VisitaMotonaves { get; set; } = new List<VisitaMotonave>();

    /// <summary>
    /// Propiedad implementadas manualmente.
    /// </summary>
    [NotMapped]
    public string? NombreZona { get; set; }

    [NotMapped]
    public string? NombreTerminal { get; set; }

    [NotMapped]
    public string? NombreEstado { get; set; }

    [NotMapped]
    public string? NombrePais { get; set; }

    [NotMapped]
    public string? DescripcionMotonave { get; set; }

    [NotMapped]
    public string? NombreAgente { get; set; }


    [NotMapped]
    public bool? CrearVisitaMotonave { get; set; }

    [NotMapped]
    public int? CodigoVisitaMotonave { get; set; }

    public SituacionPortuarium(int SpRowid, string SpCdgoMtnve, int? SpRowidZnaCd, string SpCdgoTrmnalMrtmo,
        DateTime? SpFchaArrbo, DateTime? SpFchaAtrque, DateTime? SpFchaZrpe, DateTime? SpFchaCrcion,
        string SpCdgoEstdoMtnve, string SpCdgoPais, int SpRowidAgnteNvro,
        string NombreZona, string NombreTerminal, string NombreEstado, String NombrePais, string DescripcionMotonave
        , string NombreAgente)
    {
        this.SpRowid = SpRowid;
        this.SpCdgoMtnve = SpCdgoMtnve;
        this.SpRowidZnaCd = SpRowidZnaCd;
        this.SpCdgoTrmnalMrtmo = SpCdgoTrmnalMrtmo;
        this.SpFchaArrbo = SpFchaArrbo;
        this.SpFchaAtrque = SpFchaAtrque;
        this.SpFchaZrpe = SpFchaZrpe;
        this.SpFchaCrcion = SpFchaCrcion;
        this.SpCdgoEstdoMtnve = SpCdgoEstdoMtnve;
        this.SpCdgoPais = SpCdgoPais;
        this.SpRowidAgnteNvro = SpRowidAgnteNvro;
        this.NombreZona = NombreZona;
        this.NombreTerminal = NombreTerminal;
        this.DescripcionMotonave = DescripcionMotonave;
        this.NombreEstado = NombreEstado;
        this.NombrePais = NombrePais;
        this.NombreAgente = NombreAgente;
    }

    public SituacionPortuarium(int SpRowid, string SpCdgoMtnve, int? SpRowidZnaCd, string SpCdgoTrmnalMrtmo,
      DateTime? SpFchaArrbo, DateTime? SpFchaAtrque, DateTime? SpFchaZrpe, DateTime? SpFchaCrcion,
      string SpCdgoEstdoMtnve, string SpCdgoPais, int SpRowidAgnteNvro,
      string NombreZona, string NombreTerminal, string NombreEstado, String NombrePais, string DescripcionMotonave
      , string NombreAgente, bool? CrearVisitaMotonave, int? CodigoVisitaMotonave)
    {
        this.SpRowid = SpRowid;
        this.SpCdgoMtnve = SpCdgoMtnve;
        this.SpRowidZnaCd = SpRowidZnaCd;
        this.SpCdgoTrmnalMrtmo = SpCdgoTrmnalMrtmo;
        this.SpFchaArrbo = SpFchaArrbo;
        this.SpFchaAtrque = SpFchaAtrque;
        this.SpFchaZrpe = SpFchaZrpe;
        this.SpFchaCrcion = SpFchaCrcion;
        this.SpCdgoEstdoMtnve = SpCdgoEstdoMtnve;
        this.SpCdgoPais = SpCdgoPais;
        this.SpRowidAgnteNvro = SpRowidAgnteNvro;
        this.NombreZona = NombreZona;
        this.NombreTerminal = NombreTerminal;
        this.DescripcionMotonave = DescripcionMotonave;
        this.NombreEstado = NombreEstado;
        this.NombrePais = NombrePais;
        this.NombreAgente = NombreAgente;
        this.CrearVisitaMotonave = CrearVisitaMotonave;
        this.CodigoVisitaMotonave = CodigoVisitaMotonave;
    }

    public SituacionPortuarium() { }
    public SituacionPortuarium(int SpRowid)
    {
        this.SpRowid = SpRowid;
    }
}
