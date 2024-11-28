using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class PerfilPermiso
{
    [Key]
    [JsonPropertyName("IdPerfilPermiso")]
    public int? PpRowid { get; set; }

    [StringLength(15)]
    [JsonPropertyName("CodigoPerfil")]
    public string PpCdgoPrfil { get; set; } = null!;

    [Key]
    [StringLength(32)]
    [JsonPropertyName("Permiso")]
    public string PpPrmso { get; set; } = null!;

    [JsonPropertyName("Ruta")]
    public int? PpRta { get; set; }

    [JsonPropertyName("Acciones")]
    public string? PpAccnes { get; set; }

    //propiedad creada de forma manual
    [JsonPropertyName("Operacion")]
    public string? Operacion { get; set; }

    public PerfilPermiso() { }

    public PerfilPermiso(string PpPrmso)
    {

        this.PpPrmso = PpPrmso;
    }

    public PerfilPermiso(int PpRowid, string PpCdgoPrfil, string PpPrmso)
    {

        this.PpRowid = PpRowid;
        this.PpCdgoPrfil = PpCdgoPrfil;
        this.PpPrmso = PpPrmso;
    }
}
