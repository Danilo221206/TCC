using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void rjToggleButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (rjToggleButton1.Checked) label2.Text = "Competitivo";
            else label2.Text = "casual";
        }

        private void rjButton4_Click(object sender, EventArgs e)
        {
            MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Close();
        }

        private void BtnClassic_Click(object sender, EventArgs e)
        {
            ClassicMode jogo1 = new ClassicMode();
            jogo1.Show();
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e) //tutorial 
        {
            tutoriais tut = new tutoriais(1);
            tut.Show();   
        }

        private void rjButton2_Click(object sender, EventArgs e) //speedrun game
        {
            Form4 jogo2 = new Form4();
            jogo2.Show();
            this.Close();
        }
    }
}
