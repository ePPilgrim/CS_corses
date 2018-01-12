﻿using PLDD.Lab4.MobilePhone;
using System;
using System.Windows.Forms;

namespace PLDD.Lab4.MobilePhoneOutput
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

        private event EventHandler vKickOffSmsGenerator = null;

        private SimCorpMobilePhone vMobPhone = null;
        private SMSGenerator vSmsGenerator;

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
            this.comboBox1.Location = new System.Drawing.Point(12, 47);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(284, 21);
            this.comboBox1.TabIndex = 0;
            this.comboBox1.Text = "Select Formatting";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MessageListView.Location = new System.Drawing.Point(12, 84);
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MessageListView.Size = new System.Drawing.Size(480, 520);
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
            this.comboBox2.Location = new System.Drawing.Point(315, 47);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(177, 21);
            this.comboBox2.TabIndex = 6;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(316, 9);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(176, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 9);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.Value = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(165, 9);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(131, 20);
            this.dateTimePicker2.TabIndex = 9;
            this.dateTimePicker2.Value = new System.DateTime(2018, 1, 13, 16, 2, 13, 66);
            this.dateTimePicker2.ValueChanged += new System.EventHandler(this.dateTimePicker2_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 616);
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

            vSmsGenerator = new SMSGenerator(2000, vMobPhone);
            
            vKickOffSmsGenerator = new EventHandler(OnInitSmsGenerator);
            vKickOffSmsGenerator.Invoke(this, null);
        }

        private void initPhoneNumberComboBox()
        {
            var smsPhoneNumGrouping = vMobPhone.GroupingByPhoneNumber();

             foreach (var phoneNumber in smsPhoneNumGrouping)
             {
                    comboBox2.Items.Add(phoneNumber);
             }
        }

        private void OnListViewMessageAdded(PLDD.Lab4.MobilePhone.Message addedMessage) {
            if ( InvokeRequired ) {
                Invoke(new MessageIsAddDelegate(OnListViewMessageAdded), addedMessage);
                return;
            }

            if ( vMobPhone != null ) {
                //Do smth. to handle added message event
                ShowMessages();
            }
        }

        private void OnListViewMessageRemoved(PLDD.Lab4.MobilePhone.Message removedMessage)
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

        private void OnInitSmsGenerator(object sender, EventArgs arg) { vSmsGenerator.Start(); }

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
    }
}

