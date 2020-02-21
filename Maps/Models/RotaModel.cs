using System.Collections.Generic;

namespace Maps.Models
{
    /// <summary>
    /// Classe responsável por representar o objeto da rota que foi feita pelo usuário, no momento de salvar a mesma.
    /// </summary>
    public class RotaModel
    {
        /// <summary>
        /// Propriedade que representa a Origem da rota.
        /// </summary>
        public string Origem { get; set; }

        /// <summary>
        /// Propriedade que representa o Destino da rota.
        /// </summary>
        public string Destino { get; set; }

        /// <summary>
        /// Propriedade que representa todas as paradas adicionadas na rota.
        /// </summary>
        #nullable enable
        public List<string>? Paradas { get; set; }
        #nullable disable
    }
}
