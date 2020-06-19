using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Smart-i Assist Version 0.6
 * Created: 6/9/2020
 * Updated: 6/19/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */


//TODO: Include an option to manually delete or reorder list once something has been added to the listbox?
namespace Smarti_Assist
{
    public partial class frmMain : Form
    {
        List<String> lstArkSerials, lstInjectorSerials;

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// Function to open secondary frame with contact information as dialogue 
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuHelpAbout</param>
        private void aboutSmartiAssistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout aboutFrame = new frmAbout();
            aboutFrame.ShowDialog();
        }

        /// <summary>
        /// Properly closes the application 
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuFileExit</param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// PRE: Data must be accesible to enter in frmDialogue
        /// POST: Take data entered by user which has been arleady validated and set it to local variables
        /// 
        /// Create a new form as dialogue and recieve validated input from it if the dialogue form returns OK.
        /// Set local list's data to the new validated data, clear visual list box and add that data to it for user.
        /// 
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">btnArk</param>
        /// <see cref="btnInj_Click(object, EventArgs)"/>
        private void btnArk_Click(object sender, EventArgs e)
        {
            using (frmDialogue dialogueForm = new frmDialogue())
            {
                var selection = dialogueForm.ShowDialog();
                if(selection==DialogResult.OK)
                {
                    lstArkSerials = dialogueForm.outReturn;

                    lstArk.Items.Clear();

                    if (lstArkSerials.ElementAt(0).Equals("PC"))
                    {
                        lstArkSerials.RemoveAt(0);
                    }

                    foreach (string line in lstArkSerials)
                    {
                        lstArk.Items.Add(line);
                    }
                }
            }
        }

        /// <summary>
        /// PRE: Data must be accesible to enter in frmDialogue
        /// POST: Take data entered by user which has been arleady validated and set it to local variables
        /// 
        /// Create a new form as dialogue and recieve validated input from it if the dialogue form returns OK.
        /// Set local list's data to the new validated data, clear visual list box and add that data to it for user.
        /// 
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">btnInj</param>
        /// <see cref="btnArk_Click(object, EventArgs)"/>
        private void btnInj_Click(object sender, EventArgs e)
        {
            using (frmDialogue dialogueForm = new frmDialogue())
            {
                var selection = dialogueForm.ShowDialog();
                if (selection == DialogResult.OK)
                {
                    lstInjectorSerials = dialogueForm.outReturn;

                    lstInj.Items.Clear();

                    if(lstInjectorSerials.ElementAt(0).Equals("Injector"))
                    {
                        lstInjectorSerials.RemoveAt(0);
                    }

                    foreach (string line in lstInjectorSerials)
                    {
                        lstInj.Items.Add(line);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {

            if(lstInjectorSerials.Count() == lstArkSerials.Count())
            {

            }
            else
            {
                MessageBox.Show("Number of serials listed for ARKs and Smart Injectors is not equal.","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //TODO: Validate input and print the labels
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            //TODO: Validate input and save labels as a PDF
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            //TODO: Validate input and print the labels
        }

        private void mnuFileImport_Click(object sender, EventArgs e)
        {
            //TODO: Take exported configuration file, read the data, and set the configuration settings equal to input file
        }

        private void mnuFileExport_Click(object sender, EventArgs e)
        {
            //TODO: Export configuration settings as an easily transferable file
        }

        private void mnuEditPrinter_Click(object sender, EventArgs e)
        {
            //TODO: Edit cached printer information
        }

        private void mnuEditTech_Click(object sender, EventArgs e)
        {
            //TODO: Edit the preset and saved field for technicians
        }

        private void mnuEditPart_Click(object sender, EventArgs e)
        {
            //TODO: Edit the preset and saved field for the part order
        }

        private void mnuEditQR_Click(object sender, EventArgs e)
        {
            //TODO: Edit whether or not the QR is included for some reason
        }

        private void mnuEditRemove_Click(object sender, EventArgs e)
        {
            //TODO: Delete the current settings to start first time set-up on next launch
        }

        /// <summary>
        /// Opens frmViewAssembly to provide a webbrowser view of the requested PDF
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuViewAss</param>
        /// <see cref="mnuViewSmart_Click(object, EventArgs)"/>
        private void mnuViewAss_Click(object sender, EventArgs e)
        {
            frmViewAssembly viewForm = new frmViewAssembly();
            viewForm.Show();
        }

        /// <summary>
        /// Opens frmViewSmart to provide a webbrowser view of the requested PDF
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuViewSmart</param>
        /// <see cref="mnuViewAss_Click(object, EventArgs)"/>
        private void mnuViewSmart_Click(object sender, EventArgs e)
        {
            frmViewSmart viewForm = new frmViewSmart();
            viewForm.Show();
        }

        /// <summary>
        /// Handles the checking and unchecking of chkInjector. Clears out the text field if the data is not to be
        /// included.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkInjector</param>
        /// <seealso cref="mnuEditPart_Click(object, EventArgs)"/>
        private void chkInjector_CheckedChanged(object sender, EventArgs e)
        {
            if(chkInjector.Checked==true)
            {
                txtPO.Enabled = true;
            }
            else
            {
                txtPO.Text = "";
                txtPO.Enabled = false;
            }
            //TODO: Change handling of chkInjector to be similar to chkTech so that it can be properly changed in the configuration file without an on change event handler
            //TODO: Change the configuration file to reflect the proper P.O. on subsequent boots.
        }

        /// <summary>
        /// Handles the checking and unchecking of chkTech. Asks the user if they would like to change the
        /// technician field. If so, runs a form to take that requested input. Notices a technician field that is empty
        /// and force un-checks the box
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkTech</param>
        /// <seealso cref="mnuEditTech_Click(object, EventArgs)"/>
        private void chkTech_CheckedChanged(object sender, EventArgs e)
        {
            if(chkTech.Checked==true)
            {


                var selection = MessageBox.Show("Do you wish to change the reprersented technician(s)?", "Change Technician(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(selection == DialogResult.Yes)
                {
                    using (frmTech techForm = new frmTech())
                    {
                        String techInput = techForm.technician;

                        if (techInput.Equals(""))
                        {
                            MessageBox.Show("Technician(s) cannot be included on the label if the technician field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkTech.Checked = false;
                        }
                    }
                }
                else if((selection == DialogResult.No) && txtTech.Text.Equals(""))
                {
                    MessageBox.Show("Technician(s) cannot be included on the label if the technician field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkTech.Checked = false;
                }

                //TODO: Change the configuration file to reflect the technician changes on subsequent boots.
            }
        }

        /// <summary>
        /// Opens a new form to allow the user to type his mail message. Sending is handled on the new form.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuHelpReport</param>
        private void mnuHelpReport_Click(object sender, EventArgs e)
        {
            frmMail mailForm = new frmMail();
            mailForm.ShowDialog();
        }
    }
}
