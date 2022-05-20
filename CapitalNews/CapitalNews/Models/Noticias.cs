using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaComentarios = new HashSet<Comentarios>();
            ListaJornalistas = new HashSet<JornalistasNoticias>();
            ListaFotografias = new HashSet<FotografiasNoticias>();
        }

        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Body { get; set; }

        public DateTime Data { get; set; }



        public int CategoriaFK { get; set; }
        [ForeignKey(nameof(CategoriaFK))]
        public Categorias Categoria { get; set; }

        public virtual ICollection<Comentarios> ListaComentarios { get; set; }
        public virtual ICollection<JornalistasNoticias> ListaJornalistas { get; set; }
        public virtual ICollection<FotografiasNoticias> ListaFotografias { get; set; }

    }
}
