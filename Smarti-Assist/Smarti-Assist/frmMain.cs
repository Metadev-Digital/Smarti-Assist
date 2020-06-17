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
 * Updated: 6/16/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Meteadevllc.com
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

                    foreach(string line in lstArkSerials)
                    {
                        lstArk.Items.Add(line);
                    }
                }
            }
            //TODO: Verify that the data inside of lstArkSerials and lstInjectorSerials is not being overwritten on next run of frmDialogue due to byref
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

                    foreach (string line in lstInjectorSerials)
                    {
                        lstInj.Items.Add(line);
                    }
                }
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
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
