using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class Auditorium
{
    public int AuRowid { get; set; }

    public string AuCdgoCia { get; set; } = null!;

    public string? AuCdgoMdlo { get; set; }

    public string? AuCdgoMtvo { get; set; }

    public DateTime? AuFcha { get; set; }

    public string? AuCdgoUsrio { get; set; }

    public string? AuEqpo { get; set; }

    public string? AuDtlle { get; set; }

    public int? AuRowidRgstro { get; set; }

    public string? AuLlve { get; set; }

    public string? AuRzon { get; set; }

    public string? AuCdgoUsrioAutrza { get; set; }

    public string? AuEqpoAutrza { get; set; }

    public int? AuRowidRgstroAutrzcionRmta { get; set; }

    public string? AuObsrvcnes { get; set; }

    public virtual Companium AuCdgoCiaNavigation { get; set; } = null!;

    public virtual AuditoriaModulo? AuCdgoMdloNavigation { get; set; }

    public virtual AuditoriaMotivo? AuCdgoMtvoNavigation { get; set; }

    public virtual Usuario? AuCdgoUsrioAutrzaNavigation { get; set; }

    public virtual Usuario? AuCdgoUsrioNavigation { get; set; }
}
