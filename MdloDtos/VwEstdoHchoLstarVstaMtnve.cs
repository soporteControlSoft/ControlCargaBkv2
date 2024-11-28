using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwEstdoHchoLstarVstaMtnve
{
    public string SpCdgoMtnve { get; set; } = null!;

    public int SpRowid { get; set; }

    public DateTime? SpFchaArrbo { get; set; }

    public DateTime? SpFchaAtrque { get; set; }

    public DateTime? SpFchaZrpe { get; set; }

    public DateTime? SpFchaCrcion { get; set; }

    public string SpCdgoEstdoMtnve { get; set; } = null!;

    public int? VmRowid { get; set; }

    public short VmScncia { get; set; }

    public string VmDscrpcion { get; set; } = null!;

    public short? MoCntdadEsctllas { get; set; }

    public string EmCdgo { get; set; } = null!;

    public string EmNmbre { get; set; } = null!;
}
