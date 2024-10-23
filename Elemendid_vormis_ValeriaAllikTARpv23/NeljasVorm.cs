using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static System.Formats.Asn1.AsnWriter;

namespace Elemendid_vormis_ValeriaAllikTARpv23
{
    public partial class NeljasVorm : Form
    {
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        List<string> icons2 = new List<string>()
        {
            "&", "&", "@", "@", "$", "$", "g", "g",
            "a", "a", "c", "c", "p", "p", "o", "o"
        };
        List<string> icons3 = new List<string>()
        {
            "#", "#", "u", "u", "*", "*", "¤", "¤",
            "l", "l", "q", "q", "s", "s", "m", "m"
        };
        TableLayoutPanel tlp;
        Label firstClicked, secondClicked, timerLabel, scoreLabel;
        Random random = new Random();
        System.Windows.Forms.Timer timer1;
        System.Windows.Forms.Timer countdownTimer;
        Button btnPause, btnStart;
        RadioButton easy, medium, hard;

        int timeLeft = 60;
        int score = 0;

        public NeljasVorm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Matching Game";

            // Timer label
            timerLabel = new Label();
            timerLabel.Dock = DockStyle.Top;
            timerLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            timerLabel.TextAlign = ContentAlignment.MiddleCenter;
            timerLabel.Text = $"Time Left: {timeLeft} seconds";
            timerLabel.Height = 40;
            this.Controls.Add(timerLabel);

            //score
            scoreLabel = new Label();
            scoreLabel.Dock = DockStyle.Top;
            scoreLabel.Font = new Font("Arial", 16, FontStyle.Bold);
            scoreLabel.TextAlign = ContentAlignment.MiddleCenter;
            scoreLabel.Text = $"Score: {score}";
            scoreLabel.Height = 40;
            this.Controls.Add(scoreLabel);

            // TableLayoutPanel
            tlp = new TableLayoutPanel();
            tlp.BackColor = Color.CornflowerBlue;
            tlp.Dock = DockStyle.Top;
            tlp.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tlp.ColumnCount = 4;
            tlp.RowCount = 4;
            tlp.Height = 400;


            // Пропорции для Row и Column
            for (int i = 0; i < tlp.ColumnCount; i++)
            {
                tlp.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25));
            }

            for (int i = 0; i < tlp.RowCount; i++)
            {
                tlp.RowStyles.Add(new RowStyle(SizeType.Percent, 25));
            }

            this.Controls.Add(tlp);

            // Label
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Label lbl = new Label
                    {
                        BackColor = Color.CornflowerBlue,
                        AutoSize = false,
                        Size = new Size(80, 80),
                        Margin = new Padding(10),
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                        Text = "c" // Placeholder
                    };

                    lbl.Click += Lbl_Click;
                    tlp.Controls.Add(lbl, col, row);
                }
            }


            // Timer 
            timer1 = new System.Windows.Forms.Timer
            {
                Interval = 750
            };
            timer1.Tick += Timer1_Tick;

            countdownTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            countdownTimer.Tick += CountdownTimer_Tick;

            AssignIconsToSquares();

            //button pause
            btnPause = new Button();
            btnPause.Text = "Pause";
            btnPause.AutoSize = true;
            btnPause.Location = new Point(100, 650);
            btnPause.Click += BtnPause_Click;
            this.Controls.Add(btnPause);

            // Button start 
            btnStart = new Button();
            btnStart.Text = "Start Game";
            btnStart.Location = new Point(0, 650);
            btnStart.AutoSize = true;
            btnStart.Click += BtnStart_Click;
            this.Controls.Add(btnStart);

            //
            easy = new RadioButton();
            easy.Text = "Easy";
            easy.Location = new Point(200, 650);
            easy.CheckedChanged += Easy_CheckedChanged;
            this.Controls.Add(easy);

            //
            medium = new RadioButton();
            medium.Text = "Medium";
            medium.Location = new Point(320, 650);
            medium.CheckedChanged += Medium_CheckedChanged;
            this.Controls.Add(medium);

            //
            hard = new RadioButton();
            hard.Text = "Hard";
            hard.Location = new Point(440, 650);
            hard.CheckedChanged += Hard_CheckedChanged;
            this.Controls.Add(hard);
        }

        private void BtnStart_Click(object? sender, EventArgs e)
        {
            if (!easy.Checked && !medium.Checked && !hard.Checked)
            {
                MessageBox.Show("Please select a difficulty level before starting the game.", "Select Difficulty");
                return;
            }

            AssignIconsToSquares();
            countdownTimer.Start();
        }

        private void Hard_CheckedChanged(object? sender, EventArgs e)
        {
            if (hard.Checked)
            {
                timeLeft = 30;
                timerLabel.Text = $"Time Left: {timeLeft} seconds";
                AssignIcons3ToSquares();
                countdownTimer.Start();
            }
        }

        private void Medium_CheckedChanged(object? sender, EventArgs e)
        {
            if (medium.Checked)
            {
                timeLeft = 60;
                timerLabel.Text = $"Time Left: {timeLeft} seconds";
                AssignIcons2ToSquares();
                countdownTimer.Start();
            }
        }

        private void Easy_CheckedChanged(object? sender, EventArgs e)
        {
            if (easy.Checked)
            {
                timeLeft = 120;
                timerLabel.Text = $"Time Left: {timeLeft} seconds";
                countdownTimer.Start();
            }
        }

        private void BtnPause_Click(object? sender, EventArgs e)
        {
            if (countdownTimer.Enabled)
            {
                countdownTimer.Stop();
                timer1.Stop();
                btnPause.Text = "Resume";
            }
            else
            {
                countdownTimer.Start();
                btnPause.Text = "Pause";
            }
        }



        private void CountdownTimer_Tick(object? sender, EventArgs e)
        {
            timeLeft--;
            timerLabel.Text = $"Time Left: {timeLeft} seconds";

            if (timeLeft <= 0)
            {
                countdownTimer.Stop();
                MessageBox.Show("Time's up! You didn't match all the icons in time.", "\nGame Over");
                Close();
            }
        }

        private void Timer1_Tick(object? sender, EventArgs e)
        {
            timer1.Stop();
            firstClicked.ForeColor = firstClicked.BackColor;
            secondClicked.ForeColor = secondClicked.BackColor;

            firstClicked = null;
            secondClicked = null;
        }

        private void Lbl_Click(object? sender, EventArgs e)
        {
            if (timer1.Enabled) return;

            Label clickedLabel = sender as Label;

            if (clickedLabel != null)
            {
                if (clickedLabel.ForeColor == Color.Black) return;

                clickedLabel.ForeColor = Color.Black;

                if (firstClicked == null)
                {
                    firstClicked = clickedLabel;
                    return;
                }

                secondClicked = clickedLabel;
                secondClicked.ForeColor = Color.Black;

                if (firstClicked.Text == secondClicked.Text)
                {
                    UpdateScore(10);
                    firstClicked = null;
                    secondClicked = null;
                    CheckForWinner();
                    return;
                }

                timer1.Start();
            }
        }

        private void UpdateScore(int points)
        {
            score += points;
            scoreLabel.Text = $"Score: {score}";
        }

        private void CheckForWinner()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null && iconLabel.ForeColor == iconLabel.BackColor)
                    return;
            }

            MessageBox.Show($"You matched all the icons! Your score: {score}", "Congratulations");
            Close();
            timer1.Stop();
        }

        private void AssignIconsToSquares()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void AssignIcons2ToSquares()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons2.Count);
                    iconLabel.Text = icons2[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons2.RemoveAt(randomNumber);
                }
            }
        }
        private void AssignIcons3ToSquares()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons3.Count);
                    iconLabel.Text = icons3[randomNumber];
                    iconLabel.ForeColor = iconLabel.BackColor;
                    icons3.RemoveAt(randomNumber);
                }
            }
        }
    }
}
