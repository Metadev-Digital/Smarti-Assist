using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

/*Smart-i Assist Version 0.6
 * Created: 6/9/2020
 * Updated: 6/24/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */


//TODO: Include an option to manually delete or reorder list once something has been added to the listbox?
//TODO: Include an option to set the number of EACH label to be printed. Do you want 1,2,3,4,etc.. copies of each?
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

            printLabels(lstArkSerials,lstInjectorSerials);



         //   if(lstInjectorSerials.Count()>0 && lstArkSerials.Count()>0)
           // {
             //   if (lstInjectorSerials.Count() == lstArkSerials.Count())
               // {

                //}
                //else
                //{
                //    MessageBox.Show("Number of serials listed for ARKs and Smart Injectors is not equal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
            //}
            //else
            //{
            //    MessageBox.Show("Serials not properly entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
 
            //TODO: Validate input and print the labels
        }

        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            saveLabels(lstArkSerials, lstInjectorSerials);

            //if (lstInjectorSerials.Count() == lstArkSerials.Count())
            //{

            //}
            //else
            //{
            //    MessageBox.Show("Number of serials listed for ARKs and Smart Injectors is not equal.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

            //TODO: Validate input and save labels as a PDF
        }

        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            printLabels(lstArkSerials,lstInjectorSerials);
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
        /// Handles the checking and unchecking of chkInjector. Asks the user if they would like to change the
        /// PO field. If so, runs a form to take that requested input. notices a P.O. field that is empty
        /// and then force unchecks the box.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkInjector</param>
        /// <seealso cref="mnuEditPart_Click(object, EventArgs)"/>
        private void chkInjector_CheckedChanged(object sender, EventArgs e)
        {
            if(chkInjector.Checked==true)
            {
                var selection = MessageBox.Show("Do you wish to change the unit's Part Order?", "Change Part Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (selection.Equals(DialogResult.Yes))
                {
                    using (frmPO poForm = new frmPO())
                    {
                        poForm.ShowDialog();

                        if (poForm.po == "")
                        {
                            MessageBox.Show("Part Order cannot be included on the label if the Part Order Field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkInjector.Checked = false;
                        }

                        txtPO.Text = poForm.po;
                    }
                }
                else if(selection == DialogResult.No && txtPO.Text.Equals("") )
                {
                    MessageBox.Show("Part Order cannot be included on the label if the Part Order Field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkInjector.Checked = false;
                }
            }
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
                        techForm.ShowDialog();

                        if (techForm.technician=="")
                        {
                            MessageBox.Show("Technician(s) cannot be included on the label if the technician field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            chkTech.Checked = false;
                        }

                        txtTech.Text = techForm.technician;
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

        private void printLabels(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
            //TODO: This
            throw new NotImplementedException();
        }

        private void saveLabels(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
            using (PdfWriter outWriter = new PdfWriter(choseDirectory() + "/helloworld.pdf"))
            {
                PdfDocument outPDF = new PdfDocument(outWriter);
                //Set to this size because an internet wizard said that it is 1 inch per 72 user units.
                //I have no idea where this number comes from but it makes something printable for 3"x3"
                iText.Kernel.Geom.Rectangle labelSize = new iText.Kernel.Geom.Rectangle(0, 0, 216, 216);
                iText.Layout.Document document = new iText.Layout.Document(outPDF, new PageSize(labelSize));
                document.SetMargins(2, 2, 2, 2);
                iText.Layout.Element.Paragraph p = new iText.Layout.Element.Paragraph("Hello World!");
                document.Add(p);
                document.Add(new AreaBreak(new PageSize(labelSize)));
                document.SetMargins(20, 20, 20, 20);
                document.Add(p);
                document.Add(p);
                document.Close();

                outPDF.Close();
                outWriter.Close();
            }
            //TODO: Finish fleshing out the pdf construction
            //TODO: Break up the pdf construction into a separate function so it can be called recursively
        }

        private string choseDirectory()
        {
            /* Note:
            * 
            * CommonOpenFileDialog has a weird error if a user has a scaling set on their monitor higher than
            * 100%. This casues all open frames to set back down to a 100% scaling after opening. To counter-act
            * this there is a line in the app.config that makes the program keep track of the scaling of all
            * used monitors so it can be reset afterwards
            */

            using (CommonOpenFileDialog dialog = new CommonOpenFileDialog())
            {
                dialog.InitialDirectory = "C:\\Users";
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    MessageBox.Show("You selected: " + dialog.FileName);
                }

                return dialog.FileName;
            }
        }

        //Shoud create a PDF to memory.
        private byte[] createPDF()
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);
            var pdf = new PdfDocument(writer);
            var document = new iText.Layout.Document(pdf);

            document.Add(new iText.Layout.Element.Paragraph("Hello world!"));
            document.Close();

            return stream.ToArray();
        }
    }
}
