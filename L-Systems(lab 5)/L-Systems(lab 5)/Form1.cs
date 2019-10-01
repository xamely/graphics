using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace L_Systems_lab_5_
{
    public partial class Form1 : Form
    {

        Graphics g;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 2;

            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.Clear(Color.White);
            
        }


        public void drawF(int x, int y, int len, double angle, PaintEventArgs e, int it)
        {
            Graphics g = e.Graphics;
            double x1, y1;
            len = (int)(len * zoom);
            x1 = x + len * Math.Sin(angle * Math.PI * 2 / 360.0);
            y1 = y + len * Math.Cos(angle * Math.PI * 2 / 360.0);
            g.DrawLine(new Pen(Color.Black, len / 40), x, area.Height - y, (int)x1, area.Height - (int)y1);

            if (it < 8)
            {
                Random rnd = new Random();//+ rnd.Next(-c, -c)

                drawF((int)x1, (int)y1, (int)(len * 0.8), angle - 60, e, it + 1);
                drawF((int)x1, (int)y1, (int)(len * 0.8), angle - 30, e, it + 1);
                drawF((int)x1, (int)y1, (int)(len * 0.8), angle + 30, e, it + 1);
                drawF((int)x1, (int)y1, (int)(len * 0.8), angle + 60, e, it + 1);


            }
        }


        double zoom = 0.5;

        public PointF F(float x, float y, float len, float angle, int it)
        {
            
            float x1, y1;
            len = (float)(len * zoom);
            x1 = x + len * (float)Math.Sin(angle * Math.PI * 2 / 360.0);
            y1 = y + len * (float)Math.Cos(angle * Math.PI * 2 / 360.0);

            g.DrawLine(new Pen(Color.Black), x, (float)(area.Height - y), x1, (float)(area.Height - (y1)));
            area.Invalidate();
            //area.Update();
            return new PointF(x1, y1);
        }




        //Start - начальная строка
        //Rule - правило
        //it - кол-во итераций
        public String convertRule(String starts, String rule, int it)
        {
            String s = "";
            for (int i = 0; i < it; i++)
            {
                for (int j = 0; j < starts.Length; j++)
                {
                    if (starts[j] == 'F')
                    {
                        s += rule;
                    }
                    else if (starts[j] == '+' || starts[j] == '-')
                    {
                        s += starts[j];
                    }
                }
                starts = s;
                s = "";
            }
            return starts;
        }
        public void drawFract(float x, float y, float len, float napr, float angle, String s)
        {
            int c = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'F')
                {
                    c++;
                }
            }
            PointF P = new PointF(x, y);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'F')
                {
                    P = F(P.X, P.Y, len, napr, 0);
                    area.Update();
                }
                else if (s[i] == '+')
                {
                    napr += angle;

                }
                else if (s[i] == '-')
                {
                    napr -= angle;
                }
            }
        }
        private void Refresh_Click(object sender, EventArgs e)
        {
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.Clear(Color.White);
            comboBox1.SelectedIndex = 0;
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != 0)
            {
                int X, Y, it;
                X = 150;
                Y = 150;
                it = 3;
                it = Convert.ToInt32(comboBox2.Items[comboBox2.SelectedIndex]);

                string[] text = new string[10];
                float len=0;
                float azimut=0;
                if (comboBox1.SelectedIndex == 1)
                {
                    string file_name = @"..\..\test_fractals\1.Кривая Коха.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / Math.Pow(Math.Log(200, 6), it - 1));
                    azimut = 30;

                }
                if (comboBox1.SelectedIndex == 2)
                {
                    string file_name = @"..\..\test_fractals\2.Снежинка Коха.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / Math.Pow(Math.Log(200, 6), it - 1));
                    azimut = 30;

                }

                if (comboBox1.SelectedIndex == 3)
                {
                    string file_name = @"..\..\test_fractals\3.Остров Коха.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / Math.Pow(Math.Log(200, 6), it ));
                    azimut = 0;
                    Y -= 50;
                }


                int i = 0;
                int angle = 0;
                string start = "";
                string rule = "";
                while (text[i] != ".")
                {
                    string str = text[i];
                    if (i == 0)
                    {
                        start = str.Split()[0];
                        angle = Convert.ToInt32(str.Split()[1]);
                    }
                    else
                    {
                        rule = str.Split()[2];
                    }
                    i++;
                }
               // float len = (float)(200.0 / Math.Pow(Math.Log(200, 6), it - 1));
                string s = convertRule(start, rule, it);
                drawFract(X, Y, len, azimut, angle, s);
            }
            area.Invalidate();
        }
    }
}
