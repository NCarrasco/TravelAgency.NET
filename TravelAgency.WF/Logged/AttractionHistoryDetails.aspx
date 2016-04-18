<%@ Page Title="Attraction History Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttractionHistoryDetails.aspx.cs" Inherits="TravelAgency.WF.Logged.AttractionHistoryDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Attraction Details</h2>
    <asp:ObjectDataSource ID="AttractionHistoryObjectDataSource" runat="server" SelectMethod="GetAttractionHistory" 
        TypeName="TravelAgency.BLL.BLL.TravelAgencyService"
        OnSelecting="AttractionHistoryObjectDataSource_Selecting">
        <SelectParameters>
            <asp:Parameter Name="userId" Type="Int32" />
            <asp:QueryStringParameter Name="attractionId" QueryStringField="aid" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" 
        DataSourceID="AttractionHistoryObjectDataSource" CssClass="details-data">
        <Fields>
            <asp:TemplateField HeaderText="Attraction Name" SortExpression="tAtrakcjeHistoria.Nazwa">
                <ItemTemplate>
                    <asp:Label ID="lblName" runat="server" Text='<%# Eval("tAtrakcjeHistoria.Nazwa") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Price" SortExpression="tAtrakcjeHistoria.mCena">
                <ItemTemplate>
                    <asp:Label ID="lblPrice" runat="server" Text='<%# Eval("tAtrakcjeHistoria.mCena") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Person Count" SortExpression="tAtrakcjeHistoria.iLiczbaOsob">
                <ItemTemplate>
                    <asp:Label ID="lblPersonCount" runat="server" Text='<%# Eval("tAtrakcjeHistoria.iLiczbaOsob") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Description" SortExpression="tAtrakcjeHistoria.Opis">
                <ItemTemplate>
                    <asp:Label ID="lblDescription" runat="server" Text='<%# Eval("tAtrakcjeHistoria.Opis") %>'/>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="DataZaplaty" HeaderText="Payment Date" SortExpression="DataZaplaty" />
            <asp:BoundField DataField="ZaplaconaKwota" HeaderText="Payed Amount" SortExpression="ZaplaconaKwota" />
            <asp:BoundField DataField="SposobZaplatyText" HeaderText="Payment Manner" ReadOnly="True" SortExpression="SposobZaplatyText" />
            <asp:TemplateField HeaderText="Person First Name" SortExpression="tOsoby.Imie">
                <ItemTemplate>
                    <asp:Label ID="lblFirstName" runat="server" Text='<%# Eval("tOsoby.Imie") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Person Surname" SortExpression="tOsoby.Nazwisko">
                <ItemTemplate>
                    <asp:Label ID="lblSurname" runat="server" Text='<%# Eval("tOsoby.Nazwisko") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <br />
    <asp:LinkButton runat="server" Text="Back to offer" ID="btnOfferHistory" OnClick="btnOfferHistory_Click"/>
</asp:Content>
