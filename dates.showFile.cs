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

namespace strukurovany_text
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void prochazet_Click(object sender, EventArgs e)
        {
            DialogResult odpoved = openFileDialog1.ShowDialog();
            if (odpoved == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string soubor = textBox1.Text;
            StreamReader vychozi =
                new StreamReader(soubor, Encoding.Default);

            
            DateTime dnes = DateTime.Today;
            DateTime hledameDatum;
            if(radioButton1.Checked)
            {
                hledameDatum = dnes;

            }
            else if(radioButton2.Checked)
            {
                hledameDatum = dnes.AddDays(1);
            }
            else
            {
                int rok = dnes.Year;
                hledameDatum = Convert.ToDateTime(textBox2.Text + rok.ToString());
            }


            vychozi.ReadLine();

            string radek, zprava = null;
            while ((radek = vychozi.ReadLine()) != null)
            {
                string[] hodnoty = radek.Split(';');

                string cislo = hodnoty[0];
                string prijmeni = hodnoty[1];
                string jmeno = hodnoty[2];
                string datumnarozenitext = hodnoty[3];
                DateTime datumnarozeni = Convert.ToDateTime(datumnarozenitext);

                if(datumnarozeni.Day == hledameDatum.Day && datumnarozeni.Month == hledameDatum.Month)
                {
                    zprava = jmeno + " " + prijmeni + " " + "(č." + cislo + ")" + Environment.NewLine;
                    
                } 

            }
            vychozi.Close();
            textBox3.Text = zprava;



        }
    }
}
