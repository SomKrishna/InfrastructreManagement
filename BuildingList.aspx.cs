using System;
using WebServices;

namespace InfrastructureManagement
{
    public partial class BuildingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuditoriumListView.Visible = false;
            InstituteListView.Visible = false;
            HostelBuildingListView.Visible = false;
            StaffQuarterListView.Visible = false;
            if (ddlBuldingType.SelectedItem.Text == "Auditorium")
            {
                var auditoriumList = ODataServices.GetAuditoriumList();
                AuditoriumListView.DataSource = auditoriumList;
                AuditoriumListView.DataBind();
                AuditoriumListView.Visible = true;
                InstituteListView.Visible = false;
                HostelBuildingListView.Visible = false;
                StaffQuarterListView.Visible = false;
            }
            if (ddlBuldingType.SelectedItem.Text == "Institute")
            {
                var instituteBuildings = ODataServices.GetInstituteBuildings();
                InstituteListView.DataSource = instituteBuildings;
                InstituteListView.DataBind();
                InstituteListView.Visible = true;
                AuditoriumListView.Visible = false;
                HostelBuildingListView.Visible = false;
                StaffQuarterListView.Visible = false;
            }
            if (ddlBuldingType.SelectedItem.Text == "Hostel")
            {
                var hostelBuildings = ODataServices.GetHostelBuildings();
                HostelBuildingListView.DataSource = hostelBuildings;
                HostelBuildingListView.DataBind();

                AuditoriumListView.Visible = false;
                InstituteListView.Visible = false;
                StaffQuarterListView.Visible = false;
                HostelBuildingListView.Visible = true;
            }
            if (ddlBuldingType.SelectedItem.Text == "StaffQuarter")
            {
                var staffQuarters = ODataServices.GetStaffQuarters();
                StaffQuarterListView.DataSource = staffQuarters;
                StaffQuarterListView.DataBind();

                AuditoriumListView.Visible = false;
                InstituteListView.Visible = false;
                HostelBuildingListView.Visible = false;
                StaffQuarterListView.Visible = true;
            }
        }
    }
}