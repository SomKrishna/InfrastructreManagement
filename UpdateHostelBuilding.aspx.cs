﻿using InfrastructureManagement.Common;
using System;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class UpdateHostelBuilding : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string blockCode = Request.QueryString["BlockCode"];
                var data = ODataServices.GetHostelBuilding(blockCode);
                if (!string.IsNullOrWhiteSpace(blockCode))
                {
                    lblHostelBuidingBlockNo.Text = blockCode;
                    ddlHostelBlockType.SelectedValue = data.Hostel_Type;
                    txtHostelBlockName.Text = data.Block_Name;
                    txtHostelClassRoomsAvailable.Text = Convert.ToString(data.No_Of_Room);
                    txtHostelNumberOfFloors.Text = Convert.ToString(data.No_Of_Floor);
                    txtHostelCapacity.Text = Convert.ToString(data.Total_Capacity);
                    txtHostelBuildingBlockLength.Text = Convert.ToString(data.Building_Length);
                    txtHostelBreath.Text = Convert.ToString(data.Building_Breadth_in_meter);
                    txtHostelBuildingHeigth.Text = Convert.ToString(data.Building_Height);
                    ddlHostelFireSafety.SelectedValue = data.Fire_Safety_Status;
                    txtHostelFireSafetyValidUpTo.Text = DateTimeParser.ConvertDateTimeToText(data.Fire_Safety_Valid_Upto);
                    txtHostelLayout.Text = data.Layout_Plan_No;
                    ddlHostelBuildingApproval.SelectedValue = data.Approval_Status;
                    txtHostelSupplierAgency.Text = data.Electricity_Agency;
                    ddlHostelBookOfAccount.SelectedValue = data.Book_Of_Account;
                    txtHostelLoadinKW.Text = data.Electricity_Load_in_KW;
                    txtHostelElctricityConsumerNo.Text = data.Electricity_Consumer_No;
                    ddlHostelWaterSupply.SelectedValue = data.Source_Of_Water;
                    ddlHostelTransformerType.SelectedValue = data.Transformer_Type;
                    txtPHDConsumerNo.Text = data.PHD_Consumer_No;
                    ddlHostelBuildingSafetyStatus.SelectedValue = data.Building_Safety_Status;
                    txtHostelTotalFloorArea.Text = Convert.ToString(data.Total_Floor_Area_in_sqft);
                }
            }
        }

        protected void btnHostelBuildingSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.HostelReference.HostelBuildingCard
            {
                Block_Code = lblHostelBuidingBlockNo.Text, 
                Hostel_Type = ddlHostelBlockType.SelectedValue == "Boys" ? WebServices.HostelReference.Hostel_Type.Boys : WebServices.HostelReference.Hostel_Type.Girls,
                Block_Name = txtHostelBlockName.Text,
                No_Of_Room = NumericHandler.ConvertToInteger(txtHostelClassRoomsAvailable.Text),
                No_Of_Floor = NumericHandler.ConvertToInteger(txtHostelNumberOfFloors.Text),
                Total_Capacity = NumericHandler.ConvertToInteger(txtHostelCapacity.Text),
                Total_Floor_Area_in_sqft= NumericHandler.ConvertToDecimal(txtHostelTotalFloorArea.Text),
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
                Building_Safety_Status = ddlHostelBuildingSafetyStatus.SelectedValue == "Safe" ? WebServices.HostelReference.Building_Safety_Status.Safe : WebServices.HostelReference.Building_Safety_Status.UnSafe
            };

            var result = ODataServices.UpdateHostelBuilding(obj);
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