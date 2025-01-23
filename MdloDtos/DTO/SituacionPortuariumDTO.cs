using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SituacionPortuariumDTO
{
    [Key]
    [JsonPropertyName("IdSituacion")]
    public int? IdSituacion { get; set; }

    [JsonPropertyName("CodigoMotonave")]
    public string? CodigoMotonave { get; set; } = null!;

    [JsonPropertyName("IdZona")]
    public int? IdZona { get; set; }

    [JsonPropertyName("CodigoTerminalMaritimo")]
    public string? CodigoTerminalMaritimo { get; set; }

    [JsonPropertyName("FechaArribo")]
    public DateTime? FechaArribo { get; set; }

    [JsonPropertyName("FechaAtraque")]
    public DateTime? FechaAtraque { get; set; }

    [JsonPropertyName("FechaZarpe")]
    public DateTime? FechaZarpe { get; set; }

    [JsonPropertyName("FechaCreacion")]
    public DateTime? FechaCreacion { get; set; }

    [JsonPropertyName("CodigoEstadoMotonave")]
    public string? CodigoEstadoMotonave { get; set; } = null!;

    [JsonPropertyName("CodigoPais")]
    public string? CodigoPais { get; set; } = null!;

    [JsonPropertyName("IdAgenteMaritimo")]
    public int? IdAgenteMaritimo { get; set; }

    [JsonPropertyName("CodigoUsuarioCreador")]
    public string? CodigoUsuarioCreador { get; set; } = null!;

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

    public SituacionPortuariumDTO(int SpRowid, string SpCdgoMtnve, int? SpRowidZnaCd, string SpCdgoTrmnalMrtmo,
        DateTime? SpFchaArrbo, DateTime? SpFchaAtrque, DateTime? SpFchaZrpe, DateTime? SpFchaCrcion,
        string SpCdgoEstdoMtnve, string SpCdgoPais, int SpRowidAgnteNvro,
        string NombreZona, string NombreTerminal, string NombreEstado, String NombrePais, string DescripcionMotonave
        , string NombreAgente)
    {
        this.IdSituacion = SpRowid;
        this.CodigoMotonave = SpCdgoMtnve;
        this.IdZona = SpRowidZnaCd;
        this.CodigoTerminalMaritimo = SpCdgoTrmnalMrtmo;
        this.FechaArribo = SpFchaArrbo;
        this.FechaAtraque = SpFchaAtrque;
        this.FechaZarpe = SpFchaZrpe;
        this.FechaCreacion = SpFchaCrcion;
        this.CodigoEstadoMotonave = SpCdgoEstdoMtnve;
        this.CodigoPais = SpCdgoPais;
        this.IdAgenteMaritimo = SpRowidAgnteNvro;
        this.NombreZona = NombreZona;
        this.NombreTerminal = NombreTerminal;
        this.DescripcionMotonave = DescripcionMotonave;
        this.NombreEstado = NombreEstado;
        this.NombrePais = NombrePais;
        this.NombreAgente = NombreAgente;
    }

    public SituacionPortuariumDTO(int SpRowid, string SpCdgoMtnve, int? SpRowidZnaCd, string SpCdgoTrmnalMrtmo,
      DateTime? SpFchaArrbo, DateTime? SpFchaAtrque, DateTime? SpFchaZrpe, DateTime? SpFchaCrcion,
      string SpCdgoEstdoMtnve, string SpCdgoPais, int SpRowidAgnteNvro,
      string NombreZona, string NombreTerminal, string NombreEstado, String NombrePais, string DescripcionMotonave
      , string NombreAgente, bool? CrearVisitaMotonave, int? CodigoVisitaMotonave)
    {
        this.IdSituacion = SpRowid;
        this.CodigoMotonave = SpCdgoMtnve;
        this.IdZona = SpRowidZnaCd;
        this.CodigoTerminalMaritimo = SpCdgoTrmnalMrtmo;
        this.FechaArribo = SpFchaArrbo;
        this.FechaAtraque = SpFchaAtrque;
        this.FechaZarpe = SpFchaZrpe;
        this.FechaCreacion = SpFchaCrcion;
        this.CodigoEstadoMotonave = SpCdgoEstdoMtnve;
        this.CodigoPais = SpCdgoPais;
        this.IdAgenteMaritimo = SpRowidAgnteNvro;
        this.NombreZona = NombreZona;
        this.NombreTerminal = NombreTerminal;
        this.DescripcionMotonave = DescripcionMotonave;
        this.NombreEstado = NombreEstado;
        this.NombrePais = NombrePais;
        this.NombreAgente = NombreAgente;
        this.CrearVisitaMotonave = CrearVisitaMotonave;
        this.CodigoVisitaMotonave = CodigoVisitaMotonave;
    }

    public SituacionPortuariumDTO() { }
    public SituacionPortuariumDTO(int SpRowid)
    {
        this.IdSituacion = SpRowid;
    }
}
