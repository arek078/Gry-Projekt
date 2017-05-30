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

        int pilkax = 3;
        int pilkay = 3;

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
    }
}
