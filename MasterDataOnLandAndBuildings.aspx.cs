using InfrastructureManagement.Common;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Web;
using WebServices;

namespace InfrastructureManagement
{
    public partial class MasterDataOnLandAndBuildings1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void uploadBtn_Click(object sender, EventArgs e)
        {
            //if (this.pdfUploader.HasFile)
            //{
            //    if (this.pdfUploader.PostedFile.ContentLength < 3e+6)
            //    {
            //        string fileExtention = Path.GetExtension(this.pdfUploader.FileName);
            //        string finalFileName = Path.GetFileNameWithoutExtension(this.pdfUploader.FileName.Substring(0, 10)) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
            //        string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
            //        if (!Directory.Exists(path))
            //            Directory.CreateDirectory(path);
            //        if (Directory.Exists(path))
            //        {
            //            path = Path.Combine(path, finalFileName);
            //            this.pdfUploader.SaveAs(path);
            //        }
            //        string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
            //        ODataServices.ImportLandFile(servicePath);
            //        Alert.ShowAlert(this, "s", "file Upload successfully");
            //    }
            //    else
            //    {
            //        Alert.ShowAlert(this, "s", "File size should be more than 3MB");
            //    }
            //}
            if (this.csvUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(this.csvUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(this.csvUploader.FileName.Substring(0, 10)) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    this.csvUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                try
                {
                    ODataServices.ImportLandFile(servicePath);
                }
                catch (Exception ex)
                {
                    Alert.ShowAlert(this, "e", ex.Message);
                }
                Alert.ShowAlert(this, "s", "file uploaded successfully");
            }
        }

        protected void downloadTemplateCSVBtn_Click(object sender, EventArgs e)
        {
            string FileName = "LandDataExportTemplate.csv";
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + FileName;
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