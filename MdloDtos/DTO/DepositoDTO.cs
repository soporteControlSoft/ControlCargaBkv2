using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class DepositoDTO
{
    [Key]
    [JsonPropertyName("Id")]
    public int? Id { get; set; }

    [JsonPropertyName("CodigoCompania")]
    public string? CodigoCompania { get; set; } = null!;

    [JsonPropertyName("Codigo")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? Codigo { get; set; } = null!;

    [JsonPropertyName("Estado")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? Estado { get; set; } = null!;

    [JsonPropertyName("IdTercero")]
    public int? IdTercero { get; set; }

    [JsonPropertyName("IdSedeDespacho")]
    public int? IdSedeDespacho { get; set; }

    [JsonPropertyName("IdTerceroFacturacion")]
    public int? IdTerceroFacturacion { get; set; }


    [JsonPropertyName("CodigoDepositoPadre")]
    [DataType(DataType.Text)]
    [StringLength(15)]
    public string? CodigoDepositoPadre { get; set; } = null!;

    [JsonPropertyName("CodigoProducto")]
    [DataType(DataType.Text)]
    [StringLength(15)]

    public string? CodigoProducto { get; set; } = null!;

    [JsonPropertyName("FechaAgrupacion")]
    public DateTime? FechaAgrupacion { get; set; }


    [JsonPropertyName("CodigoUsuarioCrea")]
    public string? CodigoUsuarioCrea { get; set; } = null!;

    [JsonPropertyName("CodigoUsuarioAprueba")]
    public string? CodigoUsuarioAprueba { get; set; } = null!;

    [JsonPropertyName("Activo")]
    public bool? Activo { get; set; }

    [JsonPropertyName("Aprobado")]
    public bool? Aprobado { get; set; }

    [JsonPropertyName("EsSubdeposito")]
    public bool? EsSubdeposito { get; set; }

    [JsonPropertyName("Kilos")]
    public int? Kilos { get; set; }

    [JsonPropertyName("Cantidad")]

    public int? Cantidad { get; set; }

    [JsonPropertyName("SeFactura")]
    public bool? SeFactura { get; set; }

    [JsonPropertyName("CodigoCondicionFacturacion")]
    public string? CodigoCondicionFacturacion { get; set; }

    [JsonPropertyName("CodigoPeriodoFacturacion")]
    public string? CodigoPeriodoFacturacion { get; set; }

    [JsonPropertyName("DiasGracia")]
    public short? DiasGracia { get; set; }

    [JsonPropertyName("ValorFijoXTonelda")]
    public decimal? ValorFijoXTonelda { get; set; }

    [JsonPropertyName("DiasPeriodo")]
    public byte? DiasPeriodo { get; set; }

    [JsonPropertyName("DiasCobro")]
    public byte? DiasCobro { get; set; }

    [JsonPropertyName("ModalidadFacturacion")]
    public string? ModalidadFacturacion { get; set; }

    [JsonPropertyName("LiquidarDolar")]
    public bool? LiquidarDolar { get; set; }

    [JsonPropertyName("CondicionPago")]
    public string? CondicionPago { get; set; }

    [JsonPropertyName("FacturacionFinalizada")]
    public bool? FacturacionFinalizada { get; set; }

    [JsonPropertyName("TarifaPeriodo1")]
    public decimal? TarifaPeriodo1 { get; set; }

    [JsonPropertyName("TarifaPeriodo2")]
    public decimal? TarifaPeriodo2 { get; set; }

    [JsonPropertyName("TarifaPeriodo3")]
    public decimal? TarifaPeriodo3 { get; set; }

    [JsonPropertyName("TarifaPeriodo4")]
    public decimal? TarifaPeriodo4 { get; set; }

    [JsonPropertyName("TarifaPeriodo5")]
    public decimal? TarifaPeriodo5 { get; set; }

    [JsonPropertyName("TarifaPeriodo6")]
    public decimal? TarifaPeriodo6 { get; set; }

    [JsonPropertyName("FechaInicioFacturacion")]
    public DateTime? FechaInicioFacturacion { get; set; }

    [JsonPropertyName("FechaUltimaFactura")]
    public DateTime? FechaUltimaFactura { get; set; }

    [JsonPropertyName("NumeroUltimaFactura")]
    public string? NumeroUltimaFactura { get; set; }

    [JsonPropertyName("UltimoPeriodoFacturado")]
    public short? UltimoPeriodoFacturado { get; set; }

    [JsonPropertyName("FechaPrimerMovimiento")]
    public DateTime? FechaPrimerMovimiento { get; set; }

    [JsonPropertyName("ValorCIFDolar")]
    public decimal? ValorCIFDolar { get; set; }

    [JsonPropertyName("ValorCIFLocal")]
    public decimal? ValorCIFLocal { get; set; }

    [JsonPropertyName("ValorCIFCliente")]
    public decimal? ValorCIFCliente { get; set; }

    [JsonPropertyName("CopiasTiquete")]
    public short? CopiasTiquete { get; set; }

    [JsonPropertyName("Observaciones")]
    public string? Observaciones { get; set; }

    [JsonPropertyName("Comentarios")]
    public string? Comentarios { get; set; }

    [JsonPropertyName("ValorUnitario")]
    public decimal? ValorUnitario { get; set; }

    [JsonPropertyName("PesoPromedio")]
    public decimal? PesoPromedio { get; set; }

    [JsonPropertyName("BLKilosOriginal")]
    public int? BLKilosOriginal { get; set; }

    [JsonPropertyName("BLUnidadesOriginal")]
    public int? BLUnidadesOriginal { get; set; }

    [JsonPropertyName("BLKilos")]
    public int? BLKilos { get; set; }

    [JsonPropertyName("BLunidades")]
    public int? BLunidades { get; set; }

    [JsonPropertyName("NacionalizadoKilos")]
    public int? NacionalizadoKilos { get; set; }

    [JsonPropertyName("NacionalizadoUnidades")]
    public int? NacionalizadoUnidades { get; set; }

    [JsonPropertyName("RetenidoKilos")]
    public int? RetenidoKilos { get; set; }

    [JsonPropertyName("RetenidoUnidades")]
    public string? RetenidoUnidades { get; set; }

    [JsonPropertyName("EntradasUnidades")]
    public int? EntradasUnidades { get; set; }

    [JsonPropertyName("SalidasUnidades")]
    public int? SalidasUnidades { get; set; }

    [JsonPropertyName("EntradasKilos")]
    public int? EntradasKilos { get; set; }

    [JsonPropertyName("SalidasKilos")]
    public int? SalidasKilos { get; set; }

    [JsonPropertyName("CampoCliente1")]
    public string? CampoCliente1 { get; set; }

    [JsonPropertyName("CampoCliente2")]
    public string? CampoCliente2 { get; set; }

    [JsonPropertyName("CampoCliente3")]
    public string? CampoCliente3 { get; set; }

    [JsonPropertyName("IdEmpaque")]
    public int? IdEmpaque { get; set; }

    [JsonPropertyName("ValorCIFPrimerPeriodo")]
    public decimal? ValorCIFPrimerPeriodo { get; set; }

    [JsonPropertyName("Comun")]
    public bool? Comun { get; set; }

    [JsonPropertyName("ComprometidoKilos")]
    public int? ComprometidoKilos { get; set; }

    [JsonPropertyName("ComprometidoUnidades")]
    public int? ComprometidoUnidades { get; set; }

    [JsonPropertyName("ControlUnidades")]
    public bool? ControlUnidades { get; set; }

    [JsonPropertyName("Suspendido")]
    public bool? Suspendido { get; set; }

    [JsonPropertyName("CodigoUsuarioRechaza")]
    public string? CodigoUsuarioRechaza { get; set; }

    [JsonPropertyName("FechaAprobacionRechazo")]
    public DateTime? FechaAprobacionRechazo { get; set; }

    [JsonPropertyName("ComentarioRechazo")]
    public string? ComentarioRechazo { get; set; }

    [JsonPropertyName("IdVisitaMotonave")]
    public int? IdVisitaMotonave { get; set; }

    [JsonPropertyName("CodigoCompaniaFacturacion")]
    public string? CodigoCompaniaFacturacion { get; set; }

    [JsonPropertyName("IdSubDepositoFac1")]
    public int? IdSubDepositoFac1 { get; set; }

    [JsonPropertyName("IdSubDepositoFac2")]
    public int? IdSubDepositoFac2 { get; set; }

    [JsonPropertyName("IdSubDepositoFac3")]
    public int? IdSubDepositoFac3 { get; set; }

    [JsonPropertyName("TRM")]
    public decimal? TRM { get; set; }



    [JsonPropertyName("CondicionFacturacionNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual CondicionFacturacion? CondicionFacturacionNavegacion { get; set; }

    [JsonPropertyName("ProductoNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual Producto? ProductoNavegacion { get; set; } = null!;


    [JsonPropertyName("PeriodoFacturacionNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual PeriodoFacturacion? PeriodoFacturacionNavegacion { get; set; }


    [JsonPropertyName("UsuarioApruebaNavegacion")]
    [NotMapped]
    [JsonIgnore]
    public virtual Usuario? UsuarioApruebaNavegacion { get; set; } = null!;

    [JsonPropertyName("UsuarioCreaNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Usuario? UsuarioCreaNavegacion { get; set; } =   null!;

    [JsonPropertyName("CompaniaFacturacionNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Companium? CompaniaFacturacionNavegacion { get; set; }


    [JsonPropertyName("CompaniaNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Companium? CompaniaNavegacion { get; set; } = null!;


    [JsonPropertyName("EmpaqueNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Empaque? EmpaqueNavegacion { get; set; }

    [JsonPropertyName("SedeNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Sede? SedeNavegacion { get; set; } = null!;

    [JsonPropertyName("SubDepositoFacturacion1Navegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Deposito? SubDepositoFacturacion1Navegacion { get; set; }

    [JsonPropertyName("SubDepositoFacturacion2Navegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Deposito? SubDepositoFacturacion2Navegacion { get; set; }

    [JsonPropertyName("SubDepositoFacturacion3Navegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Deposito? SubDepositoFacturacion3Navegacion { get; set; }


    [JsonPropertyName("TerceroFacturacionNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Tercero? TerceroFacturacionNavegacion { get; set; }

    [JsonPropertyName("VisitaMotonaveNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual VisitaMotonave? VisitaMotonaveNavegacion { get; set; }


    [JsonPropertyName("TerceroNavegacion")]
    [NotMapped]
    //[JsonIgnore]
    public virtual Tercero? TerceroNavegacion { get; set; } = null!;


    [JsonPropertyName("ListaBLs")]
    [NotMapped]
    public virtual ICollection<DepositoBl>? ListaBLs { get; set; } = new List<DepositoBl>();


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
    public int? SaldoKilos { get; set; }



    [JsonPropertyName("SaldoUnidades")]
    [NotMapped]
    public int? SaldoUnidades { get; set; }


    [JsonPropertyName("SubDepositos")]
    [NotMapped]
    //public List<MdloDtos.SpSubDeposito>? SubDepositos { get; set; }
    public List<MdloDtos.DTO.SpSubDepositoDTO>? SubDepositos { get; set; }
    
    public DepositoDTO() { }

    //contructor para el subdeposito
    public DepositoDTO(string DeCia, int DeRowidTrcro,int DeRowidSdeDspcho, string DeCdgoDpstoPdre, string DeCdgoPrdcto,
        string DeCdgoUsrioCrea,int DeCntdad
        ) {

        this.CodigoCompania = DeCia;
        this.IdTercero = DeRowidTrcro;
        this.IdSedeDespacho = DeRowidSdeDspcho;
        this.CodigoDepositoPadre = DeCdgoDpstoPdre;
        this.CodigoProducto = DeCdgoPrdcto;
        this.CodigoUsuarioCrea = DeCdgoUsrioCrea;
        this.Cantidad = DeCntdad;

    }

    [NotMapped]
    public virtual ICollection<Orden> Ordens { get; set; } = new List<Orden>();


    [NotMapped]
    public virtual ICollection<SolicitudRetiro> SolicitudRetiros { get; set; } = new List<SolicitudRetiro>();
}
