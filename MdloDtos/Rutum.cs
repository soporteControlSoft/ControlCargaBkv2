using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class Rutum
{
    public int RuRowid { get; set; }

    public string RuNmbre { get; set; } = null!;

    public string? RuTpo { get; set; }

    public virtual ICollection<RutaAccione> RutaAcciones { get; set; } = new List<RutaAccione>();
}
