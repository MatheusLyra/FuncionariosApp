using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Entities
{
    public class Funcionario
    {

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public String? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? EmpresaId { get; set; }
        public Empresa? Empresa { get; set; }
    }
}
