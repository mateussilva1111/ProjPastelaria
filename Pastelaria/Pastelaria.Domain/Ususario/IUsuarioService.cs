using Pastelaria.Domain.Ususario.Dto;

namespace Pastelaria.Domain.Ususario
{
    public interface IUsuarioService
    {
        UsuarioDto PostLogin(UsuarioDto usuario);
    }
}
