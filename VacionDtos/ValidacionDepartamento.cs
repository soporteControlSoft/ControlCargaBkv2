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
    /// Clase para Validar los departamentos.
    /// Fecha: 27/02/2024
    /// Daniel Alejandro Lopez
    /// </summary>
    public class ValidacionDepartamento
    {

        private readonly IMapper _mapper;
        AccsoDtos.Parametrizacion.Pais ObjPais;
        AccsoDtos.Parametrizacion.Departamento ObjDepartamento ;

        public ValidacionDepartamento()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configuration.CreateMapper();
            ObjPais = new AccsoDtos.Parametrizacion.Pais(_mapper);
            ObjDepartamento = new AccsoDtos.Parametrizacion.Departamento(_mapper);
        }

        #region Validacion de departamentos , metodo Ingreso
        public async Task<int> ValidarIngreso(MdloDtos.DTO.DepartamentoDTO objDepartamento) {

            int resultado = 0;
            try {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objDepartamento.DeCdgo)) && (!string.IsNullOrEmpty(objDepartamento.DeCdgoPais)) 
                    && (objDepartamento.DeCdgo.Length>0) && (objDepartamento.DeCdgoPais.Length > 0) 
                    && (objDepartamento.DeCdgo!="") && (objDepartamento.DeCdgoPais != "")
                    )
                {
                    //Validar la llave relacional.
                    var ListaPais = await ObjPais.FiltrarPaisEspecifico(objDepartamento.DeCdgoPais);

                    if (ListaPais == null || ListaPais.Count==0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {

                        //Validar que el codigo/Llave  No exista.
                        var DepartamentoExiste = await ObjDepartamento.VerificarDepartamento(objDepartamento.DeCdgo);
                        if (DepartamentoExiste == true)
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
            catch(Exception ex)
            {
                //Retorna valor del TipoMensaje: TransaccionIncorrecta
                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.TransaccionIncorrecta;

            }

            return resultado;
        }
        #endregion

        #region Validacion de departamentos , metodo Eliminar
        public async Task<int> ValidarEliminar(MdloDtos.DTO.DepartamentoDTO objDepartamento_)
        {

            int resultado = 0;
            try
            {
                int? Id = objDepartamento_.DeRowid;
                if (Id > 0)
                {
                    //Validar que el codigo/Llave  exista.
                    var DepartamentoExiste = await ObjDepartamento.VerificarDepartamentoId(Id);
                    if (DepartamentoExiste == false)
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

        #region Validacion de departamentos , metodo Actualizar
        public async Task<int> ValidarActualizacion(MdloDtos.DTO.DepartamentoDTO objDepartamento)
        {

            int resultado = 0;
            try
            {
                //Validar los campos Obligatorios.
                if ((!string.IsNullOrEmpty(objDepartamento.DeCdgo)) && (!string.IsNullOrEmpty(objDepartamento.DeCdgoPais))
                   && (objDepartamento.DeCdgo.Length > 0) && (objDepartamento.DeCdgoPais.Length > 0)
                   && (objDepartamento.DeCdgo != "") && (objDepartamento.DeCdgoPais != "")
                   )
                {
                    //Validar la llave relacional.
                    var ListaPais = await ObjPais.FiltrarPaisEspecifico(objDepartamento.DeCdgoPais);

                    if (ListaPais == null || ListaPais.Count == 0)
                    {
                        //Retorna valor del TipoMensaje: RelacionNoExiste
                        resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                    }
                    else
                    {

                        //Validar que el codigo/Llave exista.
                        var DepartamentoExiste = await ObjDepartamento.VerificarDepartamentoId(objDepartamento.DeRowid);
                        if (DepartamentoExiste == false)
                        {
                            //Retorna valor del TipoMensaje: RelacionNoExiste
                            resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.RelacionNoExiste;
                        }
                        else
                        {
                            //validar que el codigo no exista
                            var DepartamentoIdExiste = await ObjDepartamento.FiltrarDepartamentoIdCodigo(objDepartamento.DeCdgo, objDepartamento.DeRowid);
                            if (DepartamentoIdExiste == null || DepartamentoIdExiste.Count>0)
                            {
                                //Retorna valor del TipoMensaje: CodigoExiste
                                resultado = (int)MdloDtos.Utilidades.Constantes.TipoMensaje.CodigoExiste;
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

        #region Validacion de Departamento Validar Busquedas ( Filtros)
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
