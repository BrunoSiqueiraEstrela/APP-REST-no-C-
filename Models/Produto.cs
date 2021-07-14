using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_produtos.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(80, MinimumLength = 3, ErrorMessage = "Fora dos limites")]
        public String Nome { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Apenas números positivos")]
        public int Valor { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 3, ErrorMessage = "Fora dos limites")]
        [Column("Status")]
        public string ProdutoStatus { get; set; }

    }
}
