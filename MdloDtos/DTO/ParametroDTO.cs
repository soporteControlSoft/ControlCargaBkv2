using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    /// <summary>
    /// DTO Parametro
    /// Wilbert Rivas Granados
    /// </summary>
    public class ParametroDTO
    {
        [Key]
        public int Id { get; set; }

        public string? Empresa { get; set; }

        public int? DiasVigenciaClaveInternos { get; set; }

        public int? DiasVigenciaClaveExternos { get; set; }

        public int? ClavesAnteriores { get; set; }

        public int? DiasExternos { get; set; }

        public string? ServidorCorreo { get; set; }

        public string? CorreoUsuario { get; set; }

        public string? CorreoClave { get; set; }

        public short? CorreoPuerto { get; set; }

        public bool? CorreoConexionSegura { get; set; }

        public string? URL { get; set; }

        public string? RutaNas { get; set; }

        public string? UsuarioNas { get; set; }

        public string? ClaveNas { get; set; }

        public int? PuertoNas { get; set; }

        public int? SaldoBajoDeposito { get; set; }

        public int? SaldoBajoSolicitudRetiro { get; set; }

        public int? PesoMaximoCargar { get; set; }

        public int? MinutosVigenciaReserva { get; set; }

        public ParametroDTO() { }

        public ParametroDTO(string RutaNas, string UsuarioNas, string ClaveNas, int? PuertoNas)
        {
            this.RutaNas = RutaNas;
            this.UsuarioNas = UsuarioNas;
            this.ClaveNas = ClaveNas;
            this.PuertoNas = PuertoNas;
        }


    }
}
