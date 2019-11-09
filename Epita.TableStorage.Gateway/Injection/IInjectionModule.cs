using Microsoft.Extensions.DependencyInjection;

namespace Epita.TableStorage.Gateway.Injection
{
    public interface IInjectionModule
    {
        void Register(IServiceCollection services);
    }
}