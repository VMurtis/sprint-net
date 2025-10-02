using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Models
{
    [Table("tb_cliente")]
    public class UsuarioEntity
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(150, ErrorMessage = "O nome deve ter no máximo 150 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O email deve ter no máximo 100 caracteres.")]
        [EmailAddress(ErrorMessage = "O email informado é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve ter 11 dígitos.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números.")]
        public string Cpf { get; set; } = string.Empty;

        [StringLength(20, ErrorMessage = "O telefone deve ter no máximo 20 caracteres.")]
        [RegularExpression(@"^\(?\d{2}\)?\s?\d{4,5}-?\d{4}$", ErrorMessage = "Telefone inválido. Formato esperado: (99) 99999-9999")]
        public string Telefone { get; set; } = string.Empty;

        internal UsuarioEntity ToUsuarioEntity()
        {
            throw new NotImplementedException();
        }
    }
}
