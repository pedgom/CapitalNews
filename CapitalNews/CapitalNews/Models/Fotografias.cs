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

        /// <summary>
        /// Identificador de cada Fotografia
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Imagens para Noticias
        /// </summary>
        public string NomeFoto { get; set; }

        /// <summary>
        /// Descritor referente à foto da noticia
        /// </summary>
        public string Descritores { get; set; }


        /// <summary>
        /// Lista das Noticias referentes às Fotografias
        /// </summary>
        public virtual ICollection<Noticias> ListaNoticias { get; set; }
    }
}
