using System;
using System.Windows.Forms;

/*Smart-i Assist -Tech- Version 1.0
 * Created: 6/23/2020
 * Updated: 6/26/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */

namespace Smarti_Assist
{
    public partial class frmPO : Form
    {
        public frmPO()
        {
            InitializeComponent();
        }

        public String po { get; set; }  

        private void frmPO_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            po = txtInput.Text;
            this.Close();
        }
    }
}
