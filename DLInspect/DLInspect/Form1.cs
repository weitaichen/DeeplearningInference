using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DLInspect
{
    public partial class Form1 : Form
    {
        ImageClassifierClient client;

        public Form1()
        {
            string url = "http://127.0.0.1:8000";
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            client = new ImageClassifierClient(url);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Select a file";
            openFileDialog.Filter = "All Files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                pictureBox1.Image = Image.FromFile(filePath);
                var result = client.ClassifyImageAsync(filePath).Result;
                label2.Text = result.class_name;
            }
        }
    }
}
