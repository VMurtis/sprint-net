using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Models
{
    [Table("TB_moto")]
    public class MotoEntity

    

    {
        [Key]  // Define a chave primária da entidade
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  // A chave é gerada automaticamente
        [Column("cd_moto")]  // Nome da coluna no banco
        public int IdMoto { get; set; }

        [Column("modelo", TypeName = "nvarchar(100)")]  // Define o tipo da coluna e tamanho
        [Required]
        public string? Modelo { get; set; }

        [Column("placa", TypeName = "nvarchar(100)")]  // Define o tipo da coluna e tamanho
        [Required]  // Define que o campo é obrigatório (não pode ser nulo)
        public string? Placa { get; set; }

        [Column("chassi", TypeName = "nvarchar(100)")]
        [Required]
        public string? Chassi { get; set; }

        // Relacionamento Many-to-One com a entidade Usuario
        [ForeignKey("Usuario")]  // Chave estrangeira que se refere à entidade Usuario
        [Column("cd_user")]  // Nome da coluna no banco
        public long UsuarioId { get; set; }  // A chave estrangeira
        public UsuarioEntity? Usuario { get; set; }  // Navegação para a entidade Usuario

        [Column("iot_info", TypeName = "nvarchar(100)")]
        [Required]
        public string? IotInfo { get; set; }

        [Column("rfid_tag", TypeName = "nvarchar(100)")]
        [Required]
        public string? RfidTag { get; set; }

        [Column("localizacao", TypeName = "nvarchar(100)")]
        [Required]
        public string? Localizacao { get; set; }

        [Column("status_atual", TypeName = "nvarchar(100)")]
        [Required]
        public string StatusAtual { get; set; } = "Ativo";

        [Column("id_filial", TypeName = "nvarchar(100)")]
        [Required]
        public string? IdFilial { get; set; }


        // Relacionamento Many-to-One com a entidade Usuario
        [ForeignKey("Usuario")]  // Chave estrangeira para a entidade Usuario
        [Column("usuario_id")]  // Nome da coluna no banco
        public long UsuarioId2 { get; set; }  // Chave estrangeira
        public UsuarioEntity? Usuario2 { get; set; }  // Navegação para o segundo relacionamento com Usuario

        // Relacionamento Many-to-One com a entidade Filial
        [ForeignKey("Filial")]  // Chave estrangeira para a entidade Filial
        [Column("filial_id")]  // Nome da coluna no banco
        public long FilialId { get; set; }  // Chave estrangeira
        public FilialEntity? Filial { get; set; }
    }
}
