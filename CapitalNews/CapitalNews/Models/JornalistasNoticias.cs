using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class JornalistasNoticias
    {
        [Key]
        public int Id { get; set; }

        
        public int NoticiaFK { get; set; }
        [ForeignKey(nameof(NoticiaFK))]
        public Noticias Noticia { get; set; }


        
        public int JornalistaFK { get; set; }
        [ForeignKey(nameof(JornalistaFK))]
        public Jornalistas Jornalista { get; set; }



        public string Funcao { get; set; }
    }
}
