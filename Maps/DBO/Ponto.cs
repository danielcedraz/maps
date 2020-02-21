using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maps.DBO
{
    /// <summary>
    /// Classe responsável por representar a tabela Pontos.
    /// </summary>
    [Table("Pontos")]
    public class Ponto
    {
        /// <summary>
        /// Propriedade reponsável por armazenar a chave primária do ponto no banco de dados.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar o nome do ponto no banco de dados.
        /// </summary>
        [Required]
        public string Nome { get; set; }
    }
}
