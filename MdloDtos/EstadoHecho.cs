using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class EstadoHecho
{
    [Key]
    [JsonPropertyName("IdEstadohecho")]
    public int EhRowid { get; set; }

    [JsonPropertyName("Observacion")]
    [StringLength(250)]
    public string? EhObsrvcion { get; set; } = null!;

    [JsonPropertyName("FechaCreacion")]
    public DateTime EhFchaCrcion { get; set; }

    [JsonPropertyName("FechaInicio")]
    public DateTime EhFchaIncio { get; set; }

    [JsonPropertyName("FechaFin")]
    public DateTime EhFchaFin { get; set; }

    [JsonPropertyName("Escootilla")]
    public int? EhEsctlla { get; set; }

    [JsonPropertyName("CodigoEvento")]
    public int EhRowidEvnto { get; set; }

    [JsonPropertyName("CodigoEquipo")]
    public int? EhRowidEqpo { get; set; }

    [JsonPropertyName("CodigoSector")]
    public int EhRowidSctor { get; set; }

    [JsonPropertyName("codigoZonaCD")]
    public int? EhRowidZnaCd { get; set; }

    [JsonPropertyName("codigoVM")]
    public int? EhRowidVstaMtnve { get; set; }

    [JsonPropertyName("CodigoUsuario")]
    [StringLength(15)]
    public string? EhCdgoUsrio { get; set; }

    [JsonPropertyName("Estado")]
    [StringLength(2)]
    public string? EhEstdo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? EhCdgoUsrioNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Equipo? EhRowidEqpoNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Evento? EhRowidEvntoNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Sector? EhRowidSctorNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonave? EhRowidVstaMtnveNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ZonaCd? EhRowidZnaCdNavigation { get; set; } = null!;

}