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
            radioButton_ortZ.Checked = true;
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
                int c = 0;
                foreach (Rib rib in shape)
                {
                    pen = new Pen(Color.Black);
                    if (c == 0)
                    {
                        pen = new Pen(Color.Red);
                        c++;
                    }
                    else if (c == 1)
                    {
                        pen = new Pen(Color.Blue);
                        c++;
                    }
                    else if (c == 2)
                    {
                        pen = new Pen(Color.Green);
                        c++;
                    }
                    if (radioButton_ortZ.Checked == true)  graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtZ(), rib.secondPoint.GetPointFOrtZ()); 
                    else if (radioButton_ortX.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtX(), rib.secondPoint.GetPointFOrtX());
                    else if (radioButton_ortY.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtY(), rib.secondPoint.GetPointFOrtY());
                    else if (radioButton_isometr.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFisometr(), rib.secondPoint.GetPointFisometr());
                    else if (radioButton_perspect.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFPerspect(), rib.secondPoint.GetPointFPerspect());
                }
            }
            area.Invalidate();
        }

        public void redraw()
        {
            graphics.Clear(Color.White);
            drawShape();
            area.Invalidate();
        }

        Point3D mass_center()
        {
            int size = shape.Count;
            float x = 0, y = 0, z = 0;
            for (int i = 0; i < size; i++)
            {
                x += (shape[i].firstPoint.X + shape[i].secondPoint.X) / 2;
                y += (shape[i].firstPoint.Y + shape[i].secondPoint.Y) / 2;
                z += (shape[i].firstPoint.Z + shape[i].secondPoint.Z) / 2;
            }
            return new Point3D(x / size, y / size, z / size);
        }

        public void multiplication(Point3D point, float[,] mat, Point3D new_point)
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
            float[,] mat = { { 1, 0, 0, x }, { 0, 1, 0, y }, { 0, 0, 1, z }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D rotateX(Point3D old_point, int angle)
        {
            float sin = (float)Math.Sin(Math.PI / 180 * angle);
            float cos = (float)Math.Cos(Math.PI / 180 * angle);
            float[,] mat = {    { 1, 0, 0, 0        },
                                { 0, cos, -sin, 0   },
                                { 0, sin, cos, 0    },
                                { 0, 0, 0, 1  }};
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D rotateY(Point3D old_point, int angle)
        {
            float sin = (float)Math.Sin(Math.PI / 180 * angle);
            float cos = (float)Math.Cos(Math.PI / 180 * angle);
            float[,] mat = { { cos, 0, sin, 0 }, { 0, 1, 0, 0 }, { -sin, 0, cos, 0 }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D rotateZ(Point3D old_point, int angle)
        {
            float sin = (float)Math.Sin(Math.PI / 180 * angle);
            float cos = (float)Math.Cos(Math.PI / 180 * angle);
            float[,] mat = { { cos, -sin, 0, 0 }, { sin, cos, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D scale(Point3D old_point, float mx, float my, float mz)
        {
            float[,] mat = { { mx, 0, 0, 0 }, { 0, my, 0, 0 }, { 0, 0, mz, 0 }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D reflectionX(Point3D old_point)
        {
            float[,] mat = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, -1, 0 }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D reflectionY(Point3D old_point)
        {
            float[,] mat = { { 1, 0, 0, 0 }, { 0, -1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D reflectionZ(Point3D old_point)
        {
            float[,] mat = { { -1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        public class Point3D
        {
            public float X, Y, Z, C;

            public Point3D(Point3D point)
            {
                this.X = point.X; this.Y = point.Y; this.Z = point.Z;this.C = point.C;
            }
            public Point3D(float X, float Y, float Z)
            {
                this.X = X; this.Y = Y; this.Z = Z; this.C = (float)1.0;
            }
            public Point3D(float X, float Y, float Z,float C)
            {
                this.X = X; this.Y = Y; this.Z = Z;this.C = C;
            }

            public PointF GetPointF()
            {
                double cos_a = Math.Cos(Math.PI / 4);
                double sin_a = Math.Sin(Math.PI / 4);
                double cos_b = Math.Cos(Math.PI / 4 + Math.PI / 2);
                double sin_b = Math.Sin(Math.PI / 4 + Math.PI / 2);
                float y = (float)((Z * cos_a + X * sin_a) * sin_b + Y * cos_b + height / 2 - ribLength / 2);
                float x = (float)(-Z * sin_a + X * cos_a + width / 2 - ribLength / 2);
                return new PointF(x, y);
            }

            public PointF GetPointFOrtZ()
            {

                float[,] mat = {{ 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0,Z, 1 }};
                Point3D new_point = new Point3D(0, 0, 0);
                Point3D old_point = new Point3D(X, Y, Z);
                multiplication( mat, old_point, new_point);
                return new PointF((float)(new_point.X + width / 2 - ribLength / 2), (float)((height - new_point.Y) - height / 2 + ribLength / 2));
            }

            public PointF GetPointFOrtY()
            {

                float[,] mat = {{ 1, 0, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 1, 0 },
                                { 0, Y,0, 1 }};
                Point3D new_point = new Point3D(0, 0, 0);
                Point3D old_point = new Point3D(X, Y, Z);
                multiplication(old_point, mat, new_point);
                return new PointF((float)(new_point.X + width / 2 - ribLength / 2), (float)((height - new_point.Z) - height / 2 + ribLength / 2));
            }

            public PointF GetPointFOrtX()
            {

                float[,] mat = {{ 0, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 1, 0 },
                                { X, 0, 0, 1 }};
                Point3D new_point = new Point3D(0, 0, 0);
                Point3D old_point = new Point3D(X, Y, Z);
                multiplication(old_point, mat, new_point);
                return new PointF((float)(new_point.Z + width / 2 - ribLength / 2), (float)((height - new_point.Y) - height / 2 + ribLength / 2));
            }

            public PointF GetPointFisometr()
            {
                Point3D new_point = new Point3D(0, 0, 0);
                Point3D old_point = new Point3D(X, Y, Z);
                float k = (float)(1 / Math.Sqrt(6));
                float[,] mat = {{ (float)(k *  Math.Sqrt(3)), 0, k*(float)-Math.Sqrt(3), 0 },
                                {               k*1           , k*2, k*1, 0 },
                                { k*(float)Math.Sqrt(2),k*(float)-Math.Sqrt(2) , k*(float)Math.Sqrt(2), 0 },
                                { 0, 0, 0, 1 }};
                
                multiplication(mat, old_point, new_point);
                return new PointF((float)(new_point.X + width / 2 - ribLength / 2), (float)((height - new_point.Y) - height / 2 + ribLength / 2));
            }

            public PointF GetPointFPerspect() {
                Point3D new_point = new Point3D(0, 0, 0, 1);
                Point3D old_point = new Point3D(X, Y, Z, 1);
                int k = 250;
                float[,] mat = {{ 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0,(-1/k)},
                                { 0, 0, 0, 1}};
                multiplication(  old_point, mat , new_point);
                new_point.X = new_point.X / (1 - Z/k);
                new_point.Y = new_point.Y / (1 - Z/k);
                new_point.C = 1;


                return new PointF((float)(new_point.X + width / 2 - ribLength / 2), (float)((height - new_point.Y) - height / 2 + ribLength / 2));
            }


            public void multiplication( float[,] mat, Point3D point, Point3D new_point)
            {
                float x = point.X;
                float y = point.Y;
                float z = point.Z;
                float c = point.C;

                float[,] vec = { { 0, 0, 0, x }, { 0, 0, 0, y }, { 0, 0, 0, z }, { 0, 0, 0, 1 } };
                float[,] res = { { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 0 } };
                for (int i = 0; i < 4; i++)
                    for (int j = 0; j < 4; j++)
                        for (int k = 0; k < 4; k++)
                            res[i, j] += mat[i, k] * vec[k, j];
                new_point.X = res[0, 3];
                new_point.Y = res[1, 3];
                new_point.Z = res[2, 3];
                new_point.C = res[3, 3];
            }

            public void multiplication(Point3D point, float[,] mat, Point3D new_point) {
                float x = point.X;
                float y = point.Y;
                float z = point.Z;
                float c = point.C;
                float[,] vec = { { x, y, z, c } };
                float[,] res = { { 0, 0, 0, 0 }};
                for (int i = 0; i < 1; i++)
                    for (int j = 0; j < 4; j++)
                        for (int k = 0; k < 4; k++)
                            res[i, k] += vec[i, j] * mat[j, k];
                new_point.X = res[0, 0];
                new_point.Y = res[0, 1];
                new_point.Z = res[0, 2];
                new_point.C = res[0, 3];
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
            foreach (Rib rib in shape)
            {
                //Console.WriteLine(rib.firstPoint.GetPointF().X.ToString());
                rib.firstPoint = new Point3D(shift(rib.firstPoint, delta_x, delta_y, delta_z));
                // Console.WriteLine(rib.firstPoint.GetPointF().X.ToString());
                rib.secondPoint = new Point3D(shift(rib.secondPoint, delta_x, delta_y, delta_z));
            }

            redraw();
        }

        private void RotateX_button_Click(object sender, EventArgs e)
        {
            int angle;
            Int32.TryParse(text_rotate.Text, out angle);

            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(rotateX(rib.firstPoint, angle));
                rib.secondPoint = new Point3D(rotateX(rib.secondPoint, angle));
            }

            redraw();
        }

        private void RotateY_button_Click(object sender, EventArgs e)
        {
            int angle;
            Int32.TryParse(text_rotate.Text, out angle);

            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(rotateY(rib.firstPoint, angle));
                rib.secondPoint = new Point3D(rotateY(rib.secondPoint, angle));
            }

            redraw();
        }

        private void RotateZ_button_Click(object sender, EventArgs e)
        {
            int angle;
            Int32.TryParse(text_rotate.Text, out angle);

            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(rotateZ(rib.firstPoint, angle));
                rib.secondPoint = new Point3D(rotateZ(rib.secondPoint, angle));
            }

            redraw();
        }

        private void Scale_button_Click(object sender, EventArgs e)
        {
            float scale_x;
            float.TryParse(scaleX_text.Text, out scale_x);
            float scale_y;
            float.TryParse(scaleY_text.Text, out scale_y);
            float scale_z;
            float.TryParse(scaleZ_text.Text, out scale_z);
            foreach (Rib rib in shape)
            {
                //Console.WriteLine(rib.firstPoint.GetPointF().X.ToString());
                rib.firstPoint = new Point3D(scale(rib.firstPoint, scale_x, scale_y, scale_z));
                // Console.WriteLine(rib.firstPoint.GetPointF().X.ToString());
                rib.secondPoint = new Point3D(scale(rib.secondPoint, scale_x, scale_y, scale_z));
            }

            redraw();
        }

        private void ReflectX_button_Click(object sender, EventArgs e)
        {
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(reflectionX(rib.firstPoint));
                rib.secondPoint = new Point3D(reflectionX(rib.secondPoint));
            }

            redraw();
        }

        private void ReflectY_button_Click(object sender, EventArgs e)
        {
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(reflectionY(rib.firstPoint));
                rib.secondPoint = new Point3D(reflectionY(rib.secondPoint));
            }

            redraw();
        }

        private void ReflectZ_button_Click(object sender, EventArgs e)
        {
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(reflectionZ(rib.firstPoint));
                rib.secondPoint = new Point3D(reflectionZ(rib.secondPoint));
            }

            redraw();
        }

        private void CenterScale_button_Click(object sender, EventArgs e)
        {
            float scale_x;
            float.TryParse(scaleX_text.Text, out scale_x);
            float scale_y;
            float.TryParse(scaleY_text.Text, out scale_y);
            float scale_z;
            float.TryParse(scaleZ_text.Text, out scale_z);
            Point3D center = mass_center();
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.firstPoint = new Point3D(scale(rib.firstPoint, scale_x, scale_y, scale_z));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.secondPoint = new Point3D(scale(rib.secondPoint, scale_x, scale_y, scale_z));
            }

            redraw();
        }

        private void RotateCenterX_button_Click(object sender, EventArgs e)
        {
            int angle;
            Int32.TryParse(text_rotate.Text, out angle);

            Point3D center = mass_center();
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.firstPoint = new Point3D(rotateX(rib.firstPoint, angle));
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)center.X, (int)center.Y, (int)center.Z));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.secondPoint = new Point3D(rotateX(rib.secondPoint, angle));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)center.X, (int)center.Y, (int)center.Z));
            }

            redraw();
        }

        private void RotateCenterY_button_Click(object sender, EventArgs e)
        {
            int angle;
            Int32.TryParse(text_rotate.Text, out angle);

            Point3D center = mass_center();
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.firstPoint = new Point3D(rotateY(rib.firstPoint, angle));
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)center.X, (int)center.Y, (int)center.Z));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.secondPoint = new Point3D(rotateY(rib.secondPoint, angle));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)center.X, (int)center.Y, (int)center.Z));
            }

            redraw();
        }

        private void RotateCenterZ_button_Click(object sender, EventArgs e)
        {
            int angle;
            Int32.TryParse(text_rotate.Text, out angle);

            Point3D center = mass_center();
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.firstPoint = new Point3D(rotateZ(rib.firstPoint, angle));
                rib.firstPoint = new Point3D(shift(rib.firstPoint, (int)center.X, (int)center.Y, (int)center.Z));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)-center.X, (int)-center.Y, (int)-center.Z));
                rib.secondPoint = new Point3D(rotateZ(rib.secondPoint, angle));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, (int)center.X, (int)center.Y, (int)center.Z));
            }

            redraw();
        }

        private void LineRotate_button_Click(object sender, EventArgs e)
        {
            int x1, y1, z1, x2, y2, z2, angle;
            Int32.TryParse(point1X_text.Text, out x1);
            Int32.TryParse(point1Y_text.Text, out y1);
            Int32.TryParse(point1Z_text.Text, out z1);
            Int32.TryParse(point2X_text.Text, out x2);
            Int32.TryParse(point2Y_text.Text, out y2);
            Int32.TryParse(point2Z_text.Text, out z2);
            Int32.TryParse(text_rotate.Text, out angle);

            Point3D line = new Point3D(x2 - x1, y2 - y1, z2 - z1);
            float sin = (float)Math.Sin(Math.PI / 180 / 3 * angle);
            float cos = (float)Math.Cos(Math.PI / 180 / 3 * angle);
            float l = line.X;
            float m = line.Y;
            float n = line.Z;
            //float[,] mat = { 
            //    {l*l+ cos * (1 - l * l), l * (1 - cos) * m + n * sin, l * (1 - cos) * n - m * sin, 0 }, 
            //    { l*(1-cos)*m - n*sin, m*m + cos * (1 - m*m), m*(1-cos)*n+l*sin, 0 }, 
            //    { l*(1-cos)*n + m*sin, m*(1-cos)*n - l*sin, n*n + cos * (1-n*n), 0 }, 
            //    { 0, 0, 0, 1 } };

            float[,] mat = {
                { l * l + cos * (1 - l * l), l * (1 - cos) * m - n * sin, l * (1 - cos) * n + m * sin, 0},
                {  l * (1 - cos) * m + n * sin, m*m + cos * (1 - m*m), m*(1-cos)*n - l*sin, 0},
                { l * (1 - cos) * n - m * sin,  m*(1-cos)*n+l*sin, n*n + cos * (1-n*n), 0},
                { 0,0,0,1 } };

            foreach (Rib rib in shape)
            {
                multiplication(rib.firstPoint, mat, rib.firstPoint);
                multiplication(rib.secondPoint, mat, rib.secondPoint);
            }

            redraw();
        }

        //Саня
        private Point3D ortX(Point3D old_point)
        {
            float[,] mat = {    { 0, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 1, 0 },
                                { old_point.X, 0, 0, 1 }};
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D ortY(Point3D old_point)
        {
            float[,] mat = {    { 1, 0, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, 1, 0 },
                                {0, old_point.Y, 0, 1 }};
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }

        private Point3D ortZ(Point3D old_point)
        {
            float[,] mat = {    { 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0, old_point.Z, 1 }};
            Point3D new_point = new Point3D(0, 0, 0);
            multiplication(old_point, mat, new_point);
            return new_point;
        }



        private void button_ortX_Click(object sender, EventArgs e)
        {
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(ortX(rib.firstPoint));
                rib.secondPoint = new Point3D(ortX(rib.secondPoint));
            }

            redraw();
        }

        private void button_ortY_Click(object sender, EventArgs e)
        {
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(ortY(rib.firstPoint));
                rib.secondPoint = new Point3D(ortY(rib.secondPoint));
            }

            redraw();
        }

        private void button_ortZ_Click(object sender, EventArgs e)
        {
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(ortZ(rib.firstPoint));
                rib.secondPoint = new Point3D(ortZ(rib.secondPoint));
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
