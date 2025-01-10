using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwMdloRsrvaLstarDpsto
{
    public int DeRowid { get; set; }

    public string DeCia { get; set; } = null!;

    public string DeCdgo { get; set; } = null!;

    public bool DeEsSubdpsto { get; set; }

    public int VmRowid { get; set; }
}
