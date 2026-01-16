using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExecLauncher
{
    public class ExecFree : Form
    {
        Panel keyPanel, mainPanel;
        string correctKey = "a1sw20s#209)293^dh@#203";

        public ExecFree()
        {
            this.Size = new Size(600, 400);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(15, 15, 20);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Панель Ключа
            keyPanel = new Panel { Dock = DockStyle.Fill };
            Label title = new Label { Text = "EXEC FREE VERSION", ForeColor = Color.White, Font = new Font("Arial Black", 20), Location = new Point(120, 40), AutoSize = true };
            
            Button getBtn = new Button { 
                Text = "GET KEY (TELEGRAM)", 
                Size = new Size(250, 50), Location = new Point(175, 120), 
                FlatStyle = FlatStyle.Flat, ForeColor = Color.Cyan, BackColor = Color.FromArgb(30,30,50) 
            };
            getBtn.Click += (s, e) => { System.Diagnostics.Process.Start("https://t.me/+8YxfJI0QeZtmMjUy"); };

            TextBox input = new TextBox { Location = new Point(150, 200), Size = new Size(300, 40), BackColor = Color.Black, ForeColor = Color.White, Font = new Font("Consolas", 12) };
            
            Button checkBtn = new Button { 
                Text = "LOGIN", 
                Size = new Size(100, 40), Location = new Point(250, 250), 
                FlatStyle = FlatStyle.Flat, ForeColor = Color.Lime 
            };
            checkBtn.Click += (s, e) => {
                if (input.Text == correctKey) { keyPanel.Visible = false; mainPanel.Visible = true; }
                else { MessageBox.Show("WRONG KEY, AZER!"); }
            };

            keyPanel.Controls.AddRange(new Control[] { title, getBtn, input, checkBtn });
            this.Controls.Add(keyPanel);

            // Основная Панель (Интерфейс чита)
            mainPanel = new Panel { Dock = DockStyle.Fill, Visible = false };
            RichTextBox editor = new RichTextBox { Location = new Point(20, 60), Size = new Size(380, 250), BackColor = Color.FromArgb(25, 25, 35), ForeColor = Color.SpringGreen, BorderStyle = BorderStyle.None };
            Button exec = new Button { Text = "EXECUTE", Location = new Point(420, 60), Size = new Size(150, 40), FlatStyle = FlatStyle.Flat, ForeColor = Color.MediumPurple };
            Button attach = new Button { Text = "ATTACH", Location = new Point(420, 110), Size = new Size(150, 40), FlatStyle = FlatStyle.Flat, ForeColor = Color.Cyan };
            mainPanel.Controls.AddRange(new Control[] { editor, exec, attach });
            this.Controls.Add(mainPanel);

            // Кнопка закрытия
            Button x = new Button { Text = "X", Location = new Point(560, 10), FlatStyle = FlatStyle.Flat, ForeColor = Color.Red };
            x.Click += (s, e) => Application.Exit();
            this.Controls.Add(x);
        }
        [STAThread] static void Main() { Application.Run(new ExecFree()); }
    }
}
