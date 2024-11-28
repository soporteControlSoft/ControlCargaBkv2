using MdloDtos.IModelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.AccesoSistema
{
    /// <summary>
    /// Clase para generar una contraseña aleatotoria
    /// Daniel Alejandro lopez.
    /// </summary>
    public  class GeneradorClave: IGeneradoClave
    {
        public  string generarContraseñaAleatoria(int digitos)
        {
            const string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            StringBuilder sb = new StringBuilder();
            Random rnd = new Random();

            for (int i = 0; i < digitos; i++)
            {
                int index = rnd.Next(chars.Length);
                sb.Append(chars[index]);
            }

            return sb.ToString();
        }
    }
}
