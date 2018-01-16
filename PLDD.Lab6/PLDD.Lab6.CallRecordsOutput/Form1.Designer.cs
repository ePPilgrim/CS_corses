using PLDD.Lab6.CallRecords;
using System;
using System.Windows.Forms;

namespace PLDD.Lab6.CallRecordsOutput
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
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private event EventHandler vKickOffCallGenerator = null;

        private CallGenerator vCallGenerator = null;

        private CallList vRecordList = null;

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MessageListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // MessageListView
            // 
            this.MessageListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.MessageListView.Location = new System.Drawing.Point(12, 12);
            this.MessageListView.Name = "MessageListView";
            this.MessageListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.MessageListView.Size = new System.Drawing.Size(716, 749);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 741);
            this.Controls.Add(this.MessageListView);
            this.Name = "Form1";
            this.Text = "Message Filtering";
            this.ResumeLayout(false);

        }

        private void initDelegates() {
            vRecordList = new CallList();
            vRecordList.NewRecord += OnListViewNewCall;

            vCallGenerator = new CallGenerator(3000, new GenerateCallDelegate(vRecordList.AddRecord));

            vKickOffCallGenerator = new EventHandler(OnInitCallGenerator);
            vKickOffCallGenerator.Invoke(this, null);
        }

        private void OnListViewNewCall(){
            if ( InvokeRequired ) {
                Invoke(new NewRecordDelegate(OnListViewNewCall));
                return;
            }

            if( vRecordList != null) {
                var list = vRecordList.ListOfCalls;
                MessageListView.Items.Clear();
                for (int i = list.Count - 1; i >= 0; --i) {
                    MessageListView.Items.Add(new ListViewItem(new[] { list[i].GetNameOfCaller(), list[i].ToString() }));
                }
            }
        }

        private void OnInitCallGenerator(object sender, EventArgs arg) { vCallGenerator.Start(); }

        #endregion

        private System.Windows.Forms.ListView MessageListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
    }
}

