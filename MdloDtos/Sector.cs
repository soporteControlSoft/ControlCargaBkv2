using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Sector
{
    [Key]
    [JsonPropertyName("IdSector")]
    public int SeRowid { get; set; }

    [JsonPropertyName("IdCodigoSector")]
    [StringLength(15)]
    public string SeCdgo { get; set; } = null!;

    [JsonPropertyName("IdNombreSector")]
    [StringLength(20)]
    public string SeNmbre { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<EstadoHecho> EstadoHechoes { get; set; } = new List<EstadoHecho>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<SectorEvento> SectorEventos { get; set; } = new List<SectorEvento>();
} 
