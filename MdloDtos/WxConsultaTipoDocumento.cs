using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class WxConsultaTipoDocumento
{
    public string? TdCdgo { get; set; } = null!;

    public string? TdNmbre { get; set; } = null!;

    public string? TdOrgen { get; set; } = null!;

    public string? TdNmbreAAsgnar { get; set; } = null!;

    public bool? TdActvo { get; set; }

    public bool? TdOblgtrio { get; set; }

    public string? BotonColor { get; set; }

    public int? RowIdVmdo { get; set; }

    public int? VmdoRowid { get; set; }

    public int? VmdoRowidVstaMtnve { get; set; }

    public string? VmdoCdgoTpoDcmnto { get; set; }

    public string? VmdoEstdo { get; set; }

    public string? VmdoRta { get; set; }

    public DateTime? VmdoFchaCrgue { get; set; }

    public DateTime? VmdoFchaAprbcion { get; set; }

    public string? VmdoCdgoUsrioCrgue { get; set; }

    public string? VmdoCdgoUsrioAprbdo { get; set; }
}
