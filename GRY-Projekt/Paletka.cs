﻿using System;
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
    public partial class Paletka : Form
    {
        bool wPrawo;
        bool wLewo;
        int predkosc = 10;

        int pilkax = 6;
        int pilkay = 6;

        int punkty = 0;

        private Random rnd = new Random();
        public Paletka()
        {
            InitializeComponent();
            foreach (Control x in this.Controls)
            {
                if (x.Tag == "plytka" && x is PictureBox )
                {
                    Color randomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
                    x.BackColor = randomColor;
                }
            }
        }

        private void keydown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left && Gracz.Left>0)
            {
                wLewo = true;
            }

            if (e.KeyCode==Keys.Right && Gracz.Left+Gracz.Width<1020)
            {
                wPrawo = true;
            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Left)
            {
                wLewo = false;
            }
            if (e.KeyCode==Keys.Right)
            {
                wPrawo = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pilka.Left += pilkax; //Pilka sie porusza
            pilka.Top += pilkay;
            wynik.Text = "Wynik: " + punkty;
            if (wLewo) { Gracz.Left -= predkosc; }
            if (wPrawo) { Gracz.Left += predkosc; }

            if (Gracz.Left < 1)
            {
                wLewo = false;
            }
            else if (Gracz.Left + Gracz.Width > 1020)
            {
                wPrawo = false;
            }
            


        }

        private void KoniecGry()
        {
            timer1.Stop();
        }
    }

}
