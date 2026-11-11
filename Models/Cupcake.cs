namespace KappukeekiApp.Models {
    public class Cupcake {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set;  }
        public string SaborMassa { get; set; } = string.Empty;
        public string SaborRecheio { get; set; } = string.Empty;
        public bool Disponivel { get; set; } = true;
    }
}