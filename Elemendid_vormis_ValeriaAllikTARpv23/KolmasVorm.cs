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
    public partial class KolmasVorm : Form
    {
        List<string> margid = new List<string> { "+", "-", "×", "÷" };
        List<string> teemaValik_list = new List<string> { "Must", "Roosa", "Kollane" };
        Label lbl, timelabel, plusLeftLabel, plusRightLabel, minusLeftLabel, 
            minusRightLabel, timesLeftLabel, timesRightLabel, dividedLeftLabel, 
            dividedRightLabel, equals, signs;
        TableLayoutPanel tbl;
        FlowLayoutPanel flp;
        NumericUpDown sum, difference, product, quotient;

        Button startButton, teemaValik, giveUp, timer20, hintButton, closeButton;



        System.Windows.Forms.Timer timer1;
        ListBox lb;

        Random randomizer = new Random();

        int addend1;
        int addend2;
 
        int minuend;
        int subtrahend;
 
        int multiplicand;
        int multiplier;

        int dividend;
        int divisor;

        int timeLeft;

        string ValudTeema;
        public KolmasVorm(int w, int h)
        {

            this.Width = w;
            this.Height = h;
            this.Text = "Math quiz";

            //TableLayoutPanel
            tbl = new TableLayoutPanel();
            tbl.BorderStyle = BorderStyle.Fixed3D;
            tbl.BackColor = Color.Ivory;
            tbl.AutoSize = true;
            tbl.ColumnCount = 5;
            tbl.RowCount = 4;

            //FlowLayoutPanel
            flp = new FlowLayoutPanel();
            flp.Dock = DockStyle.Fill;
            flp.FlowDirection = FlowDirection.RightToLeft;
            flp.BorderStyle = BorderStyle.Fixed3D;
            flp.Controls.Add(tbl);

            for (int i = 0; i < 5; i++)
            {
                tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20));
            }
            for (int i = 0; i < 4; i++)
            {
                tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }

            //NumericUpDown
            //sum
            sum = new NumericUpDown();
            sum.Font = new Font("Calibri", 18, FontStyle.Regular);
            sum.Width = 100;
            sum.Text = "sum";
            sum.BackColor = Color.AliceBlue;
            sum.Enter += Sum_Enter;

            //difference
            difference = new NumericUpDown();
            difference.Font = new Font("Calibri", 18, FontStyle.Regular);
            difference.Width = 100;
            difference.Text = "min";
            difference.BackColor = Color.AliceBlue;
            difference.Enter += Difference_Enter;

            //product
            product = new NumericUpDown();
            product.Font = new Font("Calibri", 18, FontStyle.Regular);
            product.Width = 100;
            product.Text = "umn";
            product.BackColor = Color.AliceBlue;
            product.Enter += Product_Enter;

            //quotient
            quotient = new NumericUpDown();
            quotient.Font = new Font("Calibri", 18, FontStyle.Regular);
            quotient.Width = 100;
            quotient.Text = "del";
            quotient.BackColor = Color.AliceBlue;
            quotient.Enter += Quotient_Enter;

            tbl.Controls.Add(sum, 4, 0);
            tbl.Controls.Add(difference, 4, 1);
            tbl.Controls.Add(product, 4, 2);
            tbl.Controls.Add(quotient, 4, 3);

            timelabel = new Label();
            timelabel.AutoSize = true;
            timelabel.Text = "Time left: 60 seconds";
            timelabel.Font = new Font("Harlow Solid Italic", 15);
            timelabel.Dock= DockStyle.Top;
            timelabel.BorderStyle = BorderStyle.FixedSingle;
            timelabel.BackColor = Color.AliceBlue;

            //Label +
            plusLeftLabel = new Label();
            plusLeftLabel.Text = "?";
            plusLeftLabel.Font = new Font("Arial", 18);
            plusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
  
            plusRightLabel = new Label();
            plusRightLabel.Text = "?";
            plusRightLabel.Font = new Font("Arial", 18);
            plusRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            //Lable -
            minusLeftLabel = new Label();
            minusLeftLabel.Text = "?";
            minusLeftLabel.Font = new Font("Arial", 18);
            minusLeftLabel.TextAlign = ContentAlignment.MiddleCenter;
          
            minusRightLabel = new Label();
            minusRightLabel.Text = "?";
            minusRightLabel.Font = new Font("Arial", 18);
            minusRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            //Lable ×
            timesLeftLabel = new Label();
            timesLeftLabel.Text = "?";
            timesLeftLabel.Font = new Font("Arial", 18);
            timesLeftLabel.TextAlign = ContentAlignment.MiddleCenter;

            timesRightLabel = new Label();
            timesRightLabel.Text = "?";
            timesRightLabel.Font = new Font("Arial", 18);
            timesRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            //Lable ÷
            dividedLeftLabel = new Label();
            dividedLeftLabel.Text = "?";
            dividedLeftLabel.Font = new Font("Arial", 18);
            dividedLeftLabel.TextAlign = ContentAlignment.MiddleCenter;

            dividedRightLabel = new Label();
            dividedRightLabel.Text = "?";
            dividedRightLabel.Font = new Font("Arial", 18);
            dividedRightLabel.TextAlign = ContentAlignment.MiddleCenter;

            for (int i = 0; i < 4; i++)
            {
                equals = new Label();
                equals.AutoSize = false;
                equals.Dock = DockStyle.Fill;
                equals.TextAlign = ContentAlignment.MiddleCenter;
                equals.Font = new Font("Calibri", 15, FontStyle.Regular);
                equals.Text = margid[i];

                tbl.Controls.Add(equals, 1, i);


                signs = new Label();
                signs.AutoSize = false;
                signs.Dock = DockStyle.Fill;
                signs.TextAlign = ContentAlignment.MiddleCenter;
                signs.Font = new Font("Calibri", 20, FontStyle.Regular);
                signs.Text = "=";

                tbl.Controls.Add(signs, 3, i);
            }

            tbl.Controls.Add(plusLeftLabel, 0, 0);
            tbl.Controls.Add(plusRightLabel, 2, 0);

            tbl.Controls.Add(minusLeftLabel, 0, 1);
            tbl.Controls.Add(minusRightLabel, 2, 1);

            tbl.Controls.Add(timesLeftLabel, 0, 2);
            tbl.Controls.Add(timesRightLabel, 2, 2);

            tbl.Controls.Add(dividedLeftLabel, 0, 3);
            tbl.Controls.Add(dividedRightLabel, 2, 3);

            //nupp startButton
            startButton = new Button();
            startButton.Text = "Start the quiz";
            startButton.Font = new Font("Harlow Solid Italic", 14);
            startButton.BackColor = Color.LightGreen;
            startButton.AutoSize = true;
            startButton.Location = new Point(0, 50);
            startButton.TabIndex = 0;
            startButton.Click += StartButton_Click;

            timer20 = new Button();
            timer20.Text = "Timer 20sek";
            timer20.Font = new Font("Harlow Solid Italic", 14);
            timer20.BackColor = Color.LightSeaGreen;
            timer20.AutoSize = true;
            timer20.Location = new Point(0, 100);
            timer20.TabIndex = 0;
            timer20.Click += Timer20_Click;


            //nupp teema valik (värv)
            teemaValik = new Button();
            teemaValik.Text = "Choose a color theme";
            teemaValik.Font = new Font("Harlow Solid Italic", 14);

            teemaValik.BackColor = Color.LemonChiffon;
            teemaValik.AutoSize = true;
            teemaValik.Location = new Point(400, 300);
            teemaValik.Click += TeemaValik_Click;

            //nupp giveUp
            giveUp = new Button();
            giveUp.Text = "Give up";
            giveUp.Font = new Font("Harlow Solid Italic", 14);
            giveUp.BackColor = Color.LightCoral;
            giveUp.AutoSize = true;
            giveUp.Location = new Point(0, 150);
            giveUp.Click += GiveUp_Click;

            //nupp hint
            hintButton=new Button();
            hintButton.Text = "Hint";
            hintButton.Font = new Font("Harlow Solid Italic", 14);
            hintButton.BackColor = Color.CadetBlue;
            hintButton.AutoSize = true;
            hintButton.Location = new Point(0, 200);
            hintButton.Click += HintButton_Click;

            //nupp close
            closeButton=new Button();
            closeButton.Text = "Close";
            closeButton.Font = new Font("Harlow Solid Italic", 14);
            closeButton.BackColor = Color.MediumOrchid;
            closeButton.AutoSize = true;
            closeButton.Location = new Point(0, 250);
            closeButton.Click += CloseButton_Click;

            //Timer
            timer1 = new System.Windows.Forms.Timer();
            timer1.Interval = 1000;
            timer1.Tick += new EventHandler(timer1_Tick);

            this.Controls.Add(timer20);
            this.Controls.Add(hintButton);
            this.Controls.Add(startButton);
            this.Controls.Add(closeButton);
            this.Controls.Add(teemaValik);
            this.Controls.Add(giveUp);
            this.Controls.Add(flp);
            this.Controls.Add(timelabel);
        }

        private void CloseButton_Click(object? sender, EventArgs e)
        {
            this.Close();
        }

        private void HintButton_Click(object? sender, EventArgs e)
        {
            string hintMessage = "Here are your hints:\n";

            hintMessage += "Sum Hint : " + (addend1 + addend2);
            hintMessage += "\nDifference Hint : " + (minuend - subtrahend);
            hintMessage += "\nProduct Hint : " + (multiplicand * multiplier);
            hintMessage += "\nQuotient Hint : " + (dividend / divisor);

            MessageBox.Show(hintMessage, "Hints");
        }

        private void Timer20_Click(object? sender, EventArgs e)
        {
            timeLeft = 20;
            timelabel.Text = "Time left 20 seconds";
        }

        private void GiveUp_Click(object? sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("You decided to give up! Better luck next time.");
        }

        

        private void TeemaValik_Click(object? sender, EventArgs e)
        {
            // If a ListBox already exists, remove it
            if (lb != null)
            {
                Controls.Remove(lb);
            }


            lb = new ListBox();
            foreach (string item in teemaValik_list)
            {
                lb.Items.Add(item);
            }


            lb.Height = 60;
            lb.Width = 125;
            lb.Location = new Point(390, 350);

            lb.Height = 20;
            lb.Width = 120;
            lb.Location = new Point(445, 350);

            lb.SelectedIndexChanged += Lb_SelectedIndexChanged;
            Controls.Add(lb);
            lb.BringToFront(); // Ensure the ListBox is on top
        }

        private void Lb_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (lb.SelectedItem != null)
            {
                ValudTeema = lb.SelectedItem.ToString();

                if (ValudTeema == "Must")
                {
                    this.BackColor = Color.Black;
                }
                else if (ValudTeema == "Roosa")
                {

                    this.BackColor = Color.LavenderBlush;
                }
                else if (ValudTeema == "Kollane")
                {
                    this.BackColor = Color.LightYellow;
                }
                else
                {
                    this.BackColor = Color.White; // Fallback color
                }
            }
        }

        private void Quotient_Enter(object? sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Product_Enter(object? sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Difference_Enter(object? sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Sum_Enter(object? sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!",
                                "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timelabel.Text = "Time left " + timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timelabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        private void StartButton_Click(object? sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;

        }

        public void StartTheQuiz()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            sum.Value = 0;
            sum.BackColor = Color.White;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;
            difference.BackColor = Color.White;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;
            product.BackColor = Color.White;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            quotient.Value = 0;
            quotient.BackColor = Color.White;

            // Start the timer.
            timeLeft = 60;
            timelabel.Text = "Time left 60 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            bool allCorrect = true;

            if (addend1 + addend2 == sum.Value)
                sum.BackColor = Color.LightGreen;
            else
            {
                sum.BackColor = Color.White;
                allCorrect = false;
            }

            if (minuend - subtrahend == difference.Value)
                difference.BackColor = Color.LightGreen;
            else
            {
                difference.BackColor = Color.White;
                allCorrect = false;
            }

            if (multiplicand * multiplier == product.Value)
                product.BackColor = Color.LightGreen;
            else
            {
                product.BackColor = Color.White;
                allCorrect = false;
            }

            if (dividend / divisor == quotient.Value)
                quotient.BackColor = Color.LightGreen;
            else
            {
                quotient.BackColor = Color.White;
                allCorrect = false;
            }

            return allCorrect;
        }
    }
}

