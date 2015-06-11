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
    public partial class student : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if save wasn't click AND we have a student ID in url
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                GetStudent();
            }
        }

        protected void GetStudent()
        {
            //populate form eith existing stuent record
            Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            //connect to db using EF
            using (comp2007Entities db = new comp2007Entities())
            {
                //populate a student instance with the StudentID from the url parameter
                Student s = (from objs in db.Students
                             where objs.StudentID == StudentID
                             select objs).FirstOrDefault();

                //map the student properties to the form controls
                txtLastName.Text = s.LastName;
                txtFirstName.Text = s.FirstMidName;
                txtEnrollmentDate.Text = s.EnrollmentDate.ToShortDateString();
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //use EF to connect SQL Server
            using (comp2007Entities db = new comp2007Entities())
            {

                //use the student model to save the new record
                Student s = new Student();
                Int32 StudentID = 0;

                //check the querystring for an id so we can determine add/update
                if (Request.QueryString.Count > 0)
                {
                    //get the id from the url
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //get the current student from EF
                    s = (from objs in db.Students
                         where objs.StudentID == StudentID
                         select objs).FirstOrDefault();
                }

                s.LastName = txtLastName.Text;
                s.FirstMidName = txtFirstName.Text;
                s.EnrollmentDate = Convert.ToDateTime(txtEnrollmentDate.Text);

                //call add only if we have no student ID
                if (StudentID == 0)
                {
                    db.Students.Add(s);
                }
                db.SaveChanges();

                //redirect to the updated students page
                Response.Redirect("students.aspx");
            }
        }
    }
}