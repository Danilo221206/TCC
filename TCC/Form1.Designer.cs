namespace TCC
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNomeUsuario = new System.Windows.Forms.TextBox();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.ToggleCL = new CustomControls.RJControls.RJToggleButton();
            this.btnConfirmar_Click = new TCC.RJButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Noto Naskh Arabic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(-1, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Selecione um método:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("ROG Fonts v1.6", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(-3, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(288, 34);
            this.label2.TabIndex = 4;
            this.label2.Text = "BlackJack Modified";
            // 
            // txtNomeUsuario
            // 
            this.txtNomeUsuario.Location = new System.Drawing.Point(94, 78);
            this.txtNomeUsuario.Name = "txtNomeUsuario";
            this.txtNomeUsuario.Size = new System.Drawing.Size(164, 20);
            this.txtNomeUsuario.TabIndex = 7;
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(94, 109);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.Size = new System.Drawing.Size(164, 20);
            this.txtSenha.TabIndex = 8;
            // 
            // ToggleCL
            // 
            this.ToggleCL.AutoSize = true;
            this.ToggleCL.Checked = true;
            this.ToggleCL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleCL.Location = new System.Drawing.Point(122, 50);
            this.ToggleCL.MinimumSize = new System.Drawing.Size(45, 22);
            this.ToggleCL.Name = "ToggleCL";
            this.ToggleCL.OffBackColor = System.Drawing.Color.Sienna;
            this.ToggleCL.OffToggleColor = System.Drawing.Color.Yellow;
            this.ToggleCL.OnBackColor = System.Drawing.Color.MediumSlateBlue;
            this.ToggleCL.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.ToggleCL.Size = new System.Drawing.Size(45, 22);
            this.ToggleCL.TabIndex = 9;
            this.ToggleCL.UseVisualStyleBackColor = true;
            this.ToggleCL.CheckedChanged += new System.EventHandler(this.ToggleCL_CheckedChanged);
            // 
            // btnConfirmar_Click
            // 
            this.btnConfirmar_Click.BackColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar_Click.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btnConfirmar_Click.BorderColor = System.Drawing.Color.Pink;
            this.btnConfirmar_Click.BorderRadius = 10;
            this.btnConfirmar_Click.BorderSize = 3;
            this.btnConfirmar_Click.FlatAppearance.BorderSize = 0;
            this.btnConfirmar_Click.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar_Click.ForeColor = System.Drawing.Color.White;
            this.btnConfirmar_Click.Location = new System.Drawing.Point(108, 135);
            this.btnConfirmar_Click.Name = "btnConfirmar_Click";
            this.btnConfirmar_Click.Size = new System.Drawing.Size(136, 40);
            this.btnConfirmar_Click.TabIndex = 11;
            this.btnConfirmar_Click.Text = "Confirmar";
            this.btnConfirmar_Click.TextColor = System.Drawing.Color.White;
            this.btnConfirmar_Click.UseVisualStyleBackColor = false;
            this.btnConfirmar_Click.Click += new System.EventHandler(this.btnConfirmar_Click_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Noto Naskh Arabic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(173, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 32);
            this.label5.TabIndex = 12;
            this.label5.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Noto Naskh Arabic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 31);
            this.label3.TabIndex = 13;
            this.label3.Text = "Nome:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Noto Naskh Arabic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 31);
            this.label4.TabIndex = 14;
            this.label4.Text = "Senha:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(281, 178);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnConfirmar_Click);
            this.Controls.Add(this.ToggleCL);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.txtNomeUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNomeUsuario;
        private System.Windows.Forms.TextBox txtSenha;
        private CustomControls.RJControls.RJToggleButton ToggleCL;
        private RJButton btnConfirmar_Click;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

