using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            int x;
            int y;
            int ScreenHeight;
            int ScreenWidth;

            this.Cursor = new Cursor(Cursor.Current.Handle);

            //save screen parameters
            ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
            ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

            x = Cursor.Position.X;
            y = Cursor.Position.Y;
            Cursor.Position = new Point(x + 10, y + 10);
            Thread.Sleep(1);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), x + 10, y + 10, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), x + 10, y + 10, 0, 0);
            Cursor.Position = new Point(x, y);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 30 * 1000;
            timer1.Start();
        }
    }
}
