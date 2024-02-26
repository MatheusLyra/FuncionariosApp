using FuncionariosApp.Domain.Entities;

namespace FuncionariosApp.Services.Models
{
    public class FuncionariosGetModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Matricula { get; set; }
        public String? Cpf { get; set; }
        public DateTime? DataAdmissao { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public Guid? EmpresaId { get; set; }
    }
}
