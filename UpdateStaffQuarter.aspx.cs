using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;

namespace InfrastructureManagement
{
    public partial class UpdateStaffQuarter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string quarterCode = Request.QueryString["QuarterCode"];
                var data = ODataServices.GetStaffQuarter(quarterCode);
                if (!string.IsNullOrWhiteSpace(quarterCode))
                {
                    lblstaffQuarterCodeNo.Text = data.Quarter_Code;
                    ddlStaffBlockType.SelectedValue = data.Quarter_Type;
                    txtStaffBlockName.Text = data.Quarter_Block_Name;
                    txtStaffClassRoomsAvailable.Text = Convert.ToString(data.No_Of_Room);
                    txtStaffNumberOfFloor.Text = Convert.ToString(data.No_Of_Floor);
                    txtStaffFloorArea.Text = Convert.ToString(data.Total_Floor_Area_in_sqft);
                    txtStaffLengthofBuilding.Text = Convert.ToString(data.Building_Length);
                    txtStaffBreath.Text = Convert.ToString(data.Building_Breadth_in_Meter);
                    txtStaffHeight.Text = Convert.ToString(data.Building_Height);
                    ddlStaffFireSafetyStatus.SelectedValue = data.Fire_Safety_Status;
                    txtStaffFireSafetyValidUpto.Text = DateTimeParser.ConvertDateTimeToText(data.Fire_Safety_Valid_Upto);
                    ddlStaffElectricityConnectionStatus.SelectedValue = Convert.ToString(data.Electricity_Connection_Status);
                    txtStaffLayoutPlanNo.Text = data.Layout_Plan_No;
                    ddlStaffBuildingApprovalStatus.SelectedValue = data.Approval_Status;
                    txtStaffSupplierAgency.Text = data.Electricity_Agency;
                    ddlStaffBookOfAccount.SelectedValue = data.Book_Of_Account;
                    txtStaffLoadInKw.Text = data.Electricity_Load_in_KW;
                    txtStaffElecticityCOnsumerNo.Text = data.Electricity_Consumer_No;
                    ddlStaffWaterSupplySource.SelectedValue = data.Source_Of_Water;
                    ddlTransformerType.SelectedValue = data.Transformer_Type;
                    txtStaffPHDConsumerNo.Text = data.PHD_Consumer_No;
                    ddlStaffSafetyStatus.SelectedValue = data.Building_Safety_Status;
                    ddlStaffOccupancyStatus.SelectedValue = data.Occupancy_Status;
                }
            }
        }

        protected void btnStaffSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.StaffReference.StaffQuarterCard
            {
                Quarter_Code = lblstaffQuarterCodeNo.Text, 
                Quarter_Type = ddlStaffBlockType.SelectedValue == "A" ?
                WebServices.StaffReference.Quarter_Type.A : ddlStaffBlockType.SelectedValue == "B" ?
                WebServices.StaffReference.Quarter_Type.B : ddlStaffBlockType.SelectedValue == "C" ?
                WebServices.StaffReference.Quarter_Type.C : ddlStaffBlockType.SelectedValue == "D" ?
                WebServices.StaffReference.Quarter_Type.D : ddlStaffBlockType.SelectedValue == "E" ?
                WebServices.StaffReference.Quarter_Type.E : ddlStaffBlockType.SelectedValue == "E" ?
                WebServices.StaffReference.Quarter_Type.E : WebServices.StaffReference.Quarter_Type.F,
                Quarter_Block_Name = txtStaffBlockName.Text,
                No_Of_Room = NumericHandler.ConvertToInteger(txtStaffClassRoomsAvailable.Text),
                No_Of_Floor = NumericHandler.ConvertToInteger(txtStaffNumberOfFloor.Text),
                Total_Floor_Area_in_sqft = NumericHandler.ConvertToDecimal(txtStaffFloorArea.Text),
                Building_Length = NumericHandler.ConvertToInteger(txtStaffLengthofBuilding.Text),
                Building_Breadth_in_Meter = NumericHandler.ConvertToInteger(txtStaffBreath.Text),
                Building_Height = NumericHandler.ConvertToInteger(txtStaffHeight.Text),
                Fire_Safety_Status = ddlStaffFireSafetyStatus.SelectedValue == "CertificateObtained" ? WebServices.StaffReference.Fire_Safety_Status.Certificate_Obtained : WebServices.StaffReference.Fire_Safety_Status.No_Certificate,
                Fire_Safety_Valid_Upto = DateTimeParser.ParseDateTime(txtStaffFireSafetyValidUpto.Text),
                Electricity_Connection_Status = ddlStaffElectricityConnectionStatus.SelectedValue == "ELECTRIFIEDBYINSTITUTE" ? WebServices.StaffReference.Electricity_Connection_Status.Electrified_by_Institute : WebServices.StaffReference.Electricity_Connection_Status.Electrified_by_power_distribution_agency,
                Layout_Plan_No = txtStaffLayoutPlanNo.Text,
                Approval_Status = ddlStaffBuildingApprovalStatus.SelectedValue == "ApprovalObtained" ? WebServices.StaffReference.Approval_Status.Approval_Obtained : WebServices.StaffReference.Approval_Status.Approval_Not_Obtained,
                Electricity_Agency = txtStaffSupplierAgency.Text,
                Book_Of_Account = ddlStaffBookOfAccount.SelectedValue == "PWD" ? WebServices.StaffReference.Book_Of_Account.PWD : ddlStaffBookOfAccount.SelectedValue == "IDCO" ? WebServices.StaffReference.Book_Of_Account.IDCO : WebServices.StaffReference.Book_Of_Account.SOIC,
                Electricity_Load_in_KW = txtStaffLoadInKw.Text,
                Electricity_Consumer_No = txtStaffElecticityCOnsumerNo.Text,
                Source_Of_Water = ddlStaffWaterSupplySource.SelectedValue == "OwnSource" ? WebServices.StaffReference.Source_Of_Water.Own_Source : WebServices.StaffReference.Source_Of_Water.PHD_Source,
                Transformer_Type = ddlTransformerType.SelectedValue == "Own" ? WebServices.StaffReference.Transformer_Type.Own : WebServices.StaffReference.Transformer_Type.Public,
                PHD_Consumer_No = txtStaffPHDConsumerNo.Text,
                Building_Safety_Status = ddlStaffSafetyStatus.SelectedValue == "Safe" ? WebServices.StaffReference.Building_Safety_Status.Safe : WebServices.StaffReference.Building_Safety_Status.UnSafe,
                Occupancy_Status = ddlStaffOccupancyStatus.SelectedValue == "Occupied" ? WebServices.StaffReference.Occupancy_Status.Occupied : WebServices.StaffReference.Occupancy_Status.Vacancy
            };

            var result = ODataServices.UpdateStaffQuarter(obj);
            Alert.ShowAlert(this, "s", result);

            Response.Redirect("UpdateBuildings.aspx");
        }

    }
}