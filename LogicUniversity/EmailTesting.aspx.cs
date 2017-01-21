using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

using System.Web.UI;
using System.Web.UI.WebControls;

public partial class EmailTesting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void SendEmail(object sender, EventArgs e)
    {
        using (MailMessage mm = new MailMessage(txtEmail.Text, txtTo.Text))
        {
            mm.Subject = txtSubject.Text;
            //mm.IsBodyHtml = true;
           // mailMessage.Body = "Hello <b>world!</b>";
            mm.Body = txtBody.Text;
            if (fuAttachment.HasFile)
            {
                string FileName = Path.GetFileName(fuAttachment.PostedFile.FileName);
                mm.Attachments.Add(new Attachment(fuAttachment.PostedFile.InputStream, FileName));
            }
            mm.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            //smtp.Host = "smtp.gmail.com";
            smtp.Host = "lynx.class.iss.nus.edu.sg";
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential(txtEmail.Text, txtPassword.Text);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = NetworkCred;
            //smtp.Port = 587;
            smtp.Port = 25;
            smtp.Send(mm);
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('Email sent.');", true);
        }
    }

}