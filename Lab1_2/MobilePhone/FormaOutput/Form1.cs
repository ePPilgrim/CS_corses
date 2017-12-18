using PlugIns;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormaOutput
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeMobilePhone();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            curPlayback = this.playbacks[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn != null)
            {
                if (curPlayback != null)
                {
                    this.myMobilePhone.PlaybackComponent = curPlayback as IPlayback;
                    this.myMobilePhone.Play(null);
                    this.output.WriteLine("");
                    curPlayback = null;
                }

                if (this.curChargeUnit != null)
                {
                    this.myMobilePhone.ChargeUnit = curChargeUnit as ICharge;
                    this.myMobilePhone.ChargeBattery(null);
                    this.output.WriteLine("");
                    curChargeUnit = null;
                }
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            curPlayback = this.playbacks[1];
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            curPlayback = this.playbacks[2];
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            curPlayback = this.playbacks[3];
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            this.curChargeUnit = this.chargeUnits[0];
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            this.curChargeUnit = this.chargeUnits[1];
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            this.curChargeUnit = this.chargeUnits[2];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.richTextBox1.Clear();
        }
    }
}
