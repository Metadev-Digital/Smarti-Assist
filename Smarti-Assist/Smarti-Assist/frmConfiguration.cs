using Smarti_Assist.Properties;
using System;
using System.Windows.Forms;


/*Smart-i Assist -About- Version 1.0.0.5
 * Created: 6/29/2020
 * Updated: 7/9/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */


namespace Smarti_Assist
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version " + Settings.Default.version;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(!(txtPO.Text == null || txtPO.Text == "") && !(txtTechnician.Text == null || txtTechnician.Text == ""))
            {
                Settings.Default.technician = txtTechnician.Text;
                Settings.Default.partorder = txtPO.Text;
                Settings.Default.configuration = false ;
                Settings.Default.isChkTech = true;
                Settings.Default.isChkInj = true;

                this.Close();
            }
            else
            {
                if ((txtPO.Text==null || txtPO.Text=="") && (txtTechnician.Text==null || txtTechnician.Text==""))
                {
                   var selection = MessageBox.Show("Technician and Purchase Order fields should not be empty. These fields can be disabled from " +
                        "printing later if you do not wish for them to be displayed, however a default entry is recommended.\n\n" +
                        "Do you wish to continue anyway?",
                        "Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (selection==DialogResult.Yes)
                    {
                        Settings.Default.technician = "";
                        Settings.Default.partorder = "";
                        Settings.Default.isChkTech = false;
                        Settings.Default.isChkInj = false;
                        Settings.Default.configuration = false;

                        this.Close();
                    }
                }
                else if(txtPO.Text==null || txtPO.Text=="")
                {
                    var selection = MessageBox.Show("Purchase order field is empty. This field can be disabled from " +
                        "printing later if you do not wish for it to be displayed, however a default entry " +
                        "is recommended.\n\nDo you wish to continue anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if(selection==DialogResult.Yes)
                    {
                        Settings.Default.technician = txtTechnician.Text;
                        Settings.Default.partorder = "";
                        Settings.Default.isChkInj = false;
                        Settings.Default.isChkTech = true;
                        Settings.Default.configuration = false;

                        this.Close();
                    }
                }
                else
                {
                    var selection = MessageBox.Show("Technician field is empty. This field can be disabled from " +
                        "printing later if you do not wish for it to be displayed, however a default entry " +
                        "is recommended.\n\nDo you wish to continue anyway?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                   
                    if (selection == DialogResult.Yes)
                    {
                        Settings.Default.partorder = txtPO.Text;
                        Settings.Default.technician = "";
                        Settings.Default.isChkTech = false;
                        Settings.Default.isChkInj = true;
                        Settings.Default.configuration = false;

                        this.Close();
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            using (fileManipulator fm = new fileManipulator())
            {
                fm.import();
            }

            this.Close();
        }

    }
}
