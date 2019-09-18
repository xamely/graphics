using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static void RGBtoHSV(float R, float G, float B, ref float H, ref float S, ref float V)
        {

            float max, min;
            R /= 256f;
            G /= 256f;
            B /= 256f;
            if (R > G)
            {
                if (R > B)
                {
                    max = R;
                    if (G < B)
                        min = G;
                    else
                        min = B;
                }
                else
                {
                    max = B;
                    min = G;
                }
            }
            else if (G > B)
            {
                max = G;
                if (R < B)
                    min = R;
                else
                    min = B;
            }
            else
            {
                max = B;
                min = R;
            }

            if (max == min)
                H = 0;
            else if (max == R && G >= B)
                H = 60 * (G - B) / (max - min);
            else if (max == R && G < B)
                H = 60 * (G - B) / (max - min) + 360;
            else if (max == G)
                H = 60 * (B - R) / (max - min) + 120;
            else if (max == B)
                H = 60 * (R - G) / (max - min) + 240;

            S = (max == 0) ? 0 : 1 - min / max;
            V = max;
        }

        public void HSVtoRGB(float H, float S, float V, ref float R, ref float G, ref float B)
        {
            S *= 100;
            V *= 100;
            int i = (int)(H / 60) % 6;
            float Vmin = (100 - S) * V / 100;
            float a = (V - Vmin) * ((int)H % 60) / 60f;
            float Vinc = Vmin + a;
            float Vdec = V - a;
            switch (i)
            {
                case 0:
                    R = V;
                    G = Vinc;
                    B = Vmin;
                    break;
                case 1:
                    R = Vdec;
                    G = V;
                    B = Vmin;
                    break;
                case 2:
                    R = Vmin;
                    G = V;
                    B = Vinc;
                    break;
                case 3:
                    R = Vmin;
                    G = Vdec;
                    B = V;
                    break;
                case 4:
                    R = Vinc;
                    G = Vmin;
                    B = V;
                    break;
                case 5:
                    R = V;
                    G = Vmin;
                    B = Vdec;
                    break;
            }
            R *= 256 / 100;
            G *= 256 / 100;
            B *= 256 / 100;
        }

        public Form1()
        {
            InitializeComponent();
            trackBar1.Scroll += TrackBar1_Scroll;
            trackBar1.Minimum = 0;
            trackBar1.Maximum = 100;

            trackBar2.Scroll += TrackBar2_Scroll;
            trackBar2.Minimum = 0;
            trackBar2.Maximum = 360;

            trackBar3.Scroll += TrackBar3_Scroll;
            trackBar3.Minimum = 0;
            trackBar3.Maximum = 100;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void openbutton_Click(object sender, EventArgs e)
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

        private void graybutton_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) 
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output1 = new Bitmap(input.Width, input.Height);
                Bitmap output2 = new Bitmap(input.Width, input.Height);
                Bitmap output3 = new Bitmap(input.Width, input.Height);

                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());

                        float R = (float)((pixel & 0x00FF0000) >> 16); 
                        float G = (float)((pixel & 0x0000FF00) >> 8); 
                        float B = (float)(pixel & 0x000000FF); 
                        double R1, G1, B1, R2, G2, B2;  
                        R1 = G1 = B1 = (R + G + B) / 3.0f;
                        R2 = G2 = B2 = (0.299*R + 0.587*G + 0.114*B);

                        UInt32 newPixel1 = 0xFF000000 | ((UInt32)R1 << 16) | ((UInt32)G1 << 8) | ((UInt32)B1);
                        UInt32 newPixel2 = 0xFF000000 | ((UInt32)R2 << 16) | ((UInt32)G2 << 8) | ((UInt32)B2);

                        UInt32 diffPixel = (newPixel2 - newPixel1) | 0xFF000000;

                        output1.SetPixel(i, j, Color.FromArgb((int)newPixel1));
                        output2.SetPixel(i, j, Color.FromArgb((int)newPixel2));
                        output3.SetPixel(i, j, Color.FromArgb((int)diffPixel));
                    }
                pictureBox2.Image = output1;
                pictureBox3.Image = output2;
                pictureBox7.Image = output3;
            }
        }

        private void RGB_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output3 = new Bitmap(input.Width, input.Height);
                Bitmap output4 = new Bitmap(input.Width, input.Height);
                Bitmap output5 = new Bitmap(input.Width, input.Height);

                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        float R = (float)((pixel & 0x00FF0000) >> 16);
                        float G = (float)((pixel & 0x0000FF00) >> 8); 
                        float B = (float)(pixel & 0x000000FF); 
                        
                        UInt32 newPixel3 = 0xFF000000 | ((UInt32)R << 16) | 0x00000000 | 0x00000000;
                        UInt32 newPixel4 = 0xFF000000 | 0x00000000 | ((UInt32)G << 8) | 0x00000000;
                        UInt32 newPixel5 = 0xFF000000 | 0x00000000 | 0x00000000 | ((UInt32)B);

                        output3.SetPixel(i, j, Color.FromArgb((int)newPixel3));
                        output4.SetPixel(i, j, Color.FromArgb((int)newPixel4));
                        output5.SetPixel(i, j, Color.FromArgb((int)newPixel5));
                    }
                pictureBox4.Image = output3;
                pictureBox5.Image = output4;
                pictureBox6.Image = output5;
                
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Bitmap picture = new Bitmap(pictureBox1.Image);
            Bitmap picture2 = new Bitmap(pictureBox2.Image);
            Bitmap picture3 = new Bitmap(pictureBox3.Image);

            int[] gray_array = new int[256];
            if (pictureBox2.Image != null)
            {
                for (int j = 0; j < picture2.Height; j++)
                    for (int i = 0; i < picture2.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(picture2.GetPixel(i, j).ToArgb());
                        int G = (int)((pixel & 0x00FF0000) >> 16);
                        gray_array[G] += 1;
                    }
            }

            int[] gray_array2 = new int[256];
            if (pictureBox3.Image != null)
            {
                for (int j = 0; j < picture3.Height; j++)
                    for (int i = 0; i < picture3.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(picture3.GetPixel(i, j).ToArgb());
                        int G = (int)((pixel & 0x00FF0000) >> 16);
                        gray_array2[G] += 1;
                    }
            }

            int[] red_array = new int[256];
            int[] green_array = new int[256];
            int[] blue_array = new int[256];

            if (pictureBox1.Image != null)
            {
                for (int j = 0; j < picture.Height; j++)
                    for (int i = 0; i < picture.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(picture.GetPixel(i, j).ToArgb());
                        int R = (int)((pixel & 0x00FF0000) >> 16);
                        red_array[R] += 1;
                        int G = (int)((pixel & 0x0000FF00) >> 8);
                        green_array[G] += 1;
                        int B = (int)(pixel & 0x000000FF);
                        blue_array[B] += 1;
                    }
                this.chart1.Series["Color"].Points.DataBindY(red_array);
                this.chart1.Series["Color"].Color = Color.Red;
            }



            if (comboBox1.SelectedIndex == 0) // gray
            {
                if (pictureBox2.Image != null)
                {
                    this.chart1.Series["Color"].Points.DataBindY(gray_array);
                    this.chart1.Series["Color"].Color = Color.Gray;
                }
            }
            if (comboBox1.SelectedIndex == 1) // red
            {
                if (pictureBox1.Image != null)
                {
                    this.chart1.Series["Color"].Points.DataBindY(red_array);
                    this.chart1.Series["Color"].Color = Color.Red;
                }
            }
            if (comboBox1.SelectedIndex == 2) // green
            {
                if (pictureBox1.Image != null)
                {
                    this.chart1.Series["Color"].Points.DataBindY(green_array);
                    this.chart1.Series["Color"].Color = Color.Green;
                }
            }
            if (comboBox1.SelectedIndex == 3) // blue
            {
                if (pictureBox1.Image != null)
                {
                    this.chart1.Series["Color"].Points.DataBindY(blue_array);
                    this.chart1.Series["Color"].Color = Color.Blue;
                }
            }
            if (comboBox1.SelectedIndex == 4) // gray2
            {
                if (pictureBox1.Image != null)
                {
                    this.chart1.Series["Color"].Points.DataBindY(gray_array2);
                    this.chart1.Series["Color"].Color = Color.Black;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap input = new Bitmap(pictureBox1.Image);
                Bitmap output = new Bitmap(input.Width, input.Height);

                for (int j = 0; j < input.Height; j++)
                    for (int i = 0; i < input.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(input.GetPixel(i, j).ToArgb());
                        float R = (float)((pixel & 0x00FF0000) >> 16);
                        float G = (float)((pixel & 0x0000FF00) >> 8);
                        float B = (float)(pixel & 0x000000FF);

                        float H, S, V;
                        H = S = V = 0;
                        RGBtoHSV(R, G, B, ref H, ref S, ref V);
                        H = (H + trackBar2.Value) % 360;
                        S = (S + trackBar1.Value / 100) > 1 ? 1 : (S + trackBar1.Value / 100);
                        V = (V + trackBar3.Value / 100) > 1 ? 1 : (V + trackBar3.Value / 100);

                        HSVtoRGB(H, S, V, ref R, ref G, ref B);

                        UInt32 newPixel = 0xFF000000 | ((UInt32)R << 16) | ((UInt32)G << 8) | ((UInt32)B);


                        output.SetPixel(i, j, Color.FromArgb((int)newPixel));

                    }
                pictureBox8.Image = output;
                pictureBox8.Image.Save(@"C:\Users\Igor\Desktop\parrot.jpg", ImageFormat.Jpeg);

            }
        }

        private void TrackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void TrackBar2_Scroll(object sender, EventArgs e)
        {

        }

        private void TrackBar3_Scroll(object sender, EventArgs e)
        {

        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
