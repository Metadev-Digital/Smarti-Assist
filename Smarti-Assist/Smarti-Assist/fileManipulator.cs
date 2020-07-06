using Microsoft.WindowsAPICodePack.Dialogs;
using Smarti_Assist.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Smarti_Assist
{
    class fileManipulator : IDisposable
    {
        public fileManipulator() { }

        /// <summary>
        /// Asks the user to select a .sic file to import. Checkes that file first for structural integretity, second for version compatability.
        /// 
        /// If there is a version missmatch, it tries to search through the file using a Linq expression to at least grab the data it's looking for
        /// 
        /// Failing that, throws custom errors and goes back to doin nuttin'
        /// </summary>
        public void import()
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
        }

        /// <summary>
        /// Prompts the user to choose a specific directory. Checks to see if that file already exists, if it does, asks them
        /// if they want to overwrite or choose another directory. Overwrites or changes dir where applicable. Takes the data
        /// inside of settings, exports it into a file using the writeFile function.
        /// </summary>
        public void export()
        {
            try
            {
                String dir = choseDirectory();

                if (File.Exists(dir + "/Smart-i-Config.sic"))
                {
                    var selection = MessageBox.Show("That file already exists inside of that directory, do you want to overwrite it?", "Overwrite existing file?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                    if (selection == DialogResult.Yes)
                    {
                        File.Delete(dir + "/Smart-i-Config.sic");
                        writeFile(dir);
                    }
                    else if (selection == DialogResult.No)
                    {
                        selection = MessageBox.Show("Do you want to save in another location?", "Save in another Directory?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (selection == DialogResult.Yes)
                        {
                            while (File.Exists(dir + "/Smart-i-Config.sic"))
                            {
                                dir = choseDirectory();
                            }

                            writeFile(dir);
                        }
                    }
                }
                else
                {
                    writeFile(dir);
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
        /// Uses StreamWriter to write a text file containing all of the currently saved settings, saving it as a .sic
        /// </summary>
        /// <param name="dir"></param>
        private void writeFile(string dir)
        {
            using (StreamWriter sw = new StreamWriter(dir + "/Smart-i-Config.sic", true, Encoding.UTF8))
            {
                sw.WriteLine("SIC - SMART-I ASSIST");
                sw.WriteLine(DateTime.UtcNow.ToString("MM-dd-yyyy"));
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("*****************************************");
                sw.WriteLine("*** SMART-I ASSIST EXPORTED SETTINGS  ***");
                sw.WriteLine("*** MANUAL EDITING COULD CAUSE ISSUES ***");
                sw.WriteLine("*****************************************");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("Version: " + Settings.Default.version);
                if (Settings.Default.technician == null || Settings.Default.technician == "")
                {

                    sw.WriteLine("Technician: !EMPTY");
                }
                else
                {
                    sw.WriteLine("Technician: " + Settings.Default.technician);
                }
                if (Settings.Default.partorder == null || Settings.Default.partorder == "")
                {
                    sw.WriteLine("Purchase-Order: !EMPTY");
                }
                else
                {
                    sw.WriteLine("Purchase-Order: " + Settings.Default.partorder);
                }
                sw.WriteLine("Date-Checked: " + Settings.Default.isChkDate);
                sw.WriteLine("QR-Checked: " + Settings.Default.isChkQR);
                sw.WriteLine("P.O.-Checked: " + Settings.Default.isChkInj);
                sw.WriteLine("Tech-Checked: " + Settings.Default.isChkTech);

                sw.Close();
            }

            MessageBox.Show("Your configuration file was successfully exported in your chosen directory as " +
                "'Smart-i-Config.sic'", "Export Successful", MessageBoxButtons.OK);
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
        /// Provides the user with a Windows form dialog for picking a folder to save the document to
        /// </summary>
        /// <returns>Selected folder filepath</returns>
        public string choseDirectory()
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
                    var selection = MessageBox.Show("You have not selected a file location, do you want to cancel the export?", "No Location Selected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (selection == DialogResult.Yes)
                    {
                        throw new System.InvalidOperationException();
                    }
                    else
                    {
                        while (dialog.ShowDialog() != CommonFileDialogResult.Ok)
                        {

                        }
                    }
                }
                return dialog.FileName;
            }
        }

        //IDispose Function
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
                ReleaseManagedResources();

            ReleaseUnmanagedResources();
        }

        private void ReleaseManagedResources()
        {

        }

        private void ReleaseUnmanagedResources()
        {

        }

        ~fileManipulator()
        {
            Dispose(false);
        }

    }
}
