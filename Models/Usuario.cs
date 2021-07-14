using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_produtos.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Fora dos limites")]
        public String Nome { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Fora dos limites")]
        public String Senha { get; set; }

        [Required]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public String Email { get; set; }
    }
}
