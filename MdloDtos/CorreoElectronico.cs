using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos
{
    public class CorreoElectronico
    {
        public CorreoElectronico() { }
        public string Servidor_Correo { get; set; }
        public string Cuenta_Correo { get; set; }
        public string Clave_Correo { get; set; }
        public int Puerto_Correo { get; set; }
        public string Para { get; set; }
        public string Asunto { get; set; }

        public string Mensaje { get; set; }
        public string Nombre_Archivo { get; set; }
        public string Msg_error { get; set; }

    }
}
