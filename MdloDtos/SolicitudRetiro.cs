using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class SolicitudRetiro
{
    [Key]
    [JsonPropertyName("IdSolicitud")]
    public int? SrRowid { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? SrCia { get; set; } = null!;

    [JsonPropertyName("CodigoSolicitud")]
    public string? SrCdgo { get; set; } = null!;


    [JsonPropertyName("idDeposito")]
    public int? SrRowidDpsto { get; set; }


    [JsonPropertyName("RowCantidad")]
    public int? SrRowidCdad { get; set; }

    [JsonPropertyName("IDplantaDestino")]
    public string? SrPlntaDstno { get; set; }

    [JsonPropertyName("FechaApertura")]
    public DateTime? SrFchaAprtra { get; set; }

    [JsonPropertyName("KilosAutoriza")]
    public int? SrAutrzdoKlos { get; set; }

    [JsonPropertyName("CantidadAutoriza")]
    public int? SrAutrzdoCntdad { get; set; }

    [JsonPropertyName("DespachoKilos")]
    public int? SrDspchdoKlos { get; set; }

    [JsonPropertyName("DespachoCantidad")]
    public int? SrDspchdoCntdad { get; set; }

    [JsonPropertyName("EsActiva")]
    public bool? SrActva { get; set; }

    [JsonPropertyName("EsAbierta")]
    public bool? SrAbrta { get; set; }

    [JsonPropertyName("Entrega")]
    public bool? SrEntrgaSspndda { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? SrObsrvcnes { get; set; }

    [JsonPropertyName("CampoPersonalizado1")]
    public string? SrCmpoPrsnlzdo1 { get; set; }

    [JsonPropertyName("CampoPersonalizado2")]
    public string? SrCmpoPrsnlzdo2 { get; set; }

    [JsonPropertyName("CampoPersonalizado3")]
    public string? SrCmpoPrsnlzdo3 { get; set; }

    [JsonPropertyName("ZonaID")]
    public int? SrRowidZnaCd { get; set; }

    [JsonPropertyName("PesoExacto")]
    public bool? SrEntrgarPsoExcto { get; set; }

    [NotMapped]
    public virtual ICollection<SolicitudRetiroAutorizacion>? SolicitudRetiroAutorizacions { get; set; } = new List<SolicitudRetiroAutorizacion>();

    [NotMapped]
    public virtual ICollection<SolicitudRetiroTransportadora>? SolicitudRetiroTransportadoras { get; set; } = new List<SolicitudRetiroTransportadora>();

    [NotMapped]
    public virtual Ciudad? SrRowidCdadNavigation { get; set; } = null!;

    [NotMapped]
    public virtual Deposito? SrRowidDpstoNavigation { get; set; } = null!;
}
