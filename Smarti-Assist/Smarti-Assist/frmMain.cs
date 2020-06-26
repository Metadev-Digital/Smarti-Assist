using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;
using iText.Layout;
using iText.Kernel.Font;
using iText.Kernel.Colors;
using iText.Layout.Properties;
using iText.Layout.Borders;
using iText.Barcodes;


/*Smart-i Assist Version 0.6
 * Created: 6/9/2020
 * Updated: 6/25/2020
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
        /// Clears out the list boxes and resets the lists
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuFileClear</param>
        private void mnuFileClear_Click(object sender, EventArgs e)
        {
            lstArk.Items.Clear();
            lstInj.Items.Clear();
            lstArkSerials = new List<string>();
            lstInjectorSerials = new List<string>();
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

        /// <summary>
        /// Calles validateSerials to check and make sure that the correct data has been input, then calls printLabels to process
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">btnPrint</param>
        /// <see cref="mnuFilePrint_Click(object, EventArgs)"/>
        /// <seealso cref="mnuFileSave_Click(object, EventArgs)"/>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if(validateSerials(lstArkSerials,lstInjectorSerials))
            {
                printLabels(lstArkSerials, lstInjectorSerials);
            }
        }

        /// <summary>
        /// Calles validateSerials to check and make sure that the correct data has been input, then calls saveLabels to process
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuFileSave</param>
        /// <seealso cref="btnPrint_Click(object, EventArgs)"/>
        /// <seealso cref="mnuFilePrint_Click(object, EventArgs)"/>
        private void mnuFileSave_Click(object sender, EventArgs e)
        {
            if(validateSerials(lstArkSerials,lstInjectorSerials))
            {
                saveLabels(lstArkSerials, lstInjectorSerials);
            }
        }

        /// <summary>
        /// Calles validateSerials to check and make sure that the correct data has been input, then calls printLabels to process
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuFilePrint</param>
        /// <see cref="btnPrint_Click(object, EventArgs)"/>
        /// <seealso cref="mnuFileSave_Click(object, EventArgs)"/>
        private void mnuFilePrint_Click(object sender, EventArgs e)
        {
            if(validateSerials(lstArkSerials,lstInjectorSerials))
            {
                printLabels(lstArkSerials, lstInjectorSerials);
            }
        }

        private void mnuFileImport_Click(object sender, EventArgs e)
        {
            //TODO: Take exported configuration file, read the data, and set the configuration settings equal to input file
        }

        private void mnuFileExport_Click(object sender, EventArgs e)
        {
            //TODO: Export configuration settings as an easily transferable file
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
        /// Forces a second thought on disabling the QR codes on account of the.... whole point.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkQR</param>
        private void chkQR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkQR.Checked.Equals(false))
            {
                var selection = MessageBox.Show("Are you sure you wish to disable the QR code on the output labels?", "Disable QR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (selection == DialogResult.No)
                {
                    chkQR.Checked = true;
                }
            }
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


        /// <summary>
        /// Checks for the existance of data inside of the variables before shipping them off for label making.
        /// Handled in a function so this doesn't have to be hand written 3 times.
        /// </summary>
        /// <param name="lstArkSerials">List of all Ark Serials</param>
        /// <param name="lstInjectorSerials">List of all Injector Serials</param>
        /// <returns></returns>
        private bool validateSerials(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
                if (lstInjectorSerials == null && lstArkSerials == null)
                {
                    MessageBox.Show("No serial entries were provided. Please enter data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (lstInjectorSerials == null)
                {
                    MessageBox.Show("No Smart Injector serials were provided. Enter data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if(lstArkSerials == null)
                {
                    MessageBox.Show("No ARK serials were provided. Enter data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (lstInjectorSerials.Count != lstArkSerials.Count)
                {
                    if (lstArkSerials.Count > lstInjectorSerials.Count)
                    {
                        MessageBox.Show("There are more ARK serial number entries than Smart Injectors. Re-enter the data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("There are more Smart Injector serial number entries than ARKs. Re-enter the data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }

            return true;
        }


        private void printLabels(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
            try
            {
                using(var stream = new MemoryStream())
                {
                    using (PdfWriter outWriter = new PdfWriter(stream))
                    {

                        PdfDocument outPDF = new PdfDocument(outWriter);

                        //Set to this size because an internet wizard said that it is 1 inch per 72 user units.
                        //I have no idea where this number comes from but it makes something printable for 3"x3"
                        iText.Kernel.Geom.Rectangle labelSize = new iText.Kernel.Geom.Rectangle(0, 0, 216, 216);
                        iText.Layout.Document outDocument = new iText.Layout.Document(outPDF, new PageSize(labelSize));

                        for (int i = 0; i < lstArkSerials.Count(); i++)
                        {

                            createLabel(outDocument, outPDF, lstArkSerials.ElementAt(i), lstInjectorSerials.ElementAt(i));
                        }

                        //TODO: Handle the actual printing here

                        outDocument.Close();
                        outPDF.Close();
                        outWriter.Close();

                    }
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Printer job was cancelled. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Prompts the user with a requested save location for the to-be-generated PDF
        /// Iterates through all elements inside of relevant lists to create the required number of labels inside 
        /// of the PDF document, separated by pages.
        /// </summary>
        /// <param name="lstArkSerials">List of strings, representative of the entered ARK serial numbers</param>
        /// <param name="lstInjectorSerials">List of strings, representative of the entered Injector serial numbers</param>
        private void saveLabels(List<string> lstArkSerials, List<string> lstInjectorSerials)
        {
            try
            {
                using (PdfWriter outWriter = new PdfWriter(choseDirectory() + "/Smart-i-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".pdf"))
                {
                    PdfDocument outPDF = new PdfDocument(outWriter);

                    //Set to this size because an internet wizard said that it is 1 inch per 72 user units.
                    //I have no idea where this number comes from but it makes something printable for 3"x3"
                    iText.Kernel.Geom.Rectangle labelSize = new iText.Kernel.Geom.Rectangle(0, 0, 216, 216);
                    iText.Layout.Document outDocument = new iText.Layout.Document(outPDF, new PageSize(labelSize));

                    for (int i = 0; i < lstArkSerials.Count(); i++)
                    {

                            createLabel(outDocument, outPDF, lstArkSerials.ElementAt(i), lstInjectorSerials.ElementAt(i));
                    }

                    outDocument.Close();
                    outPDF.Close();
                    outWriter.Close();

                    MessageBox.Show("Your file was successfully exported in your chosen directory as 'Smart-i-" + DateTime.UtcNow.ToString("MM-dd-yyyy") + ".pdf'", "Success!", MessageBoxButtons.OK);
                }
            }
            catch (System.IO.IOException)
            {
                MessageBox.Show("An unexcected error occured when trying to save the file in that location. Is there already a file" +
                    " with that name open and in use? Does the selected directory exist? Do you have permissions to save inside of it?" +
                    "\nPlease try again.",
                    "Unexected Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Export was cancelled. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Provides the user with a Windows form dialog for picking a folder to save the document to
        /// </summary>
        /// <returns>Selected folder filepath</returns>
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
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                dialog.IsFolderPicker = true;
                if (dialog.ShowDialog() != CommonFileDialogResult.Ok)
                {
                    var selection = MessageBox.Show("You have not selected an install location, do you want to cancel the export?", "No Location Selected",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if (selection == DialogResult.Yes)
                    {
                        throw new System.InvalidOperationException();
                    }
                    else
                    {
                        while(dialog.ShowDialog() != CommonFileDialogResult.Ok)
                        {

                        }
                    }   
                }
                return dialog.FileName;
            }
        }

        /// <summary>
        /// Creates a one page label the dimensions of the GX430t label maker on site. (3" x 3" labels)
        /// Takes in a document created by another function to be modular and callable by either a printing or saving action
        /// Handles different formatting options automatically depending on the options selected by the user.
        /// </summary>
        /// <param name="document">The base document that contains the data inside of the pdf</param>
        /// <param name="PDF">Object which contains the document and teaches it how to be one with the PDF</param>
        /// <param name="ark">Provided ark serial number for current iteration</param>
        /// <param name="inj">Provided smart injector serial number for current iteration</param>
        private void createLabel(Document document, PdfDocument PDF, string ark, string inj)
        {
            Style normal = new Style();
            Style header = new Style();
            Style subtext = new Style();
            Style subheader = new Style();

            PdfFont nfont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);
            PdfFont hFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA_BOLD);
            PdfFont sFont = PdfFontFactory.CreateFont(iText.IO.Font.Constants.StandardFonts.HELVETICA);

            normal.SetFont(nfont).SetFontSize(11);
            header.SetFont(hFont).SetFontSize(16);
            subheader.SetFont(hFont).SetFontSize(13);
            subtext.SetFont(sFont).SetFontSize(7);

            document.SetMargins(10, 25, 10, 25);

            Table table = new Table(new float[7]).UseAllAvailableWidth();
            table.SetMarginTop(0);
            table.SetMarginBottom(0);

            // Header
            table.AddCell(new Cell(1, 7).Add(new Paragraph("HAT-PROC-0025").AddStyle(header)).SetTextAlignment(TextAlignment.CENTER));

            // Header Subtext
            table.AddCell(new Cell(1, 7).Add(new Paragraph("ARK-1123H with Smart Injector").AddStyle(subtext)).SetTextAlignment(TextAlignment.CENTER).SetPadding(5).SetMaxHeight(10).SetBorder(Border.NO_BORDER).SetBorderBottom(new SolidBorder(ColorConstants.BLACK, 1)));

            // PC Data Row
            table.AddCell(new Cell(2, 2).Add(new Paragraph("PC:").AddStyle(subheader)).SetBorder(Border.NO_BORDER).SetPaddingBottom(10));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Part:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph("HAPC0000088").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Serial:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingTop(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph(ark).AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingTop(0));

            // Injector Data Row
            table.AddCell(new Cell(2, 2).Add(new Paragraph("Injector:").AddStyle(subheader)).SetBorder(Border.NO_BORDER).SetPaddingBottom(10));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Part:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph("HAT-HYPR-0284").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingBottom(0));
            table.AddCell(new Cell(1, 1).Add(new Paragraph("Serial:").AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.RIGHT).SetPaddingTop(0));
            table.AddCell(new Cell(1, 4).Add(new Paragraph(inj).AddStyle(subtext)).SetBorder(Border.NO_BORDER).SetTextAlignment(TextAlignment.LEFT).SetPaddingTop(0));

            // Data Row
            if (chkQR.Checked.Equals(true))
            {
                table.AddCell(new Cell(4, 3).Add(new Image(new BarcodeQRCode(ark + " / " + inj).CreateFormXObject(PDF)).SetHeight(70).SetWidth(70)).SetBorder(Border.NO_BORDER).SetPadding(0));
            }
            else
            {
                table.AddCell(new Cell(4, 3).SetBorder(Border.NO_BORDER));
            }

            if (chkInjector.Checked.Equals(true))
            {
                table.AddCell(new Cell(1, 1).Add(new Paragraph("P.O.").AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).Add(new Paragraph(txtPO.Text).AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
            }
            else
            {
                table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).SetBorder(Border.NO_BORDER));
            }

            if (chkTech.Checked.Equals(true))
            {
                table.AddCell(new Cell(1, 1).Add(new Paragraph("Locale:").AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).Add(new Paragraph("U.S.A.").AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 4).Add(new Paragraph(txtTech.Text).AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER));
            }
            else
            {
                table.AddCell(new Cell(1, 1).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 3).SetBorder(Border.NO_BORDER));
                table.AddCell(new Cell(1, 4).SetBorder(Border.NO_BORDER));
            }

            if (chkDate.Checked.Equals(true))
            {
                table.AddCell(new Cell(1, 4).Add(new Paragraph(DateTime.UtcNow.ToString("MM-dd-yyyy")).AddStyle(subtext).SetTextAlignment(TextAlignment.LEFT)).SetBorder(Border.NO_BORDER).SetPaddingBottom(0));
            }
            /*
             * Handles the case that in the extremely unlikely event that no additional data at all is included on the label,
             * sets the second to last cell to have a set height to allow the footer to still be in the correct position
             */
            else if (chkDate.Checked.Equals(false) && chkInjector.Checked.Equals(false) && chkQR.Checked.Equals(false) && chkTech.Checked.Equals(false))
            {
                table.AddCell(new Cell(1, 4).SetHeight(50).SetBorder(Border.NO_BORDER));
            }
            else
            {
                table.AddCell(new Cell(1, 4).SetBorder(Border.NO_BORDER));
            }

            // Footer
            table.AddCell(new Cell(1, 7).Add(new Paragraph("Acrelec America - https://acrelec.com/").AddStyle(subtext)).SetTextAlignment(TextAlignment.CENTER).SetBorder(Border.NO_BORDER).SetBorderTop(new SolidBorder(ColorConstants.BLACK, 1)).SetPaddingTop(0));

            document.Add(table);
        }
    }
}
