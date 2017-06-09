using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;


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
            if (textBox2.Text == slowo)
            {
                MessageBox.Show("Odgadłeś słowo!!!");
                RestartGry();
            }
            else
            {
                RysujCzesciCiala((CzesciCiala)suma);
                suma++;
                if (suma == 10)
                {
                    MessageBox.Show("Prawidlowe slowo " + slowo);
                    RestartGry();
                }
            }
        }

        private void RysujCzesciCiala(CzesciCiala cc)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Red, 2);
            if (cc == CzesciCiala.Glowa)
            {
                g.DrawEllipse(p, 40, 50, 40, 40);

            }
            else if (cc == CzesciCiala.Lewe_Oko)
            {
                SolidBrush s = new SolidBrush(Color.Blue);
                g.FillEllipse(s, 50, 60, 5, 5);
            }
            else if (cc == CzesciCiala.Prawe_Oko)
            {
                SolidBrush s = new SolidBrush(Color.Blue);
                g.FillEllipse(s, 63, 60, 5, 5);
            }
            else if (cc == CzesciCiala.Nos)
            {
                g.DrawArc(p, 50, 60, 20, 20, 45, 90);
            }
            else if (cc == CzesciCiala.Cialo)
            {
                g.DrawLine(p, new Point(60, 90), new Point(60, 170));
            }
            else if (cc == CzesciCiala.Lewe_Ramie)
            {
                g.DrawLine(p, new Point(60, 100), new Point(30, 85));
            }
            else if (cc == CzesciCiala.Prawe_Ramie)
            {
                g.DrawLine(p, new Point(60, 100), new Point(90, 85));
            }
            else if (cc == CzesciCiala.Lewa_Noga)
            {
                g.DrawLine(p, new Point(60, 170), new Point(30, 190));

            }
            else if (cc == CzesciCiala.Prawa_Noga)
            {
                g.DrawLine(p, new Point(60, 170), new Point(90, 190));

            }
        }

        private string WybierzLosowoSlowo()
        {
            WebClient wc = new WebClient();
            string WordList = wc.DownloadString("https://www.d.umn.edu/~rave0029/research/adjectives1.txt");
            string[] slowa = WordList.Split('\n');
            Random los = new Random();
            return slowa[los.Next(0, slowa.Length - 1)];
        }
        private void TworzPodstawyLiter()
        {
            slowo = WybierzLosowoSlowo();
            char[] chars = slowo.ToCharArray();
            int between = 330 / chars.Length - 1;
            for (int i = 0; i < chars.Length ; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * between) + 10, 80);
                labels[i].Text = "_";
                labels[i].Parent = groupBox1;
                labels[i].BringToFront();
                labels[i].CreateControl();

            }
            label1.Text += (chars.Length ).ToString();
        }
        private void Pokaz(object sender, EventArgs e)
        {
            RysujSlup();
            TworzPodstawyLiter();
            //  RysujCzesciCiala(CzesciCiala.Glowa); /*Sprawdzenie jak wyglada*/

        }
        private void RestartGry()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            WybierzLosowoSlowo();
            TworzPodstawyLiter();
            RysujSlup();
            suma = 0;
            label2.Text = "Przegrałeś";
            textBox1.Text = "";


        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }
    }
}
