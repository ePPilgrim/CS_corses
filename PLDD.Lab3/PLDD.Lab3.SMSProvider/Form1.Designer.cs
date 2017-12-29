using System;

namespace PLDD.Lab3.SMSProvider
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        public delegate void SubscribeMobPhone(MobilePhone mobPhone);
        public delegate void UnsubscribeMobPhone();

        private event SubscribeMobPhone vSubscribeMobPhone = null;
        private event UnsubscribeMobPhone vUnsubscribeMobPhone = null;
        private event EventHandler vKickOffSmsGenerator = null;

        private MobilePhone vMobPhone = null;
        private SMSGenerator vSmsGenerator;
        

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.comboBox1.Location = new System.Drawing.Point(19, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(377, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select Formatting";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(19, 88);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(377, 287);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Subscribe";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 29);
            this.button2.TabIndex = 3;
            this.button2.Text = "Unsubscribe";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(280, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(116, 29);
            this.button3.TabIndex = 4;
            this.button3.Text = "Cleare";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 387);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.comboBox1);
            this.Name = "Form1";
            this.Text = "Message Formating";
            this.ResumeLayout(false);

        }

        private void initDelegates() {
            vMobPhone = new MobilePhone();
            vMobPhone.SmsProvider.SMSReceived += new SMSProvider.SMSRecievedDelegate(OnSmsReceived);
            vMobPhone.SmsProvider.SetFormatMode(SMSProvider.FormatedMode.NoneFormat);
            vSmsGenerator = new SMSGenerator(1000);
            
            vSubscribeMobPhone = new SubscribeMobPhone(vSmsGenerator.Subscribe);
            vUnsubscribeMobPhone = new UnsubscribeMobPhone(vSmsGenerator.UnSubscribe);
            vKickOffSmsGenerator = new EventHandler(OnInitSmsGenerator);
            vKickOffSmsGenerator.Invoke(this, null);
        }

        private void OnSmsReceived(string message) {
            if( InvokeRequired ) {
                Invoke(new SMSProvider.SMSRecievedDelegate(OnSmsReceived), message);
                return;  
            }

            if ( vMobPhone != null ) {
                var formatedMessage = vMobPhone.SmsProvider.RaiseFormatMessageEvent(message);
                richTextBox1.AppendText($"{formatedMessage}{Environment.NewLine}");
            }
        }

        private void OnInitSmsGenerator(object sender, EventArgs arg) {
            vSmsGenerator.Start();
        }

        #endregion
    }
}

