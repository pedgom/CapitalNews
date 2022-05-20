using System.ComponentModel.DataAnnotations;

namespace CapitalNews.Models
{
    public class Leitores
    {
        public Leitores()
        {
            ListaComentarios = new HashSet<Comentarios>();
        }

        [Key]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Fotolei { get; set; }

        public string Username { get; set; }

        public virtual ICollection<Comentarios> ListaComentarios { get; set; }



    }

}
