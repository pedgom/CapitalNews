using System.ComponentModel.DataAnnotations;

namespace CapitalNews.Models
{

    /// <summary>
    /// Representa os dados de um Leitor
    /// </summary>
    public class Leitores
    {
        public Leitores()
        {
            ListaComentarios = new HashSet<Comentarios>();
        }

        /// <summary>
        /// PK para a tabela dos Leitores
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Nome do Leitor
        /// </summary>
        [Required(ErrorMessage = "O Nome é de preenchimento obrigatório")]
        [StringLength(60, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [RegularExpression("[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+(( | d[ao](s)? | e |-|'| d')[A-ZÓÂÍ][a-zçáéíóúàèìòùãõäëïöüâêîôûñ]+){1,3}")]
        public string Nome { get; set; }

        /// <summary>
        /// Email do Leitor
        /// </summary>
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        [EmailAddress(ErrorMessage = "O {0} introduzido não é válido")]
        public string Email { get; set; }

        /// <summary>
        /// Data de Nascimento do Leitor
        /// </summary>
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}")]
        [Display(Name = "Data de Nascimento")]
        [Required]
        public DateTime Datanasc { get; set; }

        /// <summary>
        /// Sexo do Leitor 
        /// Ff - feminino; Mm - masculino
        /// </summary>
        [StringLength(1, ErrorMessage = "O {0} só aceita um caráter.")]
        [RegularExpression("[FfMm]", ErrorMessage = "No {0} só se aceitam as letras F ou M.")]
        public string Sexo { get; set; }

        /// <summary>
        /// Nome do ficheiro que contém a foto do Leitor
        /// </summary>
        public string Fotolei { get; set; }


        /// <summary>
        /// Username do Leitor
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// lista de Comentarios associados ao Leitor
        /// </summary>
        public virtual ICollection<Comentarios> ListaComentarios { get; set; }



    }

}
