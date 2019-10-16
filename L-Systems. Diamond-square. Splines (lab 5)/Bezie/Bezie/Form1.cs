using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bezie
{
    public partial class Form1 : Form
    {
        Point CurrentPoint; //Current Position
        Point LastPoint;
        Graphics g;
        List<Point> bPoints;
        PointF[] result;
        bool isDraw = false;
        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.Clear(Color.White);
            bPoints = new List<Point>();
        }

        int Fuctorial(int n) 
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }
        float polinom(int i, int n, float t)
        {
            return (Fuctorial(n) / (Fuctorial(i) * Fuctorial(n - i))) * (float)Math.Pow(t, i) * (float)Math.Pow(1 - t, n - i);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            area.Invalidate();
            bPoints.Clear();
        }

        private void Area_MouseDown(object sender, MouseEventArgs e)
        {
            if (radioButton3.Checked)
            {
                CurrentPoint = e.Location;
                bPoints.Add(CurrentPoint);
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(CurrentPoint.X, CurrentPoint.Y, 5, 5));
                area.Invalidate();
            }
            else if (radioButton1.Checked)
            {
                CurrentPoint = e.Location;
                for (int i = 0; i < bPoints.Count; i++)
                    if (Math.Abs(CurrentPoint.X - bPoints[i].X) <= 5 && Math.Abs(CurrentPoint.Y - bPoints[i].Y) <= 5)
                    {
                        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(bPoints[i].X, bPoints[i].Y, 5, 5));
                        bPoints.RemoveAt(i);
                        Draw();
                    }
            } else if (radioButton2.Checked)
            {
                CurrentPoint = e.Location;
                for (int i = 0; i < bPoints.Count; i++)
                    if (Math.Abs(CurrentPoint.X - bPoints[i].X) <= 5 && Math.Abs(CurrentPoint.Y - bPoints[i].Y) <= 5)
                    {
                        var dialogX = new Form2("Введите X");

                        int X = 0;
                        if (dialogX.ShowDialog() == DialogResult.Cancel) return;
                        if (!int.TryParse(dialogX.ResultText, out X)) return;

                        var dialogY = new Form2("Введите Y");

                        int Y = 0;
                        if (dialogY.ShowDialog() == DialogResult.Cancel) return;
                        if (!int.TryParse(dialogY.ResultText, out Y)) return;

                        g.FillEllipse(new SolidBrush(Color.White), new Rectangle(bPoints[i].X, bPoints[i].Y, 5, 5));
                        Point p = new Point(bPoints[i].X + X, bPoints[i].Y + Y);
                        bPoints[i] = p;
                        g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(bPoints[i].X, bPoints[i].Y, 5, 5));
                        Draw();
                    }
            }
        }

        public void Draw() {
            if (!isDraw)
                isDraw = true;
            else
                g.DrawLines(new Pen(Color.White), result);
            int j = 0;
            float step = 0.01f;

            result = new PointF[101];
            for (float t = 0; t < 1; t += step)
            {
                float ytmp = 0;
                float xtmp = 0;
                for (int i = 0; i < bPoints.Count; i++)
                {
                    float b = polinom(i, bPoints.Count - 1, t); 
                    xtmp += bPoints[i].X * b;
                    ytmp += bPoints[i].Y * b;
                }
                result[j] = new PointF(xtmp, ytmp);
                j++;

            }
            g.DrawLines(new Pen(Color.Black), result);
            area.Invalidate();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Draw();
        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
