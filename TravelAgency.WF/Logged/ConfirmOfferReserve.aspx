<%@ Page Title="Confirmation" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConfirmOfferReserve.aspx.cs" Inherits="TravelAgency.WF.ConfirmOfferReserve" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField runat="server" ID="OfferId" />
    <asp:Label runat="server" ID="Message" CssClass="text-primary" />
    <asp:Panel ID="pnlConfirm" runat="server" Visible="false">
    <br />
        <asp:Button runat="server" ID="ConfirmButton" Text="Confirm" 
            OnClick="ConfirmButton_Click" CssClass="btn btn-default"/>
    </asp:Panel>
    <br />
    <br />
    <asp:LinkButton runat="server" ID="BackToOfferButton" Text="Back to offer" OnClick="BackToOfferButton_Click"/>
</asp:Content>
