using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class TipoDocumentoDTO
{
    [Key]
    [JsonPropertyName("IdTipoDocumento")]
    public string? IdTipoDocumento { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; } = null!;

    [JsonPropertyName("Origen")]
    public string? Origen { get; set; } = null!;

    [JsonPropertyName("Asignar")]
    public string? Asignar { get; set; } = null!;

    [JsonPropertyName("Estado")]
    public bool? Estado { get; set; }

    [JsonPropertyName("EsObligatorio")]
    public bool? EsObligatorio { get; set; }


    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDocumento> VisitaMotonaveDocumentos { get; set; } = new List<VisitaMotonaveDocumento>();


    // Atributo creado de forma manual
    [NotMapped]
    [JsonPropertyName("BotonColor")]
    public string? BotonColor { get; set; }

    public TipoDocumentoDTO() { }

    public TipoDocumentoDTO(
                        string? IdTipoDocumento,
                        string? TdNmbre,
                        string? Origen,
                        string? Asignar,
                        bool? Estado,
                        bool? EsObligatorio,
                        string? BotonColor)
    {
        this.IdTipoDocumento = IdTipoDocumento;
        this.Nombre = Nombre;
        this.Origen = Origen;
        this.Asignar = Asignar;
        this.Estado = Estado;
        this.EsObligatorio = EsObligatorio;
        this.BotonColor = BotonColor;
    }
}
