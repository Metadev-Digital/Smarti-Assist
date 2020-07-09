using System;
using System.Net.Mail;
using System.Windows.Forms;

/*Smart-i Assist -Mail- Version 1.0.0.5
 * Created: 6/17/2020
 * Updated: 7/9/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Metadevllc.com
 * 
 * Copyright liscence Apache Liscenece 2.0 - Enjoy boys, keep updating without me. Fork to your hearts content
 */

namespace Smarti_Assist
{
    public partial class frmMail : Form
    {
        public frmMail()
        {
            InitializeComponent();
        }

        private void frmMail_Load(object sender, EventArgs e)
        {
            txtMessage.Focus();
        }

        /// <summary>
        /// Handles the sending of messages to the proper channels through an email. Tests and makes sure that there is 
        /// actually a message to be sent, then calls a function to handle the actual sending of the emails
        /// </summary>
        /// <param name="sender">frmMail</param>
        /// <param name="e">btnSubmit</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(txtMessage.Text.Equals(""))
            {
                var selection=MessageBox.Show("Empty reports will not be sent.", "Error",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if(selection==DialogResult.OK)
                {
                    this.Close();
                }
            }
            else
            {
                sendEmail(txtMessage.Text);
                this.Close();
            }
        }

        /// <summary>
        /// Creates default mail client based  off of proper information. Attaches the message typed in the text
        /// box as the message of the email and sends it to an account monitored for trouble-shooting.
        /// 
        /// Allows retry of sending messaages based off user input in case error occurs during sending. Loops
        /// through this process until a message is successfully sent or the user says so.
        /// </summary>
        /// <param name="message">txtMessage's text sent. Already checked and verified to not be empty.</param>
        protected void sendEmail(string message)
        {
            SmtpClient mailClient = new SmtpClient();
            MailMessage toSend = new MailMessage();
            bool retryOpt = true;

            toSend.From = new MailAddress("noreplymetadevdigital@gmail.com", "No Reply");
            toSend.To.Add(new MailAddress("kevin@metadevdigital.com"));
            toSend.Subject = "Smart-i Assist Report Message";
            toSend.Body = message;
            toSend.IsBodyHtml = true;

            while(retryOpt==true)
            {
                try
                {
                    mailClient.Send(toSend);
                    retryOpt = false;
                    MessageBox.Show("Message sent successfully!", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (SmtpException)
                {
                    var selection = MessageBox.Show("An unexpected error occured while trying to send the message. Do you have an " +
                        "active internet connection, or has a firewall setting been changed for your network?", "Error",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (selection == DialogResult.Retry)
                    {
                        retryOpt = true;
                    }
                    else
                    {
                        retryOpt = false;
                    }
                }
            }

            toSend.Dispose();
        }
    }
}
