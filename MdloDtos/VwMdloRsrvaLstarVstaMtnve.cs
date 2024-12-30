using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwMdloRsrvaLstarVstaMtnve
{
    public int VmRowid { get; set; }

    public string VmMotonaveCdgo { get; set; } = null!;

    public string? VmMotonaveNmbre { get; set; }

    public short VmScncia { get; set; }

    public string VmCdgoCia { get; set; } = null!;
}
