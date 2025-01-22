using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class VehiculoDTO
{
    [Key]
    [JsonPropertyName("Matricula")]
    public string? VeMtrcla { get; set; } = null!;

    [DataType(DataType.Date)]
    [JsonPropertyName("FechaSgro")]
    public DateTime? VeFchaSgro { get; set; }

    [DataType(DataType.Date)]
    [JsonPropertyName("FechaRevision")]
    public DateTime? VeFchaRvsion { get; set; }

    [DataType(DataType.Date)]
    [JsonPropertyName("FechaRegistro")]
    public DateTime? VeFchaRgstro { get; set; }

    [JsonPropertyName("UsuarioCreo")]
    public string? VeCdgoUsrioCrea { get; set; }

    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? VeRowidCnfgrcionVhclar { get; set; }

    [JsonPropertyName("Mdlo")]
    public int? VeMdlo { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? VeCdgoUsrioCreaNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual ConfiguracionVehicular? VeRowidCnfgrcionVhclarNavigation { get; set; }

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 

    [NotMapped]
    public string? ConfiguracionVehicularRowId { get; set; }

    [NotMapped]
    public string? ConfiguracionVehicularCodigo { get; set; }

    [NotMapped]
    public string? ConfiguracionVehicularNombre { get; set; }

    public VehiculoDTO()
    {

    }

    public VehiculoDTO(
                    string? VeMtrcla,
                    DateTime? VeFchaSgro,
                    DateTime? VeFchaRvsion,
                    DateTime? VeFchaRgstro,
                    string? VeCdgoUsrioCrea,
                    int? VeRowidCnfgrcionVhclar,
                    int VeMdlo,
                    string? ConfiguracionVehicularRowId,
                    string? ConfiguracionVehicularCodigo,
                    string? ConfiguracionVehicularNombre
                )
    {
        this.VeMtrcla = VeMtrcla;
        this.VeFchaSgro = VeFchaSgro;
        this.VeFchaRvsion = VeFchaRvsion;
        this.VeFchaRgstro = VeFchaRgstro;
        this.VeCdgoUsrioCrea = VeCdgoUsrioCrea;
        this.VeCdgoUsrioCrea = VeCdgoUsrioCrea;
        this.VeRowidCnfgrcionVhclar = VeRowidCnfgrcionVhclar;
        this.VeRowidCnfgrcionVhclar = VeRowidCnfgrcionVhclar;
        this.VeMdlo = VeMdlo;
        this.ConfiguracionVehicularRowId = ConfiguracionVehicularRowId;
        this.ConfiguracionVehicularCodigo = ConfiguracionVehicularCodigo;
        this.ConfiguracionVehicularNombre = ConfiguracionVehicularNombre;
    }
}
