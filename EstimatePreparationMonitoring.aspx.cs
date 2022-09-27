using InfrastructureManagement.Common;
using System;
using WebServices;

namespace InfrastructureManagement
{
    public partial class EstimatePreparationMonitoring : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEstimateSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.EstimatePrepReference.EstimatePrepCard
            {
                Estimate_amountSpecified = true,
                Name_of_building_work = txtbuildingName.Text,
                Present_Status = txtPresentStatus.Text,
                Estimate_amount = NumericHandler.ConvertToDecimal(txtEstimatedAmount.Text),
                Estimate_submittedSpecified = true,
                Type_of_work = ddlTypeOfWork.SelectedItem.Text == "Civil" ? WebServices.EstimatePrepReference.Type_of_work.Civil : ddlTypeOfWork.SelectedItem.Text == "Electrical" ? WebServices.EstimatePrepReference.Type_of_work.Electrical : WebServices.EstimatePrepReference.Type_of_work.PH,
                Estimate_submitted = ddlEstimateSubmitted.SelectedItem.Text == "Yes" ? WebServices.EstimatePrepReference.Estimate_submitted.Yes : WebServices.EstimatePrepReference.Estimate_submitted.No_x003B_
            };
            var result = ODataServices.CreateProjectEstimate(obj);
            Alert.ShowAlert(this, "s", result);
        }
    }
}