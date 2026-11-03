using System.ComponentModel.DataAnnotations;

namespace KappukeekiApp.Models {
    public class Setor {
        [Key]
        public int IdSetor { get; set; }
        [Required]
        public string NomeSetor { get; set; } = string.Empty;

        public int NivelPermissao { get; set; }

    }
}
