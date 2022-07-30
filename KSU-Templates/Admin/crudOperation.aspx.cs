using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(CRUD.conStr);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillGrid();
                populateMajor();
            }
        }
        //***************************************************************

        void FillGrid()
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                string conString = CRUD.conStr;
                string sqlCmd = "Select userName,trainee,id,major,traineeMobile ,traineeEmail,universitySupervisor,universitySupervisorEmail from trainee Left JOIN major ON trainee.majorId =major.majorId ";
               // string sqlCmd = "Select trainee,id,majorId,traineeMobile ,traineeEmail,universitySupervisor,universitySupervisorEmail from trainee ";
                SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conString);
                DataSet ds = new DataSet();
                da.Fill(ds);
                gvDepartments.DataSource = ds;
                gvDepartments.DataBind();
            }
            catch
            {

            }
        }
        //***************************************************************

        protected void update(object sender, EventArgs e)
        {

            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE trainee
                     SET trainee = @trainee, id = @id, majorId = @majorId, traineeMobile = @traineeMobile, traineeEmail= @traineeEmail, universitySupervisor= @universitySupervisor, universitySupervisorEmail=@universitySupervisorEmail
                        WHERE userName = @userName ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@trainee", name.Text.ToString());
            myPara.Add("@id", idd.Text.ToString());
            myPara.Add("@majorId", ddlMajor.SelectedIndex+1);
            myPara.Add("@traineeMobile", mobile.Text.ToString());
            myPara.Add("@traineeEmail", traineeEmail.Text.ToString());
            myPara.Add("@universitySupervisor", supervisorName.Text.ToString());
            myPara.Add("@universitySupervisorEmail", supervisorEmail.Text.ToString());
            myPara.Add("@userName", userName2.Text.ToString());
            myCrud.InsertUpdateDelete(mySql, myPara);

            FillGrid();

        }
        //***************************************************************

        protected void addNewTrainee()
        {
            try
            {
                string vUser = userNameAdd.Text.ToString();
                string vPassword = password.Text.ToString();
                string vEmail = traineeEmail.Text.ToString();
                MembershipUser existingUser = null;  // second way 
                existingUser = Membership.GetUser(vUser);

                if (existingUser == null)
                {
                    if (!Membership.ValidateUser(vUser, vPassword)) // if user not valid, then create it
                    {
                        Membership.CreateUser(vUser, vPassword, vEmail);
                        addUserToRole(vUser, "student");
                        createTrainee(vUser, vEmail);                      
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Acount Created Successfully')", true);
                        FillGrid();
                    }

                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username already exists')", true);
                        userNameAddError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Username already exists')", true);
                    userNameAddError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;

                }
            }

            catch (Exception ex)
            {            
            }
            

        }
        //***************************************************************

        void addUserToRole(string user, string role)
        {
            if (!Roles.IsUserInRole(role))
                Roles.AddUserToRole(user, role);
            return;
        }
        //***************************************************************

        void createTrainee(string user, string email)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"INSERT INTO trainee(userName, traineeEmail, institutionId, trainee, majorId, traineeMobile, universitySupervisor, universitySupervisorEmail)
              VALUES (@userN, @userEmail, 1, @trainee, @majorId, @traineeMobile, @universitySupervisor, @universitySupervisorEmail)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@userN", user);
            myPara.Add("@userEmail", email);

            myPara.Add("@trainee", name.Text.ToString());
            myPara.Add("@majorId", ddlMajor.SelectedIndex+1);

            myPara.Add("@traineeMobile", mobile.Text.ToString());

            myPara.Add("@universitySupervisor", supervisorName.Text.ToString());
            myPara.Add("@universitySupervisorEmail", supervisorEmail.Text.ToString());

            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
        }
        //***************************************************************

        protected void save(object sender, EventArgs e) {

            removeError();
            if (!checkEmptyField())
            {
                if (passwordLength())
                {
                    if (checkEmailFormat(traineeEmail))
                    {
                        if (checkEmailFormat(supervisorEmail) || string.IsNullOrEmpty(supervisorEmail.Text))
                        {
                            addNewTrainee();
                        }
                        else
                        {

                            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('the format of supervisor email is wrong!!')", true);
                            supervisorEmailError.Visible = true;
                            ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
                            btnUpdate.Visible = false;
                            btnSave.Visible = true;
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('the format of trainee email is wrong!!')", true);
                        traineeEmailError.Visible = true;
                        ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
                        btnUpdate.Visible = false;
                        btnSave.Visible = true;

                    }
                }
                else {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Password length should be more than 3 !!')", true);
                    passwordError.Visible = true;
                    ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
                    btnUpdate.Visible = false;
                    btnSave.Visible = true;

                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill out the required fields !!')", true);
                ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
                btnUpdate.Visible = false;
                btnSave.Visible = true;

            }

        }
        //***************************************************************

        protected bool passwordLength() {

            bool isCorrect = true;
            if (password.Text.Trim().Length < 3) {
                isCorrect = false;
            }
            return isCorrect;
        }

        //***************************************************************

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            // this is how you access the gv values through btn > grow > then to find the control 
            // gvDepartments.BackColor = System.Drawing.Color.White; //  
           
            ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass()", true);
            btnSave.Visible = false;
            btnUpdate.Visible = true;
            clearFields();
            gvChangeColor();
            ImageButton btn = sender as ImageButton;
              GridViewRow grow = btn.NamingContainer as GridViewRow;
              name.Text = (grow.FindControl("trainee") as Label).Text;
              idd.Text = (grow.FindControl("id") as Label).Text;
            ddlMajor.SelectedIndex = Int32.Parse(getIndexMajor((grow.FindControl("major") as Label).Text.Trim().ToString()))-1;
              traineeEmail.Text = (grow.FindControl("traineeEmail") as Label).Text;
            mobile.Text = (grow.FindControl("traineeMobile") as Label).Text;
              supervisorName.Text = (grow.FindControl("universitySupervisor") as Label).Text;
              supervisorEmail.Text = (grow.FindControl("universitySupervisorEmail") as Label).Text;
            userName2.Text = (grow.FindControl("userName") as Label).Text;
            grow.BackColor = System.Drawing.Color.LightBlue; //  

        }
        //***************************************************************

        protected void btnDelete2_Click(object sender, EventArgs e)
        {

            ImageButton btn = sender as ImageButton;
            GridViewRow grow = btn.NamingContainer as GridViewRow;
            string userName = (grow.FindControl("userName") as Label).Text.ToString();

            String UserId = getUserId(userName);
            CRUD myCrud = new CRUD();
             string sqlCmd = "delete from trainee where userName = '" +userName+ "'";
             myCrud.InsertUpdateDelete(sqlCmd);
            
            CRUD myCrud2 = new CRUD();
            string sqlCmd2 = "DELETE FROM aspnet_Membership WHERE UserID = '"+UserId+"'";
            myCrud2.InsertUpdateDelete(sqlCmd2);

            CRUD myCrud3 = new CRUD();
            string sqlCmd3 = "DELETE FROM aspnet_UsersInRoles WHERE UserID = '" + UserId + "'";
            myCrud3.InsertUpdateDelete(sqlCmd3);

            CRUD myCrud4 = new CRUD();
            string sqlCmd4 = "DELETE FROM aspnet_Users WHERE UserID = '" + UserId + "'";
            myCrud4.InsertUpdateDelete(sqlCmd4);
            
            FillGrid();
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Deleted Successfully')", true);
            

        }
        //***************************************************************

        protected void populateMajor()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"SELECT  majorId, major
                          FROM major ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlMajor.DataValueField = "majorId";
            ddlMajor.DataTextField = "major";
            ddlMajor.DataSource = dr;
            ddlMajor.DataBind();
        }
        //***************************************************************

        protected String getIndexMajor(String major)
        {
            String majorResult = "0";
            CRUD myCrud = new CRUD();
            string mySql = @"select majorId from major where major = @major ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@major", major);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    majorResult = dr["majorId"].ToString();
                
                }
            }
            return majorResult;
        }
        //***************************************************************

        protected String getUserId(String userName)
        {
            String userId = null;
            CRUD myCrud = new CRUD();
            string mySql = @"select UserId from aspnet_Users where userName =@userName";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@userName", userName);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    userId = dr["UserId"].ToString();

                }
            }
            return userId;
        }
        //***************************************************************

        protected void exportToExcel(object sender, EventArgs e)
        {
            ExportGridToExcel(gvDepartments);
          
        }
        //***************************************************************

        public void ExportGridToExcel(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=TraineeExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            FillGrid();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        //***************************************************************

        protected void exportToWord(object sender, EventArgs e)
        {
            ExportGridToWord(gvDepartments);

        }
        //***************************************************************

        public void ExportGridToWord(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=TraineeWord.doc");
            Response.Charset = "";
            Response.ContentType = "application/msword";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            FillGrid();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } td { word-break:break-all;word-wrap:break-word;width:100px; text-align:center; } TABLE { font: 14px Calibri; margin: 0px; }</style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
        //***************************************************************

        protected void exportToPDF(object sender, EventArgs e)
        {
            ExportGridToPDF(gvDepartments);

        }
        //***************************************************************

        public void ExportGridToPDF(GridView grd)
        {
            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=TraineePDF.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grd.AllowPaging = true;
            grd.DataBind();
        }
        //***************************************************************

        protected void gvChangeColor()
        {
            foreach (GridViewRow row in gvDepartments.Rows)
            {
                if (row.RowIndex == gvDepartments.SelectedIndex)
                {
                    row.BackColor = System.Drawing.Color.Green;  // not applicable
                }
                else
                {
                    row.BackColor = System.Drawing.Color.White;//ColorTranslator.FromHtml("#FFFFFF");
                }
            }
        }
        //***************************************************************

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        //***************************************************************

        protected void OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvDepartments.PageIndex = e.NewPageIndex;
            this.FillGrid();
        }
        //***************************************************************

        protected void addTrainee(object sender, EventArgs e)
        {
            clearFields();
            gvChangeColor();
            ScriptManager.RegisterStartupScript(this, GetType(), "removeClass", "removeClass();removeClassFromUserNameAndPassword()", true);
            btnUpdate.Visible = false;
            btnSave.Visible = true;

        }
        //***************************************************************

        public void clearFields() {

            userNameAdd.Text = "";
            password.Text = "";
            name.Text = "";
            idd.Text = "";
            ddlMajor.SelectedIndex = 0 ;
            traineeEmail.Text = "";
            mobile.Text = "";
            supervisorName.Text = "";
            supervisorEmail.Text = "";
            userName2.Text = "";

        }

        //###############################################################################################################################
        //###############################################################################################################################

        protected void removeError()
        {
            if (!string.IsNullOrEmpty(userNameAdd.Text.Trim()))
            {
                userNameAddError.Visible = false;

            }
            if (!string.IsNullOrEmpty(password.Text.Trim()))
            {
                passwordError.Visible = false;

            }
            if (!string.IsNullOrEmpty(traineeEmail.Text.Trim()))
            {
                traineeEmailError.Visible = false;

            }                    
        }
        //***************************************************************

        protected bool checkEmptyField()
        {

            bool isEmptyExist = false;

            if (string.IsNullOrEmpty(userNameAdd.Text.Trim()))
            {
                userNameAddError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(password.Text.Trim()))
            {
                passwordError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(traineeEmail.Text.Trim()))
            {
                traineeEmailError.Visible = true;

                isEmptyExist = true;
            }
            return isEmptyExist;
        }
        //***************************************************************

        protected bool checkEmailFormat(TextBox email)
        {

            bool isEmailFormatCorrect = true;

            string email1 = email.Text;
            Regex regex = new Regex(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
            RegexOptions.CultureInvariant | RegexOptions.Singleline);
            Console.WriteLine($"The email is {email1}");
            bool isValidEmail = regex.IsMatch(email1);
            if (!isValidEmail)
            {             
                isEmailFormatCorrect = false;
            }

            return isEmailFormatCorrect;

        }


    }
}