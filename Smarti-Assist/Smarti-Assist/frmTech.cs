using System;
using System.Windows.Forms;

/*Smart-i Assist -Tech- Version 1.0.0.5
 * Created: 6/19/2020
 * Updated: 7/9/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@metadevdigital.com
 * 
 * Copyright Copyright MIT Liscenece  - Enjoy boys, keep updating without me. Fork to your hearts content
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

        private void frmTech_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSubmit_Click(null, null);
            }
        }
    }
}
