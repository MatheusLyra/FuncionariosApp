using FuncionariosApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Interfaces.Services
{
    public interface IEmpresaDomainService
    {
        void Cadastrar(Empresa empresa);
        void Atualizar(Empresa empresa);
        void Excluir(Guid id);

        List<Empresa> Consultar();
        Empresa ConsultarPorId(Guid id);

    }
}
