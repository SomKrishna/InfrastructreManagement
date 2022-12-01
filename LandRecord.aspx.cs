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

namespace InfrastructureManagement
{
    public partial class Auditorium : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = ODataServices.GetLandDetailList().ToList();

            if (data == null || !data.Any())
            {
                btnExport.Visible = false;
            }
            else 
            {
                btnExport.Visible = true;
            }

            LandRecordList.DataSource = data;
            LandRecordList.DataBind();
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string FileName = "LandRecord.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + ODataServices.ExportLandFile().Split(Path.DirectorySeparatorChar)[5];
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);

            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label khatianNo = item.FindControl("lblKhatianNo") as Label;

            if (!string.IsNullOrEmpty(khatianNo.Text))
            {
                string FileName = "LandRecordList" + "_" + khatianNo.Text + ".pdf";
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + ODataServices.ExportLandFileInPdf(khatianNo.Text).Split(Path.DirectorySeparatorChar)[5];
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }

        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label khatianNo = item.FindControl("lblKhatianNo") as Label;

            FileUpload uploadedFile = item.FindControl("LandpdfUploader") as FileUpload;

            if (uploadedFile.HasFile)
            {
                string fileExtention = Path.GetExtension(uploadedFile.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(uploadedFile.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    uploadedFile.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.ImportPdfRoRFile(khatianNo.Text, servicePath);
                Alert.ShowAlert(this, "s", "file Upload successfully");
            }
        }
    }
}