using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MdloDtos.IModelos
{
    public interface IDepartamento
    {
        public Task<List<MdloDtos.Departamento>> ListarDepartamento();

        public Task<List<MdloDtos.Departamento>> FiltrarDepartamentoPorPais(String Codigo);

        public Task<MdloDtos.Departamento> IngresarDepartamento(MdloDtos.Departamento ObjDepartamento);

        public Task<MdloDtos.Departamento> EditarDepartamento(MdloDtos.Departamento ObjDepartamento);

        public Task<List<MdloDtos.Departamento>> FiltrarDepartamentoGeneral(String Codigo);
        public Task<List<MdloDtos.Departamento>> FiltrarDepartamentoEspecifico(String Codigo);


        public Task<MdloDtos.Departamento> EliminarDepartamento(int Codigo);
    }
}
