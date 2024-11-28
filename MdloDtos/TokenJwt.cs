using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos
{
    /// <summary>
    /// Clase para encapsular lois datos del Archivo de  configuracion Json para la generacion del Token. 
    /// Daniel Alejandro Lopez
    /// </summary>
    public class TokenJwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Subjet { get; set; }


    }
}
