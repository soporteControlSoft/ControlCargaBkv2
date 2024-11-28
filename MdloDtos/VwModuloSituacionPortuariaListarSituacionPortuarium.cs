using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwModuloSituacionPortuariaListarSituacionPortuarium
{
    public int? SpRowid { get; set; }

    public string SpCdgoMtnve { get; set; } = null!;

    public string? MoCdgo { get; set; } = null!;

    public string? MoNmbre { get; set; }

    public decimal? MoEslra { get; set; }

    public string? MoMtrcla { get; set; }

    public string? MoBndra { get; set; }

    public short? MoCntdadEsctllas { get; set; }

    public decimal? MoCldo { get; set; }

    public int? SpRowidZnaCd { get; set; }

    public int? ZcdRowid { get; set; }

    public string? ZcdCdgo { get; set; }

    public string? ZcdNmbre { get; set; }

    public string? SpCdgoTrmnalMrtmo { get; set; }

    public string? TmCdgo { get; set; }

    public string? TmDscrpcion { get; set; }

    public DateTime? SpFchaArrbo { get; set; }

    public DateTime? SpFchaAtrque { get; set; }

    public DateTime? SpFchaZrpe { get; set; }

    public DateTime? SpFchaCrcion { get; set; }

    public string? SpCdgoEstdoMtnve { get; set; } = null!;

    public string? EmCdgo { get; set; }

    public string? EmNmbre { get; set; }

    public string? SpCdgoPais { get; set; } = null!;

    public string? PaCdgo { get; set; }

    public string? PaNmbre { get; set; }

    public int? SpRowidAgnteNvro { get; set; }

    public int? TeRowid { get; set; }

    public string? TeCdgoCia { get; set; }

    public string? TeCdgo { get; set; }

    public string? TeNmbre { get; set; }

    public bool? TeAgnteMrtmo { get; set; }

    public string? SpCdgoUsrioCrea { get; set; } = null!;

    public string? UsCdgo { get; set; } = null!;

    public string? UsNmbre { get; set; }

    public string? UsIdntfccion { get; set; }

    public int? UsRowidTrcro { get; set; }

    public int CrearVisitaMotonave { get; set; }

    public int? CodigoVisitaMotonave { get; set; }
}
