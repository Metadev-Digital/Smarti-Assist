using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AAInfo;
using Microsoft.Win32;
using Smarti_Assist.Properties;


/*Smart-i Assist Version 1.0.0.5
 * Created: 6/9/2020
 * Updated: 7/9/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@metadevdigital.com
 * 
 * Copyright Copyright MIT Liscenece  - Enjoy boys, keep updating without me. Fork to your hearts content
 */

//---------------FOR VERSION 1.0------------------
//Additional Features:
//CURRENTLY DONE

//Processes:
//CURRENTLY DONE

//Content & Visuals
//CURRENTLY DONE

//1.0 RELEASE READY

//---------------FOR VERSION 1.X------------------
//Additional Features:
//TODO: Include an option to manually delete or reorder list once something has been added to the listbox?

//Processes:
//TODO: JSON my man (Newtonsoft.Json) - Better way to handle import/export
//TODO: Configure Reports to be a nice HTML email


//Bug Fix:
//TODO: Fix import config on frmConfig closing the frame even if no file is succesfully imported
//TODO: Fix strange issues caused by attempting to reset to defaults without running first time config and then saving to PDF.
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
            //Only works for deployment environment. Remove below line for testing.
            SetAddRemoveProgramsIcon();

            Settings.Default.Reload();
            if(Settings.Default.configuration==true)
            {
                using (frmConfiguration configForm = new frmConfiguration())
                {
                    configForm.ShowDialog();
                }
            }

            validateSettings();
            lblVersion.Text = "Version " + Settings.Default.version;
        }


        /// <summary>
        /// Function to open secondary frame with contact information as dialogue 
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuHelpAbout</param>
        private void aboutSmartiAssistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ErrorReporter errorReporter = new ErrorReporter("Smart-i Assist");
            InfoDisplayer infoDisplayer = new InfoDisplayer("Smart-i Assist", "Acrelec America", "MIT Licence", "help facilitate " +
                "construction of our in-house product, Hyperviews", errorReporter);
            infoDisplayer.showForm();
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
            lstArkSerials.Clear();
            lstInjectorSerials.Clear();

            MessageBox.Show("Serials successfully reset.", "Reset Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                using(labelMaker lm = new labelMaker())
                {
                    lm.printLabels(lstArkSerials, lstInjectorSerials);
                }
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
                using(labelMaker lm = new labelMaker())
                {
                    lm.saveLabels(lstArkSerials, lstInjectorSerials);
                }
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
                using(labelMaker lm = new labelMaker())
                {
                    lm.printLabels(lstArkSerials, lstInjectorSerials);
                }
            }
        }

        /// <summary>
        /// Prompts the user for a selected file to import. Attempts its best at itterating through the file to find the data.
        /// If the version does not match, the program will still try and read the file to change the settings.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileImport_Click(object sender, EventArgs e)
        {
            using(fileManipulator fm = new fileManipulator())
            {
                fm.import();
            }

            validateSettings();
        }

        /// <summary>
        /// Prompts the user for selected directory to export. Grabs all the data saved in the settings and exports ot a .sic file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mnuFileExport_Click(object sender, EventArgs e)
        {
            using(fileManipulator fm = new fileManipulator())
            {
                fm.export();
            }
        }

        /// <summary>
        /// Takes part of the ischanged function for chkTech, prompts a user to enter the new tech field, then saves it in settings
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuEditTech</param>
        private void mnuEditTech_Click(object sender, EventArgs e)
        {
            using (frmTech techForm = new frmTech())
            {
                techForm.ShowDialog();

                if (techForm.technician == null || techForm.technician == "")
                {
                    MessageBox.Show("Technician(s) cannot be included on the label(s) if the technician field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Settings.Default.isChkTech = false;
                    Settings.Default.technician = "";
                }
                else
                {
                    Settings.Default.technician = techForm.technician;
                }
                validateSettings();
            }
        }

        /// <summary>
        /// Takes part of the ischanged function for chkPO, prompts a user to enter the new part order, then saves it in settings
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuEditTech</param>
        private void mnuEditPart_Click(object sender, EventArgs e)
        {
            using (frmPO poForm = new frmPO())
            {
                poForm.ShowDialog();

                if (poForm.po == null || poForm.po == "")
                {
                    MessageBox.Show("Purchase Order cannot be included on the label(s) if the purchase Order field is empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Settings.Default.isChkTech = false;
                    Settings.Default.partorder = "";
                }
                else
                {
                    Settings.Default.partorder = poForm.po;
                }
                validateSettings();
            }
        }

        /// <summary>
        /// Deletes the set settings, then asks the user if they want to reconfigure the settings now or on next launch.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuEditRemove</param>
        private void mnuEditRemove_Click(object sender, EventArgs e)
        {
            var selection = MessageBox.Show("Are you sure you wish to reset the configuration \nfile back to defaults? This will remove " +
                "ALL settings.", "Remove Settings?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (selection == DialogResult.Yes)
            {
                Settings.Default.Reset();
                Settings.Default.Save();
                validateSettings();

                var selection2 = MessageBox.Show("Do you wish run the first time configuration now?" +
                    "\nNote: If not run now, you will still see first time configuration panel on next launch.", "Reset now?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(selection2==DialogResult.Yes)
                {
                    using (frmConfiguration configForm = new frmConfiguration())
                    {
                        configForm.ShowDialog();
                        validateSettings();
                    }
                }
            }
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
        /// <param name="e">chkDate</param>
        private void chkDate_Click(object sender, EventArgs e)
        {
            if(chkDate.Checked)
            {
                Settings.Default.isChkDate = true;
            }
            else
            {
                Settings.Default.isChkDate = false;
            }

            Settings.Default.Save();
            Settings.Default.Reload();
        }

        /// <summary>
        /// Forces a second thought on disabling the QR codes on account of the.... whole point.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkQR</param>
        private void chkQR_Click(object sender, EventArgs e)
        {
            if (chkQR.Checked.Equals(false))
            {
                var selection = MessageBox.Show("Are you sure you wish to disable \nthe QR code on the output labels?", "Disable QR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (selection == DialogResult.No)
                {
                    chkQR.Checked = true;
                    Settings.Default.isChkQR = true;
                }
                else
                {
                    Settings.Default.isChkQR = false;
                }
            }
            else
            {
                Settings.Default.isChkQR = true;
            }

            Settings.Default.Save();
            Settings.Default.Reload();
        }


        /// <summary>
        /// Handles the checking and unchecking of chkInjector. Asks the user if they would like to change the
        /// PO field. If so, runs a form to take that requested input. notices a P.O. field that is empty
        /// and then force unchecks the box.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkInjector</param>
        /// <seealso cref="mnuEditPart_Click(object, EventArgs)"/>
        private void chkInjector_Click(object sender, EventArgs e)
        {
            if(chkInjector.Checked==true)
            {
                var selection = MessageBox.Show("Do you wish to change the unit's Purchase Order?", "Change Purchase Order?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (selection.Equals(DialogResult.Yes))
                {
                    using (frmPO poForm = new frmPO())
                    {
                        poForm.ShowDialog();

                        if (poForm.po == null || poForm.po == "")
                        {
                            MessageBox.Show("Purchase Order cannot be included on the label if the Purchase Order Field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Settings.Default.partorder = "";
                            Settings.Default.isChkInj = false;
                        }
                        else
                        {
                            Settings.Default.partorder = poForm.po;
                            Settings.Default.isChkInj = true;
                        }
                    }
                }
                else if(selection == DialogResult.No && txtPO.Text.Equals("") )
                {
                    MessageBox.Show("Purchase Order cannot be included on the label if the Purchase Order Field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Settings.Default.isChkInj = false;
                }
                else
                {
                    Settings.Default.isChkInj = true;
                }
            }
            else
            {
                Settings.Default.isChkInj = false;
            }
            validateSettings();
        }

        /// <summary>
        /// Handles the checking and unchecking of chkTech. Asks the user if they would like to change the
        /// technician field. If so, runs a form to take that requested input. Notices a technician field that is empty
        /// and force un-checks the box
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">chkTech</param>
        /// <seealso cref="mnuEditTech_Click(object, EventArgs)"/>
        private void chkTech_Click(object sender, EventArgs e)
        {
            if (chkTech.Checked == true)
            {
                var selection = MessageBox.Show("Do you wish to change the default Technician(s)?", "Change Technician(s)?", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (selection.Equals(DialogResult.Yes))
                {
                    using (frmTech techForm = new frmTech())
                    {
                        techForm.ShowDialog();

                        if (techForm.technician == null || techForm.technician == "")
                        {
                            MessageBox.Show("Technician(s) cannot be included on the label if the Technician(s) field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Settings.Default.technician = "";
                            Settings.Default.isChkTech = false;
                        }
                        else
                        {
                            Settings.Default.technician = techForm.technician;
                            Settings.Default.isChkTech = true;
                        }
                    }
                }
                else if (selection == DialogResult.No && txtTech.Text.Equals(""))
                {
                    MessageBox.Show("Technician(s) cannot be included on the label if the Technician(s) Field is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Settings.Default.isChkTech = false;
                }
                else
                {
                    Settings.Default.isChkTech = true;
                }
            }
            else
            {
                Settings.Default.isChkTech = false;
            }
            validateSettings();

        }

        /// <summary>
        /// Opens a new form to allow the user to type his mail message. Sending is handled on the new form.
        /// </summary>
        /// <param name="sender">frmMain</param>
        /// <param name="e">mnuHelpReport</param>
        private void mnuHelpReport_Click(object sender, EventArgs e)
        {
            ErrorReporter errorReporter = new ErrorReporter("Smart-i Assist");
            errorReporter.showForm();
        }

        /// <summary>
        /// Takes a string input and returns it as a boolean, throws invalid cast exception if not
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool returnBool(string str)
        {
            if (str.ToLower().Equals("true"))
                return true;
            else if (str.ToLower().Equals("false"))
                return false;
            else
                throw new InvalidCastException();
        }


        /// <summary>
        /// Runs through all of the settings to flip and set fields as necessary.
        /// </summary>
        public void validateSettings()
        {
            //Text Fields
            if (Settings.Default.technician == null || Settings.Default.technician == "")
            {
                txtTech.Text = "";
                Settings.Default.isChkTech = false;
            }
            else
            {
                txtTech.Text = Settings.Default.technician;
            }

            if (Settings.Default.partorder == null || Settings.Default.partorder == "")
            {
                txtPO.Text = "";
                Settings.Default.isChkInj = false;
            }
            else
            {
                txtPO.Text = Settings.Default.partorder;
            }

            //Handles save & reload in the event that one of the options above were changed, but also assuming that they were changed before this was called.
            Settings.Default.Save();
            Settings.Default.Reload();

            //Check Boxes
            if (Settings.Default.isChkDate)
            {
                chkDate.Checked = true;
            }
            else
            {
                chkDate.Checked = false;
            }

            if (Settings.Default.isChkQR)
            {
                chkQR.Checked = true;
            }
            else
            {
                chkQR.Checked = false;
            }

            if (Settings.Default.isChkTech)
            {
                chkTech.Checked = true;
            }
            else
            {
                chkTech.Checked = false;
            }

            if (Settings.Default.isChkInj)
            {
                chkInjector.Checked = true;
            }
            else
            {
                chkInjector.Checked = false;
            }

            //NumberUpDown
            nudCopies.Value = Settings.Default.copies;
        }

        /// <summary>
        /// Updates setting copies with the number set in nudCopies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nudCopies_ValueChanged(object sender, EventArgs e)
        {
            //Should not need to round due to increment, but to be safe.
            Settings.Default.copies = Convert.ToInt32(Math.Round(nudCopies.Value, 0));

            Settings.Default.Save();
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
                if ((lstInjectorSerials == null || lstInjectorSerials.Count<1) && (lstArkSerials == null || lstArkSerials.Count<1))
                {
                    MessageBox.Show("No serial entries were provided. \nPlease enter data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (lstInjectorSerials == null || lstInjectorSerials.Count<1)
                {
                    MessageBox.Show("No Smart Injector serials were provided. \nEnter data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if(lstArkSerials == null || lstArkSerials.Count<1)
                {
                    MessageBox.Show("No ARK serials were provided. \nEnter data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                else if (lstInjectorSerials.Count != lstArkSerials.Count)
                {
                    if (lstArkSerials.Count > lstInjectorSerials.Count)
                    {
                        MessageBox.Show("There are more ARK serial number entries \nthan Smart Injectors. Re-enter the data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("There are more Smart Injector serial number entries \nthan ARKs. Re-enter the data and try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return false;
                }

            return true;
        }

        private static void SetAddRemoveProgramsIcon()
        {
            //Only execute on a first run after first install or after update
            if (ApplicationDeployment.CurrentDeployment.IsFirstRun)
            {
                try
                {
                    // Set the name of the application EXE file - make sure to include `,0` at the end.
                    // Does not work for ClickOnce applications as far as I could figure out... Note, this will probably work
                    // when run from Visual Studio, but not when deployed.
                    //string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "example.exe,0");
                    // Reverted to using this instead (note this will probably not work when run from Visual Studio, but will work on deploy.
                    string iconSourcePath = Path.Combine(System.Windows.Forms.Application.StartupPath, "Acrelec Favicon.ico");
                    if (!File.Exists(iconSourcePath))
                    {
                        MessageBox.Show("We could not find the application icon. Please notify your software vendor of this error.");
                        return;
                    }

                    RegistryKey myUninstallKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Uninstall");
                    string[] mySubKeyNames = myUninstallKey.GetSubKeyNames();
                    for (int i = 0; i < mySubKeyNames.Length; i++)
                    {
                        RegistryKey myKey = myUninstallKey.OpenSubKey(mySubKeyNames[i], true);
                        object myValue = myKey.GetValue("DisplayName");
                        Console.WriteLine(myValue.ToString());
                        // Set this to the display name of the application. If you are not sure, browse to the registry directory and check.
                        if (myValue != null && myValue.ToString() == "Smarti Assist")
                        {
                            myKey.SetValue("DisplayIcon", iconSourcePath);
                            break;
                        }
                    }
                }
                catch (Exception mye)
                {
                    MessageBox.Show("We could not properly setup the application icons. Please notify your software vendor of this error.\r\n" + mye.ToString());
                }
            }
        }
    }
}
