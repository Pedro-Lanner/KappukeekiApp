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



        private void btnAdicionar_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtNome.Text)) {
                MessageBox.Show("Informe o nome do cupcake.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return;
            }
            // Normaliza vírgula para ponto e converte (sugestão)
            string textoPreco = txtPreco.Text.Trim().Replace(',', '.');
            if (!decimal.TryParse(textoPreco, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal preco)) {
                MessageBox.Show("Informe um valor numérico válido para o preço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
                return;
            }
            // VALIDAÇÃO DO PREÇO POSITIVO (sugestão)
            if (preco <= 0) {
                MessageBox.Show("O preço do cupcake deve ser maior que R$ 0,00.", "Preço Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPreco.Focus();
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
            txtNome.Clear();
            txtMassa.Clear();
            txtRecheio.Clear();

            AtualizarTabelas();
            MessageBox.Show("Novo cupcake cadastrado com sucesso!");
        }

        private void btnCriarPedido_Click(object sender, EventArgs e) {

            if (dgvCupcakes.CurrentRow?.DataBoundItem is not Cupcake cupcakeSelecionado) {
                MessageBox.Show("Selecione um cupcake na lista para realizar o pedido.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quantidade = (int)numQuantidade.Value;
            if (quantidade <= 0) quantidade = 1;

            string cliente = string.IsNullOrWhiteSpace(txtCliente.Text) ? "Cliente Balcão" : txtCliente.Text.Trim();
            string codigo = "RET-" + Random.Shared.Next(1000, 9999);
            decimal subtotal = cupcakeSelecionado.Preco * quantidade;


            var pedido = new Pedido {
                NomeCliente = cliente,
                CodigoRetirada = codigo,
                Status = "Em Preparo",
                DataCriacao = DateTime.Now,
                Total = subtotal
            };

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

  

        private void txtMassa_TextChanged(object sender, EventArgs e) {

        }

        private void dgvCupcakes_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void Form1_Load_1(object sender, EventArgs e) {
            // 1. Configura as tabelas para selecionar a linha inteira ao clicar
            dgvCupcakes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCupcakes.MultiSelect = false;
            dgvPedidos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPedidos.MultiSelect = false;
            // 2. Atualiza o título da janela com o usuário e setor
            this.Text = $"Kappukeeki App - Conectado como: {SessaoUsuario.UsuarioAtual?.NomePessoa} ({SessaoUsuario.NomeSetor})";
            // 3. Permissão de Cupcakes (Nível < 2 não pode cadastrar nem excluir cupcakes)
            if (!SessaoUsuario.TemPermissaoMinima(2)) {
                btnAdicionar.Enabled = false;
                btnExcluir.Enabled = false;
                txtNome.Enabled = false;
                txtPreco.Enabled = false;
                txtMassa.Enabled = false;
                txtRecheio.Enabled = false;
            }
            // 4. 🔒 REGRA RBAC: O botão de operador só aparece se for Administrador (Nível >= 3)
            btnCadastrarOperador.Visible = SessaoUsuario.TemPermissaoMinima(3);
        }

        private void btnExcluir_Click(object sender, EventArgs e) {
            if (dgvCupcakes.CurrentRow?.DataBoundItem is not Cupcake cupcakeSelecionado) {
                MessageBox.Show("Selecione um cupcake na lista para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirmacao = MessageBox.Show(
                $"Deseja realmente excluir o cupcake '{cupcakeSelecionado.Nome}'?",
                "Confirmar Exclusão",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirmacao != DialogResult.Yes) return;
            var cupcake = _context.Cupcakes.Find(cupcakeSelecionado.Id);
            if (cupcake == null) return;
            // Verifica se há histórico de vendas
            bool temPedidos = _context.ItensPedido.Any(i => i.CupcakeId == cupcake.Id);
            if (temPedidos) {
                // Soft delete de proteção
                cupcake.Disponivel = false;
                _context.SaveChanges();
                AtualizarTabelas();
                MessageBox.Show(
                    $"O cupcake '{cupcake.Nome}' já possui pedidos registrados e não pode ser apagado fisicamente.\n\n" +
                    "Em vez disso, ele foi marcado como DESATIVADO (fora de linha).",
                    "Aviso de Integridade",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            else {
                // Exclusão física liberada
                _context.Cupcakes.Remove(cupcake);
                _context.SaveChanges();
                AtualizarTabelas();
                MessageBox.Show($"Cupcake '{cupcake.Nome}' excluído com sucesso!", "Excluído", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }




        // Método auxiliar que altera o status de qualquer pedido selecionado
        private void AlterarStatusPedidoSelecionado(string novoStatus) {
            if (dgvPedidos.CurrentRow == null) {
                MessageBox.Show("Selecione um pedido na tabela abaixo para alterar o status.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Pega o valor da coluna "Id" da linha atualmente selecionada no DataGridView
            int pedidoId = Convert.ToInt32(dgvPedidos.CurrentRow.Cells["Id"].Value);

            var pedido = _context.Pedidos.Find(pedidoId);
            if (pedido == null) {
                MessageBox.Show("Pedido não encontrado no banco de dados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Altera o status e salva no banco SQLite
            pedido.Status = novoStatus;
            _context.SaveChanges();
            // Atualiza a tabela na tela para mostrar o novo status
            AtualizarTabelas();
            MessageBox.Show(
                $"Status do pedido {pedido.CodigoRetirada} alterado para '{novoStatus}' com sucesso!",
                "Status Atualizado",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        // Evento do botão "Pronto para Retirada"
        private void btnStatusPronto_Click(object sender, EventArgs e) {
            AlterarStatusPedidoSelecionado("Pronto para Retirada");
        }
        // Evento do botão "Finalizar Pedido"
        private void btnStatusFinalizado_Click(object sender, EventArgs e) {
            AlterarStatusPedidoSelecionado("Finalizado");
        }

        private void btnCadastrarOperador_Click(object sender, EventArgs e) {
            using var telaCadastro = new CadastroOperadorForm();
            telaCadastro.ShowDialog();
        }
    }
}

