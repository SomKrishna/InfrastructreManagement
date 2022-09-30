using InfrastructureManagement.Common;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using WebServices;

namespace InfrastructureManagement
{
    public partial class NewEntryBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void InstituteSubmitBtn_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.InstituteReference.InstituteBuildingCard
            {
                Block_Code = txtInstituteBlockCode.Text,
                Block_Type_if_any = txtInstituteBuildingBlock.Text,
                No_Of_Class_Room = NumericHandler.ConvertToInteger(txtInstituteClassRoomNumber.Text),
                Total_Floor_Area_in_sqft = NumericHandler.ConvertToDecimal(txtInstituteTotalArea.Text),

                Total_Floor_Area_in_sqftSpecified = true,
                Building_Length_in_meterSpecified = true,
                Building_Height_in_meterSpecified = true,
                Building_Width_in_meterSpecified = true,
                No_Of_Class_RoomSpecified = true,
                No_Of_FloorSpecified = true,
                Fire_Safety_Valid_UptoSpecified = true,
                Fire_Safety_StatusSpecified = true,
                Year_of_ConstructionSpecified = true,
                No_of_Smart_ClassesSpecified = true,
                Computer_Lab_AvailableSpecified = true,
                No_of_RO_Water_PurifierSpecified = true,
                No_of_Non_RO_Water_PurifierSpecified = true,

                Building_Width_in_meter = NumericHandler.ConvertToInteger(txtInstituteBreath.Text),
                Fire_Safety_Status = IntituteFireSafetyDDList.SelectedValue == "CertificateObtained" ? WebServices.InstituteReference.Fire_Safety_Status.Certificate_Obtained : WebServices.InstituteReference.Fire_Safety_Status.No_Certificate,
                Layout_Plan_No = txtInstituteDrawingPlan.Text,
                Electricity_Agency = txtInstituteSupplyAgency.Text,
                Electricity_Load_in_KW = txtInstituteLoad.Text,
                Source_Of_Water = InstituteWaterSupplyDDL.SelectedValue == "OwnSource" ? WebServices.InstituteReference.Source_Of_Water.Own_Source : WebServices.InstituteReference.Source_Of_Water.PHD_Source,
                PHD_Consumer_No = txtInstitutePHDConsumerNumber.Text,
                Block_Name_if_any = txtInstituteBlockName.Text,
                No_Of_Floor = NumericHandler.ConvertToInteger(txtInstituteFloorNumber.Text),
                Building_Length_in_meter = NumericHandler.ConvertToInteger(txtInstituteBuildingLength.Text),
                Building_Height_in_meter = NumericHandler.ConvertToInteger(txtInstituteBuildingHeight.Text),
                Fire_Safety_Valid_Upto = DateTimeParser.ParseDateTime(txtInstituteSafetyValidUpTo.Text),
                Approval_Status = InstituteBuildingApprovalDDList.SelectedValue == "ApprovalObtained" ? WebServices.InstituteReference.Approval_Status.Approval_Obtained : WebServices.InstituteReference.Approval_Status.Approval_Not_Obtained,
                Book_Of_Account = InstituteBookOfAccountDDL.SelectedValue == "PWD" ? WebServices.InstituteReference.Book_Of_Account.PWD : InstituteBookOfAccountDDL.SelectedValue == "IDCO" ? WebServices.InstituteReference.Book_Of_Account.IDCO : WebServices.InstituteReference.Book_Of_Account.SOIC,
                Electricity_Consumer_No = txtInstituteElcConsumerNo.Text,
                Transformer_Type = InstituteTransferTypeDDL.SelectedValue == "Own" ? WebServices.InstituteReference.Transformer_Type.Own : WebServices.InstituteReference.Transformer_Type.Public,
                Building_Safety_Status = InstituteSafetyStatusDDL.SelectedValue == "Safe" ? WebServices.InstituteReference.Building_Safety_Status.Safe : WebServices.InstituteReference.Building_Safety_Status.UnSafe,
                Year_of_Construction = NumericHandler.ConvertToInteger(txtYearOfConstruction.Text),
                No_of_Smart_Classes = NumericHandler.ConvertToInteger(txtNoOfSmartClasses.Text),
                Computer_Lab_Available = ddlCompLabAvailable.SelectedValue == "Yes" ? WebServices.InstituteReference.Computer_Lab_Available.Yes : WebServices.InstituteReference.Computer_Lab_Available.No,
                No_of_RO_Water_Purifier = NumericHandler.ConvertToInteger(txtNoOfROPurifier.Text),
                No_of_Non_RO_Water_Purifier = NumericHandler.ConvertToInteger(txtNoOfNonROPurifier.Text),
            };
            var result = ODataServices.CreateInstituteBuilding(obj);
            Alert.ShowAlert(this, "s", result);
        }

        protected void btnHostelBuildingSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.HostelReference.HostelBuildingCard
            {
                Total_Floor_Area_in_sqftSpecified = true,
                Building_Breadth_in_meterSpecified = true,
                Building_HeightSpecified = true,
                Building_LengthSpecified = true,
                No_Of_RoomSpecified = true,
                No_Of_FloorSpecified = true,
                Fire_Safety_Valid_UptoSpecified = true,
                Fire_Safety_StatusSpecified = true,
                Year_of_ConstructionSpecified = true,
                No_of_Non_RO_Water_PurifierSpecified = true,
                No_of_RO_Water_PurifierSpecified = true,
                Total_CapacitySpecified = true,
                Approval_StatusSpecified = true,
                Book_Of_AccountSpecified = true,
                Building_Safety_StatusSpecified = true,
                Hostel_TypeSpecified = true,
                Source_Of_WaterSpecified = true,
                Transformer_TypeSpecified = true,

                Block_Code = txtHostelBlockCode.Text,
                Hostel_Type = ddlHostelBlockType.SelectedValue == "Boys" ? WebServices.HostelReference.Hostel_Type.Boys : WebServices.HostelReference.Hostel_Type.Girls,
                Block_Name = txtHostelBlockName.Text,
                No_Of_Room = NumericHandler.ConvertToInteger(txtHostelRoomsAvailable.Text),
                No_Of_Floor = NumericHandler.ConvertToInteger(txtHostelNumberOfFloors.Text),
                Total_Floor_Area_in_sqft = NumericHandler.ConvertToDecimal(txtHostelTotalFloorArea.Text),
                Total_Capacity = NumericHandler.ConvertToInteger(txtHostelCapacity.Text),
                Building_Length = NumericHandler.ConvertToInteger(txtHostelBuildingBlockLength.Text),
                Building_Breadth_in_meter = NumericHandler.ConvertToInteger(txtHostelBreath.Text),
                Building_Height = NumericHandler.ConvertToInteger(txtHostelBuildingHeigth.Text),
                Fire_Safety_Status = ddlHostelFireSafety.SelectedValue == "CertificateObtained" ? WebServices.HostelReference.Fire_Safety_Status.Certificate_Obtained : WebServices.HostelReference.Fire_Safety_Status.No_Certificate,
                Fire_Safety_Valid_Upto = DateTimeParser.ParseDateTime(txtHostelFireSafetyValidUpTo.Text),
                Layout_Plan_No = txtHostelLayout.Text,
                Approval_Status = ddlHostelBuildingApproval.SelectedValue == "ApprovalObtained" ? WebServices.HostelReference.Approval_Status.Approval_Obtained : WebServices.HostelReference.Approval_Status.Approval_Not_Obtained,
                Electricity_Agency = txtHostelSupplierAgency.Text,
                Book_Of_Account = ddlHostelBookOfAccount.SelectedValue == "PWD" ? WebServices.HostelReference.Book_Of_Account.PWD : ddlHostelBookOfAccount.SelectedValue == "IDCO" ? WebServices.HostelReference.Book_Of_Account.IDCO : WebServices.HostelReference.Book_Of_Account.SOIC,
                Electricity_Load_in_KW = txtHostelLoadinKW.Text,
                Electricity_Consumer_No = txtHostelElctricityConsumerNo.Text,
                Source_Of_Water = ddlHostelWaterSupply.SelectedValue == "OwnSource" ? WebServices.HostelReference.Source_Of_Water.Own_Source : WebServices.HostelReference.Source_Of_Water.PHD_Source,
                Transformer_Type = ddlHostelTransformerType.SelectedValue == "Own" ? WebServices.HostelReference.Transformer_Type.Own : WebServices.HostelReference.Transformer_Type.Public,
                PHD_Consumer_No = txtPHDConsumerNo.Text,
                Building_Safety_Status = ddlHostelBuildingSafetyStatus.SelectedValue == "Safe" ? WebServices.HostelReference.Building_Safety_Status.Safe : WebServices.HostelReference.Building_Safety_Status.UnSafe,
                Year_of_Construction = NumericHandler.ConvertToInteger(txtHostelYearOfContruction.Text),
                No_of_Non_RO_Water_Purifier = NumericHandler.ConvertToInteger(txtHostelNonROPurifier.Text),
                No_of_RO_Water_Purifier = NumericHandler.ConvertToInteger(txtHostelNoOfROPurifier.Text)
            };
            var result = ODataServices.CreateHostelBuilding(obj);
            Alert.ShowAlert(this, "s", result);
        }

        protected void btnStaffSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.StaffReference.StaffQuarterCard
            {
                Total_Floor_Area_in_sqftSpecified = true,
                Building_Breadth_in_MeterSpecified = true,
                Building_HeightSpecified = true,
                Building_LengthSpecified = true,
                No_Of_RoomSpecified = true,
                No_Of_FloorSpecified = true,
                Fire_Safety_Valid_UptoSpecified = true,
                Fire_Safety_StatusSpecified = true,
                Year_of_ConstructionSpecified = true,


                Quarter_Code = txtStaffQuarterCode.Text,
                Quarter_Type = ddlStaffBlockType.SelectedValue == "A" ?
                WebServices.StaffReference.Quarter_Type.A : ddlStaffBlockType.SelectedValue == "B" ?
                WebServices.StaffReference.Quarter_Type.B : ddlStaffBlockType.SelectedValue == "C" ?
                WebServices.StaffReference.Quarter_Type.C : ddlStaffBlockType.SelectedValue == "D" ?
                WebServices.StaffReference.Quarter_Type.D : ddlStaffBlockType.SelectedValue == "E" ?
                WebServices.StaffReference.Quarter_Type.E : ddlStaffBlockType.SelectedValue == "E" ?
                WebServices.StaffReference.Quarter_Type.E : WebServices.StaffReference.Quarter_Type.F,
                Quarter_Block_Name = txtStaffBlockName.Text,
                No_Of_Room = NumericHandler.ConvertToInteger(txtStaffHostelCapacity.Text),
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
                Occupancy_Status = ddlStaffOccupancyStatus.SelectedValue == "Occupied" ? WebServices.StaffReference.Occupancy_Status.Occupied : WebServices.StaffReference.Occupancy_Status.Vacancy,
                Year_of_Construction = NumericHandler.ConvertToInteger(txtStaffYearOfConstruction.Text)
            };
            var result = ODataServices.CreateStaffQuarter(obj);
            Alert.ShowAlert(this, "s", result);
        }

        protected void btnAudiSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.AuditoriumReference.AuditoriumBuilding
            {
                Total_Floor_Area_in_sqftSpecified = true,
                Building_Breadth_in_MeterSpecified = true,
                Building_HeightSpecified = true,
                Building_LengthSpecified = true,
                Fire_Safety_Valid_UptoSpecified = true,
                Fire_Safety_StatusSpecified = true,
                Year_of_ConstructionSpecified = true,
                Total_CapacitySpecified = true,

                Building_Code = txtAudiBuildingCode.Text,
                Total_Capacity = NumericHandler.ConvertToInteger(txtAudiSittingCapacity.Text),
                Total_Floor_Area_in_sqft = NumericHandler.ConvertToDecimal(txtAudiTotalAreaOfFloor.Text),
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
                Building_Safety_Status = ddlAudiBuildingSafetyStatus.SelectedValue == "Safe" ? WebServices.AuditoriumReference.Building_Safety_Status.Safe : WebServices.AuditoriumReference.Building_Safety_Status.UnSafe,
                Year_of_Construction = NumericHandler.ConvertToInteger(txtAudiYearOfConstruction.Text)
            };
            var result = ODataServices.CreateAuditorium(obj);
            Alert.ShowAlert(this, "s", result);
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string servicePath = string.Empty;
            if (ddlBuildingList.SelectedValue == "InstitutionalBuildings")
            {
                servicePath = ODataServices.ExportInstitutionalBuilding();
            }
            if (ddlBuildingList.SelectedValue == "HostelBuildings")
            {
                servicePath = ODataServices.ExportHostelBuilding();
            }
            if (ddlBuildingList.SelectedValue == "StaffQuarters")
            {
                servicePath = ODataServices.ExportStaffQuarter();
            }
            if (ddlBuildingList.SelectedValue == "Auditoriums")
            {
                servicePath = ODataServices.ExportAuditoriumBuilding();
            }


            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + servicePath.Split(Path.DirectorySeparatorChar)[5];
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var FileName = ddlBuildingList.SelectedValue + ".XLS";
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }
    }
}