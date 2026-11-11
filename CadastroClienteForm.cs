using KappukeekiApp.Data;
using KappukeekiApp.Models;
using KappukeekiApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;
namespace KappukeekiApp {
    public partial class CadastroClienteForm : Form {
        public CadastroClienteForm() {
            InitializeComponent();
        }
        private void CadastroClienteForm_Load(object sender, EventArgs e) {
        }
        private void btnSalvarCliente_Click(object sender, EventArgs e) {
            // 1. Validações básicas de preenchimento
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text)) {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtSenha.Text != txtConfirmarSenha.Text) {
                MessageBox.Show("As senhas não coincidem.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int.TryParse(txtIdade.Text, out int idade);
            using var context = new AppDbContext();
            // 2. Garante que não haja dois usuários com o mesmo e-mail
            string emailFormatado = txtEmail.Text.Trim().ToLower();
            if (context.Pessoas.Any(p => p.EmailPessoa.ToLower() == emailFormatado)) {
                MessageBox.Show("Este e-mail já está cadastrado no sistema.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // 3. Criptografa a senha com Hash e Salt (PBKDF2)
            var (hash, salt) = PasswordHelper.GerarHashESalt(txtSenha.Text);
            // 4. Cria a Pessoa vinculada como Cliente
            var novoCliente = new Pessoa {
                NomePessoa = txtNome.Text.Trim(),
                EmailPessoa = emailFormatado,
                IdadePessoa = idade,
                SenhaHash = hash,
                SenhaSalt = salt,
                Cliente = new Cliente() // Define que essa pessoa é um Cliente!
            };
            context.Pessoas.Add(novoCliente);
            context.SaveChanges();
            MessageBox.Show("Conta de cliente criada com sucesso! Você já pode fazer login.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}