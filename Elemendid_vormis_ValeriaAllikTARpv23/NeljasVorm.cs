using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Elemendid_vormis_ValeriaAllikTARpv23
{
    public partial class NeljasVorm : Form
    {
        List<string> icons = new List<string>()
        {
            "!", "!", "N", "N", ",", ",", "k", "k",
            "b", "b", "v", "v", "w", "w", "z", "z"
        };
        TableLayoutPanel tlp;
        Label firstClicked, secondClicked, timerLabel;
        Random random = new Random();
        System.Windows.Forms.Timer timer1;
        System.Windows.Forms.Timer countdownTimer;
        int timeLeft = 60; 

        public NeljasVorm(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this.Text = "Matching Game";

            // Timer label
            timerLabel = new Label
            {
                Dock = DockStyle.Top,
                Font = new Font("Arial", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Text = $"Time Left: {timeLeft} seconds"
            };
            this.Controls.Add(timerLabel);

            // TableLayoutPanel
            tlp = new TableLayoutPanel
            {
                BackColor = Color.CornflowerBlue,
                Dock = DockStyle.Fill,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
                ColumnCount = 4,
                RowCount = 4
            };

            // Proportsioonide paigaldamine Row'le ja Columnile
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
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Font = new Font("Webdings", 48, FontStyle.Bold),
                        Text = "c" // Initial placeholder
                    };

                    tlp.Controls.Add(lbl, col, row);
                    lbl.Click += Lbl_Click;
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
            countdownTimer.Start(); 

            AssignIconsToSquares();
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
                    firstClicked = null;
                    secondClicked = null;
                    CheckForWinner();
                    return;
                }

                timer1.Start();
            }
        }

        private void CheckForWinner()
        {
            foreach (Control control in tlp.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null && iconLabel.ForeColor == iconLabel.BackColor)
                    return;
            }

            MessageBox.Show("You matched all the icons!", "Congratulations");
            Close();
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
    }
}
