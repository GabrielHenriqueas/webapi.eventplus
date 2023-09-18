using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.event_.Domains
{
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName =  "VARCHAR(100)")]
        [Required(ErrorMessage = "Nome do usuário é obrigatório!")]
        public string? NomeUsuario { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email do usuário é obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "CHAR(60)")]
        [Required(ErrorMessage = "Senha do usuário é obrigatório!")]
        [StringLength(60,MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 a 60 caracteres")]
        public string? Senha { get; set; }

        //Referência da tabela TipoUsuario = FK;
        [Required(ErrorMessage = "O tipo de Usuário é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
    }
}
