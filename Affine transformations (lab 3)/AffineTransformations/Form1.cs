using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations
{
    public partial class Form1 : Form
    {
        Point CurrentPoint; //Current Position
        Point LastPoint;
        Graphics g;
        List<Point> polyPoints;
        bool first = true;
        bool can_draw = true;

        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.Clear(Color.White);
            this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true;
            polyPoints = new List<Point>();

            lineButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            dotButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
            polygonButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);
        }

        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            can_draw = true;
            polyPoints.Clear();
        }

        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            CurrentPoint = e.Location;
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.S)
            {
                g.DrawLine(new Pen(Color.Black), polyPoints[0], polyPoints[polyPoints.Count - 1]);
                first = true;
                can_draw = false;
                area.Invalidate();
            }
        }

        Point mass_center()
        {
            int size = polyPoints.Count;
            int x = 0, y = 0;
            for (int i = 0; i < size; i++)
            {
                x += polyPoints[i].X;
                y += polyPoints[i].Y;
            }
            return new Point(x / size, y / size);
        }

        private void area_MouseUp(object sender, MouseEventArgs e)
        {
            Pen p = new Pen(Color.Black);
            Pen r = new Pen(Color.Red);
            if (lineButton.Checked)
            {
                LastPoint = e.Location;
                if (lineOptionsBox.SelectedIndex == 2 && polyPoints.Count > 1)
                {
                    Point A = new Point(CurrentPoint.X, CurrentPoint.Y);
                    Point B = new Point(LastPoint.X, LastPoint.Y);
                    Point C = new Point(this.polyPoints[polyPoints.Count - 2].X, this.polyPoints[polyPoints.Count - 2].Y);
                    Point D = new Point(this.polyPoints[polyPoints.Count - 1].X, this.polyPoints[polyPoints.Count - 1].Y);

                    g.DrawLine(p, A, B);

                    bool f1 = false, f2 = false;
                    if (RightCheck(A, B, C) && !(RightCheck(A, B, D)))
                    {
                        f1 = true;
                    }
                    if (!(RightCheck(A, B, C)) && (RightCheck(A, B, D)))
                    {
                        f1 = true;
                    }

                    if (RightCheck(C, D, A) && !(RightCheck(C, D, B)))
                    {
                        f2 = true;
                    }
                    if (!(RightCheck(C, D, A)) && (RightCheck(C, D, B)))
                    {
                        f2 = true;
                    }

                    if (f1 == true && f2 == true)
                    {
                        label3.Text = "cross";
                    }
                    else
                    {
                        label3.Text = "no cross";
                    }

                    /*
                    g.DrawLine(p, CurrentPoint, LastPoint);

                    double a1 = (CurrentPoint.Y - LastPoint.Y) / (CurrentPoint.X - LastPoint.X);
                    double a2 = (polyPoints[0].Y - polyPoints[1].Y) / (polyPoints[0].X - polyPoints[1].X);

                    double b1 = CurrentPoint.Y - a1 * CurrentPoint.X;
                    double b2 = polyPoints[0].Y - a2 * polyPoints[0].X;

                    int x = (int)((b2 - b1) / (a1 - a2));


                    if (((x < Math.Max(CurrentPoint.X, polyPoints[0].X)) || (x > Math.Min(LastPoint.X, polyPoints[1].X)))
                        || ((x < Math.Max(polyPoints[0].X, CurrentPoint.X)) || (x > Math.Min(polyPoints[1].X, LastPoint.X))))
                    {
                        x = (int)(-((CurrentPoint.X * LastPoint.Y - LastPoint.X * CurrentPoint.Y) * (polyPoints[1].X - polyPoints[0].X) - (polyPoints[0].X * polyPoints[1].Y - polyPoints[1].X * polyPoints[0].Y) * (LastPoint.X - CurrentPoint.X)) / ((CurrentPoint.Y - LastPoint.Y) * (polyPoints[1].X - polyPoints[0].X) - (polyPoints[0].Y - polyPoints[1].Y) * (LastPoint.X - CurrentPoint.X)));
                        int y = ((polyPoints[0].Y - polyPoints[1].Y) * (-x) - (polyPoints[0].X * polyPoints[1].Y - polyPoints[1].X * polyPoints[0].Y)) / (polyPoints[1].X - polyPoints[0].X);
                        g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(x, y, 3, 3));

                    }*/
                    area.Invalidate();
                }
                else if (lineOptionsBox.SelectedIndex == 3 && polyPoints.Count > 1)
                {

                    int ox = this.polyPoints.First().X;
                    int oy = this.polyPoints.First().Y;
                    int xa = this.polyPoints.ElementAt(1).X;
                    int ya = this.polyPoints.ElementAt(1).Y;
                    int xb = this.CurrentPoint.X;
                    int yb = this.CurrentPoint.Y;

                    int oxm = 0;
                    int oym = 0;
                    int xam = xa - ox;
                    int yam = ya - oy;
                    int xbm = xb - ox;
                    int ybm = yb - oy;

                    /*
                    double sinB = yb / Math.Sqrt((xb - ox) ^ 2 + (yb - oy) ^ 2);
                    double sinA = ya / Math.Sqrt((xa - ox) ^ 2 + (ya - oy) ^ 2);
                    double cosA = xa / Math.Sqrt((xa - ox) ^ 2 + (ya - oy) ^ 2);
                    double cosB = xb / Math.Sqrt((xb - ox) ^ 2 + (yb - oy) ^ 2);*/


                    if ((ybm * xam - xbm * yam) > 0)
                    {
                        g.FillEllipse(new SolidBrush(Color.Blue), new Rectangle(this.CurrentPoint.X, this.CurrentPoint.Y, 3, 3));
                        label3.Text = "right";
                    }
                    else if ((ybm * xam - xbm * yam) < 0)
                    {
                        g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(this.CurrentPoint.X, this.CurrentPoint.Y, 3, 3));
                        label3.Text = "left";
                    }
                    else
                    {
                        label3.Text = "No";
                    }
                    area.Invalidate();
                }

                else if (lineOptionsBox.SelectedIndex == 4 && polyPoints.Count > 1)
                {

                    int ox = this.polyPoints.First().X;
                    int oy = this.polyPoints.First().Y;
                    int xa = this.polyPoints.ElementAt(1).X;
                    int ya = this.polyPoints.ElementAt(1).Y;
                    
                    for (int i = 1; i < area.Width; i += 5)
                    {
                        for (int j = 1; j < area.Height; j += 5)
                        {
                            int xb = i;//-this.CurrentPoint.X;
                            int yb = j;//-this.CurrentPoint.Y;

                            int oxm = 0;
                            int oym = 0;
                            int xam = xa - ox;
                            int yam = ya - oy;
                            int xbm = xb - ox;
                            int ybm = yb - oy;

                            /*
                            double sinB = yb / Math.Sqrt((xb - ox) ^ 2 + (yb - oy) ^ 2);
                            double sinA = ya / Math.Sqrt((xa - ox) ^ 2 + (ya - oy) ^ 2);
                            double cosA = xa / Math.Sqrt((xa - ox) ^ 2 + (ya - oy) ^ 2);
                            double cosB = xb / Math.Sqrt((xb - ox) ^ 2 + (yb - oy) ^ 2);*/


                            if ((ybm * xam - xbm * yam) > 0)
                            {
                                g.FillEllipse(new SolidBrush(Color.Blue), new Rectangle(i, j, 3, 3));
                                label3.Text = "right";
                            }
                            else if ((ybm * xam - xbm * yam) < 0)
                            {
                                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(i, j, 3, 3));
                                label3.Text = "left";
                            }
                            else
                            {
                                label3.Text = "No";
                            }
                            area.Invalidate();
                        }
                    }
                }
                else
                {
                    polyPoints.Clear();
                    g.DrawLine(p, CurrentPoint, LastPoint);
                    polyPoints.Add(CurrentPoint);
                    polyPoints.Add(LastPoint);
                    area.Invalidate();
                }
            }
            else if (dotButton.Checked)
            {
                LastPoint = e.Location;
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(LastPoint.X, LastPoint.Y, 3, 3));
                area.Invalidate();
            }

            else if (polygonButton.Checked)
            {
                if (polygonOptionsBox.SelectedIndex == 2 && polyPoints.Count > 0)
                {
                    var dialogX = new InputBox("Введите угол");

                    int alpha = 0;
                    if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                    if (!int.TryParse(dialogX.ResultText, out alpha)) return;

                    LastPoint = e.Location;
                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[polyPoints.Count - 1]);
                    for (int i = 0; i < polyPoints.Count - 1; i++)
                        g.DrawLine(new Pen(Color.White), polyPoints[i], polyPoints[i + 1]);

                    for (int i = 0; i < polyPoints.Count; i++)
                    {
                        if (i != polyPoints.Count - 1)
                        {
                            polyPoints[i] = rotate(LastPoint, alpha, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], rotate(LastPoint, alpha, polyPoints[i + 1]));
                        }
                        else
                        {
                            polyPoints[i] = rotate(LastPoint, alpha, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], polyPoints[0]);
                        }
                    }
                    area.Invalidate();
                }
                else if (polygonOptionsBox.SelectedIndex == 4 && polyPoints.Count > 0)
                {
                    var dialogX = new InputBox("Введите коэффициент X сжатия/растяжения");
                    var dialogY = new InputBox("Введите коэффициент Y сжатия/растяжения");

                    double kx = 0.0, ky = 0.0;
                    if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                    if (!double.TryParse(dialogX.ResultText, out kx)) return;
                    if (dialogY.ShowDialog() == DialogResult.Cancel) return;
                    if (!double.TryParse(dialogY.ResultText, out ky)) return;

                    LastPoint = e.Location;
                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[polyPoints.Count - 1]);
                    for (int i = 0; i < polyPoints.Count - 1; i++)
                        g.DrawLine(new Pen(Color.White), polyPoints[i], polyPoints[i + 1]);

                    for (int i = 0; i < polyPoints.Count; i++)
                    {
                        if (i != polyPoints.Count - 1)
                        {
                            polyPoints[i] = scale(LastPoint, kx, ky, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], scale(LastPoint, kx, ky, polyPoints[i + 1]));
                        }
                        else
                        {
                            polyPoints[i] = scale(LastPoint, kx, ky, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], polyPoints[0]);
                        }
                    }
                    area.Invalidate();
                }
                // Check convex polygon(RightCheck)
                else if (polygonOptionsBox.SelectedIndex == 5 && polyPoints.Count > 0)
                {
                    LastPoint = e.Location;

                    Point P = CurrentPoint;//new Point(a, b);
                    int c = 0;
                    Point start = this.polyPoints.First();
                    Point old = this.polyPoints.First();
                    for (int i = 1; i < polyPoints.Count(); i++)
                    {
                       
                        if (this.RightCheck(old, this.polyPoints.ElementAt(i), P) == true)
                        {
                            c += 1;

                        }
                        old = this.polyPoints.ElementAt(i);
                    }
                    if (this.RightCheck(old, start, P) == true)
                    {
                        c += 1;
                    }

                    if (c == 0 || c == this.polyPoints.Count())
                    {
                        g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(P.X, P.Y, 4, 4));
                    }
                    else
                    {
                        g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(P.X, P.Y, 4, 4));
                    }
                    area.Invalidate();
                }

                // Check convex polygon(RightCheckFilling)
                else if (polygonOptionsBox.SelectedIndex == 6 && polyPoints.Count > 0)
                {
                    LastPoint = e.Location;

                    for (int a = 1; a < area.Width; a += 5)
                    {
                        for (int b = 1; b < area.Height; b += 5)
                        {
                            Point P = new Point(a, b);
                            int c = 0;
                            Point start = this.polyPoints.First();

                            Point old = this.polyPoints.First();
                            for (int i = 1; i < polyPoints.Count(); i++)
                            {

                                if (this.RightCheck(old, this.polyPoints.ElementAt(i), P) == true)
                                {
                                    c += 1;
                                }
                                old = this.polyPoints.ElementAt(i);
                            }

                            if (this.RightCheck(old, start, P) == true)
                                c += 1;

                            if (c == 0 || c == this.polyPoints.Count())
                            {
                                g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(P.X, P.Y, 4, 4));
                            }
                            else
                            {
                                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(P.X, P.Y, 4, 4));
                            }


                            area.Invalidate();
                        }
                    }
                }
                else if (polygonOptionsBox.SelectedIndex == 7 && polyPoints.Count > 1)
                {
                    int count_cross = 0;
                    Point P = CurrentPoint;//new Point(a, b);
                    Point start = this.polyPoints.First();
                    Point old = this.polyPoints.First();
                    Point D = new Point(area.Width - 1, P.Y);
                    for (int i = 1; i < polyPoints.Count(); i++)
                    {
                        
                        if (this.Check_Cross(old, this.polyPoints.ElementAt(i), P, D) == true)
                        {
                            count_cross += 1;
                        }
                        old = this.polyPoints.ElementAt(i);
                    }

                    if (this.Check_Cross(old, start, P, D) == true)
                    {
                        count_cross += 1;
                    }
                    if (count_cross % 2 == 1)
                    {
                        g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(P.X, P.Y, 4, 4));
                    }
                    else
                    {
                        g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(P.X, P.Y, 4, 4));
                    }
                    area.Invalidate();

                }
                else if (polygonOptionsBox.SelectedIndex == 8 && polyPoints.Count > 1)
                {
                    for (int a = 1; a < area.Width; a += 5)
                    {
                        for (int b = 1; b < area.Height; b += 5)
                        {
                            int count_cross = 0;
                            Point P = new Point(a, b);
                            Point start = this.polyPoints.First();
                            Point old = this.polyPoints.First();
                            Point D = new Point(area.Width - 1, P.Y);
                            for (int i = 1; i < polyPoints.Count(); i++)
                            {
                                
                                if (this.Check_Cross(old, this.polyPoints.ElementAt(i), P, D) == true)
                                {
                                    count_cross += 1;
                                }
                                old = this.polyPoints.ElementAt(i);
                            }

                            if (this.Check_Cross(old, start, P, D) == true)
                            {
                                count_cross += 1;
                            }
                            if (count_cross % 2 == 1)
                            {
                                g.FillEllipse(new SolidBrush(Color.Green), new Rectangle(P.X, P.Y, 4, 4));
                            }
                            else
                            {
                                g.FillEllipse(new SolidBrush(Color.Red), new Rectangle(P.X, P.Y, 4, 4));
                            }
                            area.Invalidate();

                        }
                    }
                }
                if (can_draw)
                {
                    if (first)
                    {
                        polyPoints.Clear();
                        LastPoint = e.Location;
                        polyPoints.Add(LastPoint);
                        first = false;
                    }
                    else
                    {
                        g.DrawLine(p, LastPoint, CurrentPoint);
                        LastPoint = CurrentPoint;
                        polyPoints.Add(CurrentPoint);
                        area.Invalidate();
                    }
                }
            }
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, area.Width, area.Height);
            polyPoints.Clear();
            can_draw = true;

            first = true;
        }

        private Point rotate(Point center, int angle, Point old_point)
        {
            double[,] move_mat1 = { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] move_mat2 = { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            double cos = Math.Cos(Math.PI / 180 * angle);
            double sin = Math.Sin(Math.PI / 180 * angle);
            double[,] rotation_mat = { { cos, sin, 0 }, { -sin, cos, 0 }, { 0, 0, 1 } };

            Point new_point = new Point(0, 0);

            multiplication(old_point, move_mat1, ref new_point);
            multiplication(new_point, rotation_mat, ref new_point);
            multiplication(new_point, move_mat2, ref new_point);

            return new_point;
        }

        private Point scale(Point center, double kx, double ky, Point old_point)
        {
            double[,] move_mat1 = { { 1, 0, 0 }, { 0, 1, 0 }, { -center.X, -center.Y, 1 } };
            double[,] move_mat2 = { { 1, 0, 0 }, { 0, 1, 0 }, { center.X, center.Y, 1 } };
            double[,] scale_mat = { { 1 / kx, 0, 0 }, { 0, 1 / ky, 0 }, { 0, 0, 1 } };

            Point new_point = new Point(0, 0);

            multiplication(old_point, move_mat1, ref new_point);
            multiplication(new_point, scale_mat, ref new_point);
            multiplication(new_point, move_mat2, ref new_point);

            return new_point;
        }
        private void multiplication(Point point, double[,] mat, ref Point new_point)
        {
            double x = point.X;
            double y = point.Y;
            double[,] vec = { { 0, 0, 0 }, { x, y, 1 }, { 0, 0, 0 } };
            double[,] res = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    for (int k = 0; k < 3; k++)
                        res[i, j] += vec[i, k] * mat[k, j];
            new_point.X = (int)res[1, 0];
            new_point.Y = (int)res[1, 1];
        }

        private Point move(Point old_point, int x, int y)
        {
            double[,] mat = { { 1, 0, 0 }, { 0, 1, 0 }, { x, y, 1 } };
            Point new_point = new Point(0, 0);
            multiplication(old_point, mat, ref new_point);
            return new_point;
        }

        private void lineOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lineButton.Checked && polyPoints.Count > 0)
            {
                if (lineOptionsBox.SelectedIndex == 0)
                {
                    var dialogX = new InputBox("Введите смещение по X (целое число)");
                    var dialogY = new InputBox("Введите смещение по Y (целое число)");
                    int dx = 0, dy = 0;
                    if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                    if (!int.TryParse(dialogX.ResultText, out dx)) return;
                    if (dialogY.ShowDialog() == DialogResult.Cancel) return;
                    if (!int.TryParse(dialogY.ResultText, out dy)) return;

                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[1]);
                    polyPoints[0] = move(polyPoints[0], dx, dy);
                    polyPoints[1] = move(polyPoints[1], dx, dy);
                    g.DrawLine(new Pen(Color.Black), polyPoints[0], polyPoints[1]);
                    area.Invalidate();
                }
                else if (lineOptionsBox.SelectedIndex == 1)
                {
                    Point center = new Point((polyPoints[0].X + polyPoints[1].X) / 2, (polyPoints[0].Y + polyPoints[1].Y) / 2);
                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[1]);
                    polyPoints[0] = rotate(center, 90, polyPoints[0]);
                    polyPoints[1] = rotate(center, 90, polyPoints[1]);
                    g.DrawLine(new Pen(Color.Black), polyPoints[0], polyPoints[1]);
                    area.Invalidate();
                }
                else if (lineOptionsBox.SelectedIndex == 3)
                {

                }
                else if (lineOptionsBox.SelectedIndex == 2)
                {

                }
            }
        }

        private void PolygonOptionsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (polygonButton.Checked && polyPoints.Count > 0)
            {
                if (polygonOptionsBox.SelectedIndex == 0)
                {
                    var dialogX = new InputBox("Введите смещение по X (целое число)");
                    var dialogY = new InputBox("Введите смещение по Y (целое число)");
                    int dx = 0, dy = 0;
                    if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                    if (!int.TryParse(dialogX.ResultText, out dx)) return;
                    if (dialogY.ShowDialog() == DialogResult.Cancel) return;
                    if (!int.TryParse(dialogY.ResultText, out dy)) return;

                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[polyPoints.Count - 1]);
                    for (int i = 0; i < polyPoints.Count - 1; i++)
                        g.DrawLine(new Pen(Color.White), polyPoints[i], polyPoints[i + 1]);

                    for (int i = 0; i < polyPoints.Count; i++)
                    {
                        if (i != polyPoints.Count - 1)
                        {
                            polyPoints[i] = move(polyPoints[i], dx, dy);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], move(polyPoints[i + 1], dx, dy));
                        }
                        else
                        {
                            polyPoints[i] = move(polyPoints[i], dx, dy);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], polyPoints[0]);
                        }
                    }
                    area.Invalidate();
                }
                else if (polygonOptionsBox.SelectedIndex == 1 && polyPoints.Count > 0)
                {

                    var dialogX = new InputBox("Введите угол");

                    int alpha = 0;
                    if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                    if (!int.TryParse(dialogX.ResultText, out alpha)) return;

                    LastPoint = mass_center();
                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[polyPoints.Count - 1]);
                    for (int i = 0; i < polyPoints.Count - 1; i++)
                        g.DrawLine(new Pen(Color.White), polyPoints[i], polyPoints[i + 1]);

                    for (int i = 0; i < polyPoints.Count; i++)
                    {
                        if (i != polyPoints.Count - 1)
                        {
                            polyPoints[i] = rotate(LastPoint, alpha, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], rotate(LastPoint, alpha, polyPoints[i + 1]));
                        }
                        else
                        {
                            polyPoints[i] = rotate(LastPoint, alpha, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], polyPoints[0]);
                        }
                    }
                    area.Invalidate();

                }
                else if (polygonOptionsBox.SelectedIndex == 3 && polyPoints.Count > 0)
                {
                    var dialogX = new InputBox("Введите коэффициент X сжатия/растяжения");
                    var dialogY = new InputBox("Введите коэффициент Y сжатия/растяжения");

                    double kx = 0.0, ky = 0.0;
                    if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                    if (!double.TryParse(dialogX.ResultText, out kx)) return;
                    if (dialogY.ShowDialog() == DialogResult.Cancel) return;
                    if (!double.TryParse(dialogY.ResultText, out ky)) return;

                    LastPoint = mass_center();
                    g.DrawLine(new Pen(Color.White), polyPoints[0], polyPoints[polyPoints.Count - 1]);
                    for (int i = 0; i < polyPoints.Count - 1; i++)
                        g.DrawLine(new Pen(Color.White), polyPoints[i], polyPoints[i + 1]);

                    for (int i = 0; i < polyPoints.Count; i++)
                    {
                        if (i != polyPoints.Count - 1)
                        {
                            polyPoints[i] = scale(LastPoint, kx, ky, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], scale(LastPoint, kx, ky, polyPoints[i + 1]));
                        }
                        else
                        {
                            polyPoints[i] = scale(LastPoint, kx, ky, polyPoints[i]);
                            g.DrawLine(new Pen(Color.Black), polyPoints[i], polyPoints[0]);
                        }
                    }
                    area.Invalidate();
                }

            }
        }


        private bool RightCheck(Point O, Point A, Point B)
        {
            int ox = O.X;
            int oy = O.Y;
            int xa = A.X;
            int ya = A.Y;
            int xb = B.X;
            int yb = B.Y;

            int xam = xa - ox;
            int yam = ya - oy;
            int xbm = xb - ox;
            int ybm = yb - oy;

            /*
            double sinB = yb / Math.Sqrt((xb - ox) ^ 2 + (yb - oy) ^ 2);
            double sinA = ya / Math.Sqrt((xa - ox) ^ 2 + (ya - oy) ^ 2);
            double cosA = xa / Math.Sqrt((xa - ox) ^ 2 + (ya - oy) ^ 2);
            double cosB = xb / Math.Sqrt((xb - ox) ^ 2 + (yb - oy) ^ 2);*/


            if ((ybm * xam - xbm * yam) >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }





        private void RadioOrientationButton_CheckedChange(object sender, EventArgs e)
        {
            if (this.polyPoints.Capacity < 4)
            {
                this.label3.Text = "Нет линии";
            }
            else
            {

                this.label3.Text = "Линия есть";
            }
        }


        private bool Check_Cross(Point A, Point B, Point C, Point D)
        {
            /*Point A = new Point(CurrentPoint.X, CurrentPoint.Y);
            Point B = new Point(LastPoint.X, LastPoint.Y);
            Point C = new Point(this.polyPoints[polyPoints.Count - 2].X, this.polyPoints[polyPoints.Count - 2].Y);
            Point D = new Point(this.polyPoints[polyPoints.Count - 1].X, this.polyPoints[polyPoints.Count - 1].Y);
            
            g.DrawLine(p, A, B);*/

            bool f1 = false, f2 = false;
            if (RightCheck(A, B, C) && !(RightCheck(A, B, D)))
            {
                f1 = true;
            }
            if (!(RightCheck(A, B, C)) && (RightCheck(A, B, D)))
            {
                f1 = true;
            }

            if (RightCheck(C, D, A) && !(RightCheck(C, D, B)))
            {
                f2 = true;
            }
            if (!(RightCheck(C, D, A)) && (RightCheck(C, D, B)))
            {
                f2 = true;
            }

            if (f1 == true && f2 == true)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
