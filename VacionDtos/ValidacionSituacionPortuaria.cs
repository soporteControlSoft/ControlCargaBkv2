using AccsoDtos.Mappings;
using AccsoDtos.SituacionPortuaria;
using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace VldcionDtos
{
    /// <summary>
    /// Clase para Validar los encabezados de situacion portuaria.
    /// </summary>
    public class ValidacionSituacionPortuaria
    {
        private readonly IMapper _mapper;

        AccsoDtos.SituacionPortuaria.SituacionPortuaria ObjSituacionPortuaria = new AccsoDtos.SituacionPortuaria.SituacionPortuaria();
        AccsoDtos.Parametrizacion.ZonaCd ObjZonaCd;
        AccsoDtos.Parametrizacion.TerminalMaritimo ObjTerminalMaritimo = new AccsoDtos.Parametrizacion.TerminalMaritimo();

        //Objetos para hacer las validaciones de existencia
        AccsoDtos.Parametrizacion.Motonave ObjMotonave ;
        AccsoDtos.SituacionPortuaria.EstadosMotonave ObjEstadosMotonave;
        AccsoDtos.Parametrizacion.Pais ObjPais = new AccsoDtos.Parametrizacion.Pais();
        AccsoDtos.Parametrizacion.Usuario ObjUsuario = new AccsoDtos.Parametrizacion.Usuario();


        public ValidacionSituacionPortuaria()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjMotonave = new AccsoDtos.Parametrizacion.Motonave(_mapper);
            ObjZonaCd = new AccsoDtos.Parametrizacion.ZonaCd(_mapper);
            ObjEstadosMotonave = new AccsoDtos.SituacionPortuaria.EstadosMotonave(_mapper);
        }



        #region Validacion de SituacionPortuaria , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.SituacionPortuarium objSituacionPortuaria) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoMtnve)) && (!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoEstdoMtnve))
                    && (!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoPais)) && (!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoUsrioCrea)))
                {
                    //Validar la llave relacional.
                    var ListaMotonave = await ObjMotonave.FiltrarMotonaveEspecifico(objSituacionPortuaria.SpCdgoMtnve);
                    var ListaEstadosMotonave = await ObjEstadosMotonave.FiltrarEstadoMotonaveEspecifico(objSituacionPortuaria.SpCdgoEstdoMtnve);
                    var ListaPais = await ObjPais.FiltrarPaisEspecifico(objSituacionPortuaria.SpCdgoPais);
                    var ListaUsuario = await ObjUsuario.FiltrarUsuarioEspecifico(objSituacionPortuaria.SpCdgoUsrioCrea);

                    if (ListaMotonave == null || ListaMotonave.Count==0 || ListaEstadosMotonave == null || ListaEstadosMotonave.Count == 0 ||
                        ListaPais == null || ListaPais.Count == 0 || ListaUsuario == null || ListaUsuario.Count == 0)
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
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region Validacion de SituacionPortuaria , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.SituacionPortuarium objSituacionPortuaria)
        {
            int resultado = 0;
            try
            {
                if(objSituacionPortuaria.SpRowid != null && objSituacionPortuaria.SpRowid > 0)
                {
                    //Validar que el codigo/Llave  exista.
                    var SituacionPortuariumExiste = await ObjSituacionPortuaria.VerificarSituacionPortuaria(objSituacionPortuaria.SpRowid);
                    if (SituacionPortuariumExiste == false)
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

        #region Validacion de SituacionPortuaria , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.SituacionPortuarium objSituacionPortuaria)
        {
            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoMtnve)) && (!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoEstdoMtnve))
                    && (!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoPais)) && (!string.IsNullOrEmpty(objSituacionPortuaria.SpCdgoUsrioCrea)))
                {
                    //Validar la llave relacional.
                    var ListaMotonave = await ObjMotonave.FiltrarMotonaveEspecifico(objSituacionPortuaria.SpCdgoMtnve);
                    var ListaEstadosMotonave = await ObjEstadosMotonave.FiltrarEstadoMotonaveEspecifico(objSituacionPortuaria.SpCdgoEstdoMtnve);
                    var ListaPais = await ObjPais.FiltrarPaisEspecifico(objSituacionPortuaria.SpCdgoPais);
                    var ListaUsuario = await ObjUsuario.FiltrarUsuarioEspecifico(objSituacionPortuaria.SpCdgoUsrioCrea);


                    if (ListaMotonave == null || ListaMotonave.Count == 0 || ListaEstadosMotonave == null || ListaEstadosMotonave.Count == 0 ||
                        ListaPais == null || ListaPais.Count == 0 || ListaUsuario == null || ListaUsuario.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {
                        //Validar que el codigo/Llave  No exista.
                        var SituacionPortuariaExiste = await ObjSituacionPortuaria.VerificarSituacionPortuaria(objSituacionPortuaria.SpRowid);
                        if (SituacionPortuariaExiste == false)
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

        #region Validacion de SituacionPortuaria Validar Busquedas ( Filtros)
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

        #region  Validacion de dato idZona para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorZona(int? idZona)
        {
            int resultado = 0;
            try
            {
                if (idZona != null && idZona > 0)
                {
                    //Validar la llave relacional.
                    var listaZona = await ObjZonaCd.FiltrarZonaCdId(idZona);

                    if (listaZona == null || listaZona.Count == 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region  Validacion de dato CodigoTerminalMaritimo para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorCodigoTerminal(String? CodigoTerminalMaritimo)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(CodigoTerminalMaritimo)))
                {
                    //Validar la llave relacional.
                    var listaTerminalMaritimo = await ObjTerminalMaritimo.FiltrarTerminalMaritimoEspecifico(CodigoTerminalMaritimo);

                    if (listaTerminalMaritimo == null || listaTerminalMaritimo.Count == 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region  Validacion de dato CodigoMotonave para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorCodigoMotonave(String? CodigoMotonave)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(CodigoMotonave)))
                {
                    //Validar la llave relacional.
                    var listaMotonave = await ObjMotonave.FiltrarMotonaveEspecifico(CodigoMotonave);

                    if (listaMotonave == null || listaMotonave.Count == 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region  Validacion de dato CodigoEstadoMotonave para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorCodigoEstadosMotonave(String? CodigoEstadoMotonave)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(CodigoEstadoMotonave)))
                {
                    //Validar la llave relacional.
                    var listaEstadosMotonave = await ObjEstadosMotonave.FiltrarEstadoMotonaveEspecifico(CodigoEstadoMotonave);

                    if (listaEstadosMotonave == null || listaEstadosMotonave.Count == 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region  Validacion de dato CodigoPais para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorCodigoPais(String? CodigoPais)
        {
            int resultado = 0;
            try
            {
                if ((!string.IsNullOrEmpty(CodigoPais)))
                {
                    //Validar la llave relacional.
                    var listaPais = await ObjPais.FiltrarPaisEspecifico(CodigoPais);

                    if (listaPais == null || listaPais.Count == 0)
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
            catch (Exception e)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;
            }
            return resultado;
        }
        #endregion

        #region  Validacion de dato IdSituacionPortuaria para Busquedas ( Filtros)
        public async Task<int> ValidarFiltroBusquedasPorIdSituacionPortuaria(int? IdSituacionPortuaria)
        {
            int resultado = 0;
            try
            {
                if (IdSituacionPortuaria != null && IdSituacionPortuaria > 0)
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

        #region Valores Null para el left join de la situacion Portuaria
        public MdloDtos.SituacionPortuarium ValoresSituacionPortuaria(MdloDtos.SituacionPortuarium ObjSituacion)
        {
            int SpRowidZnaCd = 0;
            int SpRowidAgnteNvro = 0;
            String SpCdgoTrmnalMrtmo = "";
            int SpRowidOprdorPrtrio = 0;
            int SpTotalTmBl = 0;
            int SpCldoMtnve = 0;
            int SpEslraMtnve = 0;

            //validacion zona null.
            if (
                (ObjSituacion.SpRowidZnaCd != null || (ObjSituacion.SpRowidZnaCd.ToString().Length > 0 || (!string.IsNullOrWhiteSpace(ObjSituacion.SpRowidZnaCd.ToString()))))

               )
            {

                SpRowidZnaCd = (int)ObjSituacion.SpRowidZnaCd;
            }
            else
            {
                SpRowidZnaCd = 0;
            }

            //validacion Terminal null.
            if (
                (ObjSituacion.SpCdgoTrmnalMrtmo == null || (ObjSituacion.SpCdgoTrmnalMrtmo.Length == 0 || (string.IsNullOrWhiteSpace(ObjSituacion.SpCdgoTrmnalMrtmo))))

               )
            {
                SpCdgoTrmnalMrtmo = "";

            }
            else
            {
                SpCdgoTrmnalMrtmo = ObjSituacion.SpCdgoTrmnalMrtmo;
            }

            //validacion Agente Naviero null.
            if (
                (ObjSituacion.SpRowidAgnteNvro.ToString() != null || (ObjSituacion.SpRowidAgnteNvro.ToString().Length > 0 || (!string.IsNullOrWhiteSpace(ObjSituacion.SpRowidAgnteNvro.ToString()))))

               )
            {

                SpRowidAgnteNvro = (int)ObjSituacion.SpRowidAgnteNvro;
            }
            else
            {
                SpRowidAgnteNvro = 0;
            }
            return ObjSituacion;
        }
        #endregion
    }
}
