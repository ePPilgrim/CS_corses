using System;
using System.Windows.Forms;

namespace PLDD.Lab3.SMSProvider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            initDelegates();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox combobox = sender as ComboBox;
            if( combobox != null ) {
                vFormatMessage = new FormatMessage(vFormatFunc[combobox.SelectedIndex]);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            vFormatMessage =  vFormatMessage ?? new FormatMessage(vFormatFunc[0]);
            vSubscribeMobPhone(vMobPhone);
        }

        private void button2_Click(object sender, EventArgs e) {
            vUnsubscribeMobPhone();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        private void button3_Click(object sender, EventArgs e) {
            richTextBox1.Clear();
        }
    }
}
