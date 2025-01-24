using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VisitaMotonaveBl1DTO
{
    [Key]
    [JsonPropertyName("IdMotonaveBL1")]
    public int? IdMotonaveBL1 { get; set; }

    [JsonPropertyName("IdVisitaMotonaveBl")]
    public int? IdVisitaMotonaveBl { get; set; }

    [JsonPropertyName("NumeroLevante")]
    public string? NumeroLevante { get; set; } = null!;

    [JsonPropertyName("NumeroLinea")]
    public int? NumeroLinea { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonaveBl? Vmbl1RowidVstaMtnveBlNavigation { get; set; } = null!;
}
