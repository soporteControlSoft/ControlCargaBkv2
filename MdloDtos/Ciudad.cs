using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Ciudad
{
    public int? CiRowid { get; set; }

    public string? CiCdgo { get; set; } = null!;

    public string? CiNmbre { get; set; }

    public int? CiRowidDprtmnto { get; set; }

    public virtual Departamento? CiRowidDprtmntoNavigation { get; set; } = null!;

    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    [NotMapped]
    public virtual ICollection<SolicitudRetiro> SolicitudRetiros { get; set; } = new List<SolicitudRetiro>();
}
