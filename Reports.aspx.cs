using System;
using System.Configuration;
using System.IO;
using System.Net;
using WebServices;

namespace InfrastructureManagement
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEstimatePreparation_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETEstimatePreparationMonitoring();
            var FileName = "DTETEstimatePreparationMonitoring.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnAuditoriumBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETAuditoriumBuilding();
            var FileName = "DTETAuditoriumBuilding.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnHostelBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETHostelBuilding();
            var FileName = "DTETHostelBuilding.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnInstitutionalBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETInstitutionalBuilding();
            var FileName = "DTETInstitutionalBuilding.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnStaffBuilding_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETStaffBuilding();
            var FileName = "DTETStaffBuilding.XLS";
            this.FileExport(servicePath, FileName);

        }

        protected void btnLandDataDetail_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETLandDataDetails();
            var FileName = "DTETLandDataDetails.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnMaintanenceAndAMC_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETMaintanenceAndAMC();
            var FileName = "DTETMaintanenceAndAMC.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnProjectProgressDetail_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETProjectProgressDetails();
            var FileName = "ExportDTETProjectProgressDetails.XLS";
            this.FileExport(servicePath, FileName);
        }

        protected void btnServiceMonitoring_Click(object sender, EventArgs e)
        {
            var servicePath = ODataServices.ExportDTETServiceMonitoring();
            var FileName = "DTETServiceMonitoring.XLS";
            this.FileExport(servicePath, FileName);
        }

        public void FileExport(string servicePath, string FileName)
        {
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + servicePath.Split(Path.DirectorySeparatorChar)[5];
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);
            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();

        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}