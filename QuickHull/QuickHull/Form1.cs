using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickHull
{
    public partial class Form1 : Form
    {
        Graphics g;
        List<Point> points;
        HashSet<Point> hull;
        HashSet<Point> start_points;

        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.Clear(Color.White);
            points = new List<Point>();
            start_points = new HashSet<Point>();
            hull = new HashSet<Point>();
        }

        private void area_MouseClick(object sender, MouseEventArgs e)
        {
            g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(e.X - 2, e.Y - 2, 4, 4));
            start_points.Add(new Point(e.X, e.Y));

            if (start_points.Count() > 2)
            {
                builder.Enabled = true;
            }
            area.Invalidate();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, area.Width, area.Height);
            start_points.Clear();
            points.Clear();
            hull.Clear();
        }

        private void builder_Click(object sender, EventArgs e)
        {
            // finding left and right points
            points = start_points.ToList<Point>();
            Point min_point = points[0];
            Point max_point = points[0];
            for (int i = 1; i < points.Count; i++)
            {
                if (points[i].X < min_point.X)
                    min_point = points[i];
                if (points[i].X > max_point.X)
                    max_point = points[i];
            }

            quickHull(min_point, max_point, points_relatively_to_line(min_point, max_point, points, 1), 1);
            quickHull(min_point, max_point, points_relatively_to_line(min_point, max_point, points, -1), -1);
        }

        List<Point> points_relatively_to_line(Point left, Point right, List<Point> points, int side)
        {
            List<Point> result = new List<Point>();
            for (int i = 0; i < points.Count; i++)
                if (findSide(left, right, points[i]) == side || findSide(left, right, points[i]) == 0)
                    result.Add(points[i]);

           return result;
        }

        int lineDist(Point p1, Point p2, Point p)
        {
            return Math.Abs((p.X - p1.X) * (p2.Y - p1.Y) - (p.Y - p1.Y) * (p2.X - p1.X));
        }

        int findSide(Point p1, Point p2, Point p)
        {
            int val = (p.X - p1.X) * (p2.Y - p1.Y) - (p.Y - p1.Y) * (p2.X - p1.X);

            if (val > 0)
                return 1;
            if (val < 0)
                return -1;
            return 0;
        }

        // 1 = right than line between points 
        // -1 = left than line between points 
        private void quickHull(Point left, Point right, List<Point> points, int side)
        {
            if (points.Count == 2)
            {
                hull.Add(left);
                hull.Add(right);
                g.DrawLine(new Pen(Color.Black), left, right);
                area.Invalidate();
                return;
            }

            // finding point with max distance
            int max_dist = 0;
            Point max_point = new Point();
            for (int i = 0; i < points.Count; i++)
            {
                int temp = lineDist(left, right, points[i]);
                if (temp >= max_dist)
                {
                    max_point = points[i];
                    max_dist = temp;
                }
            }

            if (max_dist == 0)
            {
                for (int i = 0; i < points.Count; i++)
                    hull.Add(points[i]);
                g.DrawLine(new Pen(Color.Black), left, right);
                area.Invalidate();
                return;
            }

            // points to the left of the line (upper or lower)
            quickHull(left, max_point, points_relatively_to_line(left, max_point, points, side), side);

            // points to the right of the line (upper or lower)
            quickHull(right, max_point, points_relatively_to_line(right, max_point, points, -side), -side);
        }
    }
}
