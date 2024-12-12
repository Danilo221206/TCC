namespace TCC
{
    partial class tutoriais
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(tutoriais));
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.Classicbtn = new TCC.RJButton();
            this.Speedrunbtn = new TCC.RJButton();
            this.Extendedbtn = new TCC.RJButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("ROG Fonts v1.6", 21.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(112, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 58);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(312, 171);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // Classicbtn
            // 
            this.Classicbtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Classicbtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Classicbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Classicbtn.BorderRadius = 10;
            this.Classicbtn.BorderSize = 0;
            this.Classicbtn.FlatAppearance.BorderSize = 0;
            this.Classicbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Classicbtn.ForeColor = System.Drawing.Color.White;
            this.Classicbtn.Location = new System.Drawing.Point(12, 235);
            this.Classicbtn.Name = "Classicbtn";
            this.Classicbtn.Size = new System.Drawing.Size(100, 21);
            this.Classicbtn.TabIndex = 3;
            this.Classicbtn.Text = "Classic";
            this.Classicbtn.TextColor = System.Drawing.Color.White;
            this.Classicbtn.UseVisualStyleBackColor = false;
            this.Classicbtn.Click += new System.EventHandler(this.Classicbtn_Click);
            // 
            // Speedrunbtn
            // 
            this.Speedrunbtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Speedrunbtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Speedrunbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Speedrunbtn.BorderRadius = 10;
            this.Speedrunbtn.BorderSize = 0;
            this.Speedrunbtn.FlatAppearance.BorderSize = 0;
            this.Speedrunbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Speedrunbtn.ForeColor = System.Drawing.Color.White;
            this.Speedrunbtn.Location = new System.Drawing.Point(118, 235);
            this.Speedrunbtn.Name = "Speedrunbtn";
            this.Speedrunbtn.Size = new System.Drawing.Size(100, 21);
            this.Speedrunbtn.TabIndex = 4;
            this.Speedrunbtn.Text = "Speedrun";
            this.Speedrunbtn.TextColor = System.Drawing.Color.White;
            this.Speedrunbtn.UseVisualStyleBackColor = false;
            this.Speedrunbtn.Click += new System.EventHandler(this.Speedrunbtn_Click);
            // 
            // Extendedbtn
            // 
            this.Extendedbtn.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.Extendedbtn.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.Extendedbtn.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.Extendedbtn.BorderRadius = 10;
            this.Extendedbtn.BorderSize = 0;
            this.Extendedbtn.FlatAppearance.BorderSize = 0;
            this.Extendedbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Extendedbtn.ForeColor = System.Drawing.Color.White;
            this.Extendedbtn.Location = new System.Drawing.Point(224, 235);
            this.Extendedbtn.Name = "Extendedbtn";
            this.Extendedbtn.Size = new System.Drawing.Size(100, 21);
            this.Extendedbtn.TabIndex = 5;
            this.Extendedbtn.Text = "Speedrun";
            this.Extendedbtn.TextColor = System.Drawing.Color.White;
            this.Extendedbtn.UseVisualStyleBackColor = false;
            // 
            // tutoriais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 266);
            this.Controls.Add(this.Extendedbtn);
            this.Controls.Add(this.Speedrunbtn);
            this.Controls.Add(this.Classicbtn);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Name = "tutoriais";
            this.Text = "tutorial";
            this.Load += new System.EventHandler(this.tutoriais_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private RJButton Classicbtn;
        private RJButton Speedrunbtn;
        private RJButton Extendedbtn;
    }
}