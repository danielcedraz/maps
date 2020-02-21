using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maps.DBO
{

    /// <summary>
    /// Classe responsável por representar a entidade Paradas no banco de dados.
    /// </summary>
    [Table("Paradas")]
    public class Parada
    {

        /// <summary>
        /// Propriedade reponsável por armazenar a chave primária da parada no banco de dados.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar a chave extrangeira da rota na tabela de parada.
        /// </summary>
        [Required]
        [Column("Rota")]
        public int IdRota { get; set; }

        /// <summary>
        /// Propriedade reponsável por apenas instanciar o objeto da rota associada a essa parada.
        /// </summary>
        [ForeignKey("IdRota")]
        public virtual Rota Rota { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar a chave extrangeira do ponto na tabela de parada.
        /// </summary>
        [Required]
        [Column("Ponto")]
        public int IdPonto { get; set; }

        /// <summary>
        /// Propriedade reponsável por apenas instanciar p objeto do ponto associado a esta parada.
        /// </summary>
        [ForeignKey("IdPonto")]
        public virtual Ponto Ponto { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar a ordem da parada no banco de dados.
        /// </summary>
        [Required]
        public int Ordem { get; set; }
    }
}
