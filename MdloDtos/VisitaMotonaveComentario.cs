using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VisitaMotonaveComentario
{
    [Key]
    [JsonPropertyName("IdComentario")]
    public int VmcRowid { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int? VmcRowidVstaMtnve { get; set; }

    [JsonPropertyName("IdVisitaMotonaveBl")]
    public int? VmcRowidVstaMtnveBl { get; set; }

    [JsonPropertyName("Titulo")]
    public string? VmcTtlo { get; set; } = null!;

    [JsonPropertyName("Comentario")]
    public string? VmcCmntrios { get; set; } = null!;

    [JsonPropertyName("CodigoUsuario")]
    public string? VmcCdgoUsrio { get; set; } = null!;

    [JsonPropertyName("Fecha")]
    public DateTime? VmcFcha { get; set; }

    public virtual Usuario? VmcCdgoUsrioNavigation { get; set; } = null!;

    public virtual VisitaMotonaveBl? VmcRowidVstaMtnveBlNavigation { get; set; }

    public virtual VisitaMotonave? VmcRowidVstaMtnveNavigation { get; set; }
}
