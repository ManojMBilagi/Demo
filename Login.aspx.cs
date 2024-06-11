using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem.Code
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private bool IsValidCredentials(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["mb"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("ValidateCredentials", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    command.Parameters.Add("@IsValid", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    connection.Open();
                    command.ExecuteNonQuery();

                    return Convert.ToBoolean(command.Parameters["@IsValid"].Value);
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check username and password
            if (IsValidCredentials(username, password))
            {
                // Redirect to dashboard or another page
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid username or password";
            }
        }
    }
    }