﻿namespace Safety_Net
{
    partial class FrmMain
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnOpenDataLog = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAddPrivateInfo = new System.Windows.Forms.Button();
            this.dgvPiTracker = new System.Windows.Forms.DataGridView();
            this.TimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PI_Tracker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Website = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ckBoxes = new System.Windows.Forms.CheckedListBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiTracker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1310, 716);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnOpenDataLog);
            this.splitContainer2.Panel1.Controls.Add(this.btnDelete);
            this.splitContainer2.Panel1.Controls.Add(this.btnAddPrivateInfo);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvPiTracker);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel2_Paint);
            this.splitContainer2.Size = new System.Drawing.Size(1310, 438);
            this.splitContainer2.SplitterDistance = 64;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnOpenDataLog
            // 
            this.btnOpenDataLog.Location = new System.Drawing.Point(12, 12);
            this.btnOpenDataLog.Name = "btnOpenDataLog";
            this.btnOpenDataLog.Size = new System.Drawing.Size(120, 41);
            this.btnOpenDataLog.TabIndex = 0;
            this.btnOpenDataLog.Text = "Open Data Log";
            this.btnOpenDataLog.UseVisualStyleBackColor = true;
            this.btnOpenDataLog.Click += new System.EventHandler(this.btnOpenDataLog_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(246, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(107, 41);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete PI";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddPrivateInfo
            // 
            this.btnAddPrivateInfo.Location = new System.Drawing.Point(138, 12);
            this.btnAddPrivateInfo.Name = "btnAddPrivateInfo";
            this.btnAddPrivateInfo.Size = new System.Drawing.Size(102, 41);
            this.btnAddPrivateInfo.TabIndex = 1;
            this.btnAddPrivateInfo.Text = "Add PI";
            this.btnAddPrivateInfo.UseVisualStyleBackColor = true;
            this.btnAddPrivateInfo.Click += new System.EventHandler(this.btnAddPrivateInfo_Click);
            // 
            // dgvPiTracker
            // 
            this.dgvPiTracker.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPiTracker.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPiTracker.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TimeStamp,
            this.PI_Tracker,
            this.Website,
            this.Data});
            this.dgvPiTracker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPiTracker.Location = new System.Drawing.Point(0, 0);
            this.dgvPiTracker.Name = "dgvPiTracker";
            this.dgvPiTracker.RowTemplate.Height = 24;
            this.dgvPiTracker.Size = new System.Drawing.Size(1310, 370);
            this.dgvPiTracker.TabIndex = 5;
            this.dgvPiTracker.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // TimeStamp
            // 
            this.TimeStamp.HeaderText = "Time Stamp";
            this.TimeStamp.Name = "TimeStamp";
            // 
            // PI_Tracker
            // 
            this.PI_Tracker.HeaderText = "Personal Information";
            this.PI_Tracker.Name = "PI_Tracker";
            // 
            // Website
            // 
            this.Website.HeaderText = "Website";
            this.Website.Name = "Website";
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 4;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ckBoxes);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(1310, 716);
            this.splitContainer1.SplitterDistance = 438;
            this.splitContainer1.TabIndex = 1;
            // 
            // ckBoxes
            // 
            this.ckBoxes.AccessibleName = "ckboxes";
            this.ckBoxes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ckBoxes.FormattingEnabled = true;
            this.ckBoxes.Location = new System.Drawing.Point(0, 0);
            this.ckBoxes.Name = "ckBoxes";
            this.ckBoxes.Size = new System.Drawing.Size(1310, 274);
            this.ckBoxes.TabIndex = 0;
            this.ckBoxes.SelectedIndexChanged += new System.EventHandler(this.ckBoxes_SelectedIndexChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1310, 716);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPiTracker)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAddPrivateInfo;
        private System.Windows.Forms.Button btnOpenDataLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public System.Windows.Forms.CheckedListBox ckBoxes;
        public System.Windows.Forms.DataGridView dgvPiTracker;
        public System.Windows.Forms.DataGridViewTextBoxColumn TimeStamp;
        public System.Windows.Forms.DataGridViewTextBoxColumn PI_Tracker;
        public System.Windows.Forms.DataGridViewTextBoxColumn Website;
        public System.Windows.Forms.DataGridViewTextBoxColumn Data;
    }
}