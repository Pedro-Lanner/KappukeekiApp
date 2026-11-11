namespace KappukeekiApp {
    partial class CadastroClienteForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtIdade = new TextBox();
            txtSenha = new TextBox();
            txtConfirmarSenha = new TextBox();
            btnSalvarCliente = new Button();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 12);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome completo";
            txtNome.Size = new Size(282, 23);
            txtNome.TabIndex = 0;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(300, 12);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(282, 23);
            txtEmail.TabIndex = 1;
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(588, 12);
            txtIdade.Name = "txtIdade";
            txtIdade.PlaceholderText = "Idade";
            txtIdade.Size = new Size(43, 23);
            txtIdade.TabIndex = 2;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(12, 41);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.PlaceholderText = "Senha";
            txtSenha.Size = new Size(118, 23);
            txtSenha.TabIndex = 3;
            // 
            // txtConfirmarSenha
            // 
            txtConfirmarSenha.Location = new Point(12, 70);
            txtConfirmarSenha.Name = "txtConfirmarSenha";
            txtConfirmarSenha.PasswordChar = '*';
            txtConfirmarSenha.PlaceholderText = "Confirme a senha";
            txtConfirmarSenha.Size = new Size(118, 23);
            txtConfirmarSenha.TabIndex = 4;
            // 
            // btnSalvarCliente
            // 
            btnSalvarCliente.BackColor = Color.DarkBlue;
            btnSalvarCliente.ForeColor = Color.CornflowerBlue;
            btnSalvarCliente.Location = new Point(136, 69);
            btnSalvarCliente.Name = "btnSalvarCliente";
            btnSalvarCliente.Size = new Size(158, 23);
            btnSalvarCliente.TabIndex = 5;
            btnSalvarCliente.Text = "Salvar";
            btnSalvarCliente.UseVisualStyleBackColor = false;
            btnSalvarCliente.Click += btnSalvarCliente_Click;
            // 
            // CadastroClienteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(642, 109);
            Controls.Add(btnSalvarCliente);
            Controls.Add(txtConfirmarSenha);
            Controls.Add(txtSenha);
            Controls.Add(txtIdade);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Name = "CadastroClienteForm";
            Text = "CadastroClienteForm";
            Load += CadastroClienteForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtIdade;
        private TextBox txtSenha;
        private TextBox txtConfirmarSenha;
        private Button btnSalvarCliente;
    }
}