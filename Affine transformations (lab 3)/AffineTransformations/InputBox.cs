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
    public partial class InputBox : Form
    {
        public InputBox()
        {
            InitializeComponent();
        }

        public InputBox(string message, string title = "", string defaultValue = "")
        {
            InitializeComponent();
            Text = title;
            label1.Text = message;
            textBox1.Text = defaultValue;
        }

        public string ResultText { get; private set; } = "";

        private void button1_Click(object sender, EventArgs e)
        {
            ResultText = textBox1.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void InputBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }
    }
}
