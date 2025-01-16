using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class ConductorDTO2
{
    [Key]
    [StringLength(15)]
    public string Identificacion { get; set; } = null!;

    [StringLength(40)]
    public string Nombre { get; set; } = null!;

    public byte[]? Imagen { get; set; }

    

    [StringLength(10)]
    public string? Vehiculo { get; set; }


    public int? IdTransportadora { get; set; }

    public DateTime FechaRegistro { get; set; }

    [StringLength(15)]
    public string? CodigoUsuarioEnrolo { get; set; }

    public DateTime? FechaEnrolamiento { get; set; }

    [StringLength(15)]
    public string? Movil { get; set; }

    [StringLength(15)]
    public string? NumeroLicencia { get; set; }

    [StringLength(15)]
    public string? TipoLicencia { get; set; }

    public DateTime? FechaVencimientoLcncia { get; set; }


    public bool? Activo { get; set; }

    public bool? Urbano { get; set; }

    [NotMapped]
    public virtual MdloDtos.Tercero? CnRowidTrnsprtdraNavigation { get; set; } = null;
}
