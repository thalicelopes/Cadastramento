using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cadastramento.Models;

namespace Cadastramento.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //REFERÊNCIA DE TABELAS
        public DbSet<Produtos> Produtos { get; set; }
        public DbSet<Acessos> Acessos { get; set; }
    }
}