using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GRY_Projekt
{
    public partial class Czolg : Form
    {
        bool wlewo;
        bool wprawo;
        public int predkosc = 5;
        int score = 0;
        bool czyStrzal;
        int sumaStworkow = 12;
        int graczPredkosc = 6;
        public Czolg()
        {
            InitializeComponent();
            string poczatek = "Żeby zacząć grę " + "\nNaciśniej ENTER";
            lblpoczatek.Text = poczatek;
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                timer1.Start();
                lblpoczatek.Visible = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                wlewo = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                wprawo = true;
            }
            if (e.KeyCode == Keys.Space && !czyStrzal)
            {
                czyStrzal = true;

                zrobStrzal();
            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                wlewo = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                wprawo = false;
            }
            if (czyStrzal)
            {
                czyStrzal = false;
            }
        }
        private void zrobStrzal()
        {
            PictureBox strzal = new PictureBox();
            strzal.Image = Properties.Resources.bullet;
            strzal.Size = new Size(5, 20);
            strzal.Tag = "strzaly";
            strzal.Left = gracz.Left + gracz.Width / 2;
            strzal.Top = gracz.Top - 20;
            this.Controls.Add(strzal);
            strzal.BringToFront();
        }
    }
}
