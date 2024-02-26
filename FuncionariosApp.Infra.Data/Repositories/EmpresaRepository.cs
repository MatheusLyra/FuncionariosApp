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
    public class EmpresaRepository :
          BaseRepository<Empresa>, IEmpresaRepository
    {
        public Empresa? GetByCNPJ(String cnpj)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext?.Set<Empresa>()
                                .Where(b => b.Cnpj.Replace(".","").Replace("/","").Replace("-","")
                                .Contains(cnpj.Replace(".", "").Replace("/", "").Replace("-", "")))
                                .FirstOrDefault();

            }
        }

        public Empresa? GetByRazao(String razao)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext?.Set<Empresa>()
                                .Where(b => b.RazaoSocial.ToUpper().Contains(razao.ToUpper()))
                                .FirstOrDefault();

            }
        }
    }
}
