using MdloDtos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.EstadoHechos
{
    /// <summary>
    /// Clase para el acceso a datos de la clase Clasificacion
    /// Jesus Alberto Calzada
    /// </summary>
    /// 
    public class vwEstadoHechosListas : MdloDtos.IModelos.IEstadoHechosListas
    {
        #region Listar las visitas de motonaves en el estado de hechos
        public async Task<List<MdloDtos.VwEstdoHchoLstarVstaMtnve>> ListarEstadoHechosVisitaMotonave()
        {
            List<MdloDtos.VwEstdoHchoLstarVstaMtnve> ListarEstadoHechosVisitaMotonave = new List<MdloDtos.VwEstdoHchoLstarVstaMtnve>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                ListarEstadoHechosVisitaMotonave = await _dbContex.VwEstdoHchoLstarVstaMtnves
                    .OrderBy(v => v.EmNmbre == "ATRACADA" ? 1 :
                                  v.EmNmbre == "FONDEADA" ? 2 :
                                  v.EmNmbre == "ANUNCIADA" ? 3 :
                                  v.EmNmbre == "ZARPE" ? 4 : 5) // Ordenar según el valor de EmNmbre
                    .ToListAsync();
                _dbContex.Dispose();
            }
            return ListarEstadoHechosVisitaMotonave;
        }
        #endregion

        #region Hora del sistema
        public async Task<DateTime> ObtenerHoraSistemaAsync()
        {
            // Simula una operación asincrónica usando Task.Run para obtener la hora del sistema
            return await Task.Run(() => DateTime.Now);
        }
        #endregion

        #region Consultar todos los eventos de un estado de hechos mediante id de la visita motonave o id de la zona bodega o silo o zona de operacion tambien incluiremos el estado para saber si buscamos donde el estado es Cerrado = c, Nocerrado = NC o Inactivo = I.
        public async Task<List<MdloDtos.SpListarEstadosHecho>> ListarEstadoHechosEventos(SpListarEstadosHecho spListarEstadosHecho)
        {
            List<MdloDtos.SpListarEstadosHecho> listaEstadoHechoEvento = new List<MdloDtos.SpListarEstadosHecho>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.SpListarEstadosHechoSegunEstado(spListarEstadosHecho.eh_rowid_vsta_mtnve,spListarEstadosHecho.eh_estdo );

                listaEstadoHechoEvento = query;

                _dbContex.Dispose();
                return listaEstadoHechoEvento;
            }
        }
        #endregion

        #region Filtrar ListaEstadoHechosGeneral por codigo o descripcion general
        public async Task<List<MdloDtos.VwEstdoHchoLstarVstaMtnve>> FiltrarListarEstadoHechosVisitaMotonaveGeneral(string busqueda)
        {
            // Crear una lista vacía para almacenar los resultados
            List<MdloDtos.VwEstdoHchoLstarVstaMtnve> ListarEstadoHechosVisitaMotonaveBusqueda = new List<MdloDtos.VwEstdoHchoLstarVstaMtnve>();

            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                // Realizar la consulta con el filtro de búsqueda
                ListarEstadoHechosVisitaMotonaveBusqueda = await _dbContex.VwEstdoHchoLstarVstaMtnves
                    .Where(v => string.IsNullOrEmpty(busqueda)  // Verificar si el parámetro de búsqueda está vacío
                                || v.VmRowid.ToString().Contains(busqueda) // Filtrar por vm_rowid como string
                                || v.VmDscrpcion.Contains(busqueda)) // Filtrar por vm_dscrpcion
                    .OrderBy(v => v.EmNmbre == "ATRACADA" ? 1 :
                                  v.EmNmbre == "FONDEADA" ? 2 :
                                  v.EmNmbre == "ANUNCIADA" ? 3 :
                                  v.EmNmbre == "ZARPE" ? 4 : 5) // Ordenar según el valor de EmNmbre
                    .ToListAsync();

                // No es necesario llamar a _dbContex.Dispose() explícitamente ya que se usa dentro de un using
            }

            return ListarEstadoHechosVisitaMotonaveBusqueda;
        }

        #endregion
    }
}
