using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwMdloRsrvaLstarSlctudRtroMdal
{
    public int SrRowid { get; set; }

    public string SrCia { get; set; } = null!;

    public string SrCdgo { get; set; } = null!;

    public int DeRowid { get; set; }

    public string DeCia { get; set; } = null!;

    public string DeCdgo { get; set; } = null!;

    public string DeEstdo { get; set; } = null!;

    public int SrtRowidTrnsprtdra { get; set; }

    public int? SrtAutrzdoKlos { get; set; }

    public int? SrtAutrzdoUnddes { get; set; }

    public int? SrtDspchdoKlos { get; set; }

    public int? SrtDspchdoUnddes { get; set; }

    public bool? SrtActva { get; set; }
}
