using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kopaci_2
{
    public partial class Form1 : Form
    {
        int vyska = 10;
        int prumer = 0;
        int now;
        int kolikaty = 0;
        int[] kopaci = new int[5];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                now = Convert.ToInt32(textBox1.Text);
                kopaci[kolikaty] = now;
                if(kolikaty < 5)
                {
                    kolikaty++;
                }
                
            }
            catch
            {

            }

            prumer = 0;
            for (int i = 0; i < kolikaty ; i++)
            {
                prumer += kopaci[i] ;
                
            }
            prumer /= kolikaty;
            



            Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            for (int i = 0; i < kopaci.Length; i++)
            {
                g.FillRectangle(Brushes.Black, panel1.Width / 10 + (30*i*2) , panel1.Height - kopaci[i], 30, kopaci[i]);
            }
            g.DrawLine(Pens.Red, 0, panel1.Height - prumer, 900, panel1.Height - prumer);

        }

        private void smaz_Click(object sender, EventArgs e)
        {
            kolikaty = 0;
            kopaci = new int[5];
            prumer = 0;
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //otevreni souboru (tabulka)
            {
                StreamReader vychozi = new StreamReader(openFileDialog1.FileName, Encoding.Default);

                
                kopaci = new int[5];

                while (!vychozi.EndOfStream) //precteni radky ze souboru
                {
                    string[] hodnoty = vychozi.ReadLine().Split(';'); //split dat pomoci ;
                    for (int i = 0; i < 5; i++)
                    {
                        kopaci[i] = Convert.ToInt32(hodnoty[i]);
                        
                    }
                }

                
                vychozi.Close();
                
            }

            prumer = 0;
            for (int i = 0; i < kopaci.Length; i++)
            {
                prumer += kopaci[i];
                

            }
            prumer /= kopaci.Length;

            MessageBox.Show(prumer.ToString());

            


            Refresh();
            



        }
    }
}
