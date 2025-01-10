using AccsoDtos.Mappings;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para validar los productos.
    /// </summary>
    public class ValidacionVehiculo
    {
        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.ConfiguracionVehicular _ObjConfiguracionVehicular;
        AccsoDtos.Parametrizacion.Vehiculo _ObjVehiculo = new AccsoDtos.Parametrizacion.Vehiculo();

        public ValidacionVehiculo()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            _ObjConfiguracionVehicular = new AccsoDtos.Parametrizacion.ConfiguracionVehicular(_mapper);
        }



        #region Validacion de vehiculos , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.Vehiculo ObjVehiculo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjVehiculo.VeMtrcla)) && (ObjVehiculo.VeMdlo>0)  
                    )
                {
                    //Validar la llave relacional.
                    var ListaConfiguracion = await _ObjConfiguracionVehicular.FiltrarConfiguracionVehicularId(ObjVehiculo.VeRowidCnfgrcionVhclar);

                    if (ListaConfiguracion == null || ListaConfiguracion.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var VehiculoExiste = await _ObjVehiculo.VerificarVehiculo(ObjVehiculo.VeMtrcla);
                        if (VehiculoExiste == true)
                        {
                            //Retorna valor del TipoMensaje: CodigoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
                    }
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

        #region Validacion de vehiculo , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Vehiculo ObjVehiculo)
        {
            int resultado = 0;
            try
            {
                string? Id = ObjVehiculo.VeMtrcla;
                if (!string.IsNullOrEmpty(Id))
                {
                    //Validar que el codigo/Llave  exista.
                    var VehiculoExiste = await _ObjVehiculo.VerificarVehiculo(Id);
                    if (VehiculoExiste == false)
                    {
                        //Retorna valor del TipoMensaje: TransaccionIncorrecta
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                    }
                    else
                    {
                        //Retorna valor del TipoMensaje: TransaccionExitosa
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
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

        #region Validacion de vehiculo , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.Vehiculo ObjVehiculo)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(ObjVehiculo.VeMtrcla)) && (ObjVehiculo.VeMdlo > 0))
                 {
                    //Validar la llave relacional.
                    var ListaConfiguracion = await _ObjConfiguracionVehicular.FiltrarConfiguracionVehicularId(ObjVehiculo.VeRowidCnfgrcionVhclar);

                    if (ListaConfiguracion == null || ListaConfiguracion.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var VehiculoExiste = await _ObjVehiculo.VerificarVehiculo(ObjVehiculo.VeMtrcla);
                        if (VehiculoExiste == false)
                        {
                            //Retorna valor del TipoMensaje: CodigoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            //Retorna valor del TipoMensaje: TransaccionExitosa
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                        }
                    }
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

        #region Validacion de vehiculo,  Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(Busqueda)) || Busqueda.Length > 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

    }
}
