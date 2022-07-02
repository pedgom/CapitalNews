using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Noticias
    {
        public Noticias()
        {
            ListaComentarios = new HashSet<Comentarios>();
           
        }


        /// <summary>
        /// Identificador de cada Bebida
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Titulo da Noticia
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição da Noticia
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Data de publicação da Noticia
        /// </summary>
        public DateTime Data { get; set; }


        /// <summary>
        /// FK Categoria
        /// </summary>
        public int CategoriaFK { get; set; }
        [ForeignKey(nameof(CategoriaFK))]
        public Categorias Categoria { get; set; }

        /// <summary>
        /// FK Jornalista
        /// </summary>
        public int JornalistaFK { get; set; }
        [ForeignKey(nameof(JornalistaFK))]
        public Jornalistas Jornalista { get; set; }

        /// <summary>
        /// FK Fotografia
        /// </summary>
        public int FotografiaFK { get; set; }
        [ForeignKey(nameof(FotografiaFK))]
        public Fotografias Fotografia { get; set; }

        /// <summary>
        /// Lista de comentarios referentes às Noticias
        /// </summary>
        public virtual ICollection<Comentarios> ListaComentarios { get; set; }
        

    }
}
