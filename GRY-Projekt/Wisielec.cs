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
    public partial class Wisielec : Form
    {
        public Wisielec()
        {
            InitializeComponent();
        }

        private string slowo = string.Empty;
        List<Label> labels = new List<Label>();
        private int suma;

        enum CzesciCiala
        {
            Glowa,
            Lewe_Oko,
            Prawe_Oko,
            Nos,
            Cialo,
            Prawe_Ramie,
            Lewe_Ramie,
            Prawa_Noga,
            Lewa_Noga

        }
        private void RysujSlup()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Black, 10);
            g.DrawLine(p, new Point(130, 210), new Point(130, 5));
            g.DrawLine(p, new Point(135, 5), new Point(65, 5));
            g.DrawLine(p, new Point(60, 0), new Point(60, 50));

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void Pokaz(object sender, EventArgs e)
        {
            RysujSlup();

        }
    }
}
