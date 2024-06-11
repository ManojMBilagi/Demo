using HospitalManagementSystem.Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ViewMembers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DiseaseNameDropDown();
                getPatientsDetails();
                // Call a method to bind data to the grid
                //BindGrid();
            }

        }

        protected void DiseaseNameDropDown()
        {
            DBCalling _objDB = new DBCalling();
            DataTable dt = _objDB.GetDiseaseData("ShowDisease");
            ddldisease.DataSource = dt;
            ddldisease.DataTextField = "DiseaseName";
            ddldisease.DataValueField = "DiseaseId";
            ddldisease.DataBind();

            ddldisease.Items.Insert(0, new ListItem("--Select Disease--", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // It takes all parameters from Parameteres Class and Bind(setting and getting values in Parameters class) all
            // parameter values.
            Parameters _cParams = new Parameters();

            _cParams.Name = txtname.Text; //('name' :- id in form page)
            _cParams.EmailId = txtemail.Text;
            _cParams.PhoneNo = txtphone.Text;
            _cParams.Address = txtaddress.Text;
            _cParams.DateOfBirth = txtdob.Text;
            _cParams.Age = txtage.Text;
            _cParams.Gender = txtgender.Text;
            _cParams.DiseaseId = Convert.ToInt32(ddldisease.SelectedValue);

            DBCalling _objDB = new DBCalling();

            if (btnSubmit.Text == "Submit")
            {
                _cParams.PatientId = 0;
                _objDB.AddPatientsDetails(_cParams);

            }
            else
            {
                _cParams.PatientId = Convert.ToInt32(ViewState["PatientId"]);
                _objDB.UpdatePatientsDetails(_cParams);

            }
            PanelGrid.Visible = true;
            PanelRegister.Visible = false;
            getPatientsDetails();
        }


        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtname.Text = string.Empty;
            txtemail.Text = string.Empty;
            txtphone.Text = string.Empty;
            txtaddress.Text = string.Empty;
            txtdob.Text = string.Empty;
            txtage.Text = string.Empty;
            txtgender.Text = string.Empty;
            ddldisease.SelectedValue = "0";
        }

        protected void btnAddPatients_Click(object sender, EventArgs e)
        {
            PanelGrid.Visible = false;
            PanelRegister.Visible = true;
        }

        void FnBindGridviewColumns(DataTable dt)
        {
            try
            {
                int columnsCount = dt.Columns.Count;
                for (int i = 0; i < columnsCount; i++)
                {
                    BoundField boundField = new BoundField();
                    boundField.DataField = dt.Columns[i].ColumnName;
                    boundField.HeaderText = dt.Columns[i].ColumnName;
                    gvPat.Columns.Add(boundField);
                } 
                   // FOR EDIT LINK
                //ButtonField buttonField = new ButtonField();
                //buttonField.ButtonType = ButtonType.Link;
                //buttonField.Text = "Edit";
                ////buttonField.ImageUrl = "~/assets/images/edi.png";
                //buttonField.ControlStyle.Width = 40;
                //buttonField.CommandName = "upd";
                //gvPat.Columns.Add(buttonField);

                      // :---- FOR EDIT ICON(IMAGE)
                ButtonField buttonField = new ButtonField();
                buttonField.ButtonType = ButtonType.Image;
                //buttonField.Text = "Edit";
                buttonField.ImageUrl = "~/asset/icons8-edit-32.png";
                buttonField.ControlStyle.Width = 40;
                buttonField.CommandName = "upd";
                gvPat.Columns.Add(buttonField);

                buttonField = new ButtonField();
                buttonField.ButtonType = ButtonType.Image;
               // buttonField.Text = "delete";
                buttonField.ImageUrl = "~/asset/icons8-delete-32.png";
                buttonField.ControlStyle.Width = 40;
                buttonField.CommandName = "del";
                gvPat.Columns.Add(buttonField);
            }
            catch (Exception ex)
            {

            }
        }

        void getPatientsDetails()
        {
            DBCalling _objDB = new DBCalling();
            DataTable dt = _objDB.GetDiseaseData("getPatients");   //getPatients :- SP
            if (dt != null && dt.Rows.Count > 0)
            {
                if (gvPat.Columns.Count == 0)
                {
                    FnBindGridviewColumns(dt);
                }
                gvPat.DataSource = dt;
                gvPat.DataBind();
                ViewState["dt"] = dt;
            }
        }

        protected void gvPat_PageIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvPat_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "upd")
                {
                    PanelGrid.Visible = false;
                    PanelRegister.Visible = true;
                    btnSubmit.Text = "Update";
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    ViewState["PatientId"] = gvPat.Rows[rowIndex].Cells[0].Text.ToString();
                    txtname.Text = gvPat.Rows[rowIndex].Cells[1].Text.ToString();
                    txtemail.Text = gvPat.Rows[rowIndex].Cells[2].Text.ToString();
                    txtphone.Text = gvPat.Rows[rowIndex].Cells[3].Text.ToString();
                    txtaddress.Text = gvPat.Rows[rowIndex].Cells[4].Text.ToString();
                    txtdob.Text = gvPat.Rows[rowIndex].Cells[5].Text.ToString();
                    txtage.Text = gvPat.Rows[rowIndex].Cells[6].Text.ToString();
                    txtgender.Text = gvPat.Rows[rowIndex].Cells[7].Text.ToString();
                    ddldisease.Text = gvPat.Rows[rowIndex].Cells[8].Text.ToString();
                }
                else if (e.CommandName == "del")
                {
                    int rowIndex = int.Parse(e.CommandArgument.ToString());
                    //int CountryId = Convert.ToInt32(ddlCountry.SelectrdIndex);
                    DBCalling _objDB = new DBCalling();
                    int i = Convert.ToInt32(gvPat.Rows[rowIndex].Cells[0].Text);
                    _objDB.DeletePatients(i);

                }
                getPatientsDetails();
            }
            catch (Exception ex) { }
        }

        //protected void btnViwePatients_Click(object sender, EventArgs e)
        //{
        //    getPatientsDetails();
        //}

        protected void btnAddMembers_Click(object sender, EventArgs e)
        {
            PanelRegister.Visible = true;
            PanelGrid.Visible = false;
        }
        protected void btnDownload_Click(object sender, EventArgs e)
        {

        }

    }
}
