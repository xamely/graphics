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
        Bitmap pic;

        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, area.Width, area.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
                CurrentColor = colorDialog1.Color;
        }

        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
            if (checkBox1.Checked) fill_area();
            else isPressed = true;
        }

        private void area_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                Pen p = new Pen(CurrentColor);
                g.DrawLine(p, PrevPoint, CurrentPoint);
                area.Invalidate();
            }
        }

        private void area_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, area.Width, area.Height);
        }

        private void fill_area()
        {
            Pen p = new Pen(CurrentColor);
            Bitmap map = area.Image as Bitmap;
            Color old_color = map.GetPixel(CurrentPoint.X, CurrentPoint.Y);
            tmp_fill(p, CurrentPoint, map, old_color);
        }

        private void tmp_fill(Pen p, Point TempCurrentPoint, Bitmap map, Color old_color)
        {
            Point left_point = TempCurrentPoint;

            while (left_point.X != 0 && old_color == map.GetPixel(left_point.X - 1, left_point.Y))
                left_point.X -= 1;
            g.DrawLine(p, TempCurrentPoint, left_point);

            Point right_point = TempCurrentPoint;
            while (right_point.X != (map.Width - 1) && old_color == map.GetPixel(right_point.X + 1, right_point.Y))
                right_point.X += 1;
            g.DrawLine(p, right_point, TempCurrentPoint);

            for (int i = left_point.X; i <= right_point.X; i++)
            {
                if (left_point.Y != (map.Height - 1) && old_color == map.GetPixel(i, left_point.Y + 1))
                    tmp_fill(p, new Point(i, left_point.Y + 1), map, old_color);
                if (left_point.Y != 0 && old_color == map.GetPixel(i, left_point.Y - 1))
                    tmp_fill(p, new Point(i, left_point.Y - 1), map, old_color);
            }
            area.Invalidate();
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
