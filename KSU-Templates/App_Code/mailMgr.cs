using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Drawing;
using System.IO;

/// <summary>
/// Summary description for mailMgr
/// </summary>
public class mailMgr : MailMessage
{
    // create properties
    public string myFrom { get; set; }
    public string myTo { get; set; }
    public string mySubject { get; set; }
    public bool myIsBodyHtml { get; set; }
    public string myBody { get; set; }
    public int myPortNumber { get; set; }
    public bool myEnableSSL { get; set; }
    public string myUserName { get; set; }
    public string myPassword { get; set; }
    public string myHostsmtpAddress { get; set; }
    public int myPort { get; set; }
    public NetworkCredential myCredentials { get; set; }
    public string myEnableSsl { get; set; }

     public mailMgr()
    {
        //............ Gmail SMTP
        //// constructor to initialize properties 
        myFrom = "ksu.templates@gmail.com";
        myTo = "ksu.templates@gmail.com";
        myIsBodyHtml = true;
        myBody = "myBody";
        myHostsmtpAddress = "smtp.gmail.com";
        myPortNumber = 587;
        myEnableSSL = false;
        myUserName = "ksu.templates@gmail.com";
        myPassword = "KFMC123456";
    }
 
    public  string sendEmailViaGmail() 
    {
       
        using (MailMessage m = new MailMessage(myFrom, myTo, mySubject, myBody)) // .............................1
        {
            SmtpClient sc = new SmtpClient(myHostsmtpAddress, myPortNumber); //..................................2
            try
            {
                 sc.Credentials = new System.Net.NetworkCredential(myUserName, myPassword);  //.................3
                sc.EnableSsl = true; 
                sc.Send(m);
                return "Email Send successfully";
             
            }
            catch (SmtpFailedRecipientException ex)
            {
                SmtpStatusCode statusCode = ex.StatusCode;
                if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                {   // wait 5 seconds, try a second time
                    Thread.Sleep(5000);
                    sc.Send(m);
                    return ex.Message.ToString();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                m.Dispose();
            }
        }// end using 
    }
    public string sendEmailViaGmail(FileUpload fuAttachment) 
    {
        //string visitorUserName = Page.User.Identity.Name;
        using (MailMessage m = new MailMessage(myFrom, myTo, mySubject, myBody)) // .............................1
        {
            SmtpClient sc = new SmtpClient(myHostsmtpAddress, myPortNumber); //..................................2
            try
            {
                if (fuAttachment.HasFile)
                {
                    foreach (HttpPostedFile file in fuAttachment.PostedFiles)
                    {
                        string fileName = Path.GetFileName(file.FileName);
                        m.Attachments.Add(new Attachment(file.InputStream, fileName));
                    }
                }
                sc.Credentials = new System.Net.NetworkCredential(myUserName, myPassword);  //.................3
                sc.EnableSsl = true;
                sc.Send(m);
                return "Email Send successfully";
            }
            catch (SmtpFailedRecipientException ex)
            {
                SmtpStatusCode statusCode = ex.StatusCode;
                if (statusCode == SmtpStatusCode.MailboxBusy || statusCode == SmtpStatusCode.MailboxUnavailable || statusCode == SmtpStatusCode.TransactionFailed)
                {   // wait 5 seconds, try a second time
                    Thread.Sleep(5000);
                    sc.Send(m);
                    return ex.Message.ToString();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            finally
            {
                m.Dispose();
            }
        }// end using 
    }
   
}

