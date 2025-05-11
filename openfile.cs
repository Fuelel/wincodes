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

namespace testik_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult odpoved1 = saveFileDialog1.ShowDialog();
            if (odpoved1 == DialogResult.OK)
            {
                textBox1.Text = saveFileDialog1.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult odpoved2 = saveFileDialog2.ShowDialog();
            if (odpoved2 == DialogResult.OK)
            {
                textBox2.Text = saveFileDialog2.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult odpoved3 = saveFileDialog3.ShowDialog();
            if (odpoved3 == DialogResult.OK)
            {
                textBox3.Text = saveFileDialog3.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Encoding kodovani;
            kodovani = Encoding.UTF8;

            StreamWriter soubor = new StreamWriter(saveFileDialog3.FileName, false, kodovani);
            StreamReader prvni =
                new StreamReader(saveFileDialog1.FileName, kodovani);
            StreamReader druhy =
                new StreamReader(saveFileDialog2.FileName, kodovani);
            for (int i = 0; i < 20; i++)
            {
                string radek = prvni.ReadLine();
                string radek2 = druhy.ReadLine();

                soubor.Write(radek);
                soubor.WriteLine(radek2);


            }
            soubor.Close();
            prvni.Close();
            druhy.Close();

            MessageBox.Show("DONE");
        }
    }
}
