using InfrastructureManagement.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class SecurityServices : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var vendorList = ODataServices.GetVendorList();
                ddlAgencyName.DataSource = vendorList;
                ddlAgencyName.DataTextField = "Name";
                ddlAgencyName.DataValueField = "No";
                ddlAgencyName.DataBind();
                ddlAgencyName.Items.Insert(0, new ListItem("Select Agency", "0"));
            }
        }

        protected void btnSecurityServiceSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.ServiceCardReference.ServiceCard
            {
                No_of_person_engagedSpecified = true,
                No_of_person_sanctionedSpecified = true,
                Type_of_serviceSpecified = true,
                Agency_Code = ddlAgencyName.SelectedItem.Value,
                No_of_person_engaged = NumericHandler.ConvertToInteger(txtNumberOfPersonEngaged.Text),
                Type_of_service = ddlTypeOfService.SelectedItem.Text == "Security" ? WebServices.ServiceCardReference.Type_of_service.Security : ddlTypeOfService.SelectedItem.Text == "Sweeper" ? WebServices.ServiceCardReference.Type_of_service.Sweeper : ddlTypeOfService.SelectedItem.Text == "Driver" ? WebServices.ServiceCardReference.Type_of_service.Driver : WebServices.ServiceCardReference.Type_of_service.Others,
                No_of_person_sanctioned = NumericHandler.ConvertToInteger(txtNumberOfPersonSanctioned.Text)
            };
            var result = ODataServices.CreateSecurityService(obj);
            if (result == ExceptionHelper.SuccessfulMessage)
            {
                Alert.ShowAlert(this, "s", result);
                ddlAgencyName.SelectedIndex = 0;
                ddlTypeOfService.ClearSelection();
                txtNumberOfPersonEngaged.Text = string.Empty;
                txtNumberOfPersonSanctioned.Text = string.Empty;
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string FileName = "ServiceMonitoring.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + ODataServices.ExportSecurityFile().Split(Path.DirectorySeparatorChar)[5];
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);

            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }
    }
}