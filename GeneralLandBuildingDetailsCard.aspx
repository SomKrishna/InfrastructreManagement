<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="GeneralLandBuildingDetailsCard.aspx.cs" Inherits="InfrastructureManagement.GeneralLandBuildingDetailsCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .summary-box {
            margin-top: 75px;
            height: auto;
            text-align: center;
            box-shadow: 0 3px 6px rgba(0, 0, 0, 0.16), 0 3px 6px rgba(0, 0, 0, 0.23);
            border: 1px solid;
        }

        .container.box {
            margin-top: 61px;
            margin-bottom: 26px;
        }

        p.NewEntry {
            float: left;
            font-weight: 600;
            color: black;
        }

        .col-lg-12.NewEntrydiv {
            background-color: #eeeeee;
        }

        p.Introduction {
            float: left;
            color: black;
            padding: 23px;
            text-transform: uppercase;
            font-weight: 700;
        }

        .row.md-12.marginx {
            margin: 69px;
            padding-bottom: 36px;
            border-bottom: 3px solid black;
        }

        i.fal.fa-plus-circle.full {
            font-size: 52px;
            float: right;
            margin: 6px;
        }

        .Addaditional {
            border: solid 1px black;
            background-color: white;
            width: auto;
            height: 43px;
            margin: 10px;
            float: left;
        }

        .btn-s.float-right {
            float: right;
            background: white;
            width: 72px;
            height: 31px;
        }

        .form-control {
            height: 33px;
            margin: 2px 0;
            font-size: 13px;
            background-color: white;
            color: #000;
            font-weight: 700;
            border: 1px solid #7f7e7e;
        }

        select.form-control {
            background-color: white;
        }
        /*Modal Control*/
        .modal-dialog {
            width: 978px;
            margin: 30px auto;
        }

        .modal-header {
            background-color: white;
            font-size: 16px;
            line-height: 28px;
            padding: 10px 15px;
            display: inline-block;
            color: #f5f5f5;
            border-top: none;
            width: 100%;
        }

            .modalExtender-heading .close, .modal-header .close {
                margin: 6px;
            }

        .col-md-6.Buliding {
            border-bottom: 1px solid;
            padding: 20px;
        }

        h3.hadingline {
            color: black;
            font-size: 20px;
        }

        .btn-s.float-right.submit {
            background: black;
            color: white;
        }

        h3.hadingline {
            border-bottom: 1px solid;
        }
    </style>

    <div class="container box">

        <div class="card">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-3 col-md-2"></div>
                    <div class="col-lg-12 col-md-12">
                        <div class="row">
                            <div class="card-body">
                                <div class="row md-12 marginx">
                                    <div class="headerbox">
                                        <h1 class="NewEntry"></h1>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="row">
                                            <h3 class="hadingline">General Land/Building Detail Card</h3>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Year of Establishment</label>
                                                        <asp:TextBox ID="txtYear_of_Establis_of_institute" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Field Available</label>
                                                        <asp:DropDownList ID="ddlFieldAvailable" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Field Area (in Acres)</label>
                                                        <asp:TextBox ID="txtField_Area_in_Acres" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Sport's Court Available</label>
                                                        <asp:DropDownList ID="ddlSportCourt" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Sports Court Area (in Sqft)</label>
                                                        <asp:TextBox ID="txtSports_Court_Area_in_Sqft" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Field Gallery Available</label>
                                                        <asp:DropDownList ID="ddlFieldGalleryAvailable" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Conference Room Available</label>
                                                        <asp:DropDownList ID="ddlConferenceRoomAvailable" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Video Conference Room Available </label>
                                                        <asp:DropDownList ID="ddlVideo_Conference_Room_Avail" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Floor size of the Vide Conf.</label>
                                                        <asp:TextBox ID="txtFloor_size_of_the_Video_conf" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Video Conference Room Capacity</label>
                                                        <asp:TextBox ID="txtVideo_Conference_Room_Capacity" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="exampleAccount">Video Conference Room Location</label>
                                                        <asp:TextBox ID="txtVideo_Conference_Room_Location" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Library Available</label>
                                                        <asp:DropDownList ID="ddlLibrary_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="exampleAccount">Central Library Available</label>
                                                        <asp:DropDownList ID="ddlCentralLibraryAvailable" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Digital Library Available</label>
                                                        <asp:DropDownList ID="ddlDigitalLibraryAvailable" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Canteen/Cafeteria for Staff Avail.</label>
                                                        <asp:DropDownList ID="ddlCanteen_Caf_for_Staffs_Avail" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="exampleAccount">Canteen/Cafeteria Capacity</label>
                                                        <asp:TextBox ID="txtCanteen_Cafeteria_Capacity" onkeypress="return isDecimalNumberKey(event)" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="col-md-6 contact-info">
                                                <div class="container">
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Dispensary Available</label>
                                                        <asp:DropDownList ID="ddlDispensary_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">COE Program Available</label>
                                                        <asp:DropDownList ID="ddlCoE_Program_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">COE Program Details</label>
                                                        <asp:TextBox ID="txtCoE_Program_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">CSR Activities Available</label>
                                                        <asp:DropDownList ID="ddlCSR_Activities_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">CSR Activity Details</label>
                                                        <asp:TextBox ID="txtCSR_Activity_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Staff Common Room Available</label>
                                                        <asp:DropDownList ID="ddlStaff_Common_Room_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Staff Common Room Details</label>
                                                        <asp:TextBox ID="txtStaff_Common_Room_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Girls Common Room Available</label>
                                                        <asp:DropDownList ID="ddlGirls_Common_Room_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Girls Common Room Details</label>
                                                        <asp:TextBox ID="txtGirls_Common_Room_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>

                                                    <div class="form-group">
                                                        <label for="exampleAccount">Boys Common Room Available</label>
                                                        <asp:DropDownList ID="ddlBoys_Common_Room_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Selected="True" Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Boys Common Room Details</label>
                                                        <asp:TextBox ID="txtBoys_Common_Room_Details" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>


                                                    <div class="form-group">
                                                        <label for="exampleAccount">Roof Top Solar Panel Available</label>
                                                        <asp:DropDownList ID="ddlRoof_Top_Solar_Panel_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Rain Water Harvestin Available</label>
                                                        <asp:DropDownList ID="ddlRain_Water_Harvesting_Avail" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Sewage Treatment Plant Available</label>
                                                        <asp:DropDownList ID="ddlSewage_Treatment_Plant_Avail" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Internet Connection Available</label>
                                                        <asp:DropDownList ID="ddlInternet_Connection_Available" CssClass="form-control" runat="server">
                                                            <asp:ListItem Value="Select">Select</asp:ListItem>
                                                            <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                                            <asp:ListItem Value="No">No</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label for="exampleAccount">Uploaded FileName</label>
                                                        <asp:TextBox ID="txtUploaded_FileName" CssClass="form-control" runat="server"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-12">
                                        <asp:HiddenField ID="hdnKey" runat="server" /> 
                                        <asp:Button ID="GenralSubmitBtn" runat="server" OnClick="GenralSubmitBtn_Click" CssClass="btn-s float-right submit" type="submit" Text="Submit" />
                                        <asp:Button ID="GenralUpdateBtn" runat="server" OnClick="GenralUpdateBtn_Click" CssClass="btn-s float-right submit" type="submit" Text="Update" />
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="col-lg-3 col-md-2">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js"></script>
    <script language="Javascript">
        function isDecimalNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : event.keyCode
            if (charCode != 46 && charCode > 31 && (charCode < 48 || charCode > 57))
                return false;
            return true;
        }
    </script>
</asp:Content>
