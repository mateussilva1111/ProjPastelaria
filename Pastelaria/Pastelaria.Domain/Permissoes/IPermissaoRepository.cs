using Pastelaria.Domain.Permissoes.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Permissoes
{
    public interface IPermissaoRepository
    {
        string Get();
        IEnumerable<PermissaoDto> Getpermissao();
        void Post(PermissaoDto permissao);
        void Put(PermissaoDto permissao);
        void Delete(int id);
        List<PermissaoDto> GetpermissaoUser(int id);
        
    }
}
