using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elemendid_vormis_ValeriaAllikTARpv23
{
    public partial class TeineVorm : Form
    {
        TableLayoutPanel tbl;

        Button btn, btn2, btn3, btn4, btn5, btn6, btn7, btn8;

      

        FlowLayoutPanel flp;
        PictureBox pictureBox1, zoomPbox;
        ColorDialog colorDialog1;
        OpenFileDialog openFileDialog1;
        CheckBox chk;
        Image img;

        

        public TeineVorm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Picture Viewer";
            tbl = new TableLayoutPanel();
            tbl.Dock = DockStyle.Fill;

            //PictureBox
            pictureBox1 = new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            tbl.Controls.Add(pictureBox1);
            tbl.SetColumnSpan(pictureBox1, 2);

            //Checkbox
            chk = new CheckBox();
            chk.Text = "Stretch";
            chk.AutoSize = true;
            chk.CheckedChanged += Chk_CheckedChanged;
            tbl.Controls.Add(chk);

            //FlowLayoutPanel
            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.FlowDirection = FlowDirection.RightToLeft;

            //Button 'Show a picture'
            btn = new Button();
            btn.Text = "Show a picture";
            btn.AutoSize = true;
            btn.Click += Btn_Click;

            //Button 'Cleart the picture'
            btn2 = new Button();
            btn2.Text = "Clear the picture";
            btn2.AutoSize = true;
            btn2.Click += Btn2_Click;

            //Button 'Set the background color'
            btn3 = new Button();
            btn3.Text = "Set the background color";
            btn3.AutoSize = true;
            btn3.Click += Btn3_Click;

            //Button 'Close'
            btn4 = new Button();
            btn4.Text = "Close";
            btn4.AutoSize = true;
            btn4.Click += Btn4_Click;

            //Button 'MustValge'
            btn5 = new Button();
            btn5.Text = "Black - White";
            btn5.AutoSize = true;
            btn5.Click += Btn5_Click;

            //Button 'Pilte pööramine'
            btn6 = new Button();
            btn6.Text = "Rotate image";
            btn6.AutoSize = true;
            btn6.Click += Btn6_Click;

            //Button 'Save a picture'
            btn7 = new Button();
            btn7.Text = "Save a picture";
            btn7.AutoSize = true;
            btn7.Click += Btn7_Click;

            //Button 'Picture blur'
            btn8 = new Button();
            btn8.Text = "Image distortion";
            btn8.AutoSize = true;
            btn8.Click += Btn8_Click;



            //controls add
            tbl.Controls.Add(flp);
            flp.Controls.Add(btn);
            flp.Controls.Add(btn2);
            flp.Controls.Add(btn3);
            flp.Controls.Add(btn4);
            flp.Controls.Add(btn5);
            flp.Controls.Add(btn6);
            flp.Controls.Add(btn7);
            flp.Controls.Add(btn8);

            //Proportsioonide paigaldamine Row'le ja Columnile
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 10));

            this.Controls.Add(tbl);

            // OpenFileDialog
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*",
                Title = "Select a picture file"
            };

            // ColorDialog
            colorDialog1 = new ColorDialog();

            

        }

        private void Btn8_Click(object? sender, EventArgs e)
        {
            if (pictureBox1.Image == null) return;

            Bitmap original = new Bitmap(pictureBox1.Image);
            Bitmap distorted = new Bitmap(original.Width, original.Height);

            for (int x = 0; x < original.Width; x++)
            {
                for (int y = 0; y < original.Height; y++)
                {
                    // Применяем искажение
                    int offsetY = (int)(10 * Math.Sin(2 * Math.PI * x / 30)); // Параметры искажения
                    int newY = y + offsetY;

                    // Проверяем границы
                    if (newY >= 0 && newY < original.Height)
                    {
                        distorted.SetPixel(x, newY, original.GetPixel(x, y));
                    }
                    else
                    {
                        distorted.SetPixel(x, y, original.GetPixel(x, y)); // Оставляем без изменений
                    }
                }
            }

            pictureBox1.Image = distorted;
            pictureBox1.Invalidate();
        }


        private void Btn7_Click(object? sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*"; 
                sfd.Title = "Save img";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    // Pildi salvestamine PNG-vormingus
                    pictureBox1.Image.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
            }
        }


        //Button pööramine

        private void Btn6_Click(object? sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                Bitmap pilt = new Bitmap(pictureBox1.Image);
                Bitmap pooraminePilt = new Bitmap(pilt.Width, pilt.Height);

                using (Graphics g = Graphics.FromImage(pooraminePilt))
                {
                    // Pööramine keskpunkti suhtes on määratud
                    g.TranslateTransform(pilt.Width / 2, pilt.Height / 2);
                    g.RotateTransform(90); 
                    g.TranslateTransform(-pilt.Width / 2, -pilt.Height / 2);
                    g.DrawImage(pilt, 0, 0);
                }

                pictureBox1.Image = pooraminePilt;
            }
        }


        private void Btn5_Click(object? sender, EventArgs e)
        {
            Bitmap sepiaEffect = (Bitmap)pictureBox1.Image.Clone();
            for (int yCoordinate = 0; yCoordinate < sepiaEffect.Height; yCoordinate++)
            {
                for (int xCoordinate = 0; xCoordinate < sepiaEffect.Width; xCoordinate++)
                {
                    Color color = sepiaEffect.GetPixel(xCoordinate, yCoordinate);
                    double grayColor = ((double)(color.R + color.G + color.B)) / 3.0d;
                    Color sepia = Color.FromArgb((byte)grayColor, (byte)(grayColor * 0.95), (byte)(grayColor * 0.82));
                    sepiaEffect.SetPixel(xCoordinate, yCoordinate, sepia);
                }
            }
            pictureBox1.Image = sepiaEffect;
        }

        //Button 'Close'
        private void Btn4_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        //Button 'Set the background color'
        private void Btn3_Click(object? sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                pictureBox1.BackColor = colorDialog1.Color;
        }

        //Button 'Cleart the picture'
        private void Btn2_Click(object? sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        //Button 'Show a picture'
        private void Btn_Click(object? sender, EventArgs e) 
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }

        private void Chk_CheckedChanged(object? sender, EventArgs e)
        {
            if (chk.Checked)
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            else
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
        }
    }
}
