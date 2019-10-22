using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransformations3D
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        List<Point3D> points3d;
        public static double width, height;
        List<Rib> shape; // all ribs of current shape
        public static float ribLength = 100;
        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            width = area.Width;
            height = area.Height;
            shape = new List<Rib>();
            graphics = Graphics.FromImage(area.Image);
            graphics.Clear(Color.White);
        }
       
        public void createTetrahedron()
        {
            float cubeSide = (float)(ribLength / Math.Sqrt(2));

            Point3D vertex1 = new Point3D(0, 0, 0);
            Point3D vertex2 = new Point3D(vertex1.X + cubeSide, vertex1.Y + cubeSide, vertex1.Z);
            Point3D vertex3 = new Point3D(vertex1.X + cubeSide, vertex1.Y, vertex1.Z - cubeSide);
            Point3D vertex4 = new Point3D(vertex1.X, vertex1.Y + cubeSide, vertex1.Z - cubeSide);

            shape.Add(new Rib(vertex1, vertex3));
            shape.Add(new Rib(vertex1, vertex2));
            shape.Add(new Rib(vertex1, vertex4));
            shape.Add(new Rib(vertex2, vertex3));
            shape.Add(new Rib(vertex2, vertex4));
            shape.Add(new Rib(vertex4, vertex3));
        }

        public void createCube()
        {
            float ridLength = 100;
            float cubeSide = (float)(ridLength / Math.Sqrt(2));

            Point3D vertex1 = new Point3D(0, 0, 0);
            Point3D vertex2 = new Point3D(vertex1.X + cubeSide, vertex1.Y, vertex1.Z);
            Point3D vertex3 = new Point3D(vertex1.X + cubeSide, vertex1.Y + cubeSide, vertex1.Z);
            Point3D vertex4 = new Point3D(vertex1.X, vertex1.Y + cubeSide, vertex1.Z);
            Point3D vertex5 = new Point3D(vertex1.X, vertex1.Y, vertex1.Z - cubeSide);
            Point3D vertex6 = new Point3D(vertex1.X + cubeSide, vertex1.Y, vertex1.Z - cubeSide);
            Point3D vertex7 = new Point3D(vertex1.X + cubeSide, vertex1.Y + cubeSide, vertex1.Z - cubeSide);
            Point3D vertex8 = new Point3D(vertex1.X, vertex1.Y + cubeSide, vertex1.Z - cubeSide);

            shape.Add(new Rib(vertex1, vertex2));
            shape.Add(new Rib(vertex1, vertex5));
            shape.Add(new Rib(vertex1, vertex4));
            shape.Add(new Rib(vertex2, vertex3));
            shape.Add(new Rib(vertex2, vertex6));
            shape.Add(new Rib(vertex4, vertex3));
            shape.Add(new Rib(vertex7, vertex3));
            shape.Add(new Rib(vertex4, vertex8));
            shape.Add(new Rib(vertex5, vertex8));
            shape.Add(new Rib(vertex5, vertex6));
            shape.Add(new Rib(vertex7, vertex6));
            shape.Add(new Rib(vertex7, vertex8));
        }

        public void drawShape()
        {
            if (shape.Count != 0)
            {
                Pen pen = new Pen(Color.Black);
                foreach (Rib rib in shape)
                    graphics.DrawLine(pen, rib.firstPoint.GetPointF(), rib.secondPoint.GetPointF());
            }
            area.Invalidate();
        }

        public void redraw()
        {
            graphics.Clear(Color.White);
            drawShape();
            area.Invalidate();
        }

        private void multiplication(Point3D point, float[,] mat, Point3D new_point)
        {
            float x = point.X;
            float y = point.Y;
            float z = point.Z;

            float[,] vec = { { 0, 0, 0, x }, { 0, 0, 0, y }, { 0, 0, 0, z }, { 0, 0, 0, 1 } };
            float[,] res = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    for (int k = 0; k < 4; k++)
                        res[i, j] += mat[i, k] * vec[k, j];
            new_point.X = res[0, 3];
            new_point.Y = res[1, 3];
            new_point.Z = res[2, 3];
        }

        private Point3D shift(Point3D old_point, int x, int y, int z)
        {
            float[,] mat = { { 1, 0, 0 , x}, { 0, 1, 0 , y}, { 0, 0, 1, z}, { 0, 0, 0, 1} };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        public class Point3D
        {
            public float X, Y, Z;

            public Point3D(Point3D point)
            {
                this.X = point.X; this.Y = point.Y; this.Z = point.Z;
            }
            public Point3D(float X, float Y, float Z)
            {
                this.X = X; this.Y = Y; this.Z = Z;
            }

            public PointF GetPointF()
            {
                double cos_a = Math.Cos(Math.PI / 4);
                double sin_a = Math.Sin(Math.PI / 4);
                double cos_b = Math.Cos(Math.PI / 4 + Math.PI / 2);
                double sin_b = Math.Sin(Math.PI / 4 + Math.PI / 2);
                float y = (float)(-(Z * cos_a + X * sin_a) * sin_b + Y * cos_b + height / 2 - ribLength / 2);
                float x = (float)(-Z * sin_a + X * cos_a + width / 2 - ribLength / 2);
                return new PointF(x, y);
            }
        }

        public class Rib
        {
            public Point3D firstPoint;
            public Point3D secondPoint;

            public Rib(Point3D firstPoint, Point3D secondPoint)
            {
                this.firstPoint = firstPoint;
                this.secondPoint = secondPoint;
            }

        }

        public class Face
        {
            public List<Rib> ribs;
            public Face(List<Rib> ribs)
            {
                this.ribs = new List<Rib>(ribs);
            }

        }

        public class Polyhedron
        {
            public List<Face> faces;
            public Polyhedron(List<Face> faces)
            {
                this.faces = new List<Face>(faces);
            }
        }

        private void draw_button_Click(object sender, EventArgs e)
        {
            if (radioTetrahedron.Checked) createTetrahedron();
            else if (radioCube.Checked) createCube();

            drawShape();
        }

        private void shift_button_Click(object sender, EventArgs e)
        {
            int delta_x;
            Int32.TryParse(shift_x.Text, out delta_x);
            int delta_y;
            Int32.TryParse(shift_y.Text, out delta_y);
            int delta_z;
            Int32.TryParse(shift_z.Text, out delta_z);
            foreach (Rib rib in shape) {
                //Console.WriteLine(rib.firstPoint.GetPointF().X.ToString());
                rib.firstPoint = new Point3D(shift(rib.firstPoint, delta_x, delta_y, delta_z));
               // Console.WriteLine(rib.firstPoint.GetPointF().X.ToString());
                rib.secondPoint = new Point3D(shift(rib.secondPoint, delta_x, delta_y, delta_z));
            }

            redraw();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            shape.Clear();
            graphics.Clear(Color.White);
            area.Invalidate();
        }
                
    }
}
