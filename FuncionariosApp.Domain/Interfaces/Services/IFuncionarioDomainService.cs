using FuncionariosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Interfaces.Services
{
    public interface IFuncionarioDomainService
    {
        void Cadastrar(Funcionario funcionario);
        void Atualizar(Funcionario funcionario);
        void Excluir(Guid id);
        List<Funcionario> Consultar();
        Funcionario ConsultarPorId(Guid id);

    }
}
