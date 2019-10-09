using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;

using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JarvisAlg
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
            //this.KeyDown += new KeyEventHandler(Form1_KeyDown);
            this.KeyPreview = true;
            polyPoints = new List<Point>();

            dotButton.CheckedChanged += new EventHandler(radioButtons_CheckedChanged);

        }


        private void radioButtons_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dotButton.Checked)
            {
                can_draw = true;
                polyPoints.Clear();
            }
        }

        private void area_MouseDown(object sender, MouseEventArgs e)
        {
            this.CurrentPoint = e.Location;
        }

        private void area_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.dotButton.Checked)
            {
                LastPoint = e.Location;
                polyPoints.Add(LastPoint);
                g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(LastPoint.X-1, LastPoint.Y-1, 4,4));
                area.Invalidate();
            }
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            area.Image = new Bitmap(area.Width, area.Height);
            g = Graphics.FromImage(area.Image);
            polyPoints.Clear();
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, area.Width, area.Height);
            this.dotButton.Checked = false;

        }



        private void Start_Button_Click(object sender, EventArgs e)
        {
            int n = this.polyPoints.Count;
            List<Point> A = this.polyPoints;


            List<Point> newA = new List<Point>();

            if (this.polyPoints.Count > 2)
            {
                int m = 0;
                for (int i = 0; i < n; i++)
                {
                    if (A[i].X < A[m].X)
                    {
                        m = i;
                    }
                }


                for (int i = m; i < n; i++)
                {
                    newA.Add(A[i]);
                }
                for (int i = 0; i < m; i++)
                {
                    newA.Add(A[i]);
                }
                this.label1.Text = newA[0].ToString();
            }

            List<bool> F = new List<bool>();
            for (int i = 0; i < n; i++)
                F.Add(false);

            Point cur = newA[0];
            Point start = newA[0];
            List<Point> H = new List<Point>();
            H.Add(cur);
            int cid = 0;
            while (F[0] == false)
            {
                int right = 0;
                for (int i = 0; i < n; i++)
                {
                    if (cid != i)
                    {
                        Tuple<int, int> t = this.RightCheckList(cur, newA[i], newA);
                        if (t.Item1 == 1 && F[t.Item2]!=true)
                        {
                            cur = newA[t.Item2];
                            cid = t.Item2;
                            F[t.Item2] = true;
                            if (cur != start)
                                H.Add(cur);
                        }
                    }

                }
            }

            cur = H[0];
            for (int i = 1; i < H.Count; i++)
            {

                g.DrawLine(new Pen(Color.Black), cur, H[i]);
                cur = H[i];
                area.Invalidate();

            }
            g.DrawLine(new Pen(Color.Black),cur,H[0]);

            area.Invalidate();
        }

        public Tuple<int, int> RightCheckList(Point O, Point A, List<Point> L)
        {
            int c = 0;
            int cid = 0;
            for (int i = 0; i < L.Count; i++)
            {
                if (RightCheck(O, A, L[i]))
                {
                    c++;
                    cid = i;
                }
            }
            Tuple<int, int> t = new Tuple<int, int>(c, cid);
            return t;
        }
        /*
        private void Start_Button_Click(object sender, EventArgs e)
        {
            int n = this.polyPoints.Count;
            List<Point> A = this.polyPoints;
            List<int> P = new List<int>();

            for (int i = 0; i < n; i++)
                P.Add(i);

            if (this.polyPoints.Count > 2)
            {

                for (int i = 1; i < n; i++)
                {
                    if (A[P[i]].X < A[P[0]].X)
                    {
                        int x = P[i];
                        P[i] = P[0];
                        P[0] = x;
                    }
                }
                this.label1.Text = A[P[0]].ToString() ;
            }

            List<int> H = new List<int>();
            H.Add(P[0]);
            P.RemoveAt(0);
            P.Add(H[0]);


            while (true ) {
                int right = 0;
                for (int i = 1; i < P.Count; i++) {
                    if (  this.RightCheck(A[H[H.Count-1]],A[P[right]],A[P[i]])  ) {
                        right = i;
                    }
                    if (P[right] == H[0])
                        break;
                    else {
                        H.Add(P[right]);
                        P.RemoveAt(right);
                        this.label1.Text = H.Count.ToString();
                    }
                }
            }

        }*/



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


            if ((ybm * xam - xbm * yam) > 0)
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
