using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/*Smart-i Assist -Dialogue- Version 1.0
 * Created: 6/16/2020
 * Updated: 6/26/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */

namespace Smarti_Assist
{
    public partial class frmDialogue : Form
    {
        public frmDialogue()
        {
            InitializeComponent();

        }
        
        /// <summary>
        /// outReturn is the public accessor for frmDialogue for frmMain to get the validated data from txtInput
        /// </summary>
        public List<String> outReturn { get; set; }


        /// <summary>
        /// btnOK takes the data that was inputed in txtInput, validates it to verfify it's proper
        /// then splits it by enterline (like expected/prompted), adding each individual string to a list.
        /// Afterwards, the public accessor, outReturn is set to the validated data to be interacted with on the main form.
        /// </summary>
        /// <param name="sender">frmDialogue</param>
        /// <param name="e"btnOK></param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtInput.Text.Equals(""))
            {
                var selection = MessageBox.Show("No data was entered, do you wish to clear the current serials?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(selection==DialogResult.Yes)
                {
                    List<String> emptyOut = new List<String>();
                    emptyOut.Add("");
                    this.outReturn = emptyOut;
                }
            }
            else
            {
                List<String> output = txtInput.Text.Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

                this.DialogResult = DialogResult.OK;
                this.outReturn = output;
                this.Close();
            }
        }

        /// <summary>
        /// btnCancel simply returns a result of having cancelled out of the dialogue
        /// </summary>
        /// <param name="sender">frmDialogue</param>
        /// <param name="e">btnCancel</param>
        private void Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmDialogue_Load(object sender, EventArgs e)
        {
            txtInput.Focus();
        }
    }
}
