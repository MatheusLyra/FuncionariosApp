using FuncionariosApp.Domain.Entities;
using FuncionariosApp.Domain.Interfaces.Repositories;
using FuncionariosApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Services
{
    public class FuncionarioDomainService: IFuncionarioDomainService
    {
        private readonly IFuncionarioRepository? _funcionarioRepository;
        private readonly IEmpresaRepository? _empresaRepository;


        public FuncionarioDomainService(IFuncionarioRepository? funcionarioRepository,
                                        IEmpresaRepository? empresaRepository) 
        {
            _funcionarioRepository = funcionarioRepository; 
            _empresaRepository = empresaRepository;
        }

        public void Cadastrar(Funcionario funcionario)
        {
            if (_empresaRepository?.GetById(funcionario.EmpresaId.Value) == null)
                throw new ApplicationException("A empresa informada não localizada. Por favor, verifique.");

            var funcionarioRepositoryM = _funcionarioRepository?.GetByMatricula(funcionario.Matricula);
            if (funcionarioRepositoryM != null)
                throw new ApplicationException("Matricula já cadastrada. Por favor, verifique");

            var funcionarioRepositoryC = _funcionarioRepository?.GetByCPF(funcionario.Cpf);
            if (funcionarioRepositoryC != null)
                throw new ApplicationException("CPF já cadastrado. Por favor, verifique");

            _funcionarioRepository?.Add(funcionario);
        }
        public void Atualizar(Funcionario funcionario)
        {
           // if (_funcionarioRepository?.GetById(funcionario.Id.Value) == null)
           //     throw new ApplicationException("Funcionário não localizado. Por favor, verifique.");

            if (_empresaRepository?.GetById(funcionario.EmpresaId.Value) == null)
                throw new ApplicationException("A empresa informada não localizada. Por favor, verifique.");

            var funcionarioRepository = _funcionarioRepository?.GetById(funcionario.Id.Value);
            if (funcionarioRepository == null)
                throw new ApplicationException("Funcionário não localizado. Por favor, verifique.");

            funcionario.DataHoraCadastro = funcionarioRepository.DataHoraCadastro;
            _funcionarioRepository?.Update(funcionario);
        }

        public void Excluir(Guid id)
        {
            var funcionario = _funcionarioRepository?.GetById(id);
            if (funcionario == null) 
                throw new ApplicationException("Funcionário não localizado. Não foi possível realizar a exclusão.");

            _funcionarioRepository?.Delete(funcionario);
        }

        public List<Funcionario> Consultar()
        {
            return _funcionarioRepository
                .GetAll()
                .OrderBy(f => f.Nome)
                .ToList(); ;
        }

        public Funcionario ConsultarPorId(Guid id)
        {
            return _funcionarioRepository.GetById(id);
        }

    }
}
