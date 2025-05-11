using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace editace_tabulkových_dat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
        }
        List<string> seznam;
        



        private void konecToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("opravdu chcete zavřít okno?", "Konec programu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Close(); //zavreni okna
            }
        }
        int index = 0;

        private void otevřítToolStripMenuItem_Click(object sender, EventArgs e)
        {
                     
            if (openFileDialog1.ShowDialog() == DialogResult.OK) //otevreni souboru (tabulka)
            {         
                ulozit.Enabled = true;
                ulozit_jako.Enabled = true;
                otevřítToolStripMenuItem.Enabled = false;
            }

            StreamReader vychozi = new StreamReader(openFileDialog1.FileName, Encoding.Default);

            string hlavicka = vychozi.ReadLine(); //precteni prvni radky
            tabulka.Rows.Clear();

            while (!vychozi.EndOfStream) //precteni radky ze souboru
            {
                string[] hodnoty = vychozi.ReadLine().Split(';'); //split dat pomoci ;
                tabulka.Rows.Add(hodnoty); //pridani do tabulky v programu 
            }

            vychozi.Close();




        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            StreamWriter soubor = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
            string hlavicka = "Příjmení; Jméno; Místo bydliště";
            soubor.WriteLine(hlavicka);

        }

        private void ulozit_jako_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                return;
            }
            StreamWriter soubor = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
            string hlavicka = "Příjmení; Jméno; Místo bydliště";
            soubor.WriteLine(hlavicka);
        }

        private void novýZákazníkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] prazdna_hodnota = new string[3] {"","","" };
            tabulka.Rows.Add();

        }

        private void odstranitZákazníkaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabulka.CurrentRow == null) return;
            tabulka.Rows.RemoveAt(tabulka.CurrentRow.Index);
        }

        private void aktuálníZáznamToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabulka.CurrentRow != null)
            {
                string prijmeni = tabulka.CurrentRow.Cells[0].Value.ToString();
                string jmeno = tabulka.CurrentRow.Cells[1].Value.ToString();
                string bydlo = tabulka.CurrentRow.Cells[2].Value.ToString();

                MessageBox.Show("jméno: " + prijmeni + Environment.NewLine + "příjmení: " + jmeno + Environment.NewLine + "bydliště: " + bydlo );
            }
        }

        private void početJmenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tabulka.CurrentRow != null)
            {
                string jmeno = tabulka.CurrentRow.Cells[1].Value.ToString();
                int pocet = 0;



                for (int i = 0; i < tabulka.Rows.Count-1; i++)
                {
                    if (tabulka[1,i].Value.ToString() == jmeno)
                    {
                        pocet++;
                    }
                }
                

                MessageBox.Show($"Počet jmen '{jmeno}': {pocet}");
            }
        }

        private void městaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string mesto = textBox1.Text;
            string huhh = "";
            

            foreach (DataGridViewRow row in tabulka.Rows)
            {
                if (row.Cells[5].Value != null && row.Cells[5].Value.ToString() == mesto)
                {
                    huhh += row.Cells[1].Value.ToString() + ", " + row.Cells[0].Value.ToString() + Environment.NewLine;
                    
                }
            }

            if (huhh.Length > 0)
            {
                MessageBox.Show(huhh);
            }
            else
            {
                MessageBox.Show("Žádné záznamy pro zadané město.");
            }
        }

        private void přidatDoSeznamuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string prijmeni = tabulka.CurrentRow.Cells[1].Value.ToString();
            string jmeno = tabulka.CurrentRow.Cells[0].Value.ToString();
            string ulice = tabulka.CurrentRow.Cells[2].Value.ToString();
            string c_popis = tabulka.CurrentRow.Cells[3].Value.ToString();
            string psc = tabulka.CurrentRow.Cells[4].Value.ToString();
            string mesto = tabulka.CurrentRow.Cells[5].Value.ToString();

            listBox1.Items.Add(comboBox1.Text + " " + prijmeni + ", " + ulice + " " + c_popis + ", "+ psc + " " + mesto + " " + Environment.NewLine);

        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            comboBox1.Text = "Pan";
        }

        private void odebratSeSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                index = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(index);
            }
            catch 
            {

                MessageBox.Show("nebyl vybrán index");
            }
            
            
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
 
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter soubor2 = new StreamWriter(saveFileDialog1.FileName, false, Encoding.Default);
                foreach (var item in listBox1.Items)
                {
                    soubor2.WriteLine(item.ToString());
                }
                //zavreni souboru a kontrola
                soubor2.Close();
                MessageBox.Show("DONE!");
            }
            
        }

        private void vložitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && comboBox2.Text != "" && tabulka.CurrentRow.Cells[6].Value == null)
            {
                string email = (textBox2.Text + "@" + comboBox2.Text);
                tabulka.CurrentRow.Cells[6].Value = email;
            }
            else MessageBox.Show("položka Email už je vyplněná nebo nejsou vybrané hodnoty");
                
            
            
        }

        private void smazatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ( tabulka.CurrentRow.Cells[6].Value != null)
            {
                
                tabulka.CurrentRow.Cells[6].Value = null;
            }
            else MessageBox.Show("položka Email je prázdná");
        }

        private void chybějícíEmailyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string huh = "";


            foreach (DataGridViewRow row in tabulka.Rows)
            {
                if (row.Cells[6].Value == null && row.Cells[1].Value != null)
                {
    
                      huh += row.Cells[0].Value.ToString() + ", " + row.Cells[1].Value.ToString() + " " + row.Cells[5].Value.ToString() + Environment.NewLine;

                }
                
            }

           
           
            MessageBox.Show(huh);
           
            
        }
    }
}
