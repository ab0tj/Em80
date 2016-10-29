using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Em80
{
    public partial class frmConsole : Form
    {
        public static class Keyboard
        {
            private static byte[] buff = new byte[32];  // implement a 32-byte circular buffer
            private static int head;
            private static int tail;
            public static bool byte_aval
            {
                get { return head != tail; }
            }
            public static void KeyPress(byte val)   // add key to the buffer
            {
                int next = (head + 1) % 32;
                if (next != tail)
                {
                    buff[head] = val;
                    head = next;
                }
            }

            public static byte GetKey()     // get key from the buffer
            {
                if (!byte_aval) return 0;

                byte val = buff[tail];
                tail = (tail + 1) % 32;
                return val;
            }
        }

        public frmConsole()
        {
            InitializeComponent();

            EmulatedSystem.io.Output += new EmulatedSystem.io.IOEventHandler(OutEventHandler);
            EmulatedSystem.io.Input += new EmulatedSystem.io.IOEventHandler(InEventHandler);
        }

        public void OutEventHandler(byte port)
        {
            if (port == 2 || port == 17)
            {
                if (EmulatedSystem.cpu.registers.a == 0x08)
                {
                    // this was a backspace
                    if (textBox1.Text.Length > 0) textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
                }
                else
                {
                    // this was something else
                    textBox1.AppendText(char.ToString((char)EmulatedSystem.cpu.registers.a));
                }
            }
        }

        public void InEventHandler(byte port)
        {
            switch (port)
            {
                case 2:  // console data (imsai sio)
                case 17: // console data (altair sio)
                    EmulatedSystem.cpu.registers.a = Keyboard.GetKey();
                    break;
                case 3: // console status (imsai sio)
                    EmulatedSystem.cpu.registers.a = 0x01; // tx always ready
                    if (Keyboard.byte_aval) EmulatedSystem.cpu.registers.a |= 0x02;    // rx ready if a char is waiting
                    break;
                case 16: // console status (altair sio)
                    EmulatedSystem.cpu.registers.a = 0x02; // tx always ready
                    if (Keyboard.byte_aval) EmulatedSystem.cpu.registers.a |= 0x01;    // rx ready if a char is waiting
                    break;
            }
        }

        public void ClearConsole()
        {
            textBox1.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Keyboard.KeyPress((byte)e.KeyChar);
        }

        private void frmConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
