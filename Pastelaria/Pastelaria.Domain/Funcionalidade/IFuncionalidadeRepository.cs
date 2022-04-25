using Pastelaria.Domain.Funcionalidade.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Funcionalidade
{
    public interface IFuncionalidadeRepository
    {
        string Get();
        IEnumerable<FuncionalidadeDto> GetFuncionalidades();
        void Post(FuncionalidadeDto funcionalidade);
        void Put(FuncionalidadeDto funcionalidade);
        void Delete(int id);
    }
}
