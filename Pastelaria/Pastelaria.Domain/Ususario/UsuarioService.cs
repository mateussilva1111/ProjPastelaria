using Pastelaria.Domain.Permissoes;

namespace Pastelaria.Domain.Ususario.Dto
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IPermissaoRepository _permissaoRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository, IPermissaoRepository permissaoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _permissaoRepository = permissaoRepository;
        }

        public UsuarioDto PostLogin(UsuarioDto usuario)
        {
            var dados = _usuarioRepository.PostLogin(usuario);
            dados.Permissoes = _permissaoRepository.GetpermissaoUser(usuario.Num_Usuario);

            return dados;
        }
    }
}
