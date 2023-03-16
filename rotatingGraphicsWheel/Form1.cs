using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rotatingGraphicsWheel
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        Pen pen0 = new Pen(Color.Black, 1);
        static float k1 = 360 / 30;
        static float k2 = 360 / 60;
        float rad = (float)(180 / 3.14);
        float stepf1 = k1;
        float stepf2 = k2;
        float startangle = 0.0f;
        public bool isMouseDown = false;
        public int x1, x2, y1, y2, prevx, prevy;


        public float distantaintredouapuncte2dxy(float x1, float y1, float x2, float y2)
        {
            float c;
            c = (float)Math.Sqrt(Math.Abs(x1 - x2) * Math.Abs(x1 - x2) + Math.Abs(y1 - y2) * Math.Abs(y1 - y2));
            return c;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            g = CreateGraphics();
        }
        
        public void draw()
        {
            //stie cineva cum se deseneaza o roata dintata ???
            g.Clear(this.BackColor);
            g.DrawEllipse(pen0, 100, 100, 200, 200);
            g.DrawEllipse(pen0, 50, 50, 300, 300);
            int m = 0;
            for (float i = startangle; i <= 360.0f + startangle; i += stepf1)
            {
                m++;
                g.DrawLine(pen0, (float)(Math.Cos(i / rad) * 150 + 200), (float)(Math.Sin(i / rad) * 150 + 200), (float)(Math.Cos(i / rad) * 100 + 200), (float)(Math.Sin(i / rad) * 100 + 200));
                g.DrawLine(pen0, (float)(Math.Cos((i + stepf1) / rad) * 150 + 200), (float)(Math.Sin((i + stepf1) / rad) * 150 + 200), (float)(Math.Cos((i - stepf1) / rad) * 100 + 200), (float)(Math.Sin((i - stepf1) / rad) * 100 + 200));

                g.DrawLine(pen0, (float)(Math.Cos((i + stepf2) / rad) * 170 + 200), (float)(Math.Sin((i + stepf2) / rad) * 170 + 200), (float)(Math.Cos((i + stepf2) / rad) * 100 + 200), (float)(Math.Sin((i + stepf2) / rad) * 100 + 200));

                if (m % 2 == 0)
                {
                    g.DrawLine(pen0, (float)(Math.Cos((i + stepf2) / rad) * 170 + 200), (float)(Math.Sin((i + stepf2) / rad) * 170 + 200), (float)(Math.Cos((i + stepf2 + stepf2 + stepf2) / rad) * 170 + 200), (float)(Math.Sin((i + stepf2 + stepf2 + stepf2) / rad) * 170 + 200));
                }

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            startangle -= 1.0f;
           
            draw();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            startangle += 1.0f;
           
            draw();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isMouseDown = true;
            x1 = e.X;
            y1 = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown == true)
            {
                x2 = e.X;
                y2 = e.Y;
                float r = distantaintredouapuncte2dxy(button1.Left, button1.Top, button2.Left, button2.Top);
                Text = r.ToString();
                if (prevx > x2) { startangle = startangle - (Math.Abs(prevx - x2)) / 10; }
                else if (prevx == x2) { }
                else { startangle = startangle + (Math.Abs(x2 - prevx)) / 10; }
                prevx = x2;
                prevy = y2;
                draw();
            }
            
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }
    }
}
