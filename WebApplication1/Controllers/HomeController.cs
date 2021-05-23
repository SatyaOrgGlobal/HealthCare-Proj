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
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult List(DateTime? From, DateTime? To, string name, int? GenderId) //this value name should be same as input control name as used in view schtml file
        {
            //for alert purpose
            if (From > To)
            {
                TempData["SelectOption"] = 1;
            }
            //for alert purpose

            string mainconn = ConfigurationManager.ConnectionStrings["dbconnection"].ConnectionString; //added connection string
            PostDetail objuser = new PostDetail();
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(mainconn))
            {
                using (SqlCommand cmd = new SqlCommand("GetDataByIdName", con)) //stored procedure name
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@status", "GET"); //Parameters for filter records
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@Fromdate", From);
                    cmd.Parameters.AddWithValue("@Todate", To);
                    cmd.Parameters.AddWithValue("@GenderId", GenderId);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                    List<PostDetail> userlist = new List<PostDetail>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        PostDetail uobj = new PostDetail();

                        uobj.PostName = ds.Tables[0].Rows[i]["PostName"].ToString(); //show records with selected columns
                        uobj.catName = ds.Tables[0].Rows[i]["catName"].ToString();
                        uobj.fromdt = Convert.ToDateTime(ds.Tables[0].Rows[i]["fromdt"]);
                        uobj.Gender = ds.Tables[0].Rows[i]["Gender"].ToString();
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

