using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Smart-i Assist -Mail- Version 0.6
 * Created: 6/17/2020
 * Updated: 6/17/2020
 * Designed by: Kevin Sherman at Acrelec America
 * Contact at: Kevin@Meteadevllc.com
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

        }

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
            }
        }

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
                catch (SmtpException e)
                {
                    var selection = MessageBox.Show("An unexpected error occured while trying to send the message. Do you have an " +
                        "active internet connection, or has a firewall setting been changed for your network?", "Error",
                        MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                    if (selection == DialogResult.Retry)
                    {
                        retryOpt = true;
                    }
                }
            }

            toSend.Dispose();


            //TODO: Finish testing and polishing the mail send function, as well as comment frmMail.
        }
    }
}
