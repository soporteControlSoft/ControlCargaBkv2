using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SpDpstoAprbcion
{
    [Key]
    [JsonPropertyName("IdDeposito")]
    public int rowIdDpsto { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? cdgoCmpnia { get; set; }

    [JsonPropertyName("IdSede")]
    public int? rowIdSde { get; set; }

    [JsonPropertyName("CodigoUsuarioQueAprueba")]
    public string? cdgoUsrioAprba { get; set; }

    [JsonPropertyName("CantidadImpresionTiquete")]
    public int? CntdadImprsionTqte { get; set; }

    [JsonPropertyName("EstadoDeposito")]
    public bool? estdoDpsto { get; set; }

    [JsonPropertyName("ControlUnidades")]
    public bool? cntrlUnddes { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? obsrvcnes { get; set; }

    [JsonPropertyName("DepositoComun")]
    public bool? dpstoComun { get; set; }

    [JsonPropertyName("IdEmpaque")]
    public int? rowIdEmpaque { get; set; }

    [JsonPropertyName("UsuarioObservacion")]
    public string? usuarioObservacion { get; set; }

    [JsonPropertyName("CodigoCompaniaFacturacion")]
    public string? cdgoCmpniaFctrcion { get; set; }


}
