using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test_2_graficka_aplikace_kalkulacka
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        bool hahahihi = true;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            Pen myPen = new Pen(Color.Black);
            myPen.Width = 3;
            
            g.DrawLine(myPen, 1, 1, 1, 375);
            g.DrawLine(myPen, 1, 1, 300, 1);
            g.DrawLine(myPen, 1, 371, 300, 371);
            g.DrawLine(myPen, 296, 1, 296, 375);
            //rám
            g.DrawLine(myPen, 75, 1, 75, 300);
            g.DrawLine(myPen, 150, 1, 150, 375);
            g.DrawLine(myPen, 225, 1, 225, 375);
            //vertikalní
            g.DrawLine(myPen, 1, 75, 300, 75);
            g.DrawLine(myPen, 1, 150, 225, 150);
            g.DrawLine(myPen, 1, 225, 300, 225);
            g.DrawLine(myPen, 1, 300, 225, 300);
            //horizontální

            g.DrawString("←", new Font("Arial", 25), Brushes.Black, 37 - 15, 37 - 15);
            g.DrawString("/", new Font("Arial", 25), Brushes.Black, 112 - 15, 37 - 15);
            g.DrawString("*", new Font("Arial", 25), Brushes.Black, 187 - 15, 37 - 15);
            g.DrawString("-", new Font("Arial", 25), Brushes.Black, 263 - 15, 37 - 15);

            g.DrawString("1", new Font("Arial", 25), Brushes.Black, 37 - 15, 112 - 15);
            g.DrawString("2", new Font("Arial", 25), Brushes.Black, 112 - 15, 112 - 15);
            g.DrawString("3", new Font("Arial", 25), Brushes.Black, 187 - 15, 112 - 15);

            g.DrawString("4", new Font("Arial", 25), Brushes.Black, 37 - 15, 187 - 15);
            g.DrawString("5", new Font("Arial", 25), Brushes.Black, 112 - 15, 187 - 15);
            g.DrawString("6", new Font("Arial", 25), Brushes.Black, 187 - 15, 187 - 15);

            g.DrawString("7", new Font("Arial", 25), Brushes.Black, 37 - 15, 263 - 15);
            g.DrawString("8", new Font("Arial", 25), Brushes.Black, 112 - 15, 263 - 15);
            g.DrawString("9", new Font("Arial", 25), Brushes.Black, 187 - 15, 263 - 15);

            g.DrawString(".", new Font("Arial", 25), Brushes.Black, 187 - 15, 338 - 15);
            g.DrawString("0", new Font("Arial", 25), Brushes.Black, 75 - 15, 338 - 15);

            g.DrawString("+", new Font("Arial", 25), Brushes.Black, 263 - 15, 150 - 15);
            g.DrawString("enter", new Font("Arial", 10), Brushes.Black, 263 -21, 300 - 15);





        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            String a;
            switch (e.Button)
            {
                case MouseButtons.Left:
                    a = "leve tlacitko";
                    break;               
                
            }
            int y = e.Y;
            int x = e.X;

            



            if (y < 75 && x < 75)
            {
                try
                {
                    textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                }
                catch (Exception)
                {

                    textBox1.Text = "syntax error";
                }
            }
            else if (y < 75 && x < 150 && x > 75 && hahahihi == true)
            {
                textBox1.Text += "/";
                hahahihi = false;

            }
            else if (y < 75 && x < 225 && x > 75 && hahahihi == true)
            {
                textBox1.Text += "*";
                hahahihi = false;
            }
            else if (y < 75 && x < 300 && x > 75 && hahahihi == true)
            {
                textBox1.Text += "-";
                hahahihi = false;
            }
            else if (y > 75 && y < 150 && x < 75 )
            {
                textBox1.Text += "1";
            }
            else if (y > 75 && y < 150 && x < 150 && x > 75)
            {
                textBox1.Text += "2";
            }
            else if (y > 75 && y < 150 && x < 225 && x > 150)
            {
                textBox1.Text += "3";
            }
            else if (y > 75 && y < 225 && x < 300 && x > 225)
            {
                textBox1.Text += "+";
            }
            else if (y > 150 && y < 225 && x < 75)
            {
                textBox1.Text += "4";
            }
            else if (y > 150 && y < 225 && x < 150 && x >75)
            {
                textBox1.Text += "5";
            }
            else if (y > 150 && y < 225 && x < 225 && x > 150)
            {
                textBox1.Text += "6";
            }
            else if (y > 225 && y < 300 && x < 75)
            {
                textBox1.Text += "7";
            }
            else if (y > 225 && y < 300 && x < 150 && x > 75)
            {
                textBox1.Text += "8";
            }
            else if (y > 225 && y < 300 && x < 225 && x > 150)
            {
                textBox1.Text += "9";
            }
            else if (y > 300 && y < 375 && x < 150 )
            {
                textBox1.Text += "0";
            }
            else if (y > 300 && y < 375 && x > 150 && x < 225)
            {
                textBox1.Text += ".";
            }

            else if (y > 225 && y < 375 && x < 300 && x > 225)
            {
                

                try
                {
                    var result = new DataTable().Compute(textBox1.Text, null);
                    textBox1.Text = result.ToString();
                    if (textBox1.Text == "∞")
                    {
                        textBox1.Text = "syntax error";
                    }
                }
                catch (Exception)
                {

                    textBox1.Text = "syntax error";
                }

                
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            hahahihi = true;
            
        }
    }
}
