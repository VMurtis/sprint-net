using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Challenge.Domain.Models
{
    [Table("TB_filial")]
    public class FilialEntity
    {
        [Key]
        [Column("cd_filial")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // equivalente ao @GeneratedValue
        public long Id { get; set; }

        [Column("filial_nome")]
        [Required]                    // equivalente a nullable = false
        [MaxLength(100)]              // equivalente a length = 100
        public string FilialNome { get; set; } = string.Empty;

        [Column("endereco")]
        [Required]
        [MaxLength(100)]
        public string Endereco { get; set; } = string.Empty;

        [Column("contato")]
        [Required]
        [MaxLength(100)]
        public string Contato { get; set; } = string.Empty;

        [Column("horario_funcionamento")]
        [Required]
        [MaxLength(100)]
        public string HorarioFuncionamento { get; set; } = string.Empty;
    }
}
