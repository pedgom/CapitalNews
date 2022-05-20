using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class FotografiasNoticias
    {
        [Key]
        public int Id { get; set; }


        public int FotografiaFK { get; set; }
        [ForeignKey(nameof(FotografiaFK))]
        public Fotografias Fotografia { get; set; }

        public int NoticiaFK { get; set; }
        [ForeignKey(nameof(NoticiaFK))]
        public Noticias Noticia { get; set; }


        
        
    }
}
