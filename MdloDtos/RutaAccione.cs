using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class RutaAccione
{
    public int RaRowid { get; set; }

    public int RaRowidRta { get; set; }

    public string RaAccnes { get; set; } = null!;

    public virtual Rutum RaRowidRtaNavigation { get; set; } = null!;
}
