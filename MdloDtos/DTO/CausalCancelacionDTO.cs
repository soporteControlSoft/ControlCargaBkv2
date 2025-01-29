using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    public class CausalCancelacionDTO
    {
        /// <summary>
        /// DTO Causal Cancelacion , Control de pesaje
        /// Daniel Lopez
        /// </summary>

        [Key]
        [StringLength(15)]
        public string Codigo { get; set; } = null!;

        [StringLength(100)]
        public string? Descripcion { get; set; }

        [StringLength(1)]
        public string? Origen { get; set; }
    }
}
