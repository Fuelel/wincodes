using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prvni_prace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void butt_vypocti_Click(object sender, EventArgs e)
        {
            string nazev_prvni = nazev1.Text;
            if (nazev_prvni.Length == 0)
            {
                MessageBox.Show("není zadaný název");
                return;
            }

            if (amount1.Value == 0)
            {
                MessageBox.Show("Nemůžeš mít 0 položek");
                return;
            }

            double pocet_prvni = Convert.ToDouble(amount1.Value); 
            double cena_prvni = Convert.ToDouble(cena1.Text);
            double sleva_prvni = Convert.ToDouble(sleva1.Text);
            double dph_prvni = Convert.ToDouble(comboBox1.Items[comboBox1.SelectedIndex]);



            string nazev_druhy = nazev2.Text;
            if (nazev_druhy.Length == 0)
            {
                MessageBox.Show("není zadaný název");
                return;
            }

            if (amount2.Value == 0)
            {
                MessageBox.Show("Nemůžeš mít 0 položek");
                return;
            }
            double pocet_druhy = Convert.ToDouble(amount2.Value);
            double cena_druhy = Convert.ToDouble(cena2.Text);
            double sleva_druhy = Convert.ToDouble(sleva2.Text);
            double dph_druhy = Convert.ToDouble(comboBox2.Items[comboBox2.SelectedIndex]);
     

            double celkem_bez_final = (((cena_prvni * pocet_prvni) / 100) * (100 - sleva_prvni))+(((cena_druhy * pocet_druhy) / 100) * (100 - sleva_druhy));
            textBox11.Text = Convert.ToString(celkem_bez_final);

            double mnozstvi = pocet_druhy + pocet_prvni;

            double dph_final = (dph_prvni - cena_prvni) + (dph_druhy - cena_prvni);
            textBox14.Text = Convert.ToString(dph_final);

            if (mnozstvi < 10)
            {
                textBox12.Text = "0%";
                textBox13.Text = Convert.ToString(celkem_bez_final);
                double final = dph_final + celkem_bez_final;
                textBox15.Text = Convert.ToString(final);

            }
            else if (mnozstvi <= 50)
            {
                textBox12.Text = "5%";
                double celkem_bezdph_sleva = (celkem_bez_final / 100) * (100 - 5);
                textBox13.Text = Convert.ToString(celkem_bezdph_sleva);
                double final = dph_final + celkem_bezdph_sleva;
                textBox15.Text = Convert.ToString(final);
                int d = 0;

            }
            else
            {
                textBox12.Text = "10%";
                double celkem_bezdph_sleva = (celkem_bez_final / 100) * (100 - 10);
                textBox13.Text = Convert.ToString(celkem_bezdph_sleva);
                double final = dph_final + celkem_bezdph_sleva;
                textBox15.Text = Convert.ToString(final);
            }
            
            


        }

        private void nazev1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nazev_prvni = nazev1.Text;
                double pocet_prvni = Convert.ToDouble(amount1.Value);
                double cena_prvni = Convert.ToDouble(cena1.Text);
                double sleva_prvni = Convert.ToDouble(sleva1.Text);
                double dph_prvni = Convert.ToDouble(comboBox1.Items[comboBox1.SelectedIndex]);

                double celkem_bez1 = ((cena_prvni * pocet_prvni)/100) * (100 - sleva_prvni);
                celkembez1.Text = Convert.ToString(celkem_bez1);

                double celkem_1 = celkem_bez1 + (celkem_bez1 * (dph_prvni / 100));
                celkem1.Text = Convert.ToString(celkem_1);

            }
            catch (Exception)
            {

                
            }

        }

        private void nazev2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string nazev_druhy = nazev2.Text;
                double pocet_druhy = Convert.ToDouble(amount2.Value);
                double cena_druhy = Convert.ToDouble(cena2.Text);
                double sleva_druhy = Convert.ToDouble(sleva2.Text);
                double dph_druhy = Convert.ToDouble(comboBox2.Items[comboBox2.SelectedIndex]);

                double celkem_bez2 = ((cena_druhy * pocet_druhy) / 100) * (100 - sleva_druhy);
                celkembez2.Text = Convert.ToString(celkem_bez2);

                double celkem_2 = celkem_bez2 + (celkem_bez2 * (dph_druhy / 100));
                celkem2.Text = Convert.ToString(celkem_2);

            }
            catch (Exception)
            {


            }
        }
    }
}
