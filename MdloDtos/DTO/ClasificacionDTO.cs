using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    /// <summary>
    /// DTO Clasificaciom, Estado de hechos
    /// Jesus alberto calzada
    /// </summary>
    public class ClasificacionDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(60)]
        public string? Nombre { get; set; } = null!;

        [StringLength(255)]
        public string? Descripcion { get; set; } = null!;

        public DateTime? FechaCreacion { get; set; }

        [StringLength(15)]
        public string? CodigoUsuario { get; set; }

        public bool Estado { get; set; }

    }
}
