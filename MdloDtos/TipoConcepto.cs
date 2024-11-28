using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class TipoConcepto
{
    public string TcCdgo { get; set; } = null!;

    public string? TcNmbre { get; set; }

    public string? TcNtrlza { get; set; }

    public virtual ICollection<ConceptoPesaje> ConceptoPesajes { get; set; } = new List<ConceptoPesaje>();
}
