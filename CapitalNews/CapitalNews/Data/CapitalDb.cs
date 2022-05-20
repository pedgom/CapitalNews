using CapitalNews.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CapitalNews.Data
{
    public class CapitalDb : IdentityDbContext
    {
        public CapitalDb(DbContextOptions<CapitalDb> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 'importa' todo o comportamento do método, 
            // aquando da sua definição na SuperClasse
            base.OnModelCreating(modelBuilder);

            // adicionar registos que serão adicionados às
            // tabelas da BD
            modelBuilder.Entity<Jornalistas>().HasData(
               new Jornalistas()
               {
                   Id = 1,
                   Nome = "José Silva",
                   Email = "jose@gmail.com",
                   Fotojor = "Jose.jpg"
               },
               new Jornalistas()
               {
                   Id = 2,
                   Nome = "Maria Gomes dos Santos",
                   Email = "maria@gmail.com",
                   Fotojor = "Maria.jpg"
               },
               new Jornalistas()
               {
                   Id = 3,
                   Nome = "Ricardo Sousa",
                   Email = "ricardo@gmail.com",
                   Fotojor = "Ricardo.jpg"
               }
            );

        }


        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Fotografias> Fotografias { get; set; }
        public DbSet<FotografiasNoticias> FotografiasNoticias { get; set; }
        public DbSet<Jornalistas> Jornalistas { get; set; }
        public DbSet<JornalistasNoticias> JornalistasNoticias { get; set; }
        public DbSet<Leitores> Leitores { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
    }

}