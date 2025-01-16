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
    /// Clase para Validar Visita Motonave Bl
    /// </summary>
    public class ValidacionVisitaMotonaveBl
    {
        private readonly IMapper _mapper;

        AccsoDtos.VisitaMotonave.VisitaMotonaveDetalle ObjVisitaMotonaveDetalle = new AccsoDtos.VisitaMotonave.VisitaMotonaveDetalle();
        AccsoDtos.VisitaMotonave.VisitaMotonave ObjVisitaMotonave = new AccsoDtos.VisitaMotonave.VisitaMotonave();
        AccsoDtos.Parametrizacion.UnidadMedida ObjUnidadMedida;
        AccsoDtos.Parametrizacion.Usuario ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();
        AccsoDtos.VisitaMotonave.VisitaMotonaveBl ObjVisitaMotonaveBl = new AccsoDtos.VisitaMotonave.VisitaMotonaveBl();

        public ValidacionVisitaMotonaveBl()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjUnidadMedida = new AccsoDtos.Parametrizacion.UnidadMedida(_mapper);

        }

        #region Validacion de  VisitaMotonaveBl , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl)
        {
            int resultado = 0;
            try
            {
                if (objVisitaMotonaveBl.VmblCdgoUndadMdda != null && resultado == 0)
                {
                    var UndadMddaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objVisitaMotonaveBl.VmblCdgoUndadMdda);
                    if (UndadMddaExiste == false)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                }
                if (objVisitaMotonaveBl.VmblRowidVstaMtnveDtlle != null && resultado == 0)
                {
                    var VstaMtnveDtlleExiste = await ObjVisitaMotonaveDetalle.FiltrarVisitaMotonaveDetalleEspecifico((int)objVisitaMotonaveBl.VmblRowidVstaMtnveDtlle);
                    if (VstaMtnveDtlleExiste.Count <= 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }
                if (objVisitaMotonaveBl.VmblCdgoUsrioCrgue != null && resultado == 0)
                {
                    var UsuarioExiste = await ObjUsuario.FiltrarUsuarioEspecifico(objVisitaMotonaveBl.VmblCdgoUsrioCrgue);
                    if (UsuarioExiste.Count <= 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }

                }
                //Validar los campos Obligatorios.
                if (objVisitaMotonaveBl.VmblRowidVstaMtnveDtlle != null && objVisitaMotonaveBl.VmblCdgoUsrioCrgue != null && resultado == 0)
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    if (resultado == 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de VisitaMotonaveBl , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl_)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if (objVisitaMotonaveBl_.VmblCdgoUsrioCrgue != null && objVisitaMotonaveBl_.VmblRowid != null &&
                   objVisitaMotonaveBl_.VmblRowidVstaMtnveDtlle != null)
                {
                    if (objVisitaMotonaveBl_.VmblCdgoUndadMdda != null && resultado == 0)
                    {
                        var UndadMddaExiste = await ObjUnidadMedida.VerificarUnidadMedida(objVisitaMotonaveBl_.VmblCdgoUndadMdda);
                        if (UndadMddaExiste == false)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                    }

                    if (objVisitaMotonaveBl_.VmblRowidVstaMtnveDtlle != null && resultado == 0)
                    {
                        var VstaMtnveDtlleExiste = await ObjVisitaMotonaveDetalle.FiltrarVisitaMotonaveDetalleEspecifico((int)objVisitaMotonaveBl_.VmblRowidVstaMtnveDtlle);
                        if (VstaMtnveDtlleExiste.Count <= 0)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }

                    }
                    if (objVisitaMotonaveBl_.VmblCdgoUsrioCrgue != null && resultado == 0)
                    {
                        var UsuarioExiste = await ObjUsuario.FiltrarUsuarioEspecifico(objVisitaMotonaveBl_.VmblCdgoUsrioCrgue);
                        if (UsuarioExiste.Count <= 0)
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }

                    }
                    if (objVisitaMotonaveBl_.VmblRowid != null && resultado == 0)
                    {
                        var VisitaMotonaveBlExiste = await ObjVisitaMotonaveBl.FiltrarVisitaMotonaveBlEspecifico(objVisitaMotonaveBl_.VmblRowid);
                        if (VisitaMotonaveBlExiste.Count <= 0 || ((VisitaMotonaveBlExiste.Count >= 1 && !VisitaMotonaveBlExiste[0].VmblEstdo.Equals("C"))))
                        {
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                    }
                    if (resultado == 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }

            return resultado;
        }
        #endregion

        #region Validacion de VisitaMotonaveBl Validar Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(string? Busqueda)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(Busqueda)) || Busqueda.Length > 0)
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }

            return resultado;
        }
        #endregion

        #region Validacion de filtro de busquedas por IdVisitaMotonaveDetalle para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdVisitaMotonaveDetalle(int? idVisitaMotonaveDetalle)
        {
            int resultado = 0;
            try
            {
                if (idVisitaMotonaveDetalle != null && idVisitaMotonaveDetalle > 0)
                {
                    var VstaMtnveDtlleExiste = await ObjVisitaMotonaveDetalle.FiltrarVisitaMotonaveDetalleEspecifico((int)idVisitaMotonaveDetalle);
                    if (VstaMtnveDtlleExiste.Count <= 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de filtro de busquedas por IdVisitaMotonave para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdVisitaMotonave(int? idVisitaMotonave)
        {
            int resultado = 0;
            try
            {
                if (idVisitaMotonave != null && idVisitaMotonave > 0)
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
        #region Validacion de filtro de busquedas por   IdVisitaMotonave, IdTercero, codigoProducto para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasVisitaMotonaveBl(int IdVisitaMotonave, int IdTercero, string codigoProducto)
        {
            int resultado = 0;
            try
            {
                if (IdVisitaMotonave != null && IdVisitaMotonave > 0 && IdTercero != null && IdTercero > 0 && !string.IsNullOrEmpty(codigoProducto))
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de filtro de busquedas por IdVisitaMotonave para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedas(int? idVisitaMotonave, string codigoUsuario)
        {
            int resultado = 0;
            try
            {
                if (idVisitaMotonave != null && idVisitaMotonave > 0 && !String.IsNullOrEmpty(codigoUsuario))
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de dato idVisitaMotonaveBl para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdVisitaMotonaveBl(int? idVisitaMotonaveBl)
        {
            int resultado = 0;
            try
            {
                if (idVisitaMotonaveBl != null && idVisitaMotonaveBl > 0)
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception e)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de VisitaMotonaveBl , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl_)
        {
            int resultado = 0;
            try
            {
                if (objVisitaMotonaveBl_.VmblRowid != null && objVisitaMotonaveBl_.VmblRowid > 0)
                {
                    //Validar que el codigo/Llave exista.
                    var VisitaMotonaveBlExiste = await ObjVisitaMotonaveBl.FiltrarVisitaMotonaveBlEspecifico(objVisitaMotonaveBl_.VmblRowid);
                    if (VisitaMotonaveBlExiste.Count == 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de eliminar VisitaMotonaveBl por IdVisitaMotonaveDetalle , metodo Eliminar
        public async Task<int> ValidarEliminarPorVisitaMotonaveDetalle(MdloDtos.VisitaMotonaveDetalle objVisitaMotonaveDetalle)
        {
            int resultado = 0;
            try
            {
                if (objVisitaMotonaveDetalle.VmdRowid != null && objVisitaMotonaveDetalle.VmdRowid > 0)
                {
                    //Validar que el codigo/Llave exista.
                    var VisitaMotonaveDetalleExiste = await ObjVisitaMotonaveDetalle.FiltrarVisitaMotonaveDetalleEspecifico(objVisitaMotonaveDetalle.VmdRowid);
                    if (VisitaMotonaveDetalleExiste.Count == 0)
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
                    }
                }
                else
                {
                    resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }
            }
            catch (Exception ex)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de VisitaMotonaveBl , metodo Actualizar estados
        public async Task<int> ValidarActualizacionEstado(MdloDtos.VisitaMotonaveBl objVisitaMotonaveBl_)
        {
            int resultado = 0;
            try
            {
                // Validar los campos Obligatorios.
                if (objVisitaMotonaveBl_.VmblRowid == null || objVisitaMotonaveBl_.VmblCdgoUsrioAprbdo == null || objVisitaMotonaveBl_.VmblEstdo == null)
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                if (!(objVisitaMotonaveBl_.VmblEstdo.Equals("A") || objVisitaMotonaveBl_.VmblEstdo.Equals("R")))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.NoAceptaValoresNull;
                }

                var UsuarioExiste = await ObjUsuario.FiltrarUsuarioEspecifico(objVisitaMotonaveBl_.VmblCdgoUsrioAprbdo);
                if (UsuarioExiste.Count <= 0)
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }

                var VisitaMotonaveBlExiste = await ObjVisitaMotonaveBl.FiltrarVisitaMotonaveBlEspecifico(objVisitaMotonaveBl_.VmblRowid);
                if (VisitaMotonaveBlExiste.Count <= 0)
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                }

                if (!VisitaMotonaveBlExiste[0].VmblEstdo.Equals("C"))
                {
                    return (int)MdloDtos.Utilidades.Constantes.TipoMensaje.DocumentoAprobado;
                   
                }
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionExitosa;
            }
            catch (Exception)
            {
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion
    }
}
