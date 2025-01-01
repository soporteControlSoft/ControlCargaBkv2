using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MdloDtos;

public partial class Parametro
{
    [Key]
    [JsonPropertyName("Id")]
    public int PaId { get; set; }

    [JsonPropertyName("Empresa")]
    public string? PaEmprsa { get; set; }

    [JsonPropertyName("DiasVigenciaClaveInternos")]
    public int? PaDiasVgnciaClveIntrnos { get; set; }

    [JsonPropertyName("DiasVigenciaClaveExternos")]
    public int? PaDiasVgnciaClveExtrnos { get; set; }

    [JsonPropertyName("ClavesAnteriores")]
    public int? PaClvesAntrres { get; set; }

    [JsonPropertyName("DiasExternos")]
    public int? PaDiasInctvcionExtrnos { get; set; }

    [JsonPropertyName("ServidorCorreo")]
    public string? PaCrreoSrvdor { get; set; }

    [JsonPropertyName("CorreoUsuario")]
    public string? PaCrreoUsrio { get; set; }

    [JsonPropertyName("CorreoClave")]
    public string? PaCrreoClve { get; set; }

    [JsonPropertyName("CorreoPuerto")]
    public short? PaCrreoPrto { get; set; }

    [JsonPropertyName("CorreoConexionSegura")]
    public bool? PaCrreoCnxionSgra { get; set; }

    [JsonPropertyName("URL")]
    public string? PaUrlPrtalLgstco { get; set; }

    [JsonPropertyName("RutaNas")]
    public string? PaNasRuta { get; set; }

    [JsonPropertyName("UsuarioNas")]
    public string? PaNasUsuario { get; set; }

    [JsonPropertyName("ClaveNas")]
    public string? PaNasClave { get; set; }

    [JsonPropertyName("PuertoNas")]
    public int? PaNasPuerto { get; set; }

    public int? PaSldoBjoDpsto { get; set; }

    public int? PaSldoBjoSlctudRtro { get; set; }

    public int? PaPsoMxmoACrgar { get; set; }

    public int? PaMntosVgnviaRsrva { get; set; }


    public Parametro() { }

    public Parametro(string PaNasRuta, string PaNasUsuario, string PaNasClave, int? PaNasPuerto)
    {
        this.PaNasRuta = PaNasRuta;
        this.PaNasUsuario = PaNasUsuario;
        this.PaNasClave = PaNasClave;
        this.PaNasPuerto = PaNasPuerto;
    }
}
