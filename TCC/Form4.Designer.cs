namespace TCC
{
    partial class Form4
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
            this.labeldin = new System.Windows.Forms.Label();
            this.Dinheiro = new System.Windows.Forms.NumericUpDown();
            this.Playerscore = new System.Windows.Forms.Label();
            this.Dealerscore = new System.Windows.Forms.Label();
            this.cartadealer2 = new System.Windows.Forms.PictureBox();
            this.cartadealer1 = new System.Windows.Forms.PictureBox();
            this.cartaplayer2 = new System.Windows.Forms.PictureBox();
            this.cartaplayer1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Aposta = new System.Windows.Forms.NumericUpDown();
            this.Betbtn = new TCC.RJButton();
            this.Doublebtn = new TCC.RJButton();
            this.Hitbtn = new TCC.RJButton();
            ((System.ComponentModel.ISupportInitialize)(this.Dinheiro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartadealer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartadealer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaplayer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaplayer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aposta)).BeginInit();
            this.SuspendLayout();
            // 
            // labeldin
            // 
            this.labeldin.AutoSize = true;
            this.labeldin.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labeldin.Location = new System.Drawing.Point(-3, -1);
            this.labeldin.Name = "labeldin";
            this.labeldin.Size = new System.Drawing.Size(131, 40);
            this.labeldin.TabIndex = 2;
            this.labeldin.Text = "Dinheiro:";
            // 
            // Dinheiro
            // 
            this.Dinheiro.Enabled = false;
            this.Dinheiro.Increment = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.Dinheiro.Location = new System.Drawing.Point(118, 13);
            this.Dinheiro.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.Dinheiro.Name = "Dinheiro";
            this.Dinheiro.ReadOnly = true;
            this.Dinheiro.Size = new System.Drawing.Size(120, 20);
            this.Dinheiro.TabIndex = 21;
            this.Dinheiro.ValueChanged += new System.EventHandler(this.Dinheiro_ValueChanged_1);
            // 
            // Playerscore
            // 
            this.Playerscore.AutoSize = true;
            this.Playerscore.Location = new System.Drawing.Point(271, 20);
            this.Playerscore.Name = "Playerscore";
            this.Playerscore.Size = new System.Drawing.Size(67, 13);
            this.Playerscore.TabIndex = 22;
            this.Playerscore.Text = "Player Score";
            // 
            // Dealerscore
            // 
            this.Dealerscore.AutoSize = true;
            this.Dealerscore.Location = new System.Drawing.Point(640, 20);
            this.Dealerscore.Name = "Dealerscore";
            this.Dealerscore.Size = new System.Drawing.Size(69, 13);
            this.Dealerscore.TabIndex = 23;
            this.Dealerscore.Text = "Dealer Score";
            // 
            // cartadealer2
            // 
            this.cartadealer2.Location = new System.Drawing.Point(590, 36);
            this.cartadealer2.Name = "cartadealer2";
            this.cartadealer2.Size = new System.Drawing.Size(317, 434);
            this.cartadealer2.TabIndex = 27;
            this.cartadealer2.TabStop = false;
            // 
            // cartadealer1
            // 
            this.cartadealer1.Location = new System.Drawing.Point(525, 36);
            this.cartadealer1.Name = "cartadealer1";
            this.cartadealer1.Size = new System.Drawing.Size(317, 434);
            this.cartadealer1.TabIndex = 26;
            this.cartadealer1.TabStop = false;
            // 
            // cartaplayer2
            // 
            this.cartaplayer2.Location = new System.Drawing.Point(202, 36);
            this.cartaplayer2.Name = "cartaplayer2";
            this.cartaplayer2.Size = new System.Drawing.Size(317, 434);
            this.cartaplayer2.TabIndex = 25;
            this.cartaplayer2.TabStop = false;
            // 
            // cartaplayer1
            // 
            this.cartaplayer1.Location = new System.Drawing.Point(134, 36);
            this.cartaplayer1.Name = "cartaplayer1";
            this.cartaplayer1.Size = new System.Drawing.Size(317, 434);
            this.cartaplayer1.TabIndex = 24;
            this.cartaplayer1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-2, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "Insira quanto quer apostar";
            // 
            // Aposta
            // 
            this.Aposta.Location = new System.Drawing.Point(12, 224);
            this.Aposta.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.Aposta.Name = "Aposta";
            this.Aposta.Size = new System.Drawing.Size(99, 20);
            this.Aposta.TabIndex = 31;
            // 
            // Betbtn
            // 
            this.Betbtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Betbtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Betbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Betbtn.BorderRadius = 10;
            this.Betbtn.BorderSize = 0;
            this.Betbtn.FlatAppearance.BorderSize = 0;
            this.Betbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Betbtn.ForeColor = System.Drawing.Color.White;
            this.Betbtn.Location = new System.Drawing.Point(12, 250);
            this.Betbtn.Name = "Betbtn";
            this.Betbtn.Size = new System.Drawing.Size(100, 21);
            this.Betbtn.TabIndex = 30;
            this.Betbtn.Text = "Começar";
            this.Betbtn.TextColor = System.Drawing.Color.White;
            this.Betbtn.UseVisualStyleBackColor = false;
            this.Betbtn.Click += new System.EventHandler(this.Betbtn_Click);
            // 
            // Doublebtn
            // 
            this.Doublebtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Doublebtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Doublebtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Doublebtn.BorderRadius = 10;
            this.Doublebtn.BorderSize = 0;
            this.Doublebtn.FlatAppearance.BorderSize = 0;
            this.Doublebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Doublebtn.ForeColor = System.Drawing.Color.White;
            this.Doublebtn.Location = new System.Drawing.Point(4, 137);
            this.Doublebtn.Name = "Doublebtn";
            this.Doublebtn.Size = new System.Drawing.Size(100, 21);
            this.Doublebtn.TabIndex = 29;
            this.Doublebtn.Text = "Double";
            this.Doublebtn.TextColor = System.Drawing.Color.White;
            this.Doublebtn.UseVisualStyleBackColor = false;
            this.Doublebtn.Click += new System.EventHandler(this.Doublebtn_Click_1);
            // 
            // Hitbtn
            // 
            this.Hitbtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Hitbtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Hitbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Hitbtn.BorderRadius = 10;
            this.Hitbtn.BorderSize = 0;
            this.Hitbtn.FlatAppearance.BorderSize = 0;
            this.Hitbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Hitbtn.ForeColor = System.Drawing.Color.White;
            this.Hitbtn.Location = new System.Drawing.Point(4, 110);
            this.Hitbtn.Name = "Hitbtn";
            this.Hitbtn.Size = new System.Drawing.Size(100, 21);
            this.Hitbtn.TabIndex = 28;
            this.Hitbtn.Text = "Hit";
            this.Hitbtn.TextColor = System.Drawing.Color.White;
            this.Hitbtn.UseVisualStyleBackColor = false;
            this.Hitbtn.Click += new System.EventHandler(this.Hitbtn_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 482);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Aposta);
            this.Controls.Add(this.Betbtn);
            this.Controls.Add(this.Doublebtn);
            this.Controls.Add(this.Hitbtn);
            this.Controls.Add(this.cartadealer2);
            this.Controls.Add(this.cartadealer1);
            this.Controls.Add(this.cartaplayer2);
            this.Controls.Add(this.cartaplayer1);
            this.Controls.Add(this.Dealerscore);
            this.Controls.Add(this.Playerscore);
            this.Controls.Add(this.Dinheiro);
            this.Controls.Add(this.labeldin);
            this.Name = "Form4";
            this.Text = "Speedrun";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Dinheiro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartadealer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartadealer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaplayer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cartaplayer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Aposta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labeldin;
        private System.Windows.Forms.NumericUpDown Dinheiro;
        private System.Windows.Forms.Label Playerscore;
        private System.Windows.Forms.Label Dealerscore;
        private System.Windows.Forms.PictureBox cartaplayer2;
        private System.Windows.Forms.PictureBox cartaplayer1;
        private System.Windows.Forms.PictureBox cartadealer2;
        private System.Windows.Forms.PictureBox cartadealer1;
        private RJButton Doublebtn;
        private RJButton Hitbtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown Aposta;
        private RJButton Betbtn;
    }
}