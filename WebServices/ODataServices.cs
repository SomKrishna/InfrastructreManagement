using Microsoft.OData.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServices
{
    public class ODataServices
    {
        public static List<InfraOdata.LandDetailList> GetLandDetailList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.LandDetailList> q = container.CreateQuery<InfraOdata.LandDetailList>("LandDetailList").ToList();

            return q;
        }

        public static List<InfraOdata.AuditoriumBuilding> GetAuditoriumList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.AuditoriumBuilding> q = container.CreateQuery<InfraOdata.AuditoriumBuilding>("AuditoriumBuilding").ToList();

            return q;
        }

        public static string CreateAuditorium(AuditoriumReference.AuditoriumBuilding obj)
        {
            try
            {
                AuditoriumReference.AuditoriumBuilding_Service _obj_Binding = (AuditoriumReference.AuditoriumBuilding_Service)Configuration.getNavService(new AuditoriumReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page");
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
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
                List<InfraOdata.AuditoriumBuilding> objList = GetAuditoriumList().Where(x => string.Equals(x.Building_Code, input.Building_Code, StringComparison.OrdinalIgnoreCase)).ToList();

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
                return "Information Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static InfraOdata.AuditoriumBuilding GetAuditorium(string buildingCode)
        {
            AuditoriumReference.AuditoriumBuilding_Service _obj_Binding = (AuditoriumReference.AuditoriumBuilding_Service)Configuration.getNavService(new AuditoriumReference.AuditoriumBuilding_Service(), "AuditoriumBuilding", "Page");
            AuditoriumReference.AuditoriumBuilding obj = new AuditoriumReference.AuditoriumBuilding();
            List<InfraOdata.AuditoriumBuilding> objList = GetAuditoriumList().Where(x => string.Equals(x.Building_Code, buildingCode, StringComparison.OrdinalIgnoreCase)).ToList();
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
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<InfraOdata.InstituteBuildingsList> GetInstituteBuildings()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.InstituteBuildingsList> q = container.CreateQuery<InfraOdata.InstituteBuildingsList>("InstituteBuildingsList").ToList();

            return q;
        }

        public static string UpdateInstituteBuilding(InstituteReference.InstituteBuildingCard input)
        {
            try
            {
                InstituteReference.InstituteBuildingCard_Service _obj_Binding = (InstituteReference.InstituteBuildingCard_Service)Configuration.getNavService(new InstituteReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page");
                InstituteReference.InstituteBuildingCard obj = new InstituteReference.InstituteBuildingCard();
                List<InfraOdata.InstituteBuildingsList> objList = GetInstituteBuildings().Where(x => string.Equals(x.Block_Code, input.Block_Code, StringComparison.OrdinalIgnoreCase)).ToList();


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
                return "Information Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static InfraOdata.InstituteBuildingsList GetInstituteBuilding(string blockCode)
        {
            InstituteReference.InstituteBuildingCard_Service _obj_Binding = (InstituteReference.InstituteBuildingCard_Service)Configuration.getNavService(new InstituteReference.InstituteBuildingCard_Service(), "InstituteBuildingCard", "Page");
            InstituteReference.InstituteBuildingCard obj = new InstituteReference.InstituteBuildingCard();
            List<InfraOdata.InstituteBuildingsList> objList = GetInstituteBuildings().Where(x => string.Equals(x.Block_Code, blockCode, StringComparison.OrdinalIgnoreCase)).ToList();
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

        public static List<InfraOdata.HostelBuildingsList> GetHostelBuildings()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.HostelBuildingsList> q = container.CreateQuery<InfraOdata.HostelBuildingsList>("HostelBuildingsList").ToList();

            return q;
        }

        public static InfraOdata.HostelBuildingsList GetHostelBuilding(string blockCode)
        {
            HostelReference.HostelBuildingCard_Service _obj_Binding = (HostelReference.HostelBuildingCard_Service)Configuration.getNavService(new HostelReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page");
            HostelReference.HostelBuildingCard obj = new HostelReference.HostelBuildingCard();
            List<InfraOdata.HostelBuildingsList> objList = GetHostelBuildings().Where(x => string.Equals(x.Block_Code, blockCode, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();

        }

        public static string UpdateHostelBuilding(HostelReference.HostelBuildingCard input)
        {
            try
            {
                HostelReference.HostelBuildingCard_Service _obj_Binding = (HostelReference.HostelBuildingCard_Service)Configuration.getNavService(new HostelReference.HostelBuildingCard_Service(), "HostelBuildingCard", "Page");
                HostelReference.HostelBuildingCard obj = new HostelReference.HostelBuildingCard();
                List<InfraOdata.HostelBuildingsList> objList = GetHostelBuildings().Where(x => string.Equals(x.Block_Code, input.Block_Code, StringComparison.OrdinalIgnoreCase)).ToList();

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
                return "Information Updated Successfully";
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
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<InfraOdata.StaffQuartersList> GetStaffQuarters()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.StaffQuartersList> q = container.CreateQuery<InfraOdata.StaffQuartersList>("StaffQuartersList").ToList();

            return q;
        }

        public static InfraOdata.StaffQuartersList GetStaffQuarter(string quaterNo)
        {
            StaffReference.StaffQuarterCard_Service _obj_Binding = (StaffReference.StaffQuarterCard_Service)Configuration.getNavService(new StaffReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page");
            StaffReference.StaffQuarterCard obj = new StaffReference.StaffQuarterCard();
            List<InfraOdata.StaffQuartersList> objList = GetStaffQuarters().Where(x => string.Equals(x.Quarter_Code, quaterNo, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();
        }

        public static string UpdateStaffQuarter(StaffReference.StaffQuarterCard input)
        {
            try
            {
                StaffReference.StaffQuarterCard_Service _obj_Binding = (StaffReference.StaffQuarterCard_Service)Configuration.getNavService(new StaffReference.StaffQuarterCard_Service(), "StaffQuarterCard", "Page");
                StaffReference.StaffQuarterCard obj = new StaffReference.StaffQuarterCard();
                List<InfraOdata.StaffQuartersList> objList = GetStaffQuarters().Where(x => string.Equals(x.Quarter_Code, input.Quarter_Code, StringComparison.OrdinalIgnoreCase)).ToList();

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
                return "Information Updated Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<InfraOdata.NewProjectDetails> GetAllNewProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.NewProjectDetails> q = container.CreateQuery<InfraOdata.NewProjectDetails>("NewProjectDetails").ToList();

            return q;
        }

        public static string CreateNewProject(NewProjectReference.Newprojectcard obj)
        {
            try
            {
                NewProjectReference.Newprojectcard_Service _obj_Binding = (NewProjectReference.Newprojectcard_Service)Configuration.getNavService(new NewProjectReference.Newprojectcard_Service(), "Newprojectcard", "Page");
                _obj_Binding.Create(ref obj);
                return "Data Saved Successfully";
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
                return "Data Saved Successfully";
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
                return "Data Saved Successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static List<InfraOdata.Ongoingprojectcard> GetOnGoingTypeProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.Ongoingprojectcard> q = container.CreateQuery<InfraOdata.Ongoingprojectcard>("Ongoingprojectcard").ToList();

            return q;
        }

        public static List<InfraOdata.Improvementprojectcard> GetImprovementTypeProjectDetails()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.Improvementprojectcard> q = container.CreateQuery<InfraOdata.Improvementprojectcard>("Improvementprojectcard").ToList();

            return q;
        }

        public static List<InfraOdata.Institutelist> GetAllInstitutes()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.Institutelist> q = container.CreateQuery<InfraOdata.Institutelist>("Institutelist").ToList();

            return q;
        }

        public static List<InfraOdata.Districtlist> GetAllDistricts()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.Districtlist> q = container.CreateQuery<InfraOdata.Districtlist>("Districtlist").ToList();

            return q;
        }

        public static List<InfraOdata.Projectprogressdetailscard> GetAllProjectProgress()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.Projectprogressdetailscard> q = container.CreateQuery<InfraOdata.Projectprogressdetailscard>("Projectprogressdetailscard").ToList();

            return q;
        }

        public static InfraOdata.Projectprogressdetailscard GetProjectProgressByProjectCode(string projectCode)
        {
            ProjectProgressReference.Projectprogressdetailscard_Service _obj_Binding = (ProjectProgressReference.Projectprogressdetailscard_Service)Configuration.getNavService(new ProjectProgressReference.Projectprogressdetailscard_Service(), "Projectprogressdetailscard", "Page");
            ProjectProgressReference.Projectprogressdetailscard obj = new ProjectProgressReference.Projectprogressdetailscard();
            List<InfraOdata.Projectprogressdetailscard> objList = GetAllProjectProgress().Where(x => string.Equals(x.Project_Code, projectCode, StringComparison.OrdinalIgnoreCase)).ToList();
            return objList.FirstOrDefault();
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
                List<InfraOdata.Projectprogressdetailscard> objList = GetAllProjectProgress().Where(x => string.Equals(x.AA_No, input.AA_No, StringComparison.OrdinalIgnoreCase)).ToList();

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
                return "Information Updated Successfully";
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
                return "Data Saved Successfully";
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
                return "Data Saved Successfully";
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
                return "Data Saved Successfully";
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

        public static List<InfraOdata.VendorList> GetVendorList()
        {
            string serviceUrl = string.Format(Configuration.ODataServiceUrl());
            Uri uri = new Uri(serviceUrl);
            var container = new InfraOdata.NAV(uri);
            container.BuildingRequest += Context_BuildingRequest;
            List<InfraOdata.VendorList> q = container.CreateQuery<InfraOdata.VendorList>("VendorList").ToList();

            return q;
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
