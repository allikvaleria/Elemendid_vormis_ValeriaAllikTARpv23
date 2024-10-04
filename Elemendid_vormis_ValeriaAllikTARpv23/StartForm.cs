namespace Elemendid_vormis_ValeriaAllikTARpv23
{
    public partial class StartForm : Form
    {
        List<string> elemendid = new List<string> { "Nupp", "Silt", "Pilt", "Märkruut", "Raadionupp", "Raadionupp1", "Tekstikast" };
        List<string> rbtn_list = new List<string> { "Üks", "Kaks", "Kolm" };
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pbox, pbox2;
        CheckBox chk1, chk2;
        RadioButton rbtn, rbtn1, rbtn2, rbtn3;
        TextBox txt;
        public StartForm()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid : ");
            foreach(var element in elemendid)
            {
                tn.Nodes.Add(new TreeNode(element));
            }

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
            //nupp
            btn = new Button();
            btn.Text = "Vajuta siia";
            btn.Height = 50;
            btn.Width = 70;
            btn.Location = new Point(150, 50);
            btn.Click += Btn_Click;

            //silt-label
            lbl= new Label();
            lbl.Text = "Aknade elemendid c# abil";
            lbl.Font = new Font("Arial", 30, FontStyle.Italic);
            lbl.Size = new Size(550, 50);
            lbl.Location = new Point(150, 0);
            lbl.MouseHover += Lbl_MouseHover;
            lbl.MouseLeave += Lbl_MouseLeave;

            //pbox-picturebox
            pbox= new PictureBox();
            pbox.Size = new Size(80, 80);
            pbox.Location = new Point(150, btn.Height+lbl.Height+5);
            pbox.SizeMode = PictureBoxSizeMode.Zoom;
            pbox.Image = Image.FromFile(@"..\..\..\bunny.jpg");
            pbox.DoubleClick += Pbox_DoubleClick;

        }
        int tt = 0;
        private void Pbox_DoubleClick(object? sender, EventArgs e)
        {
            string[] pildid = { "bunnies.jpg", "cat.jpg", "flowerbunny.jpg", "kitten.jpg" };
            string fail=pildid[tt];
            pbox.Image= Image.FromFile(@"..\..\..\"+fail);
            tt++;
            if (tt == 4) { tt = 0; }
        }

        private void Lbl_MouseLeave(object? sender, EventArgs e)
        {
            lbl.Font = new Font("Times New Roman", 30, FontStyle.Italic);
            lbl.BackColor = Color.Pink;
            lbl.ForeColor = Color.LavenderBlush;
        }

        private void Lbl_MouseHover(object? sender, EventArgs e)
        {
            lbl.Font = new Font("Times New Roman", 30, FontStyle.Italic);
            lbl.BackColor = Color.Lavender;
            lbl.ForeColor = Color.LightGray;
        }

        int t = 0;
        private void Btn_Click(object? sender, EventArgs e)
        {
            t++;
            if (t % 2 == 0)
            {
                btn.BackColor = Color.White;
            }
            else
            {
                btn.BackColor = Color.Lavender;
            }
        }


        private void Tree_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "Nupp")
            {
                Controls.Add(btn);
            }
            else if (e.Node.Text == "Silt")
            {
                Controls.Add(lbl);
            }
            else if (e.Node.Text == "Pilt")
            {
                Controls.Add(pbox);
            }
            else if (e.Node.Text == "Märkruut")
            {
                chk1=new CheckBox();
                chk1.Checked = false;
                chk1.Text = e.Node.Text;
                chk1.Size = new Size(chk1.Text.Length*10, chk1.Size.Height);
                chk1.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + 10);
                chk1.CheckedChanged += new EventHandler(Chk1_CheckedChanged);

                chk2 = new CheckBox();
                chk2.Checked = false;
                chk2.BackgroundImage = Image.FromFile(@"..\..\..\bunny.jpg");
                chk2.BackgroundImageLayout = ImageLayout.Zoom;
                chk2.Size = new Size(100, 100);
                chk2.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + chk1.Height + 15);
                
                
                //II var.
                //pbox2 = new PictureBox();
                //pbox2.Image = Image.FromFile(@"..\..\..\bunny.jpg");
                //pbox2.SizeMode = PictureBoxSizeMode.Zoom;
                //pbox2.Size = new Size(100, 100);
                //pbox2.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + chk1.Height + 15);

                //CheckBox chk2 = new CheckBox();
                //chk2.Checked = false;
                //chk2.Size = new Size(100, 100);
                //chk2.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + chk1.Height + 15);
                //chk2.CheckedChanged += Chk2_CheckedChanged;

                //Controls.Add(pbox2);
                Controls.Add(chk1);
                Controls.Add(chk2);
            }
            else if (e.Node.Text == "Raadionupp")
            {
                rbtn1=new RadioButton();
                rbtn1.Checked = false;
                rbtn1.Text = "Bisque";
                rbtn1.Location = new Point(150, 420);
                rbtn1.CheckedChanged += Rbtn1_CheckedChanged;

                rbtn2 = new RadioButton();
                rbtn2.Checked = false;
                rbtn2.Text = "Teal";
                rbtn2.Location = new Point(150, 440);
                rbtn2.CheckedChanged += Rbtn2_CheckedChanged;

                rbtn3 = new RadioButton();
                rbtn3.Checked = false;
                rbtn3.Text = "DarkRed";
                rbtn3.Location = new Point(150, 460);
                rbtn3.CheckedChanged += Rbtn3_CheckedChanged;

                Controls.Add(rbtn1);
                Controls.Add(rbtn2);
                Controls.Add(rbtn3);
            }
            else if (e.Node.Text == "Raadionupp1")
            {
                int x = 20;
                for (int i = 0; i < rbtn_list.Count; i++)
                {
                    rbtn = new RadioButton();
                    rbtn.Checked = false;
                    rbtn.Text = rbtn_list[i];
                    rbtn.Height = x;
                    x = x + 20;
                    rbtn.Location = new Point(150, btn.Height + lbl.Height + pbox.Height + chk1.Height + chk2.Height + rbtn.Height);
                    rbtn.CheckedChanged += new EventHandler(Btn_CheckedChanged);

                    Controls.Add(rbtn);
                }
            }
            else if(e.Node.Text == "Tekstikast")
            {
                txt=new TextBox();
                txt.Location = new Point(150 + btn.Width + 5, btn.Height);
                txt.Font = new Font("Arial", 20);
                txt.Width = 200;
                txt.TextChanged += Txt_TextChanged;
                Controls.Add(txt);
            }
        }

        private void Txt_TextChanged(object? sender, EventArgs e)
        {
            lbl.Text = txt.Text;
        }

        private void Btn_CheckedChanged(object? sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            lbl.Text = rb.Text;
        }

        private void Rbtn1_CheckedChanged(object? sender, EventArgs e)
        {
            rbtn1.Font = new Font("Brush Script MT", 15, FontStyle.Italic);
            this.BackColor = Color.Bisque;
        }

        private void Rbtn2_CheckedChanged(object? sender, EventArgs e)
        {
            rbtn2.Font = new Font("Brush Script MT", 15, FontStyle.Italic);
            this.BackColor = Color.Teal;

        }

        private void Rbtn3_CheckedChanged(object? sender, EventArgs e)
        {
            rbtn3.Font = new Font("Brush Script MT", 15, FontStyle.Italic);
            this.BackColor = Color.DarkRed;
        }

        private void Chk1_CheckedChanged(object? sender, EventArgs e)
        {
            if (chk1.Checked && chk2.Checked) 
            { 
                lbl.BorderStyle = BorderStyle.Fixed3D;
                pbox.BorderStyle = BorderStyle.Fixed3D;
            }
            else if (chk1.Checked)
            {
                lbl.BorderStyle = BorderStyle.Fixed3D;
                pbox.BorderStyle = BorderStyle.None;
            }
            else if (chk2.Checked)
            {
                pbox.BorderStyle = BorderStyle.Fixed3D;
                lbl.BorderStyle = BorderStyle.None;
            }
            else
            {
                lbl.BorderStyle = BorderStyle.None;
                pbox.BorderStyle = BorderStyle.None;
            }
        }
    }
}
