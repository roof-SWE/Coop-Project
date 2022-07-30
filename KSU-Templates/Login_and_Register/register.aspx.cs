using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace KSU_Templates.Login_and_Register
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {





        }

        //***************************************************************
        protected void submit(object sender, EventArgs e)
        {

            removeErrorMsg();
            if (!checkEmptyFieldAndPasswordLength())
            {
                createUserAccount();
            }


        }


        //***************************************************************



        protected void createUserAccount()
        {

            try
            {
                string vUser = userName.Text.ToString();
                string vPassword = password.Text.ToString();
                string vEmail = email.Text.ToString();
                MembershipUser existingUser = null;  // second way 
                existingUser = Membership.GetUser(vUser);

                if (existingUser == null)
                {
                    if (!Membership.ValidateUser(vUser, vPassword)) // if user not valid, then create it
                    {
                        Session["Username"] = userName.Text;
                        Membership.CreateUser(vUser, vPassword, vEmail);
                        addUserToRole(vUser, "student");
                        createTrainee(vUser, vEmail);
                        FormsAuthentication.RedirectFromLoginPage(userName.Text, false);
                        //  postMsg("User Created Successfuly");
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Acount Created Successfully')", true);
                        Response.Redirect("/Student/HomePage");

                    }

                    else
                    {
                        //  postMsg("User already exists!!");
                        userError.Attributes["data-validate"] = "Username already exists";

                        userError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");
                        return;
                    }
                    // populateCheckBoxListRolesUsers();
                }
                else
                {
                    userError.Attributes["data-validate"] = "Username already exists";

                    userError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                }
            }

            catch (Exception ex)
            {
                // postMsg(ex.Message.ToString());  // to do , log the errors  rtn
                // postMsgClient(ex.Message);

                // ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Inserted Successfully')", true);

            }

        }

        //***************************************************************

        protected bool checkEmptyFieldAndPasswordLength()
        {

            bool isEmptyExist = false;

            if (string.IsNullOrEmpty(userName.Text.Trim()))
            {
                userError.Attributes["data-validate"] = "Enter username";

                userError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmptyExist = true;

            }
            if (string.IsNullOrEmpty(email.Text.Trim()))
            {

                emailError.Attributes["data-validate"] = "Enter email";


                emailError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmptyExist = true;

            }
            else
            {

                if (!checkEmailFormat())
                {

                    isEmptyExist = true;

                }

            }
            if (string.IsNullOrEmpty(password.Text))
            {
                passwordError.Attributes["data-validate"] = "Enter password";

                passwordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmptyExist = true;

            }
            else
            {

                if (string.IsNullOrEmpty(password.Text.Trim()))
                {

                    passwordError.Attributes["data-validate"] = "White space not valid";


                    passwordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                    isEmptyExist = true;

                }
                else
                {

                    if (password.Text.Trim().Length < 3)
                    {

                        passwordError.Attributes["data-validate"] = "Password must be more than 3 ";


                        passwordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                        isEmptyExist = true;

                    }

                }
            }



            if (string.IsNullOrEmpty(confirmPassword.Text))
            {
                confirmPasswordError.Attributes["data-validate"] = "Enter confirm password";


                confirmPasswordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmptyExist = true;

            }
            else
            {

                if (string.IsNullOrEmpty(confirmPassword.Text.Trim()))
                {

                    confirmPasswordError.Attributes["data-validate"] = "White space not valid";


                    confirmPasswordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                    isEmptyExist = true;


                }
                else
                {

                    if (!confirmPassword.Text.Trim().Equals(password.Text.Trim()))
                    {

                        confirmPasswordError.Attributes["data-validate"] = "Confirm password does not match the password";


                        confirmPasswordError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                        isEmptyExist = true;


                    }
                }

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
            if (!string.IsNullOrEmpty(email.Text) && checkEmailFormat())
            {

                emailError.Attributes.Add("class", emailError.Attributes["class"].ToString().Replace("alert-validate", ""));

            }
            if (!string.IsNullOrEmpty(password.Text))
            {

                passwordError.Attributes.Add("class", passwordError.Attributes["class"].ToString().Replace("alert-validate", ""));

            }
            if (!string.IsNullOrEmpty(confirmPassword.Text))
            {

                confirmPasswordError.Attributes.Add("class", confirmPasswordError.Attributes["class"].ToString().Replace("alert-validate", ""));
            }
        }

        //***************************************************************

        protected bool checkEmailFormat()
        {

            bool isEmailFormatCorrect = true;

            string email1 = email.Text;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            Console.WriteLine($"The email is {email1}");
            bool isValidEmail = regex.IsMatch(email1);
            if (!isValidEmail)
            {
                emailError.Attributes["data-validate"] = "Wrong email format";

                emailError.Attributes.Add("class", "wrap-input100 validate-input alert-validate");

                isEmailFormatCorrect = false;
            }

            return isEmailFormatCorrect;

        }
        //***************************************************************

        void addUserToRole(string user, string role)
        {
            if (!Roles.IsUserInRole(role))
                Roles.AddUserToRole(user, role);
            return;
        }
        void createTrainee(string user, string email) {
            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO trainee(userName, traineeEmail, institutionId)
              VALUES (@userN, @userEmail, 1)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@userN", user);
            myPara.Add("@userEmail", email);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
        }
    }
}