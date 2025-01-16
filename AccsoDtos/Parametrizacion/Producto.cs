using AutoMapper;
using MdloDtos.DTO;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// CRUD para el manejo de productos
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Producto : MdloDtos.IModelos.IProducto
    {
        private readonly IMapper _mapper;

        public Producto(IMapper mapper)
        {
            _mapper = mapper;
        }
        #region ingreso de datos a la entidad Producto
        public async Task<MdloDtos.DTO.ProductoDTO> IngresarProducto(MdloDtos.DTO.ProductoDTO _ProductoDTO)
        {
            var ObjProducto = new MdloDtos.Producto();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ProductoExiste = await this.VerificarProducto(_ProductoDTO.PrCdgo);

                    if (ProductoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjProducto.PrCdgo = _ProductoDTO.PrCdgo;
                        ObjProducto.PrNmbre = _ProductoDTO.PrNmbre;
                        ObjProducto.PrActvo = _ProductoDTO.PrActvo;
                        ObjProducto.PrSlctarEmpque = _ProductoDTO.PrSlctarEmpque;
                        ObjProducto.PrCdgoErp = _ProductoDTO.PrCdgoErp;
                        ObjProducto.PrSstnciaCntrlda = _ProductoDTO.PrSstnciaCntrlda;

                        var res = await _dbContex.Productos.AddAsync(ObjProducto);
                        await _dbContex.SaveChangesAsync();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return _ProductoDTO;
            }
        }
        #endregion


        #region valida si existe un Producto validando nombre pasando como parámetro Nombre
        public bool ValidacionProductoNombreIngresar(string Nombre)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Productos
                           where e.PrNmbre == Nombre
                           select e).Count();

                if (lst > 0)
                {
                    retorno = true;
                }

                _dbContex.Dispose();
                return retorno;
            }
        }
        #endregion

        #region valida si existe un Producto validando codigo, nombre pasando como parámetro un Objeto Producto
        public bool ValidacionProductoNombreActualizar(MdloDtos.DTO.ProductoDTO objProducto)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.Productos
                           where e.PrCdgo != objProducto.PrCdgo &&
                                 e.PrNmbre == objProducto.PrNmbre
                           select e).Count();

                if (lst > 0)
                {
                    retorno = true;

                }

                _dbContex.Dispose();
                return retorno;

            }
        }
        #endregion


        #region consultar los datos de Producto mediante un parámetro Codigo General
        public async Task<List<MdloDtos.DTO.ProductoDTO>> FiltrarProductoGeneral(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.Productos
                                 where p.PrCdgo.Contains(Codigo) || p.PrNmbre.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                var lst = (query.Count > 0) ? _mapper.Map<List<ProductoDTO>>(query) : new List<ProductoDTO>();
                return lst;
            }
        }
        #endregion

        #region consultar los datos de Producto mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.DTO.ProductoDTO>> FiltrarProductoEspecifico(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await (from p in _dbContex.Productos
                                 where p.PrCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                var lst = (query.Count > 0) ? _mapper.Map<List<ProductoDTO>>(query) : new List<ProductoDTO>();
                return lst;
            }
        }
        #endregion

        #region Actualiza un Producto pasando un parámetro _Producto
        public async Task<MdloDtos.DTO.ProductoDTO> EditarProducto(MdloDtos.DTO.ProductoDTO _Producto)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ProductoExiste = await _dbContex.Productos.FindAsync(_Producto.PrCdgo);
                    if (ProductoExiste != null)
                    {
                        ProductoExiste.PrCdgo = _Producto.PrCdgo;
                        ProductoExiste.PrNmbre = _Producto.PrNmbre;
                        ProductoExiste.PrActvo = _Producto.PrActvo;
                        ProductoExiste.PrSlctarEmpque = _Producto.PrSlctarEmpque;
                        ProductoExiste.PrCdgoErp = _Producto.PrCdgoErp;

                        _dbContex.Productos.Update(ProductoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _Producto;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }
        #endregion

        #region consultar todos los datos de Productos
        public async Task<List<MdloDtos.DTO.ProductoDTO>> ListarProducto()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var query = await _dbContex.Productos.ToListAsync();
                _dbContex.Dispose();

                var lst = (query.Count > 0) ? _mapper.Map<List<ProductoDTO>>(query) : new List<ProductoDTO>();
                return lst;
            }
        }
        #endregion

        #region Elimina un Producto mediante parámetro Codigo
        public async Task<dynamic> EliminarProducto(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ProductoExiste = await _dbContex.Productos.FindAsync(Codigo);
                    if (ProductoExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(ProductoExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ProductoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verifica la existencia de un producto pasando como parámetro Codigo
        public async Task<bool> VerificarProducto(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjProducto = await _dbContex.Productos.FindAsync(Codigo);
                    if (ObjProducto == null)
                    {
                        respuesta = false;
                    }
                    else
                    {
                        respuesta = true;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
                _dbContex.Dispose();
                return respuesta;
                
            }
        }
        #endregion
    }
}
