using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.Utilidades
{
    public class Conexiones
    {
        //Cadena de Conexion SQL SERVER para ADO NET y para EF.
        //daniel 
        //public static string CadenaConexion = @"Server=DESKTOP-KBI7I1E\SQLEXPRESS;Initial Catalog=cc_ventura;Persist Security Info=False;User ID=pruebas1234;Password=pruebas1234;Connection Timeout=30;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=FALSE;";

        //wilbert
        // public static string CadenaConexion = @"Server=172.30.200.113\MSSQLSERVER,2330;Initial Catalog=cc_ventura;Persist Security Info=False;User ID=sa;Password=V3ntuRAdata.2;Connection Timeout=30;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=FALSE;";
        // public static string CadenaConexion = @"Server=172.30.200.113\MSSQLSERVER,2330;Initial Catalog=cc_ventura;Persist Security Info=False;User ID=sa;Password=V3ntuRAdata.2;Connection Timeout=30;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=FALSE;";
        public static string CadenaConexion = @"Server=172.30.200.110\MSSQLSERVER,2330;Initial Catalog=cc_ventura;Persist Security Info=False;User ID=sa;Password=V3ntuRAdata.2;Connection Timeout=30;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=FALSE;";
        //
        //servidor

        //public static string CadenaConexion = @"Server=ULISES\MSSQLSERVER,2330;Initial Catalog=cc_ventura;Persist Security Info=False;User ID=pruebas1234;Password=pruebas1234;Connection Timeout=30;Trusted_Connection=True;TrustServerCertificate=True;Integrated Security=FALSE;";

        /// <summary>
        /// Objetos Conexiones para EF y LINQ.
        /// </summary>

        public static MdloDtos.Utilidades.RespuestaServicios _respuesta = new RespuestaServicios();
        // public static MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext();

    }
}
