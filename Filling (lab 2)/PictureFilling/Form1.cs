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
            g.FillRectangle(new SolidBrush(Color.Azure), 0, 0, area.Width, area.Height);
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
            if (checkBox2.Checked) fill_by_pic();
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
            g.FillRectangle(new SolidBrush(Color.Azure), 0, 0, area.Width, area.Height);
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
            area.Invalidate();
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

        private void fill_by_pic()
        {
            Bitmap map = area.Image as Bitmap;
            Color old_color = map.GetPixel(CurrentPoint.X, CurrentPoint.Y);
            fill_pic(CurrentPoint, old_color, map, 0, 0);
        }

        private void fill_pic(Point TempCurrentPoint, Color old_color, Bitmap map, int i, int j)
        {
            Point left_point = TempCurrentPoint;
            while (left_point.X != 0 && old_color == map.GetPixel(left_point.X - 1, left_point.Y))
                left_point.X -= 1;

            int temp_j = pic.Width - (TempCurrentPoint.X - left_point.X) % pic.Width - 1;//пиксел картинки
            for (int r = left_point.X; r < TempCurrentPoint.X; r++)
            {
                map.SetPixel(r, TempCurrentPoint.Y, pic.GetPixel((temp_j + r - left_point.X) % pic.Width, i % pic.Height));
                area.Invalidate();
            }

            Point right_point = TempCurrentPoint;
            while (right_point.X != (map.Width - 1) && old_color == map.GetPixel(right_point.X + 1, right_point.Y))
                right_point.X += 1;

            for (int r = TempCurrentPoint.X; r <= right_point.X; r++)
            {
                map.SetPixel(r, TempCurrentPoint.Y, pic.GetPixel((j + r - TempCurrentPoint.X) % pic.Width, i % pic.Height));
                area.Invalidate();
            }

            for (int r = TempCurrentPoint.X; r <= right_point.X; r++)
            {
                if (right_point.Y != (map.Height - 1) && old_color == map.GetPixel(r, left_point.Y + 1))
                    fill_pic(new Point(r, right_point.Y + 1), old_color, map, (i + 1) % pic.Height, (j + r - TempCurrentPoint.X) % pic.Width);
                if (right_point.Y != 0 && old_color == map.GetPixel(r, right_point.Y - 1))
                    fill_pic(new Point(r, right_point.Y - 1), old_color, map, (i == 0) ? (pic.Height - 1) : (i - 1), (j + r - TempCurrentPoint.X) % pic.Width);
            }

            for (int r = left_point.X; r < TempCurrentPoint.X; r++)
            {
                if (left_point.Y != (map.Height - 1) && old_color == map.GetPixel(r, left_point.Y + 1))
                    fill_pic(new Point(r, left_point.Y + 1), old_color, map, (i + 1) % pic.Height, (temp_j + r - left_point.X) % pic.Width);
                if (left_point.Y != 0 && old_color == map.GetPixel(r, left_point.Y - 1))
                    fill_pic(new Point(r, left_point.Y - 1), old_color, map, (i == 0) ? (pic.Height - 1) : (i - 1), (temp_j + r - left_point.X) % pic.Width);
            }
            area.Invalidate();
        }

        private void openbutton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pic = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
