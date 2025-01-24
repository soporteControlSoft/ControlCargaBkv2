using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    public class AuditoriaModuloDTO
    {
        [Key]
        [StringLength(15)]
        public string? Codigo { get; set; }

        [StringLength(30)]
        public string? Nombre { get; set; }



    }
}
