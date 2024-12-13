namespace TCC
{
    partial class MenuPrincipal
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rjButton5 = new TCC.RJButton();
            this.rjButton4 = new TCC.RJButton();
            this.BtnSts = new TCC.RJButton();
            this.BtnGM = new TCC.RJButton();
            this.BtnInv = new TCC.RJButton();
            this.roundPB1 = new TCC.RoundPB();
            ((System.ComponentModel.ISupportInitialize)(this.roundPB1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(154, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome do usuário";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(155, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "$ TOTAL";
            // 
            // rjButton5
            // 
            this.rjButton5.BackColor = System.Drawing.Color.SteelBlue;
            this.rjButton5.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.rjButton5.BorderColor = System.Drawing.Color.Pink;
            this.rjButton5.BorderRadius = 10;
            this.rjButton5.BorderSize = 3;
            this.rjButton5.FlatAppearance.BorderSize = 0;
            this.rjButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton5.ForeColor = System.Drawing.Color.White;
            this.rjButton5.Location = new System.Drawing.Point(180, 314);
            this.rjButton5.Name = "rjButton5";
            this.rjButton5.Size = new System.Drawing.Size(136, 40);
            this.rjButton5.TabIndex = 8;
            this.rjButton5.Text = "Loja";
            this.rjButton5.TextColor = System.Drawing.Color.White;
            this.rjButton5.UseVisualStyleBackColor = false;
            // 
            // rjButton4
            // 
            this.rjButton4.BackColor = System.Drawing.Color.SteelBlue;
            this.rjButton4.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.rjButton4.BorderColor = System.Drawing.Color.Pink;
            this.rjButton4.BorderRadius = 10;
            this.rjButton4.BorderSize = 3;
            this.rjButton4.FlatAppearance.BorderSize = 0;
            this.rjButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rjButton4.ForeColor = System.Drawing.Color.White;
            this.rjButton4.Location = new System.Drawing.Point(12, 314);
            this.rjButton4.Name = "rjButton4";
            this.rjButton4.Size = new System.Drawing.Size(136, 40);
            this.rjButton4.TabIndex = 7;
            this.rjButton4.Text = "Logout";
            this.rjButton4.TextColor = System.Drawing.Color.White;
            this.rjButton4.UseVisualStyleBackColor = false;
            this.rjButton4.Click += new System.EventHandler(this.rjButton4_Click);
            // 
            // BtnSts
            // 
            this.BtnSts.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSts.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BtnSts.BorderColor = System.Drawing.Color.LightPink;
            this.BtnSts.BorderRadius = 10;
            this.BtnSts.BorderSize = 3;
            this.BtnSts.FlatAppearance.BorderSize = 0;
            this.BtnSts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSts.ForeColor = System.Drawing.Color.White;
            this.BtnSts.Location = new System.Drawing.Point(12, 268);
            this.BtnSts.Name = "BtnSts";
            this.BtnSts.Size = new System.Drawing.Size(304, 40);
            this.BtnSts.TabIndex = 6;
            this.BtnSts.Text = "Estatísticas";
            this.BtnSts.TextColor = System.Drawing.Color.White;
            this.BtnSts.UseVisualStyleBackColor = false;
            // 
            // BtnGM
            // 
            this.BtnGM.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnGM.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BtnGM.BorderColor = System.Drawing.Color.LightPink;
            this.BtnGM.BorderRadius = 10;
            this.BtnGM.BorderSize = 3;
            this.BtnGM.FlatAppearance.BorderSize = 0;
            this.BtnGM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnGM.ForeColor = System.Drawing.Color.White;
            this.BtnGM.Location = new System.Drawing.Point(12, 222);
            this.BtnGM.Name = "BtnGM";
            this.BtnGM.Size = new System.Drawing.Size(304, 40);
            this.BtnGM.TabIndex = 5;
            this.BtnGM.Text = "Modos de Jogo";
            this.BtnGM.TextColor = System.Drawing.Color.White;
            this.BtnGM.UseVisualStyleBackColor = false;
            this.BtnGM.Click += new System.EventHandler(this.BtnGM_Click);
            // 
            // BtnInv
            // 
            this.BtnInv.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnInv.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.BtnInv.BorderColor = System.Drawing.Color.LightPink;
            this.BtnInv.BorderRadius = 10;
            this.BtnInv.BorderSize = 3;
            this.BtnInv.FlatAppearance.BorderSize = 0;
            this.BtnInv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnInv.ForeColor = System.Drawing.Color.White;
            this.BtnInv.Location = new System.Drawing.Point(12, 176);
            this.BtnInv.Name = "BtnInv";
            this.BtnInv.Size = new System.Drawing.Size(304, 40);
            this.BtnInv.TabIndex = 4;
            this.BtnInv.Text = "Inventário";
            this.BtnInv.TextColor = System.Drawing.Color.White;
            this.BtnInv.UseVisualStyleBackColor = false;
            // 
            // roundPB1
            // 
            this.roundPB1.Image = global::TCC.Properties.Resources.unknownperson;
            this.roundPB1.Location = new System.Drawing.Point(12, 12);
            this.roundPB1.Name = "roundPB1";
            this.roundPB1.Size = new System.Drawing.Size(120, 120);
            this.roundPB1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.roundPB1.TabIndex = 0;
            this.roundPB1.TabStop = false;
            this.roundPB1.Click += new System.EventHandler(this.roundPB1_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.ClientSize = new System.Drawing.Size(328, 377);
            this.Controls.Add(this.rjButton5);
            this.Controls.Add(this.rjButton4);
            this.Controls.Add(this.BtnSts);
            this.Controls.Add(this.BtnGM);
            this.Controls.Add(this.BtnInv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundPB1);
            this.Name = "MenuPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu Principal";
            this.Load += new System.EventHandler(this.MenuPrincipal_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.roundPB1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private RoundPB roundPB1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private RJButton BtnInv;
        private RJButton BtnGM;
        private RJButton BtnSts;
        private RJButton rjButton4;
        private RJButton rjButton5;
    }
}