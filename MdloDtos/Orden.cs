using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Orden
{
    [Key]
    [JsonPropertyName("Codigo")]
    public int OrCdgo { get; set; }

    [JsonPropertyName("IdTransportadora")]
    public int OrRowidTrnsprtdra { get; set; }

    [JsonPropertyName("Activa")]
    public bool OrActva { get; set; }

    [JsonPropertyName("FechaReserva")]
    public DateTime? OrFchaRsrva { get; set; }

    [JsonPropertyName("FechaRegistroReserva")]
    public DateTime? OrFchaRgstroRsrva { get; set; }

    [JsonPropertyName("CodigoUsuarioReserva")]
    public string? OrCdgoUsrioRsrva { get; set; }

    [JsonPropertyName("Placa")]
    public string? OrPlca { get; set; }

    [JsonPropertyName("Remolque")]
    public string? OrRmlque { get; set; }

    [JsonPropertyName("Manifiesto")]
    public string? OrMnfsto { get; set; }

    [JsonPropertyName("Remision")]
    public string? OrRmsion { get; set; }

    [JsonPropertyName("IdentificacionConductor")]
    public string? OrIdntfccionCndctor { get; set; }

    [JsonPropertyName("Llamada")]
    public bool? OrLlmda { get; set; }

    [JsonPropertyName("Radicada")]
    public bool? OrRdcda { get; set; }

    [JsonPropertyName("FechaRadicacion")]
    public DateTime? OrFchaRdccion { get; set; }

    [JsonPropertyName("IdDeposito")]
    public int? OrRowidDpsto { get; set; }

    [JsonPropertyName("IdSolicitudRetiro")]
    public int? OrRowidSlctudRtro { get; set; }

    [JsonPropertyName("IdConfiguracionVehicular")]
    public int? OrRowidCnfgrcionVhclar { get; set; }

    [JsonPropertyName("IdCiudad")]
    public int? OrRowidCdad { get; set; }

    [JsonPropertyName("IdZonaCargueDescargue")]
    public int? OrRowidZnaCd { get; set; }

    [JsonPropertyName("RadicaccionHuellaValidada")]
    public bool? OrRdccionHllaVldda { get; set; }

    [JsonPropertyName("CodigoUsuarioRadicaccion")]
    public string? OrCdgoUsrioRdccion { get; set; }

    [JsonPropertyName("NumeroLLamadas")]
    public short? OrLlmdas { get; set; }

    [JsonPropertyName("FechaAnulacion")]
    public DateTime? OrFchaAnlcion { get; set; }

    [JsonPropertyName("IdSocidad")]
    public string? OrIdScdad { get; set; }

    [JsonPropertyName("VigenciaTurno")]
    public short? OrVgnciaTrno { get; set; }

    [JsonPropertyName("TurnoValidado")]
    public bool? OrTrnoVlddo { get; set; }

    [JsonPropertyName("PesoACargar")]
    public int? OrPsoACrgar { get; set; }

    [JsonPropertyName("Concepto")]
    public string? OrCncpto { get; set; }

    [JsonPropertyName("CorrigeTurno")]
    public bool? OrCrrgeTrno { get; set; }

    [JsonPropertyName("CorrigeTurnoFecha")]
    public DateTime? OrCrrgeTrnoFcha { get; set; }

    [JsonPropertyName("ValidarVigenciaRadicaccion")]
    public bool? OrVldarVgnciaRdccion { get; set; }

    [JsonPropertyName("FechaEntradaSociedad")]
    public DateTime? OrFchaEntrdaScdad { get; set; }

    [JsonPropertyName("UsuarioEntradaSociedad")]
    public string? OrUsrioEntrdaScdad { get; set; }

    [JsonPropertyName("FechaPrimerLlamado")]
    public DateTime? OrFchaPrmerLlmdo { get; set; }

    [JsonPropertyName("FechaUltimoLlamado")]
    public DateTime? OrFchaUltmoLlmdo { get; set; }

    [JsonPropertyName("Tipo")]
    public string? OrTpo { get; set; }

    [JsonPropertyName("Tercero")]
    public string? OrTrcro { get; set; }

    [JsonPropertyName("TurnoNumero")]
    public int? OrTrnoNmro { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? OrObsrvcnes { get; set; }

    [JsonPropertyName("Articulo")]
    public string? OrArtclo { get; set; }

    [JsonPropertyName("FechaSalidaSocidad")]
    public DateTime? OrFchaSldaScdad { get; set; }

    [JsonPropertyName("UsuarioSalidaSociada")]
    public string? OrUsrioSldaScdad { get; set; }

    [JsonPropertyName("UbicacionRadicacion")]
    public string? OrUbccionRdccion { get; set; }

    [JsonPropertyName("TipoCarroceria")]
    public string? OrTpoCrrcria { get; set; }

    [JsonPropertyName("InterfazInside")]
    public bool? OrIntrfazInsde { get; set; }

    [JsonPropertyName("InterfazInsideCancelada")]
    public bool? OrIntrfazInsdeCnclda { get; set; }

    [JsonPropertyName("CodigoCausalCancelacion")]
    public string? OrCdgoCsalCnclcion { get; set; }

    [JsonPropertyName("ObservacionesCancelacion")]
    public string? OrObsrvcnesCnclcion { get; set; }

    [JsonPropertyName("InterfazInsideConError")]
    public bool? OrIntrfazInsdeConError { get; set; }

    [JsonPropertyName("InterfazInsideCanceladaConError")]
    public bool? OrIntrfazInsdeCncldaConError { get; set; }

    [JsonPropertyName("IngresoIdInside")]
    public string? OrIngrsoidInsde { get; set; }

    [JsonPropertyName("IngresoId2Inside")]
    public string? OrIngrsoid2Insde { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdCiudadNavegacion")]
    public virtual Ciudad? OrRowidCdadNavigation { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdConfiguracionVehicularNavegacion")]
    public virtual ConfiguracionVehicular? OrRowidCnfgrcionVhclarNavigation { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdDepositoNavegacion")]
    public virtual Deposito? OrRowidDpstoNavigation { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdSolicitudRetiroNavegacion")]
    public virtual SolicitudRetiro? OrRowidSlctudRtroNavigation { get; set; }

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdTransportadoraNavegacion")]
    public virtual Tercero? OrRowidTrnsprtdraNavigation { get; set; } = null!;

    [NotMapped]
    [JsonIgnore]
    [JsonPropertyName("IdZonaCargueDescargueNavegacion")]
    public virtual ZonaCd? OrRowidZnaCdNavigation { get; set; }
}
