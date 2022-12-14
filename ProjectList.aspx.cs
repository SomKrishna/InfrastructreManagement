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
    public partial class ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ListView1.Visible = false;
            if (ddlProjectType.SelectedItem.Text == "New")
            {
                var result = ODataServices.GetAllProjectDetails();
                ListView1.DataSource = result.Where(x => x.Project_Type == Convert.ToString(WebServices.NewProjectReference.Project_Type.New));
                ListView1.DataBind();
                ListView1.Visible = true;
            }
            if (ddlProjectType.SelectedItem.Text == "Ongoing")
            {
                var result = ODataServices.GetAllProjectDetails();
                ListView1.DataSource = result.Where(x => x.Project_Type == Convert.ToString(WebServices.NewProjectReference.Project_Type.Ongoing));
                ListView1.DataBind();
                ListView1.Visible = true;
            }
            if (ddlProjectType.SelectedItem.Text == "Improvement")
            {
                var result = ODataServices.GetAllProjectDetails();
                ListView1.DataSource = result.Where(x => x.Project_Type == Convert.ToString(WebServices.NewProjectReference.Project_Type.Improvement));
                ListView1.DataBind();
                ListView1.Visible = true;
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label projectCode = item.FindControl("lblProjectCode") as Label;
            Label projectType = item.FindControl("lblProjectType") as Label;

            if (!string.IsNullOrEmpty(projectCode.Text) && !string.IsNullOrEmpty(projectType.Text))
            {
                var servicePath = ODataServices.DownloadProjectFile(GetProjectTypeIndex(projectType.Text), projectCode.Text);
                if (!string.IsNullOrEmpty(servicePath))
                {
                    string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + servicePath.Split(Path.DirectorySeparatorChar)[5];
                    WebClient wc = new WebClient();
                    byte[] buffer = wc.DownloadData(exportedFilePath);
                    var FileName = "Project" + "_" + projectCode.Text + ".PDF";
                    var fileName = "attachment; filename=" + FileName;
                    base.Response.ClearContent();
                    base.Response.AddHeader("content-disposition", fileName);
                    base.Response.ContentType = "application/vnd.ms-excel";
                    base.Response.BinaryWrite(buffer);
                    base.Response.End();
                }
                else
                {
                    Alert.ShowAlert(this, "e", "No file found.");
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            LinkButton btn = sender as LinkButton;
            ListViewDataItem item = btn.NamingContainer as ListViewDataItem;
            Label projectCode = item.FindControl("lblProjectCode") as Label;
            Label projectType = item.FindControl("lblProjectType") as Label;

            FileUpload uploadedFile = item.FindControl("ProjectpdfUploader") as FileUpload;

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
                ODataServices.UploadProjectFile(GetProjectTypeIndex(projectType.Text), projectCode.Text, servicePath);
                Alert.ShowAlert(this, "s", "file Upload successfully");
            }
        }

        public int GetProjectTypeIndex(string projectType)
        {
            int projectTypeIndex = 2;
            if (WebServices.ImprovementProjectReference.Project_Type.Improvement.ToString() == projectType)
            {
                projectTypeIndex = 0;
            }
            if (WebServices.ImprovementProjectReference.Project_Type.Ongoing.ToString() == projectType)
            {
                projectTypeIndex = 1;
            }
            //if (WebServices.ImprovementProjectReference.Project_Type.New.ToString() == projectType)
            //{
            //    projectTypeIndex = 2;
            //}
            return projectTypeIndex;
        }
    }
}