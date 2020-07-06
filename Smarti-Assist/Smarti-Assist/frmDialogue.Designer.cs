namespace Smarti_Assist
{
    partial class frmDialogue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDialogue));
            this.btnOK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(348, 16);
            this.btnOK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(59, 21);
            this.btnOK.TabIndex = 0;
            this.btnOK.Text = "Ok";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(348, 40);
            this.Cancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(59, 21);
            this.Cancel.TabIndex = 1;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 26);
            this.label1.TabIndex = 2;
            this.label1.Text = "Please enter raw serial number data separated by enterlines:\r\n(Copy/Pasted from S" +
    "mart Injector tracability Excel document)";
            // 
            // txtInput
            // 
            this.txtInput.AcceptsReturn = true;
            this.txtInput.AcceptsTab = true;
            this.txtInput.AllowDrop = true;
            this.txtInput.Location = new System.Drawing.Point(11, 81);
            this.txtInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(398, 77);
            this.txtInput.TabIndex = 3;
            // 
            // frmDialogue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 174);
            this.ControlBox = false;
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmDialogue";
            this.Text = "Input Serials";
            this.Load += new System.EventHandler(this.frmDialogue_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInput;
    }
}