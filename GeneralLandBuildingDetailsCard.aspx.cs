﻿using InfrastructureManagement.Common;
using System;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class GeneralLandBuildingDetailsCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GenralSubmitBtn_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.GeneralLandBuildingReference.GeneralLandBuildingCard
            {

                Boys_Common_Room_AvailableSpecified = true,
                Canteen_Cafeteria_CapacitySpecified = true,
                Canteen_Caf_for_Staffs_AvailSpecified = true,
                Central_Library_AvailableSpecified = true,
                CoE_Program_AvailableSpecified = true,
                Conference_Room_AvailableSpecified = true,
                CSR_Activities_AvailableSpecified = true,
                Digital_Library_AvailableSpecified = true,
                Dispensary_AvailableSpecified = true,
                Field_Area_in_AcresSpecified = true,
                Field_AvailableSpecified = true,
                Field_Gallery_AvailableSpecified = true,
                Floor_size_of_the_Video_confSpecified = true,
                Girls_Common_Room_AvailableSpecified = true,
                Internet_Connection_AvailableSpecified = true,
                Library_AvailableSpecified = true,
                Rain_Water_Harvesting_AvailSpecified = true,
                Roof_Top_Solar_Panel_AvailableSpecified = true,
                Sewage_Treatment_Plant_AvailSpecified = true,
                Sports_Court_Area_in_SqftSpecified = true,
                Sports_Court_AvailableSpecified = true,
                Staff_Common_Room_AvailableSpecified = true,
                Video_Conference_Room_AvailSpecified = true,
                Video_Conference_Room_CapacitySpecified = true,

                Boys_Common_Room_Available = ddlBoys_Common_Room_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Boys_Common_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Boys_Common_Room_Available.No,
                Boys_Common_Room_Details = txtBoys_Common_Room_Details.Text,
                Canteen_Cafeteria_Capacity = NumericHandler.ConvertToInteger(txtCanteen_Cafeteria_Capacity.Text),
                Canteen_Caf_for_Staffs_Avail = ddlCanteen_Caf_for_Staffs_Avail.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Canteen_Caf_for_Staffs_Avail.Yes : WebServices.GeneralLandBuildingReference.Canteen_Caf_for_Staffs_Avail.No,
                Central_Library_Available = ddlCentralLibraryAvailable.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Central_Library_Available.Yes : WebServices.GeneralLandBuildingReference.Central_Library_Available.No,
                CoE_Program_Available = ddlCoE_Program_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.CoE_Program_Available.Yes : WebServices.GeneralLandBuildingReference.CoE_Program_Available.No,
                CoE_Program_Details = txtCoE_Program_Details.Text,
                Conference_Room_Available = ddlConferenceRoomAvailable.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Conference_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Conference_Room_Available.No,
                CSR_Activities_Available = ddlCSR_Activities_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.CSR_Activities_Available.Yes : WebServices.GeneralLandBuildingReference.CSR_Activities_Available.No,
                CSR_Activity_Details = txtCSR_Activity_Details.Text,
                Digital_Library_Available = ddlDigitalLibraryAvailable.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Digital_Library_Available.Yes : WebServices.GeneralLandBuildingReference.Digital_Library_Available.No,
                Dispensary_Available = ddlDispensary_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Dispensary_Available.Yes : WebServices.GeneralLandBuildingReference.Dispensary_Available.No,
                Field_Area_in_Acres = NumericHandler.ConvertToDecimal(txtField_Area_in_Acres.Text),
                Field_Available = ddlFieldAvailable.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Field_Available.Yes : WebServices.GeneralLandBuildingReference.Field_Available.No,
                Field_Gallery_Available = ddlFieldGalleryAvailable.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Field_Gallery_Available.Yes : WebServices.GeneralLandBuildingReference.Field_Gallery_Available.No,
                Floor_size_of_the_Video_conf = NumericHandler.ConvertToDecimal(txtFloor_size_of_the_Video_conf.Text),
                Girls_Common_Room_Available = ddlGirls_Common_Room_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Girls_Common_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Girls_Common_Room_Available.No,
                Girls_Common_Room_Details = txtGirls_Common_Room_Details.Text,
                Internet_Connection_Available = ddlInternet_Connection_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Internet_Connection_Available.Yes : WebServices.GeneralLandBuildingReference.Internet_Connection_Available.No,
                Library_Available = ddlLibrary_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Library_Available.Yes : WebServices.GeneralLandBuildingReference.Library_Available.No,
                Rain_Water_Harvesting_Avail = ddlRain_Water_Harvesting_Avail.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Rain_Water_Harvesting_Avail.Yes : WebServices.GeneralLandBuildingReference.Rain_Water_Harvesting_Avail.No,
                Roof_Top_Solar_Panel_Available = ddlRoof_Top_Solar_Panel_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Roof_Top_Solar_Panel_Available.Yes : WebServices.GeneralLandBuildingReference.Roof_Top_Solar_Panel_Available.No,
                Sewage_Treatment_Plant_Avail = ddlSewage_Treatment_Plant_Avail.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Sewage_Treatment_Plant_Avail.Yes : WebServices.GeneralLandBuildingReference.Sewage_Treatment_Plant_Avail.No,
                Sports_Court_Area_in_Sqft = NumericHandler.ConvertToDecimal(txtSports_Court_Area_in_Sqft.Text),
                Sports_Court_Available = ddlSportCourt.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Sports_Court_Available.Yes : WebServices.GeneralLandBuildingReference.Sports_Court_Available.No,
                Staff_Common_Room_Available = ddlStaff_Common_Room_Available.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Staff_Common_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Staff_Common_Room_Available.No,
                Staff_Common_Room_Details = txtStaff_Common_Room_Details.Text,
                Uploaded_FileName = txtUploaded_FileName.Text,
                Video_Conference_Room_Avail = ddlVideo_Conference_Room_Avail.SelectedValue == "Yes" ? WebServices.GeneralLandBuildingReference.Video_Conference_Room_Avail.Yes : WebServices.GeneralLandBuildingReference.Video_Conference_Room_Avail.No,
                Video_Conference_Room_Capacity = NumericHandler.ConvertToInteger(txtVideo_Conference_Room_Capacity.Text),
                Video_Conference_Room_Location = txtVideo_Conference_Room_Location.Text,
                Year_of_Establis_of_institute = txtYear_of_Establis_of_institute.Text
            };

            var result = ODataServices.CreateGeneralBuildingRecord(obj);
            if (result == ExceptionHelper.SuccessfulMessage)
            {
                ddlBoys_Common_Room_Available.SelectedValue = "Select";
                txtBoys_Common_Room_Details.Text = string.Empty;
                txtCanteen_Cafeteria_Capacity.Text = string.Empty;
                ddlCanteen_Caf_for_Staffs_Avail.SelectedValue = "Select";
                ddlCentralLibraryAvailable.SelectedValue = "Select";
                ddlCoE_Program_Available.SelectedValue = "Select";
                txtCoE_Program_Details.Text = string.Empty;
                ddlConferenceRoomAvailable.SelectedValue = "Select";
                ddlCSR_Activities_Available.SelectedValue = "Select";
                txtCSR_Activity_Details.Text = string.Empty;
                ddlDigitalLibraryAvailable.SelectedValue = "Select";
                ddlDispensary_Available.SelectedValue = "Select";
                txtField_Area_in_Acres.Text = string.Empty,
               ddlFieldAvailable.SelectedValue = "Select";
                ddlFieldGalleryAvailable.SelectedValue = "Select";
                txtFloor_size_of_the_Video_conf.Text = string.Empty;
                ddlGirls_Common_Room_Available.SelectedValue = "Select";
                txtGirls_Common_Room_Details.Text = string.Empty;
                ddlInternet_Connection_Available.SelectedValue = "Select";
                ddlLibrary_Available.SelectedValue = "Select";
                ddlRain_Water_Harvesting_Avail.SelectedValue = "Select";
                ddlRoof_Top_Solar_Panel_Available.SelectedValue = "Select";
                ddlSewage_Treatment_Plant_Avail.SelectedValue = "Select";
                txtSports_Court_Area_in_Sqft.Text = string.Empty;
                ddlSportCourt.SelectedValue = "Select";
                ddlStaff_Common_Room_Available.SelectedValue = "Select";
                txtStaff_Common_Room_Details.Text = string.Empty;
                txtUploaded_FileName.Text = string.Empty;
                ddlVideo_Conference_Room_Avail.SelectedValue = "Select";
                txtVideo_Conference_Room_Capacity.Text = string.Empty;
                txtVideo_Conference_Room_Location.Text = string.Empty;
                txtYear_of_Establis_of_institute.Text = string.Empty;
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }
    }