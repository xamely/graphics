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

        public PointF F(float x, float y, float len, float angle)
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

        public PointF falshF(float x, float y, float len, float angle, int it)
        {
            float x1, y1;
            len = (float)(len * zoom);
            x1 = x + len * (float)Math.Sin(angle * Math.PI * 2 / 360.0);
            y1 = y + len * (float)Math.Cos(angle * Math.PI * 2 / 360.0);
            area.Invalidate();
            return new PointF(x1, y1);
        }

        //На это не смотреть
        public double preDraw(float x, float y, float len, float napr, float angle, String s) {
            List<PointF> points = new List<PointF>();
            PointF P = new PointF(x, y);
            points.Add(P);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'F')
                {
                    P = F(P.X, P.Y, len, napr);
                    points.Add(P);
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

            return 0.0;
        }


        //Start - начальная строка
        //Rule - правило
        //it - кол-во итераций
        public String convertRule(String starts, Dictionary<char,string> rules, int it)
        {
            String s = "";
            for (int i = 0; i < it; i++)
            {
                for (int j = 0; j < starts.Length; j++)
                {
                    if (starts[j] == 'F')
                    {
                        s += rules['F'];
                    }
                    else if (starts[j] == 'X')
                    {
                        s += rules['X'];
                    }
                    else if (starts[j] == 'Y')
                    {
                        s += rules['Y'];
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

            PointF P = new PointF(x, y);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'F')
                {
                    P = F(P.X, P.Y, len, napr);
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
            
        }

        private static int CompForX(PointF p1,PointF p2) {
            if (p1.X < p2.X)
                return -1;
            else if (p1.X > p2.X)
                return 1;
            else
                return 0;
        }
        private static int CompForY(PointF p1, PointF p2)
        {
            if (p1.Y < p2.Y)
                return -1;
            else if (p1.Y > p2.Y)
                return 1;
            else
                return 0;
        }

        private PointF getNewXY(float oldX, float oldY, float len, float azimut, float angle, String s)
        {
            List<PointF> points = new List<PointF>();
            PointF P = new PointF(oldX, oldY);
            points.Add(P);
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'F')
                {
                    P = falshF(P.X, P.Y, len, azimut, 0);
                    points.Add(P);
                }
                else if (s[i] == '+')
                {
                    azimut += angle;

                }
                else if (s[i] == '-')
                {
                    azimut -= angle;
                }
            }
            float x_min = points.Select(point => point.X).Min();
            float y_min = points.Select(point => point.Y).Min();
            float x_max = points.Select(point => point.X).Max();
            float y_max = points.Select(point => point.Y).Max();
            float center_x = (x_max + x_min)/2;
            float center_y = (y_max + y_min)/2;
            float dx = (float)(area.Width/2)- center_x;
            float dy = (float)(area.Height / 2) - center_y;
            float new_x = oldX + dx;
            float new_y = oldY + dy;

            return new PointF(new_x, new_y);
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
                    //Y -= 50;
                }

                if (comboBox1.SelectedIndex == 4)
                {
                    string file_name = @"..\..\test_fractals\4.Треугольник Серпинского.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / Math.Pow(Math.Log(200, 6), it));
                    azimut = 30;
                   // Y -= 50;
                }

                if (comboBox1.SelectedIndex == 5)
                {
                    string file_name = @"..\..\test_fractals\5.Наконечник Серпинского.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / (it*it));
                    azimut = 30;
                    //Y -= it*10;
                }

                if (comboBox1.SelectedIndex == 6)
                {
                    string file_name = @"..\..\test_fractals\6.Кривая Гильберта.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / (it * it));
                    azimut = 90;
                    //Y -= it * 10;
                }
                
                if (comboBox1.SelectedIndex == 7)
                {
                    string file_name = @"..\..\test_fractals\7.Кривая Дракона.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / (it*3  ));
                    azimut = 0;
                    //X = area.Width / 2+100;
                    //Y = area.Height / 2;
                }

                if (comboBox1.SelectedIndex == 8)
                {
                    string file_name = @"..\..\test_fractals\8.Кривая Госпера.txt";

                    text = File.ReadAllLines(file_name);
                    label1.Text = text[1];
                    len = (float)(200.0 / (it * it));
                    azimut = 0;
                    //X = area.Width / 2 - 200;
                    //Y = area.Height / 2;
                    
                }

                int i = 0;
                int angle = 0;
                string start = "";
                Dictionary<char, string> rules = new Dictionary<char, string>();
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
                        rules.Add(str.Split()[0][0],str.Split()[2]);
                    }
                    i++;
                }
               
                string s = convertRule(start, rules, it);
                //zoom = preDraw(X, Y, len, azimut, angle, s);
                PointF newP = getNewXY(X, Y, len, azimut, angle, s);
                drawFract(newP.X, newP.Y, len, azimut, angle, s);
            }
            area.Invalidate();
        }
    }
}
