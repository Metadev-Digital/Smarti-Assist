namespace Smarti_Assist
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileImport = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuFileClear = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditTech = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEditPart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuEditRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewAss = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewSmart = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuHelpReport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.nudCopies = new System.Windows.Forms.NumericUpDown();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTech = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkTech = new System.Windows.Forms.CheckBox();
            this.chkQR = new System.Windows.Forms.CheckBox();
            this.chkDate = new System.Windows.Forms.CheckBox();
            this.chkInjector = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.lstArk = new System.Windows.Forms.ListBox();
            this.lstInj = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnArk = new System.Windows.Forms.Button();
            this.btnInj = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(748, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFileSave,
            this.mnuFilePrint,
            this.toolStripMenuItem1,
            this.mnuFileImport,
            this.mnuFileExport,
            this.toolStripMenuItem2,
            this.mnuFileClear,
            this.mnuFileExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuFileSave
            // 
            this.mnuFileSave.Name = "mnuFileSave";
            this.mnuFileSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnuFileSave.Size = new System.Drawing.Size(185, 22);
            this.mnuFileSave.Text = "Save as PDF...";
            this.mnuFileSave.Click += new System.EventHandler(this.mnuFileSave_Click);
            // 
            // mnuFilePrint
            // 
            this.mnuFilePrint.Name = "mnuFilePrint";
            this.mnuFilePrint.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.mnuFilePrint.Size = new System.Drawing.Size(185, 22);
            this.mnuFilePrint.Text = "Print...";
            this.mnuFilePrint.Click += new System.EventHandler(this.mnuFilePrint_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 6);
            // 
            // mnuFileImport
            // 
            this.mnuFileImport.Name = "mnuFileImport";
            this.mnuFileImport.Size = new System.Drawing.Size(185, 22);
            this.mnuFileImport.Text = "Import Config File";
            this.mnuFileImport.Click += new System.EventHandler(this.mnuFileImport_Click);
            // 
            // mnuFileExport
            // 
            this.mnuFileExport.Name = "mnuFileExport";
            this.mnuFileExport.Size = new System.Drawing.Size(185, 22);
            this.mnuFileExport.Text = "Export Config File...";
            this.mnuFileExport.Click += new System.EventHandler(this.mnuFileExport_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 6);
            // 
            // mnuFileClear
            // 
            this.mnuFileClear.Name = "mnuFileClear";
            this.mnuFileClear.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.R)));
            this.mnuFileClear.Size = new System.Drawing.Size(185, 22);
            this.mnuFileClear.Text = "Clear";
            this.mnuFileClear.Click += new System.EventHandler(this.mnuFileClear_Click);
            // 
            // mnuFileExit
            // 
            this.mnuFileExit.Name = "mnuFileExit";
            this.mnuFileExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuFileExit.Size = new System.Drawing.Size(185, 22);
            this.mnuFileExit.Text = "Exit";
            this.mnuFileExit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEditTech,
            this.mnuEditPart,
            this.toolStripMenuItem3,
            this.mnuEditRemove});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 22);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // mnuEditTech
            // 
            this.mnuEditTech.Name = "mnuEditTech";
            this.mnuEditTech.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.T)));
            this.mnuEditTech.Size = new System.Drawing.Size(226, 22);
            this.mnuEditTech.Text = "Set Technicians";
            this.mnuEditTech.Click += new System.EventHandler(this.mnuEditTech_Click);
            // 
            // mnuEditPart
            // 
            this.mnuEditPart.Name = "mnuEditPart";
            this.mnuEditPart.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.N)));
            this.mnuEditPart.Size = new System.Drawing.Size(226, 22);
            this.mnuEditPart.Text = "Part Numbers";
            this.mnuEditPart.Click += new System.EventHandler(this.mnuEditPart_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(223, 6);
            // 
            // mnuEditRemove
            // 
            this.mnuEditRemove.Name = "mnuEditRemove";
            this.mnuEditRemove.Size = new System.Drawing.Size(226, 22);
            this.mnuEditRemove.Text = "Remove Config File";
            this.mnuEditRemove.Click += new System.EventHandler(this.mnuEditRemove_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuViewAss,
            this.mnuViewSmart});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // mnuViewAss
            // 
            this.mnuViewAss.Name = "mnuViewAss";
            this.mnuViewAss.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuViewAss.Size = new System.Drawing.Size(248, 22);
            this.mnuViewAss.Text = "Assembly Document";
            this.mnuViewAss.Click += new System.EventHandler(this.mnuViewAss_Click);
            // 
            // mnuViewSmart
            // 
            this.mnuViewSmart.Name = "mnuViewSmart";
            this.mnuViewSmart.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.mnuViewSmart.Size = new System.Drawing.Size(248, 22);
            this.mnuViewSmart.Text = "Smart-i Assist Document";
            this.mnuViewSmart.Click += new System.EventHandler(this.mnuViewSmart_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHelpReport,
            this.toolStripMenuItem4,
            this.mnuHelpAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // mnuHelpReport
            // 
            this.mnuHelpReport.Name = "mnuHelpReport";
            this.mnuHelpReport.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.mnuHelpReport.Size = new System.Drawing.Size(182, 22);
            this.mnuHelpReport.Text = "Report Issue";
            this.mnuHelpReport.Click += new System.EventHandler(this.mnuHelpReport_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(179, 6);
            // 
            // mnuHelpAbout
            // 
            this.mnuHelpAbout.Name = "mnuHelpAbout";
            this.mnuHelpAbout.Size = new System.Drawing.Size(182, 22);
            this.mnuHelpAbout.Text = "About Smart-i Assist";
            this.mnuHelpAbout.Click += new System.EventHandler(this.aboutSmartiAssistToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(-6, 328);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(754, 2);
            this.label1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(246, 335);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(265, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Copyright © 2020 All Rights Reserved - Acrelec America";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(677, 335);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(60, 13);
            this.lblVersion.TabIndex = 3;
            this.lblVersion.Text = "Version 1.0";
            // 
            // grpOptions
            // 
            this.grpOptions.Controls.Add(this.label3);
            this.grpOptions.Controls.Add(this.nudCopies);
            this.grpOptions.Controls.Add(this.txtPO);
            this.grpOptions.Controls.Add(this.label7);
            this.grpOptions.Controls.Add(this.txtTech);
            this.grpOptions.Controls.Add(this.label6);
            this.grpOptions.Controls.Add(this.label5);
            this.grpOptions.Controls.Add(this.chkTech);
            this.grpOptions.Controls.Add(this.chkQR);
            this.grpOptions.Controls.Add(this.chkDate);
            this.grpOptions.Controls.Add(this.chkInjector);
            this.grpOptions.Location = new System.Drawing.Point(560, 40);
            this.grpOptions.Margin = new System.Windows.Forms.Padding(2);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Padding = new System.Windows.Forms.Padding(2);
            this.grpOptions.Size = new System.Drawing.Size(162, 224);
            this.grpOptions.TabIndex = 4;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Include Options";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "# of copies";
            // 
            // nudCopies
            // 
            this.nudCopies.Location = new System.Drawing.Point(8, 98);
            this.nudCopies.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopies.Name = "nudCopies";
            this.nudCopies.Size = new System.Drawing.Size(29, 20);
            this.nudCopies.TabIndex = 9;
            this.nudCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopies.ValueChanged += new System.EventHandler(this.nudCopies_ValueChanged);
            // 
            // txtPO
            // 
            this.txtPO.Enabled = false;
            this.txtPO.Location = new System.Drawing.Point(9, 191);
            this.txtPO.Margin = new System.Windows.Forms.Padding(2);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(149, 20);
            this.txtPO.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 175);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Injector P/O:";
            // 
            // txtTech
            // 
            this.txtTech.Enabled = false;
            this.txtTech.Location = new System.Drawing.Point(9, 150);
            this.txtTech.Margin = new System.Windows.Forms.Padding(2);
            this.txtTech.Name = "txtTech";
            this.txtTech.Size = new System.Drawing.Size(149, 20);
            this.txtTech.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 135);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Technician(s):";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(-1, 126);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(162, 1);
            this.label5.TabIndex = 5;
            // 
            // chkTech
            // 
            this.chkTech.AutoSize = true;
            this.chkTech.Checked = true;
            this.chkTech.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTech.Location = new System.Drawing.Point(9, 18);
            this.chkTech.Margin = new System.Windows.Forms.Padding(2);
            this.chkTech.Name = "chkTech";
            this.chkTech.Size = new System.Drawing.Size(90, 17);
            this.chkTech.TabIndex = 3;
            this.chkTech.Text = "Technician(s)";
            this.chkTech.UseVisualStyleBackColor = true;
            this.chkTech.Click += new System.EventHandler(this.chkTech_Click);
            // 
            // chkQR
            // 
            this.chkQR.AutoSize = true;
            this.chkQR.Checked = true;
            this.chkQR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkQR.Location = new System.Drawing.Point(9, 57);
            this.chkQR.Margin = new System.Windows.Forms.Padding(2);
            this.chkQR.Name = "chkQR";
            this.chkQR.Size = new System.Drawing.Size(76, 17);
            this.chkQR.TabIndex = 2;
            this.chkQR.Text = "Q.R. Code";
            this.chkQR.UseVisualStyleBackColor = true;
            this.chkQR.Click += new System.EventHandler(this.chkQR_Click);
            // 
            // chkDate
            // 
            this.chkDate.AutoSize = true;
            this.chkDate.Checked = true;
            this.chkDate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDate.Location = new System.Drawing.Point(9, 77);
            this.chkDate.Margin = new System.Windows.Forms.Padding(2);
            this.chkDate.Name = "chkDate";
            this.chkDate.Size = new System.Drawing.Size(49, 17);
            this.chkDate.TabIndex = 1;
            this.chkDate.Text = "Date";
            this.chkDate.UseVisualStyleBackColor = true;
            this.chkDate.Click += new System.EventHandler(this.chkDate_Click);
            // 
            // chkInjector
            // 
            this.chkInjector.AutoSize = true;
            this.chkInjector.Checked = true;
            this.chkInjector.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInjector.Location = new System.Drawing.Point(9, 38);
            this.chkInjector.Margin = new System.Windows.Forms.Padding(2);
            this.chkInjector.Name = "chkInjector";
            this.chkInjector.Size = new System.Drawing.Size(84, 17);
            this.chkInjector.TabIndex = 0;
            this.chkInjector.Text = "Injector P/O";
            this.chkInjector.UseVisualStyleBackColor = true;
            this.chkInjector.Click += new System.EventHandler(this.chkInjector_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(567, 274);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(143, 30);
            this.btnPrint.TabIndex = 5;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // lstArk
            // 
            this.lstArk.FormattingEnabled = true;
            this.lstArk.Location = new System.Drawing.Point(11, 79);
            this.lstArk.Margin = new System.Windows.Forms.Padding(2);
            this.lstArk.Name = "lstArk";
            this.lstArk.Size = new System.Drawing.Size(257, 225);
            this.lstArk.TabIndex = 6;
            // 
            // lstInj
            // 
            this.lstInj.FormattingEnabled = true;
            this.lstInj.Location = new System.Drawing.Point(285, 79);
            this.lstInj.Margin = new System.Windows.Forms.Padding(2);
            this.lstInj.Name = "lstInj";
            this.lstInj.Size = new System.Drawing.Size(257, 225);
            this.lstInj.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(64, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 18);
            this.label8.TabIndex = 8;
            this.label8.Text = "ARK Serials";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(342, 51);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 18);
            this.label9.TabIndex = 9;
            this.label9.Text = "Injector Serials";
            // 
            // btnArk
            // 
            this.btnArk.Location = new System.Drawing.Point(218, 50);
            this.btnArk.Margin = new System.Windows.Forms.Padding(2);
            this.btnArk.Name = "btnArk";
            this.btnArk.Size = new System.Drawing.Size(50, 23);
            this.btnArk.TabIndex = 10;
            this.btnArk.Text = "Import";
            this.btnArk.UseVisualStyleBackColor = true;
            this.btnArk.Click += new System.EventHandler(this.btnArk_Click);
            // 
            // btnInj
            // 
            this.btnInj.Location = new System.Drawing.Point(492, 50);
            this.btnInj.Margin = new System.Windows.Forms.Padding(2);
            this.btnInj.Name = "btnInj";
            this.btnInj.Size = new System.Drawing.Size(50, 23);
            this.btnInj.TabIndex = 11;
            this.btnInj.Text = "Import";
            this.btnInj.UseVisualStyleBackColor = true;
            this.btnInj.Click += new System.EventHandler(this.btnInj_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(748, 356);
            this.Controls.Add(this.btnInj);
            this.Controls.Add(this.btnArk);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstInj);
            this.Controls.Add(this.lstArk);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.grpOptions);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "Smart-i Assist";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuFileSave;
        private System.Windows.Forms.ToolStripMenuItem mnuFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuFileImport;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuFileExit;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuEditTech;
        private System.Windows.Forms.ToolStripMenuItem mnuEditPart;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem mnuEditRemove;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuViewAss;
        private System.Windows.Forms.ToolStripMenuItem mnuViewSmart;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpReport;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuHelpAbout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.CheckBox chkTech;
        private System.Windows.Forms.CheckBox chkQR;
        private System.Windows.Forms.CheckBox chkDate;
        private System.Windows.Forms.CheckBox chkInjector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTech;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ListBox lstArk;
        private System.Windows.Forms.ListBox lstInj;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnArk;
        private System.Windows.Forms.Button btnInj;
        private System.Windows.Forms.ToolStripMenuItem mnuFileClear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudCopies;
    }
}

