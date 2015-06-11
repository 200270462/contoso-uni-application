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
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // if loading the page for the first time, populate studetn grid
            if (!IsPostBack)
            {
                GetStudents();
            }
        }

        protected void GetStudents()
        {
            using (comp2007Entities db = new comp2007Entities())
            {
                //querry the students table using EF and LINQ
                var Students = from s in db.Students
                               select s;

                //bind the result to the gridview
                grdStudent.DataSource = Students.ToList();
                grdStudent.DataBind();

            }
        }

        protected void grdStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            Int32 selectedRow = e.RowIndex;
            //get the slected StudentID using the grid's dataview collection
            Int32 studentID = Convert.ToInt32(grdStudent.DataKeys[selectedRow].Values["StudentID"]);
            //use ef to delete row
            using (comp2007Entities db = new comp2007Entities())
            {
                Student s = (from objs in db.Students where objs.StudentID == studentID select objs).FirstOrDefault();

                //do delete 
                db.Students.Remove(s);
                db.SaveChanges();
                //redirect to the updated students page
                Response.Redirect("students.aspx");
            }
        }

        protected void grdStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}