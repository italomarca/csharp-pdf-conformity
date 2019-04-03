namespace mlegate
{
    partial class FrmConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCaminhoDepositos = new System.Windows.Forms.TextBox();
            this.txtCaminhoAdiantBanc = new System.Windows.Forms.TextBox();
            this.txtCaminhoExtratoBanc = new System.Windows.Forms.TextBox();
            this.txtCaminhoProtRec = new System.Windows.Forms.TextBox();
            this.txtCaminhoDacte = new System.Windows.Forms.TextBox();
            this.txtCaminhoDanfe = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.txtServidor = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(401, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 40);
            this.button1.TabIndex = 20;
            this.button1.Text = "Salvar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSenha);
            this.groupBox1.Controls.Add(this.txtUsuario);
            this.groupBox1.Controls.Add(this.txtBanco);
            this.groupBox1.Controls.Add(this.txtServidor);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 139);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuração de Banco de Dados";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCaminhoDepositos);
            this.groupBox2.Controls.Add(this.txtCaminhoAdiantBanc);
            this.groupBox2.Controls.Add(this.txtCaminhoExtratoBanc);
            this.groupBox2.Controls.Add(this.txtCaminhoProtRec);
            this.groupBox2.Controls.Add(this.txtCaminhoDacte);
            this.groupBox2.Controls.Add(this.txtCaminhoDanfe);
            this.groupBox2.Location = new System.Drawing.Point(12, 170);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 191);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Caminhos de Arquivos";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(63, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 13);
            this.label10.TabIndex = 31;
            this.label10.Text = "Depósitos:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(46, 131);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Adiant. Banc.:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(41, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Extratos Banc.:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(101, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Protocolos de Rec.:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "DACTEs";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "DANFEs";
            // 
            // txtCaminhoDepositos
            // 
            this.txtCaminhoDepositos.Location = new System.Drawing.Point(126, 154);
            this.txtCaminhoDepositos.Name = "txtCaminhoDepositos";
            this.txtCaminhoDepositos.Size = new System.Drawing.Size(316, 20);
            this.txtCaminhoDepositos.TabIndex = 25;
            // 
            // txtCaminhoAdiantBanc
            // 
            this.txtCaminhoAdiantBanc.Location = new System.Drawing.Point(126, 128);
            this.txtCaminhoAdiantBanc.Name = "txtCaminhoAdiantBanc";
            this.txtCaminhoAdiantBanc.Size = new System.Drawing.Size(316, 20);
            this.txtCaminhoAdiantBanc.TabIndex = 24;
            // 
            // txtCaminhoExtratoBanc
            // 
            this.txtCaminhoExtratoBanc.Location = new System.Drawing.Point(126, 102);
            this.txtCaminhoExtratoBanc.Name = "txtCaminhoExtratoBanc";
            this.txtCaminhoExtratoBanc.Size = new System.Drawing.Size(316, 20);
            this.txtCaminhoExtratoBanc.TabIndex = 23;
            // 
            // txtCaminhoProtRec
            // 
            this.txtCaminhoProtRec.Location = new System.Drawing.Point(126, 76);
            this.txtCaminhoProtRec.Name = "txtCaminhoProtRec";
            this.txtCaminhoProtRec.Size = new System.Drawing.Size(316, 20);
            this.txtCaminhoProtRec.TabIndex = 22;
            // 
            // txtCaminhoDacte
            // 
            this.txtCaminhoDacte.Location = new System.Drawing.Point(126, 50);
            this.txtCaminhoDacte.Name = "txtCaminhoDacte";
            this.txtCaminhoDacte.Size = new System.Drawing.Size(316, 20);
            this.txtCaminhoDacte.TabIndex = 21;
            // 
            // txtCaminhoDanfe
            // 
            this.txtCaminhoDanfe.Location = new System.Drawing.Point(126, 24);
            this.txtCaminhoDanfe.Name = "txtCaminhoDanfe";
            this.txtCaminhoDanfe.Size = new System.Drawing.Size(316, 20);
            this.txtCaminhoDanfe.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Senha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Usuário:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Base de Dados:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "Servidor:";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(126, 105);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(316, 20);
            this.txtSenha.TabIndex = 17;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(126, 79);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(316, 20);
            this.txtUsuario.TabIndex = 16;
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(126, 53);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(316, 20);
            this.txtBanco.TabIndex = 15;
            // 
            // txtServidor
            // 
            this.txtServidor.Location = new System.Drawing.Point(126, 27);
            this.txtServidor.Name = "txtServidor";
            this.txtServidor.Size = new System.Drawing.Size(316, 20);
            this.txtServidor.TabIndex = 14;
            // 
            // FrmConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 415);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "FrmConfig";
            this.Text = "Configurações";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.TextBox txtServidor;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCaminhoDepositos;
        private System.Windows.Forms.TextBox txtCaminhoAdiantBanc;
        private System.Windows.Forms.TextBox txtCaminhoExtratoBanc;
        private System.Windows.Forms.TextBox txtCaminhoProtRec;
        private System.Windows.Forms.TextBox txtCaminhoDacte;
        private System.Windows.Forms.TextBox txtCaminhoDanfe;
    }
}