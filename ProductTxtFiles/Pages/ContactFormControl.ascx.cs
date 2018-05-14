using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.IO;

public partial class Pages_WebUserControl : System.Web.UI.UserControl
{
    MailMessage message = new MailMessage();
    FileUpload file = new FileUpload();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // Attaches file to message
    public void AttachFile()
    {
        if (FileUploadAttch.HasFile)
        {
            try
            {
                string file = Path.GetFileName(FileUploadAttch.FileName);
                UploadStatus.Text = "File successfully attached";
                message.Attachments.Add(new Attachment(FileUploadAttch.FileContent, file));
            }

            catch (Exception ex)
            {
                UploadStatus.Text = "File failed to upload. Error: " + ex.Message;
            }
        }
    }

    public void CreateEmail()
    {
        try
        {
            AttachFile();

            if (Page.IsValid)
            {
                message.Subject = "User Inquiry";
                message.Body = "Name: " + FNameBox.Text + " " + LNameBox.Text + "\n";
                message.Body += "Phone Number: " + PhoneBox.Text + "\n";
                message.Body += "Email Address: " + EmailBox.Text + "\n";
                message.Body += "Comment: " + CommentBox.Value;
                message.From = new MailAddress("amm7152@psu.edu", "New User Inquiry", System.Text.Encoding.UTF8);
            }
        }
        catch (Exception ex)
        {

        }

        message.To.Add("webinquiriesamm@gmail.com");

        if (SendMeChkBox.Checked)
        {
            try
            {
                message.To.Add(EmailBox.Text);
                MailMessage messagecopy = new MailMessage();
                messagecopy.Subject = "User Inquiry";
                messagecopy.Body = message.Body;
                message.From = new MailAddress("amm7152@psu.edu", "New User Inquiry", System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {

            }
        }
    }

    public void SendEmail()
    {
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("webinquiriesamm@gmail.com", "inquiriespw");
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;

        try
        {
            client.Send(message);
            ClearForm();
        }
        catch (Exception ex)
        {

        }
    }

    public void SubmitBttn_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            CreateEmail();
            SendEmail();
        }
    }

    public void ClearForm()
    {
        foreach (Control control in Page.Controls)
        {
            if (control is TextBox)
            {
                TextBox txt = (TextBox)control;
                txt.Text = "";
            }
        }
        SuccessLabel.Text = "Message has been sent! We'll get back to you shortly.";
    }

    public void CommentBox_ServerValidate(object sender, ServerValidateEventArgs a)
    {
        if (a.Value.Contains("www") || a.Value.Contains(".com"))
        {
            a.IsValid = false;
        }
        else
        {
            a.IsValid = true;
        }
    }

    // Checks if email address contains .com or .edu
    public void Email_ServerValidate(object sender, ServerValidateEventArgs a)
    {
        if (a.Value.Contains(".com") || a.Value.Contains(".edu"))
        {
            a.IsValid = true;
        }
        else
        {
            a.IsValid = false;
        }
    }

    public void NotEmpty_ServerValidate(object sender, ServerValidateEventArgs e)
    {
        if (e.Value.Length > 0)
        {
            e.IsValid = true;
        }
        else
        {
            e.IsValid = false;
        }
    }
}