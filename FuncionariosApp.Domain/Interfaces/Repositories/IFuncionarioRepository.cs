using FuncionariosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Interfaces.Repositories
{
    public interface IFuncionarioRepository: IBaseRepository<Funcionario>
    {
        Funcionario? GetByMatricula(String matricula);

        Funcionario? GetByCPF(String cpf);
    }
}
