using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace InfrastructureManagement
{
    public partial class UpdateBuildings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            ddlBuildings.SelectedValue = ddlBuildings.SelectedValue;

            if (ddlBuildings.SelectedValue == "IndustrialBuldings")
            {
                var data = ODataServices.GetInstituteBuilding(txtSearch.Text);
                if (data != null && !string.IsNullOrEmpty(data.Block_Code))
                {
                    btnEdit.Visible = true;
                }
            }
            else if (ddlBuildings.SelectedValue == "HostelBuildings")
            {
                var data = ODataServices.GetHostelBuilding(txtSearch.Text);
                if (data != null && !string.IsNullOrEmpty(data.Block_Code))
                {
                    btnEdit.Visible = true;
                }
            }
            else if (ddlBuildings.SelectedValue == "StaffQuarters")
            {
                var data = ODataServices.GetStaffQuarter(txtSearch.Text);
                if (data != null && !string.IsNullOrEmpty(data.Quarter_Code))
                {
                    btnEdit.Visible = true;
                }
            }
            else
            {
                var data = ODataServices.GetAuditorium(txtSearch.Text);
                if (data != null && !string.IsNullOrEmpty(data.Building_Code))
                {
                    btnEdit.Visible = true;
                }
            }
            if (!btnEdit.Visible)
            {
                LblMessage.Text = "No record found. Please try with valid Building No.";
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            if (ddlBuildings.SelectedValue == "IndustrialBuldings")
            {
                Response.Redirect("UpdateInstituteBuilding.aspx?BlockCode=" + txtSearch.Text);
            }
            else if (ddlBuildings.SelectedValue == "HostelBuildings")
            {
                Response.Redirect("UpdateHostelBuilding.aspx?BlockCode=" + txtSearch.Text);
            }
            else if (ddlBuildings.SelectedValue == "StaffQuarters")
            {
                Response.Redirect("UpdateStaffQuarter.aspx?QuarterCode=" + txtSearch.Text);
            }
            else
            {
                Response.Redirect("UpdateAuditorium.aspx?BuildingCode=" + txtSearch.Text);
            }
        }
    }
}