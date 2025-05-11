using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika_krapniky
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<int> krapniciNahore = new List<int>();
        List<int> krapniciDole = new List<int>();
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            krapniciNahore.Clear();
            string[] delky = textBox1.Text.Split(',');

            foreach(String delka in delky)
            {
                
                if(delka.Length == 0)
                {
                    continue;
                }
                
                int idelka = int.Parse(delka);

                if (idelka > panel1.Height/2)
                {
                    idelka = 0;
                }


                krapniciNahore.Add(idelka);
            }
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            float horniDelka = panel1.Width / ((krapniciNahore.Count * 2) + 1);
            float dolniDelka = panel1.Width / ((krapniciDole.Count * 2) + 1);
            Graphics g = e.Graphics;

            for(int i = 0; i < krapniciNahore.Count; i++)
            {
                g.FillRectangle(Brushes.Blue, horniDelka * (i * 2 + 1), 0, horniDelka, krapniciNahore[i]);
            }
            for (int i = 0; i < krapniciDole.Count; i++)
            {
                g.FillRectangle(Brushes.Green, dolniDelka * (i * 2 + 1), panel1.Height - krapniciDole[i], dolniDelka, krapniciDole[i]);
            }


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            krapniciDole.Clear();
            string[] delky1 = textBox2.Text.Split(',');

            foreach (String delka1 in delky1)
            {

                if (delka1.Length == 0)
                {
                    continue;
                }
                int idelka1 = int.Parse(delka1);

                if (idelka1 > panel1.Height / 2)
                {
                    idelka1 = 0;
                }

                krapniciDole.Add(idelka1);
            }
            panel1.Refresh();
        }
    }
}
