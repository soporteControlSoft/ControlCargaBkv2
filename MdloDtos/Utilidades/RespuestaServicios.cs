using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.Utilidades
{
    /// <summary>
    /// Clase para Manejar Los errores de los servicios
    /// Daniel Alejandro Lopez
    /// </summary>
    public class RespuestaServicios
    {
        public int exito { get; set; }
        public string mensaje { get; set; }
        public Object datos { get; set; }


        public RespuestaServicios()
        {
            this.exito = 0;
        }
    }
}
