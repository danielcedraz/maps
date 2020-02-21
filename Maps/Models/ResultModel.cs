namespace Maps.Models
{
    /// <summary>
    /// Classe utiizada para enviar um retorno em métodos de controllers.
    /// </summary>
    public class ResultModel
    {
        /// <summary>
        /// Propriedade reponsável por armazenar um boleano informando se é um erro.
        /// </summary>
        public bool Erro { get; set; }

        /// <summary>
        /// Propriedade reponsável por armazenar um texto para ser apresentado ao usuário.
        /// </summary>
        public string Mensagem { get; set; }
    }
}
