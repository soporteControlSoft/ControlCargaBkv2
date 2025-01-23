using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class DepositoDTO
{
    [Key]
    [JsonPropertyName("Id")]
    public int? DeRowid { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? DeCia { get; set; } = null!;

    [JsonPropertyName("Codigo")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? DeCdgo { get; set; } = null!;

    [JsonPropertyName("Estado")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? DeEstdo { get; set; } = null!;

    [JsonPropertyName("IdTercero")]
    public int? DeRowidTrcro { get; set; }

    [JsonPropertyName("IdSedeDespacho")]
    public int? DeRowidSdeDspcho { get; set; }

    [JsonPropertyName("IdTerceroFacturacion")]
    public int? DeRowidTrcroFctrcion { get; set; }


    [JsonPropertyName("CodigoDepositoPadre")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? DeCdgoDpstoPdre { get; set; } = null!;

    [JsonPropertyName("CodigoProducto")]
    [DataType(DataType.Text)]
    [StringLength(15)]

    public string? DeCdgoPrdcto { get; set; } = null!;

    [JsonPropertyName("FechaAgrupacion")]
    public DateTime? DeFchaAgrpcion { get; set; }


    [JsonPropertyName("CodigoUsuarioCrea")]
    public string? DeCdgoUsrioCrea { get; set; } = null!;

    [JsonPropertyName("CodigoUsuarioAprueba")]
    public string? DeCdgoUsrioAprba { get; set; } = null!;

    [JsonPropertyName("Activo")]
    public bool? DeActvo { get; set; }

    [JsonPropertyName("Aprobado")]
    public bool? DeAprbdo { get; set; }

    [JsonPropertyName("EsSubdeposito")]
    public bool? DeEsSubdpsto { get; set; }

    [JsonPropertyName("Kilos")]
    public int? DeKlos { get; set; }

    [JsonPropertyName("Cantidad")]

    public int? DeCntdad { get; set; }

    [JsonPropertyName("SeFactura")]
    public bool? DeSeFctra { get; set; }

    [JsonPropertyName("CodigoCondicionFacturacion")]
    public string? DeCdgoCndcionFctrcion { get; set; }

    [JsonPropertyName("CodigoPeriodoFacturacion")]
    public string? DeCdgoPrdoFctrcion { get; set; }

    [JsonPropertyName("DiasGracia")]
    public short? DeDiasGrcia { get; set; }

    [JsonPropertyName("ValorFijoXTonelda")]
    public decimal? DeVlorFjoXTnlda { get; set; }

    [JsonPropertyName("DiasPeriodo")]
    public byte? DeDiasPrdo { get; set; }

    [JsonPropertyName("DiasCobro")]
    public byte? DeDiasCbro { get; set; }

    [JsonPropertyName("ModalidadFacturacion")]
    public string? DeMdldadFctrcion { get; set; }

    [JsonPropertyName("LiquidarDolar")]
    public bool? DeLqdaDlar { get; set; }

    [JsonPropertyName("CondicionPago")]
    public string? DeCndcionPgo { get; set; }

    [JsonPropertyName("FacturacionFinalizada")]
    public bool? DeFctrcionFnlzda { get; set; }

    [JsonPropertyName("TarifaPeriodo1")]
    public decimal? DeTrfaPrdo1 { get; set; }

    [JsonPropertyName("TarifaPeriodo2")]
    public decimal? DeTrfaPrdo2 { get; set; }

    [JsonPropertyName("TarifaPeriodo3")]
    public decimal? DeTrfaPrdo3 { get; set; }

    [JsonPropertyName("TarifaPeriodo4")]
    public decimal? DeTrfaPrdo4 { get; set; }

    [JsonPropertyName("TarifaPeriodo5")]
    public decimal? DeTrfaPrdo5 { get; set; }

    [JsonPropertyName("TarifaPeriodo6")]
    public decimal? DeTrfaPrdo6 { get; set; }

    [JsonPropertyName("FechaInicioFacturacion")]
    public DateTime? DeFchaIncioFctrcion { get; set; }

    [JsonPropertyName("FechaUltimaFactura")]
    public DateTime? DeFchaUltmaFctra { get; set; }

    [JsonPropertyName("NumeroUltimaFactura")]
    public string? DeNmroUltmaFctra { get; set; }

    [JsonPropertyName("UltimoPeriodoFacturado")]
    public short? DeUltmoPrdoFctrdo { get; set; }

    [JsonPropertyName("FechaPrimerMovimiento")]
    public DateTime? DeFchaPrmerMvmnto { get; set; }

    [JsonPropertyName("ValorCIFDolar")]
    public decimal? DeVlorCifUs { get; set; }

    [JsonPropertyName("ValorCIFLocal")]
    public decimal? DeVlorCifLo { get; set; }

    [JsonPropertyName("ValorCIFCliente")]
    public decimal? DeVlorCifClnte { get; set; }

    [JsonPropertyName("CopiasTiquete")]
    public short? DeCpiasTqte { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? DeObsrvcnes { get; set; }

    [JsonPropertyName("Comentarios")]
    public string? DeCmntrios { get; set; }

    [JsonPropertyName("ValorUnitario")]
    public decimal? DeVlorUntrio { get; set; }

    [JsonPropertyName("PesoPromedio")]
    public decimal? DePsoPrmdio { get; set; }

    [JsonPropertyName("BLKilosOriginal")]
    public int? DeBlKlosOrgnal { get; set; }

    [JsonPropertyName("BLUnidadesOriginal")]
    public int? DeBlUnddesOrgnal { get; set; }

    [JsonPropertyName("BLKilos")]
    public int? DeBlKlos { get; set; }

    [JsonPropertyName("BLunidades")]
    public int? DeBlUnddes { get; set; }

    [JsonPropertyName("NacionalizadoKilos")]
    public int? DeNcnlzdoKlos { get; set; }

    [JsonPropertyName("NacionalizadoUnidades")]
    public int? DeNcnlzdoUnddes { get; set; }

    [JsonPropertyName("RetenidoKilos")]
    public int? DeRtndoKlos { get; set; }

    [JsonPropertyName("RetenidoUnidades")]
    public string? DeRtndoUnddes { get; set; }

    [JsonPropertyName("EntradasUnidades")]
    public int? DeEntrdasUnddes { get; set; }

    [JsonPropertyName("SalidasUnidades")]
    public int? DeSldasUnddes { get; set; }

    [JsonPropertyName("EntradasKilos")]
    public int? DeEntrdasKlos { get; set; }

    [JsonPropertyName("SalidasKilos")]
    public int? DeSldasKlos { get; set; }

    [JsonPropertyName("CampoCliente1")]
    public string? DeCmpoClnte1 { get; set; }

    [JsonPropertyName("CampoCliente2")]
    public string? DeCmpoClnte2 { get; set; }

    [JsonPropertyName("CampoCliente3")]
    public string? DeCmpoClnte3 { get; set; }

    [JsonPropertyName("IdEmpaque")]
    public int? DeRowidEmpque { get; set; }

    [JsonPropertyName("ValorCIFPrimerPeriodo")]
    public decimal? DeVlorCifPrmerPrdo { get; set; }

    [JsonPropertyName("Comun")]
    public bool? DeCmun { get; set; }

    [JsonPropertyName("ComprometidoKilos")]
    public int? DeCmprmtdoKlos { get; set; }

    [JsonPropertyName("ComprometidoUnidades")]
    public int? DeCmprmtdoUnddes { get; set; }

    [JsonPropertyName("ControlUnidades")]
    public bool? DeCntrolUnddes { get; set; }

    [JsonPropertyName("Suspendido")]
    public bool? DeSspnddo { get; set; }

    [JsonPropertyName("CodigoUsuarioRechaza")]
    public string? DeCdgoUsrioRchza { get; set; }

    [JsonPropertyName("FechaAprobacionRechazo")]
    public DateTime? DeFchaAprbcionRchzo { get; set; }

    [JsonPropertyName("ComentarioRechazo")]
    public string? DeCmntrioRchzo { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int? DeRowidVstaMtnve { get; set; }

    [JsonPropertyName("CodigoCompaniaFacturacion")]
    public string? DeCiaFctrcion { get; set; }

    [JsonPropertyName("IdSubDepositoFac1")]
    public int? DeRowidSubdpstoFac1 { get; set; }

    [JsonPropertyName("IdSubDepositoFac2")]
    public int? DeRowidSubdpstoFac2 { get; set; }

    [JsonPropertyName("IdSubDepositoFac3")]
    public int? DeRowidSubdpstoFac3 { get; set; }

    [JsonPropertyName("TRM")]
    public decimal? DeTrm { get; set; }



    [JsonPropertyName("CondicionFacturacionNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual CondicionFacturacion? DeCdgoCndcionFctrcionNavigation { get; set; }

    [JsonPropertyName("ProductoNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual Producto? DeCdgoPrdctoNavigation { get; set; } = null!;


    [JsonPropertyName("PeriodoFacturacionNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual PeriodoFacturacion? DeCdgoPrdoFctrcionNavigation { get; set; }


    [JsonPropertyName("UsuarioApruebaNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual Usuario? DeCdgoUsrioAprbaNavigation { get; set; } = null!;

    [JsonPropertyName("UsuarioCreaNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Usuario? DeCdgoUsrioCreaNavigation { get; set; } =   null!;

    [JsonPropertyName("CompaniaFacturacionNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Companium? DeCiaFctrcionNavigation { get; set; }


    [JsonPropertyName("CompaniaNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Companium? DeCiaNavigation { get; set; } = null!;


    [JsonPropertyName("EmpaqueNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Empaque? DeRowidEmpqueNavigation { get; set; }

    [JsonPropertyName("SedeNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Sede? DeRowidSdeDspchoNavigation { get; set; } = null!;

    [JsonPropertyName("SubDepositoFacturacion1Navegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Deposito? DeRowidSubdpstoFac1Navigation { get; set; }

    [JsonPropertyName("SubDepositoFacturacion2Navegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Deposito? DeRowidSubdpstoFac2Navigation { get; set; }

    [JsonPropertyName("SubDepositoFacturacion3Navegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Deposito? DeRowidSubdpstoFac3Navigation { get; set; }


    [JsonPropertyName("TerceroFacturacionNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Tercero? DeRowidTrcroFctrcionNavigation { get; set; }

    [JsonPropertyName("VisitaMotonaveNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual VisitaMotonave? DeRowidVstaMtnveNavigation { get; set; }


    [JsonPropertyName("TerceroNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Tercero? DeRowidTrcroNavigation { get; set; } = null!;


    [JsonPropertyName("ListaBLs")]
    [NotMapped]
    public virtual ICollection<DepositoBl>? DepositoBls { get; set; } = new List<DepositoBl>();


    [NotMapped]
    public virtual ICollection<Deposito> InverseDeRowidSubdpstoFac1Navigation { get; set; } = new List<Deposito>();

    [NotMapped]
    public virtual ICollection<Deposito> InverseDeRowidSubdpstoFac2Navigation { get; set; } = new List<Deposito>();

    [NotMapped]
    public virtual ICollection<Deposito> InverseDeRowidSubdpstoFac3Navigation { get; set; } = new List<Deposito>();


    //Propiedad Agregada manual

    [JsonPropertyName("TerceroCertificado")]
    [NotMapped]
    //[JsonIgnore]
    public virtual TerceroCertificado? TerceroCertificado { get; set; } = null!;



    [JsonPropertyName("SaldoKilos")]
    [NotMapped]
    public int? DeSldoKlos { get; set; }



    [JsonPropertyName("SaldoUnidades")]
    [NotMapped]
    public int? DeSldoUnddes { get; set; }


    [JsonPropertyName("SubDepositos")]
    [NotMapped]
    public List<MdloDtos.SpSubDeposito>? SubDepositos { get; set; }


    public DepositoDTO() { }

    //contructor para el subdeposito
    public DepositoDTO(string DeCia, int deRowidTrcro,int DeRowidSdeDspcho, string DeCdgoDpstoPdre, string DeCdgoPrdcto,
        string DeCdgoUsrioCrea,int DeCntdad
        ) {

        this.DeCia = DeCia;
        this.DeRowidTrcro = DeRowidTrcro;
        this.DeRowidSdeDspcho = DeRowidSdeDspcho;
        this.DeCdgoDpstoPdre = DeCdgoDpstoPdre;
        this.DeCdgoPrdcto = DeCdgoPrdcto;
        this.DeCdgoUsrioCrea = DeCdgoUsrioCrea;
        this.DeCntdad = DeCntdad;

    }

    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();


    [NotMapped]
    public virtual ICollection<SolicitudRetiro> SolicitudRetiros { get; set; } = new List<SolicitudRetiro>();
}
