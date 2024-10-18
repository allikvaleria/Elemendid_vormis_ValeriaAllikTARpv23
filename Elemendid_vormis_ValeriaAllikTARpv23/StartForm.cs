using Microsoft.VisualBasic;
using System.Data;
using System.Xml.Linq;

namespace Elemendid_vormis_ValeriaAllikTARpv23
{
    public partial class StartForm : Form
    {
        List<string> elemendid = new List<string> 
        { "Nupp", "Silt", "Pilt", "Märkruut", "Raadionupp", "Raadionupp1", "Tekstikast", "Loetelu", "Tabel", "Dialogi aknad", "Tutorial I", "Tutorial II", "Tutorial III"};
        List<string> rbtn_list = new List<string> { "Üks", "Kaks", "Kolm" };
        TreeView tree;
        Button btn, btn2, btn3, btn4;
        Label lbl;
        PictureBox pbox, pbox2;
        CheckBox chk1, chk2;
        RadioButton rbtn, rbtn1, rbtn2, rbtn3;
        TextBox txt;
        ListBox lb;
        DataSet ds;
        DataGridView dg;
        public StartForm()
        {
            this.Height = 800;
            this.Width = 1000;
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

            //nupp TeineVorm
            btn2 = new Button();
            btn2.Text = "Picture Viewer";
            btn2.Height = 50;
            btn2.Width = 70;
            btn2.Location = new Point(700, 50);
            btn2.Click += Btn2_Click;

            //nupp KolmasVorm
            btn3 = new Button();
            btn3.Text = "Math quiz";
            btn3.Height = 50;
            btn3.Width = 70;
            btn3.Location = new Point(700, 100);
            btn3.Click += Btn3_Click;

            //nupp NeljasVorm
            btn4 = new Button();
            btn4.Text = "Matching Game";
            btn4.Height = 50;
            btn4.Width = 70;
            btn4.Location = new Point(700, 150);
            btn4.Click += Btn4_Click;

            //silt-label
            lbl = new Label();
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

        private void Btn2_Click(object? sender, EventArgs e)
        {
            btn2.BackColor = Color.LavenderBlush;
            TeineVorm teineVorm = new TeineVorm(800, 900);
            teineVorm.Show();
        }

        private void Btn3_Click(object? sender, EventArgs e)
        {
            btn3.BackColor = Color.LemonChiffon;
            KolmasVorm kolmasVorm = new KolmasVorm(800, 900);
            kolmasVorm.Show();
        }

        private void Btn4_Click(object? sender, EventArgs e)
        {
            btn4.BackColor = Color.LightCyan; 
            NeljasVorm neljasVorm = new NeljasVorm(800, 900);
            neljasVorm.Show();
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
                txt.Font = new Font("Arial", 10);
                txt.Width = 200;
                txt.TextChanged += Txt_TextChanged;
                Controls.Add(txt);
            }
            else if (e.Node.Text == "Loetelu")
            {
                lb = new ListBox();
                foreach(string item in rbtn_list)
                {
                    lb.Items.Add(item);
                }
                lb.Height = 30;
                lb.Location = new Point(160 + btn.Width + txt.Width, btn.Height);
                lb.SelectedIndexChanged += Lb_SelectedIndexChanged;
                Controls.Add(lb);
            }
            else if (e.Node.Text == "Tabel")
            {
                ds = new DataSet("XML file");
                ds.ReadXml(@"..\..\..\menu.xml");
                dg = new DataGridView();
                dg.Location = new Point(155 + chk1.Width + 15, txt.Height + lbl.Height + 10);
                dg.DataSource = ds;
                dg.DataMember = "food";
                dg.RowHeaderMouseClick += Dg_RowHeaderMouseClick;
                Controls.Add(dg);
            }
            else if (e.Node.Text == "Dialogaknad")
            {
                MessageBox.Show("Dialoog", "See on lihtne aken");
                var vastus = MessageBox.Show("Sisestame andmed", "Kas tahad InputBoxi kasutada?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (vastus == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta midagi siia", "andmete sisestamine"); MessageBox.Show("Oli sisestanud : " + text);
                    Random random = new Random();
                    DataRow dr = ds.Tables["food"].NewRow();
                    dr["name"] = text;
                    dr["price"] = "$" + (random.NextSingle() * 10).ToString();
                    dr["description"] = "Väga maitsev ";
                    dr["calories"] = random.Next(10, 100);

                    ds.Tables["food"].Rows.Add(dr);
                    if (ds == null) { return; }
                    ds.WriteXml(@"..\..\..\menu.xml");
                    MessageBox.Show("Oli sisestatud" + text);
                }
                //minu var
                //MessageBox.Show("Dialoog", "See on lihtne aken");
                //var vastus = MessageBox.Show("Sisestame andmed", "Kas tahad InputBoxi kasutada?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //if (vastus == DialogResult.Yes)
                //{
                //    string nimi = Interaction.InputBox("Toidu nimi");
                //    string hind = Interaction.InputBox("Hind");
                //    string kirjeldus = Interaction.InputBox("Kirjeldus");
                //    string kalorid = Interaction.InputBox("Kalorid");

                //    var xdoc = XDocument.Load("menu.xml");
                //    xdoc.Element("menu").Add(new XElement("food",
                //        new XElement("nimi", nimi),
                //        new XElement("hind", hind),
                //        new XElement("kirjeldus", kirjeldus),
                //        new XElement("kalorid", kalorid)
                //    ));

                //    ds.WriteXml(@"..\..\..\menu.xml");
                //    MessageBox.Show("Toit lisatud: " + nimi);
                //}
            }
            else if (e.Node.Text== "Tutorial I")
            {
                Controls.Add(btn2);
            }
            else if(e.Node.Text == "Tutorial II")
            {
                Controls.Add(btn3);
            }
            else if(e.Node.Text == "Tutorial III")
            {
                Controls.Add(btn4);
            }
        }
        

        private void Dg_RowHeaderMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {
            txt.Text=dg.Rows[e.RowIndex].Cells[0].Value.ToString()+ " hind " + dg.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void Lb_SelectedIndexChanged(object? sender, EventArgs e)
        {
            switch (lb.SelectedIndex)
            {
                case 0:tree.BackColor = Color.Sienna; break;
                case 1:tree.BackColor = Color.Silver; break;
                case 2:tree.BackColor = Color.SlateBlue; break;
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
