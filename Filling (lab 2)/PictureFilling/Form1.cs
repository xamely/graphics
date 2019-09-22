using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureFilling
{
    public partial class Form1 : Form
    {
        Color CurrentColor = Color.Black; //Default color
        Point CurrentPoint; //Current Position
        Point PrevPoint; //Previous Position
        bool isPressed;
        Graphics g;
        private Bitmap map;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            map = new Bitmap(panel1.Width, panel1.Height, g);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
                CurrentColor = colorDialog1.Color;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            if (checkBox1.Checked) fill_area();
            else isPressed = true;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                paint_simple();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void paint_simple()
        {
            Pen p = new Pen(CurrentColor);
            g.DrawLine(p, PrevPoint, CurrentPoint);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void fill_area()
        {
            Pen p = new Pen(CurrentColor);
            map = new Bitmap(panel1.Width, panel1.Height);
            tmp_fill(p, CurrentPoint);
        }

        private void tmp_fill(Pen p, Point TempCurrentPoint)
        {
            Point left_point = TempCurrentPoint;
            while (left_point.X > 0 && p.Color != map.GetPixel(left_point.X - 1, left_point.Y))
                left_point.X -= 1;
            g.DrawLine(p, TempCurrentPoint, left_point);
            Point right_point = TempCurrentPoint;
            while (right_point.X < (map.Width - 1) && p.Color != map.GetPixel(right_point.X + 1, right_point.Y))
                right_point.X += 1;
            g.DrawLine(p, right_point, TempCurrentPoint);
            for (int i = left_point.X; i <= right_point.X; i++)
            {
                if (left_point.Y < (map.Height - 1) && p.Color != map.GetPixel(i, left_point.Y + 1))
                    tmp_fill(p, new Point(i, left_point.Y + 1));
                if (left_point.Y > 0 && p.Color != map.GetPixel(i, left_point.Y - 1))
                    tmp_fill(p, new Point(i, left_point.Y - 1));
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
