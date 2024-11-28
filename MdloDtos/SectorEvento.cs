using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MdloDtos;

public partial class SectorEvento
{
    [Key]
    public int SeRowid { get; set; }

    public int SeRowidSctor { get; set; }

    public int SeRowidEvnto { get; set; }

    public virtual Evento? SeRowidEvntoNavigation { get; set; } = null!;

    public virtual Sector? SeRowidSctorNavigation { get; set; } = null!;
}
