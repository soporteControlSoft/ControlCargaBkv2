using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    public class PuertoOrigen : MdloDtos.IModelos.IPuertoOrigen
    {
        #region Ingresar datos a la entidad Puerto Origen
        public async Task<MdloDtos.PuertoOrigen> IngresarPuertoOrigen(MdloDtos.PuertoOrigen _PuertoOrigen)
        {
            var ObjPuertoOrigen = new MdloDtos.PuertoOrigen();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PuertoOrigenExiste = await this.VerificarPuertoOrigen(_PuertoOrigen.PoCdgo);

                    if (PuertoOrigenExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjPuertoOrigen.PoCdgo = _PuertoOrigen.PoCdgo;
                        ObjPuertoOrigen.PoDscrpcion = _PuertoOrigen.PoDscrpcion;
                        ObjPuertoOrigen.PoActvo = _PuertoOrigen.PoActvo;
                        var res = await _dbContex.PuertoOrigens.AddAsync(ObjPuertoOrigen);
                        await _dbContex.SaveChangesAsync();
                    }
                   
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
                _dbContex.Dispose();
                return ObjPuertoOrigen;
            }

        }
        #endregion

        #region Consultar todos los datos de Puerto Origen mediante un parametro Codigo
        public async Task<List<MdloDtos.PuertoOrigen>> FiltrarPuertoOrigenGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.PuertoOrigens
                                 where p.PoCdgo.Contains(Codigo) || p.PoDscrpcion.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Puerto Origen mediante un parametro Codigo especifico
        public async Task<List<MdloDtos.PuertoOrigen>> FiltrarPuertoOrigenEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.PuertoOrigens
                                 where p.PoCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Actualizar Puerto Origen pasando el objeto _PuertoOrigen
        public async Task<MdloDtos.PuertoOrigen> EditarPuertoOrigen(MdloDtos.PuertoOrigen _PuertoOrigen)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.PuertoOrigen PuertoOrigenExiste = await _dbContex.PuertoOrigens.FindAsync(_PuertoOrigen.PoCdgo);
                    if (PuertoOrigenExiste != null)
                    {

                        PuertoOrigenExiste.PoCdgo = _PuertoOrigen.PoCdgo;
                        PuertoOrigenExiste.PoDscrpcion = _PuertoOrigen.PoDscrpcion;
                        PuertoOrigenExiste.PoActvo = _PuertoOrigen.PoActvo;
                        _dbContex.Entry(PuertoOrigenExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return PuertoOrigenExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region Consultar todos los datos de Puerto Origen
        public async Task<List<MdloDtos.PuertoOrigen>> ListarPuertoOrigen()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.PuertoOrigens.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }

        #endregion

        #region Eliminar Puerto Origen
        public async Task<MdloDtos.PuertoOrigen> EliminarPuertoOrigen(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var PuertoOrigenExiste = await _dbContex.PuertoOrigens.FindAsync(Codigo);
                    if (PuertoOrigenExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(PuertoOrigenExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return PuertoOrigenExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


        }

        #endregion

        #region verificar Puerto Origen
        public async Task<bool> VerificarPuertoOrigen(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjPuertoOrigenExiste = await _dbContex.PuertoOrigens.FindAsync(Codigo);
                    if (ObjPuertoOrigenExiste == null)
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
                return respuesta;
            }

        }
        #endregion
    }
}
