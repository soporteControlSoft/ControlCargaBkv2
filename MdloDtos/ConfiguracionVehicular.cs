using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class ConfiguracionVehicular
{
    [Key]
    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? CvRowid { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string? CvCdgo { get; set; } = null!;

    [StringLength(60)]
    [JsonPropertyName("Nombre")]
    public string? CvNmbre { get; set; } = null!;

    [JsonPropertyName("PesoMaximo")]
    public int? CvPsoMxmo { get; set; }

    [JsonPropertyName("Tolerancia")]
    public int? CvTlrncia { get; set; }

    [JsonPropertyName("CodigoCompania")]
    [StringLength(15)]
    public string? CvCdgoCia { get; set; } = null!;

    [JsonPropertyName("Estado")]
    public bool? CvActvo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Companium? CvCdgoCiaNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? CompaniaCodigo { get; set; }



    [NotMapped]
    public string? CompaniaNombre { get; set; }

    public ConfiguracionVehicular()
    {

    }

    public ConfiguracionVehicular(
                    int? CvRowid,
                    string? CvCdgo,
                    string? CvNmbre,
                    int? CvPsoMxmo,
                    int? CvTlrncia,
                    string? CvCdgoCia,
                    bool? CvActvo,
                    string? CompaniaCodigo,
                    string? CompaniaNombre
                )
    {
        this.CvRowid = CvRowid;
        this.CvCdgo = CvCdgo;
        this.CvNmbre = CvNmbre;
        this.CvPsoMxmo = CvPsoMxmo;
        this.CvTlrncia = CvTlrncia;
        this.CvCdgoCia = CvCdgoCia;
        this.CvActvo = CvActvo;
        this.CompaniaCodigo = CompaniaCodigo;
        this.CompaniaNombre = CompaniaNombre;
    }

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<Orden>? Ordens { get; set; } = new List<Orden>();
}
