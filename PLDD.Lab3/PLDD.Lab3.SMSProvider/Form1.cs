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

        /// <summary>
        /// used to chose the format mode of the received messages.
        /// by default the formated mode is none. That is no alteration to
        /// the generated sms message has not been provided.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) {
            ComboBox combobox = sender as ComboBox;
            if( combobox != null ) {
                vMobPhone?.SmsProvider.SetFormatMode(combobox.SelectedIndex);
            }
        }

        /// <summary>
        /// used to subscribe "mobile phone" to the sms service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {    
            vSubscribeMobPhone(vMobPhone);
        }

        /// <summary>
        /// unsubscribe "mobile phone" off the sms service.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e) {
            vUnsubscribeMobPhone();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e) {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }

        /// <summary>
        /// simply clear rich text box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e) {
            richTextBox1.Clear();
        }
    }
}
