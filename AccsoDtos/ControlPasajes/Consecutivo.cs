using AccsoDtos.Parametrizacion;
using AccsoDtos.VisitaMotonave;
using AutoMapper;
using MdloDtos;
using MdloDtos.DTO;
using MdloDtos.IModelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AccsoDtos.ControlPesajes;

public class Consecutivo : MdloDtos.IModelos.IConsecutivo
{

    private readonly CcVenturaContext _dbContext;
    private readonly IMapper _mapper;


    public Consecutivo( IMapper mapper, MdloDtos.CcVenturaContext dbContext)
    {
        _mapper = mapper;
        _dbContext = dbContext;
    }


    //Consultar toda la tabla
    public async Task<List<ConsecutivoDTO>> ConsultarConsecutivo()
    {
        try
        {
            var consecutivoLst = await _dbContext.Consecutivos
                .Include(p => p.CoCdgoCiaNavigation)
                .ToListAsync();

            var result = _mapper.Map<List<ConsecutivoDTO>>(consecutivoLst);

            return result;
        }
        catch (Exception ex)
        {
            return [];
        }
    }

    //Filtrar un consecutivo por el codigo de la compañia
    public async Task<List<ConsecutivoDTO>> FiltrarConsecutivoPorCompania(string CodigoCompania)
    {
        try
        {
            var consecutivoLst = await _dbContext.Consecutivos
                .Include(p => p.CoCdgoCiaNavigation)
                .Where(p=>p.CoCdgoCia== CodigoCompania)
                .ToListAsync();

            var result = _mapper.Map<List<ConsecutivoDTO>>(consecutivoLst);

            return result;
        }
        catch (Exception ex)
        {
            return [];
        }
    }


    //Filtrar consectivo por el ID
    public async Task<List<ConsecutivoDTO>> FiltrarConsecutivoId(Int32 Id)
    {
        try
        {
            var consecutivoLst = await _dbContext.Consecutivos
                .Include(p => p.CoCdgoCiaNavigation)
                .Where(p => p.CoRowid == Id)
                .ToListAsync();

            var result = _mapper.Map<List<ConsecutivoDTO>>(consecutivoLst);

            return result;
        }
        catch (Exception ex)
        {
            return [];
        }
    }

    //ingresar datos del sub deposito
    public async Task<dynamic> IngresarConsecutivo(ConsecutivoDTO ObjConsecutivo)
    {

        var ObjConsecutivoIng = new MdloDtos.Consecutivo();
        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        {
            try
            {
                var ConsecutivoExiste = await this.VerificarConsecutivo(ObjConsecutivo.Id);

                if (ConsecutivoExiste == true)
                {
                    throw new Exception(MdloDtos.Utilidades.Mensajes.Error + " al momento de hacer un :" + MdloDtos.Utilidades.Constantes.TipoOperacion.Ingreso);
                }
                else
                {
                    ObjConsecutivoIng.CoCdgoCia = ObjConsecutivo.CodigoCompania;
                    ObjConsecutivoIng.CoNmbre = ObjConsecutivo.Nombre;
                    ObjConsecutivoIng.CoCdgo = ObjConsecutivo.Codigo;
                    ObjConsecutivoIng.CoCntdor = ObjConsecutivo.Contador;

                    var res = await _dbContex.Consecutivos.AddAsync(ObjConsecutivoIng);
                    await _dbContex.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            _dbContex.Dispose();
            return ObjConsecutivoIng;
        }
    }


    // verifica la existencia de un consecutivo
    public async Task<bool> VerificarConsecutivo(int Id)
    {
        bool respuesta = false;
        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        {
            try
            {
                var ObjConsecutivo = await _dbContex.Consecutivos.FindAsync(Id);
                if (ObjConsecutivo == null)
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



    //Actualizar consecutivo
    public async Task<dynamic> EditarConsecutivo(ConsecutivoDTO ObjConsecutivo)
    {
        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        {
            try
            {
                var ConsecutivoExiste = await _dbContex.Consecutivos.FindAsync(ObjConsecutivo.Id);
                if (ConsecutivoExiste != null)
                {
                    ConsecutivoExiste.CoCdgoCia = ObjConsecutivo.CodigoCompania;
                    ConsecutivoExiste.CoNmbre = ObjConsecutivo.Nombre;
                    ConsecutivoExiste.CoCdgo = ObjConsecutivo.Codigo;
                    ConsecutivoExiste.CoCntdor = ObjConsecutivo.Contador;

                    _dbContex.Consecutivos.Update(ConsecutivoExiste).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    await _dbContex.SaveChangesAsync();
                }
                _dbContex.Dispose();
                return ConsecutivoExiste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

    }

    /// Elimina un consecutivo
    public async Task<dynamic> EliminarConsecutivo(Int32 Id)
    {
        using (MdloDtos.CcVenturaContext _dbContex = new MdloDtos.CcVenturaContext())
        {
            try
            {
                var consecutivoExiste = await _dbContex.Consecutivos.FindAsync(Id);
                if (consecutivoExiste == null)
                {
                    throw new DllNotFoundException();
                }
                else
                {
                    _dbContex.Remove(consecutivoExiste);
                    await _dbContex.SaveChangesAsync();
                }
                _dbContex.Dispose();
                return consecutivoExiste;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
  


}
