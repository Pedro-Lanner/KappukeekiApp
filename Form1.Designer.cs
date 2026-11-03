namespace KappukeekiApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            dgvCupcakes = new DataGridView();
            btnAdicionar = new Button();
            btnCriarPedido = new Button();
            lblStatus = new Label();
            txtNome = new TextBox();
            txtPreco = new TextBox();
            txtMassa = new TextBox();
            txtRecheio = new TextBox();
            txtCliente = new TextBox();
            numQuantidade = new NumericUpDown();
            dgvPedidos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCupcakes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).BeginInit();
            SuspendLayout();
            // 
            // dgvCupcakes
            // 
            dgvCupcakes.BackgroundColor = Color.LightPink;
            dgvCupcakes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCupcakes.Location = new Point(12, 80);
            dgvCupcakes.Name = "dgvCupcakes";
            dgvCupcakes.Size = new Size(882, 323);
            dgvCupcakes.TabIndex = 0;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 12);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(177, 23);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar Cupcake Teste";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // btnCriarPedido
            // 
            btnCriarPedido.Location = new Point(12, 41);
            btnCriarPedido.Name = "btnCriarPedido";
            btnCriarPedido.Size = new Size(177, 23);
            btnCriarPedido.TabIndex = 2;
            btnCriarPedido.Text = "Criar Pedido Retirada";
            btnCriarPedido.UseVisualStyleBackColor = true;
            btnCriarPedido.Click += btnCriarPedido_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(377, 297);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(0, 15);
            lblStatus.TabIndex = 3;
            // 
            // txtNome
            // 
            txtNome.Location = new Point(688, 40);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(100, 23);
            txtNome.TabIndex = 4;
            txtNome.Text = "Nome";
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(688, 12);
            txtPreco.Name = "txtPreco";
            txtPreco.Size = new Size(100, 23);
            txtPreco.TabIndex = 5;
            txtPreco.Text = "Preço";
            // 
            // txtMassa
            // 
            txtMassa.Location = new Point(794, 13);
            txtMassa.Name = "txtMassa";
            txtMassa.Size = new Size(100, 23);
            txtMassa.TabIndex = 6;
            txtMassa.Text = "Massa";
            // 
            // txtRecheio
            // 
            txtRecheio.Location = new Point(794, 40);
            txtRecheio.Name = "txtRecheio";
            txtRecheio.Size = new Size(100, 23);
            txtRecheio.TabIndex = 7;
            txtRecheio.Text = "Recheio";
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(476, 12);
            txtCliente.Name = "txtCliente";
            txtCliente.Size = new Size(100, 23);
            txtCliente.TabIndex = 9;
            txtCliente.Text = "Nome cliente";
            // 
            // numQuantidade
            // 
            numQuantidade.Location = new Point(476, 41);
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(100, 23);
            numQuantidade.TabIndex = 10;
            // 
            // dgvPedidos
            // 
            dgvPedidos.BackgroundColor = Color.LightPink;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(12, 418);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Size = new Size(882, 314);
            dgvPedidos.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(905, 749);
            Controls.Add(dgvPedidos);
            Controls.Add(numQuantidade);
            Controls.Add(txtCliente);
            Controls.Add(txtRecheio);
            Controls.Add(txtMassa);
            Controls.Add(txtPreco);
            Controls.Add(txtNome);
            Controls.Add(lblStatus);
            Controls.Add(btnCriarPedido);
            Controls.Add(btnAdicionar);
            Controls.Add(dgvCupcakes);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvCupcakes).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantidade).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPedidos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvCupcakes;
        private Button btnAdicionar;
        private Button btnCriarPedido;
        private Label lblStatus;
        private TextBox txtNome;
        private TextBox txtPreco;
        private TextBox txtMassa;
        private TextBox txtRecheio;
        private TextBox txtCliente;
        private NumericUpDown numQuantidade;
        private DataGridView dgvPedidos;
    }
}
