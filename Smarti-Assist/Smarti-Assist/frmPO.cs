using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Smart-i Assist -Tech- Version 0.6
 * Created: 6/23/2020
 * Updated: 6/23/2020
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

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            po = txtInput.Text;
            this.Close();
        }
    }
}
