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
            if (pilka.Left + pilka.Width > ClientSize.Width || pilka.Left < 0)
            {
                pilkax = -pilkax;
            }
            if (pilka.Top < 0 || pilka.Bounds.IntersectsWith(Gracz.Bounds))
            {
                pilkay = -pilkay;
            }
            if (pilka.Top + pilka.Height > ClientSize.Height)
            {
                timer1.Stop();
                MessageBox.Show("Przegrałeś","Informacja",MessageBoxButtons.OK,MessageBoxIcon.Information);
                KoniecGry();

            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "plytka")
                {
                    if (pilka.Bounds.IntersectsWith(x.Bounds))
                    {
                        this.Controls.Remove(x);
                        pilkay = -pilkay;
                        punkty++;

                    }
                }
                if (punkty> 29)
                {
                    timer1.Stop();
                    MessageBox.Show("Wygrałes");
                    KoniecGry();
                    
                }
            }



        }

        private void KoniecGry()
        {
                            if (MessageBox.Show(" Zaczynamy od nowa ", "Informacja", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    pilka.Location = new System.Drawing.Point(64, 471);
                this.Controls.Add(pictureBox1);
                this.Controls.Add(pictureBox2);
                this.Controls.Add(pictureBox3);
                this.Controls.Add(pictureBox4);
                this.Controls.Add(pictureBox5);
                this.Controls.Add(pictureBox6);
                this.Controls.Add(pictureBox7);
                this.Controls.Add(pictureBox8);
                this.Controls.Add(pictureBox9);
                this.Controls.Add(pictureBox10);
                this.Controls.Add(pictureBox11);
                this.Controls.Add(pictureBox12);
                this.Controls.Add(pictureBox13);
                this.Controls.Add(pictureBox14);
                this.Controls.Add(pictureBox15);
                this.Controls.Add(pictureBox16);
                this.Controls.Add(pictureBox17);
                this.Controls.Add(pictureBox18);
                this.Controls.Add(pictureBox19);
                this.Controls.Add(pictureBox20);
                this.Controls.Add(pictureBox21);
                this.Controls.Add(pictureBox22);
                this.Controls.Add(pictureBox23);
                this.Controls.Add(pictureBox24);
                this.Controls.Add(pictureBox25);
                this.Controls.Add(pictureBox26);
                this.Controls.Add(pictureBox27);
                this.Controls.Add(pictureBox28);
                this.Controls.Add(pictureBox29);
                this.Controls.Add(pictureBox30);



                timer1.Start();
                }else
                {
                    this.Close();
                }
        }
    }

}
