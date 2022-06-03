using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaComentarios = new HashSet<Comentarios>();
           
        }

        [Key]
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Body { get; set; }

        public DateTime Data { get; set; }



        public int CategoriaFK { get; set; }
        [ForeignKey(nameof(CategoriaFK))]
        public Categorias Categoria { get; set; }

        public int JornalistaFK { get; set; }
        [ForeignKey(nameof(JornalistaFK))]
        public Jornalistas Jornalista { get; set; }

        public int FotografiaFK { get; set; }
        [ForeignKey(nameof(FotografiaFK))]
        public Fotografias Fotografia { get; set; }

        public virtual ICollection<Comentarios> ListaComentarios { get; set; }
        

    }
}
