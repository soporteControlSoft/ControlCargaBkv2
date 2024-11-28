using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class TipoDocumento
{
    [Key]
    [JsonPropertyName("IdTipoDocumento")]
    public string? TdCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    public string? TdNmbre { get; set; } = null!;

    [JsonPropertyName("Origen")]
    public string? TdOrgen { get; set; } = null!;

    [JsonPropertyName("Asignar")]
    public string? TdNmbreAAsgnar { get; set; } = null!;

    [JsonPropertyName("Estado")]
    public bool? TdActvo { get; set; }

    [JsonPropertyName("EsObligatorio")]
    public bool? TdOblgtrio { get; set; }


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDocumento> VisitaMotonaveDocumentos { get; set; } = new List<VisitaMotonaveDocumento>();


    // Atributo creado de forma manual
    [NotMapped]
    [JsonPropertyName("BotonColor")]
    public string? BotonColor { get; set; }

    public TipoDocumento() { }

    public TipoDocumento(
                        string? TdCdgo,
                        string? TdNmbre,
                        string? TdOrgen,
                        string? TdNmbreAAsgnar,
                        bool? TdActvo,
                        bool? TdOblgtrio,
                        string? BotonColor)
    {
        this.TdCdgo = TdCdgo;
        this.TdNmbre = TdNmbre;
        this.TdOrgen = TdOrgen;
        this.TdNmbreAAsgnar = TdNmbreAAsgnar;
        this.TdActvo = TdActvo;
        this.TdOblgtrio = TdOblgtrio;
        this.BotonColor = BotonColor;
    }
}
