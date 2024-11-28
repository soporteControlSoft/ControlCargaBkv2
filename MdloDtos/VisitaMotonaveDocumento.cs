using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class VisitaMotonaveDocumento
{
    [Key]
    [JsonPropertyName("IdVisitaDocumento")]
    public int? VmdoRowid { get; set; }

    [JsonPropertyName("IdiVisitaMotonave")]
    public int? VmdoRowidVstaMtnve { get; set; }

    [JsonPropertyName("CodigoTipoDocumento")]
    public string? VmdoCdgoTpoDcmnto { get; set; } = null!;

    [JsonPropertyName("Estado")]
    public string? VmdoEstdo { get; set; } = null!;

    [JsonPropertyName("RutaArchivo")]
    public string? VmdoRta { get; set; } = null!;

    [JsonPropertyName("FechaCargue")]
    public DateTime? VmdoFchaCrgue { get; set; }

    [JsonPropertyName("FechaAprobacion")]
    public DateTime? VmdoFchaAprbcion { get; set; }

    [JsonPropertyName("CodigoUsuarioCargue")]
    public string? VmdoCdgoUsrioCrgue { get; set; } = null!;

    [JsonPropertyName("CodigoUsuarioAprobo")]
    public string? VmdoCdgoUsrioAprbdo { get; set; }

    [JsonPropertyName("Numero")]
    public string? VmdoNmro { get; set; }

    [JsonPropertyName("IdVisitaMotonaveBl")]
    public int? VmdoRowidVstaMtnveBl { get; set; }

    [JsonPropertyName("Comentario")]
    public string? VmdoCmntrio { get; set; }

    [JsonPropertyName("NumeroLinea")]
    public int? VmdoLnea { get; set; }

    [JsonPropertyName("Cantidad")]
    public int? VmdoCntdad { get; set; }

    [JsonPropertyName("Trm")]
    public decimal? VmdoTrm { get; set; }

    [JsonPropertyName("CostoSeguroFlete")]
    public decimal? VmdoCstoSgroFlte { get; set; }

    [JsonPropertyName("ArancelImportacion")]
    public decimal? VmdoArncelImprtcion { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual TipoDocumento? VmdoCdgoTpoDcmntoNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? VmdoCdgoUsrioAprbdoNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual Usuario? VmdoCdgoUsrioCrgueNavigation { get; set; } = null!;

    [JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonaveBl? VmdoRowidVstaMtnveBlNavigation { get; set; }

    [JsonIgnore]
    [NotMapped]
    public virtual VisitaMotonave? VmdoRowidVstaMtnveNavigation { get; set; } = null!;

    /// <summary>
    /// Propiedades Implementadas
    /// </summary>
    [NotMapped]
    public string? NombreMotonave { get; set; }

    [NotMapped]
    public short? SecuenciaVisita { get; set; }

    [NotMapped]
    public string? CodigoDocumento { get; set; }

    [NotMapped]
    public string? NombreDocumento { get; set; }

    [NotMapped]
    public string? OrigenDocumento { get; set; }

    [NotMapped]
    public string? NombreAsignar { get; set; }

    [NotMapped]
    public string? Color { get; set; }

    //Wilbert: Atributos para determinar cual es el documento actual del objeto
    [NotMapped]
    public MdloDtos.TipoDocumento? TipoDocumentoCargado { get; set; }

    //Wilbert: Atributos para cargar el levante con el documento en el mismo objeto
    [NotMapped]
    public MdloDtos.VisitaMotonaveBl1? VisitaMotonaveBl1 { get; set; }

    [NotMapped]
    public MdloDtos.TipoDocumento? TipoDocumento { get; set; }

    //Wilbert: Atributos creados para ingresar el BL y el documento en el mismo momento 
    [NotMapped]
    [JsonPropertyName("Levante")]
    public string? lvnte { get; set; }

    [NotMapped]
    [JsonPropertyName("CodigoDocumentoOrden")]
    public string? VmdoCdgoTpoDcmntoOrden { get; set; }

    [NotMapped]
    [JsonPropertyName("EstadoOrden")]
    public string? VmdoEstdoOrden { get; set; }

    [NotMapped]
    [JsonPropertyName("NumeroOrden")]
    public string? VmdoNmroOrden { get; set; }

    [NotMapped]
    [JsonPropertyName("RutaOrden")]
    public string? VmdoRtaOrden { get; set; }

    //Constructores de la Clase
    public VisitaMotonaveDocumento() { }

    public VisitaMotonaveDocumento(int VmdoRowidVstaMtnve, string NombreMotonave, short SecuenciaVisita)
    {
        this.VmdoRowidVstaMtnve = VmdoRowidVstaMtnve;
        this.NombreMotonave = NombreMotonave;
        this.SecuenciaVisita = SecuenciaVisita;
    }

    //Wilbert: Constructor para consultar todos los documentos asociados o no asociados a la visita Motonave
    public VisitaMotonaveDocumento(int? VmdoRowid, int VmdoRowidVstaMtnve, string VmdoCdgoTpoDcmnto,
                                    string CodigoDocumento, string NombreDocumento, string OrigenDocumento,
                                    string NombreAsignar, string VmdoEstdo)
    {
        this.VmdoRowid = VmdoRowid;
        this.VmdoRowidVstaMtnve = VmdoRowidVstaMtnve;
        this.VmdoCdgoTpoDcmnto = VmdoCdgoTpoDcmnto;
        this.CodigoDocumento = CodigoDocumento;
        this.NombreDocumento = NombreDocumento;
        this.OrigenDocumento = OrigenDocumento;
        this.NombreAsignar = NombreAsignar;
        this.VmdoEstdo = VmdoEstdo;
    }


    //ingresar BL Documento.
    public VisitaMotonaveDocumento(Int32 VmdoRowidVstaMtnve, string? VmdoCdgoTpoDcmnto, string? VmdoEstdo, string? VmdoRta,
                                    DateTime? VmdoFchaCrgue, string? VmdoCdgoUsrioCrgue,
                                 string? VmdoNmro, int? VmdoRowidVstaMtnveBl, string? lvnte,
                                    string? VmdoCdgoTpoDcmntoOrden, string? VmdoEstdoOrden, string? VmdoRtaOrden, string? VmdoNmroOrden, int VmdoCntdad)
    {
        this.VmdoRowidVstaMtnve = VmdoRowidVstaMtnve;
        this.VmdoCdgoTpoDcmnto = VmdoCdgoTpoDcmnto;
        this.VmdoEstdo = VmdoEstdo;
        this.VmdoRta = VmdoRta;
        this.VmdoFchaCrgue = VmdoFchaCrgue;
        this.VmdoCdgoUsrioCrgue = VmdoCdgoUsrioCrgue;
        this.VmdoNmro = VmdoNmro;
        this.VmdoRowidVstaMtnveBl = VmdoRowidVstaMtnveBl;
        this.lvnte = lvnte;
        this.VmdoCdgoTpoDcmntoOrden = VmdoCdgoTpoDcmntoOrden;
        this.VmdoEstdoOrden = VmdoEstdoOrden;
        this.VmdoRtaOrden = VmdoRtaOrden;
        this.VmdoNmroOrden = VmdoNmro;
        //this.VmdoCntdadOrden = VmdoCntdadOrden;
        this.VmdoCntdad = VmdoCntdad;
    }

    //actualizar
    public VisitaMotonaveDocumento(Int32 VmdoRowidVstaMtnve, string? VmdoCdgoTpoDcmnto, string? VmdoEstdo, string? VmdoRta,
                                   DateTime? VmdoFchaCrgue, string? VmdoCdgoUsrioCrgue,
                                string? VmdoNmro, int? VmdoRowidVstaMtnveBl, string? lvnte, int? VmdoLnea,
                                   string? VmdoCdgoTpoDcmntoOrden, string? VmdoEstdoOrden, string? VmdoRtaOrden, string? VmdoNmroOrden, /*int VmdoCntdadOrden,*/ int VmdoCntdad)
    {
        this.VmdoRowidVstaMtnve = VmdoRowidVstaMtnve;
        this.VmdoCdgoTpoDcmnto = VmdoCdgoTpoDcmnto;
        this.VmdoEstdo = VmdoEstdo;
        this.VmdoRta = VmdoRta;
        this.VmdoFchaCrgue = VmdoFchaCrgue;
        this.VmdoCdgoUsrioCrgue = VmdoCdgoUsrioCrgue;
        this.VmdoNmro = VmdoNmro;
        this.VmdoRowidVstaMtnveBl = VmdoRowidVstaMtnveBl;
        this.lvnte = lvnte;
        this.VmdoCdgoTpoDcmntoOrden = VmdoCdgoTpoDcmntoOrden;
        this.VmdoEstdoOrden = VmdoEstdoOrden;
        this.VmdoRtaOrden = VmdoRtaOrden;
        this.VmdoNmroOrden = VmdoNmro;
        this.VmdoLnea = VmdoLnea;
        //this.VmdoCntdadOrden = VmdoCntdadOrden;
        this.VmdoCntdad = VmdoCntdad;
    }
}
