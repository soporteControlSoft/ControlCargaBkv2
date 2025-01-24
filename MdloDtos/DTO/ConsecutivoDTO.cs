using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.DTO
{
    /// <summary>
    /// DTO Consecutivo , Control de pesaje
    /// Daniel Lopez
    /// </summary>
    public class ConsecutivoDTO
    {
        [Key]
        public int Id { get; set; }

        [StringLength(15)]
        [DataType(DataType.Text)]
        public string? CodigoCompania { get; set; } = null!;

        [StringLength(80)]
        [DataType(DataType.Text)]
        public string? NombreCompania { get; set; } = null!;

        [StringLength(15)]
        [DataType(DataType.Text)]
        public string? Codigo { get; set; } = null!;

        [StringLength(60)]
        [DataType(DataType.Text)]
        public string? Nombre { get; set; } = null!;

        public Int32 Contador { get; set; } = 0;


    }
}
