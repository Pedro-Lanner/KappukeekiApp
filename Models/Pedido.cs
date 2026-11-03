using KappukeekiApp.Models;
using System;
using System.Collections.Generic;

namespace KappukeekiApp.Models {
    public class Pedido {
        public int Id { get; set; }
        public string NomeCliente { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public string Status { get; set; } = "Em Preparo";
        public string CodigoRetirada { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public List<ItemPedido> Itens { get; set; } = new();
    }
    public class ItemPedido {
        public int Id { get; set; }
        public int PedidoID { get; set; }
        public int CupcakeId { get; set; }
        public Cupcake? Cupcake { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUnitario { get; set; }
    }
}