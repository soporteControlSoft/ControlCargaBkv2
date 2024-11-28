using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Sede
{
    [Key]
    [JsonPropertyName("IdSede")]
    public int? SeRowid { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string? SeCdgo { get; set; } = null!;

    [StringLength(15)]
    [JsonPropertyName("CodigoCompania")]
    public string? SeCdgoCia { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(60)]
    public string? SeNmbre { get; set; }

    [JsonPropertyName("Estado")]
    public bool? SeActvo { get; set; }

    public bool? SeDpstoAdnro { get; set; }

    [JsonPropertyName("CodigoDepositoAduanero")]
    [StringLength(15)]
    public string? SeCdgoDpstoAdnro { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? SeCdgoCiaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<ZonaCd> ZonaCds { get; set; } = new List<ZonaCd>();

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? CompaniaCodigo { get; set; }



    [NotMapped]
    public string? CompaniaNombre { get; set; }

    public Sede()
    {

    }

    public Sede(
                    int? SeRowid,
                    string? SeCdgo,
                    string? SeCdgoCia,
                    string? SeNmbre,
                    bool? SeActvo,
                    bool? SeDpstoAdnro,
                    string? SeCdgoDpstoAdnro,
                    string? CompaniaCodigo,
                    string? CompaniaNombre
                )
    {
        this.SeRowid = SeRowid;
        this.SeCdgo = SeCdgo;
        this.SeCdgoCia = SeCdgoCia;
        this.SeNmbre = SeNmbre;
        this.SeActvo = SeActvo;
        this.SeDpstoAdnro = SeDpstoAdnro;
        this.SeCdgoDpstoAdnro = SeCdgoDpstoAdnro;
        this.CompaniaCodigo = CompaniaCodigo;
        this.CompaniaNombre = CompaniaNombre;
    }
}
