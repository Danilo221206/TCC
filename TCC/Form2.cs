﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TCC.Form1;

namespace TCC
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();

        }
        private void rjButton4_Click(object sender, EventArgs e)
        {
            Form1 login= new Form1();
            login.Show();
            this.Close();
            
        }

        private void BtnGM_Click(object sender, EventArgs e)
        {
            Form3 Gm = new Form3();
            Gm.Show();
            this.Close();
        }

        private void MenuPrincipal_Load_1(object sender, EventArgs e)
        {
            label1.Text = $"Bem-vindo, {UsuarioAtual.NomeUsuario}!";
            label2.Text = $"Dinheiro: R$ {UsuarioAtual.DinheiroUsuario}";
            if(UsuarioAtual.Admin == 1)
            {
                admbutton.Enabled = true;
                admbutton.Visible = true;
            }
            else
            {
                admbutton.Enabled = false;
                admbutton.Visible = false;
            }

        }

        private void roundPB1_Click(object sender, EventArgs e)
        {

        }

        private void admbutton_Click(object sender, EventArgs e)
        {
            Admconfig admconfig = new Admconfig();
            admconfig.Show();
            this.Close();
        }
    }
}
