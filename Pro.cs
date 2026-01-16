using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ExecLauncher
{
    public class ExecPro : Form
    {
        [DllImport("user32.dll")] public static extern bool ReleaseCapture();
        [DllImport("user32.dll")] public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        public ExecPro()
        {
            this.Size = new Size(650, 450);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(10, 5, 20); // Глубокий темный
            this.StartPosition = FormStartPosition.CenterScreen;

            // Заголовок в стиле Dela Gothic
            Label logo = new Label { 
                Text = "EXEC PRO PC", 
                ForeColor = Color.MediumPurple, 
                Font = new Font("Arial Black", 22, FontStyle.Bold), 
                Location = new Point(20, 20), AutoSize = true 
            };
            this.Controls.Add(logo);

            // Поле редактора
            RichTextBox editor = new RichTextBox {
                Location = new Point(20, 80),
                Size = new Size(450, 300),
                BackColor = Color.FromArgb(20, 15, 30),
                ForeColor = Color.SpringGreen,
                BorderStyle = BorderStyle.None,
                Font = new Font("Consolas", 11),
                Text = "-- EXEC PRO VERSION LOADED\nprint('Welcome, User!')"
            };
            this.Controls.Add(editor);

            // Кнопки управления
            Button execBtn = CreateBtn("EXECUTE", 490, 80, Color.FromArgb(80, 40, 150));
            Button attachBtn = CreateBtn("ATTACH", 490, 135, Color.FromArgb(40, 100, 40));
            Button clearBtn = CreateBtn("CLEAR", 490, 190, Color.FromArgb(50, 50, 50));

            this.Controls.AddRange(new Control[] { execBtn, attachBtn, clearBtn });

            // Закрытие
            Button close = new Button { Text = "✕", Location = new Point(610, 10), FlatStyle = FlatStyle.Flat, ForeColor = Color.Gray, Size = new Size(30, 30) };
            close.Click += (s, e) => Application.Exit();
            this.Controls.Add(close);

            // Перетаскивание
            this.MouseDown += (s, e) => { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } };
        }

        Button CreateBtn(string text, int x, int y, Color bg) {
            return new Button {
                Text = text, Location = new Point(x, y), Size = new Size(140, 45),
                FlatStyle = FlatStyle.Flat, BackColor = bg, ForeColor = Color.White,
                Font = new Font("Arial Black", 10)
            };
        }

        [STAThread] static void Main() { Application.Run(new ExecPro()); }
    }
}
