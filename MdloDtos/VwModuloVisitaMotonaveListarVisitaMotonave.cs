using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class VwModuloVisitaMotonaveListarVisitaMotonave
{
    public int? VmRowid { get; set; }

    public string? VmCdgoCia { get; set; } = null!;

    public string? VmCompaniaCdgo { get; set; } = null!;

    public string? VmCompaniaIdntfccion { get; set; } = null!;

    public string? VmCompaniaNmbre { get; set; }

    public string? VmCdgoMtnve { get; set; } = null!;

    public string? VmMotonaveeCdgo { get; set; } = null!;

    public string? VmMotonaveNmbre { get; set; }

    public decimal? VmMotonaveEslra { get; set; }

    public string? VmMotonaveMtrcla { get; set; }

    public string? VmMotonaveBndra { get; set; }

    public short? VmMotonaveCntdadEsctllas { get; set; }

    public decimal? VmMotonaveCldo { get; set; }

    public DateTime? VmFchaCrcion { get; set; }

    public DateTime? VmFchaIncioOprcion { get; set; }

    public DateTime? VmFchaFinOprcion { get; set; }

    public DateTime? VmFchaFndeo { get; set; }

    public short? VmScncia { get; set; }

    public string? VmDscrpcion { get; set; } = null!;

    public int? VmRowidVnddor { get; set; }

    public int? VmVnddorTrcroRowid { get; set; }

    public string? VmVnddorTrcroCdgo { get; set; }

    public string? VmVnddorTrcroNmbre { get; set; }

    public string? VnddorTrcroIdntfccion { get; set; }

    public int? VmRowidZnaCdAltrno { get; set; }

    public int? VmZnaCdAltrnoRowid { get; set; }

    public string? VmZnaCdAltrnoCdgo { get; set; }

    public string? VmZnaCdAltrnoNmbre { get; set; }

    public int? VmRowidStcionPrtria { get; set; }

    public string? VmRowidsPrstdresSrvcios { get; set; }

    public string? VmCdgoUsrioCrea { get; set; } = null!;

    public string? VmUsrioCreaCdgo { get; set; } = null!;

    public string? VmUsrioCreaNmbre { get; set; }

    public string? VmUsrioCreaIdntfccion { get; set; }

    public int? SpRowid { get; set; }

    public string? SpCdgoMtnve { get; set; } = null!;

    public string? SpMotonaveCdgo { get; set; } = null!;

    public string? SpMotonaveNmbre { get; set; }

    public decimal? SpMotonaveEslra { get; set; }

    public string? SpMotonaveMtrcla { get; set; }

    public string? SpMotonaveBndra { get; set; }

    public short? SpMotonaveCntdadEsctllas { get; set; }

    public decimal? SpMotonaveCldo { get; set; }

    public int? SpRowidZnaCd { get; set; }

    public int? SpZonaCdRowid { get; set; }

    public string? SpZonaCdCdgo { get; set; }

    public string? SpZonaCdNmbre { get; set; }

    public string? SpCdgoTrmnalMrtmo { get; set; }

    public string? SpTerminalMaritimoCdgo { get; set; }

    public string? SpTerminalMaritimoDscrpcion { get; set; }

    public DateTime? SpFchaArrbo { get; set; }

    public DateTime? SpFchaAtrque { get; set; }

    public DateTime? SpFchaZrpe { get; set; }

    public DateTime? SpFchaCrcion { get; set; }

    public string? SpCdgoEstdoMtnve { get; set; } = null!;

    public string? SpEstadoMotonaveCdgo { get; set; }

    public string? SpEstadoMotonaveNmbre { get; set; }

    public string? SpCdgoPais { get; set; } = null!;

    public string? SpPaisCdgo { get; set; }

    public string? SpPaisNmbre { get; set; }

    public int? SpRowidAgnteNvro { get; set; }

    public int? SpTerceroAgnteRowid { get; set; }

    public string? SpTerceroAgnteNvrocdgoCia { get; set; }

    public string? SpTerceroAgnteNvroCdgo { get; set; }

    public string? SpTerceroAgnteNvroNmbre { get; set; }

    public string? SpCdgoUsrioCrea { get; set; } = null!;

    public string? SpUsuarioCreaCdgo { get; set; } = null!;

    public string? SpUsuarioCreaNmbre { get; set; }

    public string? SpUsuarioCreaIdntfccion { get; set; }

    public int? SpUsuarioCreaRowidTrcro { get; set; }

    public int SpCrearVisitaMotonave { get; set; }

    public int SpCodigoVisitaMotonave { get; set; }
}
