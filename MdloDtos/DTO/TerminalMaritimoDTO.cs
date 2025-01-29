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
    /// <summary>
    /// DTO Terminal Maritimo.
    /// Daniel Lopez
    /// </summary>
    public class TerminalMaritimoDTO
    {
        [Key]
        [StringLength(15)]
        public string Codigo { get; set; } = null!;

        [StringLength(40)]
        public string? Descripcion { get; set; }

        public bool? Estado { get; set; }

       
    }
}
