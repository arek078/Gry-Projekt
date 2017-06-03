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
        private void KoniecGry()
        {
            timer1.Stop();
            label1.Text += "Koniec gry";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (wlewo)
            {
                gracz.Left -= graczPredkosc;
            }
            else if (wprawo)
            {
                gracz.Left += graczPredkosc;
            }

            foreach (Control x in this.Controls)
            {

                if (x is PictureBox && x.Tag == "stworek")
                {
                    if (((PictureBox)x).Bounds.IntersectsWith(gracz.Bounds))
                    {
                        KoniecGry();
                    }
                    ((PictureBox)x).Left += predkosc;
                    if (((PictureBox)x).Left > 720)
                    {
                        ((PictureBox)x).Top += ((PictureBox)x).Height + 10;
                        ((PictureBox)x).Left = -50;
                    }
                }
            }
            foreach (Control y in this.Controls)
            {
                if (y is PictureBox && y.Tag == "strzaly")
                {
                    y.Top -= 20;
                    if (((PictureBox)y).Top < this.Height - 490)
                    {
                        this.Controls.Remove(y);
                    }
                }
            }

            foreach (Control i in this.Controls)
            {
                foreach (Control j in this.Controls)
                {
                    if (i is PictureBox && i.Tag == "stworek")
                    {
                        if (j is PictureBox && j.Tag == "strzaly")
                        {
                            if (i.Bounds.IntersectsWith(j.Bounds))
                            {
                                score++;
                                this.Controls.Remove(i);
                                this.Controls.Remove(j);
                            }
                        }
                    }
                }
            }
        }
    }
}
