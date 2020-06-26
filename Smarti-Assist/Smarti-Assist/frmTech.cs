using System;
using System.Windows.Forms;

/*Smart-i Assist -Tech- Version 1.0
 * Created: 6/19/2020
 * Updated: 6/26/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */

namespace Smarti_Assist
{
    public partial class frmTech : Form
    {
        public frmTech()
        {
            InitializeComponent();
        }

        public String technician { get; set; }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            technician = txtInput.Text;
            this.Close();
        }

        private void frmTech_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }
    }
}
