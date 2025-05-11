using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rtání_animace
{
    public partial class Form1 : Form
    {
        int tloustka = 100;
        int prumer = 50;
        int VRTy = 50;
        int VRTyg = 50;
        bool smer = false;
        bool hotovo = false;
        public Form1()
        {
            
            InitializeComponent();
            this.Select();
            

            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            SolidBrush brush = new SolidBrush(Form1.DefaultBackColor); 
            Rectangle rect = new Rectangle(100, 230, 300, tloustka);
            e.Graphics.FillRectangle(Brushes.Teal, rect);

            Rectangle vrt_ghost = new Rectangle(250 - (prumer / 2), VRTyg, prumer, 150);
            e.Graphics.FillRectangle(brush, vrt_ghost);

            Rectangle vrt = new Rectangle(250 - (prumer / 2), VRTy, prumer, 150);
            e.Graphics.FillRectangle(Brushes.Gray, vrt);
        }

        private void Uprav_Click(object sender, EventArgs e)
        {
            try
            {
                tloustka = Convert.ToInt32(textBox1.Text);
                prumer = Convert.ToInt32(textBox2.Text);

            }
            catch{

                MessageBox.Show("zadané špatné údaje");
            }

            VRTyg = 50;
            Refresh();
        }

        private void Vrtej_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((VRTy + 150) < (230 + tloustka) && smer == false)
            {
                VRTy += 10;
                VRTyg += 10;

            }
            else smer = true;

            if (VRTy > 50 && smer == true)
            {
                VRTy -= 10;

            }
            else if(VRTy == 50 && smer == true)
            { 
                smer = false;
                timer1.Stop();
            }

            Refresh();
        }

        

        
    }
}
