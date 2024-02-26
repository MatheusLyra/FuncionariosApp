using FuncionariosApp.Domain.Entities;
using FuncionariosApp.Domain.Interfaces.Repositories;
using FuncionariosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Services
{
    public class EmpresaDomainService : IEmpresaDomainService
    {
        private readonly IEmpresaRepository? _empresaRepository;

        public EmpresaDomainService(IEmpresaRepository? empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }
        public void Cadastrar(Empresa empresa)
        {
            var empresaRepositoryR = _empresaRepository?.GetByRazao(empresa.RazaoSocial);
            if (empresaRepositoryR != null)
                throw new ApplicationException("Razão Social já cadastrada. Por favor, verifique");

            var empresaRepositoryC = _empresaRepository?.GetByCNPJ(empresa.Cnpj);
            if (empresaRepositoryC != null)
                throw new ApplicationException("CNPJ já cadastrado. Por favor, verifique");

            _empresaRepository?.Add(empresa);
        }

        public void Atualizar(Empresa empresa)
        {

           var empresaRepository = _empresaRepository?.GetById(empresa.Id.Value);
           if (empresaRepository == null)
               throw new ApplicationException("Empresa não localizada. Por favor, verifique");

            empresa.DataHoraCadastro = empresaRepository.DataHoraCadastro;
            _empresaRepository?.Update(empresa);
        }

        public void Excluir(Guid id)
        {
            var empresa = _empresaRepository?.GetById(id);

            if (empresa == null)
                throw new ApplicationException("Empresa não localizada. Não foi possivel realizar a exclusão."); 

            _empresaRepository?.Delete(empresa);
        }

        public List<Empresa> Consultar()
        {
            return _empresaRepository
                .GetAll()
                .OrderBy(e => e.NomeFantasia)
                .ToList();
        }

        public Empresa ConsultarPorId(Guid id)
        {
            return _empresaRepository
                .GetById(id);
        }


    }
}
