using System;
using System.Linq;
using WebServices;

namespace InfrastructureManagement
{
    public partial class LandRecordCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var result = ODataServices.GetLandDetailList();
            var filteredResult = result.Where(x => x.Khatian_Serial_No == txtSearch.Text).FirstOrDefault();
            if (filteredResult != null)
            {
                txtKhatian_Serial_No.Text = filteredResult.Khatian_Serial_No;
                ddlLandKisam.SelectedValue = Convert.ToString(filteredResult.Land_Kisam);
                txtPlot_No.Text = filteredResult.Plot_No;
                ddlDistrict.SelectedItem.Text = filteredResult.District;
                txtTahasil.Text = filteredResult.Tahasil;
                txtVillage.Text = filteredResult.Village;
                txtRI_Circle.Text = filteredResult.RI_Circle;
                txtLand_Owner_Details.Text = filteredResult.Land_Owner_Details;
                txtLand_possessioner_Details.Text = filteredResult.Land_possessioner_Details;
                txtLand_Issue_Description.Text = filteredResult.Land_Issue_Description;
                txtEncroachment_Plot_No.Text = filteredResult.Encroachment_Plot_No;
                txtEncroachment_Plot_Area.Text = Convert.ToString(filteredResult.Encroachment_Plot_Area);
                txtDispute_Plot_No.Text = filteredResult.Dispute_Plot_No;
                txtDispute_Area.Text = Convert.ToString(filteredResult.Dispute_Area);
                txtCasePlot_No.Text = filteredResult.CasePlot_No;
                LblMessage.Text = string.Empty;
            }
            else
            {
                LblMessage.Text = "No record found. Please try with valid Khatian Serial No.";
            }
        }
    }
}