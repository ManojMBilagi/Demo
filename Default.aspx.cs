using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HospitalManagementSystem.Code;
using System.Net;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Xml.Linq;

namespace HospitalManagementSystem
{
    public partial class _Default : Page
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["mb"].ConnectionString);
        SqlCommand cmd;
        SqlDataAdapter da;
        DataTable dt=new DataTable ();
        DataSet ds1 = new DataSet();
        DataSet ds2 = new DataSet();

        DBCalling dB = new DBCalling(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Code.Charts cs = new Code.Charts();

                if (!IsPostBack)
                {

                    ds1 = cs.GetChartData("GetPatientValues");
                    dt = ds1.Tables[0];

                    barchart.Text = cs.BarChart(dt, 0);
                    //dt= ds1.Tables[0];
                    ////barchart.Text = cs.BarChart(dt, 1);
                    //piechart.Text = cs.PieChart(dt, 0);


                }
            } catch { }
            

        }
        
    }
}


    

