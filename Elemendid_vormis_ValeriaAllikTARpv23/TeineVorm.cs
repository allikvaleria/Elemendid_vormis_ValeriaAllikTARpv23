using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Elemendid_vormis_ValeriaAllikTARpv23
{
    public partial class TeineVorm : Form
    {
        TableLayoutPanel tbl;
        Button btn, btn2, btn3, btn4;
        FlowLayoutPanel flp;
        PictureBox pictureBox1;
        ColorDialog colorDialog1;
        OpenFileDialog openFileDialog1;
        CheckBox chk;

        public TeineVorm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Picture Viewer";
            tbl = new TableLayoutPanel();
            tbl.Dock = DockStyle.Fill;

            //Proportsioonide paigaldamine Row'le ja Columnile
            tbl.RowCount = 2;
            tbl.ColumnCount = 2;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15));
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 85));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 90));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 10));
            
            tbl.Controls.Add(flp);

            //PictureBox
            pictureBox1= new PictureBox();
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            tbl.Controls.Add(pictureBox1);
            tbl.SetColumnSpan(pictureBox1, 2);

            // OpenFileDialog
            openFileDialog1 = new OpenFileDialog
            {
                Filter = "JPEG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|BMP Files (*.bmp)|*.bmp|All files (*.*)|*.*",
                Title = "Select a picture file"
            };

            // ColorDialog
            colorDialog1 = new ColorDialog();

            //FlowLayoutPanel
            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.FlowDirection = FlowDirection.RightToLeft;
            
            //Checkbox
            chk = new CheckBox();
            chk.Text = "Stretch";
            chk.AutoSize = true;
            flp.Controls.Add(chk);
            chk.CheckedChanged += Chk_CheckedChanged;

         
            //Button 'Show a picture'
            btn = new Button();
            btn.Text = "Show a picture";
            btn.AutoSize = true;
            flp.Controls.Add(btn);
            btn.Click += Btn_Click;

            //Button 'Cleart the picture'
            btn2 = new Button();
            btn2.Text = "Clear the picture";
            btn2.AutoSize = true;
            flp.Controls.Add(btn2);
            btn2.Click += Btn2_Click;

            //Button 'Set the background color'
            btn3 = new Button();
            btn3.Text = "Set the background color";
            btn3.AutoSize = true;
            flp.Controls.Add(btn3);
            btn3.Click += Btn3_Click;

            //Button 'Close'
            btn4 = new Button();
            btn4.Text = "Close";
            btn4.AutoSize = true;
            flp.Controls.Add(btn4);
            btn4.Click += Btn4_Click;

            this.Controls.Add(tbl);
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
