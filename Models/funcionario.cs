using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KappukeekiApp.Models {
    public class Funcionario {
        [Key, ForeignKey("Pessoa")]
        public int IdFunc { get; set; }
        public Pessoa Pessoa { get; set; } = null!;
        public DateTime DataContrato { get; set; } = DateTime.Now;
        public bool Demitido { get; set; } = false;

        public int? IdSetor { get; set; }
        [ForeignKey("IdSetor")]
        public Setor? Setor { get; set; }


    }
}
