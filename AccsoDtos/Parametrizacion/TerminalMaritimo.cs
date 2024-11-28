using MdloDtos.Utilidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.Parametrizacion
{
    public  class TerminalMaritimo:MdloDtos.IModelos.ITerminalMaritimo
    {
        #region Ingresar datos a la entidad Tipo Maritimo
        public async Task<MdloDtos.TerminalMaritimo> IngresarTerminalMaritimo(MdloDtos.TerminalMaritimo _TerminalMaritimo)
        {
            var ObjTerminalMaritimo = new MdloDtos.TerminalMaritimo();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TerminalMaritimoExiste = await this.VerificarTerminalMaritimo(_TerminalMaritimo.TmCdgo);

                    if (TerminalMaritimoExiste == true)
                    {
                        throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                    }
                    else
                    {
                        ObjTerminalMaritimo.TmCdgo = _TerminalMaritimo.TmCdgo;
                        ObjTerminalMaritimo.TmDscrpcion = _TerminalMaritimo.TmDscrpcion;
                        ObjTerminalMaritimo.TmActvo = _TerminalMaritimo.TmActvo;
                        var res = await _dbContex.TerminalMaritimos.AddAsync(ObjTerminalMaritimo);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return ObjTerminalMaritimo;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }

        }
        #endregion

        #region valida si existe un TerminalMaritimo validando nombre pasando como parámetro Nombre
        public bool ValidacionTerminalNombreIngresar(string Nombre)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.TerminalMaritimos
                           where e.TmDscrpcion == Nombre
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

        #region valida si existe un TerminalMaritimo validando codigo, descripcion pasando como parámetro un Objeto TerminalMaritimo
        public bool ValidacionTerminalNombreActualizar(MdloDtos.TerminalMaritimo objTerminalMaritimo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                Boolean retorno = false;
                var lst = (from e in _dbContex.TerminalMaritimos
                           where    e.TmCdgo != objTerminalMaritimo.TmCdgo && 
                                    e.TmDscrpcion == objTerminalMaritimo.TmDscrpcion
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

        #region Consultar todos los datos de Terminal Maritimo mediante un parametro Codigo General
        public async Task<List<MdloDtos.TerminalMaritimo>> FiltrarTerminalMaritimoEspecifico(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.TerminalMaritimos
                                 where p.TmCdgo.Contains(Codigo) || p.TmDscrpcion.Contains(Codigo)
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Consultar todos los datos de Terminal Maritimo mediante un parametro Codigo Terminal 
        public async Task<List<MdloDtos.TerminalMaritimo>> FiltrarTerminalMaritimoGeneral(String Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await (from p in _dbContex.TerminalMaritimos
                                 where p.TmCdgo == Codigo
                                 select p).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }
        #endregion

        #region Actualizar Terminal Maritimo pasando el objeto _TerminalMaritimo
        public async Task<MdloDtos.TerminalMaritimo> EditarTerminalMaritimo(MdloDtos.TerminalMaritimo _TerminalMaritimo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    MdloDtos.TerminalMaritimo TerminalMaritimoExiste = await _dbContex.TerminalMaritimos.FindAsync(_TerminalMaritimo.TmCdgo);
                    if (TerminalMaritimoExiste != null)
                    {

                        TerminalMaritimoExiste.TmCdgo = _TerminalMaritimo.TmCdgo;
                        TerminalMaritimoExiste.TmDscrpcion = _TerminalMaritimo.TmDscrpcion;
                        TerminalMaritimoExiste.TmActvo = _TerminalMaritimo.TmActvo;
                        _dbContex.Entry(TerminalMaritimoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        await _dbContex.SaveChangesAsync();

                    }
                    _dbContex.Dispose();
                    return TerminalMaritimoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }

        #endregion

        #region Consultar todos los datos de Terminal Maritimo
        public async Task<List<MdloDtos.TerminalMaritimo>> ListarTerminalMaritimo()
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                var lst = await _dbContex.TerminalMaritimos.ToListAsync();
                _dbContex.Dispose();
                return lst;
            }

        }

        #endregion

        #region Eliminar Terminal Maritimo
        public async Task<MdloDtos.TerminalMaritimo> EliminarTerminalMaritimo(string Codigo)
        {
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var TerminalMaritimoExiste = await _dbContex.TerminalMaritimos.FindAsync(Codigo);
                    if (TerminalMaritimoExiste == null)
                    {
                        throw new DllNotFoundException();
                    }
                    else
                    {
                        _dbContex.Remove(TerminalMaritimoExiste);
                        await _dbContex.SaveChangesAsync();
                    }
                    _dbContex.Dispose();
                    return TerminalMaritimoExiste;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);

                }
            }


        }

        #endregion

        #region verificar Terminal maritimo
        public async Task<bool> VerificarTerminalMaritimo(string Codigo)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjTerminalMaritimo = await _dbContex.TerminalMaritimos.FindAsync(Codigo);
                    if (ObjTerminalMaritimo == null)
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
