using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CapitalNews.Models
{
    public class Comentarios
    {
        /// <summary>
        /// Identificador de Comentario
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Texto do comentario
        /// </summary>
        public string TextoComentario { get; set; }

        /// <summary>
        /// Data da publicação do comentario
        /// </summary>
        public DateTime DataComentario { get; set; }

        public Boolean Visibilidade { get; set; }

        /// <summary>
        /// FK para Noticias
        /// </summary>
        public int NoticiaFK { get; set; }
        [ForeignKey(nameof(NoticiaFK))]
        public Noticias Noticia { get; set; }



        /// <summary>
        /// FK para Leitores
        /// </summary>
        public int LeitorFK { get; set; }
        [ForeignKey(nameof(LeitorFK))]
        public Leitores Leitor { get; set; }
    }
}
