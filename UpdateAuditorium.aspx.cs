using InfrastructureManagement.Common;
using System;
using WebServices;

namespace InfrastructureManagement
{
    public partial class UpdateAuditorium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string buildingCode = Request.QueryString["BuildingCode"];
                var data = ODataServices.GetAuditorium(buildingCode);
                if (data != null && !string.IsNullOrWhiteSpace(buildingCode))
                {
                    lblAuditoriumBuildingCode.Text = data.Building_Code;
                    txtBuildingName.Text = data.Building_Name;
                    txtAudiSittingCapacity.Text = Convert.ToString(data.Total_Capacity);
                    txtAudiTotalAreaOfFloor.Text = Convert.ToString(data.Total_Floor_Area_in_sqft);
                    txtAudiTotalLength.Text = Convert.ToString(data.Building_Length);
                    txtAudiTotalBreath.Text = Convert.ToString(data.Building_Breadth_in_Meter);
                    txtAudiTotalHeigth.Text = Convert.ToString(data.Building_Height);
                    ddlAudiFireSafetyStatus.SelectedValue = data.Fire_Safety_Status;
                    txtAudiFireSafetyUpto.Text = DateTimeParser.ConvertDateTimeToText(data.Fire_Safety_Valid_Upto);
                    txtAudiLayoutPlanNo.Text = data.Layout_Plan_No;
                    ddlBuildingApporvalStatus.SelectedValue = data.Approval_Status;
                    txtAudiSuplierAgency.Text = data.Electricity_Agency;
                    ddlAudiBuildingBookOfAccount.SelectedValue = data.Book_Of_Account;
                    txtAudiLoadInKW.Text = data.Electricity_Load_in_KW;
                    txtElectricityConsumerNo.Text = data.Electricity_Consumer_No;
                    ddlAudiBuildingSafetyStatus.SelectedValue = data.Building_Safety_Status;
                }
            }
        }

        protected void btnAudiSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.AuditoriumReference.AuditoriumBuilding
            {
                Total_Capacity = NumericHandler.ConvertToInteger(txtAudiSittingCapacity.Text),
                Total_Floor_Area_in_sqft = NumericHandler.ConvertToDecimal(txtAudiTotalAreaOfFloor.Text),
                Building_Name = txtBuildingName.Text,
                Building_Length = NumericHandler.ConvertToInteger(txtAudiTotalLength.Text),
                Building_Breadth_in_Meter = NumericHandler.ConvertToInteger(txtAudiTotalBreath.Text),
                Building_Height = NumericHandler.ConvertToInteger(txtAudiTotalHeigth.Text),
                Fire_Safety_Status = ddlAudiFireSafetyStatus.SelectedValue == "CertificateObtained" ? WebServices.AuditoriumReference.Fire_Safety_Status.Certificate_Obtained : WebServices.AuditoriumReference.Fire_Safety_Status.No_Certificate,
                Fire_Safety_Valid_Upto = DateTimeParser.ParseDateTime(txtAudiFireSafetyUpto.Text),
                Layout_Plan_No = txtAudiLayoutPlanNo.Text,
                Approval_Status = ddlBuildingApporvalStatus.SelectedValue == "ApprovalObtained" ? WebServices.AuditoriumReference.Approval_Status.Approval_Obtained : WebServices.AuditoriumReference.Approval_Status.Approval_Not_Obtained,
                Electricity_Agency = txtAudiSuplierAgency.Text,
                Book_Of_Account = ddlAudiBuildingBookOfAccount.SelectedValue == "PWD" ? WebServices.AuditoriumReference.Book_Of_Account.PWD : ddlAudiBuildingBookOfAccount.SelectedValue == "IDCO" ? WebServices.AuditoriumReference.Book_Of_Account.IDCO : WebServices.AuditoriumReference.Book_Of_Account.SOIC,
                Electricity_Load_in_KW = txtAudiLoadInKW.Text,
                Electricity_Consumer_No = txtElectricityConsumerNo.Text,
                Building_Safety_Status = ddlAudiBuildingSafetyStatus.SelectedValue == "Safe" ? WebServices.AuditoriumReference.Building_Safety_Status.Safe : WebServices.AuditoriumReference.Building_Safety_Status.UnSafe

            };

            var result = ODataServices.UpdateAuditorium(obj);
            Alert.ShowAlert(this, "s", result);

            Response.Redirect("UpdateBuildings.aspx");
        }
    }
}