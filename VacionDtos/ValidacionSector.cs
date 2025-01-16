using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar las ciudades.
    /// </summary>
    public class ValidacionSector
    {
        AccsoDtos.EstadoHechos.Sector ObjSector = new AccsoDtos.EstadoHechos.Sector(null, null);
 

        #region Validacion de Clasificacion , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.SectorDTO objSector) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objSector.IdNombreSector) 
                   )
                {
                    //Validar la llave exitosa.
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
    }
}
