using InfrastructureManagement.Common;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web.UI.WebControls;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class MaintenanceAndAMC : System.Web.UI.Page
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

                var items = ODataServices.GetItemList();
                ddlItemNo.DataSource = items;
                ddlItemNo.DataTextField = "Description";
                ddlItemNo.DataValueField = "No";
                ddlItemNo.DataBind();
                ddlItemNo.Items.Insert(0, new ListItem("Select Item", "0"));
            }
        }

        protected void btnAMCSubmit_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.AMCCardReference.AMCCard
            {
                DurationSpecified = true,
                Date_of_ExpirySpecified = true,
                Annual_Cost_of_AMCSpecified = true,

                Agency_No = ddlAgencyName.SelectedItem.Value,
                Type_of_equipment_under_AMC = txtTypeOfEquipment.Text,
                Duration = NumericHandler.ConvertToInteger(txtDuration.Text),
                Date_of_Expiry = DateTimeParser.ParseDateTime(txtDateOfExpiry.Text),
                Annual_Cost_of_AMC = NumericHandler.ConvertToDecimal(txtAnnualAMCCost.Text),
                Payment_Status = ddlPaymentStatus.SelectedItem.Text == "Already Paid" ? WebServices.AMCCardReference.Payment_Status.Paid : WebServices.AMCCardReference.Payment_Status.To_be_paid,
                Item_No = ddlItemNo.SelectedItem.Value,
                Equipment_Id = txtEquipmentId.Text
                //Item_Name = txtItemDescription.Text
            };
            var result = ODataServices.CreateMaintainceAndAMC(obj);
            if (result == ExceptionHelper.SuccessfulMessage)
            {
                Alert.ShowAlert(this, "s", result);
                ddlAgencyName.SelectedIndex = 0;
                ddlItemNo.SelectedIndex = 0;
                ddlPaymentStatus.ClearSelection();
                txtTypeOfEquipment.Text = string.Empty;
                txtDuration.Text = string.Empty;
                txtAnnualAMCCost.Text = string.Empty;
                txtEquipmentId.Text = string.Empty;
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string FileName = "AMCAndMaintenance.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + ODataServices.ExportAMCAndMaintenanceFile().Split(Path.DirectorySeparatorChar)[5];
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