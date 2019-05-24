namespace SSE_Fallout_4_Animation_Converter
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btstart = new System.Windows.Forms.Button();
            this.btClear = new System.Windows.Forms.Button();
            this.btadddir = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.credit = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.FIX_PATH = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SK = new System.Windows.Forms.RadioButton();
            this.F4 = new System.Windows.Forms.RadioButton();
            this.btadd = new System.Windows.Forms.Button();
            this.lboxFiles = new System.Windows.Forms.ListBox();
            this.SK_Upgrade = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btstart
            // 
            this.btstart.AutoSize = true;
            this.btstart.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btstart.Location = new System.Drawing.Point(653, 119);
            this.btstart.Name = "btstart";
            this.btstart.Size = new System.Drawing.Size(144, 23);
            this.btstart.TabIndex = 73;
            this.btstart.Text = "Start";
            this.btstart.UseVisualStyleBackColor = true;
            this.btstart.Click += new System.EventHandler(this.btstart_Click);
            // 
            // btClear
            // 
            this.btClear.AutoSize = true;
            this.btClear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btClear.Location = new System.Drawing.Point(653, 61);
            this.btClear.Name = "btClear";
            this.btClear.Size = new System.Drawing.Size(144, 23);
            this.btClear.TabIndex = 72;
            this.btClear.Text = "Purge list";
            this.btClear.UseVisualStyleBackColor = true;
            this.btClear.Click += new System.EventHandler(this.btClear_Click);
            // 
            // btadddir
            // 
            this.btadddir.AutoSize = true;
            this.btadddir.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btadddir.Location = new System.Drawing.Point(653, 32);
            this.btadddir.Name = "btadddir";
            this.btadddir.Size = new System.Drawing.Size(144, 23);
            this.btadddir.TabIndex = 71;
            this.btadddir.Text = "Add Directory(s)";
            this.btadddir.UseVisualStyleBackColor = true;
            this.btadddir.Click += new System.EventHandler(this.btadddir_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // credit
            // 
            this.credit.AutoSize = true;
            this.credit.Location = new System.Drawing.Point(653, 90);
            this.credit.Name = "credit";
            this.credit.Size = new System.Drawing.Size(144, 23);
            this.credit.TabIndex = 75;
            this.credit.Text = "Credits";
            this.credit.UseVisualStyleBackColor = true;
            this.credit.Click += new System.EventHandler(this.credit_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(653, 167);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(144, 23);
            this.progressBar1.TabIndex = 74;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(653, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 76;
            this.label1.Text = "label1";
            // 
            // FIX_PATH
            // 
            this.FIX_PATH.AutoSize = true;
            this.FIX_PATH.Location = new System.Drawing.Point(651, 196);
            this.FIX_PATH.Name = "FIX_PATH";
            this.FIX_PATH.Size = new System.Drawing.Size(146, 17);
            this.FIX_PATH.TabIndex = 78;
            this.FIX_PATH.Text = "Make Currect Directory(s)";
            this.FIX_PATH.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(650, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 39);
            this.label3.TabIndex = 80;
            this.label3.Text = "ONLY USE when converting \r\nxml to hkx\r\nNOTE: Skyrim only";
            // 
            // SK
            // 
            this.SK.AutoSize = true;
            this.SK.Location = new System.Drawing.Point(4, 3);
            this.SK.Name = "SK";
            this.SK.Size = new System.Drawing.Size(129, 17);
            this.SK.TabIndex = 81;
            this.SK.TabStop = true;
            this.SK.Text = "Skyrim Special Edition";
            this.SK.UseVisualStyleBackColor = true;
            this.SK.CheckedChanged += new System.EventHandler(this.SK_CheckedChanged);
            // 
            // F4
            // 
            this.F4.AutoSize = true;
            this.F4.Location = new System.Drawing.Point(3, 3);
            this.F4.Name = "F4";
            this.F4.Size = new System.Drawing.Size(65, 17);
            this.F4.TabIndex = 82;
            this.F4.TabStop = true;
            this.F4.Text = "Fallout 4";
            this.F4.UseVisualStyleBackColor = true;
            this.F4.CheckedChanged += new System.EventHandler(this.F4_CheckedChanged);
            // 
            // btadd
            // 
            this.btadd.AutoSize = true;
            this.btadd.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btadd.Location = new System.Drawing.Point(653, 3);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(144, 23);
            this.btadd.TabIndex = 70;
            this.btadd.Text = "Add File(s)";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.btadd_Click);
            // 
            // lboxFiles
            // 
            this.lboxFiles.AllowDrop = true;
            this.lboxFiles.FormattingEnabled = true;
            this.lboxFiles.Location = new System.Drawing.Point(3, 3);
            this.lboxFiles.Name = "lboxFiles";
            this.lboxFiles.Size = new System.Drawing.Size(646, 485);
            this.lboxFiles.TabIndex = 77;
            this.lboxFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lboxFiles_DragDrop);
            this.lboxFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lboxFiles_DragEnter);
            // 
            // SK_Upgrade
            // 
            this.SK_Upgrade.AutoSize = true;
            this.SK_Upgrade.Location = new System.Drawing.Point(3, 3);
            this.SK_Upgrade.Name = "SK_Upgrade";
            this.SK_Upgrade.Size = new System.Drawing.Size(162, 17);
            this.SK_Upgrade.TabIndex = 83;
            this.SK_Upgrade.TabStop = true;
            this.SK_Upgrade.Text = "Upgrading Skyrim Animations\r\n";
            this.SK_Upgrade.UseVisualStyleBackColor = true;
            this.SK_Upgrade.CheckedChanged += new System.EventHandler(this.SK_Upgrade_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(160, 39);
            this.label2.TabIndex = 84;
            this.label2.Text = "Skyirm 32-Bit => 64-Bit(SSE)\r\nRequire:\r\nHavokBehaviorPostProcess.exe\r\n";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 52);
            this.label4.TabIndex = 85;
            this.label4.Text = "64-Bit  => 32-Bit => 64-Bit\r\nPC => PC => PS4\r\nRequires:\r\nHavok content tools 2010" +
    "(64-Bit)\r\n";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(163, 39);
            this.label5.TabIndex = 86;
            this.label5.Text = "64-Bit PC => 64-Bit PS4\r\nRequires\r\nHavok content tools 2014(64-Bit)\r\n";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.SK_Upgrade);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(650, 402);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 66);
            this.panel1.TabIndex = 87;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.SK);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(650, 324);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(176, 77);
            this.panel2.TabIndex = 88;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.F4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(651, 259);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(175, 67);
            this.panel3.TabIndex = 89;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 488);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.FIX_PATH);
            this.Controls.Add(this.btstart);
            this.Controls.Add(this.btClear);
            this.Controls.Add(this.btadddir);
            this.Controls.Add(this.btadd);
            this.Controls.Add(this.lboxFiles);
            this.Controls.Add(this.credit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "SSE/Fallout 4 Animation Converter";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.Load += new System.EventHandler(this.Main_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btstart;
        private System.Windows.Forms.Button btClear;
        private System.Windows.Forms.Button btadddir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button credit;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox FIX_PATH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton SK;
        private System.Windows.Forms.RadioButton F4;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.ListBox lboxFiles;
        private System.Windows.Forms.RadioButton SK_Upgrade;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}

