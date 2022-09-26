using InfrastructureManagement.Common;
using System;
using System.Linq;
using System.Web.UI.WebControls;
using WebServices;

namespace InfrastructureManagement
{
    public partial class ProjectWorkInput : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var collegeList = ODataServices.GetAllInstitutes().Where(x => !string.IsNullOrWhiteSpace(x.Institute_Code)).ToList();
                ddlInstituteName.DataSource = collegeList;
                ddlInstituteName.DataTextField = "Institute_Name";
                ddlInstituteName.DataValueField = "Institute_Code";
                ddlInstituteName.DataBind();
                ddlInstituteName.Items.Insert(0, new ListItem("Select Institute", "0"));

                ddlDistrict.DataSource = ODataServices.GetAllDistricts();
                ddlDistrict.DataTextField = "Name";
                ddlDistrict.DataValueField = "Code";
                ddlDistrict.DataBind();
                ddlDistrict.Items.Insert(0, new ListItem("Select District", "0"));
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var result = string.Empty;
            if (ddlProjectType.SelectedValue == "Improvement")
            {
                var imporovment = new WebServices.ImprovementProjectReference.Improvementprojectcard
                {
                    Date_of_commencement_as_per_agreementSpecified = true,
                    Date_of_completion_as_per_agreementSpecified = true,

                    Project_Code = txtProjectCode.Text,
                    Project_Type = WebServices.ImprovementProjectReference.Project_Type.Improvement,
                    Building_ID = txtBuildingId.Text,
                    District = ddlDistrict.SelectedItem.Text,
                    Name_of_the_Institute = ddlInstituteName.SelectedItem.Value,
                    Name_of_the_project = txtProjectName.Text,
                    Type_of_work = ddlTypeOfWork.SelectedValue == "Civil" ? WebServices.ImprovementProjectReference.Type_of_work.Civil : ddlTypeOfWork.SelectedValue == "Electrical" ? WebServices.ImprovementProjectReference.Type_of_work.Electrical : WebServices.ImprovementProjectReference.Type_of_work.PH,
                    Agency = ddlNameOfAgency.SelectedValue == "R&B" ? WebServices.ImprovementProjectReference.Agency.R_x0026_B
                    : ddlNameOfAgency.SelectedValue == "GPHD" ? WebServices.ImprovementProjectReference.Agency.GPHD
                    : ddlNameOfAgency.SelectedValue == "PHD" ? WebServices.ImprovementProjectReference.Agency.PHD
                    : ddlNameOfAgency.SelectedValue == "IDCO" ? WebServices.ImprovementProjectReference.Agency.IDCO
                    : ddlNameOfAgency.SelectedValue == "OSPH&WC" ? WebServices.ImprovementProjectReference.Agency.OSPH_x0026_WC
                    : ddlNameOfAgency.SelectedValue == "OSIC" ? WebServices.ImprovementProjectReference.Agency.OSIC
                    : WebServices.ImprovementProjectReference.Agency.GEMSat_principal_level,
                    Mode_of_Work = ddlModeOfWork.SelectedValue == "iOTMS" ? WebServices.ImprovementProjectReference.Mode_of_Work.iOTMS
                    : ddlModeOfWork.SelectedValue == "Works Module" ? WebServices.ImprovementProjectReference.Mode_of_Work.Works_Module
                    : WebServices.ImprovementProjectReference.Mode_of_Work.Deposit_mode_at_principal_level_referring_to_the_AA_issued_from_DTE_x0026_T_Govt,
                    Date_of_commencement_as_per_agreement = DateTimeParser.ParseDateTime(txtCommencementDate.Text),
                    Date_of_completion_as_per_agreement = DateTimeParser.ParseDateTime(txtCompletionPerAgreement.Text)
                };

                result = ODataServices.CreateImprovementProject(imporovment);
            }
            else if (ddlProjectType.SelectedValue == "Ongoing")
            {
                var onGoing = new WebServices.OngoingProjectReference.Ongoingprojectcard
                {
                    Date_of_completion_as_per_agreementSpecified = true,
                    Date_of_commencementSpecified = true,

                    Project_Code = txtProjectCode.Text,
                    Project_Type = WebServices.OngoingProjectReference.Project_Type.Improvement,
                    District = ddlDistrict.SelectedItem.Text,
                    Name_of_the_Institute = ddlInstituteName.SelectedItem.Value,
                    Name_of_the_project = txtProjectName.Text,
                    Type_of_work = ddlTypeOfWork.SelectedValue == "Civil" ? WebServices.OngoingProjectReference.Type_of_work.Civil : ddlTypeOfWork.SelectedValue == "Electrical" ? WebServices.OngoingProjectReference.Type_of_work.Electrical : WebServices.OngoingProjectReference.Type_of_work.PH,
                    Agency = ddlNameOfAgency.SelectedValue == "R&B" ? WebServices.OngoingProjectReference.Agency.R_x0026_B
                    : ddlNameOfAgency.SelectedValue == "GPHD" ? WebServices.OngoingProjectReference.Agency.GPHD
                    : ddlNameOfAgency.SelectedValue == "PHD" ? WebServices.OngoingProjectReference.Agency.PHD
                    : ddlNameOfAgency.SelectedValue == "IDCO" ? WebServices.OngoingProjectReference.Agency.IDCO
                    : ddlNameOfAgency.SelectedValue == "OSPH&WC" ? WebServices.OngoingProjectReference.Agency.OSPH_x0026_WC
                    : ddlNameOfAgency.SelectedValue == "OSIC" ? WebServices.OngoingProjectReference.Agency.OSIC
                    : WebServices.OngoingProjectReference.Agency.GEMSat_principal_level,
                    Mode_of_Work = ddlModeOfWork.SelectedValue == "iOTMS" ? WebServices.OngoingProjectReference.Mode_of_Work.iOTMS
                    : ddlModeOfWork.SelectedValue == "Works Module" ? WebServices.OngoingProjectReference.Mode_of_Work.Works_Module
                    : WebServices.OngoingProjectReference.Mode_of_Work.Deposit_mode_at_principal_level_referring_to_the_AA_issued_from_DTE_x0026_T_Govt,
                    Date_of_commencement = DateTimeParser.ParseDateTime(txtCommencementDate.Text),
                    Date_of_completion_as_per_agreement = DateTimeParser.ParseDateTime(txtCompletionPerAgreement.Text)
                };
                result = ODataServices.CreateOngoingProject(onGoing);

            }
            else
            {
                var newProject = new WebServices.NewProjectReference.Newprojectcard
                {
                    Date_of_commencement_as_per_agreementSpecified = true,
                    Date_of_completion_as_per_agreementSpecified = true,

                    Project_Code = txtProjectCode.Text,
                    Project_Type = WebServices.NewProjectReference.Project_Type.Improvement,
                    District = ddlDistrict.SelectedItem.Text,
                    Name_of_the_Institute = ddlInstituteName.SelectedItem.Value,
                    Name_of_the_project = txtProjectName.Text,
                    Type_of_work = ddlTypeOfWork.SelectedValue == "Civil" ? WebServices.NewProjectReference.Type_of_work.Civil : ddlTypeOfWork.SelectedValue == "Electrical" ? WebServices.NewProjectReference.Type_of_work.Electrical : WebServices.NewProjectReference.Type_of_work.PH,
                    Agency = ddlNameOfAgency.SelectedValue == "R&B" ? WebServices.NewProjectReference.Agency.R_x0026_B
                    : ddlNameOfAgency.SelectedValue == "GPHD" ? WebServices.NewProjectReference.Agency.GPHD
                    : ddlNameOfAgency.SelectedValue == "PHD" ? WebServices.NewProjectReference.Agency.PHD
                    : ddlNameOfAgency.SelectedValue == "IDCO" ? WebServices.NewProjectReference.Agency.IDCO
                    : ddlNameOfAgency.SelectedValue == "OSPH&WC" ? WebServices.NewProjectReference.Agency.OSPH_x0026_WC
                    : ddlNameOfAgency.SelectedValue == "OSIC" ? WebServices.NewProjectReference.Agency.OSIC
                    : WebServices.NewProjectReference.Agency.GEMSat_principal_level,
                    Mode_of_Work = ddlModeOfWork.SelectedValue == "iOTMS" ? WebServices.NewProjectReference.Mode_of_Work.iOTMS
                    : ddlModeOfWork.SelectedValue == "Works Module" ? WebServices.NewProjectReference.Mode_of_Work.Works_Module
                    : WebServices.NewProjectReference.Mode_of_Work.Deposit_mode_at_principal_level_referring_to_the_AA_issued_from_DTE_x0026_T_Govt,
                    Date_of_commencement_as_per_agreement = DateTimeParser.ParseDateTime(txtCommencementDate.Text),
                    Date_of_completion_as_per_agreement = DateTimeParser.ParseDateTime(txtCompletionPerAgreement.Text)
                };
                result = ODataServices.CreateNewProject(newProject);

            }
            Alert.ShowAlert(this, "s", result);
        }
    }
}