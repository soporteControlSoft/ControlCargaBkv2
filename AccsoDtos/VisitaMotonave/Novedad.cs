using MdloDtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccsoDtos.VisitaMotonave
{
    /// <summary>
    /// Daniel Alejandro Lopez
    /// Fecha: 30/04/2024
    /// Crud tipo de Novedad 
    /// </summary>
    public class Novedad:MdloDtos.IModelos.INovedad
    {
        /*#region ingreso de datos a la entidad Novedad
        public async Task<MdloDtos.VisitaMotonaveNovedad> IngresarNovedad(MdloDtos.VisitaMotonaveNovedad _Novedad)
        {
            var ObjVisitaMotonaveNovedad = new MdloDtos.VisitaMotonaveNovedad();
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    string CorreoUsuario = "";
                    MdloDtos.CorreoElectronico ObjModeloCorreo = new CorreoElectronico();


                    var usuarioCorreo = (from co in _dbContex.Usuarios
                                         where co.UsCdgo == _Novedad.VmnCdgoUsrio
                                         select co).ToList();
                    foreach (var la in usuarioCorreo)
                    {

                        CorreoUsuario = la.UsEmail;
                    }


                    ObjVisitaMotonaveNovedad.VmnRowidVstaMtnve = _Novedad.VmnRowidVstaMtnve;
                    ObjVisitaMotonaveNovedad.VmnTtlo = _Novedad.VmnTtlo;
                    ObjVisitaMotonaveNovedad.VmnCmntrios = _Novedad.VmnCmntrios;
                    ObjVisitaMotonaveNovedad.VmnCdgoUsrio = _Novedad.VmnCdgoUsrio;
                    ObjVisitaMotonaveNovedad.VmnFcha = _Novedad.VmnFcha;
                    var res = await _dbContex.VisitaMotonaveNovedads.AddAsync(ObjVisitaMotonaveNovedad);
                    await _dbContex.SaveChangesAsync();
                    //envia correo
                    var correo = (from l in _dbContex.Parametros select l).ToList();
                    if (correo.Count > 0 || correo != null)
                    {

                        foreach (var item in correo)
                        {

                            ObjModeloCorreo.Servidor_Correo = item.PaCrreoSrvdor;
                            ObjModeloCorreo.Cuenta_Correo = item.PaCrreoUsrio;
                            ObjModeloCorreo.Clave_Correo = item.PaCrreoClve;
                            ObjModeloCorreo.Puerto_Correo = (int)item.PaCrreoPrto;
                            ObjModeloCorreo.Para = CorreoUsuario;
                            ObjModeloCorreo.Asunto = _Novedad.VmnTtlo;
                            ObjModeloCorreo.Mensaje = _Novedad.VmnCmntrios;
                            ObjModeloCorreo.Nombre_Archivo = "";
                            ObjModeloCorreo.Msg_error = "";

                        }

                    }
                

                    _dbContex.Dispose();
                    return ObjVisitaMotonaveNovedad;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.ToString());
                }
            }
        }
        #endregion

        #region Consulta todos los datos de Novedad.
        public async Task<List<MdloDtos.VisitaMotonaveNovedad>> ListarNovedad(int IdVisita)
        {
           using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {

                var lst = await (from v in _dbContex.VisitaMotonaveNovedads
                                 where v.VmnRowidVstaMtnve== IdVisita
                                 select v ).ToListAsync();
                _dbContex.Dispose();
                return lst;
            }
        }
        #endregion

        #region verificar un Id Visita de la novedad
        public async Task<bool> VerificarNovedadVisita(int? IdVisita)
        {
            bool respuesta = false;
            using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
            {
                try
                {
                    var ObjNovedad = await (from p in _dbContex.VisitaMotonaves
                                            where p.VmRowid == IdVisita
                                            select p).CountAsync();
                    if (ObjNovedad == null || ObjNovedad==0)
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

       */
    }
}
