using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwPrueba
{
    public int CiRowid { get; set; }

    public string CiCdgo { get; set; } = null!;

    public string? CiNmbre { get; set; }

    public int CiRowidDprtmnto { get; set; }
}
