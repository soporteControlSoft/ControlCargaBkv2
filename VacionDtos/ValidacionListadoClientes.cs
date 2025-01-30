using AccsoDtos.Mappings;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    public class ValidacionListadoClientes
    {
        private readonly IMapper _mapper;

        AccsoDtos.ListadoClientes.ListadoClientesEncabezado ObjListadoClientesEncabezado = new AccsoDtos.ListadoClientes.ListadoClientesEncabezado();
        AccsoDtos.Parametrizacion.Tercero ObjTercero;

        public ValidacionListadoClientes()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjTercero = new AccsoDtos.Parametrizacion.Tercero(_mapper);
        }

        #region Validacion Listado de clientes encabezado( actualizar)
        public async Task<int> ValidarActualizacion(MdloDtos.VwListadoClientesEncabezado objListadoClientes)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objListadoClientes.IdTercero.ToString()) && (!string.IsNullOrEmpty(objListadoClientes.CodPrestadoServicio)))
                {
                    //Validar que el codigo/Llave del tercero  exista.
                    var TerceroExiste = await ObjTercero.VerificarTerceroPorId(objListadoClientes.IdTercero);
                    if (TerceroExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

            }
            return resultado;
        }
        #endregion

        #region Validacion Listado de clientes Detalle( actualizar)
        public async Task<int> ValidarActualizacionDetalle(MdloDtos.VwListadoClientesDetalle objListadoClientes)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (!string.IsNullOrEmpty(objListadoClientes.Ecotilla.ToString()) && (!string.IsNullOrEmpty(objListadoClientes.RequisitoCliente.ToString()) )
                    && !string.IsNullOrEmpty(objListadoClientes.Directo.ToString()) && !string.IsNullOrEmpty(objListadoClientes.Almacenar.ToString()) 
                     && !string.IsNullOrEmpty(objListadoClientes.Localizacion.ToString()))
                {
                   
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    //Retorna valor del TipoMensaje: NoAceptaValoresNull
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

            }
            return resultado;
        }
        #endregion
    }
}
