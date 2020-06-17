using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

            toSend.From = new MailAddress("system@metadevdigital.com", "System");
            toSend.To.Add(new MailAddress("kevin@metadevdigital.com"));
            toSend.Subject = "Smart-i Assist Report Message";
            toSend.Body = message;
            toSend.IsBodyHtml = true;
            mailClient.Send(toSend);
            toSend.Dispose();
        }
    }
}
