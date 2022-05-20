using System.ComponentModel.DataAnnotations;

namespace CapitalNews.Models
{
    public class Jornalistas
    {
        public Jornalistas()
        {
            ListaNoticias = new HashSet<JornalistasNoticias>();
        }


        /// <summary>
        /// PK para a tabela dos Jornalistas
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Jornalista
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Email do Jornalista
        /// </summary>
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O {0} introduzido não é válido")]
        public string Email { get; set; }


        /// <summary>
        /// Nome do ficheiro que contém a fotografia do Jornalista
        /// </summary>
        public string Fotojor { get; set; }

        /// <summary>
        /// Lista de Noticias postadas pelo Jornalistas
        /// </summary>
        public virtual ICollection<JornalistasNoticias> ListaNoticias { get; set; }
    }
}
