using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RegistroEventoAssociadov4.Models;

namespace RegistroEventoAssociadov4.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets para todas as entidades do projeto
        public DbSet<Associado> Associados { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Convidado> Convidados { get; set; }
        public DbSet<Dependente> Dependentes { get; set; }
        public DbSet<EspacoLocavel> EspacosLocaveis { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}
