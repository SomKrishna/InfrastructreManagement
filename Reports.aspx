<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultMasterPage.Master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="InfrastructureManagement.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link rel="stylesheet" href="https://pro.fontawesome.com/releases/v5.12.1/css/all.css" />

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

        .col-lg-12.col-md-12.summary-box {
            margin: 94px 10px 10px -113px;
        }
    </style>

    <div class="container box col-lg-12 col-md-12" id="booggg">
        <div class="row">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <div class="col-lg-12 NewEntrydiv">
                            <p class="NewEntry">Reports</p>
                        </div>
                    </div>
                    <div class="modal-body">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 model-box">
                                <div class="row">
                                    <div class="row md-12 marginx">
                                        <ol>
                                            <li>
                                                <asp:LinkButton runat="server">Report 1</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 2</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 3</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 4</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 5</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 6</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 7</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 8</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 9</asp:LinkButton></li>
                                            <li>
                                                <asp:LinkButton runat="server">Report 10</asp:LinkButton></li>
                                        </ol>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

