using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates
{
    public partial class Contact : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //***************************************************************
        protected void btnSend_Click(object sender, EventArgs e)
        {
            removeError();
            if (isEmptyFields())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill out the required fields!!')", true);
            }
            else
            {
                sendEmail();
            }
        }
        //***************************************************************
        protected void sendEmail()
        {
            string senderName = "";
            if (Session["Username"] != null)
            {
                 senderName = Session["Username"].ToString();
            }

            string rtn = "";

  
            string senderEmail = txtFrom.Value;
            using (mailMgr myMailMgr = new mailMgr())
            {
                
                myMailMgr.mySubject = txtSubject.Value + " " + senderEmail + ": " + senderName;
                myMailMgr.myBody = txtMessage.Text;
                if (FileUpload1.HasFile)
                {
                    foreach (HttpPostedFile file in FileUpload1.PostedFiles)
                    {
                        //1. get fileName
                        string fileName = Path.GetFileName(file.FileName);

                        //3. to attached files to email 
                        myMailMgr.Attachments.Add(new Attachment(file.InputStream, fileName)); // to attached files to email 
                    }
                    rtn = myMailMgr.sendEmailViaGmail(FileUpload1);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('"+rtn+"')", true);
                    emptyFields();
                }
                else
                {
                    rtn = myMailMgr.sendEmailViaGmail();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('" + rtn + "')", true);
                    emptyFields();
                }
                


            }
        }
        //***************************************************************
        protected void removeError()
        {

            if (!string.IsNullOrEmpty(txtFrom.Value.Trim()))
            {
                fromError.Visible = false;

            }
            if (!string.IsNullOrEmpty(txtSubject.Value.Trim()))
            {
                subjectError.Visible = false;

            }
            if (!string.IsNullOrEmpty(txtMessage.Text.Trim()))
            {
                messageError.Visible = false;

            }
           

        }
        //***************************************************************
        protected bool isEmptyFields()
        {

            bool isEmpty = false;

            if (string.IsNullOrEmpty(txtFrom.Value.Trim()))
            {
                fromError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(txtSubject.Value.Trim()))
            {
                subjectError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(txtMessage.Text.Trim()))
            {
                messageError.Visible = true;

                isEmpty = true;
            }

            return isEmpty;
        }
        //***************************************************************
        protected void emptyFields()
        {
            txtFrom.Value = string.Empty;
            txtSubject.Value = string.Empty;
            txtMessage.Text = string.Empty;
        }
    }
}