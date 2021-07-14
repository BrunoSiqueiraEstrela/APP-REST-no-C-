using Meus_produtos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meus_produtos.Context
{
    public class ContextMeusProdutos : DbContext
    {

        public ContextMeusProdutos(DbContextOptions<ContextMeusProdutos> options) : base(options)
        {
            Database.EnsureCreated();

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>()
                .HasIndex(p => new { p.Email })
                .IsUnique(true);

            modelBuilder.Entity<Usuario>().HasData(new Usuario
            {
                UsuarioId = 1,
                Nome = "Bruno Estrela",
                Email = "brunosiqest2@gmail.com",
                Senha = "admin"
            }
            );

            modelBuilder.Entity<Produto>().HasData(new Produto
            {
                ProdutoId = 1,
                Nome = "Processador",
                Valor = 50,
                ProdutoStatus = "Ativo"
            }
            );
        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Produto> Produto { get; set; }


    }
}
