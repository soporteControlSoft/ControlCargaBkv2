using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Ciudad
{
    [Key]
    [JsonPropertyName("IdCiudad")]
    public int? CiRowid { get; set; }

    [JsonPropertyName("Codigo")]
    [StringLength(15)]
    public string? CiCdgo { get; set; } = null!;

    [JsonPropertyName("Nombre")]
    [StringLength(60)]
    public string? CiNmbre { get; set; }

    [JsonPropertyName("IdDepartamento")]
    public int? CiRowidDprtmnto { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Departamento? CiRowidDprtmntoNavigation { get; set; } = null!;

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    /// 
    [NotMapped]
    public string? DepartamentoRowId { get; set; }


    [NotMapped]
    public string? DepartamentoCodigo { get; set; }

    [NotMapped]
    public string? DepartamentoNombre { get; set; }

    public Ciudad()
    {

    }

    public Ciudad(
                    int? CiRowid,
                    string? CiCdgo,
                    string? CiNmbre,
                    int? CiRowidDprtmnto,
                    string? DepartamentoRowId,
                    string? DepartamentoCodigo,
                    string? DepartamentoNombre
                )
    {
        //Atributos de Ciudad
        this.CiRowid = CiRowid;
        this.CiCdgo = CiCdgo;
        this.CiNmbre = CiNmbre;
        this.CiRowidDprtmnto = CiRowidDprtmnto;

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
