using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace EmployeMVC.Models
{
    public class EmployeContext
    {
        

        
        public void InsertEmployeConnectionless(Employe e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);

            DataTable dt = new DataTable();
            dt.Columns.Add("Empid");
            dt.Columns.Add("Empname");
            dt.Columns.Add("Empemail");
            dt.Columns.Add("Empsalary");
            dt.Columns.Add("Empjob");
            dt.Columns.Add("Empdept");
            DataRow dr = dt.NewRow();
            dr["Empid"] = e.Empid;
            dr["Empname"] = e.Empname;
            dr["Empemail"] = e.Empemail;
            dr["Empsalary"] = e.Empsalary;
            dr["Empjob"] = e.Empjob;
            dr["Empdept"] = e.Empdept;
            dt.Rows.Add(dr);

            SqlCommandBuilder cb = new SqlCommandBuilder();
            cb.DataAdapter = new SqlDataAdapter("Select * from Employe", con);
            SqlDataAdapter da = cb.DataAdapter as SqlDataAdapter;
            da.Update(dt);



        }

        

        public void DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employe", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Empid"] };
            DataRow dr = dt.Rows.Find(id);
            if (dr != null)
            {
                dr.Delete();
                // dt.Rows.Remove(dr);
            }
            SqlCommandBuilder cb = new SqlCommandBuilder();
            cb.DataAdapter = new SqlDataAdapter("Select * from Employe", con);
            SqlDataAdapter da = cb.DataAdapter as SqlDataAdapter;
            int a = da.Update(dt);


        }


        public void UpdateEmployeeConnectionless(Employe e)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlDataAdapter ad = new SqlDataAdapter("select * from Employe", con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Empid"] };
            DataRow dr = dt.Rows.Find(e.Empid);
            if (dr != null)
            {
                //dr.Delete();
                // dt.Rows.Remove(dr);
                dr["Empid"] = e.Empid;
                dr["Empname"] = e.Empname;
                dr["Empemail"] = e.Empemail;
                dr["Empsalary"] = e.Empsalary;
                dr["Empjob"] = e.Empjob;
                dr["Empdept"] = e.Empdept;
            }
            SqlCommandBuilder cb = new SqlCommandBuilder();
            cb.DataAdapter = new SqlDataAdapter("Select * from Employe", con);
            SqlDataAdapter da = cb.DataAdapter as SqlDataAdapter;
            int a = da.Update(dt);


        }

        public Employe getEmployeById(int id)
        {
            //List<Employe> emplist = new List<Employe>();
            Employe e = new Employe();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlcon"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Employe where Empid="+id,con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dt.PrimaryKey = new DataColumn[] { dt.Columns["Empid"] };
            DataRow dr = dt.Rows.Find(id);
            if (dr != null)
            {
                e.Empid = Convert.ToInt32(dr["Empid"]);
                e.Empname = Convert.ToString(dr["Empname"]);
                e.Empemail = Convert.ToString(dr["Empemail"]);
                e.Empsalary = Convert.ToDouble(dr["Empsalary"]);
                e.Empjob = Convert.ToString(dr["Empjob"]);
                e.Empdept = Convert.ToString(dr["Empdept"]);
            }

            return e;
        }
    }
}
