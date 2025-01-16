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
    public class SectorDTO
    {
        [Key]
        public int IdSector { get; set; }

        [StringLength(15)]
        public string IdCodigoSector { get; set; } = null!;

        [StringLength(20)]
        public string IdNombreSector { get; set; } = null!;


    }
}
