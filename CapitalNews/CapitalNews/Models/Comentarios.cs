using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Comentarios
    {

        [Key]
        public int Id { get; set; }

        public string TextoComentario { get; set; }

        public DateTime DataComentario { get; set; }

        public Boolean Visibilidade { get; set; }

        public int NoticiaFK { get; set; }
        [ForeignKey(nameof(NoticiaFK))]
        public Noticias Noticia { get; set; }




        public int LeitorFK { get; set; }
        [ForeignKey(nameof(LeitorFK))]
        public Leitores Leitor { get; set; }
    }
}
