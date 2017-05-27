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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch(lista_rozwijana1.SelectedIndex)
            {
                case 0:
                    Waz waz = new Waz();
                    waz.Show();
                    break;
                case 1:
                    Wisielec wisielec = new Wisielec();
                    wisielec.Show();
                    break;
                case 2:
                    Czolg czolg = new Czolg();
                    czolg.Show();
                    break;
                case 3:
                    Paletka paletka = new Paletka();
                    paletka.Show();
                    break;

            }
        }
    }
}
