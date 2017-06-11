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
    public partial class Waz : Form
    {
        List<Punkt> waz = new List<Punkt>();
        const int szerokosc = 16;
        const int wysoksc = 16;
        bool gameover = false;
        int punkty = 0;
        int kierunek = 0; // w górę = 3,dół = 0, W prawo = 2, Lewo = 1
        Punkt czesci_jedzenia = new Punkt();

        public Waz()
        {
            InitializeComponent();
            timer1.Interval = 1000 / 4;
            timer1.Tick += new EventHandler(Ustawienia);
            timer1.Start();
            StartGry();
        }

        private void StartGry()
        {
            gameover = false;
            punkty = 0;
            waz.Clear();
            Punkt glowa = new Punkt();
            glowa.X = 1;
            glowa.Y = 5;
            waz.Add(glowa);
            TworzJedzenie();
        }

        #region Funk
        private void Waz_KeyDown(object sender, KeyEventArgs e)
        {
            Ruch.ChangeState(e.KeyCode, true);

        }

        private void Waz_KeyUp(object sender, KeyEventArgs e)
        {
            Ruch.ChangeState(e.KeyCode, false);
        }

        private void pictureBoxW_Paint(object sender, PaintEventArgs e)
        {
            Graphics tlo = e.Graphics;
            if (gameover)
            {
                Font tekst = this.Font;
                string przegrales_w = "Przegrales";
                string nowa_gra = "Nacisjnij ENTER by zagrać ponownie";
                int szerokosc = pictureBoxW.Width / 2;
                SizeF wiadomosc_rozmiar = tlo.MeasureString(przegrales_w, tekst);
                PointF wiadomosc_punkty = new PointF(szerokosc - wiadomosc_rozmiar.Width / 2, 16);
                tlo.DrawString(przegrales_w, tekst, Brushes.White, wiadomosc_punkty);
                wiadomosc_punkty = new PointF(szerokosc - wiadomosc_rozmiar.Width / 2, 32);
                wiadomosc_rozmiar = tlo.MeasureString(nowa_gra, tekst);
                wiadomosc_punkty = new PointF(szerokosc - wiadomosc_rozmiar.Width / 2, 48);
                tlo.DrawString(nowa_gra, tekst, Brushes.White, wiadomosc_punkty);
            }
            else
            {
                for (int i = 0; i < waz.Count; i++)
                {
                    Brush snake_color = i == 0 ? Brushes.Red : Brushes.Black;
                    tlo.FillRectangle(snake_color, new Rectangle(waz[i].X * szerokosc, waz[i].Y * wysoksc, szerokosc, wysoksc));
                }
                tlo.FillRectangle(Brushes.Orange, new Rectangle(czesci_jedzenia.X * szerokosc, czesci_jedzenia.Y * wysoksc, szerokosc, wysoksc));
                label1.Text = "Wynik " + punkty;
            }

            }
        #endregion
        private void TworzJedzenie()
        {
            int max_w = pictureBoxW.Size.Width / szerokosc;
            int max_h = pictureBoxW.Size.Height / wysoksc;
            Random random = new Random();
            czesci_jedzenia = new Punkt();
            czesci_jedzenia.X = random.Next(0, max_w);
            czesci_jedzenia.Y = random.Next(0, max_h);
        }

        private void Ustawienia(object sender, EventArgs e)
        {
            if (gameover)
            {
            }
            else
            {
                if (Ruch.Pressed(Keys.Right))
                {
                    if (waz.Count < 2 || waz[0].X == waz[1].X)
                        kierunek = 2;
                }
                else if (Ruch.Pressed(Keys.Left))
                {
                    if (waz.Count < 2 || waz[0].X == waz[1].X)
                        kierunek = 1;
                }
                else if (Ruch.Pressed(Keys.Up))
                {
                    if (waz.Count < 2 || waz[0].Y == waz[1].Y)
                        kierunek = 3;
                }
                else if (Ruch.Pressed(Keys.Down))
                {
                    if (waz.Count < 2 || waz[0].Y == waz[1].Y)
                        kierunek = 0;
                }
                UstawieniaWaz();
            }
            pictureBoxW.Invalidate();
        }

        private void UstawieniaWaz()
        {
            for (int i = waz.Count - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    switch (kierunek)
                    {
                        case 0: // Down
                            waz[i].Y++;
                            break;
                        case 1: // Left
                            waz[i].X--;
                            break;
                        case 2: // Right
                            waz[i].X++;
                            break;
                        case 3: // Up
                            waz[i].Y--;
                            break;
                    }
                }
            }
        
    }


    }
}
