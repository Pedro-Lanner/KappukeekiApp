using KappukeekiApp.Data;
using KappukeekiApp.Models;
using KappukeekiApp.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Windows.Forms;

namespace KappukeekiApp {
    public partial class Form1 : Form {
        private readonly AppDbContext _context = new();

        public Form1() {
            InitializeComponent();
            _context.Database.EnsureCreated();
            AtualizarTabelas();
        }

        private void AtualizarTabelas() {
            dgvCupcakes.DataSource = _context.Cupcakes.AsNoTracking().ToList();
            dgvPedidos.DataSource = _context.Pedidos.AsNoTracking().Include(p => p.Itens).ThenInclude(i => i.Cupcake).Select(p => new {
                p.Id,
                p.CodigoRetirada,
                p.NomeCliente,
                p.Status,
                p.Total,
                p.DataCriacao,
                Itens = string.Join(", ", p.Itens.Select(i => $"{i.Quantidade}x {(i.Cupcake != null ? i.Cupcake.Nome : "Cupcake")}")),

            }).OrderByDescending(p => p.DataCriacao).ToList();
        }

       /* private void btnAdicionar_Click(object sender, EventArgs e) {
            var novo = new Cupcake {
                Nome = "Cupcake Red Velvet",
                Preco = 12.50m,
                SaborMassa = "Baunilha Vermelha",
                SaborRecheio = "Cream Cheese"
            };

            _context.Cupcakes.Add(novo);
            _context.SaveChanges();
            AtualizarTabelas();
            lblStatus.Text = "Cupcake cadastrado no SQLite!";
        }*/
       private void btnAdicionar_Click(object sender, EventArgs e) {
            MessageBox.Show("Clicou!");
            if (string.IsNullOrWhiteSpace(txtNome.Text) || !decimal.TryParse(txtPreco.Text, out decimal preco)) {
                MessageBox.Show("Informe um nome válido e um preço numérico.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                
            }
            var novoCupcake = new Cupcake {
                Nome = txtNome.Text.Trim(),
                Preco = preco,
                SaborMassa = txtMassa.Text.Trim(),
                SaborRecheio = txtRecheio.Text.Trim(),
                Disponivel = true
            };

            _context.Cupcakes.Add(novoCupcake);
            _context.SaveChanges();

            txtNome.Clear();
            txtPreco.Clear();
            txtMassa.Clear();
            txtRecheio.Clear();

            AtualizarTabelas();
            MessageBox.Show("Novo cupcake cadastrado com sucesso!");
        }

        private void btnCriarPedido_Click(object sender, EventArgs e) {
            /*     var cupcake = _context.Cupcakes.FirstOrDefault();
                 if (cupcake == null) {
                     MessageBox.Show("Cadastre ao menos um cupcake primeiro.");
                     return;
                 }

                 var pedido = new Pedido {
                     NomeCliente = "Cliente Balcao",
                     CodigoRetirada = "RET-" + new Random().Next(1000, 9999),
                     Total = cupcake.Preco
                 };

                 pedido.Itens.Add(new ItemPedido {
                     CupcakeId = cupcake.Id,
                     Quantidade = 1,
                     PrecoUnitario = cupcake.Preco
                 });

                 _context.Pedidos.Add(pedido);
                 _context.SaveChanges();

                 lblStatus.Text = $"Pedido {pedido.Id} criado! Código para balcão: {pedido.CodigoRetirada}";
                 */
            if (dgvCupcakes.CurrentRow?.DataBoundItem is not Cupcake cupcakeSelecionado) {
                MessageBox.Show("Selecione um cupcake na lista para realizar o pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidade = (int)numQuantidade.Value;
            if (quantidade <= 0) quantidade = 1;

            string cliente = string.IsNullOrWhiteSpace(txtCliente.Text) ? "Cliente Balcão" : txtCliente.Text.Trim();
            string codigo = "RET-" + Random.Shared.Next(1000, 9999);
            decimal subtotal = cupcakeSelecionado.Preco * quantidade;

            // Cria a entidade Pedido
            var pedido = new Pedido {
                NomeCliente = cliente,
                CodigoRetirada = codigo,
                Status = "Em Preparo",
                DataCriacao = DateTime.Now,
                Total = subtotal
            };

            // Cria o ItemPedido vinculado ao Pedido e ao Cupcake
            var item = new ItemPedido {
                CupcakeId = cupcakeSelecionado.Id,
                Quantidade = quantidade,
                PrecoUnitario = cupcakeSelecionado.Preco
            };

            pedido.Itens.Add(item);

            _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            txtCliente.Clear();
            numQuantidade.Value = 1;

            AtualizarTabelas();

            MessageBox.Show(
                $"Pedido {codigo} criado com sucesso!\n\n" +
                $"Item: {quantidade}x {cupcakeSelecionado.Nome}\n" +
                $"Total: {subtotal:C2}\n" +
                $"Status: {pedido.Status}",
                "Pedido Realizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.Text = $"Kappukeeki App - Conectado como: {SessaoUsuario.UsuarioAtual?.NomePessoa} ({SessaoUsuario.NomeSetor})";
            if (!SessaoUsuario.TemPermissaoMinima(2)) {
                btnAdicionar.Enabled = false;
                txtNome.Enabled = false;
                txtNome.Enabled = false;
                txtMassa.Enabled = false;
                txtRecheio.Enabled = false;
            }
        }
    }
}