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
        }

        private void keydown(object sender, KeyEventArgs e)
        {

        }

        private void keyup(object sender, KeyEventArgs e)
        {

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
