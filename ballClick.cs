using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graficka_apka_mouseclick
{
    public partial class Form1 : Form
    {
        float mouseX = 0;
        float mouseY = 0;
        float Rx = 0;
        float Ry = 0;
        float cestaX;
        float cestaY;
        int i;
        int klik;
        int klikk;
        public Form1()
        {
            InitializeComponent();
            Rx = panel1.Width / 2 - 10;
            Ry = panel1.Height / 2 - 10;
        }
        
        


        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            mouseX = e.X;
            mouseY = e.Y;
            cestaX = (Rx - mouseX) / 40;
            cestaY = (Ry - mouseY) / 40;
            i = 0;
            if (mouseX > Rx-10 && mouseX < Rx+20 && mouseY < Ry+20 && mouseY > Ry -10 )
            {
                klikk++;
            }
            else klik ++;
            timer1.Start();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            

            e.Graphics.FillEllipse(Brushes.Teal, Rx, Ry, 20, 20);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(klik);
            textBox2.Text = Convert.ToString(klikk);
            if(i != 40)
            {
                Rx -= cestaX;
                Ry -= cestaY;
                ++i;
            } 

            
            panel1.Refresh();
            
        }
    }
}
