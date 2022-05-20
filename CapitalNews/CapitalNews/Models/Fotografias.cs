using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Fotografias
    {
        public Fotografias()
        {
            ListaNoticias = new HashSet<FotografiasNoticias>();
        }

        [Key]
        public int Id { get; set; }


        public string Fotografia { get; set; }



        public virtual ICollection<FotografiasNoticias> ListaNoticias { get; set; }
    }
}
