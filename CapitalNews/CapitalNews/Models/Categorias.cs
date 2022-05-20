using System.ComponentModel.DataAnnotations;

namespace CapitalNews.Models
{
    public class Categorias
    {
        public Categorias()
        {
            ListaNoticias = new HashSet<Noticias>();
        }



        [Key]
        public int Id { get; set; }


        public string CategoriaNome { get; set; }


        public ICollection<Noticias> ListaNoticias { get; set; }
    }
}
