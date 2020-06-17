using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Smart-i Assist -About- Version 0.6
 * Created: 6/9/2020
 * Updated: 6/17/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Meteadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */


namespace Smarti_Assist
{
    public partial class frmAbout : Form
    {
        public frmAbout()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Opens a new form to allow the user to type his mail message. Sending is handled on the new form.
        /// </summary>
        /// <param name="sender">frmAbout</param>
        /// <param name="e">btnContact</param>
        /// <see cref="frmMain.mnuHelpReport_Click(object, EventArgs)"/>
        private void btnContact_Click(object sender, EventArgs e)
        {
            frmMail mailForm = new frmMail();
            mailForm.ShowDialog();
        }
    }
}
