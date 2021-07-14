using Meus_produtos.Models;
using MEUS_PRODUTOS.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEUS_PRODUTOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository produtoPepository;
                                           

        public ProdutoController(IProdutoRepository produtoPepository)
        {
            this.produtoPepository = produtoPepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetProdutos()
        {
            try
            {
                return Ok(await produtoPepository.GetProdutos());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição da Data ");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            try
            {
                var result = await produtoPepository.GetProduto(id);

                if (result == null)
                    return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição da Data ");
            }

        }


        [HttpPost]
        public async Task<ActionResult<Produto>> Postproduto(Produto produto)
        {
            try
            {
                if (produto == null)
                    return BadRequest();

                var createdproduto = await produtoPepository.PostProduto(produto);



                return CreatedAtAction(nameof(Postproduto), new { id = createdproduto.ProdutoId }, createdproduto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição da Data ");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Produto>> Putproduto(int id, Produto produto)
        {

            try
            {
                if (id != produto.ProdutoId)
                    return BadRequest($"ID de produto errado {id} != de {produto.ProdutoId}");

                var produtoToPut = await produtoPepository.GetProduto(id);

                if (produtoToPut == null)
                    return NotFound($"produto com id = {id} não foi achado");

                return await produtoPepository.PutProduto(produto);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro atualizando o produto");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Deleteproduto(int id)
        {

            try
            {
                var produtoToDelete = await produtoPepository.GetProduto(id);

                if (produtoToDelete == null)
                    return NotFound($"produto com id = {id} não foi achado");

                await produtoPepository.DeleteProduto(id);

                return Ok($"produto com id = {id} foi deletado");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro deletando o produto");
            }

        }

    }
}
