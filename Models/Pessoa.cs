using System.ComponentModel.DataAnnotations;

namespace KappukeekiApp.Models {
    public class Pessoa {
        [Key]
        public int IdPessoa { get; set; }

        [Required]
        public string NomePessoa { get; set; } = string.Empty;
        public int IdadePessoa { get; set; }

        [Required]
        public string EmailPessoa { get; set; } = string.Empty;

        [Required]
        public string SenhaHash { get; set; } = string.Empty;
        [Required]
        public string SenhaSalt { get; set; } = string.Empty;

        //herança
        public Funcionario? Funcionario { get; set; }
        public Cliente? Cliente { get; set; }


        
    }
}
