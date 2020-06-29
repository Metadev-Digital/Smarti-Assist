namespace Smarti_Assist
{
    partial class frmConfiguration
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConfiguration));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTechnician = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPO = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Smarti_Assist.Properties.Resources.ACRELEC_LOGO;
            this.pictureBox1.Location = new System.Drawing.Point(45, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(841, 171);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(593, 140);
            this.label1.TabIndex = 16;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtTechnician
            // 
            this.txtTechnician.Location = new System.Drawing.Point(671, 238);
            this.txtTechnician.Name = "txtTechnician";
            this.txtTechnician.Size = new System.Drawing.Size(230, 26);
            this.txtTechnician.TabIndex = 17;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 201);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(273, 26);
            this.label2.TabIndex = 18;
            this.label2.Text = "Enter Default Technician";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(36, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(187, 26);
            this.label3.TabIndex = 21;
            this.label3.Text = "Enter Part Order";
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(671, 451);
            this.txtPO.Name = "txtPO";
            this.txtPO.Size = new System.Drawing.Size(230, 26);
            this.txtPO.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 451);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(590, 120);
            this.label4.TabIndex = 19;
            this.label4.Text = resources.GetString("label4.Text");
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(709, 572);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(161, 34);
            this.btnEnter.TabIndex = 22;
            this.btnEnter.Text = "Enter";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(709, 523);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(161, 34);
            this.btnImport.TabIndex = 23;
            this.btnImport.Text = "Import from File";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(832, 639);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 17);
            this.label5.TabIndex = 26;
            this.label5.Text = "Version 1.0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(277, 639);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(361, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "Copyright © 2020 All Rights Reserved - Acrelec America";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(5, 634);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(928, 2);
            this.label7.TabIndex = 24;
            // 
            // frmConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 661);
            this.ControlBox = false;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtPO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTechnician);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConfiguration";
            this.Text = "Smart-i Assist | Configuration Panel";
            this.Load += new System.EventHandler(this.frmConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTechnician;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}