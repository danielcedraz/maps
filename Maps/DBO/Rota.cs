using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Maps.DBO
{
    /// <summary>
    /// Classe responsável por representar a tabela Rotas no banco de dados.
    /// </summary>
    [Table("Rotas")]
    public class Rota
    {
        /// <summary>
        /// Propriedade reponsável por armazenar a chave primária da rota no banco de dados.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar a chave extrangeira do ponto de origem na tabela de rota.
        /// </summary>
        [Required]
        [Column("Origem")]
        public int IdOrigem { get; set; }

        /// <summary>
        /// Propriedade reponsável por instanciar o objeto de Ponto representando a origem da rota.
        /// </summary>
        [ForeignKey("IdOrigem")]
        public virtual Ponto Origem { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar a chave extrangeira do ponto de destino na tabela de rota.
        /// </summary>
        [Required]
        [Column("Destino")]
        public int IdDestino { get; set; }

        /// <summary>
        /// Propriedade reponsável por instanciar o objeto de Ponto representando o destino da rota.
        /// </summary>
        [ForeignKey("IdDestino")]
        public virtual Ponto Destino { get; set; }
    }
}
