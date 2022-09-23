<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="MasterDataBuilding.aspx.cs" Inherits="InfrastructureManagement.MasterDataBuilding" %>
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
.modalExtender-heading .close, .modal-header .close{
    margin: 6px;
}
.col-md-6.Buliding {
    border-bottom: 1px solid;
    padding: 20px;
}
h3.hadingline {
    color: black;
    font-size: 20px;
    float:left;
    margin:31px;
}
.btn-s.float-right.submit {
    background: black;
    color: white;
}
.editbutton {
    background: white;
    border: 2.5px dotted;
    width: 129px;
}
table thead tr th, .table > tbody > tr > th {
    background-color: #60594f;
    color: #fefefe !important;
    border-top: none !important;
    font-size: small;
    font-weight: normal;
    vertical-align: middle !important;
    outline: none;
}
.btn-s.float-right.Export {
    width: 100px;
    float: left;
}
 .col-lg-12.col-md-12.summary-box {
    margin: 94px 10px 10px -113px;
}
    </style>
    <div class="container box">
        <div class="row">
            <div class="col-lg-3 col-md-2"></div>
    <%-- Master Data --%>
        <div class="col-lg-12 col-md-12 summary-box">
            <div class="col-lg-12 NewEntrydiv">
                    <p class="NewEntry">Sanctioned Staff Quarter Details Input</p>
            </div>
                  <div class="col-md-12 float-left">
                    <h3 class="hadingline">Name of the Institute-ITI Cuttack</h3>
                </div>
              
                
             
               
                <div class="row">
                   
                <div class="card-body">
                    <div class="row md-12 marginx">
                       <table class="table">
                          <thead class="thead-dark">
                            <tr>
                              <th scope="col">Available Building Types</th>
                              <th scope="col">Total Number of Building Block/s Available</th>
                              <th scope="col">Total Number of Unsafe Buildings</th>
                            </tr>
                          </thead>
                          <tbody>
                            <tr>
                              <td><asp:Button ID="Button6" runat="server" CssClass="editbutton" Text="Institutional" /></td>
                              <td></td>
                              <td></td>
                            </tr>
                            <tr>
                              <td><asp:Button ID="Button2" runat="server" CssClass="editbutton" Text="Hostel" /></td>
                              <td></td>
                              <td></td>
                            </tr>
                            <tr>
                              <td><asp:Button ID="Button3" runat="server" CssClass="editbutton" Text="Staff Quarter" /></td>
                              <td></td>
                              <td></td>
                            </tr>
                              <tr>
                              <td><asp:Button ID="Button4" runat="server" CssClass="editbutton" Text="Auditorium" /></td>
                              <td></td>
                              <td></td>
                            </tr>
                          </tbody>
                        </table>
                        <div class="col-md-12">
                            <asp:Button ID="Button1" runat="server" CssClass="btn-s float-right Export" type="submit"  Text="Export CSV" />
                        </div>
                    </div>
                </div>
                        
                </div>
            <div class="col-lg-3 col-md-2">
                    
            </div>
        </div>
        </div>
    </div>
</asp:Content>
