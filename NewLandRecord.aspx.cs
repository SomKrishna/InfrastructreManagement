using InfrastructureManagement.Common;
using System;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class NewLandRecord : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlDistrict.DataSource = ODataServices.GetAllDistricts();
                ddlDistrict.DataTextField = "Name";
                ddlDistrict.DataValueField = "Code";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.LandReference.LandCard
            {
                Land_KisamSpecified = true,
                Dispute_AreaSpecified = true,
                Encroachment_Plot_AreaSpecified = true,

                Khatian_Serial_No = txtKhatian_Serial_No.Text,
                Land_Kisam = ddlLandKisam.SelectedValue == "Abadi_Irrigated_Two_Crops" ? WebServices.LandReference.Land_Kisam.Abadi_Irrigated_Two_Crops
                : ddlLandKisam.SelectedValue == "Abadi_Irrigated_One_crop" ? WebServices.LandReference.Land_Kisam.Abadi_Irrigated_One_crop
                : ddlLandKisam.SelectedValue == "Abadi_Non_irrigated_Rainfed" ? WebServices.LandReference.Land_Kisam.Abadi_Non_irrigated_Rainfed
                : ddlLandKisam.SelectedValue == "Abadi_Orchards_Bagayat" ? WebServices.LandReference.Land_Kisam.Abadi_Orchards_Bagayat
                : ddlLandKisam.SelectedValue == "Abadi_Water_bodies_Jalashaya" ? WebServices.LandReference.Land_Kisam.Abadi_Water_bodies_Jalashaya
                : ddlLandKisam.SelectedValue == "Abadi_Homestead_Gharabari" ? WebServices.LandReference.Land_Kisam.Abadi_Homestead_Gharabari
                : ddlLandKisam.SelectedValue == "Abadi_Commercial_Byabasaika" ? WebServices.LandReference.Land_Kisam.Abadi_Commercial_Byabasaika
                : ddlLandKisam.SelectedValue == "Abadi_Industrial_Shilpabhttika" ? WebServices.LandReference.Land_Kisam.Abadi_Industrial_Shilpabhttika
                : ddlLandKisam.SelectedValue == "Abadi_Forest_Jungle" ? WebServices.LandReference.Land_Kisam.Abadi_Forest_Jungle
                : ddlLandKisam.SelectedValue == "Abadi_Institutional_Anushthan" ? WebServices.LandReference.Land_Kisam.Abadi_Institutional_Anushthan
                : ddlLandKisam.SelectedValue == "Abadi_Mine_Khani_Khadan__x0026__Others" ? WebServices.LandReference.Land_Kisam.Abadi_Mine_Khani_Khadan__x0026__Others
                : ddlLandKisam.SelectedValue == "Abada_Jogya_Anabadi" ? WebServices.LandReference.Land_Kisam.Abada_Jogya_Anabadi
                : ddlLandKisam.SelectedValue == "Abada_Ajogya_Anabadi" ? WebServices.LandReference.Land_Kisam.Abada_Ajogya_Anabadi
                : ddlLandKisam.SelectedValue == "Rakhit" ? WebServices.LandReference.Land_Kisam.Rakhit
                : ddlLandKisam.SelectedValue== "Sarbasadharana" ? WebServices.LandReference.Land_Kisam.Sarbasadharana
                : WebServices.LandReference.Land_Kisam._blank_,
                Plot_No = txtPlot_No.Text,
                District = ddlDistrict.SelectedItem.Text,
                Tahasil = txtTahasil.Text,
                Village = txtVillage.Text,
                RI_Circle = txtRI_Circle.Text,
                Land_Owner_Details = txtLand_Owner_Details.Text,
                Land_possessioner_Details = txtLand_possessioner_Details.Text,
                Land_Issue_Description = txtLand_Issue_Description.Text,
                Encroachment_Plot_Area = NumericHandler.ConvertToDecimal(txtEncroachment_Plot_Area.Text),
                Encroachment_Plot_No = txtEncroachment_Plot_No.Text,
                Dispute_Plot_No = txtDispute_Plot_No.Text,
                Dispute_Area = NumericHandler.ConvertToDecimal(txtDispute_Area.Text),
                CasePlot_No = txtCasePlot_No.Text
            };
            var result = ODataServices.CreateLandRecord(obj);
            if (result == ExceptionHelper.SuccessfulMessage)
            {
                txtKhatian_Serial_No.Text = string.Empty;
                ddlLandKisam.SelectedValue = "Select";
                txtPlot_No.Text = string.Empty;
                ddlDistrict.SelectedValue = "0";
                txtTahasil.Text = string.Empty;
                txtVillage.Text = string.Empty;
                txtRI_Circle.Text = string.Empty;
                txtLand_Owner_Details.Text = string.Empty;
                txtLand_possessioner_Details.Text = string.Empty;
                txtLand_Issue_Description.Text = string.Empty;
                txtEncroachment_Plot_No.Text = string.Empty;
                txtEncroachment_Plot_Area.Text = string.Empty;
                txtDispute_Plot_No.Text = string.Empty;
                txtDispute_Area.Text = string.Empty;
                txtCasePlot_No.Text = string.Empty;
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }
    }
}