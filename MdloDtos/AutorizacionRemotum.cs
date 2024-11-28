using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class AutorizacionRemotum
{
    public int ArRowid { get; set; }

    public string ArCdgoCia { get; set; } = null!;

    public string? ArIdntfcdor { get; set; }

    public string? ArCdgoUsrioSlcta { get; set; }

    public string? ArEqpoSlcta { get; set; }

    public string? ArDtlle { get; set; }

    public string? ArCdgoPrmso { get; set; }

    public DateTime? ArFchaSlctud { get; set; }

    public bool? ArCnfrmda { get; set; }

    public bool? ArAutrzda { get; set; }

    public DateTime? ArFchaAutrza { get; set; }

    public string? ArCdgoUsrioAutrza { get; set; }

    public string? ArEqpoAutrza { get; set; }

    public string? ArObsrvcnes { get; set; }

    public virtual Companium? ArCdgoCiaNavigation { get; set; } = null!;

    public virtual Usuario? ArCdgoUsrioAutrzaNavigation { get; set; }

    public virtual Usuario? ArCdgoUsrioSlctaNavigation { get; set; }
}
