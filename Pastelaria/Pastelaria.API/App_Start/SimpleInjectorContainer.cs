using Pastelaria.Domain.Cargo;
using Pastelaria.Domain.Endereco.Dto;
using Pastelaria.Domain.Funcionalidade;
using Pastelaria.Domain.Permissoes;
using Pastelaria.Domain.Tarefa;
using Pastelaria.Domain.Ususario;
using Pastelaria.Domain.Ususario.Dto;
using Pastelaria.Repository;
using Pastelaria.Repository.Infra;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Pastelaria.API
{
    public class SimpleInjectorContainer
    {

        public static Container Build()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            //este serviço deve ir para função Registesr repository
            container.Register<ICargoRepository, CargoRepository>();
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IEnderecoRepository, EnderecoRepository>();
            container.Register<ITarefaRepository, TarefaRepository>();
            container.Register<IFuncionalidadeRepository, FuncionalidadeRepository>();
            container.Register<IPermissaoRepository, PermissaoRepository>();
            container.Register<IUsuarioService, UsuarioService>();
            container.Register<ITarefaService, TarefaService>();
            RegisterServices();
            RegisterRepositories();

            container.Register<BaseRepository>(Lifestyle.Scoped);

            container.Verify();

            return container;
        }

        private static void RegisterServices()
        {

        }

        private static void RegisterRepositories()
        {
           

        }


    }
}