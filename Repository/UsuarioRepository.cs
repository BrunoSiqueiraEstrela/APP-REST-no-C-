using Meus_produtos.Context;
using Meus_produtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MEUS_PRODUTOS.Repository
{
    public class UsuarioRepository : IUsuarioPepository
    {
        private readonly ContextMeusProdutos contextMeusProdutos;

        public UsuarioRepository(ContextMeusProdutos contextMeusProdutos)
        {
            this.contextMeusProdutos = contextMeusProdutos;
        }

        public async Task DeleteUsuario(int usuarioId)
        {

            var result = await contextMeusProdutos.Usuario.FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);

            if(result != null)
            {
                contextMeusProdutos.Usuario.Remove(result);
                await contextMeusProdutos.SaveChangesAsync();

            }
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await contextMeusProdutos.Usuario.ToListAsync();
        }

        public async Task<Usuario> GetUsuario(int id)
        {
            return await contextMeusProdutos.Usuario.FirstOrDefaultAsync(e => e.UsuarioId == id);
        }

        public async Task<Usuario> GetUsuarioPorEmail(string email)
        {
            return await contextMeusProdutos.Usuario.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<Usuario> PostUsuario(Usuario usuario)
        {
            var result = await contextMeusProdutos.Usuario.AddAsync(usuario);
            await contextMeusProdutos.SaveChangesAsync();
            return result.Entity;
        }


        public async Task<Usuario> PutUsuario(Usuario usuario)
        {
            var result = await contextMeusProdutos.Usuario.FirstOrDefaultAsync(e => e.UsuarioId == usuario.UsuarioId);

            if (result != null)
            {
                result.Nome = usuario.Nome;
                result.Email = usuario.Email;
                result.Senha = usuario.Senha;

                await contextMeusProdutos.SaveChangesAsync();

                return result;

            }
            return null;
        }

 
    }
}
