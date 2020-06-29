using Smarti_Assist.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


/*Smart-i Assist -About- Version 1.0
 * Created: 6/29/2020
 * Updated: 6/29/2020
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

        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(txtPO.Text!=null && txtTechnician.Text!=null)
            {
                Settings.Default.technician = txtTechnician.Text;
                Settings.Default.partorder = txtPO.Text;
                Settings.Default.configuration = false ;

                Settings.Default.Save();

                this.Close();
            }
            else
            {
                if (txtPO.Text==null && txtTechnician==null)
                {
                    MessageBox.Show("Technician and Part Order fields cannot be empty. These fields can be disabled from " +
                        "printing later if you do not wish for them to be displayed, however a default entry is required.",
                        "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(txtPO.Text==null)
                {
                    MessageBox.Show("Part order field is empty. These fields can be disabled from " +
                        "printing later if you do not wish for them to be displayed, however a default  entry " +
                        "is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Technician field is empty. These fields can be disabled from " +
                        "printing later if you do not wish for them to be displayed, however a default  entry " +
                        "is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {

        }
    }
}
