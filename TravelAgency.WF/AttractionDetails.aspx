<%@ Page Title="Attraction Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttractionDetails.aspx.cs" Inherits="TravelAgency.WF.AttractionDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Attraction Details</h2>
    <asp:ObjectDataSource ID="AttractionObjectDataSource" runat="server" SelectMethod="FindAttraction" TypeName="TravelAgency.BLL.BLL.TravelAgencyService">
        <SelectParameters>
            <asp:QueryStringParameter Name="attractionId" QueryStringField="aid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsViewAttraction" runat="server" AutoGenerateRows="False" DataSourceID="AttractionObjectDataSource"
        CssClass="details-data" DataKeyNames="IDAtrakcjiUslugi">
        <Fields>
            <asp:TemplateField HeaderText="Offer Country" SortExpression="tOferta.tPanstwa.NazwaPanstwa">
                <ItemTemplate>
                    <asp:Label ID="lblCountry" runat="server" Text='<%# Eval("tOferta.tPanstwa.NazwaPanstwa") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="Nazwa" HeaderText="Attraction Name" SortExpression="Nazwa" />
            <asp:BoundField DataField="iLiczbaOsob" HeaderText="Person Count" SortExpression="iLiczbaOsob" />
            <asp:BoundField DataField="mCena" HeaderText="Price" SortExpression="mCena" />
            <asp:BoundField DataField="Opis" HeaderText="Description" SortExpression="Opis" />
        </Fields>
    </asp:DetailsView>

    <br />
    <%if (!IsAttractionReserved)
      { %>
    <% if (CanReserveAttraction)
       { %>
    <asp:Button runat="server" ID="ReserveButton" Text="Reserve" OnClick="ReserveButton_Click" CssClass="btn btn-default" />
    <% }
       else
       {%>
    <asp:Label Text="Reservation cannot be done: offer has to be reserved first." CssClass="text-info" runat="server" />
    <%} %>
    <%}%>
    <%if (IsAttractionReserved)
      { %>
    <asp:Label Text="Attraction is reserved." CssClass="text-info" runat="server" />
    <%}%>

    <br />
    <br />
    <asp:LinkButton ID="btnBackToOffer" runat="server" Text="Back to offer" OnClick="btnBackToOffer_Click" />
</asp:Content>
