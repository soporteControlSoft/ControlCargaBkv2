using AutoMapper;
using MdloDtos;
using MdloDtos.IModelos;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    public class Departamento : MdloDtos.IModelos.IDepartamento
    {
        /// <summary>
        /// CRUD para el manejo del Departamento
        /// Daniel Alejandro Lopez
        /// </summary>
        /// 

        private readonly IMapper _mapper;

        public Departamento(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Ingresar datos a la entidad Departamento
        public async Task<dynamic> IngresarDepartamento(MdloDtos.DTO.DepartamentoDTO _Departamento)
        {

            var ObjDepartamento = new MdloDtos.Departamento();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var DepartamentoExiste = await this.VerificarDepartamento(_Departamento.DeCdgo);

                    if (DepartamentoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjDepartamento.DeCdgo = _Departamento.DeCdgo;
                        ObjDepartamento.DeNmbre = _Departamento.DeNmbre;
                        ObjDepartamento.DeCdgoPais = _Departamento.DeCdgoPais;
                        var res = await _dbContex.Departamentos.AddAsync(ObjDepartamento);
                        await _dbContex.SaveChangesAsync();
                    }

                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjDepartamento;
            }

        }
        #endregion

        #region Consultar todos los datos de Departamento mediante un parametro Codigo de Pais
        public async Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoPorPais(String CodigoPais)
        {
            List<MdloDtos.DTO.DepartamentoDTO> listadoDepartamento = new List<MdloDtos.DTO.DepartamentoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                MdloDtos.Pai PäisExiste = await _dbContex.Pais.FindAsync(CodigoPais);
                if (PäisExiste != null)
                {
                    string busqueda = Convert.ToString(CodigoPais);
                    var lst = await (from departamento in _dbContex.Departamentos
                                     join pais in _dbContex.Pais on departamento.DeCdgoPais equals pais.PaCdgo into paisJoin
                                     from pais in paisJoin.DefaultIfEmpty()

                                     where departamento.DeCdgoPais == busqueda

                                     select new
                                     {
                                         //Atributos Departamento
                                         departamento.DeRowid,
                                         departamento.DeCdgo,
                                         departamento.DeNmbre,
                                         departamento.DeCdgoPais,

                                         //Atributos del país
                                         pais.PaCdgo,
                                         pais.PaNmbre

                                     }
                               ).ToListAsync();
                    _dbContex.Dispose();
                    foreach (var item in lst)
                    {
                        //Creamos una entidad Sede para agregar a la lista
                        MdloDtos.DTO.DepartamentoDTO objDepartamento = new MdloDtos.DTO.DepartamentoDTO(
                                                                    //Atributos Departamento
                                                                    item.DeRowid != null ? item.DeRowid : 0,
                                                                    item.DeCdgo != null ? item.DeCdgo : String.Empty,
                                                                    item.DeNmbre != null ? item.DeNmbre : String.Empty,
                                                                    item.DeCdgoPais != null ? item.DeCdgoPais : String.Empty,


                                                                    //Atributos país
                                                                    item.PaCdgo != null ? item.PaCdgo.ToString() : String.Empty,
                                                                    item.PaNmbre != null ? item.PaNmbre : String.Empty
                                                                   );
                        //Agregamnos a la lista
                        listadoDepartamento.Add(objDepartamento);
                    }
                }
                _dbContex.Dispose();
                return listadoDepartamento;
            }
        }
        #endregion

        #region Listar todos los departamentos
        public async Task<List<MdloDtos.DTO.DepartamentoDTO>> ListarDepartamento()
        {
            List<MdloDtos.DTO.DepartamentoDTO> listadoDepartamento = new List<MdloDtos.DTO.DepartamentoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from departamento in _dbContex.Departamentos
                                 join pais in _dbContex.Pais on departamento.DeCdgoPais equals pais.PaCdgo into paisJoin
                                 from pais in paisJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Departamento
                                     departamento.DeRowid,
                                     departamento.DeCdgo,
                                     departamento.DeNmbre,
                                     departamento.DeCdgoPais,

                                     //Atributos del país
                                     pais.PaCdgo,
                                     pais.PaNmbre
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.DepartamentoDTO objDepartamento = new MdloDtos.DTO.DepartamentoDTO(
                                                                //Atributos Departamento
                                                                item.DeRowid != null ? item.DeRowid : 0,
                                                                item.DeCdgo != null ? item.DeCdgo : String.Empty,
                                                                item.DeNmbre != null ? item.DeNmbre : String.Empty,
                                                                item.DeCdgoPais != null ? item.DeCdgoPais : String.Empty,


                                                                //Atributos país
                                                                item.PaCdgo != null ? item.PaCdgo.ToString() : String.Empty,
                                                                item.PaNmbre != null ? item.PaNmbre : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoDepartamento.Add(objDepartamento);
                }
                _dbContex.Dispose();
                return listadoDepartamento;
            }
        }
        #endregion

        #region Actualizar departamentos por el objeto _Departamento
        public async Task<MdloDtos.DTO.DepartamentoDTO> EditarDepartamento(MdloDtos.DTO.DepartamentoDTO _Departamento)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.Departamento DepartamentoExiste = await _dbContex.Departamentos.FindAsync(_Departamento.DeRowid);

                    if (DepartamentoExiste != null)
                    {

                        DepartamentoExiste.DeCdgo = _Departamento.DeCdgo;
                        DepartamentoExiste.DeNmbre = _Departamento.DeNmbre;
                        DepartamentoExiste.DeCdgoPais = _Departamento.DeCdgoPais;
                        _dbContex.Entry(DepartamentoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return _Departamento;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Filtrar departamento por codigo General
        public async Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoGeneral(string Codigo)
        {
            List<MdloDtos.DTO.DepartamentoDTO> listadoDepartamento = new List<MdloDtos.DTO.DepartamentoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from departamento in _dbContex.Departamentos
                                 join pais in _dbContex.Pais on departamento.DeCdgoPais equals pais.PaCdgo into paisJoin
                                 from pais in paisJoin.DefaultIfEmpty()

                                 where departamento.DeCdgo.Contains(Codigo) || departamento.DeNmbre.Contains(Codigo)


                                 select new
                                 {
                                     //Atributos Departamento
                                     departamento.DeRowid,
                                     departamento.DeCdgo,
                                     departamento.DeNmbre,
                                     departamento.DeCdgoPais,

                                     //Atributos del país
                                     pais.PaCdgo,
                                     pais.PaNmbre
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.DepartamentoDTO objDepartamento = new MdloDtos.DTO.DepartamentoDTO(
                                                                //Atributos Departamento
                                                                item.DeRowid != null ? item.DeRowid : 0,
                                                                item.DeCdgo != null ? item.DeCdgo : String.Empty,
                                                                item.DeNmbre != null ? item.DeNmbre : String.Empty,
                                                                item.DeCdgoPais != null ? item.DeCdgoPais : String.Empty,


                                                                //Atributos país
                                                                item.PaCdgo != null ? item.PaCdgo.ToString() : String.Empty,
                                                                item.PaNmbre != null ? item.PaNmbre : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoDepartamento.Add(objDepartamento);
                }
                _dbContex.Dispose();
                return listadoDepartamento;
            }
        }
        #endregion

        #region Filtrar departamento por codigo y por Id
        public async Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoIdCodigo(string Codigo,int? IdDepartamento)
        {
            List<MdloDtos.DTO.DepartamentoDTO> listadoDepartamento = new List<MdloDtos.DTO.DepartamentoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from departamento in _dbContex.Departamentos
                                 join pais in _dbContex.Pais on departamento.DeCdgoPais equals pais.PaCdgo into paisJoin
                                 from pais in paisJoin.DefaultIfEmpty()

                                 where departamento.DeCdgo == Codigo && (departamento.DeRowid != IdDepartamento)

                                 select new
                                 {
                                     //Atributos Departamento
                                     departamento.DeRowid,
                                     departamento.DeCdgo,
                                     departamento.DeNmbre,
                                     departamento.DeCdgoPais,

                                     //Atributos del país
                                     pais.PaCdgo,
                                     pais.PaNmbre
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.DepartamentoDTO objDepartamento = new MdloDtos.DTO.DepartamentoDTO(
                                                                //Atributos Departamento
                                                                item.DeRowid != null ? item.DeRowid : 0,
                                                                item.DeCdgo != null ? item.DeCdgo : String.Empty,
                                                                item.DeNmbre != null ? item.DeNmbre : String.Empty,
                                                                item.DeCdgoPais != null ? item.DeCdgoPais : String.Empty,


                                                                //Atributos país
                                                                item.PaCdgo != null ? item.PaCdgo.ToString() : String.Empty,
                                                                item.PaNmbre != null ? item.PaNmbre : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoDepartamento.Add(objDepartamento);
                }
                _dbContex.Dispose();
                return listadoDepartamento;
            }
        }
        #endregion

        #region Filtrar departamento por codigo Especifico
        public async Task<List<MdloDtos.DTO.DepartamentoDTO>> FiltrarDepartamentoEspecifico(string Codigo)
        {
            List<MdloDtos.DTO.DepartamentoDTO> listadoDepartamento = new List<MdloDtos.DTO.DepartamentoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from departamento in _dbContex.Departamentos
                                 join pais in _dbContex.Pais on departamento.DeCdgoPais equals pais.PaCdgo into paisJoin
                                 from pais in paisJoin.DefaultIfEmpty()

                                 where departamento.DeCdgo == Codigo

                                 select new
                                 {
                                     //Atributos Departamento
                                     departamento.DeRowid,
                                     departamento.DeCdgo,
                                     departamento.DeNmbre,
                                     departamento.DeCdgoPais,

                                     //Atributos del país
                                     pais.PaCdgo,
                                     pais.PaNmbre
                                 }
                           ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Sede para agregar a la lista
                    MdloDtos.DTO.DepartamentoDTO objDepartamento = new MdloDtos.DTO.DepartamentoDTO(
                                                                //Atributos Departamento
                                                                item.DeRowid != null ? item.DeRowid : 0,
                                                                item.DeCdgo != null ? item.DeCdgo : String.Empty,
                                                                item.DeNmbre != null ? item.DeNmbre : String.Empty,
                                                                item.DeCdgoPais != null ? item.DeCdgoPais : String.Empty,


                                                                //Atributos país
                                                                item.PaCdgo != null ? item.PaCdgo.ToString() : String.Empty,
                                                                item.PaNmbre != null ? item.PaNmbre : String.Empty
                                                               );
                    //Agregamnos a la lista
                    listadoDepartamento.Add(objDepartamento);
                }
                _dbContex.Dispose();
                return listadoDepartamento;
            }
        }
        #endregion

        #region Eliminar Departamento Por codigo.
        public async Task<dynamic> EliminarDepartamento(int Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var DepartamentoExiste = await _dbContex.Departamentos.FindAsync(Codigo);
                    if (DepartamentoExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(DepartamentoExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return DepartamentoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }

        }
        #endregion

        #region verificar Departamento por codigo.
        public async Task<bool> VerificarDepartamento(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Departamentos
                               where p.DeCdgo == Codigo
                               select p).Count();

                    var ObjDepartamentos = lst;
                    if (ObjDepartamentos == null || ObjDepartamentos == 0)
                    {

                        respuesta = false;
                    }
                    else
                    {

                        respuesta = true;
                    }

                    _dbContex.Dispose();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
        #endregion

        #region verificar Departamento por Id.
        public async Task<bool> VerificarDepartamentoId(int? Id)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var lst = (from p in _dbContex.Departamentos
                               where p.DeRowid == Id
                               select p).Count();

                    var ObjDepartamentos = lst;
                    if (ObjDepartamentos == null || ObjDepartamentos == 0)
                    {

                        respuesta = false;
                    }
                    else
                    {

                        respuesta = true;
                    }

                    _dbContex.Dispose();
                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

        }
        #endregion

    }

}
