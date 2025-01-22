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
    /// Clase para Validar las Sedes.
    /// </summary>
    public class ValidacionSede
    {

        private readonly IMapper _mapper;

        AccsoDtos.Parametrizacion.Compania ObjCompania;
        AccsoDtos.Parametrizacion.Sede ObjSede;

        public ValidacionSede()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjSede = new AccsoDtos.Parametrizacion.Sede(_mapper);
            ObjCompania = new AccsoDtos.Parametrizacion.Compania(_mapper);
        }

        #region Validacion de Sede , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.SedeDTO objSede) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if ( (!string.IsNullOrEmpty(objSede.SeCdgo)) && (!string.IsNullOrEmpty(objSede.SeCdgoCia))
                    && (!string.IsNullOrEmpty(objSede.SeNmbre)) && (!string.IsNullOrEmpty(objSede.SeCdgoDpstoAdnro)))
                {
                    //Validar la llave relacional.
                    var ListaCompania = await ObjCompania.FiltrarCompaniaEspecifico(objSede.SeCdgoCia.ToString());
                    if (ListaCompania == null || ListaCompania.Count==0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var SedeExiste = await ObjSede.VerificarSede(objSede.SeCdgo);
                        if (SedeExiste == true)
                        {
                            //Retorna valor del TipoMensaje: CodigoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjSede.ValidacionSedeNombreIngresar(objSede);
                            //validar si el nombre existe
                            if (NombreExiste == true)
                            {
                                //Retorna el valor del tipo de mensaje: Nombre existe
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                            }
                            else {

                                //Retorna valor del TipoMensaje: TransaccionExitosa
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                            }
                           
                        }
                    }
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

        #region Validacion de Sede , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.Sede objSede_)
        {
            int resultado = 0;
            try
            {
                if(objSede_.SeRowid != null)
                {
                    //Validar que el codigo/Llave  exista.
                    var SedeExiste = await ObjSede.VerificarSedePorRowId((int)objSede_.SeRowid);
                    if (SedeExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
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

        #region Validacion de Sede , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.SedeDTO objSede)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objSede.SeCdgo)) && (!string.IsNullOrEmpty(objSede.SeCdgoCia))
                    && (!string.IsNullOrEmpty(objSede.SeNmbre)) && (!string.IsNullOrEmpty(objSede.SeCdgoDpstoAdnro)))
                {
                    //Validar la llave relacional.
                    var ListaCompania = await ObjCompania.FiltrarCompaniaEspecifico(objSede.SeCdgoCia.ToString());
                    if (ListaCompania == null || ListaCompania.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var SedeExiste = await ObjSede.VerificarSede(objSede.SeCdgo);
                        if (SedeExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            var NombreExiste = ObjSede.ValidacionSedeNombreActualizar(objSede);
                            //validar si el nombre existe
                            if (NombreExiste == true)
                            {
                                //Retorna el valor del tipo de mensaje: Nombre existe
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NombreExiste;
                            }
                            else {

                                //Retorna valor del TipoMensaje: TransaccionExitosa
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                            }
                            

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

        #region Validacion de Sede Validar Busquedas ( Filtros)
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
