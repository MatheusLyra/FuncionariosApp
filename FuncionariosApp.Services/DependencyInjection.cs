using FuncionariosApp.Domain.Interfaces.Repositories;
using FuncionariosApp.Domain.Interfaces.Services;
using FuncionariosApp.Domain.Services;
using FuncionariosApp.Infra.Data.Repositories;

namespace FuncionariosApp.Services
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection services)
        {
            services.AddTransient<IFuncionarioDomainService, FuncionarioDomainService>();
            services.AddTransient<IEmpresaDomainService    , EmpresaDomainService>();
            services.AddTransient<IFuncionarioRepository   , FuncionarioRepository>();
            services.AddTransient<IEmpresaRepository       , EmpresaRepository>();

        }
    }
}
