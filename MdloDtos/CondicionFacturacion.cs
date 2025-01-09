using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class CondicionFacturacion
{
    public string CfCdgo { get; set; } = null!;

    public string? CfNmbre { get; set; }

    public string? CfFchaBse { get; set; }

    public virtual ICollection<Deposito> Depositos { get; set; } = new List<Deposito>();
}
