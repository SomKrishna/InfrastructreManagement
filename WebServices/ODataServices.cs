using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.Helper;

namespace WebServices
{
    public class ODataServices
    {
        public static List<Infra.LandDetailList> GetLandDetailList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.LandDetailList> q = container.CreateQuery<Infra.LandDetailList>("LandDetailList").ToList();

            return q;
        }

        public static List<Infra.AuditoriumBuilding> GetAuditoriumList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.AuditoriumBuilding> q = container.CreateQuery<Infra.AuditoriumBuilding>("AuditoriumBuilding").ToList();

            return q;
        }

        public static string CreateAuditorium(AuditoriumReference.AuditoriumBuilding obj)
        {
            try
            {
                AuditoriumReference.AuditoriumBuilding_Service _obj_Binding = (AuditoriumReference.AuditoriumBuilding_Service)Configuration.getNavService(new AuditoriumReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateAuditorium(AuditoriumReference.AuditoriumBuilding input)
        {
            try
            {
                AuditoriumReference.AuditoriumBuilding_Service _obj_Binding = (AuditoriumReference.AuditoriumBuilding_Service)Configuration.getNavService(new AuditoriumReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page");
                AuditoriumReference.AuditoriumBuilding obj = new AuditoriumReference.AuditoriumBuilding();
                List<Infra.AuditoriumBuilding> objList = GetAuditoriumList().Where(x => string.Equals(x.Building_Code, input.Building_Code, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Building_Code);

                obj.Total_Capacity = input.Total_Capacity;
                obj.Total_Floor_Area_in_sqft = input.Total_Floor_Area_in_sqft;
                obj.Building_Length = input.Building_Length;
                obj.Building_Breadth_in_Meter = input.Building_Breadth_in_Meter;
                obj.Building_Height = input.Building_Height;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Approval_Status = input.Approval_Status;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Building_Safety_Status = input.Building_Safety_Status;

                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static Infra.AuditoriumBuilding GetAuditorium(string buildingCode)
        {
            AuditoriumReference.AuditoriumBuilding_Service _obj_Binding = (AuditoriumReference.AuditoriumBuilding_Service)Configuration.getNavService(new AuditoriumReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page");
            AuditoriumReference.AuditoriumBuilding obj = new AuditoriumReference.AuditoriumBuilding();
            List<Infra.AuditoriumBuilding> objList = GetAuditoriumList().Where(x => string.Equals(x.Building_Code, buildingCode, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();
        }

        public static void ImportLandFile(string filePathWithName)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.ImportLandFile(Path.Combine(filePathWithName));
        }

        public static string ExportLandFile()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportLandDataDetails();
        }

        public static void ImportPdfRoRFile(string khatianNumber, string filePath)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_Land_File(khatianNumber, filePath);
        }

        public static string ExportLandFileInPdf(string khatianNumber)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            var returnValue = obj.Download_Land_File(khatianNumber);
            return returnValue;
        }

        #region Building Master Plan files
        public static string Download_Auditorium_Building_File(string buildingCode)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            var returnValue = obj.Download_Auditorium_Building_File(buildingCode);
            return returnValue;
        }

        public static string Download_Hostel_Building_File(string blockCode)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            var returnValue = obj.Download_Hostel_Building_File(blockCode);
            return returnValue;
        }

        public static string Download_Institutional_File(string blockCode)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            var returnValue = obj.Download_Institutional_File(blockCode);
            return returnValue;
        }

        public static string Download_Staff_Building_File(string blockCode)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            var returnValue = obj.Download_Staff_Building_File(blockCode);
            return returnValue;
        }

        public static string Downlond_GeneralLand_Building_File(string primaryKey)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            var returnValue = obj.Downlond_GeneralLand_Building_File(primaryKey);
            return returnValue;
        }

        public static void Upload_Auditorium_Buliding_File(string buildingCode, string fileName)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_Auditorium_Buliding_File(buildingCode, fileName);
        }

        public static void Upload_Hostel_Buliding_File(string blockCode, string fileName)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_Hostel_Buliding_File(blockCode, fileName);
        }

        public static void Upload_Institute_Buliding_File(string blockCode, string fileName)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_Institute_Buliding_File(blockCode, fileName);
        }

        public static void Upload_Staff_Buliding_File(string quarterCode, string fileName)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_Staff_Buliding_File(quarterCode, fileName);
        }

        public static void Upload_GeneralLand_Buliding_File(string primaryKey, string fileName)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_GeneralLand_Buliding_File(primaryKey, fileName);
        }
        #endregion
        public static string ExportInstitutionalBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportInstitutionalBuilding();
        }
        public static string ExportHostelBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportHostelBuilding();
        }
        public static string ExportStaffQuarter()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportStaffBuilding();
        }

        public static string ExportAuditoriumBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportAuditoriumBuilding();
        }

        public static string DownloadProjectFile(int projectType, string projectCode)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.Download_Project_File(projectType, projectCode);
        }

        public static void UploadProjectFile(int projectType, string projectCode, string filePath)
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            obj.Upload_Project_File(projectType, projectCode, filePath);
        }

        public static string ExportSecurityFile()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportServiceMonitoring();
        }

        public static string ExportAMCAndMaintenanceFile()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportMaintanenceAndAMC();
        }

        #region DTET services
        public static string ExportDTETEstimatePreparationMonitoring()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETEstimatePreparationMonitoring();
        }

        public static string ExportDTETAuditoriumBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETAuditoriumBuilding();
        }

        public static string ExportDTETHostelBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETHostelBuilding();
        }

        public static string ExportDTETInstitutionalBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETInstitutionalBuilding();
        }

        public static string ExportDTETStaffBuilding()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETStaffBuilding();
        }

        public static string ExportDTETLandDataDetails()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETLandDataDetails();
        }

        public static string ExportDTETMaintanenceAndAMC()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETMaintanenceAndAMC();
        }

        public static string ExportDTETProjectProgressDetails()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETProjectProgressDetails();
        }

        public static string ExportDTETServiceMonitoring()
        {
            CodeUnitReference.InfraCodeunit obj = new CodeUnitReference.InfraCodeunit();
            obj = (CodeUnitReference.InfraCodeunit)Configuration.getNavService(new CodeUnitReference.InfraCodeunit(), "InfraCodeunit", "Codeunit");
            return obj.ExportDTETServiceMonitoring();
        }
        #endregion
        public static string CreateInstituteBuilding(InstituteReference.InstituteBuildingCard obj)
        {
            try
            {
                InstituteReference.InstituteBuildingCard_Service _obj_Binding = (InstituteReference.InstituteBuildingCard_Service)Configuration.getNavService(new InstituteReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Infra.InstituteBuildingsList> GetInstituteBuildings()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.InstituteBuildingsList> q = container.CreateQuery<Infra.InstituteBuildingsList>("InstituteBuildingsList").ToList();

            return q;
        }

        public static string UpdateInstituteBuilding(InstituteReference.InstituteBuildingCard input)
        {
            try
            {
                InstituteReference.InstituteBuildingCard_Service _obj_Binding = (InstituteReference.InstituteBuildingCard_Service)Configuration.getNavService(new InstituteReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page");
                InstituteReference.InstituteBuildingCard obj = new InstituteReference.InstituteBuildingCard();
                List<Infra.InstituteBuildingsList> objList = GetInstituteBuildings().Where(x => string.Equals(x.Block_Code, input.Block_Code, StringComparison.OrdinalIgnoreCase)).ToList();


                obj = _obj_Binding.Read(input.Block_Code);

                obj.Block_Type_if_any = input.Block_Type_if_any;
                obj.No_Of_Class_Room = input.No_Of_Class_Room;
                obj.Total_Floor_Area_in_sqft = input.Total_Floor_Area_in_sqft;
                obj.Building_Width_in_meter = input.Building_Width_in_meter;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Source_Of_Water = input.Source_Of_Water;
                obj.PHD_Consumer_No = input.PHD_Consumer_No;
                obj.Block_Name_if_any = input.Block_Name_if_any;
                obj.No_Of_Floor = input.No_Of_Floor;
                obj.Building_Length_in_meter = input.Building_Length_in_meter;
                obj.Building_Height_in_meter = input.Building_Height_in_meter;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Approval_Status = input.Approval_Status;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Transformer_Type = input.Transformer_Type;
                obj.Building_Safety_Status = input.Building_Safety_Status;
                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static Infra.InstituteBuildingsList GetInstituteBuilding(string blockCode)
        {
            InstituteReference.InstituteBuildingCard_Service _obj_Binding = (InstituteReference.InstituteBuildingCard_Service)Configuration.getNavService(new InstituteReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page");
            InstituteReference.InstituteBuildingCard obj = new InstituteReference.InstituteBuildingCard();
            List<Infra.InstituteBuildingsList> objList = GetInstituteBuildings().Where(x => string.Equals(x.Block_Code, blockCode, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();
        }

        public static string CreateHostelBuilding(HostelReference.HostelBuildingCard obj)
        {
            try
            {
                HostelReference.HostelBuildingCard_Service _obj_Binding = (HostelReference.HostelBuildingCard_Service)Configuration.getNavService(new HostelReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page");
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Infra.HostelBuildingsList> GetHostelBuildings()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.HostelBuildingsList> q = container.CreateQuery<Infra.HostelBuildingsList>("HostelBuildingsList").ToList();

            return q;
        }

        public static Infra.HostelBuildingsList GetHostelBuilding(string blockCode)
        {
            HostelReference.HostelBuildingCard_Service _obj_Binding = (HostelReference.HostelBuildingCard_Service)Configuration.getNavService(new HostelReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page");
            HostelReference.HostelBuildingCard obj = new HostelReference.HostelBuildingCard();
            List<Infra.HostelBuildingsList> objList = GetHostelBuildings().Where(x => string.Equals(x.Block_Code, blockCode, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();

        }

        public static string UpdateHostelBuilding(HostelReference.HostelBuildingCard input)
        {
            try
            {
                HostelReference.HostelBuildingCard_Service _obj_Binding = (HostelReference.HostelBuildingCard_Service)Configuration.getNavService(new HostelReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page");
                HostelReference.HostelBuildingCard obj = new HostelReference.HostelBuildingCard();
                List<Infra.HostelBuildingsList> objList = GetHostelBuildings().Where(x => string.Equals(x.Block_Code, input.Block_Code, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Block_Code);

                obj.Hostel_Type = input.Hostel_Type;
                obj.Block_Name = input.Block_Name;
                obj.No_Of_Room = input.No_Of_Room;
                obj.No_Of_Floor = input.No_Of_Floor;
                obj.Total_Capacity = input.Total_Capacity;
                obj.Building_Length = input.Building_Length;
                obj.Building_Breadth_in_meter = input.Building_Breadth_in_meter;
                obj.Building_Height = input.Building_Height;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Approval_Status = input.Approval_Status;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Source_Of_Water = input.Source_Of_Water;
                obj.Transformer_Type = input.Transformer_Type;
                obj.PHD_Consumer_No = input.PHD_Consumer_No;
                obj.Building_Safety_Status = input.Building_Safety_Status;
                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateStaffQuarter(StaffReference.StaffQuarterCard obj)
        {
            try
            {
                StaffReference.StaffQuarterCard_Service _obj_Binding = (StaffReference.StaffQuarterCard_Service)Configuration.getNavService(new StaffReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Infra.StaffQuartersList> GetStaffQuarters()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.StaffQuartersList> q = container.CreateQuery<Infra.StaffQuartersList>("StaffQuartersList").ToList();

            return q;
        }

        public static Infra.StaffQuartersList GetStaffQuarter(string quaterNo)
        {
            StaffReference.StaffQuarterCard_Service _obj_Binding = (StaffReference.StaffQuarterCard_Service)Configuration.getNavService(new StaffReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page");
            StaffReference.StaffQuarterCard obj = new StaffReference.StaffQuarterCard();
            List<Infra.StaffQuartersList> objList = GetStaffQuarters().Where(x => string.Equals(x.Quarter_Code, quaterNo, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();
        }

        public static string UpdateStaffQuarter(StaffReference.StaffQuarterCard input)
        {
            try
            {
                StaffReference.StaffQuarterCard_Service _obj_Binding = (StaffReference.StaffQuarterCard_Service)Configuration.getNavService(new StaffReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page");
                StaffReference.StaffQuarterCard obj = new StaffReference.StaffQuarterCard();
                List<Infra.StaffQuartersList> objList = GetStaffQuarters().Where(x => string.Equals(x.Quarter_Code, input.Quarter_Code, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Quarter_Code);

                //obj.Quarter_Code = txtStaffQuarterCode.Text,//need to decide 
                obj.Quarter_Type = input.Quarter_Type;
                obj.Quarter_Block_Name = input.Quarter_Block_Name;
                obj.No_Of_Room = input.No_Of_Room;
                obj.No_Of_Floor = input.No_Of_Floor;
                obj.Total_Floor_Area_in_sqft = input.Total_Floor_Area_in_sqft;
                //obj.capacity = Convert.ToInt32(txtStaffHostelCapacity.Text),
                obj.Building_Length = input.Building_Length;
                obj.Building_Breadth_in_Meter = input.Building_Breadth_in_Meter;
                obj.Building_Height = input.Building_Height;
                obj.Fire_Safety_Status = input.Fire_Safety_Status;
                obj.Fire_Safety_Valid_Upto = input.Fire_Safety_Valid_Upto;
                obj.Electricity_Connection_Status = input.Electricity_Connection_Status;
                obj.Layout_Plan_No = input.Layout_Plan_No;
                obj.Approval_Status = input.Approval_Status;
                obj.Electricity_Agency = input.Electricity_Agency;
                obj.Book_Of_Account = input.Book_Of_Account;
                obj.Electricity_Load_in_KW = input.Electricity_Load_in_KW;
                obj.Electricity_Consumer_No = input.Electricity_Consumer_No;
                obj.Source_Of_Water = input.Source_Of_Water;
                obj.Transformer_Type = input.Transformer_Type;
                obj.PHD_Consumer_No = input.PHD_Consumer_No;
                obj.Building_Safety_Status = input.Building_Safety_Status;
                obj.Occupancy_Status = input.Occupancy_Status;

                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Infra.NewProjectDetails> GetAllNewProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.NewProjectDetails> q = container.CreateQuery<Infra.NewProjectDetails>("NewProjectDetails").ToList();

            return q;
        }

        public static List<Infra.AllProjectList> GetAllProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.AllProjectList> q = container.CreateQuery<Infra.AllProjectList>("AllProjectList").ToList();

            return q;
        }

        public static string CreateNewProject(NewProjectReference.Newprojectcard obj)
        {
            try
            {
                NewProjectReference.Newprojectcard_Service _obj_Binding = (NewProjectReference.Newprojectcard_Service)Configuration.getNavService(new NewProjectReference.Newprojectcard_Service(), "Newprojectcard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateImprovementProject(ImprovementProjectReference.Improvementprojectcard obj)
        {
            try
            {
                ImprovementProjectReference.Improvementprojectcard_Service _obj_Binding = (ImprovementProjectReference.Improvementprojectcard_Service)Configuration.getNavService(new ImprovementProjectReference.Improvementprojectcard_Service(), "Improvementprojectcard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateOngoingProject(OngoingProjectReference.Ongoingprojectcard obj)
        {
            try
            {
                OngoingProjectReference.Ongoingprojectcard_Service _obj_Binding = (OngoingProjectReference.Ongoingprojectcard_Service)Configuration.getNavService(new OngoingProjectReference.Ongoingprojectcard_Service(), "Ongoingprojectcard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Infra.Ongoingprojectcard> GetOnGoingTypeProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.Ongoingprojectcard> q = container.CreateQuery<Infra.Ongoingprojectcard>("Ongoingprojectcard").ToList();

            return q;
        }

        public static List<Infra.Improvementprojectcard> GetImprovementTypeProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.Improvementprojectcard> q = container.CreateQuery<Infra.Improvementprojectcard>("Improvementprojectcard").ToList();

            return q;
        }

        public static List<Infra.Institutelist> GetAllInstitutes()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.Institutelist> q = container.CreateQuery<Infra.Institutelist>("Institutelist").ToList();

            return q;
        }

        public static List<Infra.Districtlist> GetAllDistricts()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.Districtlist> q = container.CreateQuery<Infra.Districtlist>("Districtlist").ToList();

            return q;
        }

        public static List<Infra.Projectprogressdetailscard> GetAllProjectProgress()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.Projectprogressdetailscard> q = container.CreateQuery<Infra.Projectprogressdetailscard>("Projectprogressdetailscard").ToList();

            return q;
        }

        public static List<Infra.Projectprogressdetailscard> GetProjectProgressByProjectCode(string projectCode)
        {
            ProjectProgressReference.Projectprogressdetailscard_Service _obj_Binding = (ProjectProgressReference.Projectprogressdetailscard_Service)Configuration.getNavService(new ProjectProgressReference.Projectprogressdetailscard_Service(), "Projectprogressdetailscard", "Page");
            ProjectProgressReference.Projectprogressdetailscard obj = new ProjectProgressReference.Projectprogressdetailscard();
            List<Infra.Projectprogressdetailscard> objList = GetAllProjectProgress().Where(x => string.Equals(x.Project_Code, projectCode, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList;
        }

        public static string AddProjectProgressDeatils(ProjectProgressReference.Projectprogressdetailscard input)
        {
            try
            {
                var result = string.Empty;
                var obj = GetAllProjectProgress().Where(x => string.Equals(x.AA_No, input.AA_No, StringComparison.OrdinalIgnoreCase)).ToList();

                if (obj != null && obj.Count > 0)
                {
                    result = UpdateProjectProgressDetails(input);
                }
                else
                {
                    result = CreateProjectProgress(input);
                }

                return result;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateProjectProgressDetails(ProjectProgressReference.Projectprogressdetailscard input)
        {
            try
            {
                ProjectProgressReference.Projectprogressdetailscard_Service _obj_Binding = (ProjectProgressReference.Projectprogressdetailscard_Service)Configuration.getNavService(new ProjectProgressReference.Projectprogressdetailscard_Service(), "Projectprogressdetailscard", "Page");
                ProjectProgressReference.Projectprogressdetailscard obj = new ProjectProgressReference.Projectprogressdetailscard();
                List<Infra.Projectprogressdetailscard> objList = GetAllProjectProgress().Where(x => string.Equals(x.AA_No, input.AA_No, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Project_Type.ToString(), input.Project_Code);

                obj.AA_No = input.AA_No;
                obj.AA_date = input.AA_date;
                obj.Amount_of_AA_accorded = input.Amount_of_AA_accorded;
                obj.Agreement_Value_with_GST_in_Lakh = input.Agreement_Value_with_GST_in_Lakh;
                obj.Running_FY_expenditure_in_Lakh = input.Running_FY_expenditure_in_Lakh;
                obj.Expenditure_made_as_on_31_march_of_Last_FY_in_Lakh = input.Expenditure_made_as_on_31_march_of_Last_FY_in_Lakh;
                obj.Balance_fund_required_for_commencement_of_Work_in_Running_FY_in_Lakh = input.Balance_fund_required_for_commencement_of_Work_in_Running_FY_in_Lakh;
                obj.Balance_fund_requried_for_completion_of_work_in_Running_FY_in_Lakh = input.Balance_fund_requried_for_completion_of_work_in_Running_FY_in_Lakh;
                obj.Present_status = input.Present_status;
                obj.Expected_date_for_completion = input.Expected_date_for_completion;
                obj.Reason_for_delayif_delayed = input.Reason_for_delayif_delayed;
                obj.Tender_Variation = input.Tender_Variation;
                obj.Percentage_of_work_completion = input.Percentage_of_work_completion;
                obj.Fund_now_proposed_for_release_in_Running_FY_in = input.Fund_now_proposed_for_release_in_Running_FY_in;
                obj.UC_status = input.UC_status;

                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateProjectProgress(ProjectProgressReference.Projectprogressdetailscard obj)
        {
            try
            {
                ProjectProgressReference.Projectprogressdetailscard_Service _obj_Binding = (ProjectProgressReference.Projectprogressdetailscard_Service)Configuration.getNavService(new ProjectProgressReference.Projectprogressdetailscard_Service(), "Projectprogressdetailscard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateProjectEstimate(EstimatePrepReference.EstimatePrepCard obj)
        {
            try
            {
                EstimatePrepReference.EstimatePrepCard_Service _obj_Binding = (EstimatePrepReference.EstimatePrepCard_Service)Configuration.getNavService(new EstimatePrepReference.EstimatePrepCard_Service(), "EstimatePrepCard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateSecurityService(ServiceCardReference.ServiceCard obj)
        {
            try
            {
                ServiceCardReference.ServiceCard_Service _obj_Binding = (ServiceCardReference.ServiceCard_Service)Configuration.getNavService(new ServiceCardReference.ServiceCard_Service(), "ServiceCard", "Page");
                _obj_Binding.Create(ref obj);
                return ExceptionHelper.SuccessfulMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string CreateMaintainceAndAMC(AMCCardReference.AMCCard obj)
        {
            try
            {
                AMCCardReference.AMCCard_Service _obj_Binding = (AMCCardReference.AMCCard_Service)Configuration.getNavService(new AMCCardReference.AMCCard_Service(), "AMCCard", "Page");
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<Infra.VendorList> GetVendorList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.VendorList> q = container.CreateQuery<Infra.VendorList>("VendorList").ToList();

            return q;
        }

        public static List<Infra.ItemList> GetItemList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.ItemList> q = container.CreateQuery<Infra.ItemList>("ItemList").ToList();

            return q;
        }

        public static List<Infra.ServiceList> GetSecurityServiceList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.ServiceList> q = container.CreateQuery<Infra.ServiceList>("ServiceList").ToList();

            return q;
        }

        public static List<Infra.AMCList> GetAMCList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.AMCList> q = container.CreateQuery<Infra.AMCList>("AMCList").ToList();

            return q;
        }

        public static string CreateLandRecord(LandReference.LandCard obj)
        {
            try
            {
                LandReference.LandCard_Service _obj_Binding = (LandReference.LandCard_Service)Configuration.getNavService(new LandReference.LandCard_Service(), "LandCard", "Page");
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateLandRecord(LandReference.LandCard input)
        {
            try
            {
                LandReference.LandCard_Service _obj_Binding = (LandReference.LandCard_Service)Configuration.getNavService(new LandReference.LandCard_Service(), "LandCard", "Page");
                LandReference.LandCard obj = new LandReference.LandCard();
                //List<Infra.LandDetailList> objList = GetLandDetailList().Where(x => string.Equals(x.Khatian_Serial_No, input.Khatian_Serial_No, StringComparison.OrdinalIgnoreCase)).ToList();

                obj = _obj_Binding.Read(input.Khatian_Serial_No.ToString());

                obj.Land_Kisam = input.Land_Kisam;
                obj.Plot_No = input.Plot_No;
                obj.District = input.District;
                obj.Tahasil = input.Tahasil;
                obj.Village = input.Village;
                obj.RI_Circle = input.RI_Circle;
                obj.Land_Owner_Details = input.Land_Owner_Details;
                obj.Land_possessioner_Details = input.Land_possessioner_Details;
                obj.Land_Issue_Description = input.Land_Issue_Description;
                obj.Encroachment_Plot_No = input.Encroachment_Plot_No;
                obj.Encroachment_Plot_Area = input.Encroachment_Plot_Area;
                obj.Dispute_Plot_No = input.Dispute_Plot_No;
                obj.Dispute_Area = input.Dispute_Area;
                obj.CasePlot_No = input.CasePlot_No;

                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static IList<Infra.GeneralLandBuildingList> GetGeneralLandBuildingList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new Infra.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<Infra.GeneralLandBuildingList> q = container.CreateQuery<Infra.GeneralLandBuildingList>("GeneralLandBuildingList").ToList();

            return q;
        }


        public static string CreateGeneralBuildingRecord(GeneralLandBuildingReference.GeneralLandBuildingCard obj)
        {
            try
            {
                GeneralLandBuildingReference.GeneralLandBuildingCard_Service _obj_Binding = (GeneralLandBuildingReference.GeneralLandBuildingCard_Service)Configuration.getNavService(new GeneralLandBuildingReference.GeneralLandBuildingCard_Service(), "GeneralLandBuildingCard", "Page");
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static string UpdateGeneralBuildingRecord(GeneralLandBuildingReference.GeneralLandBuildingCard input)
        {
            try
            {
                GeneralLandBuildingReference.GeneralLandBuildingCard_Service _obj_Binding = (GeneralLandBuildingReference.GeneralLandBuildingCard_Service)Configuration.getNavService(new GeneralLandBuildingReference.GeneralLandBuildingCard_Service(), "GeneralLandBuildingCard", "Page");
                GeneralLandBuildingReference.GeneralLandBuildingCard obj = new GeneralLandBuildingReference.GeneralLandBuildingCard();
                var recId = _obj_Binding.GetRecIdFromKey(input.Key);
                obj = _obj_Binding.ReadByRecId(recId);
                //obj.Key = string.Empty;
                obj.Boys_Common_Room_Available = input.Boys_Common_Room_Available;
                obj.Boys_Common_Room_Details = input.Boys_Common_Room_Details;
                obj.Canteen_Cafeteria_Capacity = input.Canteen_Cafeteria_Capacity;
                obj.Canteen_Caf_for_Staffs_Avail = input.Canteen_Caf_for_Staffs_Avail;
                obj.Central_Library_Available = input.Central_Library_Available;
                obj.CoE_Program_Available = input.CoE_Program_Available;
                obj.CoE_Program_Details = input.CoE_Program_Details;
                obj.Conference_Room_Available = input.Conference_Room_Available;
                obj.CSR_Activities_Available = input.CSR_Activities_Available;
                obj.CSR_Activity_Details = input.CSR_Activity_Details;
                obj.Digital_Library_Available = input.Digital_Library_Available;
                obj.Dispensary_Available = input.Dispensary_Available;
                obj.Field_Area_in_Acres = input.Field_Area_in_Acres;
                obj.Field_Available = input.Field_Available;
                obj.Field_Gallery_Available = input.Field_Gallery_Available;
                obj.Floor_size_of_the_Video_conf = input.Floor_size_of_the_Video_conf;
                obj.Girls_Common_Room_Available = input.Girls_Common_Room_Available;
                obj.Girls_Common_Room_Details = input.Girls_Common_Room_Details;
                obj.Internet_Connection_Available = input.Internet_Connection_Available;
                obj.Library_Available = input.Library_Available;
                obj.Rain_Water_Harvesting_Avail = input.Rain_Water_Harvesting_Avail;
                obj.Roof_Top_Solar_Panel_Available = input.Roof_Top_Solar_Panel_Available;
                obj.Sewage_Treatment_Plant_Avail = input.Sewage_Treatment_Plant_Avail;
                obj.Sports_Court_Area_in_Sqft = input.Sports_Court_Area_in_Sqft;
                obj.Sports_Court_Available = input.Sports_Court_Available;
                obj.Staff_Common_Room_Available = input.Staff_Common_Room_Available;
                obj.Staff_Common_Room_Details = input.Staff_Common_Room_Details;
                obj.Uploaded_FileName = input.Uploaded_FileName;
                obj.Video_Conference_Room_Avail = input.Video_Conference_Room_Avail;
                obj.Video_Conference_Room_Capacity = input.Video_Conference_Room_Capacity;
                obj.Video_Conference_Room_Location = input.Video_Conference_Room_Location;
                obj.Year_of_Establis_of_institute = input.Year_of_Establis_of_institute;


                _obj_Binding.Update(ref obj);
                return ExceptionHelper.UpdateMessage;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        private static void Context_BuildingRequest(object sender, BuildingRequestEventArgs e)
        {
            string authKey = ConfigurationManager.AppSettings["AuthKey"].ToString();
            if (!string.IsNullOrEmpty(authKey))
            {
                e.Headers.Add("Authorization", authKey);
            }
        }
    }
}
