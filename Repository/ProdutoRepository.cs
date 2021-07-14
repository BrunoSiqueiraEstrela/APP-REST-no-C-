using Meus_produtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Meus_produtos.Context;

namespace MEUS_PRODUTOS.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ContextMeusProdutos contextMeusProdutos;

        public ProdutoRepository(ContextMeusProdutos contextMeusProdutos)
        {
            this.contextMeusProdutos = contextMeusProdutos;
        }

        public async Task DeleteProduto(int produtoId)
        {
            var result = await contextMeusProdutos.Produto.FirstOrDefaultAsync(e => e.ProdutoId == produtoId);

            if (result != null)
            {
                contextMeusProdutos.Produto.Remove(result);
                await contextMeusProdutos.SaveChangesAsync();

            }
        }

        public async Task<Produto> GetProduto(int produtoId)
        {
            return await contextMeusProdutos.Produto.FirstOrDefaultAsync(e => e.ProdutoId == produtoId);
        }

        public async Task<IEnumerable<Produto>> GetProdutos()
        {
            return await contextMeusProdutos.Produto.ToListAsync();
        }

        public async Task<Produto> PostProduto(Produto produto)
        {
            var result = await contextMeusProdutos.Produto.AddAsync(produto);
            await contextMeusProdutos.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Produto> PutProduto(Produto produto)
        {
            var result = await contextMeusProdutos.Produto.FirstOrDefaultAsync(e => e.ProdutoId == produto.ProdutoId);

            if (result != null)
            {
                result.Nome = produto.Nome;
                result.Valor = produto.Valor;
                result.ProdutoStatus = produto.ProdutoStatus;

                await contextMeusProdutos.SaveChangesAsync();

                return result;

            }
            return null;
        }
    }
}
