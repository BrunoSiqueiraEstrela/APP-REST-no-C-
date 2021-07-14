using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meus_produtos.Models;

namespace MEUS_PRODUTOS.Repository
{
    public interface IProdutoRepository
    {

        Task<IEnumerable<Produto>> GetProdutos();
        Task<Produto> GetProduto(int produtoId);
        Task<Produto> PostProduto(Produto produto);
        Task<Produto> PutProduto(Produto produto);
        Task DeleteProduto(int produtoId);

  

    }
}
