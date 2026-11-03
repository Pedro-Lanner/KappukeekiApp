using KappukeekiApp.Data;
using KappukeekiApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Text;
using System.Windows.Forms;

namespace KappukeekiApp {
    public partial class LoginForm : Form {
        public LoginForm() {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e) {
            using var context = new AppDbContext();
            var authService = new AuthService(context);
            var (sucesso, mensagem) = authService.Login(txtEmail.Text, txtSenha.Text);

            if (sucesso) {
                MessageBox.Show($"Ben-vindo,{SessaoUsuario.UsuarioAtual?.NomePessoa}!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
            else {
                MessageBox.Show(mensagem, "Erro no Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }
    }
}
