using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace KSU_Templates.Student.Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {

                displayAttendanceInformation();
                getStudentInfo();
                checkEmptyGrideViews();
            }


        }

        //***************************************************************

        protected void submit(object sender, EventArgs e) {

            removeError();
            if (!checkEmptyField())
            {
                if (!checkAttendance(week.Value.ToString(), ddlDay.SelectedIndex.ToString()))
                {
                    saveAttendance();
                    updateTrainee();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Saved Successfully')", true);
                    // Response.Redirect(Request.RawUrl);
                    displayAttendanceInformation();
                    getStudentInfo();
                    clear();
                }
                else
                {

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('You have an attendance record same a week and day entered, please delete the previous one !!!')", true);

                }
            }
            else {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill out the required field !!')", true);
            }

        }
        //***************************************************************

        protected void displayAttendanceInformation()
        {

            string sqlCmd = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '1' ";

            string conString = CRUD.conStr;//..CRUD.DB_CONN_ST; //WebConfigurationManager.ConnectionStrings["conStrInternship"].ConnectionString;//WebConfigurationManager.ConnectionStrings["FtreeConStrlocal"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(sqlCmd, conString);
            DataTable dtUserRoles = new DataTable();
            dad.Fill(dtUserRoles);
            gvUsers.DataSource = dtUserRoles;
            gvUsers.DataBind();

            string sqlCmd2 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '2' ";

            SqlDataAdapter dad2 = new SqlDataAdapter(sqlCmd2, conString);
            DataTable dtUserRoles2 = new DataTable();
            dad2.Fill(dtUserRoles2);
            GridView2.DataSource = dtUserRoles2;
            GridView2.DataBind();

            string sqlCmd3 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '3' ";

            SqlDataAdapter dad3 = new SqlDataAdapter(sqlCmd3, conString);
            DataTable dtUserRoles3 = new DataTable();
            dad3.Fill(dtUserRoles3);
            GridView3.DataSource = dtUserRoles3;
            GridView3.DataBind();

            string sqlCmd4 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '4' ";

            SqlDataAdapter dad4 = new SqlDataAdapter(sqlCmd4, conString);
            DataTable dtUserRoles4 = new DataTable();
            dad4.Fill(dtUserRoles4);
            GridView4.DataSource = dtUserRoles4;
            GridView4.DataBind();

            string sqlCmd5 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '5' ";

            SqlDataAdapter dad5 = new SqlDataAdapter(sqlCmd5, conString);
            DataTable dtUserRoles5 = new DataTable();
            dad5.Fill(dtUserRoles5);
            GridView5.DataSource = dtUserRoles5;
            GridView5.DataBind();


            string sqlCmd6 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '6' ";

            SqlDataAdapter dad6 = new SqlDataAdapter(sqlCmd6, conString);
            DataTable dtUserRoles6 = new DataTable();
            dad6.Fill(dtUserRoles6);
            GridView6.DataSource = dtUserRoles6;
            GridView6.DataBind();

            string sqlCmd7 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '7' ";

            SqlDataAdapter dad7 = new SqlDataAdapter(sqlCmd7, conString);
            DataTable dtUserRoles7 = new DataTable();
            dad7.Fill(dtUserRoles7);
            GridView7.DataSource = dtUserRoles7;
            GridView7.DataBind();

            string sqlCmd8 = "select * from attendance INNER JOIN day ON attendance.dayId =day.dayId where userName ='" + Session["Username"] + "' and week = '8' ";

            SqlDataAdapter dad8 = new SqlDataAdapter(sqlCmd8, conString);
            DataTable dtUserRoles8 = new DataTable();
            dad8.Fill(dtUserRoles8);
            GridView8.DataSource = dtUserRoles8;
            GridView8.DataBind();
        }
        //***************************************************************

        protected void getStudentInfo()
        {
            if (Session["Username"] != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select trainee, triningStartingDate, id, institutionId, traineeSignature from trainee where userName = @userN ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userN", Session["Username"]);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String namee = dr["trainee"].ToString();
                        String startingD = dr["triningStartingDate"].ToString();
                        String id = dr["id"].ToString();
                        name.Text = namee;
                        idd.Text = id;
                        String institutionId  = dr["institutionId"].ToString();
                        institution.Value = getInstitution(institutionId);
                        if(!string.IsNullOrEmpty(startingD)) { 
                        DateTime d = DateTime.Parse(startingD);
                        startingDate.Text = d.ToString("yyyy-MM-dd");}
                        // Retrive and display traineeSignature
                        if (!Convert.IsDBNull(dr["traineeSignature"]))
                        {
                            byte[] imageData = (byte[])dr["traineeSignature"];
                            string img = Convert.ToBase64String(imageData, 0, imageData.Length);
                            oldSignature.ImageUrl = "data:image/png;base64," + img;
                            oldSignature.Visible = true;


                        }
                    }
                }
            }
        }
        //***************************************************************

        protected String getInstitution(String institutionId)
        {
            String institution = null;
            if (institutionId != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select institution from institution where institutionId = @id ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@id", institutionId);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        institution = dr["institution"].ToString();
                    }
                }
            }
                return institution;
            
        }
        //***************************************************************

        protected bool checkEmptyField() {

            bool isEmptyExist = false;

            if (string.IsNullOrEmpty(name.Text.Trim()))
            {
                nameError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(idd.Text.Trim()))
            {
                idError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(institution.Value.Trim()))
            {
                institutionError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = true;

                isEmptyExist = true;
            }
            if (week.SelectedIndex == 0)
            {
                weekError.Visible = true;

                isEmptyExist = true;
            }
            if (ddlDay.SelectedValue.Equals("Day"))
            {
                dayError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(attendanceDate.Text.Trim()))
            {
                dateError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(timeInField.Text.Trim()))
            {
                timeInError.Visible = true;

                isEmptyExist = true;
            }
            if (string.IsNullOrEmpty(timeOutField.Text.Trim()))
            {
                timeOutError.Visible = true;

                isEmptyExist = true;
            }
            /*    if (string.IsNullOrEmpty(comments.Value.Trim()))                  need to complete when adding image
                {
                    signatureError.Visible = true;

                    isEmptyExist = true;
                }*/

            return isEmptyExist;
        }

        //***************************************************************

        protected void removeError()
        {


            if (!string.IsNullOrEmpty(name.Text.Trim()))
            {
                nameError.Visible = false;

            }
            if (!string.IsNullOrEmpty(idd.Text.Trim()))
            {
                idError.Visible = false;

            }
            if (!string.IsNullOrEmpty(institution.Value.Trim()))
            {
                institutionError.Visible = false;

            }
            if (!string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = false;

            }
            if (week.SelectedIndex != 0)
            {
                weekError.Visible = false;

            }
            if (!ddlDay.SelectedValue.Equals("Day"))
            {
                dayError.Visible = false;

            }
            if (!string.IsNullOrEmpty(attendanceDate.Text.Trim()))
            {
                dateError.Visible = false;

            }
            if (!string.IsNullOrEmpty(timeInField.Text.Trim()))
            {
                timeInError.Visible = false;

            }
            if (!string.IsNullOrEmpty(timeOutField.Text.Trim()))
            {
                timeOutError.Visible = false;

            }
            /*    if (string.IsNullOrEmpty(comments.Value.Trim()))                  need to complete when adding image
                {
                    signatureError.Visible = true;

                    isEmptyExist = true;
                }*/


        }
        //***************************************************************

        protected void saveAttendance() {
           
                CRUD myCrud = new CRUD();
                string mySql = @"INSERT INTO attendance (week, dayId, date, timeIn, timeOut, comment, userName)
              VALUES (@week, @dayId , @date, @timeIn, @timeOut,  @comment, @userName)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@week", week.Value.ToString());
                myPara.Add("@dayId", ddlDay.SelectedIndex.ToString());
                myPara.Add("@date", attendanceDate.Text.ToString());
                myPara.Add("@timeIn", timeInField.Text.ToString());
                myPara.Add("@timeOut", timeOutField.Text.ToString());
                myPara.Add("@comment", comments.Value.ToString());
                myPara.Add("@userName", Session["Username"]);
                myCrud.InsertUpdateDelete(mySql, myPara);
            
        }
        //***************************************************************

        protected bool checkAttendance(String week , String day) /// check if attendance exist or not (to prevent the user from add duplicate attendance)
        {
            bool exist = false;
            if (Session["Username"] != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select * from attendance where userName = @userN and week = @week and dayId = @day";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userN", Session["Username"]);
                myPara.Add("@week", week );
                myPara.Add("@day", day);

                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    exist = true;
                }
            }

            return exist;
        }
        //***************************************************************

        protected void updateTrainee()
        {

            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE trainee
                     SET trainee = @trainee, id = @id, triningStartingDate = @strDate
                        WHERE userName = @userName ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@trainee", name.Text.ToString());
            myPara.Add("@id", idd.Text.ToString());
            myPara.Add("@strDate", startingDate.Text.ToString());
            myPara.Add("@userName", Session["Username"]);


            // Upload traineeSignature
            if (FileUpload1.HasFile)
            {
                mySql = @"UPDATE trainee
                     SET trainee = @trainee, id = @id, triningStartingDate = @strDate, traineeSignature = @traineeSignature
                        WHERE userName = @userName ";
                myPara.Add("@traineeSignature", FileUpload1.FileBytes);
            }
            else
            {
                mySql = @"UPDATE trainee
                     SET trainee = @trainee, id = @id, triningStartingDate = @strDate
                        WHERE userName = @userName ";
            }




            myCrud.InsertUpdateDelete(mySql, myPara);

        }
        //***************************************************************

        protected void deleteW1(Object sender, GridViewDeleteEventArgs e) {


                String week = gvUsers.Rows[e.RowIndex].Cells[0].Text.ToString();
                String day = gvUsers.Rows[e.RowIndex].Cells[1].Text.ToString();
                CRUD myCrud = new CRUD();
                string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
                myCrud.InsertUpdateDelete(sqlCmd);

                displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW2(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView2.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView2.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW3(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView3.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView3.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW4(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView4.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView4.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW5(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView5.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView5.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW6(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView6.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView6.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW7(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView7.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView7.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected void deleteW8(Object sender, GridViewDeleteEventArgs e)
        {


            String week = GridView8.Rows[e.RowIndex].Cells[0].Text.ToString();
            String day = GridView8.Rows[e.RowIndex].Cells[1].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from attendance where userName = '" + Session["Username"] + "' and week = '" + week + "' and dayId = " + getDayId(day) + "";
            myCrud.InsertUpdateDelete(sqlCmd);

            displayAttendanceInformation();
            checkEmptyGrideViews();


        }
        //***************************************************************

        protected int getDayId(String day)
        {
            if (day.Trim().Equals("Sunday")) { return 1; }
            if (day.Trim().Equals("Monday")) { return 2; }
            if (day.Trim().Equals("Tuesday")) { return 3; }
            if (day.Trim().Equals("Wednesday")) { return 4; }
            if (day.Trim().Equals("Thursday")) { return 5; } else { return 0; }

        }
        //***************************************************************

        protected void checkEmptyGrideViews() {

            if (gvUsers.Rows.Count == 0 && GridView2.Rows.Count == 0 && GridView3.Rows.Count == 0 && GridView4.Rows.Count == 0 && GridView5.Rows.Count == 0 && GridView6.Rows.Count == 0 && GridView7.Rows.Count == 0 && GridView8.Rows.Count == 0) {

                emptyGrideViews.Visible = true;
            }


        }

        //***************************************************************

        protected void clear()
        {
            week.SelectedIndex = 0;
            ddlDay.SelectedIndex = 0;
            attendanceDate.Text = "";
            timeInField.Text = "";
            timeOutField.Text = "";
            comments.Value = "";
        }
            /*  protected void updateIstituation()
              {
                  CRUD myCrud = new CRUD();
                  string mySql = @"UPDATE [dbo].[institution]
                    SET institution = @institution
                      WHERE institutionId = 1;";
                  Dictionary<string, object> myPara = new Dictionary<string, object>();
                  myPara.Add("@institution", institution.Value.ToString());
                  myCrud.InsertUpdateDelete(mySql, myPara);

              } */

        }
    }