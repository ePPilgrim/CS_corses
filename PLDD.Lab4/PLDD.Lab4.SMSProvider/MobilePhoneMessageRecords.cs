using System;
using System.Windows.Forms;

namespace PLDD.Lab4.MobilePhoneOutput
{
    public partial class MobilePhoneMessageRecords : Form
    {
        public MobilePhoneMessageRecords()
        {
            InitializeComponent();
            initDelegates();
            initPhoneNumberComboBox();
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
            if( combobox != null ) { vMobPhone?.SetFormatMode(combobox.SelectedIndex); }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combobox = sender as ComboBox;
            if ( combobox != null ) { ShowMessages(); }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txtbox = sender as TextBox;
            if( txtbox != null ) { ShowMessages(); }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtpick = sender as DateTimePicker;
            if( dtpick != null ) { ShowMessages(); }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateTimePicker dtpick = sender as DateTimePicker;
            if ( dtpick != null ) { ShowMessages(); }
        }

    }
}
