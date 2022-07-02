using System.ComponentModel.DataAnnotations;

namespace CapitalNews.Models
{
    /// <summary>
    /// descrição de cada uma das Categorias
    /// </summary>
    public class Categorias
    {
        public Categorias()
        {
            ListaNoticias = new HashSet<Noticias>();
        }


        /// <summary>
        /// Identificador de cada Categoria
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome da Categoria
        /// </summary>
        public string CategoriaNome { get; set; }

        /// <summary>
        /// Lista das NOticias referentes às Categorias
        /// </summary>
        public ICollection<Noticias> ListaNoticias { get; set; }
    }
}
