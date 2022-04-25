using Pastelaria.Domain.Ususario.Dto;
using System.Collections.Generic;

namespace Pastelaria.Domain.Ususario
{
    public interface IUsuarioRepository
    {
        string Get();
        IEnumerable<UsuarioDto> GetUsuario();
        void Post(UsuarioDto entity);
        void Put(UsuarioDto entity);
        void Delete(int id);
        UsuarioDto PostLogin(UsuarioDto usuario);
        UsuarioDto GetUsuarioId(int id);
        void PutUser(UsuarioDto user);
    }
}
