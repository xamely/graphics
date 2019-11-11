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
        List<Face> shapeFaces; // all faces of current shape
        List<Rib> axes;
        List<Rib> obr; // образующая
        Rib lineRotate;
        Rib axisRotation; 
        
        public static float ribLength = 100;
        public Form1()
        {
            InitializeComponent();
            area.Image = new Bitmap(area.Width, area.Height);
            width = area.Width;
            height = area.Height;
            points3d = new List<Point3D>(); 
            shape = new List<Rib>();
            axes = new List<Rib>();
            obr = new List<Rib>();
            shapeFaces = new List<Face>();
            graphics = Graphics.FromImage(area.Image);
            graphics.Clear(Color.White);
            radioButton_isometr.Checked = true;
            createAxes();
            redraw();
        }

        public void createTetrahedron()
        {
            float cubeSide = (float)(ribLength / Math.Sqrt(2));

            Point3D vertex1 = new Point3D(0, 0, 0);
            Point3D vertex2 = new Point3D(vertex1.X + cubeSide, vertex1.Y + cubeSide, vertex1.Z);
            Point3D vertex3 = new Point3D(vertex1.X + cubeSide, vertex1.Y, vertex1.Z - cubeSide);
            Point3D vertex4 = new Point3D(vertex1.X, vertex1.Y + cubeSide, vertex1.Z - cubeSide);

            Rib rib1 = new Rib(vertex1, vertex2);
            Rib rib2 = new Rib(vertex1, vertex3);
            Rib rib3 = new Rib(vertex2, vertex3);
            Rib rib4 = new Rib(vertex1, vertex4);
            Rib rib5 = new Rib(vertex2, vertex4);
            Rib rib6 = new Rib(vertex4, vertex3);
            Rib rib7 = new Rib(vertex4, vertex2);

            shape.Add(rib1); shape.Add(rib2); shape.Add(rib3); shape.Add(rib4); shape.Add(rib5); shape.Add(rib6); shape.Add(rib7); 

            Face f1 = new Face(new List<Rib>() { rib1, rib3, rib2 });
            Face f2 = new Face(new List<Rib>() { rib4, rib7, rib1 });
            Face f3 = new Face(new List<Rib>() { rib7, rib3, rib6 });
            Face f4 = new Face(new List<Rib>() { rib4, rib6, rib2 });

            shapeFaces.Add(f1); shapeFaces.Add(f2); shapeFaces.Add(f3); shapeFaces.Add(f4); 
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

            Rib rib1 = new Rib(vertex1, vertex2);
            Rib rib2 = new Rib(vertex2, vertex3);
            Rib rib3 = new Rib(vertex3, vertex4);
            Rib rib4 = new Rib(vertex1, vertex4);
            Rib rib5 = new Rib(vertex2, vertex6);
            Rib rib6 = new Rib(vertex6, vertex5);
            Rib rib7 = new Rib(vertex1, vertex5);
            Rib rib8 = new Rib(vertex6, vertex7);
            Rib rib9 = new Rib(vertex7, vertex8);
            Rib rib10 = new Rib(vertex5, vertex8);
            Rib rib11 = new Rib(vertex3, vertex7);
            Rib rib12 = new Rib(vertex4, vertex8);
            Rib rib13 = new Rib(vertex5, vertex6);
            Rib rib14 = new Rib(vertex4, vertex3);
            Rib rib15 = new Rib(vertex7, vertex3);
            Rib rib16 = new Rib(vertex8, vertex4);

            shape.Add(rib1); shape.Add(rib2); shape.Add(rib3); shape.Add(rib4); shape.Add(rib5); shape.Add(rib6);
            shape.Add(rib7); shape.Add(rib8); shape.Add(rib9); shape.Add(rib10); shape.Add(rib11); shape.Add(rib12);
            shape.Add(rib13); shape.Add(rib14); shape.Add(rib15); shape.Add(rib16); 

            Face f1 = new Face(new List<Rib>() { rib1, rib2, rib3, rib4 });
            Face f2 = new Face(new List<Rib>() { rib1, rib5, rib6, rib7 });
            Face f3 = new Face(new List<Rib>() { rib13, rib8, rib9, rib10 });
            Face f4 = new Face(new List<Rib>() { rib14, rib11, rib9, rib12 }); 
            Face f5 = new Face(new List<Rib>() { rib5, rib8, rib15, rib2 });
            Face f6 = new Face(new List<Rib>() { rib7, rib10, rib16, rib4 });

            shapeFaces.Add(f1); shapeFaces.Add(f2); shapeFaces.Add(f3); shapeFaces.Add(f4); shapeFaces.Add(f5); shapeFaces.Add(f6); 
        }

        private void createIcosahedron()
        {
            float r = (float)(100 * (1 + Math.Sqrt(5)) / 4); // радиус полувписанной окружности
            Point3D vertex1 = new Point3D(0, -50, -r);
            Point3D vertex2 = new Point3D(0, 50, -r);
            Point3D vertex3 = new Point3D(50, r, 0);
            Point3D vertex4 = new Point3D(r, 0, -50);
            Point3D vertex5 = new Point3D(50, -r, 0);
            Point3D vertex6 = new Point3D(-50, -r, 0);
            Point3D vertex7 = new Point3D(-r, 0, -50);
            Point3D vertex8 = new Point3D(-50, r, 0);
            Point3D vertex9 = new Point3D(r, 0, 50);
            Point3D vertex10 = new Point3D(-r, 0, 50);
            Point3D vertex11 = new Point3D(0, -50, r);
            Point3D vertex12 = new Point3D(0, 50, r);

            shape.Add(new Rib(vertex1, vertex2));
            shape.Add(new Rib(vertex1, vertex4));
            shape.Add(new Rib(vertex1, vertex6));
            shape.Add(new Rib(vertex1, vertex5));
            shape.Add(new Rib(vertex1, vertex7));

            shape.Add(new Rib(vertex2, vertex3));
            shape.Add(new Rib(vertex2, vertex4));
            shape.Add(new Rib(vertex2, vertex7));
            shape.Add(new Rib(vertex2, vertex8));


            shape.Add(new Rib(vertex3, vertex8));
            shape.Add(new Rib(vertex3, vertex4));
            shape.Add(new Rib(vertex3, vertex9));
            shape.Add(new Rib(vertex3, vertex12));

            shape.Add(new Rib(vertex4, vertex9));
            shape.Add(new Rib(vertex4, vertex5));

            shape.Add(new Rib(vertex5, vertex6));
            shape.Add(new Rib(vertex5, vertex9));
            shape.Add(new Rib(vertex5, vertex11));

            shape.Add(new Rib(vertex6, vertex10));
            shape.Add(new Rib(vertex6, vertex7));
            shape.Add(new Rib(vertex6, vertex11));

            shape.Add(new Rib(vertex7, vertex8));
            shape.Add(new Rib(vertex7, vertex10));

            shape.Add(new Rib(vertex8, vertex10));
            shape.Add(new Rib(vertex8, vertex12));

            shape.Add(new Rib(vertex9, vertex12));
            shape.Add(new Rib(vertex9, vertex11));

            shape.Add(new Rib(vertex10, vertex12));
            shape.Add(new Rib(vertex10, vertex11));

            shape.Add(new Rib(vertex11, vertex12));
        }

        private void create_dodecahedron()
        {
            float r = (float)(100 * (3 + Math.Sqrt(5)) / 4); // радиус полувписанной окружности
            float x = (float)(100 * (1 + Math.Sqrt(5)) / 4); // половина стороны пятиугольника в сечении 

            Point3D vertex1 = new Point3D(0, -50, -r);
            Point3D vertex2 = new Point3D(0, 50, -r);
            Point3D vertex3 = new Point3D(x, x, -x);
            Point3D vertex4 = new Point3D(r, 0, -50);
            Point3D vertex5 = new Point3D(x, -x, -x);
            Point3D vertex6 = new Point3D(50, -r, 0);
            Point3D vertex7 = new Point3D(-50, -r, 0);
            Point3D vertex8 = new Point3D(-x, -x, -x);
            Point3D vertex9 = new Point3D(-r, 0, -50);
            Point3D vertex10 = new Point3D(-x, x, -x);
            Point3D vertex11 = new Point3D(-50, r, 0);
            Point3D vertex12 = new Point3D(50, r, 0);
            Point3D vertex13 = new Point3D(-x, -x, x);
            Point3D vertex14 = new Point3D(0, -50, r);
            Point3D vertex15 = new Point3D(x, -x, x);
            Point3D vertex16 = new Point3D(0, 50, r);
            Point3D vertex17 = new Point3D(-x, x, x);
            Point3D vertex18 = new Point3D(x, x, x);
            Point3D vertex19 = new Point3D(-r, 0, 50);
            Point3D vertex20 = new Point3D(r, 0, 50);


            shape.Add(new Rib(vertex1, vertex2));
            shape.Add(new Rib(vertex1, vertex5));
            shape.Add(new Rib(vertex1, vertex8));

            shape.Add(new Rib(vertex2, vertex3));
            shape.Add(new Rib(vertex2, vertex10));

            shape.Add(new Rib(vertex3, vertex4));
            shape.Add(new Rib(vertex3, vertex12));

            shape.Add(new Rib(vertex4, vertex5));
            shape.Add(new Rib(vertex4, vertex20));

            shape.Add(new Rib(vertex5, vertex6));

            shape.Add(new Rib(vertex6, vertex7));
            shape.Add(new Rib(vertex6, vertex15));

            shape.Add(new Rib(vertex7, vertex8));
            shape.Add(new Rib(vertex7, vertex13));

            shape.Add(new Rib(vertex8, vertex9));

            shape.Add(new Rib(vertex9, vertex10));
            shape.Add(new Rib(vertex9, vertex19));
            shape.Add(new Rib(vertex10, vertex11));
            shape.Add(new Rib(vertex11, vertex12));
            shape.Add(new Rib(vertex11, vertex17));
            shape.Add(new Rib(vertex12, vertex18));
            shape.Add(new Rib(vertex13, vertex19));
            shape.Add(new Rib(vertex13, vertex14));
            shape.Add(new Rib(vertex14, vertex15));
            shape.Add(new Rib(vertex15, vertex20));
            shape.Add(new Rib(vertex16, vertex18));
            shape.Add(new Rib(vertex16, vertex14));
            shape.Add(new Rib(vertex16, vertex17));
            shape.Add(new Rib(vertex16, vertex18));
            shape.Add(new Rib(vertex17, vertex19));
            shape.Add(new Rib(vertex18, vertex20));

        }

        private void createAxes()
        {
            Point3D start = new Point3D(0, 0, 0);
            Point3D X = new Point3D(200, 0, 0);
            Point3D Y = new Point3D(0, 200, 0);
            Point3D Z = new Point3D(0, 0, 200);
            axes.Add(new Rib(start, X));
            axes.Add(new Rib(start, Y));
            axes.Add(new Rib(start, Z));
        }

        public void drawShape()
        {
            if (shape.Count == 0) return;
            if (non_faced_checkBox.Checked) drawShape_non_faces();
            else
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
                    if (radioButton_ortZ.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtZ(), rib.secondPoint.GetPointFOrtZ());
                    else if (radioButton_ortX.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtX(), rib.secondPoint.GetPointFOrtX());
                    else if (radioButton_ortY.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtY(), rib.secondPoint.GetPointFOrtY());
                    else if (radioButton_isometr.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFisometr(), rib.secondPoint.GetPointFisometr());
                    else if (radioButton_perspect.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFPerspect(), rib.secondPoint.GetPointFPerspect());
                }
            }
            area.Invalidate();
        }

        public void drawShape_non_faces()
        {
            if (shapeFaces.Count != 0)
            {
                Pen pen = new Pen(Color.Black);

                int x1, y1, z1, x2, y2, z2;
                Int32.TryParse(cut_off_p1x.Text, out x1);
                Int32.TryParse(cut_off_p1y.Text, out y1);
                Int32.TryParse(cut_off_p1z.Text, out z1);
                Int32.TryParse(cut_off_p2x.Text, out x2);
                Int32.TryParse(cut_off_p2y.Text, out y2);
                Int32.TryParse(cut_off_p2z.Text, out z2);

                Point3D startPoint = new Point3D(x1, y1, z1);
                Point3D endPoint = new Point3D(x2, y2, z2);
                graphics.DrawLine(pen, startPoint.GetPointFisometr(), endPoint.GetPointFisometr());

                foreach (Face face in shapeFaces)
                {
                    if (!is_face_visible(face)) continue;
                    foreach (Rib rib in face.ribs)
                    {
                        if (radioButton_ortZ.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtZ(), rib.secondPoint.GetPointFOrtZ());
                        else if (radioButton_ortX.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtX(), rib.secondPoint.GetPointFOrtX());
                        else if (radioButton_ortY.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtY(), rib.secondPoint.GetPointFOrtY());
                        else if (radioButton_isometr.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFisometr(), rib.secondPoint.GetPointFisometr());
                        else if (radioButton_perspect.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFPerspect(), rib.secondPoint.GetPointFPerspect());
                    }
                }
            }
            area.Invalidate();
        }

        public bool is_face_visible(Face face)
        {
            Point3D point1 = face.ribs[0].firstPoint - face.ribs[0].secondPoint;
            Point3D point2 = face.ribs[1].secondPoint - face.ribs[1].firstPoint;
            Point3D normal_point = new Point3D(point1.Y * point2.Z - point1.Z * point2.Y, point1.Z * point2.X - point1.X * point2.Z, point1.X * point2.Y - point1.Y * point2.X);
            
            Rib normal = new Rib(face.ribs[0].secondPoint, normal_point + face.ribs[0].secondPoint);
            Point3D center_point = mass_center();

            Point3D first_vector = normal.firstPoint - center_point;
            Point3D second_vector = normal.secondPoint - normal.firstPoint;
            double angle = scalar_mult(first_vector, second_vector);

            if (angle < Math.PI / 2)
            {
                Point3D temp = new Point3D(normal.secondPoint);
                normal.secondPoint = new Point3D(normal.firstPoint);
                normal.firstPoint = temp;
            }

            int x1, y1, z1, x2, y2, z2;
            Int32.TryParse(cut_off_p1x.Text, out x1);
            Int32.TryParse(cut_off_p1y.Text, out y1);
            Int32.TryParse(cut_off_p1z.Text, out z1);
            Int32.TryParse(cut_off_p2x.Text, out x2);
            Int32.TryParse(cut_off_p2y.Text, out y2);
            Int32.TryParse(cut_off_p2z.Text, out z2);

            first_vector = normal.secondPoint - normal.firstPoint;
            second_vector = new Point3D(x2 - x1, y2 - y1, z2 - z1);
            angle = scalar_mult(first_vector, second_vector);

            Console.WriteLine(angle);

            return (angle < Math.PI / 2);
        }

        public double scalar_mult(Point3D first_vector, Point3D second_vector)
        {
            return Math.Acos((first_vector.X * second_vector.X + first_vector.Y * second_vector.Y + first_vector.Z * second_vector.Z)
                            / (Math.Sqrt(first_vector.X * first_vector.X + first_vector.Y * first_vector.Y + first_vector.Z * first_vector.Z)
                            * Math.Sqrt(second_vector.X * second_vector.X + second_vector.Y * second_vector.Y + second_vector.Z * second_vector.Z)));
        }

        public void drawAxes()
        {
            Pen pen = new Pen(Color.Black);
            int c = 0;
            foreach (Rib rib in axes)
            {
                pen = new Pen(Color.Black);
                if (c == 0)
                {
                    pen = new Pen(Color.Red);
                    c++;
                }
                else if (c == 1)
                {
                    pen = new Pen(Color.Green);
                    c++;
                }
                else if (c == 2)
                {
                    pen = new Pen(Color.Blue);
                    c++;
                }
                if (radioButton_ortZ.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtZ(), rib.secondPoint.GetPointFOrtZ());
                else if (radioButton_ortX.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtX(), rib.secondPoint.GetPointFOrtX());
                else if (radioButton_ortY.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFOrtY(), rib.secondPoint.GetPointFOrtY());
                else if (radioButton_isometr.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFisometr(), rib.secondPoint.GetPointFisometr());
                else if (radioButton_perspect.Checked == true) graphics.DrawLine(pen, rib.firstPoint.GetPointFPerspect(), rib.secondPoint.GetPointFPerspect());
            }
            area.Invalidate();
        }

        public void drawPoint3D() {
            if (points3d.Count == 0) return;
            Pen pen = new Pen(Color.Black);
            foreach (Point3D rib in points3d)
            {
                if (radioButton_ortZ.Checked == true) graphics.DrawRectangle(pen, rib.GetPointFOrtZ().X, rib.GetPointFOrtZ().Y, 1, 1);
                else if (radioButton_ortX.Checked == true) graphics.DrawRectangle(pen, rib.GetPointFOrtX().X, rib.GetPointFOrtX().Y, 1, 1);
                else if (radioButton_ortY.Checked == true) graphics.DrawRectangle(pen, rib.GetPointFOrtY().X, rib.GetPointFOrtY().Y, 1, 1);
                else if (radioButton_isometr.Checked == true)
                {
                    float new_x = rib.GetPointFisometr().X;
                    float new_y = rib.GetPointFisometr().Y;
                    graphics.DrawRectangle(pen, new_x, new_y, 2, 2);
                }
                else if (radioButton_perspect.Checked == true) graphics.DrawRectangle(pen, rib.GetPointFPerspect().X, rib.GetPointFPerspect().Y, 1, 1);
            }
            
            area.Invalidate();
        }

        public void redraw()
        {

            graphics.Clear(Color.White);
            drawShape();
            drawPoint3D();
            if (axes_checkBox.Checked) drawAxes();  // отображение осей
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
            float[,] mat = { { 1, 0, 0, 0 }, { 0, -1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
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
                this.X = point.X; this.Y = point.Y; this.Z = point.Z; this.C = point.C;
            }
            public Point3D(float X, float Y, float Z)
            {
                this.X = X; this.Y = Y; this.Z = Z; this.C = (float)1.0;
            }
            public Point3D(float X, float Y, float Z, float C)
            {
                this.X = X; this.Y = Y; this.Z = Z; this.C = C;
            }

            public static Point3D operator -(Point3D point1, Point3D point2)
            {
                return new Point3D(point2.X - point1.X, point2.Y - point1.Y, point2.Z - point1.Z);
            }

            public static Point3D operator +(Point3D point1, Point3D point2)
            {
                return new Point3D(point2.X + point1.X, point2.Y + point1.Y, point2.Z + point1.Z);
            }

            public PointF GetPointFOrtZ()
            {

                float[,] mat = {{ 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0, 0 },
                                { 0, 0,Z, 1 }};
                Point3D new_point = new Point3D(0, 0, 0);
                Point3D old_point = new Point3D(X, Y, Z);
                multiplication(mat, old_point, new_point);
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

            public PointF GetPointFPerspect()
            {
                Point3D new_point = new Point3D(0, 0, 0, 1);
                Point3D old_point = new Point3D(X, Y, Z, 1);
                int k = 250;
                float[,] mat = {{ 1, 0, 0, 0 },
                                { 0, 1, 0, 0 },
                                { 0, 0, 0,(-1/k)},
                                { 0, 0, 0, 1}};
                multiplication(old_point, mat, new_point);
                new_point.X = new_point.X / (1 - Z / k);
                new_point.Y = new_point.Y / (1 - Z / k);
                new_point.C = 1;


                return new PointF((float)(new_point.X + width / 2 - ribLength / 2), (float)((height - new_point.Y) - height / 2 + ribLength / 2));
            }


            public void multiplication(float[,] mat, Point3D point, Point3D new_point)
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

            public void multiplication(Point3D point, float[,] mat, Point3D new_point)
            {
                float x = point.X;
                float y = point.Y;
                float z = point.Z;
                float c = point.C;
                float[,] vec = { { x, y, z, c } };
                float[,] res = { { 0, 0, 0, 0 } };
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
            else if (icosahedron_radioButton.Checked) createIcosahedron();
            else if (radioDodecahedron.Checked) create_dodecahedron();
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


            foreach (Point3D p in points3d)
            {
                Point3D x = new Point3D(rotateX(p, angle));
                p.X = x.X;
                p.Y = x.Y;
                p.Z = x.Z;
            }

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


            foreach (Point3D p in points3d)
            {
                Point3D x = new Point3D(rotateY(p, angle));
                p.X = x.X;
                p.Y = x.Y;
                p.Z = x.Z;
            }
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


            foreach (Point3D p in points3d)
            {
                Point3D x = new Point3D(rotateZ(p, angle));
                p.X = x.X;
                p.Y = x.Y;
                p.Z = x.Z;
            }

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


            foreach (Point3D p in points3d)
            {
                Point3D x = new Point3D(reflectionX(p));
                p.X = x.X;
                p.Y = x.Y;
                p.Z = x.Z;
            }
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(reflectionX(rib.firstPoint));
                rib.secondPoint = new Point3D(reflectionX(rib.secondPoint));
            }

            redraw();
        }

        private void ReflectY_button_Click(object sender, EventArgs e)
        {

            foreach (Point3D p in points3d)
            {
                Point3D x = new Point3D(reflectionY(p));
                p.X = x.X;
                p.Y = x.Y;
                p.Z = x.Z;
            }
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(reflectionY(rib.firstPoint));
                rib.secondPoint = new Point3D(reflectionY(rib.secondPoint));
            }

            redraw();
        }

        private void ReflectZ_button_Click(object sender, EventArgs e)
        {

            foreach (Point3D p in points3d)
            {
                Point3D x = new Point3D(reflectionZ(p));
                p.X = x.X;
                p.Y = x.Y;
                p.Z = x.Z;
            }
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

        // Поворачивает точку вокруг заданной прямой, изменяя new_point
        private Point3D pointRotateLine(Rib Line, Point3D point, float angle) {
            int x1 = (int)axisRotation.firstPoint.X;
            int y1 = (int)axisRotation.firstPoint.Y;
            int z1 = (int)axisRotation.firstPoint.Z;
            int x2 = (int)axisRotation.secondPoint.X;
            int y2 = (int)axisRotation.secondPoint.Y;
            int z2 = (int)axisRotation.secondPoint.Z;

            Point3D line = new Point3D(x2 - x1, y2 - y1, z2 - z1);
            float length = (float)Math.Sqrt(line.X * line.X + line.Y * line.Y + line.Z * line.Z);
            float sin = (float)Math.Sin(Math.PI / 180 * angle);
            float cos = (float)Math.Cos(Math.PI / 180 * angle);
            float l = line.X / length;
            float m = line.Y / length;
            float n = line.Z / length;

            float[,] mat = {
                {l*l+ cos * (1 - l * l), l * (1 - cos) * m + n * sin, l * (1 - cos) * n - m * sin, 0 },
                { l*(1-cos)*m - n*sin, m*m + cos * (1 - m*m), m*(1-cos)*n+l*sin, 0 },
                { l*(1-cos)*n + m*sin, m*(1-cos)*n - l*sin, n*n + cos * (1-n*n), 0 },
                { 0, 0, 0, 1 } };

            
            // Перенос  
            Point3D new_point = new Point3D(shift(point, -x1, -y1, -z1));
            //Поворот
            multiplication(new_point, mat, new_point);
            // Перенос 
            new_point= new Point3D(shift(new_point, x1, y1, z1));
            return new_point;
        }

        // Задаем ось вращения и рисуем ее 
        private void initAxisRotation_button_click(object sender, EventArgs e)
        {
            int x1, y1, z1, x2, y2, z2;
            Int32.TryParse(firstPointAxisX_text.Text, out x1);
            Int32.TryParse(firstPointAxisY_text.Text, out y1);
            Int32.TryParse(firstPointAxisZ_text.Text, out z1);
            Int32.TryParse(secondPointAxisX_text.Text, out x2);
            Int32.TryParse(secondPointAxisY_text.Text, out y2);
            Int32.TryParse(secondPointAxisZ_text.Text, out z2);
            Point3D start = new Point3D(x1,y1,z1);
            Point3D end = new Point3D(x2,y2,z2);
            axisRotation = new Rib(start, end);
            shape.Add(axisRotation);
            redraw();
        }

        //Добавляем образующие точки и рисуем их
        private void addPoint_button_Click(object sender, EventArgs e)
        {
            int x1, y1, z1;
            Int32.TryParse(addPointX_text.Text, out x1);
            Int32.TryParse(addPointY_text.Text, out y1);
            Int32.TryParse(addPointZ_text.Text, out z1);
         
            points3d.Add(new Point3D(x1, y1, z1));
            redraw();
        }

        // Создаем фигуру 
        private void createFigure_button_click(object sender, EventArgs e)
        {
            int count;
            Int32.TryParse(countDiv_text.Text, out count);
            float angle = (float)360 / (float)count;

            for (int i = 0; i < points3d.Count - 1; i++) // Инициализация Образующей
                obr.Add(new Rib(points3d[i], points3d[i + 1]));

            List<Rib> old_obr = obr; // Сохраняем предыдущую образующую 
            for (int i = 0; i < count; i++) { // выполняем count разбиений
                List<Rib> new_obr = new List<Rib>();
                foreach (Rib rib in old_obr) { // Рассматриваем каждое ребро из образующей
                    
                    Point3D start = pointRotateLine(axisRotation, rib.firstPoint, angle); //новое начало ребра
                    Point3D end = pointRotateLine(axisRotation, rib.secondPoint, angle); //новый конец ребра

                    Rib newRib = new Rib(start,end); // Новое ребро со смещением
                    shape.Add(new Rib(rib.firstPoint, start));  // соединение между образующими 
                    shape.Add(new Rib(rib.secondPoint, end));   // соединение между образующими
                    shape.Add(newRib);
                    new_obr.Add(newRib);
                }
                old_obr = new_obr; 
            }
            redraw();
        }

        private void drawLinesListPoints(List<Rib> L) {
            if (L.Count >= 1)
            {
                foreach (Rib rib in L) {
                    shape.Add(rib);
                }
            }
            //redraw();
        }

        private void drawLine_button_Click(object sender, EventArgs e)
        {
            int x1, y1, z1, x2, y2, z2, angle;
            Int32.TryParse(point1X_text.Text, out x1);
            Int32.TryParse(point1Y_text.Text, out y1);
            Int32.TryParse(point1Z_text.Text, out z1);
            Int32.TryParse(point2X_text.Text, out x2);
            Int32.TryParse(point2Y_text.Text, out y2);
            Int32.TryParse(point2Z_text.Text, out z2);
            Point3D startPoint = new Point3D(x1, y1, z1);
            Point3D endPoint = new Point3D(x2, y2, z2);
            lineRotate =  new Rib(startPoint, endPoint);
            shape.Add(lineRotate);
            redraw();
        }

        private void LineRotate_button_Click(object sender, EventArgs e)
        {
            int x1 = (int)lineRotate.firstPoint.X;
            int y1 = (int)lineRotate.firstPoint.Y;
            int z1 = (int)lineRotate.firstPoint.Z;
            int x2 = (int)lineRotate.secondPoint.X;
            int y2 = (int)lineRotate.secondPoint.Y;
            int z2 = (int)lineRotate.secondPoint.Z;
            int angle;

            Int32.TryParse(text_rotate.Text, out angle);
            Point3D line = new Point3D(x2 - x1, y2 - y1, z2 - z1);
            float length = (float)Math.Sqrt(line.X * line.X + line.Y * line.Y + line.Z * line.Z);
            float sin = (float)Math.Sin(Math.PI / 180 * angle);
            float cos = (float)Math.Cos(Math.PI / 180 * angle);
            float l = line.X / length;
            float m = line.Y / length;
            float n = line.Z / length;

            float[,] mat = {
                {l*l+ cos * (1 - l * l), l * (1 - cos) * m + n * sin, l * (1 - cos) * n - m * sin, 0 },
                { l*(1-cos)*m - n*sin, m*m + cos * (1 - m*m), m*(1-cos)*n+l*sin, 0 },
                { l*(1-cos)*n + m*sin, m*(1-cos)*n - l*sin, n*n + cos * (1-n*n), 0 },
                { 0, 0, 0, 1 } };

            // Перенос  
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(shift(rib.firstPoint, -x1, -y1, -z1));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, -x1, -y1, -z1));
                
            }

            //Поворот
            foreach (Rib rib in shape)
            {
                multiplication(rib.firstPoint, mat, rib.firstPoint);
                multiplication(rib.secondPoint, mat, rib.secondPoint);
            }

            // Перенос  
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(shift(rib.firstPoint, x1, y1, z1));
                rib.secondPoint = new Point3D(shift(rib.secondPoint, x1, y1, z1));
            }

            redraw();
            area.Invalidate();
        }

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

        int oldV = 0;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int angle = 10;
            if (trackBar1.Value < oldV)
            {
                angle = -10;
                oldV = trackBar1.Value;
            }
            foreach (Rib rib in shape)
            {
                rib.firstPoint = new Point3D(rotateY(rib.firstPoint, angle));
                rib.secondPoint = new Point3D(rotateY(rib.secondPoint, angle));
            }
            oldV = trackBar1.Value;
            redraw();
        }

        private float func(float x, float y)
        {
            return x * x + 5 * (float)Math.Sin(y);
        }

        private void Draw_func_button_Click(object sender, EventArgs e)
        {
            float x0, y0, x1, y1;
            int range;

            float.TryParse(range0_text.Text, out x0);
            float.TryParse(range1_text.Text, out x1);
            Int32.TryParse(fragmentation_text.Text, out range);
            y0 = x0;
            y1 = x1;
            float step = (x1 - x0) / range;

            Pen pen = new Pen(Color.Black);
            shape.Add(new Rib(new Point3D(0, 0, 0), new Point3D(50, 0, 0)));
            shape.Add(new Rib(new Point3D(0, 0, 0), new Point3D(0, 50, 0)));
            shape.Add(new Rib(new Point3D(0, 0, 0), new Point3D(0, 0, 50)));
            for (float i = x0; i < x1; i += step)
                for (float j = y0; j < y1; j += step)
                {
                    Rib rib1 = new Rib(new Point3D(i, j, func(i, j)), new Point3D(i, j + step, func(i, j + step)));
                    Rib rib2 = new Rib(new Point3D(i, j, func(i, j)), new Point3D(i - step, j, func(i - step, j)));
                    Rib rib3 = new Rib(rib2.secondPoint, new Point3D(i - step, j + step, func(i - step, j + step)));
                    Rib rib4 = new Rib(rib1.secondPoint, rib3.secondPoint);

                    shape.Add(rib1);
                    shape.Add(rib2);
                    shape.Add(rib3);
                    shape.Add(rib4);

                    Face face = new Face(new List<Rib>() { rib1, rib2, rib3, rib4 });
                    shapeFaces.Add(face);
                }
            drawShape();
        }

        private void load_figure_button_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.InitialDirectory = Environment.CurrentDirectory.Replace("bin\\Debug", "");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = dialog.FileName;
                parse(selectedFile);
            }
        }

        private void parse(string file_name)
        {
            shape.Clear();
            shapeFaces.Clear();
            System.IO.StreamReader file = new System.IO.StreamReader(file_name);
            string line;

            HashSet<Rib> temp_shape = new HashSet<Rib>();

            while ((line = file.ReadLine()) != null)
            {
                string[] arr = line.Split(' ');

                List<Rib> curr_face = new List<Rib>();

                foreach (string ribs in arr)
                {
                    string[] points = ribs.Split(';');

                    string[] first = points[0].Split(',');
                    float X, Y, Z;
                    float.TryParse(first[0], out X);
                    float.TryParse(first[1], out Y);
                    float.TryParse(first[2], out Z);
                    Point3D first_point = new Point3D(X, Y, Z);

                    string[] second = points[1].Split(',');
                    float.TryParse(second[0], out X);
                    float.TryParse(second[1], out Y);
                    float.TryParse(second[2], out Z);
                    Point3D second_point = new Point3D(X, Y, Z);

                    Rib rib = new Rib(first_point, second_point);
                    temp_shape.Add(rib);
                    curr_face.Add(rib);
                }

                Face face = new Face(curr_face);
                shapeFaces.Add(face);
            }

            shape = temp_shape.ToList();
            redraw();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            redraw();
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            shape.Clear();
            shapeFaces.Clear();
            points3d.Clear();
            obr.Clear();
            graphics.Clear(Color.White);
            area.Invalidate();
        }

    }
}
