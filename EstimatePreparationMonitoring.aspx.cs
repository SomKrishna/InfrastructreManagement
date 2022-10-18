using InfrastructureManagement.Common;
using System;
using WebServices;
using WebServices.Helper;

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
                Estimate_submittedSpecified = true,

                Name_of_building_work = txtbuildingName.Text,
                Present_Status = txtPresentStatus.Text,
                Estimate_amount = NumericHandler.ConvertToDecimal(txtEstimatedAmount.Text),
                Type_of_work = ddlTypeOfWork.SelectedItem.Text == "Civil" ? WebServices.EstimatePrepReference.Type_of_work.Civil : ddlTypeOfWork.SelectedItem.Text == "Electrical" ? WebServices.EstimatePrepReference.Type_of_work.Electrical : WebServices.EstimatePrepReference.Type_of_work.PH,
                Estimate_submitted = ddlEstimateSubmitted.SelectedItem.Text == "Yes" ? WebServices.EstimatePrepReference.Estimate_submitted.Yes : WebServices.EstimatePrepReference.Estimate_submitted.No_x003B_,
                Remarks = txtRemarks.Text
            };
            var result = ODataServices.CreateProjectEstimate(obj);
            if (result == ExceptionHelper.SuccessfulMessage)
            {
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }
    }
}