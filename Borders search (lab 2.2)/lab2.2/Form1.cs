using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab2._2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        // Поиск координат стартовой точки границы, от середины левого края по всей ширине картинки
        int start_x, start_y;

        private void Button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox2.Image = new Bitmap(ofd.FileName);
                }
                catch // в случае ошибки выводим MessageBox
                {
                    MessageBox.Show("Невозможно открыть выбранный файл", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public List<Point> board = new List<Point>();
        private void Button4_Click(object sender, EventArgs e)
        {
            if (board.Count == 0)
            {
                return;
            }
            Bitmap pic2 = new Bitmap(pictureBox2.Image);
            Bitmap output = new Bitmap(pic2.Width, pic2.Height);
            UInt32 boardPixel = 0xFF000000;
            foreach (Point x in board) {
                pic2.SetPixel(x.X, x.Y, Color.FromArgb((int)boardPixel));
            }

            pictureBox2.Image = pic2;
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap pic = new Bitmap(pictureBox1.Image);
                int i = 5;
                while (i < pic.Width)
                {
                    UInt32 pixel = (UInt32)(pic.GetPixel(i, pic.Height / 2).ToArgb());
                    // Если равен 
                    if (pixel == (UInt32)0xFF000000)
                    {
                        start_x = i;
                        start_y = pic.Height / 2;
                        break;
                    }
                    i++;
                }
            };

            Point start_point = new Point(start_x, start_y);
            bool f = false;
            board.Add(start_point);
            Bitmap input = new Bitmap(pictureBox1.Image);
            n2(start_point);


            void n0(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);
                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    return;
                }

                UInt32 pixel1 = (UInt32)(input.GetPixel(p.X + 1, p.Y - 1).ToArgb());
                UInt32 pixel0 = (UInt32)(input.GetPixel(p.X + 1, p.Y).ToArgb());
                UInt32 pixel7 = (UInt32)(input.GetPixel(p.X + 1, p.Y + 1).ToArgb());
                UInt32 pixel6 = (UInt32)(input.GetPixel(p.X, p.Y + 1).ToArgb());


                if (pixel1 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y - 1);
                    board.Add(new_point);
                    n1(new_point);
                }

                else if (pixel0 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y);
                    board.Add(new_point);
                    n0(new_point);
                }
                else if (pixel7 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y + 1);
                    board.Add(new_point);
                    n7(new_point);
                }

                else if (pixel6 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y + 1);
                    board.Add(new_point);
                    n6(new_point);
                }

            }


            void n1(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);
                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    Console.WriteLine("Good");
                    return;
                }

                UInt32 pixel2 = (UInt32)(input.GetPixel(p.X, p.Y - 1).ToArgb());
                UInt32 pixel1 = (UInt32)(input.GetPixel(p.X + 1, p.Y - 1).ToArgb());
                UInt32 pixel0 = (UInt32)(input.GetPixel(p.X + 1, p.Y).ToArgb());
                UInt32 pixel7 = (UInt32)(input.GetPixel(p.X + 1, p.Y + 1).ToArgb());

                if (pixel2 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y - 1);
                    board.Add(new_point);
                    n2(new_point);
                }

                else if (pixel1 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y - 1);
                    board.Add(new_point);
                    n1(new_point);
                }
                else if (pixel0 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y);
                    board.Add(new_point);
                    n0(new_point);
                }

                else
                {
                    if (pixel7 == (UInt32)0xFF000000)
                    {
                        Point new_point = new Point(p.X + 1, p.Y + 1);
                        board.Add(new_point);
                        n7(new_point);
                    }
                }
            }


            void n2(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);
                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    Console.WriteLine("Good");

                    return;
                }
                f = true;
                UInt32 pixel3 = (UInt32)(input.GetPixel(p.X - 1, p.Y - 1).ToArgb());
                UInt32 pixel2 = (UInt32)(input.GetPixel(p.X, p.Y - 1).ToArgb());
                UInt32 pixel1 = (UInt32)(input.GetPixel(p.X + 1, p.Y - 1).ToArgb());
                UInt32 pixel0 = (UInt32)(input.GetPixel(p.X + 1, p.Y).ToArgb());

                if (pixel3 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y - 1);
                    board.Add(new_point);
                    n3(new_point);
                }

                else if (pixel2 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y - 1);
                    board.Add(new_point);
                    n2(new_point);
                }
                else if (pixel1 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y - 1);
                    board.Add(new_point);
                    n1(new_point);
                }

                else if (pixel0 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y);
                    board.Add(new_point);
                    n0(new_point);
                }

            }

            void n3(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);

                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    Console.WriteLine("Good");

                    return;
                }
                UInt32 pixel4 = (UInt32)(input.GetPixel(p.X - 1, p.Y).ToArgb());
                UInt32 pixel3 = (UInt32)(input.GetPixel(p.X - 1, p.Y - 1).ToArgb());
                UInt32 pixel2 = (UInt32)(input.GetPixel(p.X, p.Y - 1).ToArgb());
                UInt32 pixel1 = (UInt32)(input.GetPixel(p.X + 1, p.Y - 1).ToArgb());

                if (pixel4 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y);
                    board.Add(new_point);
                    n4(new_point);
                }

                else if (pixel3 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y - 1);
                    board.Add(new_point);
                    n3(new_point);
                }
                else if (pixel2 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y - 1);
                    board.Add(new_point);
                    n2(new_point);
                }

                else if (pixel1 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y - 1);
                    board.Add(new_point);
                    n1(new_point);
                }
            }

            void n4(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);


                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    Console.WriteLine("Good");

                    return;
                }
                UInt32 pixel5 = (UInt32)(input.GetPixel(p.X - 1, p.Y + 1).ToArgb());
                UInt32 pixel4 = (UInt32)(input.GetPixel(p.X - 1, p.Y).ToArgb());
                UInt32 pixel3 = (UInt32)(input.GetPixel(p.X - 1, p.Y - 1).ToArgb());
                UInt32 pixel2 = (UInt32)(input.GetPixel(p.X, p.Y - 1).ToArgb());

                if (pixel5 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y + 1);
                    board.Add(new_point);
                    n5(new_point);
                }
                else if (pixel4 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y);
                    board.Add(new_point);
                    n4(new_point);
                }
                else if (pixel3 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y - 1);
                    board.Add(new_point);
                    n3(new_point);
                }

                else if (pixel2 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y - 1);
                    board.Add(new_point);
                    n2(new_point);
                }

            }

            void n5(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);


                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    Console.WriteLine("Good");

                    return;
                }
                UInt32 pixel6 = (UInt32)(input.GetPixel(p.X, p.Y + 1).ToArgb());
                UInt32 pixel5 = (UInt32)(input.GetPixel(p.X - 1, p.Y + 1).ToArgb());
                UInt32 pixel4 = (UInt32)(input.GetPixel(p.X - 1, p.Y).ToArgb());
                UInt32 pixel3 = (UInt32)(input.GetPixel(p.X - 1, p.Y - 1).ToArgb());


                if (pixel6 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y + 1);
                    board.Add(new_point);
                    n6(new_point);
                }

                else if (pixel5 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y + 1);
                    board.Add(new_point);
                    n5(new_point);
                }
                else if (pixel4 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y);
                    board.Add(new_point);
                    n4(new_point);
                }

                else if (pixel3 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y - 1);
                    board.Add(new_point);
                    n3(new_point);
                }

            }


            void n6(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);

                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    Console.WriteLine("Good");

                    return;
                }
                UInt32 pixel7 = (UInt32)(input.GetPixel(p.X + 1, p.Y + 1).ToArgb());
                UInt32 pixel6 = (UInt32)(input.GetPixel(p.X, p.Y + 1).ToArgb());
                UInt32 pixel5 = (UInt32)(input.GetPixel(p.X - 1, p.Y + 1).ToArgb());
                UInt32 pixel4 = (UInt32)(input.GetPixel(p.X - 1, p.Y).ToArgb());

                if (pixel7 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y + 1);
                    board.Add(new_point);
                    n7(new_point);
                }

                else if (pixel6 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y + 1);
                    board.Add(new_point);
                    n6(new_point);
                }
                else if (pixel5 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y + 1);
                    board.Add(new_point);
                    n5(new_point);
                }

                else if (pixel4 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y);
                    board.Add(new_point);
                    n4(new_point);
                }

            }

            void n7(Point p)
            {
                Console.WriteLine("{0},{1}", p.X, p.Y);

                if ((p.X == start_point.X) && (p.Y == start_point.Y) && (f == true))
                {
                    return;
                }

                UInt32 pixel0 = (UInt32)(input.GetPixel(p.X + 1, p.Y).ToArgb());
                UInt32 pixel7 = (UInt32)(input.GetPixel(p.X + 1, p.Y + 1).ToArgb());
                UInt32 pixel6 = (UInt32)(input.GetPixel(p.X, p.Y + 1).ToArgb());
                UInt32 pixel5 = (UInt32)(input.GetPixel(p.X - 1, p.Y + 1).ToArgb());

                if (pixel0 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y);
                    board.Add(new_point);
                    n0(new_point);
                }

                else if (pixel7 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X + 1, p.Y + 1);
                    board.Add(new_point);
                    n7(new_point);
                }
                else if (pixel6 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X, p.Y + 1);
                    board.Add(new_point);
                    n6(new_point);
                }

                else if (pixel5 == (UInt32)0xFF000000)
                {
                    Point new_point = new Point(p.X - 1, p.Y + 1);
                    board.Add(new_point);
                    n5(new_point);
                }

            }
        }
    }
}
