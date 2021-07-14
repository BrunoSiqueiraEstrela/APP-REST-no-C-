using Meus_produtos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEUS_PRODUTOS.Repository
{
    public interface IUsuarioPepository
    {
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> GetUsuario(int id);
        Task<Usuario> GetUsuarioPorEmail(String email);
        Task<Usuario> PostUsuario(Usuario usuario);
        Task<Usuario> PutUsuario(Usuario usuario);
        Task DeleteUsuario(int usuarioId);
        
    }
}
