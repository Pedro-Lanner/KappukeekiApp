using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KappukeekiApp.Models {
    public class Cliente {
        [Key, ForeignKey("Pessoa")]
        public int IdCliente { get; set; }
        public Pessoa Pessoa { get; set; } = null!;
        public string? HistoricoCliente { get; set; }
        public string? InfoPagamento { get; set; }

    }
}
