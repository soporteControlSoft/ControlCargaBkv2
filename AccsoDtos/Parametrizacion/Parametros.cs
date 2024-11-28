using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Crud Parametros
    /// </summary>
    public class Parametros:MdloDtos.IModelos.IParametros
    {
        #region Consultar todos los datos de Parametros 
        public async Task<List<MdloDtos.Parametro>> ListarParametro()
        {
            List<MdloDtos.Parametro> listadoParametro = new List<MdloDtos.Parametro>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from para in _dbContex.Parametros
                                 select new {

                                     Ruta = para.PaNasRuta,
                                     UsuarioNas = para.PaNasUsuario,
                                     Clave=para.PaNasClave,
                                     Puerto=para.PaNasPuerto
                                             }
                                 ).ToListAsync();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.Parametro objParametro = new MdloDtos.Parametro(
                                                                //Atributos Sede
                                                                item.Ruta,
                                                                item.UsuarioNas,
                                                                item.Clave,
                                                                item.Puerto
                                                               );
                    //Agregamnos la Sede a la lista
                    listadoParametro.Add(objParametro);
                }
                _dbContex.Dispose();
                return listadoParametro;
            }

        }
        #endregion
    }
}
