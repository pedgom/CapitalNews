using System.ComponentModel.DataAnnotations;

namespace CapitalNews.Models
{
    public class Jornalistas
    {
        public Jornalistas()
        {
            ListaNoticias = new HashSet<JornalistasNoticias>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Fotojor { get; set; }


        public virtual ICollection<JornalistasNoticias> ListaNoticias { get; set; }
    }
}
