using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace HospitalManagementSystem.Code
{
    public class DBCalling
    {
        public DBCalling()
        {

        }
        public DataTable GetDiseaseData(string query, bool isSP = true)
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
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }

            catch (Exception ex)
            {
                return null;
            }
        }

        public void AddPatientsDetails(Parameters cParams)
        {
            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["mb"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "AddPatients";  // Add Employee(Register) SP
            cmd.Connection = sql;
            cmd.CommandType = CommandType.StoredProcedure;

            // Storing the details in Database(by using details already stored in Parametes class)
            List<SqlParameter> lstPar = new List<SqlParameter>();
            //DB(SP) name    Parameters Name 
            lstPar.Add(new SqlParameter("@PatId", cParams.PatientId));
            lstPar.Add(new SqlParameter("@name", cParams.Name));
            lstPar.Add(new SqlParameter("@email", cParams.EmailId));
            lstPar.Add(new SqlParameter("@phonenumber", cParams.PhoneNo));
            lstPar.Add(new SqlParameter("@address", cParams.Address));
            lstPar.Add(new SqlParameter("@dob", cParams.DateOfBirth));
            lstPar.Add(new SqlParameter("@age", cParams.Age));
            lstPar.Add(new SqlParameter("@gender", cParams.Gender));
            lstPar.Add(new SqlParameter("@diseaseid", cParams.DiseaseId));

            foreach (SqlParameter p in lstPar)
            {
                cmd.Parameters.Add(p);
            }
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public void UpdatePatientsDetails(Parameters cParams)
        {
            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["mb"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UpdatePatientRecord";
            cmd.Connection = sql;
            cmd.CommandType = CommandType.StoredProcedure;

            // Storing the details in Database(by using details already stored in Parametes class)
            List<SqlParameter> lstPar = new List<SqlParameter>();
                                       //DB(SP) name    Parameters Name 
            lstPar.Add(new SqlParameter("@PatId", cParams.PatientId));
            lstPar.Add(new SqlParameter("@name", cParams.Name));
            lstPar.Add(new SqlParameter("@email", cParams.EmailId));
            lstPar.Add(new SqlParameter("@phonenumber", cParams.PhoneNo));
            lstPar.Add(new SqlParameter("@address", cParams.Address));
            lstPar.Add(new SqlParameter("@dob", cParams.DateOfBirth));
            lstPar.Add(new SqlParameter("@age", cParams.Age));
            lstPar.Add(new SqlParameter("@gender", cParams.Gender));
            lstPar.Add(new SqlParameter("@diseaseid", cParams.DiseaseId));

            foreach (SqlParameter p in lstPar)
            {
                cmd.Parameters.Add(p);
            }
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

        public void DeletePatients(int index)
        {
            SqlConnection sql = new SqlConnection(ConfigurationManager.ConnectionStrings["mb"].ConnectionString);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "DeletePatientRecord";
            cmd.Connection = sql;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("@Id", index));
            SqlDataAdapter adapter = new SqlDataAdapter();
            sql.Open();
            cmd.ExecuteNonQuery();
            sql.Close();
        }

    }
}