using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class ProjectProgressDetailsInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var ongoingobj = new Infra.Ongoingprojectcard();
            var improvementObj = new Infra.Improvementprojectcard();
            var InputProgectCode = txtProjectSearch.Text;
            //var projectProgressData = ODataServices.GetProjectProgressByProjectCode(InputProgectCode);
            ongoingobj = ODataServices.GetOnGoingTypeProjectDetails().Where(x => string.Equals(x.Project_Code, InputProgectCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            if (ongoingobj == null)
            {
                improvementObj = ODataServices.GetImprovementTypeProjectDetails().Where(x => string.Equals(x.Project_Code, InputProgectCode, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();
            }
            if (ongoingobj == null && improvementObj != null)
            {
                lblDistrict.InnerText = improvementObj.District;
                lblInstitute.InnerText = improvementObj.Name_of_the_Institute;
                lblProjectType.InnerText = improvementObj.Project_Type;
                lblBuildingId.InnerText = improvementObj.Building_ID;
                lblProjectName.InnerText = improvementObj.Name_of_the_project;
                lblAgencyName.InnerText = improvementObj.Agency;
                lblWorkType.InnerText = improvementObj.Type_of_work;
                lblWorkMode.InnerText = improvementObj.Mode_of_Work;
                lblCommencementDate.InnerText = Convert.ToString(improvementObj.Date_of_commencement_as_per_agreement);
                lblCompletionDate.InnerText = Convert.ToString(improvementObj.Date_of_completion_as_per_agreement);
            }
            else if (ongoingobj != null)
            {
                lblDistrict.InnerText = ongoingobj.District;
                lblInstitute.InnerText = ongoingobj.Name_of_the_Institute;
                lblProjectType.InnerText = ongoingobj.Project_Type;
                lblProjectName.InnerText = ongoingobj.Name_of_the_project;
                lblAgencyName.InnerText = ongoingobj.Agency;
                lblWorkType.InnerText = ongoingobj.Type_of_work;
                lblWorkMode.InnerText = ongoingobj.Mode_of_Work;
                lblCompletionDate.InnerText = Convert.ToString(ongoingobj.Date_of_completion_as_per_agreement);
            }
            else
            {
                lblDistrict.InnerText = string.Empty;
                lblInstitute.InnerText = string.Empty;
                lblProjectType.InnerText = string.Empty;
                lblBuildingId.InnerText = string.Empty;
                lblProjectName.InnerText = string.Empty;
                lblAgencyName.InnerText = string.Empty;
                lblWorkType.InnerText = string.Empty;
                lblWorkMode.InnerText = string.Empty;
                lblCommencementDate.InnerText = string.Empty;
                lblCompletionDate.InnerText = string.Empty;
            }
            if (ongoingobj == null && improvementObj == null)
            {
                LblMessage.Text = "No record found. Please try with valid Project Code";
            }
            else
            {
                LblMessage.Text = string.Empty;
            }
        }

        protected void txtProjectProgressSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.ProjectProgressReference.Projectprogressdetailscard
            {
                AA_dateSpecified = true,
                Amount_of_AA_accordedSpecified = true,
                Agreement_Value_with_GST_in_LakhSpecified = true,
                Running_FY_expenditure_in_LakhSpecified = true,
                Expected_date_for_completionSpecified = true,
                Expenditure_made_as_on_31_march_of_Last_FY_in_LakhSpecified = true,
                Balance_fund_required_for_commencement_of_Work_in_Running_FY_in_LakhSpecified = true,
                Balance_fund_requried_for_completion_of_work_in_Running_FY_in_LakhSpecified = true,
                Percentage_of_work_completionSpecified = true,
                Fund_now_proposed_for_release_in_Running_FY_inSpecified = true,

                Project_Type = lblProjectType.InnerText == "Improvement" ? WebServices.ProjectProgressReference.Project_Type.Improvement : lblProjectType.InnerText == "Ongoing" ? WebServices.ProjectProgressReference.Project_Type.Ongoing : WebServices.ProjectProgressReference.Project_Type.New,
                //Project_Code = hiddenFiledProjectCode.Value,
                AA_No = txtAANo.Text,
                AA_date = DateTimeParser.ParseDateTime(txtAADate.Text),
                Amount_of_AA_accorded = NumericHandler.ConvertToDecimal(txtAmountOfAA.Text),
                Agreement_Value_with_GST_in_Lakh = NumericHandler.ConvertToDecimal(txtAgreementValue.Text),
                Running_FY_expenditure_in_Lakh = NumericHandler.ConvertToDecimal(txtRunningExp.Text),
                Expenditure_made_as_on_31_march_of_Last_FY_in_Lakh = NumericHandler.ConvertToDecimal(txtExpenditureMade.Text),
                Balance_fund_required_for_commencement_of_Work_in_Running_FY_in_Lakh = NumericHandler.ConvertToDecimal(txtCommencementBalanceWork.Text),
                Balance_fund_requried_for_completion_of_work_in_Running_FY_in_Lakh = NumericHandler.ConvertToDecimal(txtCompletionBalanceFund.Text),
                Present_status = txtPresentStatus.Text,
                Expected_date_for_completion = DateTimeParser.ParseDateTime(txtExpectedDate.Text),
                Reason_for_delayif_delayed = txtDelayReason.Text,
                Tender_Variation = ddlTenderVariation.SelectedItem.Text == "Excess" ? WebServices.ProjectProgressReference.Tender_Variation.Excess : WebServices.ProjectProgressReference.Tender_Variation.Less,
                Percentage_of_work_completion = NumericHandler.ConvertToDecimal(txtWorkCompletionPercentage.Text),
                Fund_now_proposed_for_release_in_Running_FY_in = NumericHandler.ConvertToDecimal(txtFundNow.Text),
                UC_status = ddlUCStatus.SelectedValue == "blank" ? WebServices.ProjectProgressReference.UC_status._blank_ : ddlUCStatus.SelectedValue == "Submitted" ? WebServices.ProjectProgressReference.UC_status.Submitted : WebServices.ProjectProgressReference.UC_status.To_be_submitted,
                Running_Financial_Year = txtRunningFinanacialYear.Text
            };
            var result = ODataServices.AddProjectProgressDeatils(obj);
            if (result == ExceptionHelper.SuccessfulMessage || result == ExceptionHelper.UpdateMessage)
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