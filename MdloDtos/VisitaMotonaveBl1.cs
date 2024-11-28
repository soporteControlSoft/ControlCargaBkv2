using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VisitaMotonaveBl1
{
    [Key]
    [JsonPropertyName("IdMotonaveBL1")]
    public int? Vmbl1Rowid { get; set; }

    [JsonPropertyName("IdVisitaMotonaveBl")]
    public int? Vmbl1RowidVstaMtnveBl { get; set; }

    [JsonPropertyName("NumeroLevante")]
    public string? Vmbl1NmroLvnte { get; set; } = null!;

    [JsonPropertyName("NumeroLinea")]
    public int? Vmbl1Lnea { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonaveBl? Vmbl1RowidVstaMtnveBlNavigation { get; set; } = null!;
}
