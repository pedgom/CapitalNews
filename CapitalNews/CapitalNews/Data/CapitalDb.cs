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