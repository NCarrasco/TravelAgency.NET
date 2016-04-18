<%@ Page Title="Offer Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OfferDetails.aspx.cs" Inherits="TravelAgency.WF.OfferDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Offer Details</h2>
    <asp:ObjectDataSource ID="OfferObjectDataSource" runat="server" 
        SelectMethod="FindOffer" 
        TypeName="TravelAgency.BLL.BLL.TravelAgencyService">
        <SelectParameters>
            <asp:QueryStringParameter DefaultValue="0" Name="id" QueryStringField="oid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="OfferDetailsView" runat="server" AutoGenerateRows="False" 
        DataSourceID="OfferObjectDataSource" CssClass="details-data" DataKeyNames="IDOferty">
        <Fields>
            <asp:BoundField DataField="IDOferty" HeaderText="IDOferty" SortExpression="IDOferty" Visible="false"/>
            <asp:CheckBoxField DataField="bWyjazd" HeaderText="Departure" SortExpression="bWyjazd" />
            <asp:BoundField DataField="mCena" HeaderText="Price" SortExpression="mCena" />
            <asp:BoundField DataField="iLiczbaOsob" HeaderText="Person Cont" SortExpression="iLiczbaOsob" />
            <asp:BoundField DataField="Miasto" HeaderText="City" SortExpression="Miasto" />
            <asp:BoundField DataField="MiejsceWyjazdu" HeaderText="Departure Place" SortExpression="MiejsceWyjazdu" />
            <asp:BoundField DataField="LiczbaDniTrwania" HeaderText="Days" SortExpression="LiczbaDniTrwania" />
            <asp:BoundField DataField="DataWyjazdu" HeaderText="Departure Date" SortExpression="DataWyjazdu" />
            <asp:TemplateField ConvertEmptyStringToNull="False" HeaderText="Country" SortExpression="tPanstwa.NazwaPanstwa">
                    <ItemTemplate>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("tPanstwa.NazwaPanstwa") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            <asp:BoundField DataField="Opis" HeaderText="Description" SortExpression="Opis" />
        </Fields>

    </asp:DetailsView>
    <br />
    <%if(!IsOfferReserved){ %>
        <asp:Button runat="server" ID="ReserveButton" Text="Reserve" OnClick="ReserveButton_Click" CssClass="btn btn-default"/>
    <%}%>
    <%if(IsOfferReserved){ %>
        <asp:Label Text="Offer is reserved." CssClass="text-info" runat="server"/>
    <%}%>

    <asp:Panel runat="server" ID="AttractionPanel">
        <h3>Releted Attractions/Services</h3>
        <asp:ObjectDataSource ID="AttractionsObjectDataSource" runat="server" SelectMethod="GetAttractions" 
            TypeName="TravelAgency.BLL.BLL.TravelAgencyService">
            <SelectParameters>
                <asp:QueryStringParameter Name="offerId" QueryStringField="oid" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
        <asp:GridView ID="GridViewAttractions" runat="server" AutoGenerateColumns="False" 
            DataSourceID="AttractionsObjectDataSource"
            CssClass="dataTable"
            OnRowDataBound="GridViewAttractions_RowDataBound"
            DataKeyNames="IDAtrakcjiUslugi">
            <Columns>
                <asp:BoundField DataField="Nazwa" HeaderText="Attraction Name" SortExpression="Nazwa" />
                <asp:BoundField DataField="iLiczbaOsob" HeaderText="Person Count" SortExpression="iLiczbaOsob" />
                <asp:BoundField DataField="mCena" HeaderText="Price" SortExpression="mCena" />
                <asp:BoundField DataField="Opis" HeaderText="Description" SortExpression="Opis" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton runat="server" ID="btnShowDetails" Text="Details" OnClick="btnShowDetails_Click"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>


    </asp:Panel>
</asp:Content>
