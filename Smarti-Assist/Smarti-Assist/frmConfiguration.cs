using Smarti_Assist.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


/*Smart-i Assist -About- Version 1.0
 * Created: 6/29/2020
 * Updated: 7/6/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */


namespace Smarti_Assist
{
    public partial class frmConfiguration : Form
    {
        public frmConfiguration()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void frmConfiguration_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version " + Settings.Default.version;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(!(txtPO.Text == null || txtPO.Text == "") && !(txtTechnician.Text == null || txtTechnician.Text == ""))
            {
                Settings.Default.technician = txtTechnician.Text;
                Settings.Default.partorder = txtPO.Text;
                Settings.Default.configuration = false ;
                Settings.Default.isChkTech = true;
                Settings.Default.isChkInj = true;

                this.Close();
            }
            else
            {
                if ((txtPO.Text==null || txtPO.Text=="") && (txtTechnician.Text==null || txtTechnician.Text==""))
                {
                   var selection = MessageBox.Show("Technician and Purchase Order fields should not be empty. These fields can be disabled from " +
                        "printing later if you do not wish for them to be displayed, however a default entry is recommended.\n\n" +
                        "Do you wish to continue anyway?",
                        "Error",MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if (selection==DialogResult.Yes)
                    {
                        Settings.Default.technician = "";
                        Settings.Default.partorder = "";
                        Settings.Default.isChkTech = false;
                        Settings.Default.isChkInj = false;

                        this.Close();
                    }
                }
                else if(txtPO.Text==null || txtPO.Text=="")
                {
                    var selection = MessageBox.Show("Purchase order field is empty. This field can be disabled from " +
                        "printing later if you do not wish for it to be displayed, however a default entry " +
                        "is recommended.\n\nDo you wish to continue anyway?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);

                    if(selection==DialogResult.Yes)
                    {
                        Settings.Default.technician = txtTechnician.Text;
                        Settings.Default.partorder = "";
                        Settings.Default.isChkInj = false;
                        Settings.Default.isChkTech = true;

                        this.Close();
                    }
                }
                else
                {
                    var selection = MessageBox.Show("Technician field is empty. This field can be disabled from " +
                        "printing later if you do not wish for it to be displayed, however a default entry " +
                        "is recommended.\n\nDo you wish to continue anyway?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                   
                    if (selection == DialogResult.Yes)
                    {
                        Settings.Default.partorder = txtPO.Text;
                        Settings.Default.technician = "";
                        Settings.Default.isChkTech = false;
                        Settings.Default.isChkInj = true;

                        this.Close();
                    }
                }
            }
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Smart-i Assist Configuration Files | *.sic";
            dialog.Multiselect = false;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(new FileStream(dialog.FileName, FileMode.Open), new UTF8Encoding()))
                {
                    try
                    {
                        String[] newSettings = new string[6];
                        bool properImport = false;

                        if (sr.ReadLine().Equals("SIC - SMART-I ASSIST"))
                        {
                            //Imports the rest of the file to a List for manipulation
                            List<String> fileText = sr.ReadToEnd().Split(new[] { System.Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();

                            //Uses string.contains with Linq expression to allow searching for a partial string since lists will not.
                            int searchIndex = fileText.FindIndex(str => str.Contains("Version"));
                            if (searchIndex >= 0)
                            {

                                string version = fileText.ElementAt(searchIndex);
                                version = version.Substring(version.IndexOf(":") + 2);

                                //Version match, we know the exact layout of this file
                                if (version == Settings.Default.version)
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        newSettings[i] = fileText.ElementAt(++searchIndex);
                                        newSettings[i] = newSettings[i].Substring(newSettings[i].IndexOf(":") + 2);
                                    }

                                    properImport = true;
                                }
                                //Version missmatch, we cannot assume anything about this file, but it might contain the data we're looking for
                                else
                                {
                                    for (int i = 0; i < 6; i++)
                                    {
                                        string search;
                                        switch (i)
                                        {
                                            case 0:
                                                search = "Technician:";
                                                break;
                                            case 1:
                                                search = "Purchase-Order:";
                                                break;
                                            case 2:
                                                search = "Date-Checked:";
                                                break;
                                            case 3:
                                                search = "QR-Checked:";
                                                break;
                                            case 4:
                                                search = "P.O.-Checked:";
                                                break;
                                            case 5:
                                                search = "Tech-Checked:";
                                                break;
                                            default:
                                                search = "--------";
                                                break;

                                        }

                                        searchIndex = -1;
                                        searchIndex = fileText.FindIndex(str => str.Contains(search));
                                        if (searchIndex >= 0)
                                        {
                                            newSettings[i] = fileText.ElementAt(searchIndex);
                                            newSettings[i] = newSettings[i].Substring(newSettings[i].IndexOf(":") + 2);
                                        }
                                        else
                                        {
                                            throw new IncompatibleFileVersionException();
                                        }
                                    }

                                    properImport = true;
                                }
                            }
                            else
                            {
                                throw new IncompatibleFileException();
                            }

                            sr.Close();
                        }
                        else
                        {
                            throw new IncompatibleFileException();
                        }

                        if (properImport)
                        {
                            /*
                             * Holds off changing any settings till the end in case there is a file that can be paritally
                             * read, this way there are no instances of half changed settings. Also keeps me from writting
                             * the below set twice or making another function.
                             */

                            if (newSettings[0] == "!EMPTY")
                            {
                                Settings.Default.technician = "";
                            }
                            else
                            {
                                Settings.Default.technician = newSettings[0];
                            }

                            if (newSettings[1] == "!EMPTY")
                            {
                                Settings.Default.partorder = "";
                            }
                            else
                            {
                                Settings.Default.partorder = newSettings[1];
                            }

                            Settings.Default.isChkDate = returnBool(newSettings[2]);
                            Settings.Default.isChkQR = returnBool(newSettings[3]);
                            Settings.Default.isChkInj = returnBool(newSettings[4]);
                            Settings.Default.isChkTech = returnBool(newSettings[5]);

                            Settings.Default.Save();

                            MessageBox.Show("Settings successfully imported from selected file.", "Successful Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //This should never be called, but in case it makes it this far and has not set properImport
                            throw new IncompatibleFileVersionException();
                        }
                    }
                    catch (IncompatibleFileException)
                    {
                        sr.Close();
                        MessageBox.Show("The file selected for import is either corrupt, or has been edited in some way which" +
                            "makes it incompatible for importing. Export the settings to a new clean file and try again.\n\n" +
                            "If you believe this to be shown in error, please report the issue from the report issue button" +
                            "under the help bar (or by pressing CTRL + R)", "Import Error - File Corrupt",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (IncompatibleFileVersionException)
                    {
                        MessageBox.Show(".SIC file is from an incompatible version number and cannot be imported.\n\n" +
                            "If your version of Smart-i Assist needs updated, please contact your system administrator," +
                            "the Order Fullfillment Manager, or program creator through the report issue option under" +
                            "help.", "Incompatible File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            this.Close();
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

    }
}
