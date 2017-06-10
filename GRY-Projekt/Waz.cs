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
        }
        #endregion
        private void TworzJedzenie()
        {
            int max_w = pictureBoxW.Size.Width / szerokosc;
            int max__h = pictureBoxW.Size.Height / wysoksc;
            Random random = new Random();
            czesci_jedzenia = new Punkt();
            czesci_jedzenia.X = random.Next(0, max_w);
            czesci_jedzenia.Y = random.Next(0, max_h);
        }

        private void Ustawienia(object sender, EventArgs e)
        { }

        private void UstawieniaWaz()
        { }


    }
}
