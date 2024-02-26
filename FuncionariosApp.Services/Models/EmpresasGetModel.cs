using System.ComponentModel.DataAnnotations;

namespace FuncionariosApp.Services.Models
{
    public class EmpresasGetModel
    {
        public Guid? Id { get; set; }
        public String? NomeFantasia { get; set; }
        public String? RazaoSocial { get; set; }
        public String? Cnpj { get; set; }
        public DateTime? DataHoraCadastro { get; set; }

    }
}
