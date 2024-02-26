using FuncionariosApp.Domain.Entities;
using FuncionariosApp.Domain.Interfaces.Repositories;
using FuncionariosApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Infra.Data.Repositories
{
    public class FuncionarioRepository :
         BaseRepository<Funcionario>, IFuncionarioRepository
    {
        public Funcionario? GetByCPF(string cpf)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext?.Set<Funcionario>()
                                .Where(b => b.Cpf.Replace(".", "").Replace("-", "")
                                .Contains(cpf.Replace(".", "").Replace("-", "")))
                                .FirstOrDefault();

            }
        }

        public Funcionario? GetByMatricula(string matricula)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext?.Set<Funcionario>()
                                .Where(b => b.Matricula.Contains(matricula))
                                .FirstOrDefault();

            }
        }
    }
}
