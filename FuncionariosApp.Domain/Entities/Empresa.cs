using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncionariosApp.Domain.Entities
{
    public class Empresa
    {
        public Guid? Id { get; set; }
        public String? NomeFantasia { get; set; }
        public String? RazaoSocial { get; set; }
        public String? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public List<Funcionario>? Funcionarios { get; set; }

    }
}
