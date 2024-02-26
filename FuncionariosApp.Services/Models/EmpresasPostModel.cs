using System.ComponentModel.DataAnnotations;

namespace FuncionariosApp.Services.Models
{
    public class EmpresasPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome fantasia.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(80, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String? NomeFantasia { get; set; }
        [Required(ErrorMessage = "Por favor, informe a razão social.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [MaxLength(160, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        public String? RazaoSocial { get; set; }
        [Required(ErrorMessage = "Por favor, informe o CNPJ.")]
       // [MinLength(14, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
       // [MaxLength(18, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
       // [RegularExpression("^[0-9]{14}$", ErrorMessage = "Somente números são permitidos.")]
        public String? Cnpj { get; set; }
    }
}
