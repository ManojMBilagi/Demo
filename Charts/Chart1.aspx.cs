using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.Charts
{
    public partial class Chart1 : System.Web.UI.Page
    {

        Code.Charts cs = new Code.Charts();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                DataSet ds = cs.GetChartData("GetPatientValues", true);

                DataTable dt = ds.Tables[0];
                barchart.Text = cs.BarChart(dt, 0);

            }

        }
    }
}