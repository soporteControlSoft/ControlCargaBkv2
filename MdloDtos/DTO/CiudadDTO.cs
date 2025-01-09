using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class CiudadDTO
{
    [Key]
    [JsonPropertyName("IdCiudad")]
    public int? IdCiudad { get; set; }

    [StringLength(15)]
    [JsonPropertyName("Codigo")]
    public string? Codigo { get; set; } = null!;

    [StringLength(60)]
    [JsonPropertyName("Nombre")]
    public string? Nombre { get; set; }

    [JsonPropertyName("Identificacion")]
    public int? IdDepartamento { get; set; }

    [JsonIgnore]
    [NotMapped]
    [JsonPropertyName("CiRowidDprtmntoNavigation")]
    public virtual Departamento? CiRowidDprtmntoNavigation { get; set; } = null!;

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 
    [NotMapped]
    [JsonPropertyName("DepartamentoRowId")]
    public string? DepartamentoRowId { get; set; }


    [NotMapped]
    [JsonPropertyName("DepartamentoCodigo")]
    public string? DepartamentoCodigo { get; set; }

    [NotMapped]
    [JsonPropertyName("DepartamentoNombre")]
    public string? DepartamentoNombre { get; set; }

    public CiudadDTO()
    {

    }

    public CiudadDTO(
                    int? IdCiudad,
                    string? Codigo,
                    string? Nombre,
                    int? IdDepartamento,
                    string? DepartamentoRowId,
                    string? DepartamentoCodigo,
                    string? DepartamentoNombre
                )
    {
        //Atributos de Ciudad
        this.IdCiudad = IdCiudad;
        this.Codigo = Codigo;
        this.Nombre = Nombre;
        this.IdDepartamento = IdDepartamento;

        //Atributos de departamento
        this.DepartamentoRowId = DepartamentoRowId;
        this.DepartamentoCodigo = DepartamentoCodigo;
        this.DepartamentoNombre = DepartamentoNombre;
    }

    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();



    [NotMapped]
    public virtual ICollection<SolicitudRetiro> SolicitudRetiros { get; set; } = new List<SolicitudRetiro>();
}
