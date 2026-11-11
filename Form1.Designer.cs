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
            btnExcluir = new Button();
            btnStatusPronto = new Button();
            btnStatusFinalizado = new Button();
            btnCadastrarOperador = new Button();
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
            dgvCupcakes.Size = new Size(786, 168);
            dgvCupcakes.TabIndex = 0;
            dgvCupcakes.CellContentClick += dgvCupcakes_CellContentClick;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(12, 12);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(177, 23);
            btnAdicionar.TabIndex = 1;
            btnAdicionar.Text = "Adicionar cupcake";
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
            txtNome.Location = new Point(530, 43);
            txtNome.Name = "txtNome";
            txtNome.PlaceholderText = "Nome do Cupcake";
            txtNome.Size = new Size(129, 23);
            txtNome.TabIndex = 4;
            // 
            // txtPreco
            // 
            txtPreco.Location = new Point(530, 14);
            txtPreco.Name = "txtPreco";
            txtPreco.PlaceholderText = "Preço";
            txtPreco.Size = new Size(129, 23);
            txtPreco.TabIndex = 5;
            // 
            // txtMassa
            // 
            txtMassa.Location = new Point(665, 14);
            txtMassa.Name = "txtMassa";
            txtMassa.PlaceholderText = "Sabor da massa";
            txtMassa.Size = new Size(129, 23);
            txtMassa.TabIndex = 6;
            txtMassa.TextChanged += txtMassa_TextChanged;
            // 
            // txtRecheio
            // 
            txtRecheio.Location = new Point(665, 43);
            txtRecheio.Name = "txtRecheio";
            txtRecheio.PlaceholderText = "Sabor do Recheio";
            txtRecheio.Size = new Size(129, 23);
            txtRecheio.TabIndex = 7;
            // 
            // txtCliente
            // 
            txtCliente.Location = new Point(195, 14);
            txtCliente.Name = "txtCliente";
            txtCliente.PlaceholderText = "Nome do cliente";
            txtCliente.Size = new Size(129, 23);
            txtCliente.TabIndex = 9;
            // 
            // numQuantidade
            // 
            numQuantidade.Location = new Point(195, 43);
            numQuantidade.Name = "numQuantidade";
            numQuantidade.Size = new Size(129, 23);
            numQuantidade.TabIndex = 10;
            // 
            // dgvPedidos
            // 
            dgvPedidos.BackgroundColor = Color.LightPink;
            dgvPedidos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPedidos.Location = new Point(12, 315);
            dgvPedidos.Name = "dgvPedidos";
            dgvPedidos.Size = new Size(786, 183);
            dgvPedidos.TabIndex = 11;
            // 
            // btnExcluir
            // 
            btnExcluir.Location = new Point(330, 14);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(75, 23);
            btnExcluir.TabIndex = 12;
            btnExcluir.Text = "Excluir";
            btnExcluir.UseVisualStyleBackColor = true;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnStatusPronto
            // 
            btnStatusPronto.Location = new Point(12, 286);
            btnStatusPronto.Name = "btnStatusPronto";
            btnStatusPronto.Size = new Size(120, 23);
            btnStatusPronto.TabIndex = 13;
            btnStatusPronto.Text = "Pronto para retirada";
            btnStatusPronto.UseVisualStyleBackColor = true;
            btnStatusPronto.Click += btnStatusPronto_Click;
            // 
            // btnStatusFinalizado
            // 
            btnStatusFinalizado.BackColor = Color.DarkSeaGreen;
            btnStatusFinalizado.Location = new Point(138, 286);
            btnStatusFinalizado.Name = "btnStatusFinalizado";
            btnStatusFinalizado.Size = new Size(120, 23);
            btnStatusFinalizado.TabIndex = 14;
            btnStatusFinalizado.Text = "Finalizar pedido";
            btnStatusFinalizado.UseVisualStyleBackColor = false;
            btnStatusFinalizado.Click += btnStatusFinalizado_Click;
            // 
            // btnCadastrarOperador
            // 
            btnCadastrarOperador.Location = new Point(665, 286);
            btnCadastrarOperador.Name = "btnCadastrarOperador";
            btnCadastrarOperador.Size = new Size(129, 23);
            btnCadastrarOperador.TabIndex = 15;
            btnCadastrarOperador.Text = "Cadastrar operador";
            btnCadastrarOperador.UseVisualStyleBackColor = true;
            btnCadastrarOperador.Visible = false;
            btnCadastrarOperador.Click += btnCadastrarOperador_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.CornflowerBlue;
            ClientSize = new Size(816, 508);
            Controls.Add(btnCadastrarOperador);
            Controls.Add(btnStatusFinalizado);
            Controls.Add(btnStatusPronto);
            Controls.Add(btnExcluir);
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
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kappukeeki App";
            Load += Form1_Load_1;
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
        private Button btnExcluir;
        private Button btnStatusPronto;
        private Button btnStatusFinalizado;
        private Button btnCadastrarOperador;
    }
}
