using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.Login_and_Register
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //***************************************************************

        protected void submit(object sender, EventArgs e)
        {

            removeErrorMsg();
            if (!checkEmptyFielh())
            {
                logIn();
            }


        }

        //***************************************************************

        protected bool checkEmptyFielh()
        {

            bool isEmptyExist = false;

            if (string.IsNullOrEmpty(userName.Text.Trim()))
            {
                userError.Attributes["data-validate"] = "Enter username";

                userError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmptyExist = true;

            }
          
            if (string.IsNullOrEmpty(password.Text))
            {
                passwordError.Attributes["data-validate"] = "Enter password";

                passwordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmptyExist = true;

            }
            

            return isEmptyExist;

        }



        //***************************************************************


        protected void removeErrorMsg()
        {

            userError.Attributes["class"].ToString().Replace("alert-validate", "");
            if (!string.IsNullOrEmpty(userName.Text))
            {
                userError.Attributes.Add("class", userError.Attributes["class"].ToString().Replace("alert-validate", ""));

            }
          
            if (!string.IsNullOrEmpty(password.Text))
            {

                passwordError.Attributes.Add("class", passwordError.Attributes["class"].ToString().Replace("alert-validate", ""));

            }
          
        }

       
        //***************************************************************
        protected void logIn()
        {
            Session["Username"] = userName.Text;
            bool blnAuthenticate = AuthenticateUser(); //Authenticate(dicObjformValues);
            if (blnAuthenticate)
            {
                FormsAuthentication.RedirectFromLoginPage(userName.Text, false);
                if (Roles.IsUserInRole(userName.Text.ToString(), "admin"))
                {
                    Response.Redirect("/Admin/AdminHomePage");

                }
                else {
                    Response.Redirect("/Student/HomePage");
                }
                // email admin when a user logged in the site
                DateTime myDate = DateTime.Now;
            }
            else
            {
                // this is important 
                 ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Your login was invalid, Please try again')", true);

                //  lblOutput.Text = "Your login was invalid, Please try again";
                //   Response.Redirect("~\\Account\\stop.aspx");
            }
        }

        //***************************************************************

        protected bool AuthenticateUser()
        {
            string userNamee = userName.Text;
            string passwordd = password.Text;
            bool userFound = false;
            try
            {
                userFound = Membership.ValidateUser(userNamee, passwordd);
                //   lblOutput.Text = Session["Username"].ToString();
            }
            catch (Exception ex)
            {
                // lblOutput.Text = "Please take image snapshot and email it to aalhussein@yahoo.com " + ex.Message.ToString();
            }
            return userFound;
        }
    }
}