using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
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

                        output1.SetPixel(i, j, Color.FromArgb((int)newPixel1));
                        output2.SetPixel(i, j, Color.FromArgb((int)newPixel2));
                    }
                pictureBox2.Image = output1;
                pictureBox3.Image = output2;
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


            if (comboBox1.SelectedIndex == 0) // gray
            {
                
            }
            if (comboBox1.SelectedIndex == 1) // red
            {
                int[] red_array = new int[256];
                for (int j = 0; j < picture.Height; j++)
                    for (int i = 0; i < picture.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(picture.GetPixel(i, j).ToArgb());
                        int R = (int)((pixel & 0x00FF0000) >> 16);
                        red_array[R] += 1;
                    }
                this.chart1.Series["Color"].Points.DataBindY(red_array);
                this.chart1.Series["Color"].Color = Color.Red;
            }
            if (comboBox1.SelectedIndex == 2) // green
            {
                int[] green_array = new int[256];
                for (int j = 0; j < picture.Height; j++)
                    for (int i = 0; i < picture.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(picture.GetPixel(i, j).ToArgb());
                        int G = (int)((pixel & 0x0000FF00) >> 8);
                        green_array[G] += 1;
                    }
                this.chart1.Series["Color"].Points.DataBindY(green_array);
                this.chart1.Series["Color"].Color = Color.Green;
            }
            if (comboBox1.SelectedIndex == 3) // blue
            {
                int[] blue_array = new int[256];
                for (int j = 0; j < picture.Height; j++)
                    for (int i = 0; i < picture.Width; i++)
                    {
                        UInt32 pixel = (UInt32)(picture.GetPixel(i, j).ToArgb());
                        int B = (int)(pixel & 0x000000FF);
                        blue_array[B] += 1;
                    }
                this.chart1.Series["Color"].Points.DataBindY(blue_array);
                this.chart1.Series["Color"].Color = Color.Blue;
            }
        }
    }
}
