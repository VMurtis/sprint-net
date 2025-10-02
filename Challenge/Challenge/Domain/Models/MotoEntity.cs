using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Challenge.Domain.Models
{
    [Table("TB_moto")]
    public class MotoEntity

    

    {
        [Key]  
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        [Column("cd_moto")]  
        public int IdMoto { get; set; }

        [Column("modelo", TypeName = "nvarchar(100)")]  
        [Required]
        public string? Modelo { get; set; }

        [Column("placa", TypeName = "nvarchar(100)")]  
        [Required]  
        public string? Placa { get; set; }

        [Column("chassi", TypeName = "nvarchar(100)")]
        [Required]
        public string? Chassi { get; set; }

        
        [ForeignKey("Usuario")]  
        [Column("cd_user")]  
        public long UsuarioId { get; set; }  
        public UsuarioEntity? Usuario { get; set; }  

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



        
        [ForeignKey("Filial")]  
        [Column("filial_id")]  
        public long FilialId { get; set; }  
        public FilialEntity? Filial { get; set; }

        
        [ForeignKey("Usuario")]
        [Column("usuario_id")]
        public int UsuarioId { get; set; }  
        public UsuarioEntity? Usuario { get; set; }
    }
}
