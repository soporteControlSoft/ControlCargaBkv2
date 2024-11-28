using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class DepositoBl
{
    [JsonPropertyName("Id")]
    public int? DblRowid { get; set; }

    [JsonPropertyName("IdDeposito")]
    public int? DblRowidDpsto { get; set; }

    [JsonPropertyName("IdVisitaMotonaveBl")]
    public int? DblRowidVstaMtnveBl { get; set; }

    [JsonPropertyName("DepositoNavegacion")]
    public virtual Deposito? DblRowidDpstoNavigation { get; set; } = null!;

    [JsonPropertyName("VisitaMotonaveBLNavegacion")]

    public virtual VisitaMotonaveBl? DblRowidVstaMtnveBlNavigation { get; set; } = null!;
}
