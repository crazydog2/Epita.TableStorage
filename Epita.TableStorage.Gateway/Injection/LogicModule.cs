using Epita.TableStorage.Logic;
using Epita.TableStorage.Logic.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Epita.TableStorage.Gateway.Injection
{
    public class LogicModule : IInjectionModule
    {
        public void Register(IServiceCollection services)
        {
            services.AddSingleton<IUserLogic, UserLogic>();
        }
    }
}