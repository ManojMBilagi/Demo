using HospitalManagementSystem.Charts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Code
{
    public class Charts
    {

        DataSet ds = new DataSet();

        public Charts()
        {

        }

        public DataSet GetChartData(string query, bool isSP = true)
        {
            try
            {
                SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["mb"].ConnectionString);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.Connection = sql;
                if (isSP)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                }
                else
                {
                    cmd.CommandType = CommandType.Text;
                }
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                return ds;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public string BarChart(DataTable dt, int count)
        {
            // throw new NotImplementedException();
            string Value1 = "";
            string Value2 = "";
            string Chartmain = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    Value1 += ",";
                    Value2 += ",";
                }
                Value1 += "'" + dt.Rows[i][0].ToString() + "'";
                Value2 += "'" + dt.Rows[i][1].ToString() + "'";
            }
            // use type:pie(pie chart),line(line chart)
            Chartmain = "<canvas id=\"barchart" + count + "\" style=\"width:100%;max-width:600px\"></canvas>\r\n\r\n<script>\r\n const xValues = [" + Value1 + "];\r\n const yValues = [" + Value2 + "];\r\nconst barColors = [\"red\", \"green\",\"blue\",\"orange\",\"brown\"];\r\n\r\nnew Chart(\"barchart" + count + "\", {\r\n  type: \"bar\",\r\n  data: {\r\n    labels: xValues,\r\n    datasets: [{\r\n      backgroundColor: barColors,\r\n      data: yValues\r\n    }]\r\n  },\r\n  options: {\r\n    legend: {display: false},\r\n    title: {\r\n      display: true,\r\n      text: \"Patients Table\"\r\n    }\r\n  }\r\n});\r\n</script>";
            return Chartmain;

        }

        public string PieChart(DataTable dt, int count)
        {
            // throw new NotImplementedException();
            string Value1 = "";
            string Value2 = "";
            string Chartmain = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    Value1 += ",";
                    Value2 += ",";
                }
                Value1 += "'" + dt.Rows[i][0].ToString() + "'";
                Value2 += "'" + dt.Rows[i][1].ToString() + "'";
            }
            // use type:pie(pie chart),line(line chart)
            Chartmain = "<canvas id=\"piechart" + count +"\" style =\"width:100%;max-width:600px\"></canvas>\r\n\r\n<script>\r\nvar xValues = ["+ Value1 + "];\r\nvar yValues = [" + Value2 + "];\r\nvar barColors = [\r\n  \"#b91d47\",\r\n  \"#00aba9\",\r\n  \"#2b5797\",\r\n  \"#e8c3b9\",\r\n  \"#1e7145\"\r\n];\r\n\r\nnew Chart(\"piechart"+count+"\", {\r\n  type: \"pie\",\r\n  data: {\r\n    labels: xValues,\r\n    datasets: [{\r\n      backgroundColor: barColors,\r\n      data: yValues\r\n    }]\r\n  },\r\n  options: {\r\n    title: {\r\n      display: true,\r\n      text: \"World Wide Wine Production 2018\"\r\n    }\r\n  }\r\n});\r\n</script>\r\n";

            return Chartmain;

        }

        public string LineChart(DataTable dt, int count)
        {
            // throw new NotImplementedException();
            string Value1 = "";
            string Value2 = "";
            string Chartmain = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i > 0)
                {
                    Value1 += ",";
                    Value2 += ",";
                }
                Value1 += "'" + dt.Rows[i][0].ToString() + "'";
                Value2 += "'" + dt.Rows[i][1].ToString() + "'";
            }
            // use type:pie(pie chart),line(line chart)
            Chartmain = "<canvas id=\"linechart" + count + "\" style=\"width:100%;max-width:600px\"></canvas>\r\n\r\n<script>\r\n const xValues = [" + Value1 + "];\r\n const yValues = [" + Value2 + "];\r\nconst barColors = [\"red\", \"green\",\"blue\",\"orange\",\"brown\"];\r\n\r\nnew Chart(\"linechart" + count + "\", {\r\n  type: \"line\",\r\n  data: {\r\n    labels: xValues,\r\n    datasets: [{\r\n      backgroundColor: barColors,\r\n      data: yValues\r\n    }]\r\n  },\r\n  options: {\r\n    legend: {display: false},\r\n    title: {\r\n      display: true,\r\n      text: \"Patients Table\"\r\n    }\r\n  }\r\n});\r\n</script>";
            return Chartmain;

        }
    }
}