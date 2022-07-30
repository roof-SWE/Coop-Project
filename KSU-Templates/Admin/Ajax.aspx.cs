using KSU_Templates.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KSU_Templates
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)

            {

                this.DDLAjax.Items.Add("IT");

                this.DDLAjax.Items.Add("CS");

                this.DDLAjax.Items.Add("SWE");

                this.DDLAjax.Items.Add("IS");


            }



        }

        protected void Button1_Click(object sender, EventArgs e)

        {

          
            SqlCommand cmd = new SqlCommand();
            string conString = CRUD.conStr;
            string sqlCmd = null;
            if (this.DDLAjax.SelectedItem.Text == "IT")

            {

                 sqlCmd = "Select userName from trainee where majorId = 1";


            }

            if (this.DDLAjax.SelectedItem.Text == "CS")

            {

                sqlCmd = "Select userName from trainee where majorId = 2";

            }

            if (this.DDLAjax.SelectedItem.Text == "SWE")

            {

                sqlCmd = "Select userName from trainee where majorId = 3";

            }

            if (this.DDLAjax.SelectedItem.Text == "IS")

            {

                sqlCmd = "Select userName from trainee where majorId = 4";

            }

            SqlDataAdapter da = new SqlDataAdapter(sqlCmd, conString);
            DataSet ds = new DataSet();
            da.Fill(ds);

            this.GridView1.DataSource = ds;

            this.GridView1.DataBind();

        }

    }
}