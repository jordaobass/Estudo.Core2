using Alura.WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace Alura.WebAPI.DAL.Livros
{
    public class LeituraContext : DbContext
    {
        public DbSet<Livro> Livros { get; set; }

        public LeituraContext(DbContextOptions<LeituraContext> options) 
            : base(options)
        {
            //irá criar o banco e a estrutura de tabelas necessárias
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<Livro>(new LivroConfiguration());
        }
    }
}
