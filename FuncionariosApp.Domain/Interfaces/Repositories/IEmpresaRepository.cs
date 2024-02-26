using FuncionariosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Interfaces.Repositories
{
    public interface IEmpresaRepository: IBaseRepository<Empresa>
    {
        Empresa? GetByRazao(String razao);

        Empresa? GetByCNPJ(String cnpj);
    }

}
