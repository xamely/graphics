using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diamond_square
{
    public partial class Form1 : Form
    {
        Point StartPoint;
        Point LastPoint;
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.Clear(Color.White);
        }

        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            StartPoint = e.Location;
        }

        private void area_MouseUp(object sender, MouseEventArgs e)
        {
            LastPoint = e.Location;
            Pen p = new Pen(Color.Black);
            g.DrawLine(p, StartPoint, LastPoint);
            area.Invalidate();
        }

        private void draw_Click(object sender, EventArgs e)
        {
            double d;
            double.TryParse(textBox1.Text, out d);
            diamond_squareAsync(StartPoint, LastPoint, d);
        }

        private async void diamond_squareAsync(Point left, Point right, double r)
        {
            if (Math.Abs(left.X - right.X) == 1) return;

            int length = (int)Math.Sqrt((left.X - right.X) * (left.X - right.X) + (left.Y - right.Y) * (left.Y - right.Y));

            int new_h = (left.Y + right.Y) / 2 + new Random(length).Next((int)(-r * length), (int)(r * length));
            Point h = new Point((left.X + right.X) / 2, new_h);

            Pen p = new Pen(Color.White);
            g.DrawLine(p, left, right);
            p = new Pen(Color.Black);
            g.DrawLine(p, left, h);
            g.DrawLine(p, h, right);
            
            area.Invalidate();
            await Task.Delay(100);
            diamond_squareAsync(left, h, r);
            diamond_squareAsync(h, right, r);
        }

        private void clear_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            area.Invalidate();
        }
    }
}
