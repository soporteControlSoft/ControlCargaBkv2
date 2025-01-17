using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class Consecutivo
{
    public int CoRowid { get; set; }

    public string CoCdgoCia { get; set; } = null!;

    public string CoCdgo { get; set; } = null!;

    public string CoNmbre { get; set; } = null!;

    public int CoCntdor { get; set; } 

    public virtual Companium CoCdgoCiaNavigation { get; set; } = null!;

    public virtual ICollection<ConceptoPesaje> ConceptoPesajes { get; set; } = new List<ConceptoPesaje>();
}
