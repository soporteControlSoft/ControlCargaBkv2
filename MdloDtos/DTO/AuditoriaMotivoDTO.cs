using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    public class AuditoriaMotivoDTO
    {
        [Key]
        [StringLength(15)]
        public string Codigo { get; set; } = null!;

        [StringLength(15)]
        public string Nombre { get; set; } = null!;

        public bool? RequierePedirRazon { get; set; }

    }
}
