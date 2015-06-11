using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//model references for EF
using lesson5.Models;
using System.Web.ModelBinding;

namespace lesson5
{
    public partial class department : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate studetn grid
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            //populate form eith existing stuent record
            Int32 DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            //connect to db using EF
            using (comp2007Entities db = new comp2007Entities())
            {
                //populate a student instance with the StudentID from the url parameter
                Department d = (from objs in db.Departments
                             where objs.DepartmentID == DepartmentID
                             select objs).FirstOrDefault();

                //map the student properties to the form controls
                txtDepartmentName.Text = d.Name;
                txtBudget.Text = d.Budget.ToString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //use EF to connect SQL Server
            using (comp2007Entities db = new comp2007Entities())
            {

                //use the student model to save the new record
                Department d = new Department();
                Int32 DepartmentID = 0;

                //check the querystring for an id so we can determine add/update
                if (Request.QueryString.Count > 0)
                {
                    //get the id from the url
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current student from EF
                    d = (from objs in db.Departments
                         where objs.DepartmentID == DepartmentID
                         select objs).FirstOrDefault();
                }

                d.Name = txtDepartmentName.Text;
                d.Budget = Convert.ToDecimal(txtBudget.Text);

                //call add only if we have no student ID
                if (DepartmentID == 0)
                {
                    db.Departments.Add(d);
                }
                db.SaveChanges();

                //redirect to the updated students page
                Response.Redirect("departments.aspx");
            }
        }
    }
}