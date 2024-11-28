using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos
{
    /// <summary>
    /// Clase utilizanda para la autenticacion del usuario en el sistema de informacion
    /// Daniel Alejandro Lopez Alvarez
    /// </summary>
    public class AutenticacionUsuario
    {
        [Key]
        [Required]
        [StringLength(15)]
        public string CodigoEmpresa { get; set; }

        [Key]
        [Required]
        [StringLength(15)]
        public string CodigoUsuario { get; set; }

        [Required]
        [StringLength(15)]
        public string Clave { get; set; }

        [Required]
        [StringLength(15)]
        public string? ClaveNueva { get; set; }

        [StringLength(15)]
        public string CodigoCorreo { get; set; }
    }
}
