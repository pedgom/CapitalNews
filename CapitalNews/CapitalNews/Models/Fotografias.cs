using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Fotografias
    {
        public Fotografias()
        {
            ListaNoticias = new HashSet<Noticias>();
        }

        [Key]
        public int Id { get; set; }
        public string NomeFoto { get; set; }
        public string Descritores { get; set; }



        public virtual ICollection<Noticias> ListaNoticias { get; set; }
    }
}
