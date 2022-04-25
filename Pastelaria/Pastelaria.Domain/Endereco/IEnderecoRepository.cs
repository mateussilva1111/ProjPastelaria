using System.Collections.Generic;

namespace Pastelaria.Domain.Endereco.Dto
{
    public interface IEnderecoRepository
    {
        string Get();
        IEnumerable<EnderecoDto> GetEnderecos();
        EnderecoDto GetEnderecoId(int id);
        void Post(EnderecoDto endereco);
        void Put(EnderecoDto endereco);
        void Delete(int id);
    }
}
