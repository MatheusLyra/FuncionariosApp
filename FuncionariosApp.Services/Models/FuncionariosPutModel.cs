using System.ComponentModel.DataAnnotations;

namespace FuncionariosApp.Services.Models
{
    public class FuncionariosPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id do funcionário.")]
        public Guid? Id { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do funcionário.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(200, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a matrícula do funcionário.")]
        [MinLength(7, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(20, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Somente números são permitidos.")]
        public String? Matricula { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cpf do funcionário.")]
        [RegularExpression("^[0-9]{11}$", ErrorMessage = "Somente números são permitidos.")]
        public String? Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data e hora da admissão.")]
        public DateTime? DataAdmissao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid? EmpresaId { get; set; }
    }
}
