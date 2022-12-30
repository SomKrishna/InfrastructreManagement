using InfrastructureManagement.Common;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using WebServices;
using WebServices.Helper;

namespace InfrastructureManagement
{
    public partial class GeneralLandBuildingDetailsCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var result = ODataServices.GetGeneralLandBuildingList();

                if (result != null && result.Any())
                {
                    var rec = result.FirstOrDefault();
                    hdnKey.Value = rec.Primary_Key;
                    chkBoys_Common_Room_Available.Checked = rec.Boys_Common_Room_Available == "Yes" ? true : false;
                    txtBoys_Common_Room_Details.Text = rec.Boys_Common_Room_Details;
                    txtCanteen_Cafeteria_Capacity.Text = Convert.ToString(rec.Canteen_Cafeteria_Capacity);
                    chkCanteen_Caf_for_Staffs_Avail.Checked = rec.Canteen_Caf_for_Staffs_Avail == "Yes" ? true : false;
                    chkCentralLibraryAvailable.Checked = rec.Central_Library_Available == "Yes" ? true : false;
                    chkCoE_Program_Available.Checked = rec.CoE_Program_Available == "Yes" ? true : false;
                    txtCoE_Program_Details.Text = rec.CoE_Program_Details;
                    chkConferenceRoomAvailable.Checked = rec.Conference_Room_Available == "Yes" ? true : false;
                    chkCSR_Activities_Available.Checked = rec.CSR_Activities_Available == "Yes" ? true : false;
                    txtCSR_Activity_Details.Text = rec.CSR_Activity_Details;
                    chkDigitalLibraryAvailable.Checked = rec.Digital_Library_Available == "Yes" ? true : false;
                    chkDispensary_Available.Checked = rec.Dispensary_Available == "Yes" ? true : false;
                    txtField_Area_in_Acres.Text = Convert.ToString(rec.Field_Area_in_Acres);
                    chkFieldAvailable.Checked = rec.Field_Available == "Yes" ? true : false;
                    chkFieldGalleryAvailable.Checked = rec.Field_Gallery_Available == "Yes" ? true : false;
                    txtFloor_size_of_the_Video_conf.Text = Convert.ToString(rec.Floor_size_of_the_Video_conf);
                    chkGirls_Common_Room_Available.Checked = rec.Girls_Common_Room_Available == "Yes" ? true : false;
                    txtGirls_Common_Room_Details.Text = rec.Girls_Common_Room_Details;
                    chkInternet_Connection_Available.Checked = rec.Internet_Connection_Available == "Yes" ? true : false;
                    chkLibrary_Available.Checked = rec.Library_Available == "Yes" ? true : false;
                    chkRain_Water_Harvesting_Avail.Checked = rec.Rain_Water_Harvesting_Avail == "Yes" ? true : false;
                    chkRoof_Top_Solar_Panel_Available.Checked = rec.Roof_Top_Solar_Panel_Available == "Yes" ? true : false;
                    chkSewage_Treatment_Plant_Avail.Checked = rec.Sewage_Treatment_Plant_Avail == "Yes" ? true : false;
                    txtSports_Court_Area_in_Sqft.Text = Convert.ToString(rec.Sports_Court_Area_in_Sqft);
                    chkSportCourt.Checked = rec.Sport_x2019_s_Court_Available == "Yes" ? true : false;
                    chkStaff_Common_Room_Available.Checked = rec.Staff_Common_Room_Available == "Yes" ? true : false;
                    txtStaff_Common_Room_Details.Text = rec.Staff_Common_Room_Details;
                    //txtUploaded_FileName.Text = rec.Uploaded_FileName;
                    chkVideo_Conference_Room_Avail.Checked = rec.Video_Conference_Room_Avail == "Yes" ? true : false;
                    txtVideo_Conference_Room_Capacity.Text = Convert.ToString(rec.Video_Conference_Room_Capacity);
                    txtVideo_Conference_Room_Location.Text = rec.Video_Conference_Room_Location;
                    txtYear_of_Establis_of_institute.Text = rec.Year_of_Establis_of_institute;
                }
            }
        }

        protected void GenralSubmitBtn_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.GeneralLandBuildingReference.GeneralLandBuildingCard
            {
                Boys_Common_Room_AvailableSpecified = true,
                Canteen_Cafeteria_CapacitySpecified = true,
                Canteen_Caf_for_Staffs_AvailSpecified = true,
                Central_Library_AvailableSpecified = true,
                CoE_Program_AvailableSpecified = true,
                Conference_Room_AvailableSpecified = true,
                CSR_Activities_AvailableSpecified = true,
                Digital_Library_AvailableSpecified = true,
                Dispensary_AvailableSpecified = true,
                Field_Area_in_AcresSpecified = true,
                Field_AvailableSpecified = true,
                Field_Gallery_AvailableSpecified = true,
                Floor_size_of_the_Video_confSpecified = true,
                Girls_Common_Room_AvailableSpecified = true,
                Internet_Connection_AvailableSpecified = true,
                Library_AvailableSpecified = true,
                Rain_Water_Harvesting_AvailSpecified = true,
                Roof_Top_Solar_Panel_AvailableSpecified = true,
                Sewage_Treatment_Plant_AvailSpecified = true,
                Sports_Court_Area_in_SqftSpecified = true,
                Sports_Court_AvailableSpecified = true,
                Staff_Common_Room_AvailableSpecified = true,
                Video_Conference_Room_AvailSpecified = true,
                Video_Conference_Room_CapacitySpecified = true,

                Boys_Common_Room_Available = chkBoys_Common_Room_Available.Checked ? WebServices.GeneralLandBuildingReference.Boys_Common_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Boys_Common_Room_Available.No,
                Boys_Common_Room_Details = txtBoys_Common_Room_Details.Text,
                Canteen_Cafeteria_Capacity = NumericHandler.ConvertToInteger(txtCanteen_Cafeteria_Capacity.Text),
                Canteen_Caf_for_Staffs_Avail = chkCanteen_Caf_for_Staffs_Avail.Checked ? WebServices.GeneralLandBuildingReference.Canteen_Caf_for_Staffs_Avail.Yes : WebServices.GeneralLandBuildingReference.Canteen_Caf_for_Staffs_Avail.No,
                Central_Library_Available = chkCentralLibraryAvailable.Checked ? WebServices.GeneralLandBuildingReference.Central_Library_Available.Yes : WebServices.GeneralLandBuildingReference.Central_Library_Available.No,
                CoE_Program_Available = chkCoE_Program_Available.Checked ? WebServices.GeneralLandBuildingReference.CoE_Program_Available.Yes : WebServices.GeneralLandBuildingReference.CoE_Program_Available.No,
                CoE_Program_Details = txtCoE_Program_Details.Text,
                Conference_Room_Available = chkConferenceRoomAvailable.Checked ? WebServices.GeneralLandBuildingReference.Conference_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Conference_Room_Available.No,
                CSR_Activities_Available = chkCSR_Activities_Available.Checked ? WebServices.GeneralLandBuildingReference.CSR_Activities_Available.Yes : WebServices.GeneralLandBuildingReference.CSR_Activities_Available.No,
                CSR_Activity_Details = txtCSR_Activity_Details.Text,
                Digital_Library_Available = chkDigitalLibraryAvailable.Checked ? WebServices.GeneralLandBuildingReference.Digital_Library_Available.Yes : WebServices.GeneralLandBuildingReference.Digital_Library_Available.No,
                Dispensary_Available = chkDispensary_Available.Checked ? WebServices.GeneralLandBuildingReference.Dispensary_Available.Yes : WebServices.GeneralLandBuildingReference.Dispensary_Available.No,
                Field_Area_in_Acres = NumericHandler.ConvertToDecimal(txtField_Area_in_Acres.Text),
                Field_Available = chkFieldAvailable.Checked ? WebServices.GeneralLandBuildingReference.Field_Available.Yes : WebServices.GeneralLandBuildingReference.Field_Available.No,
                Field_Gallery_Available = chkFieldGalleryAvailable.Checked ? WebServices.GeneralLandBuildingReference.Field_Gallery_Available.Yes : WebServices.GeneralLandBuildingReference.Field_Gallery_Available.No,
                Floor_size_of_the_Video_conf = NumericHandler.ConvertToDecimal(txtFloor_size_of_the_Video_conf.Text),
                Girls_Common_Room_Available = chkGirls_Common_Room_Available.Checked ? WebServices.GeneralLandBuildingReference.Girls_Common_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Girls_Common_Room_Available.No,
                Girls_Common_Room_Details = txtGirls_Common_Room_Details.Text,
                Internet_Connection_Available = chkInternet_Connection_Available.Checked ? WebServices.GeneralLandBuildingReference.Internet_Connection_Available.Yes : WebServices.GeneralLandBuildingReference.Internet_Connection_Available.No,
                Library_Available = chkLibrary_Available.Checked ? WebServices.GeneralLandBuildingReference.Library_Available.Yes : WebServices.GeneralLandBuildingReference.Library_Available.No,
                Rain_Water_Harvesting_Avail = chkRain_Water_Harvesting_Avail.Checked ? WebServices.GeneralLandBuildingReference.Rain_Water_Harvesting_Avail.Yes : WebServices.GeneralLandBuildingReference.Rain_Water_Harvesting_Avail.No,
                Roof_Top_Solar_Panel_Available = chkRoof_Top_Solar_Panel_Available.Checked ? WebServices.GeneralLandBuildingReference.Roof_Top_Solar_Panel_Available.Yes : WebServices.GeneralLandBuildingReference.Roof_Top_Solar_Panel_Available.No,
                Sewage_Treatment_Plant_Avail = chkSewage_Treatment_Plant_Avail.Checked ? WebServices.GeneralLandBuildingReference.Sewage_Treatment_Plant_Avail.Yes : WebServices.GeneralLandBuildingReference.Sewage_Treatment_Plant_Avail.No,
                Sports_Court_Area_in_Sqft = NumericHandler.ConvertToDecimal(txtSports_Court_Area_in_Sqft.Text),
                Sports_Court_Available = chkSportCourt.Checked ? WebServices.GeneralLandBuildingReference.Sports_Court_Available.Yes : WebServices.GeneralLandBuildingReference.Sports_Court_Available.No,
                Staff_Common_Room_Available = chkStaff_Common_Room_Available.Checked ? WebServices.GeneralLandBuildingReference.Staff_Common_Room_Available.Yes : WebServices.GeneralLandBuildingReference.Staff_Common_Room_Available.No,
                Staff_Common_Room_Details = txtStaff_Common_Room_Details.Text,
                //Uploaded_FileName = txtUploaded_FileName.Text,
                Video_Conference_Room_Avail = chkVideo_Conference_Room_Avail.Checked ? WebServices.GeneralLandBuildingReference.Video_Conference_Room_Avail.Yes : WebServices.GeneralLandBuildingReference.Video_Conference_Room_Avail.No,
                Video_Conference_Room_Capacity = NumericHandler.ConvertToInteger(txtVideo_Conference_Room_Capacity.Text),
                Video_Conference_Room_Location = txtVideo_Conference_Room_Location.Text,
                Year_of_Establis_of_institute = txtYear_of_Establis_of_institute.Text
            };

            var result = ODataServices.CreateGeneralBuildingRecord(obj);
            if (result == ExceptionHelper.SuccessfulMessage)
            {
                chkBoys_Common_Room_Available.Checked = false;
                txtBoys_Common_Room_Details.Text = string.Empty;
                txtCanteen_Cafeteria_Capacity.Text = string.Empty;
                chkCanteen_Caf_for_Staffs_Avail.Checked = false;
                chkCentralLibraryAvailable.Checked = false;
                chkCoE_Program_Available.Checked = false;
                txtCoE_Program_Details.Text = string.Empty;
                chkConferenceRoomAvailable.Checked = false;
                chkCSR_Activities_Available.Checked = false;
                txtCSR_Activity_Details.Text = string.Empty;
                chkDigitalLibraryAvailable.Checked = false;
                chkDispensary_Available.Checked = false;
                txtField_Area_in_Acres.Text = string.Empty;
                chkFieldAvailable.Checked = false;
                chkFieldGalleryAvailable.Checked = false;
                txtFloor_size_of_the_Video_conf.Text = string.Empty;
                chkGirls_Common_Room_Available.Checked = false;
                txtGirls_Common_Room_Details.Text = string.Empty;
                chkInternet_Connection_Available.Checked = false;
                chkLibrary_Available.Checked = false;
                chkRain_Water_Harvesting_Avail.Checked = false;
                chkRoof_Top_Solar_Panel_Available.Checked = false;
                chkSewage_Treatment_Plant_Avail.Checked = false;
                txtSports_Court_Area_in_Sqft.Text = string.Empty;
                chkSportCourt.Checked = false;
                chkStaff_Common_Room_Available.Checked = false;
                txtStaff_Common_Room_Details.Text = string.Empty;
                chkVideo_Conference_Room_Avail.Checked = false;
                txtVideo_Conference_Room_Capacity.Text = string.Empty;
                txtVideo_Conference_Room_Location.Text = string.Empty;
                txtYear_of_Establis_of_institute.Text = string.Empty;

                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }
        }

        protected void GenralUpdateBtn_Click(object sender, EventArgs e)
        {
            var obj = new WebServices.GeneralLandBuildingReference.GeneralLandBuildingCard();
            obj.Key = hdnKey.Value;
            if (chkBoys_Common_Room_Available.Checked)
            {
                obj.Boys_Common_Room_Available = WebServices.GeneralLandBuildingReference.Boys_Common_Room_Available.Yes;
                obj.Boys_Common_Room_Details = txtBoys_Common_Room_Details.Text;
                if (Boys_Common_RoomUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(Boys_Common_RoomUploader.FileName);
                    Boys_Common_RoomUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Boys_Common_Room_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkCanteen_Caf_for_Staffs_Avail.Checked)
            {
                obj.Canteen_Cafeteria_Capacity = NumericHandler.ConvertToInteger(txtCanteen_Cafeteria_Capacity.Text);
                obj.Canteen_Caf_for_Staffs_Avail = WebServices.GeneralLandBuildingReference.Canteen_Caf_for_Staffs_Avail.Yes;
                if (Canteen_CafUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(Canteen_CafUploader.FileName);
                    Canteen_CafUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Staff_Canteena47Cafeteria_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkCentralLibraryAvailable.Checked)
            {
                obj.Central_Library_Available = WebServices.GeneralLandBuildingReference.Central_Library_Available.Yes;
                if (CentralLibraryFileUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(CentralLibraryFileUploader.FileName);
                    CentralLibraryFileUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Central_Library_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkCoE_Program_Available.Checked)
            {
                obj.CoE_Program_Available = WebServices.GeneralLandBuildingReference.CoE_Program_Available.Yes;
                obj.CoE_Program_Details = txtCoE_Program_Details.Text;
            }
            if (chkConferenceRoomAvailable.Checked)
            {
                obj.Conference_Room_Available = WebServices.GeneralLandBuildingReference.Conference_Room_Available.Yes;
                if (conferenceRoomFileUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(conferenceRoomFileUploader.FileName);
                    conferenceRoomFileUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Conference_Room_photo(uploadedResult.ServicePath);
                }
            }
            if (chkCSR_Activities_Available.Checked)
            {
                obj.CSR_Activities_Available = WebServices.GeneralLandBuildingReference.CSR_Activities_Available.Yes;
                obj.CSR_Activity_Details = txtCSR_Activity_Details.Text;
            }
            if (chkDigitalLibraryAvailable.Checked)
            {
                obj.Digital_Library_Available = WebServices.GeneralLandBuildingReference.Digital_Library_Available.Yes;
            }
            if (chkDispensary_Available.Checked)
            {
                obj.Dispensary_Available = WebServices.GeneralLandBuildingReference.Dispensary_Available.Yes;
                if (DispensaryAvailableUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(FileAvailablepdfUploader.FileName);
                    DispensaryAvailableUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Dispensary_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkFieldAvailable.Checked)
            {
                obj.Field_Area_in_Acres = NumericHandler.ConvertToDecimal(txtField_Area_in_Acres.Text);
                obj.Field_Available = WebServices.GeneralLandBuildingReference.Field_Available.Yes;
                if (FileAvailablepdfUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(FileAvailablepdfUploader.FileName);
                    FileAvailablepdfUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Field_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkFieldGalleryAvailable.Checked)
            {
                obj.Field_Gallery_Available = WebServices.GeneralLandBuildingReference.Field_Gallery_Available.Yes;
                if (fieldGalleryFileUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(fieldGalleryFileUploader.FileName);
                    fieldGalleryFileUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Field_Gallery_photo(uploadedResult.ServicePath);
                }
            }
            if (chkGirls_Common_Room_Available.Checked)
            {
                obj.Girls_Common_Room_Available = WebServices.GeneralLandBuildingReference.Girls_Common_Room_Available.Yes;
                obj.Girls_Common_Room_Details = txtGirls_Common_Room_Details.Text;
                if (girlsCommonRoomAvailableUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(girlsCommonRoomAvailableUploader.FileName);
                    girlsCommonRoomAvailableUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Girls_Common_Room_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkInternet_Connection_Available.Checked)
            {
                obj.Internet_Connection_Available = WebServices.GeneralLandBuildingReference.Internet_Connection_Available.Yes;
            }
            if (chkLibrary_Available.Checked)
            {
                obj.Library_Available = WebServices.GeneralLandBuildingReference.Library_Available.Yes;
                if (Library_AvailableFileUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(Library_AvailableFileUploader.FileName);
                    Library_AvailableFileUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Library_Photos(uploadedResult.ServicePath);
                }
            }
            if (chkRain_Water_Harvesting_Avail.Checked)
            {
                obj.Rain_Water_Harvesting_Avail = WebServices.GeneralLandBuildingReference.Rain_Water_Harvesting_Avail.Yes;
            }
            if (chkRoof_Top_Solar_Panel_Available.Checked)
            {
                obj.Roof_Top_Solar_Panel_Available = WebServices.GeneralLandBuildingReference.Roof_Top_Solar_Panel_Available.Yes;
            }
            if (chkSewage_Treatment_Plant_Avail.Checked)
            {
                obj.Sewage_Treatment_Plant_Avail = WebServices.GeneralLandBuildingReference.Sewage_Treatment_Plant_Avail.Yes;
            }
            if (chkSportCourt.Checked)
            {
                obj.Sports_Court_Area_in_Sqft = NumericHandler.ConvertToDecimal(txtSports_Court_Area_in_Sqft.Text);
                obj.Sports_Court_Available = WebServices.GeneralLandBuildingReference.Sports_Court_Available.Yes;
                if (SportCourtFileUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(SportCourtFileUploader.FileName);
                    SportCourtFileUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Sports_Court_photo(uploadedResult.ServicePath);
                }
            }
            if (chkStaff_Common_Room_Available.Checked)
            {
                obj.Staff_Common_Room_Available = WebServices.GeneralLandBuildingReference.Staff_Common_Room_Available.Yes;
                obj.Staff_Common_Room_Details = txtStaff_Common_Room_Details.Text;
                if (StaffCommonRoomAvailableUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(StaffCommonRoomAvailableUploader.FileName);
                    StaffCommonRoomAvailableUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Staff_Common_Room_Photos(uploadedResult.ServicePath);
                }
            }
            if (mainEntranceUploader.HasFile)
            {
                obj.Uploaded_FileName = mainEntranceUploader.FileName;
                var uploadedResult = GenerateUploadPath(mainEntranceUploader.FileName);
                mainEntranceUploader.SaveAs(uploadedResult.Path);
                ODataServices.Upload_GB_Main_Entrance_Photos(uploadedResult.ServicePath);
            }
            if (chkVideo_Conference_Room_Avail.Checked)
            {
                obj.Video_Conference_Room_Avail = WebServices.GeneralLandBuildingReference.Video_Conference_Room_Avail.Yes;
                obj.Video_Conference_Room_Capacity = NumericHandler.ConvertToInteger(txtVideo_Conference_Room_Capacity.Text);
                obj.Video_Conference_Room_Location = txtVideo_Conference_Room_Location.Text;
                obj.Floor_size_of_the_Video_conf = NumericHandler.ConvertToDecimal(txtFloor_size_of_the_Video_conf.Text);
                if (VideoConferenceRoomUploader.HasFile)
                {
                    var uploadedResult = GenerateUploadPath(VideoConferenceRoomUploader.FileName);
                    VideoConferenceRoomUploader.SaveAs(uploadedResult.Path);
                    ODataServices.Upload_GB_Video_Conference_Room_photo(uploadedResult.ServicePath);
                }
            }
            obj.Year_of_Establis_of_institute = txtYear_of_Establis_of_institute.Text;

            var result = ODataServices.UpdateGeneralBuildingRecord(obj);
            if (result == ExceptionHelper.UpdateMessage)
            {
                Alert.ShowAlert(this, "s", result);
            }
            else
            {
                Alert.ShowAlert(this, "e", result);
            }

        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            string FileName = "GeneralBuilding.XLS";
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + ODataServices.Downlond_GeneralLand_Building_File(string.Empty).Split(Path.DirectorySeparatorChar)[5];
            WebClient wc = new WebClient();
            byte[] buffer = wc.DownloadData(exportedFilePath);

            var fileName = "attachment; filename=" + FileName;
            base.Response.ClearContent();
            base.Response.AddHeader("content-disposition", fileName);
            base.Response.ContentType = "application/vnd.ms-excel";
            base.Response.BinaryWrite(buffer);
            base.Response.End();
        }

        public UploadedResult GenerateUploadPath(string fileName)
        {
            string fileExtention = Path.GetExtension(fileName);
            string finalFileName = Path.GetFileNameWithoutExtension(new string(fileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (Directory.Exists(path))
            {
                path = Path.Combine(path, finalFileName);
            }
            string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
            return new UploadedResult { Path = path, ServicePath = servicePath };
        }

        protected void fileAvailableUpload_Click(object sender, EventArgs e)
        {
            if (FileAvailablepdfUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(FileAvailablepdfUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(FileAvailablepdfUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    FileAvailablepdfUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Field_Photos(servicePath);
            }
        }

        protected void btnFileAvailableDownload_Click(object sender, EventArgs e)
        {
            string FileName = "Field_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Field_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void SportCourtFileUploadButton_Click(object sender, EventArgs e)
        {
            if (SportCourtFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(SportCourtFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(SportCourtFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    SportCourtFileUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Sports_Court_photo(servicePath);
            }
        }

        protected void SportCourtDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Sports_Court" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Sports_Court_photo();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void fieldGalleryFileUploadButton_Click(object sender, EventArgs e)
        {
            if (fieldGalleryFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(fieldGalleryFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(fieldGalleryFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    fieldGalleryFileUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Field_Gallery_photo(servicePath);
            }
        }

        protected void fieldGalleryDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Field_Gallery" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Field_Gallery_photo();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void conferenceRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (conferenceRoomFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(conferenceRoomFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(conferenceRoomFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    conferenceRoomFileUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Conference_Room_photo(servicePath);
            }
        }

        protected void conferenceRoomDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Conference_Room" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Conference_Room_photo();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void videoConferenceRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (VideoConferenceRoomUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(VideoConferenceRoomUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(VideoConferenceRoomUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    VideoConferenceRoomUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Video_Conference_Room_photo(servicePath);
            }
        }

        protected void VideoConferenceRoomDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Video_Conference" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Video_Conference_Room_photo();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void Library_AvailableUploadButton_Click(object sender, EventArgs e)
        {
            if (Library_AvailableFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(Library_AvailableFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(Library_AvailableFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    Library_AvailableFileUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Library_Photos(servicePath);
            }
        }

        protected void Library_AvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Library_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Library_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void CentralLibraryUploadButton_Click(object sender, EventArgs e)
        {
            if (CentralLibraryFileUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(CentralLibraryFileUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(CentralLibraryFileUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    CentralLibraryFileUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Central_Library_Photos(servicePath);
            }
        }

        protected void CentralLibraryDowloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Library_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Central_Library_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void mainEntranceUploadButton_Click(object sender, EventArgs e)
        {
            if (mainEntranceUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(mainEntranceUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(mainEntranceUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    mainEntranceUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Main_Entrance_Photos(servicePath);
            }
        }

        protected void mainEntranceDownButton_Click(object sender, EventArgs e)
        {
            string FileName = "Main_Entrance" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Main_Entrance_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void DispensaryAvailableUploadButton_Click(object sender, EventArgs e)
        {
            if (DispensaryAvailableUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(DispensaryAvailableUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(DispensaryAvailableUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    DispensaryAvailableUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Dispensary_Photos(servicePath);
            }
        }

        protected void DispensaryAvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Dispensary_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Dispensary_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void StaffCommonRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (StaffCommonRoomAvailableUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(StaffCommonRoomAvailableUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(StaffCommonRoomAvailableUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    StaffCommonRoomAvailableUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Staff_Common_Room_Photos(servicePath);
            }
        }

        protected void StaffCommonRoomAvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Staff_Common_Room_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Staff_Common_Room_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void girlsCommonRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (girlsCommonRoomAvailableUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(girlsCommonRoomAvailableUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(girlsCommonRoomAvailableUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    girlsCommonRoomAvailableUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Girls_Common_Room_Photos(servicePath);
            }
        }

        protected void girlsCommonRoomAvailableDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Girls_Common_Room_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Girls_Common_Room_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void BoysCommonRoomUploadButton_Click(object sender, EventArgs e)
        {
            if (Boys_Common_RoomUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(Boys_Common_RoomUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(Boys_Common_RoomUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    Boys_Common_RoomUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Boys_Common_Room_Photos(servicePath);
            }
        }

        protected void Boys_Common_RoomDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Boys_Common_Room_Photos" + "_" + ".pdf";
            string bcPath = ODataServices.Downlond_GB_Boys_Common_Room_Photos();
            if (!string.IsNullOrEmpty(bcPath))
            {
                string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + StringHelper.GetFileNameFromURL(bcPath);
                WebClient wc = new WebClient();
                byte[] buffer = wc.DownloadData(exportedFilePath);

                var fileName = "attachment; filename=" + FileName;
                base.Response.ClearContent();
                base.Response.AddHeader("content-disposition", fileName);
                base.Response.ContentType = "application/pdf";
                base.Response.BinaryWrite(buffer);
                base.Response.End();
            }
            else
            {
                Alert.ShowAlert(this, "e", "No file found. Please upload a file");
            }
        }

        protected void Canteen_CafUploadButton_Click(object sender, EventArgs e)
        {
            if (Canteen_CafUploader.HasFile)
            {
                string fileExtention = Path.GetExtension(Canteen_CafUploader.FileName);
                string finalFileName = Path.GetFileNameWithoutExtension(new string(Canteen_CafUploader.FileName.Take(10).ToArray())) + "_" + DateTime.Now.ToString("dd MMM yyyy") + fileExtention;
                string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("./" + "PDF" + "/"));
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                if (Directory.Exists(path))
                {
                    path = Path.Combine(path, finalFileName);
                    Canteen_CafUploader.SaveAs(path);
                }
                string servicePath = @"\\genesisnav16\PORTAL\PDF\" + finalFileName;
                ODataServices.Upload_GB_Staff_Canteena47Cafeteria_Photos(servicePath);
            }
        }

        protected void Canteen_CafDownloadButton_Click(object sender, EventArgs e)
        {
            string FileName = "Staff_Canteena_Cafeteria_Photos" + "_" + ".pdf";
            string exportedFilePath = ConfigurationManager.AppSettings["LandandBuildingTemplatePath"].ToString() + ODataServices.Downlond_GB_Staff_Canteena47Cafeteria_Photos().Split(Path.DirectorySeparatorChar)[5];
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

    public class UploadedResult
    {
        public string Path { get; set; }
        public string ServicePath { get; set; }
    }
}