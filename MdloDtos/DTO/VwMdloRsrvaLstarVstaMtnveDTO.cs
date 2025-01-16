using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VwMdloRsrvaLstarVstaMtnveDTO
{
    [Key]
    [JsonPropertyName("IdVisitaMotonave")]
    public int IdVisitaMotonave { get; set; }

    [JsonPropertyName("CodigoMotonave")]
    public string CodigoMotonave { get; set; } = null!;

    [JsonPropertyName("NombreMotonave")]
    public string? NombreMotonave { get; set; }

    [JsonPropertyName("Secuencia")]
    public short Secuencia { get; set; }

    [JsonPropertyName("CodigoCompaniaVisitaMotonave")]
    public string CodigoCompaniaVisitaMotonave { get; set; } = null!;
}
