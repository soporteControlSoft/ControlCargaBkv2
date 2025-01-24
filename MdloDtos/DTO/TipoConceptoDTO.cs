using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    /// <summary>
    /// DTO tipo de concepto , Control de pesaje
    /// Daniel Lopez
    /// </summary>
    public class TipoConceptoDTO
    {
        [Key]
        [StringLength(15)]
        [DataType(DataType.Text)]
        public string Codigo { get; set; } = null!;

        [StringLength(30)]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; }


        [StringLength(3)]
        [DataType(DataType.Text)]
        public string? Naturaleza { get; set; }
    }
}
