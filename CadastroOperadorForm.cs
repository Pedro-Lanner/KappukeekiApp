using KappukeekiApp.Data;
using KappukeekiApp.Models;
using KappukeekiApp.Services;
using System;
using System.Linq;
using System.Windows.Forms;
namespace KappukeekiApp {
    public partial class CadastroOperadorForm : Form {
        public CadastroOperadorForm() {
            InitializeComponent();
        }
        private void btnSalvarOperador_Click(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(txtNome.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtSenha.Text)) {
                MessageBox.Show("Preencha todos os campos obrigatórios.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int.TryParse(txtIdade.Text, out int idade);
            using var context = new AppDbContext();
            string emailFormatado = txtEmail.Text.Trim().ToLower();
            if (context.Pessoas.Any(p => p.EmailPessoa.ToLower() == emailFormatado)) {
                MessageBox.Show("Este e-mail já está em uso.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            var setorOperador = context.Setores.FirstOrDefault(s => s.NomeSetor == "Operação");
            if (setorOperador == null) {
                setorOperador = new Setor {
                    NomeSetor = "Operação",
                    NivelPermissao = 1
                };
                context.Setores.Add(setorOperador);
                context.SaveChanges();
            }
            
            var (hash, salt) = PasswordHelper.GerarHashESalt(txtSenha.Text);
            
            var novoOperador = new Pessoa {
                NomePessoa = txtNome.Text.Trim(),
                EmailPessoa = emailFormatado,
                IdadePessoa = idade,
                SenhaHash = hash,
                SenhaSalt = salt,
                Funcionario = new Funcionario {
                    IdSetor = setorOperador.IdSetor,
                    DataContrato = DateTime.Now,
                    Demitido = false
                }
            };
            context.Pessoas.Add(novoOperador);
            context.SaveChanges();
            MessageBox.Show($"Operador '{novoOperador.NomePessoa}' cadastrado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}