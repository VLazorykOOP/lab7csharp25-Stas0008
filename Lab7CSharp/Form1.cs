using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Task 1
        private void button1_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                richTextBox1.Text += $"[{DateTime.Now}] {textBox1.Text}\n";
                textBox1.Text = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = null;
        }

        //Task 2
        Bitmap loadedImage;
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.bmp;*.jpg;*.png";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                loadedImage = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = loadedImage;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("No image to save!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            saveFileDialog1.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                if (saveFileDialog1.FileName.EndsWith(".jpg"))
                    format = System.Drawing.Imaging.ImageFormat.Jpeg;
                else if (saveFileDialog1.FileName.EndsWith(".bmp"))
                    format = System.Drawing.Imaging.ImageFormat.Bmp;

                pictureBox1.Image.Save(saveFileDialog1.FileName, format);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (loadedImage == null) return;

            var scaleX = (double)loadedImage.Width / pictureBox1.Width;
            var scaleY = (double)loadedImage.Height / pictureBox1.Height;

            int imgX = (int)(e.X * scaleX);
            int imgY = (int)(e.Y * scaleY);

            if (imgX >= 0 && imgX < loadedImage.Width && imgY >= 0 && imgY < loadedImage.Height)
            {
                Color pickedColor = loadedImage.GetPixel(imgX, imgY);

                pictureBox2.BackColor = pickedColor;
                label1.Text = $"R: {pickedColor.R} G: {pickedColor.G} B: {pickedColor.B}";
            }
        }

        //Task 3
        private Figure[] figures;
        private Random rand = new Random();
        private Bitmap bmp;
        private void button5_Click(object sender, EventArgs e)
        {
            int n = int.Parse(textBox2.Text);
            figures = new Figure[n];

            bmp = new Bitmap(pictureBox3.Width, pictureBox3.Height);
            Graphics g = Graphics.FromImage(bmp);

            for (int i = 0; i < n; i++)
            {
                int x = rand.Next(20, pictureBox3.Width - 40);
                int y = rand.Next(20, pictureBox3.Height - 40);
                Color color = Color.FromName(comboBox2.SelectedItem.ToString());
                string text = textBox3.Text;

                switch (comboBox1.SelectedItem.ToString())
                {
                    case "Square":
                        figures[i] = new Square(x, y, color, text, int.Parse(textBox4.Text));
                        break;
                    case "Rectangle":
                        figures[i] = new Rectangle(x, y, color, text, int.Parse(textBox5.Text), int.Parse(textBox6.Text));
                        break;
                    case "Triangle":
                        figures[i] = new Triangle(x, y, color, text, int.Parse(textBox7.Text));
                        break;
                    case "Circle":
                        figures[i] = new Circle(x, y, color, text, int.Parse(textBox8.Text));
                        break;
                }
                figures[i].Draw(g);
            }
            pictureBox3.Image = bmp;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = null;

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
    }
}
