namespace KappukeekiApp {
    partial class CadastroOperadorForm {
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
            btnSalvarOperador = new Button();
            txtNome = new TextBox();
            txtEmail = new TextBox();
            txtIdade = new TextBox();
            txtSenha = new TextBox();
            SuspendLayout();
            // 
            // btnSalvarOperador
            // 
            btnSalvarOperador.Location = new Point(12, 128);
            btnSalvarOperador.Name = "btnSalvarOperador";
            btnSalvarOperador.Size = new Size(100, 23);
            btnSalvarOperador.TabIndex = 0;
            btnSalvarOperador.Text = "Salvar";
            btnSalvarOperador.UseVisualStyleBackColor = true;
            btnSalvarOperador.Click += btnSalvarOperador_Click;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 12);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome";
            txtNome.Size = new Size(220, 23);
            txtNome.TabIndex = 1;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 41);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "E-mail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 2;
            // 
            // txtIdade
            // 
            txtIdade.Location = new Point(12, 70);
            txtIdade.Name = "txtIdade";
            txtIdade.PlaceholderText = "Idade";
            txtIdade.Size = new Size(100, 23);
            txtIdade.TabIndex = 3;
            // 
            // txtSenha
            // 
            txtSenha.Location = new Point(12, 99);
            txtSenha.Name = "txtSenha";
            txtSenha.PasswordChar = '*';
            txtSenha.PlaceholderText = "Senha";
            txtSenha.Size = new Size(220, 23);
            txtSenha.TabIndex = 4;
            // 
            // CadastroOperadorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(248, 164);
            Controls.Add(txtSenha);
            Controls.Add(txtIdade);
            Controls.Add(txtEmail);
            Controls.Add(txtNome);
            Controls.Add(btnSalvarOperador);
            Name = "CadastroOperadorForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "CadastroOperadorForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSalvarOperador;
        private TextBox txtNome;
        private TextBox txtEmail;
        private TextBox txtIdade;
        private TextBox txtSenha;
    }
}