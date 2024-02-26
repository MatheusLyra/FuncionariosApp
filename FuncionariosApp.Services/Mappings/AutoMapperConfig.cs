using AutoMapper;
using FuncionariosApp.Domain.Entities;
using FuncionariosApp.Services.Models;

namespace FuncionariosApp.Services.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<FuncionariosPostModel, Funcionario>()
                 .AfterMap((model, entity) =>
            {
                entity.Id = Guid.NewGuid();
            });

            CreateMap<EmpresasPostModel, Empresa>()
                 .AfterMap((model, entity) =>
                 {
                     entity.Id = Guid.NewGuid();
                 });

            CreateMap<Empresa    , EmpresasGetModel>();
            CreateMap<Funcionario, FuncionariosGetModel>();

            CreateMap<EmpresasPutModel    , Empresa>();
            CreateMap<FuncionariosPutModel, Funcionario>();

        }
    }
}
