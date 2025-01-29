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
    /// <summary>
    /// Clase para Validar las Estado de hechosos.
    /// </summary>
    public class ValidacionEstadoHecho
    {
        private readonly IMapper _mapper;

        AccsoDtos.EstadoHechos.EstadoHecho ObjEstadoHecho;
        AccsoDtos.EstadoHechos.Evento _ObjEvento = new AccsoDtos.EstadoHechos.Evento(null, null);
        AccsoDtos.EstadoHechos.Sector _ObjSector = new AccsoDtos.EstadoHechos.Sector(null, null);
        AccsoDtos.Parametrizacion.Usuario _ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();

        public ValidacionEstadoHecho()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjEstadoHecho = new AccsoDtos.EstadoHechos.EstadoHecho(_mapper);
        }


        #region Validacion de EstsadoHecho , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.EstadoHechoDTO objEstadoHecho) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if (
                    !string.IsNullOrEmpty(objEstadoHecho.EhObsrvcion) &&
                    objEstadoHecho.EhFchaIncio != DateTime.MinValue && // Validación para DateTime
                    objEstadoHecho.EhRowidEvnto > 0 &&
                    objEstadoHecho.EhRowidSctor > 0
                   )
                {
                    //Validar la llave relacional.
                    var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objEstadoHecho.EhCdgoUsrio);
                    if (UsuarioExiste == false)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar la llave relacional con la evento.
                        var EventoExiste = await _ObjEvento.VerificarEvento(objEstadoHecho.EhRowidEvnto);
                        if (EventoExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {   //Validar la llave relacional con la Responsable.
                            var SectorExiste = await _ObjSector.VerificarSector(objEstadoHecho.EhRowidSctor);
                            if (SectorExiste == false)
                            {
                                //Retorna valor del TipoMensaje: RelacionNoExiste
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            }
                            else
                            {   //Validar la llave relacional con la Responsable.
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

        #region Validacion de estadoHechos , metodo modificar estado
        public async Task<int> ValidarModificarEstadoEstadoHecho(MdloDtos.DTO.EstadoHechoDTO objEstadoHecho)
        {
           
            int resultado = 0;
            try
            {
                //Validar la llave relacional.
                var EstadoHechosExiste = await ObjEstadoHecho.VerificarEstadoHecho(objEstadoHecho.EhRowid);
                if (EstadoHechosExiste == true)
                {
                    if (
                       objEstadoHecho.EhRowid > 0
                        )
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

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

        #region Validacion de estadoHechos , metodo Cerrar
        public async Task<int> ValidarCerrarOcancelarEstadoEstadoHecho(MdloDtos.DTO.EstadoHechoDTO objEstadoHecho)
        {

            int resultado = 0;
            try
            {
                //Validar la llave relacional.
                var EstadoHechosExiste = await ObjEstadoHecho.VerificarEstadoHecho(objEstadoHecho.EhRowid);
                if (EstadoHechosExiste == true)
                {
                    //validamos el id para ver si el evento de este estado de hechos exite
                    if (
                        !string.IsNullOrEmpty(objEstadoHecho.EhEstdo) &&
                        objEstadoHecho.EhRowid > 0
                        )
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

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

        #region Validacion de estadoHechos , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.EstadoHechoDTO objEstadoHecho)
        {
            int resultado = 0;
            try
            {
                var EstadoHechoExiste = await ObjEstadoHecho.VerificarEstadoHecho(objEstadoHecho.EhRowid);
                if (EstadoHechoExiste == true)
                {
                    //Validar los campos Obligatorios.
                    if (
                        !string.IsNullOrEmpty(objEstadoHecho.EhObsrvcion) &&
                        objEstadoHecho.EhFchaIncio != DateTime.MinValue && // Validación para DateTime
                        objEstadoHecho.EhRowidEvnto > 0 &&
                        objEstadoHecho.EhRowidSctor > 0
                       )
                    {
                        //Validar la llave relacional.
                        var UsuarioExiste = await _ObjUsuario.VerificarUsuario(objEstadoHecho.EhCdgoUsrio);
                        if (UsuarioExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            //Validar la llave relacional con la evento.
                            var EventoExiste = await _ObjEvento.VerificarEvento(objEstadoHecho.EhRowidEvnto);
                            if (EventoExiste == false)
                            {
                                //Retorna valor del TipoMensaje: RelacionNoExiste
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                            }
                            else
                            {   //Validar la llave relacional con la Responsable.
                                var SectorExiste = await _ObjSector.VerificarSector(objEstadoHecho.EhRowidSctor);
                                if (SectorExiste == false)
                                {
                                    //Retorna valor del TipoMensaje: RelacionNoExiste
                                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                                }
                                else
                                {   //Validar la llave relacional con la Responsable.
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
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TipoDatoIncorrecto;
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

        #region Validacion de estadohecho Validar Busquedas ( Filtros)
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

        #region Validacion de eventos de un estadohecho validamos si tiene datos
        public async Task<int> ValidarCamposEventosEstadoHecho(string? estado, int? idEstadohechoVmOZc)
        {
            int resultado = 0;
            try
            {
                if (
                    ((!string.IsNullOrEmpty(estado)) || estado.Length > 0) && 
                    idEstadohechoVmOZc > 0
                   )                     
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
