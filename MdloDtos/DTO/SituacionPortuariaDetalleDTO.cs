using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos.DTO;

public partial class SituacionPortuariaDetalleDTO
{
    [Key]
    [JsonPropertyName("Id")]
    public int Id { get; set; }

    [JsonPropertyName("IdSituacionPortuaria")]
    public int? IdSituacionPortuaria { get; set; }

    [JsonPropertyName("IdTercero")]
    public int? IdTercero { get; set; }

    [JsonPropertyName("CodigoProducto")]
    public string? CodigoProducto { get; set; }

    [JsonPropertyName("Tmbl")]
    public int? Tmbl { get; set; }

    [JsonPropertyName("CodigoUnidadMedida")]
    public string? CodigoUnidadMedida { get; set; }

    [JsonPropertyName("Cantidad")]
    public int? Cantidad { get; set; }

    [JsonPropertyName("OperadorPortuario")]
    public int? OperadorPortuario { get; set; }

    public int? SpdEsctlla { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual Producto? SdpCdgoPrdctoNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual UnidadMedidum? SpdCdgoUndadMddaNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual Tercero? SpdRowidOprdorPrtrioNavigation { get; set; } = null!;

    //[JsonIgnore]
    [NotMapped]
    public virtual SituacionPortuarium? SpdRowidStcionPrtriaNavigation { get; set; }

    //[JsonIgnore]
    [NotMapped]
    public virtual Tercero? SpdRowidTrcroNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveBl> VisitaMotonaveBls { get; set; } = new List<VisitaMotonaveBl>();

    [JsonIgnore]
    [NotMapped]
    public virtual ICollection<VisitaMotonaveDetalle> VisitaMotonaveDetalles { get; set; } = new List<VisitaMotonaveDetalle>();

    /// <summary>
    /// Propiedad implementadas de forma manual.
    /// </summary>
    [NotMapped]
    public string? UnidadMedidaCodigo { get; set; }

    [NotMapped]
    public string? UnidadMedidaDescripcion { get; set; }

    [NotMapped]
    public string? ProductoCodigo { get; set; }

    [NotMapped]
    public string? ProductoNombre { get; set; }

    [NotMapped]
    public string? TerceroCodigo { get; set; }

    [NotMapped]
    public string? TerceroNombre { get; set; }


    public SituacionPortuariaDetalleDTO() { }


    public SituacionPortuariaDetalleDTO(int spdRowid, int? spdRowidStcionPrtria, int spdRowidTrcro, string? sdpCdgoPrdcto, int? sdpTmBl, string? spdCdgoUndadMdda, int? spdCntdad, int? SpdRowidOprdorPrtrio,
                                     string? UnidadMedidaCodigo, string? UnidadMedidaDescripcion, string? ProductoCodigo, string? ProductoNombre, string? TerceroCodigo, string? TerceroNombre)
    {
        this.Id = spdRowid;
        this.IdSituacionPortuaria = spdRowidStcionPrtria;
        this.IdTercero = spdRowidTrcro;
        this.CodigoProducto = sdpCdgoPrdcto;
        this.Tmbl = sdpTmBl;
        this.CodigoUnidadMedida = spdCdgoUndadMdda;
        this.Cantidad = spdCntdad;
        this.OperadorPortuario = SpdRowidOprdorPrtrio;
        this.UnidadMedidaCodigo = UnidadMedidaCodigo;
        this.UnidadMedidaDescripcion = UnidadMedidaDescripcion;
        this.ProductoCodigo = ProductoCodigo;
        this.ProductoNombre = ProductoNombre;
        this.TerceroCodigo = TerceroCodigo;
        this.TerceroNombre = TerceroNombre;
    }


}
