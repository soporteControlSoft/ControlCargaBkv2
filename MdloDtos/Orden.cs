using System;
using System.Collections.Generic;

namespace MdloDtos;

public partial class Orden
{
    public int OrCdgo { get; set; }

    public int OrRowidTrnsprtdra { get; set; }

    public bool OrActva { get; set; }

    public DateTime? OrFchaRsrva { get; set; }

    public DateTime? OrFchaRgstroRsrva { get; set; }

    public string? OrCdgoUsrioRsrva { get; set; }

    public string? OrPlca { get; set; }

    public string? OrRmlque { get; set; }

    public string? OrMnfsto { get; set; }

    public string? OrRmsion { get; set; }

    public string? OrIdntfccionCndctor { get; set; }

    public bool? OrLlmda { get; set; }

    public bool? OrRdcda { get; set; }

    public DateTime? OrFchaRdccion { get; set; }

    public int? OrRowidDpsto { get; set; }

    public int? OrRowidSlctudRtro { get; set; }

    public int? OrRowidCnfgrcionVhclar { get; set; }

    public int? OrRowidCdad { get; set; }

    public int? OrRowidZnaCd { get; set; }

    public bool? OrRdccionHllaVldda { get; set; }

    public string? OrCdgoUsrioRdccion { get; set; }

    public short? OrLlmdas { get; set; }

    public DateTime? OrFchaAnlcion { get; set; }

    public string? OrIdScdad { get; set; }

    public short? OrVgnciaTrno { get; set; }

    public bool? OrTrnoVlddo { get; set; }

    public int? OrPsoACrgar { get; set; }

    public string? OrCncpto { get; set; }

    public bool? OrCrrgeTrno { get; set; }

    public DateTime? OrCrrgeTrnoFcha { get; set; }

    public bool? OrVldarVgnciaRdccion { get; set; }

    public DateTime? OrFchaEntrdaScdad { get; set; }

    public string? OrUsrioEntrdaScdad { get; set; }

    public DateTime? OrFchaPrmerLlmdo { get; set; }

    public DateTime? OrFchaUltmoLlmdo { get; set; }

    public string? OrTpo { get; set; }

    public string? OrTrcro { get; set; }

    public int? OrTrnoNmro { get; set; }

    public string? OrObsrvcnes { get; set; }

    public string? OrArtclo { get; set; }

    public DateTime? OrFchaSldaScdad { get; set; }

    public string? OrUsrioSldaScdad { get; set; }

    public string? OrUbccionRdccion { get; set; }

    public string? OrTpoCrrcria { get; set; }

    public bool? OrIntrfazInsde { get; set; }

    public bool? OrIntrfazInsdeCnclda { get; set; }

    public string? OrCdgoCsalCnclcion { get; set; }

    public string? OrObsrvcnesCnclcion { get; set; }

    public bool? OrIntrfazInsdeConError { get; set; }

    public bool? OrIntrfazInsdeCncldaConError { get; set; }

    public string? OrIngrsoidInsde { get; set; }

    public string? OrIngrsoid2Insde { get; set; }

    public virtual Ciudad? OrRowidCdadNavigation { get; set; }

    public virtual ConfiguracionVehicular? OrRowidCnfgrcionVhclarNavigation { get; set; }

    public virtual Deposito? OrRowidDpstoNavigation { get; set; }

    public virtual SolicitudRetiro? OrRowidSlctudRtroNavigation { get; set; }

    public virtual Tercero OrRowidTrnsprtdraNavigation { get; set; } = null!;

    public virtual ZonaCd? OrRowidZnaCdNavigation { get; set; }
}
