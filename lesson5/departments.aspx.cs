using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference the EF Model
using lesson5.Models;
using System.Web.ModelBinding;
namespace lesson5
{
    public partial class departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate studetn grid
            if (!IsPostBack)
            {
                GetDepartments();
            }
        }

        protected void grdDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GetDepartments()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                //querry the students table using EF and LINQ
                var Departments = from d in db.Departments
                                  select d;

                //bind the result to the gridview
                grdDepartment.DataSource = Departments.ToList();
                grdDepartment.DataBind();

            }
        }

        protected void grdDepartment_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            Int32 selectedRow = e.RowIndex;
            //get the slected StudentID using the grid's dataview collection
            Int32 departmentID = Convert.ToInt32(grdDepartment.DataKeys[selectedRow].Values["DepartmentID"]);
            //use ef to delete row
            using (comp2007Entities db = new comp2007Entities())
            {
                Department d = (from objs in db.Departments where objs.DepartmentID == departmentID select objs).FirstOrDefault();

                //do delete 
                db.Departments.Remove(d);
                db.SaveChanges();
                //redirect to the updated students page
                Response.Redirect("departments.aspx");
            }
        }
    }
}