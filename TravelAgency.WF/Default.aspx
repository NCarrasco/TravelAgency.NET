<%@ Page Title="Travel Agency" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TravelAgency.WF._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--min-height is hardcoded in order to deal with wkhtmltoimage rendering engine--%>
    <div style="min-height: 350px">
        <div class="col-md-4">
            <h2>Offers</h2>
            <p>List of events we offer can be find by selecting the below link.</p>
            <p><a href="Offers">Offer List</a></p>
        </div>
        <div class="col-md-4">
            <h2>Travel Agency</h2>
            <p>
                We offer trips to the country and abroad. Our prices are competitive. We provide a high level of service.
            </p>
            <p><a href="Contact">Contact</a></p>
        </div>
        <% if (User.Identity.IsAuthenticated)
           {  %>
        <div class="col-md-4">
            <h2>Logged in</h2>
            <p>You are logged as: <%: User.Identity.Name %></p>
            <p>
                <asp:LinkButton runat="server" Text="Log out" ID="btnLogOut" OnClick="btnLogOut_Click"></asp:LinkButton>
        </div>
        <% }
           else
           { %>
        <div class="col-md-4">
            <h2>Logged out</h2>
            <p>You are currently logged out. To log in or register select the below link.</p>
            <p><a href="Account/Login">Login or register</a></p>
        </div>
        <% } %>
    </div>
</asp:Content>
