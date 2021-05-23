using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace WebApplication1.Controllers
{
    public class DateController : Controller
    {
        // GET: Date
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DateView(DateTime? From, DateTime? To) //this value name should be same as input control name as used in view schtml file
        {
            //for alert purpose
            if (From > To)
            {
                TempData["SelectOption"] = 1;
            }
            //for alert purpose

            string mainconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; //added connection string
            DateDetails objuser = new DateDetails();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(mainconn))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_EmployeeDetailsWithAge", con)) //stored procedure name
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "DIS"); //Parameters for filter records
                    cmd.Parameters.AddWithValue("@Fromdate", From);
                    cmd.Parameters.AddWithValue("@Todate", To);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    List<DateDetails> userlist = new List<DateDetails>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateDetails uobj = new DateDetails();

                        uobj.ApplicantName = ds.Tables[0].Rows[i]["ApplicantName"].ToString(); //show records with selected columns
                        uobj.DOB = ds.Tables[0].Rows[i]["DOB"].ToString();
                        uobj.Age = ds.Tables[0].Rows[i]["Age"].ToString();
                        uobj.DOJ = ds.Tables[0].Rows[i]["DOJ"].ToString();

                        uobj.DOL = ds.Tables[0].Rows[i]["DOL"].ToString();
                        uobj.Expr = ds.Tables[0].Rows[i]["Expr"].ToString();
                        uobj.FatherName = ds.Tables[0].Rows[i]["FatherName"].ToString();
                        uobj.MotherName = ds.Tables[0].Rows[i]["MotherName"].ToString();

                        uobj.CountryName = ds.Tables[0].Rows[i]["CountryName"].ToString();
                        uobj.StateName = ds.Tables[0].Rows[i]["StateName"].ToString();
                        uobj.Mobile = ds.Tables[0].Rows[i]["Mobile"].ToString();
                        uobj.Email = ds.Tables[0].Rows[i]["Email"].ToString();

                        userlist.Add(uobj);
                    }
                    objuser.usersinfo = userlist;
                }
                con.Close();
            }
            return View(objuser);


        }

        public ActionResult AgeCalc(DateTime? From, DateTime? To) //this value name should be same as input control name as used in view schtml file
        {
            //for alert purpose
            if (From > To)
            {
                TempData["SelectOption"] = 1;
            }
            //for alert purpose

            string mainconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; //added connection string
            DateDetails objuser = new DateDetails();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(mainconn))
            {
                using (SqlCommand cmd = new SqlCommand("Sp_AgeWithExpBetweenDates", con)) //stored procedure name
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "SHW"); //Parameters for filter records
                    cmd.Parameters.AddWithValue("@Fromdate", From);
                    cmd.Parameters.AddWithValue("@Todate", To);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    List<DateDetails> userlist = new List<DateDetails>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DateDetails uobj = new DateDetails();

                        uobj.YearRange = ds.Tables[0].Rows[i]["YearRange"].ToString(); //show records with selected columns

                        userlist.Add(uobj);
                    }
                    objuser.usersinfo = userlist;
                }
                con.Close();
            }
            return View(objuser);


        }

    }
}