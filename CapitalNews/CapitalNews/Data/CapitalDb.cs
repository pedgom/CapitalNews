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

            modelBuilder.Entity<Categorias>().HasData(
                 new Categorias()
                 {
                     Id = 1,
                     CategoriaNome = "País"

                 },

               new Categorias()
               {
                   Id = 2,
                   CategoriaNome = "Mundo"

               },

               new Categorias()
               {
                   Id = 3,
                   CategoriaNome = "Economia"

               },

               new Categorias()
               {
                   Id = 4,
                   CategoriaNome = "Desporto"

               },

               new Categorias()
               {
                   Id = 5,
                   CategoriaNome = "Cultura"

               },

               new Categorias()
               {
                   Id = 6,
                   CategoriaNome = "Política"

               },

               new Categorias()
               {
                   Id = 7,
                   CategoriaNome = "Tecnologia"

               },

               new Categorias()
               {
                   Id = 8,
                   CategoriaNome = "Auto"

               }


            );


            

        }


        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Fotografias> Fotografias { get; set; }
        public DbSet<Jornalistas> Jornalistas { get; set; }
        public DbSet<Leitores> Leitores { get; set; }
        public DbSet<Noticias> Noticias { get; set; }
    }

}