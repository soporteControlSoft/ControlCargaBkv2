using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class ConfiguracionVehicular
{
    public int CvRowid { get; set; }

    public string CvCdgo { get; set; } = null!;

    public string CvNmbre { get; set; } = null!;

    public int? CvPsoMxmo { get; set; }

    public int? CvTlrncia { get; set; }

    public string CvCdgoCia { get; set; } = null!;

    public bool? CvActvo { get; set; }

    public virtual Companium CvCdgoCiaNavigation { get; set; } = null!;

    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();

    public virtual ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}
