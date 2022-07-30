
using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates.Templates
{
    public partial class FollowUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)  // means do it only once for each user session
            {
                populateWeekComb();
                getStudentInfo();
                displayFollowUpInformation();
            }

        }
        //***************************************************************
        protected void populateWeekComb()
        {
            CRUD myCrud = new CRUD();
            string mysql = "select weekId, week from week";
            SqlDataReader dr = myCrud.getDrPassSql(mysql);
            ddlWeek.DataValueField = "weekId";
            ddlWeek.DataTextField = "weekId";

            ddlWeek.DataSource = dr;
            ddlWeek.DataBind();
            ddlWeek.Items.Insert(0, new ListItem("Select", "0"));
        }
        //***************************************************************
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            removeError();
            if (isEmptyFields())
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please fill out the required fields!!')", true);
            }
            else
            {
                if ("Submit".Equals(btnSubmit.Text))
                {
                    submitInformation();
                    updateTrainee();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('week"+ddlWeek.SelectedIndex+ " tasks submitted successfully!!')", true);
                    getStudentInfo();
                    displayFollowUpInformation();
                }
                else
                {
                    updateTasks();
                    updateTrainee();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('week" + ddlWeek.SelectedIndex + " tasks updated successfully!!')", true);
                    getStudentInfo();
                    displayFollowUpInformation();
                }
              

            }
        }
        //***************************************************************
        protected void updateTasks()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"UPDATE followup
                     SET task1 = @task1, task2 = @task2, task3 = @task3, task4 = @task4
                        WHERE userName = @userName and weekId = @weekId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@userName", Session["Username"]);
            myPara.Add("@weekId", int.Parse(ddlWeek.SelectedIndex.ToString()));
            myPara.Add("@task1", task1.Text.Trim());
            myPara.Add("@task2", task2.Text.Trim());
            myPara.Add("@task3", task3.Text.Trim());
            myPara.Add("@task4", task4.Text.Trim());
            myCrud.InsertUpdateDelete(mySql, myPara);
        }
        //***************************************************************
        protected void submitInformation()
        {
            CRUD myCrud = new CRUD();
                string mySql = @"INSERT INTO followup (userName,weekId,task1,task2,task3,task4)
                    VALUES (@userName, @weekId,@task1,@task2,@task3,@task4)";

            Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userName", Session["Username"]);
                myPara.Add("@weekId", int.Parse(ddlWeek.SelectedIndex.ToString()));
                myPara.Add("@task1", task1.Text.Trim());
                myPara.Add("@task2", task2.Text.Trim());
                myPara.Add("@task3", task3.Text.Trim());
                myPara.Add("@task4", task4.Text.Trim());
                
                myCrud.InsertUpdateDelete(mySql, myPara);
                btnSubmit.Text = "Update";

        }
    
        //***************************************************************
        protected void updateTrainee()
            {
                CRUD myCrud = new CRUD();
                string mySql = "sql command";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@name", txtName.Text.ToString());
                myPara.Add("@id", txtId.Text.ToString());
                myPara.Add("@strDate", startingDate.Text.ToString());
                myPara.Add("@userName", Session["Username"]);

                // Upload traineeSignature
                if (FileUpload1.HasFile)
                {
                 mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, triningStartingDate = @strDate, traineeSignature = @traineeSignature
                        WHERE userName = @userName ";
                myPara.Add("@traineeSignature", FileUpload1.FileBytes);
                }
               else
               {
                 mySql = @"UPDATE trainee
                     SET trainee = @name, id = @id, triningStartingDate = @strDate
                        WHERE userName = @userName ";
               }

                myCrud.InsertUpdateDelete(mySql, myPara);

        }
        //***************************************************************
        protected void getStudentInfo()
        {
            if (Session["Username"] != null)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select trainee, triningStartingDate, id, institutionId,traineeSignature from trainee where userName = @userName ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@userName", Session["Username"]);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        String namee = dr["trainee"].ToString();
                        String startingD = dr["triningStartingDate"].ToString();
                        String id = dr["id"].ToString();
                        txtName.Text = namee;
                        txtId.Text = id;
                        String institutionId = dr["institutionId"].ToString();
                        txtInstitution.Value = getInstitution(institutionId);

                        if (!string.IsNullOrEmpty(startingD))
                        {
                            DateTime d = DateTime.Parse(startingD);
                            startingDate.Text = d.ToString("yyyy-MM-dd");
                        }

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
        protected void removeError()
        {

            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                nameError.Visible = false;

            }
            if (!string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                idError.Visible = false;

            }
            if (!string.IsNullOrEmpty(txtInstitution.Value.Trim()))
            {
                institutionError.Visible = false;

            }
            if (!string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = false;

            }
            if (ddlWeek.SelectedIndex != 0)
            {
                weekError.Visible = false;

            }
           
            if (!string.IsNullOrEmpty(task1.Text.Trim()))
            {
                task1Error.Visible = false;

            }

        }
        //***************************************************************

        protected bool isEmptyFields()
        {

            bool isEmpty = false;

            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                nameError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(txtId.Text.Trim()))
            {
                idError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(txtInstitution.Value.Trim()))
            {
                institutionError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(startingDate.Text.Trim()))
            {
                startDateError.Visible = true;

                isEmpty = true;
            }
            if (ddlWeek.SelectedIndex == 0)
            {
                weekError.Visible = true;

                isEmpty = true;
            }
            if (string.IsNullOrEmpty(task1.Text.Trim()))
            {
                task1Error.Visible = true;

                isEmpty = true;
            }

            return isEmpty;
        }

        protected void ddlWeek_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            //Retrive tasks based on week number
            if (ddlWeek.SelectedIndex != 0)
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select task1, task2, task3, task4 from followup where userName = @username and weekId = @weekId";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@username", Session["Username"]);
                myPara.Add("@weekId", ddlWeek.SelectedIndex);
                SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        task1.Text = dr["task1"].ToString();
                        task2.Text = dr["task2"].ToString();
                        task3.Text = dr["task3"].ToString();
                        task4.Text = dr["task4"].ToString();

                    }
                    btnSubmit.Text = "Update";
                }
                else
                {
                    emptyTasks();
                    btnSubmit.Text = "Submit";
                }
            }
            else
            {
                emptyTasks();
                btnSubmit.Text = "Submit";
            }

            displayFollowUpInformation();

        }



        //***************************************************************
        protected void emptyTasks()
        {
            task1.Text = string.Empty;
            task2.Text = string.Empty;
            task3.Text = string.Empty;
            task4.Text = string.Empty;
        }

        //***************************************************************

        protected void displayFollowUpInformation()
        {

            string sqlCmd = "select * from followup where userName ='" + Session["Username"]+"'";

            string conString = CRUD.conStr;//..CRUD.DB_CONN_ST; //WebConfigurationManager.ConnectionStrings["conStrInternship"].ConnectionString;//WebConfigurationManager.ConnectionStrings["FtreeConStrlocal"].ConnectionString;
            SqlDataAdapter dad = new SqlDataAdapter(sqlCmd, conString);
            DataTable dtUserRoles = new DataTable();
            dad.Fill(dtUserRoles);
            gvUsers.DataSource = dtUserRoles;
            gvUsers.DataBind();
        }
        //***************************************************************
        protected void deleteWeek(Object sender, GridViewDeleteEventArgs e)
        {


            String week = gvUsers.Rows[e.RowIndex].Cells[0].Text.ToString();
            CRUD myCrud = new CRUD();
            string sqlCmd = "delete from followup where userName = '" + Session["Username"] + "' and weekId =" + week;
            myCrud.InsertUpdateDelete(sqlCmd);

            displayFollowUpInformation();
            checkEmptyGrideViews();


        }

        protected void checkEmptyGrideViews()
        {

            if (gvUsers.Rows.Count == 0)
            {

                emptyGrideViews.Visible = true;
            }


        }

    }
}