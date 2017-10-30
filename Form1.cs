using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WSphp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jemix.JemixWS ws = new Jemix.JemixWS();

            label1.Text = ws.add((int)numericUpDown1.Value, (int)numericUpDown2.Value).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Jemix.JemixWS ws = new Jemix.JemixWS();

            label1.Text = ws.div((int)numericUpDown1.Value, (int)numericUpDown2.Value).ToString();
        }
    }
}
