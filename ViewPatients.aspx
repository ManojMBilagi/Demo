<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewPatients.aspx.cs" Inherits="HospitalManagementSystem.ViewPatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <main>

        <style>
            #container {
                display: flex;
                justify-content: center;
                align-items: center;
                margin-bottom: 30px;
            }
        </style>
        <asp:Panel ID="PanelViewMembers" runat="server" Visible="true">
            <div id="container">
                <div>
                    <asp:Button ID="btnAddMembers" CssClass="btn btn-danger" Text="AddMembers" runat="server" OnClick="btnAddMembers_Click" />
                    <asp:Button ID="btnViewMembers" CssClass="btn btn-danger" Text="ViewMembers" runat="server" OnClick="btnViewMembers_Click" />
                </div>
            </div>
            </asp:Panel>
    </main>
</asp:Content>
