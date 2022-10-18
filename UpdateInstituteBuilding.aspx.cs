﻿using InfrastructureManagement.Common;
using System;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class UpdateBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string blockCode = Request.QueryString["BlockCode"];
                if (!string.IsNullOrWhiteSpace(blockCode))
                {
                    var data = ODataServices.GetInstituteBuilding(blockCode);

                    lblBuidingBlockNo.Text = blockCode;
                    txtInstituteBuildingBlock.Text = data.Block_Type_if_any;
                    txtInstituteClassRoomNumber.Text = Convert.ToString(data.No_Of_Class_Room);
                    txtInstituteTotalArea.Text = Convert.ToString(data.Total_Floor_Area_in_sqft);
                    txtInstituteBreath.Text = Convert.ToString(data.Building_Width_in_meter);
                    IntituteFireSafetyDDList.SelectedValue = data.Fire_Safety_Status;
                    txtInstituteDrawingPlan.Text = data.Layout_Plan_No;
                    txtInstituteSupplyAgency.Text = data.Electricity_Agency;
                    txtInstituteLoad.Text = data.Electricity_Load_in_KW;
                    InstituteWaterSupplyDDL.SelectedValue = data.Source_Of_Water;
                    txtInstitutePHDConsumerNumber.Text = data.PHD_Consumer_No;
                    txtInstituteBlockName.Text = data.Block_Name_if_any;
                    txtInstituteFloorNumber.Text = Convert.ToString(data.No_Of_Floor);
                    txtInstituteBuildingLength.Text = Convert.ToString(data.Building_Length_in_meter);
                    txtInstituteBuildingHeight.Text = Convert.ToString(data.Building_Height_in_meter);
                    txtInstituteSafetyValidUpTo.Text = DateTimeParser.ConvertDateTimeToText(data.Fire_Safety_Valid_Upto);
                    InstituteBuildingApprovalDDList.SelectedValue = data.Approval_Status;
                    InstituteBookOfAccountDDL.SelectedValue = data.Book_Of_Account;
                    txtInstituteElcConsumerNo.Text = data.Electricity_Consumer_No;
                    InstituteTransferTypeDDL.SelectedValue = data.Transformer_Type;
                    InstituteSafetyStatusDDL.SelectedValue = data.Building_Safety_Status;
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.InstituteReference.InstituteBuildingCard
            {
                Block_Code = lblBuidingBlockNo.Text,
                Block_Type_if_any = txtInstituteBuildingBlock.Text,
                No_Of_Class_Room = NumericHandler.ConvertToInteger(txtInstituteClassRoomNumber.Text),
                Total_Floor_Area_in_sqft = NumericHandler.ConvertToDecimal(txtInstituteTotalArea.Text),
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
                Building_Safety_Status = InstituteSafetyStatusDDL.SelectedValue == "Safe" ? WebServices.InstituteReference.Building_Safety_Status.Safe : WebServices.InstituteReference.Building_Safety_Status.UnSafe
            };

            var result = ODataServices.UpdateInstituteBuilding(obj);
            if (result == ExceptionHelper.UpdateMessage)
            {
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }

            Response.Redirect("UpdateBuildings.aspx");
        }
    }
}