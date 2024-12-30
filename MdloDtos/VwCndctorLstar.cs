using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwCndctorLstar
{
    public string CnIdntfccion { get; set; } = null!;

    public string CnNmbre { get; set; } = null!;

    public byte[]? CnFeatures { get; set; }

    public string? CnVhclo { get; set; }

    public int? CnRowidTrnsprtdra { get; set; }

    public DateTime CnFchaRgstro { get; set; }

    public string? CnCdgoUsrioEnrlo { get; set; }

    public DateTime? CnFchaEnrlmnto { get; set; }

    public string? CnMvil { get; set; }

    public string? CnNmroLcncia { get; set; }

    public string? CnTpoLcncia { get; set; }

    public DateTime? CnFchaVncmntoLcncia { get; set; }

    public bool? CnActvo { get; set; }

    public bool? CnUrbno { get; set; }
}
