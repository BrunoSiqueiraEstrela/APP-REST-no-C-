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
    public class UsuarioController : ControllerBase
    {

        private readonly IUsuarioPepository usuarioPepository;

        public UsuarioController(IUsuarioPepository usuarioPepository)
        {
            this.usuarioPepository = usuarioPepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetUsuarios() 
        {
            try
            {
                return Ok( await usuarioPepository.GetUsuarios());
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição da Data ");
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            try
            {
                var result = await usuarioPepository.GetUsuario(id);

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
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    return BadRequest();

                var emp = usuarioPepository.GetUsuarioPorEmail(usuario.Email);

                if (emp.Result != null) 
                {
                    
                    ModelState.AddModelError("Email", "Email já esta em uso ");
                    return BadRequest(ModelState);

                }

                var createdUsuario = await usuarioPepository.PostUsuario(usuario);



                return CreatedAtAction(nameof(PostUsuario), new { id = createdUsuario.UsuarioId }, createdUsuario);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro na requisição da Data ");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Usuario>> PutUsuario(int id, Usuario usuario) 
        {

            try 
            {
                if (id != usuario.UsuarioId)
                    return BadRequest($"ID de usuario errado {id} != de {usuario.UsuarioId}");

                var usuarioToPut = await usuarioPepository.GetUsuario(id);

                if (usuarioToPut == null)
                    return NotFound($"Usuario com id = {id} não foi achado");

                return await usuarioPepository.PutUsuario(usuario);

            } 
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro atualizando o usuario");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUsuario(int id)
        {

            try
            {
                var usuarioToDelete = await usuarioPepository.GetUsuario(id);

                if (usuarioToDelete == null)
                return NotFound($"Usuario com id = {id} não foi achado");

                await usuarioPepository.DeleteUsuario(id);

                return Ok($"Usuario com id = {id} foi deletado");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro deletando o usuario");
            }

        }


    }
}
