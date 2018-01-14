using PLDD.Lab5.MobilePhone;
using System;
using System.Threading;
using System.Windows.Forms;

namespace PLDD.Lab5.MobilePhoneOutput
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            vSmsGeneratingThread.Abort();
            vUnchargeMobPhoneThread.Abort();
            vChargeMobPhoneThread.Abort();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private SimCorpMobilePhone vMobPhone = null;

        private Thread vSmsGeneratingThread = null;

        private Thread vChargeMobPhoneThread = null;

        private Thread vUnchargeMobPhoneThread = null;

        private System.Windows.Forms.ComboBox comboBox1;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.MessageListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.FromDate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "None",
            "Start with [Date Time]",
            "End with [Date Time]",
            "Lowercase",
            "Uppercase"});
            this.comboBox1.Location = new System.Drawing.Point(316, 73);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(177, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select Formatting";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MessageListView.Location = new System.Drawing.Point(12, 150);
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MessageListView.Size = new System.Drawing.Size(489, 611);
            this.MessageListView.TabIndex = 5;
            this.MessageListView.TileSize = new System.Drawing.Size(512, 30);
            this.MessageListView.UseCompatibleStateImageBehavior = false;
            this.MessageListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "User Name";
            this.columnHeader1.Width = 128;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message Text";
            this.columnHeader2.Width = 355;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(316, 37);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(177, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(316, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(177, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(59, 12);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(59, 38);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker2.TabIndex = 9;
            this.dateTimePicker2.Value = new System.DateTime(2018, 1, 13, 16, 2, 13, 66);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // FromDate
            // 
            this.FromDate.AutoSize = true;
            this.FromDate.Location = new System.Drawing.Point(2, 12);
            this.FromDate.Name = "FromDate";
            this.FromDate.Size = new System.Drawing.Size(53, 13);
            this.FromDate.TabIndex = 10;
            this.FromDate.Text = "FromDate";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "ToDate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Filte By Text";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(192, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filter By Phone Number";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 71);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 23);
            this.button1.TabIndex = 14;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 71);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(91, 23);
            this.button2.TabIndex = 15;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Message Generator";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(125, 107);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 22);
            this.button3.TabIndex = 17;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(223, 107);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(86, 22);
            this.button4.TabIndex = 18;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Charge Battery";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(322, 109);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(170, 19);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Click += new System.EventHandler(this.progressBar1_Click);
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = 100;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 741);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FromDate);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.MessageListView);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Message Filtering";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void initDelegates() {
            vMobPhone = new SimCorpMobilePhone();
            vMobPhone.SetFormatMode(0);
            vMobPhone.SetMessageIsAddedDelegat(OnListViewMessageAdded);
            vMobPhone.SetMessageIsRemoveDelegat(OnListViewMessageRemoved);
            vMobPhone.SetBatteryChargeChangeDelegat(OnChargeIsChanged);
            
            vSmsGeneratingThread = new Thread(vMobPhone.SetGeneratingThread());
            vSmsGeneratingThread.Start();

            vChargeMobPhoneThread = new Thread(vMobPhone.SetChargThread());
            vChargeMobPhoneThread.Start();

            vUnchargeMobPhoneThread = new Thread(vMobPhone.SetUnchargeThread());
            vUnchargeMobPhoneThread.Start();
        }

        private void OnChargeIsChanged(int charge)
        {
            if ( InvokeRequired ) {
                Invoke(new ChargeStateChangeDelegate(OnChargeIsChanged), charge);
                return;
            }

            if (vMobPhone != null) { progressBar1.Value = charge; }
        }

        private void initPhoneNumberComboBox()
        {
            var smsPhoneNumGrouping = vMobPhone.GroupingByPhoneNumber();

             foreach (var phoneNumber in smsPhoneNumGrouping)
             {
                    comboBox2.Items.Add(phoneNumber);
             }
        }

        private void OnListViewMessageAdded(PLDD.Lab5.MobilePhone.Message addedMessage) {
            if ( InvokeRequired ) {
                Invoke(new MessageIsAddDelegate(OnListViewMessageAdded), addedMessage);
                return;
            }

            if ( vMobPhone != null ) {
                //Do smth. to handle added message event
                ShowMessages();
            }
        }

        private void OnListViewMessageRemoved(PLDD.Lab5.MobilePhone.Message removedMessage)
        {
            if ( InvokeRequired ) {
                Invoke(new MessageIsRemoveDelegate(OnListViewMessageRemoved), removedMessage);
                return;
            }

            if ( vMobPhone != null ) {
                //Do smth. to handle remove message event
                ShowMessages();
            }
        }

        private void ShowMessages()
        {
            if ( comboBox2.SelectedItem != null ) {
                var messageList = vMobPhone.FileterAnd((int)comboBox2.SelectedItem, textBox1.Text, dateTimePicker1.Value, dateTimePicker2.Value);
                MessageListView.Items.Clear();
                foreach (var message in messageList)
                {
                    MessageListView.Items.Add(new ListViewItem(new[] { message.UserName, message.Text }));
                }
            }
        }

        #endregion

        private System.Windows.Forms.ListView MessageListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ComboBox comboBox2;
        private TextBox textBox1;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label FromDate;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
        private Label label4;
        private Button button3;
        private Button button4;
        private Label label5;
        private ProgressBar progressBar1;
    }
}

