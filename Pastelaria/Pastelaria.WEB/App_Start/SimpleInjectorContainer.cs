using Pastelaria.WEB.Application.Cargo;
using Pastelaria.WEB.Application.Tarefa;
using Pastelaria.WEB.Application.Usuario;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace Pastelaria.WEB.App_Start
{
    public static class SimpleInjectorContainer
    {
        public static Container Build()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<UsuarioApplication>();
            container.Register<CargoApplication>();
            container.Register<TarefaApplication>();
            container.Verify();

            

            return container;
        }

    }
}