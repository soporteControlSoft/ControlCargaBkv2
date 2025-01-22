using AutoMapper;
using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    /// <summary>
    /// CRUD para el manejo de vehiculos
    /// Wilbert Rivas Granados
    /// </summary>
    /// 
    public class Vehiculo :MdloDtos.IModelos.IVehiculo
    {
        private readonly IMapper _mapper;

        public Vehiculo(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region ingreso de datos a la entidad Vehiculo
        public async Task<dynamic> IngresarVehiculo(MdloDtos.DTO.VehiculoDTO _Vehiculo)
        {
            var ObjVehiculo = new MdloDtos.Vehiculo();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VehiculoExiste = await this.VerificarVehiculo(_Vehiculo.VeMtrcla);
                    if (VehiculoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjVehiculo.VeMtrcla = _Vehiculo.VeMtrcla;
                        ObjVehiculo.VeFchaSgro = _Vehiculo.VeFchaSgro;
                        ObjVehiculo.VeFchaRvsion = _Vehiculo.VeFchaRvsion;
                        ObjVehiculo.VeFchaRgstro = _Vehiculo.VeFchaRgstro;
                        ObjVehiculo.VeCdgoUsrioCrea = _Vehiculo.VeCdgoUsrioCrea;
                        ObjVehiculo.VeRowidCnfgrcionVhclar = _Vehiculo.VeRowidCnfgrcionVhclar;
                        ObjVehiculo.VeMdlo = _Vehiculo.VeMdlo;
                        var res = await _dbContex.Vehiculos.AddAsync(ObjVehiculo);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjVehiculo;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de Vehiculo.
        public async Task<List<MdloDtos.DTO.VehiculoDTO>> ListarVehiculo()
        {
            List<MdloDtos.DTO.VehiculoDTO> listadoVehiculo = new List<MdloDtos.DTO.VehiculoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from vehiculo in _dbContex.Vehiculos
                                 join configuracionVehicular in _dbContex.ConfiguracionVehiculars on vehiculo.VeRowidCnfgrcionVhclar equals configuracionVehicular.CvRowid into configuracionVehicularJoin
                                 from configuracionVehicular in configuracionVehicularJoin.DefaultIfEmpty()

                                 select new
                                 {
                                     //Atributos Vehículo
                                     vehiculo.VeMtrcla,
                                     vehiculo.VeFchaSgro,
                                     vehiculo.VeFchaRvsion,
                                     vehiculo.VeFchaRgstro,
                                     vehiculo.VeCdgoUsrioCrea,
                                     vehiculo.VeRowidCnfgrcionVhclar,
                                     vehiculo.VeMdlo,

                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.DTO.VehiculoDTO objVehiculo = new MdloDtos.DTO.VehiculoDTO(
                                                                //Atributos Vehículo
                                                                item.VeMtrcla != null ? item.VeMtrcla : String.Empty,
                                                                item.VeFchaSgro != null ? Convert.ToDateTime(item.VeFchaSgro) : null,
                                                                item.VeFchaRvsion != null ? Convert.ToDateTime(item.VeFchaRvsion) : null,
                                                                item.VeFchaRgstro != null ? Convert.ToDateTime(item.VeFchaRgstro) : null,
                                                                item.VeCdgoUsrioCrea != null ? item.VeCdgoUsrioCrea : null,
                                                                item.VeRowidCnfgrcionVhclar != null ? item.VeRowidCnfgrcionVhclar : null,
                                                                item.VeMdlo != null ? (int)item.VeMdlo : 0,

                                                                //Atributos Configuración Vehícular
                                                                item.CvRowid != null ? item.CvRowid.ToString() : String.Empty,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoVehiculo.Add(objVehiculo);
                }
                _dbContex.Dispose();
                return listadoVehiculo;
            }
        }
        #endregion

        #region Consulta los datos de vehiculos mediante un parámetro Codigo general
        public async Task<List<MdloDtos.DTO.VehiculoDTO>> FiltrarVehiculoGeneral(string Codigo)
        {
            List<MdloDtos.DTO.VehiculoDTO> listadoVehiculo = new List<MdloDtos.DTO.VehiculoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from vehiculo in _dbContex.Vehiculos
                                 join configuracionVehicular in _dbContex.ConfiguracionVehiculars on vehiculo.VeRowidCnfgrcionVhclar equals configuracionVehicular.CvRowid into configuracionVehicularJoin
                                 from configuracionVehicular in configuracionVehicularJoin.DefaultIfEmpty()
                                 where vehiculo.VeMtrcla.Contains(Codigo)
                                 select new
                                 {
                                     //Atributos Vehículo
                                     vehiculo.VeMtrcla,
                                     vehiculo.VeFchaSgro,
                                     vehiculo.VeFchaRvsion,
                                     vehiculo.VeFchaRgstro,
                                     vehiculo.VeCdgoUsrioCrea,
                                     vehiculo.VeRowidCnfgrcionVhclar,
                                     vehiculo.VeMdlo,

                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.DTO.VehiculoDTO objVehiculo = new MdloDtos.DTO.VehiculoDTO(
                                                                //Atributos Vehículo
                                                                item.VeMtrcla != null ? item.VeMtrcla : String.Empty,
                                                                item.VeFchaSgro != null ? Convert.ToDateTime(item.VeFchaSgro) : null,
                                                                item.VeFchaRvsion != null ? Convert.ToDateTime(item.VeFchaRvsion) : null,
                                                                item.VeFchaRgstro != null ? Convert.ToDateTime(item.VeFchaRgstro) : null,
                                                                item.VeCdgoUsrioCrea != null ? item.VeCdgoUsrioCrea : null,
                                                                item.VeRowidCnfgrcionVhclar != null ? item.VeRowidCnfgrcionVhclar : null,
                                                                item.VeMdlo != null ? (int)item.VeMdlo : 0,

                                                                //Atributos Configuración Vehícular
                                                                item.CvRowid != null ? item.CvRowid.ToString() : String.Empty,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoVehiculo.Add(objVehiculo);
                }
                _dbContex.Dispose();
                return listadoVehiculo;
            }
        }
        #endregion

        #region Consulta los datos de vehiculos mediante un parámetro Codigo Especifico
        public async Task<List<MdloDtos.DTO.VehiculoDTO>> FiltrarVehiculoEspecifico(string Codigo)
        {
            List<MdloDtos.DTO.VehiculoDTO> listadoVehiculo = new List<MdloDtos.DTO.VehiculoDTO>();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from vehiculo in _dbContex.Vehiculos
                                 join configuracionVehicular in _dbContex.ConfiguracionVehiculars on vehiculo.VeRowidCnfgrcionVhclar equals configuracionVehicular.CvRowid into configuracionVehicularJoin
                                 from configuracionVehicular in configuracionVehicularJoin.DefaultIfEmpty()
                                 where vehiculo.VeMtrcla == Codigo
                                 select new
                                 {
                                     //Atributos Vehículo
                                     vehiculo.VeMtrcla,
                                     vehiculo.VeFchaSgro,
                                     vehiculo.VeFchaRvsion,
                                     vehiculo.VeFchaRgstro,
                                     vehiculo.VeCdgoUsrioCrea,
                                     vehiculo.VeRowidCnfgrcionVhclar,
                                     vehiculo.VeMdlo,

                                     //Atributos Configuracion Vehícular
                                     configuracionVehicular.CvRowid,
                                     configuracionVehicular.CvCdgo,
                                     configuracionVehicular.CvNmbre
                                 }
                               ).ToListAsync();
                _dbContex.Dispose();
                foreach (var item in lst)
                {
                    //Creamos una entidad Vehículos para agregar a la lista
                    MdloDtos.DTO.VehiculoDTO objVehiculo = new MdloDtos.DTO.VehiculoDTO(
                                                                //Atributos Vehículo
                                                                item.VeMtrcla != null ? item.VeMtrcla : String.Empty,
                                                                item.VeFchaSgro != null ? Convert.ToDateTime(item.VeFchaSgro) : null,
                                                                item.VeFchaRvsion != null ? Convert.ToDateTime(item.VeFchaRvsion) : null,
                                                                item.VeFchaRgstro != null ? Convert.ToDateTime(item.VeFchaRgstro) : null,
                                                                item.VeCdgoUsrioCrea != null ? item.VeCdgoUsrioCrea : null,
                                                                item.VeRowidCnfgrcionVhclar != null ? item.VeRowidCnfgrcionVhclar : null,
                                                                item.VeMdlo != null ? (int)item.VeMdlo : 0,

                                                                //Atributos Configuración Vehícular
                                                                item.CvRowid != null ? item.CvRowid.ToString() : String.Empty,
                                                                item.CvCdgo != null ? item.CvCdgo : String.Empty,
                                                                item.CvNmbre != null ? item.CvNmbre : String.Empty
                                                               );
                    //Agregamnos la Configuración Vehicular a la lista
                    listadoVehiculo.Add(objVehiculo);
                }
                _dbContex.Dispose();
                return listadoVehiculo;
            }
        }
        #endregion


        #region Actualiza Vehiculo pasando un objeto _Vehiculo
        public async Task<MdloDtos.DTO.VehiculoDTO> EditarVehiculo(MdloDtos.DTO.VehiculoDTO _Vehiculo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try {
                    MdloDtos.Vehiculo VehiculoExiste = await _dbContex.Vehiculos.FindAsync(_Vehiculo.VeMtrcla);
                    if (VehiculoExiste != null)
                    {
                        VehiculoExiste.VeMtrcla = _Vehiculo.VeMtrcla;
                        VehiculoExiste.VeFchaSgro = _Vehiculo.VeFchaSgro;
                        VehiculoExiste.VeFchaRvsion = _Vehiculo.VeFchaRvsion;
                        VehiculoExiste.VeFchaRgstro = _Vehiculo.VeFchaRgstro;
                        VehiculoExiste.VeCdgoUsrioCrea = _Vehiculo.VeCdgoUsrioCrea;
                        VehiculoExiste.VeRowidCnfgrcionVhclar = _Vehiculo.VeRowidCnfgrcionVhclar;
                        VehiculoExiste.VeMdlo = _Vehiculo.VeMdlo;

                        _dbContex.Vehiculos.Entry(VehiculoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return _Vehiculo;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        

        #region Elimina un Vehiculo pasando como parámetro Codigo
        public async Task<dynamic> EliminarVehiculo(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var VehiculoExiste = await _dbContex.Vehiculos.FindAsync(Codigo);
                    if (VehiculoExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Vehiculos.Remove(VehiculoExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return VehiculoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        #endregion

        #region verificar un Vehiculo
        public async Task<bool> VerificarVehiculo(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjVehiculo = await _dbContex.Vehiculos.FindAsync(Codigo);
                    if (ObjVehiculo == null)
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
