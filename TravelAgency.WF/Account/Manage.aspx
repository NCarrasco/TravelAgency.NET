<%@ Page Title="Account Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage.aspx.cs" Inherits="TravelAgency.WF.Account.Manage" %>

<%@ Register TagPrefix="travel" TagName="PersonControl" Src="~/Account/_PersonRegister.ascx" %>
<%@ Register TagPrefix="travel" TagName="FirmControl" Src="~/Account/_FirmRegister.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <asp:Label runat="server" ID="MessageLabel" CssClass="text-info" />

    <div class="form-horizontal">
        <% if (IsPerson) {%>
        <asp:PlaceHolder ID="PersonPanel" runat="server">
            <div>
                <h2>Edit Person Data</h2>
                <travel:PersonControl runat="server" ID="PersonData" IsEditMode="true" Visible="false"/>
            </div>
        </asp:PlaceHolder>
        <%}%>
        <% if (IsFirm) {%>
        <asp:PlaceHolder ID="FirmPanel" runat="server">
            <div>
                <h2>Edit Firm Data</h2>
                <travel:FirmControl runat="server" ID="FirmData" IsEditMode="true" Visible="false" />
            </div>
        </asp:PlaceHolder>
        <%}%>

        <asp:Panel runat="server" ID="ButtonPanel">
            <asp:ValidationSummary runat="server" CssClass="text-danger" />

            <div class="form-group">
                <div class="col-md-offset-2 col-md-10">
                    <asp:Button runat="server" OnClick="SaveData_Click" Text="Save" CssClass="btn btn-default" />
                </div>
            </div>
        </asp:Panel>
    </div>
</asp:Content>
